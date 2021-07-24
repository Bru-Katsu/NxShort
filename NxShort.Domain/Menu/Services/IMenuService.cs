using NxShort.Domain.Menu.Enums;

namespace NxShort.Domain.Menu.Services
{
    public interface IMenuService
    {
        void Register(MenuEntry entry, EntryType type);
        void Remove(MenuEntry entry);
    }
}
