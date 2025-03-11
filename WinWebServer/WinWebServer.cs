using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Mime;
using System.Text.Json;



namespace WinWebServer
{
    public partial class WinWebServer : Form
    {

        private int port;
        private bool isPublic;
        private WebApplication webHost;



        public WinWebServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Log($"[INFO] Control Panel started successfully");
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                port = int.Parse(txtPort.Text);
            }
            catch {
                MessageBox.Show("Invalid port number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isPublic = chkPublic.Checked;
            bool useHttps = chkUseHttps.Checked;
            string certPath = txtCertPath.Text;
            string certPassword = txtCertPassword.Text;

            string host = isPublic ? $"http://*:{port}" : $"http://localhost:{port}";

            var builder = WebApplication.CreateBuilder();
            builder.WebHost.UseKestrel(options =>
            {
                options.ListenAnyIP(port);

                if (useHttps && File.Exists(certPath))
                {
                    try
                    {
                        options.ListenAnyIP(port, listenOptions =>
                        {
                            listenOptions.UseHttps(certPath, certPassword);
                        });
                        Log($"[INFO] Using SSL certificate: {certPath}");
                    }
                    catch (Exception ex)
                    {
                        Log($"[ERROR] Error loading certificate: {ex.Message}");
                        MessageBox.Show("Invalid SSL certificate or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            });

            builder.WebHost.UseUrls(host);
            webHost = builder.Build();

            webHost.UseStaticFiles();
            webHost.UseRouting();
#pragma warning disable ASP0014
            webHost.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{**path}", async context =>
                {
                    string clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
                    string requestedPath = context.Request.Path.ToString();
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string errorForbiddenPagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errors", "403.html");

                    if (chkEnableBlacklist.Checked && ipBlacklist.Contains(clientIp))
                    {
                        Log($"[WARN] [403] Blocked access from blacklisted IP {clientIp}");
                        if (File.Exists(errorForbiddenPagePath))
                        {
                            context.Response.ContentType = "text/html";
                            await context.Response.SendFileAsync(errorForbiddenPagePath);
                        }
                        else
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 - Forbidden: Your IP is banned.");
                        }
                        return;
                    }



                    if (chkEnableWhitelist.Checked && !ipWhitelist.Contains(clientIp))
                    {
                        Log($"[WARN] [403] Unauthorized access attempt from {clientIp}");

                        if (File.Exists(errorForbiddenPagePath))
                        {
                            context.Response.ContentType = "text/html";
                            await context.Response.SendFileAsync(errorForbiddenPagePath);
                        }
                        else
                        {
                            context.Response.StatusCode = 403;
                            await context.Response.WriteAsync("403 - Forbidden: Your IP is not allowed.");
                        }
                        return;
                    }

                    if (string.IsNullOrEmpty(requestedPath) || requestedPath == "/")
                        requestedPath = "index.html";

                    string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", requestedPath);





                    Log($"[INFO] Client {clientIp} requested '{requestedPath}'");

                    if (File.Exists(filePath))
                    {
                        string contentType = GetContentType(filePath);
                        context.Response.ContentType = contentType;
                        await context.Response.SendFileAsync(filePath);
                    }
                    else
                    {
                        string errorPagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errors", "404.html");
                        if (File.Exists(errorPagePath))
                        {
                            context.Response.ContentType = "text/html";
                            await context.Response.SendFileAsync(errorPagePath);
                        }
                        else
                        {
                            context.Response.StatusCode = 404;
                            await context.Response.WriteAsync("404 - Page Not Found");
                        }
                        Log($"[ERROR] [404] {clientIp} requested '{requestedPath}' - Not Found");
                    }
                });

            });










#pragma warning restore ASP0014

            _ = Task.Run(() => webHost.RunAsync());

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = $"Server Status: Running on {host}";
            Log($"[INFO] Server started on {host}");
        }




        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension switch
            {
                ".html" => "text/html",
                ".css" => "text/css",
                ".js" => "application/javascript",
                ".png" => "image/png",
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".gif" => "image/gif",
                ".svg" => "image/svg+xml",
                ".ico" => "image/x-icon",
                ".json" => "application/json",
                ".txt" => "text/plain",
                ".woff" => "font/woff",
                ".woff2" => "font/woff2",
                ".ttf" => "font/ttf",
                ".eot" => "application/vnd.ms-fontobject",
                _ => "application/octet-stream", // Default if unknown
            };
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            if (webHost != null)
            {
                await webHost.StopAsync();
                webHost = null;

                btnStart.Enabled = true;
                btnStop.Enabled = false;
                lblStatus.Text = "Server Status: Stopped";
                Log("[INFO] Server stopped.");
            }
        }














        private Dictionary<string, string> userCredentials = new();

        private void LoadUserCredentials()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "users.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                userCredentials = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new();
            }
            else
            {
                userCredentials = new();
                File.WriteAllText(filePath, JsonSerializer.Serialize(userCredentials, new JsonSerializerOptions { WriteIndented = true }));
            }
        }




















        private void Log(string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Format: YYYY-MM-DD HH:MM:SS
            string logMessage = $"[{timestamp}] {message}";

            if (lstLogs.InvokeRequired)
            {
                lstLogs.Invoke(new Action(() => Log(message)));
                return;
            }

            lstLogs.Items.Insert(0, logMessage);
            if (lstLogs.Items.Count > 100)
            {
                lstLogs.Items.RemoveAt(lstLogs.Items.Count - 1);
            }
        }







        private void btnBrowseCert_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PFX Certificate|*.pfx";
                openFileDialog.Title = "Select SSL Certificate";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtCertPath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnOpenWwwroot_Click(object sender, EventArgs e)
        {
            string wwwrootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");

            if (Directory.Exists(wwwrootPath))
            {
                Process.Start("explorer.exe", wwwrootPath);
            }
            else
            {
                MessageBox.Show("The wwwroot folder does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }














        private List<string> ipWhitelist = new List<string>();

        private void btnAddIP_Click(object sender, EventArgs e)
        {
            string newIP = txtWhitelistIP.Text.Trim();
            if (!string.IsNullOrEmpty(newIP) && !ipWhitelist.Contains(newIP))
            {
                ipWhitelist.Add(newIP);
                lstWhitelist.Items.Add(newIP);
                txtWhitelistIP.Clear();
                Log($"[INFO] Added IP to whitelist: {newIP}");
            }
        }

        private void btnRemoveIP_Click(object sender, EventArgs e)
        {
            if (lstWhitelist.SelectedItem != null)
            {
                string selectedIP = lstWhitelist.SelectedItem.ToString();
                ipWhitelist.Remove(selectedIP);
                lstWhitelist.Items.Remove(selectedIP);
                Log($"[INFO] Removed IP from whitelist: {selectedIP}");
            }
            else
            {
                MessageBox.Show("Please select an IP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkEnableWhitelist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableWhitelist.Checked)
            {
                Log("[INFO] Enabled Whitelist");
            }
            else
            {
                Log("[INFO] Disabled Whitelist");
            }
        }

        private List<string> ipBlacklist = new List<string>();

        private void btnAddBlacklistIP_Click(object sender, EventArgs e)
        {
            string newIP = txtBlacklistIP.Text.Trim();
            if (!string.IsNullOrEmpty(newIP) && !ipBlacklist.Contains(newIP))
            {
                ipBlacklist.Add(newIP);
                lstBlacklist.Items.Add(newIP);
                txtBlacklistIP.Clear();
                Log($"[INFO] Added IP to blacklist: {newIP}");
            }
        }

        private void btnRemoveBlacklistIP_Click(object sender, EventArgs e)
        {
            if (lstBlacklist.SelectedItem != null)
            {
                string selectedIP = lstBlacklist.SelectedItem.ToString();
                ipBlacklist.Remove(selectedIP);
                lstBlacklist.Items.Remove(selectedIP);
                Log($"[INFO] Removed IP from blacklist: {selectedIP}");
            }
            else
            {
                MessageBox.Show("Please select an IP", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void chkEnableBlacklist_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEnableBlacklist.Checked)
            {
                Log("[INFO] Enabled Blacklist");
            }
            else
            {
                Log("[INFO] Disabled Blacklist");
            }
        }

        private void btnExportLog_Click(object sender, EventArgs e)
        {
            if (lstLogs.Items.Count == 0)
            {
                MessageBox.Show("There are no logs to export.", "Export Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveFileDialog1.Filter = "Log Files (*.log)|*.log|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog1.Title = "Save Log File";
            saveFileDialog1.FileName = $"ServerLog_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                    {
                        foreach (var item in lstLogs.Items)
                        {
                            writer.WriteLine(item.ToString());
                        }
                    }
                    MessageBox.Show("Logs exported successfully!", "Export Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Log($"[INFO] Logs exported to: {saveFileDialog1.FileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving log file:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log($"[ERROR] Failed to export logs: {ex.Message}");
                }
            }
        }

        private void btnVisitPage_Click(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MessageBox.Show("Invalid port number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Determine if HTTPS is enabled
            string protocol = chkUseHttps.Checked ? "https" : "http";
            string url = $"{protocol}://localhost:{port}";

            try
            {
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open browser: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
