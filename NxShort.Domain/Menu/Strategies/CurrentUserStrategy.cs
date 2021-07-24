using IWshRuntimeLibrary;
using System;
using System.IO;

namespace NxShort.Domain.Menu.Strategies
{
    public class CurrentUserStrategy : IShortcutStrategy
    {
        public void Create(MenuEntry entry)
        {
            string programs_path = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
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
