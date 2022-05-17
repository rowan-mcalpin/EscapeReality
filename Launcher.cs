using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Compression;
using System.Net;

namespace EscapeReality.Launcher
{
    public enum LauncherStatus
    {
        UPDATE_FAILED,
        UPDATE_IN_PROGRESS,
        GAME_INSTALLING,
        FAILED,
        READY
    }

    public partial class Launcher : Form
    {
        readonly WebClient webClient;
        private LauncherStatus _status;
        internal LauncherStatus Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case LauncherStatus.UPDATE_IN_PROGRESS:
                        UpdateButton.Text = "Updating...";
                        UpdateButton.Enabled = false;
                        PlayButton.Enabled = false;
                        break;
                    case LauncherStatus.GAME_INSTALLING:
                        UpdateButton.Text = "Installing Game...";
                        UpdateButton.Enabled = false;
                        PlayButton.Enabled = false;
                        break;
                    case LauncherStatus.FAILED:
                        UpdateButton.Text = "Download Failed - Retry";
                        UpdateButton.Enabled = true;
                        PlayButton.Enabled = false;
                        break;
                    case LauncherStatus.READY:
                        UpdateButton.Text = "Check For Updates";
                        UpdateButton.Enabled = true;
                        PlayButton.Enabled = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public Launcher()
        {
            InitializeComponent();
            if (File.Exists(Constants.VERSION_FILE))
            {
                VersionText.Text = File.ReadAllText(Constants.VERSION_FILE);
            }
            webClient = new();
            webClient.Headers.Add("user-agent", "EscapeReality Launcher");
        }

        private void CheckForUpdates()
        {
            if (File.Exists(Constants.VERSION_FILE))
            {
                Version InstalledVersion = new(File.ReadAllText(Constants.VERSION_FILE));
                VersionText.Text = InstalledVersion.ToString();
                    try
                    {
                        Version LatestVersion = new(webClient.DownloadString(Constants.ONLINE_VERSION_LINK));

                        if (LatestVersion.IsDifferentThan(InstalledVersion))
                        {
                            InstallGameFiles(true, LatestVersion);
                        }
                        else
                        {
                            Status = LauncherStatus.READY;
                        }
                    }
                    catch (Exception ex)
                    {
                        Status = LauncherStatus.UPDATE_FAILED;
                        MessageBox.Show($"Error checking for game updates. Details: \n{ex}");
                    }
            } else
            {
                File.Create(Constants.VERSION_FILE);
                File.WriteAllText(Constants.VERSION_FILE, "0.0.0");
                InstallGameFiles(false, Version.zero);
            }
        }

        private void InstallGameFiles(bool IsUpdate, Version TargetVersion)
        {
            if (!File.Exists(Constants.GAME_INSTALL))
            {
                Directory.CreateDirectory(Constants.GAME_INSTALL);
            }
            try
            {
                if (IsUpdate)
                {
                    Status = LauncherStatus.UPDATE_IN_PROGRESS;
                }
                else
                {
                    Status = LauncherStatus.GAME_INSTALLING;
                    TargetVersion = new Version(webClient.DownloadString(Constants.ONLINE_VERSION_LINK));
                }

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadGameCompletedCallback);
                webClient.DownloadFileAsync(new Uri(Constants.ONLINE_GAME_LINK), Constants.GAME_ZIP, TargetVersion);
            } catch (Exception ex)
            {
                Status = LauncherStatus.FAILED;
                MessageBox.Show($"Error installing files. Details: \n{ex}");
            }
        }

        private void DownloadGameCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string OnlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(Constants.GAME_ZIP, Constants.GAME_INSTALL, true);
                File.Delete(Constants.GAME_ZIP);

                File.WriteAllText(Constants.VERSION_FILE, OnlineVersion);

                VersionText.Text = OnlineVersion;
                Status = LauncherStatus.READY;
            }
            catch (Exception ex)
            {
                Status = LauncherStatus.FAILED;
                MessageBox.Show($"Error finishing download. Details: \n{ex}");
            }
        }

        // When window is loaded
        private void Launcher_Load(object sender, EventArgs e)
        {
            // Put the play button in the middle horizontally and 75% vertically
            PlayButton.Left = (this.ClientSize.Width - PlayButton.Width) / 2;
            PlayButton.Top = (this.ClientSize.Height - PlayButton.Height) / 12 * 7;
            UpdateButton.Left = (this.ClientSize.Width - UpdateButton.Width) / 2;
            UpdateButton.Top = (this.ClientSize.Height - UpdateButton.Height) / 12 * 7 + UpdateButton.Height + (UpdateButton.Height) / 2;
            Title.Left = (this.ClientSize.Width - Title.Width) / 2;
            Title.Top = (this.ClientSize.Height - Title.Height) / 4;
        }

        // When window is resized
        private void Launcher_Resize(object sender, EventArgs e)
        {
            // Put the play button in the middle horizontally and 75% vertically
            PlayButton.Left = (this.ClientSize.Width - PlayButton.Width) / 2;
            PlayButton.Top = (this.ClientSize.Height - PlayButton.Height) / 12 * 7;
            UpdateButton.Left = (this.ClientSize.Width - UpdateButton.Width) / 2;
            UpdateButton.Top = ((this.ClientSize.Height - UpdateButton.Height) / 12 * 7) + (UpdateButton.Height) + (UpdateButton.Height / 2);
            Title.Left = (this.ClientSize.Width - Title.Width) / 2;
            Title.Top = (this.ClientSize.Height - Title.Height) / 4;
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Constants.GAME_EXE))
                {
                    Directory.CreateDirectory(Constants.WORKING_DIRECTORY);
                    ProcessStartInfo startInfo = new(Constants.GAME_EXE);
                    startInfo.WorkingDirectory = Constants.WORKING_DIRECTORY;
                    Process.Start(startInfo);

                    Close();
                }
                else
                {
                    throw new FileNotFoundException("EscapeReality.exe not found");
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Could not launch game. Details: \n{ex}");
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            CheckForUpdates();
        }
    }

    struct Version
    {
        internal static readonly Version zero = new(0, 0, 0);
        private readonly ushort Major;
        private readonly ushort Minor;
        private readonly ushort SubMinor;

        internal Version(ushort _major, ushort _minor, ushort _subMinor)
        {
            Major = _major;
            Minor = _minor;
            SubMinor = _subMinor;
        }

        internal Version(string version)
        {
            string[] versionStrings = version.Split('.');
            if (versionStrings.Length != 3)
            {
                Major = 0;
                Minor = 0;
                SubMinor = 0;
                return;
            }
            
            Major = ushort.Parse(versionStrings[0]);
            Minor = ushort.Parse(versionStrings[1]);
            SubMinor = ushort.Parse(versionStrings[2]);
        }

        internal bool IsDifferentThan(Version other)
        {
            if (other.Major != Major)
            {
                return true;
            }
            else
            {
                if (other.Minor != Minor)
                {
                    return true;
                }
                else
                {
                    if (other.SubMinor != SubMinor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{SubMinor}";
        }
    }
}