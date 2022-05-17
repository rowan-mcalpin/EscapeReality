using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeReality
{
    /// <summary>
    /// Contains all of the machine-dependant variables, primarily paths.
    /// TODO: Add settings button in launcher to change the paths.
    /// </summary>
    public class Constants
    {
        internal static string ROOT;
        internal static string VERSION_FILE;
        internal static string GAME_EXE;
        internal static string WORKING_DIRECTORY;
        internal static string GAME_ZIP;
        internal static string ONLINE_VERSION_LINK;
        internal static string ONLINE_GAME_LINK;
        internal static string GAME_INSTALL;
        internal static string GAME_FOLDER;

        static Constants()
        {
            ROOT = Directory.GetCurrentDirectory();
            VERSION_FILE = Path.Combine(ROOT, "Version.txt");
            GAME_ZIP = Path.Combine(ROOT, "GameDownload.zip");
            ONLINE_VERSION_LINK = "https://raw.githubusercontent.com/REM-Codes/EscapeReality/version/Version.txt";
            ONLINE_GAME_LINK = "https://github.com/REM-Codes/EscapeReality/archive/refs/heads/release.zip";
            GAME_INSTALL = Path.Combine(ROOT, "Install");
            GAME_FOLDER = Path.Combine(GAME_INSTALL, "EscapeReality-release");
            GAME_EXE = Path.Combine(GAME_FOLDER, "EscapeReality.exe");
            WORKING_DIRECTORY = Path.Combine(ROOT, "GameFiles");
        }

        public static void ResetConstants()
        {
            ROOT = Directory.GetCurrentDirectory();
            VERSION_FILE = Path.Combine(ROOT, "Version.txt");
            GAME_ZIP = Path.Combine(ROOT, "GameDownload.zip");
            ONLINE_VERSION_LINK = "https://raw.githubusercontent.com/REM-Codes/EscapeReality/version/Version.txt";
            ONLINE_GAME_LINK = "https://github.com/REM-Codes/EscapeReality/archive/refs/heads/release.zip";
            GAME_INSTALL = Path.Combine(ROOT, "Install");
            GAME_FOLDER = Path.Combine(GAME_INSTALL, "EscapeReality-release");
            GAME_EXE = Path.Combine(GAME_FOLDER, "EscapeReality.exe");
            WORKING_DIRECTORY = Path.Combine(ROOT, "Build");
        }
    }
}
