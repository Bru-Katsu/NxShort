using NxShort.Domain.Menu.Enums;
using NxShort.Domain.Menu.Strategies.Factories;
using System;

namespace NxShort.Domain.Menu.Services
{
    public class MenuService : IMenuService
    {
        public void Register(MenuEntry entry, EntryType type)
        {
            var strategy = ShortcutFactory.CreateByType(type);
            strategy.Create(entry);
        }

        public void Remove(MenuEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
