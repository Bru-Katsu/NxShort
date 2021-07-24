using System;
using System.Text;
using IWshRuntimeLibrary;
using System.Runtime.InteropServices;
using System.IO;

namespace NxShort.Domain.Menu.Strategies
{
    public class AllUsersStrategy : IShortcutStrategy
    {
        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_STARTMENU = 0x16;
        public void Create(MenuEntry entry)
        {
            StringBuilder allUserProfile = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_COMMON_STARTMENU, false);

            string programs_path = Path.Combine(allUserProfile.ToString(), "Programs");

            string shortcutFolder = Path.Combine(programs_path, entry.Folder);

            if (!Directory.Exists(shortcutFolder))
            {
                Directory.CreateDirectory(shortcutFolder);
            }

            WshShellClass shellClass = new WshShellClass();

            string settingsLink = Path.Combine(shortcutFolder, $"{entry.Name}.lnk");
            IWshShortcut shortcut = (IWshShortcut)shellClass.CreateShortcut(settingsLink);
            shortcut.TargetPath = entry.Path;

            //shortcut.IconLocation = @"C:\Program FilesMorganTechSpacesettings.ico";
            shortcut.Arguments = entry.Arguments;
            shortcut.Description = entry.Description;
            shortcut.Save();
        }
    }
}
