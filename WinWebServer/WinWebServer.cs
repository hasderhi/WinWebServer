using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Diagnostics;


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
            cleanupTimer.Interval = 60000; // 1x/1min
            cleanupTimer.Tick += CleanupOldConnections;
            cleanupTimer.Start();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            port = int.Parse(txtPort.Text);
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
                        Log($"Using SSL certificate: {certPath}");
                    }
                    catch (Exception ex)
                    {
                        Log($"Error loading certificate: {ex.Message}");
                        MessageBox.Show("Invalid SSL certificate or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            });

            builder.WebHost.UseUrls(host);
            webHost = builder.Build();

            webHost.UseStaticFiles();
            webHost.UseRouting();
            webHost.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{**path}", async context =>
                {
                    string requestedPath = context.Request.Path.ToString().Trim('/');
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string clientIp = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
                    string wwwrootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
                    string filePath = Path.Combine(wwwrootPath, requestedPath);

                    // Log connection
                    if (lstConnectedUsers.InvokeRequired)
                    {
                        lstConnectedUsers.Invoke(new Action(() => AddUserToList(clientIp, requestedPath, timestamp)));
                    }
                    else
                    {
                        AddUserToList(clientIp, requestedPath, timestamp);
                    }

                    Log($"Client {clientIp} requested '{requestedPath}'");

                    if (Directory.Exists(filePath))
                    {
                        // If dir accessed, check for index.html
                        string indexPath = Path.Combine(filePath, "index.html");
                        if (File.Exists(indexPath))
                        {
                            context.Response.Redirect($"{requestedPath}/index.html");
                            return;
                        }

                        // If no index.html >>> Generate dir listing
                        await GenerateDirectoryListing(context, filePath, requestedPath);
                        return;
                    }

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

                        Log($"[404] {clientIp} requested '{requestedPath}' - Not Found");
                    }
                });
            });

            _ = Task.Run(() => webHost.RunAsync());

            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblStatus.Text = $"Server Status: Running on {host}";
            Log($"Server started on {host}");
        }

        private async Task GenerateDirectoryListing(HttpContext context, string directoryPath, string relativePath)
        {
            string[] files = Directory.GetFiles(directoryPath);
            string[] directories = Directory.GetDirectories(directoryPath);

            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync("<html><head><title>Directory Listing</title>");
            await context.Response.WriteAsync("<style>body { font-family: Arial; } a { display: block; margin: 5px; }</style>");
            await context.Response.WriteAsync("</head><body>");
            await context.Response.WriteAsync($"<h2>Directory Listing: /{relativePath}</h2>");

            // List dirs
            foreach (var dir in directories)
            {
                string dirName = Path.GetFileName(dir);
                await context.Response.WriteAsync($"<a href=\"/{relativePath}/{dirName}/\">📁 {dirName}/</a>");
            }

            // List files
            foreach (var file in files)
            {
                string fileName = Path.GetFileName(file);
                await context.Response.WriteAsync($"<a href=\"/{relativePath}/{fileName}\">📄 {fileName}</a>");
            }

            await context.Response.WriteAsync("</body></html>");
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
                _ => "application/octet-stream", // Default if unknown type
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
                Log("Server stopped.");
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

            lstLogs.Items.Insert(0, logMessage); // Newest logs at top
            if (lstLogs.Items.Count > 100) // Keep only last 100 logs
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










        private void AddUserToList(string ip, string path, string timestamp)
        {
            foreach (ListViewItem item in lstConnectedUsers.Items)
            {
                if (item.SubItems[0].Text == ip && item.SubItems[1].Text == path)
                    return; // Already logged
            }

            ListViewItem newItem = new ListViewItem(ip);
            newItem.SubItems.Add(path);
            newItem.SubItems.Add(timestamp);
            lstConnectedUsers.Items.Insert(0, newItem); // Add to top

            // Limit log size to 100 items
            if (lstConnectedUsers.Items.Count > 100)
            {
                lstConnectedUsers.Items.RemoveAt(lstConnectedUsers.Items.Count - 1);
            }
        }

        private void CleanupOldConnections(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();

            foreach (ListViewItem item in lstConnectedUsers.Items)
            {
                DateTime timestamp = DateTime.Parse(item.SubItems[2].Text);
                if ((now - timestamp).TotalMinutes > 5) // Remove if older than 5 min
                {
                    itemsToRemove.Add(item);
                }
            }

            foreach (var item in itemsToRemove)
            {
                lstConnectedUsers.Items.Remove(item);
            }
        }
    }
}
