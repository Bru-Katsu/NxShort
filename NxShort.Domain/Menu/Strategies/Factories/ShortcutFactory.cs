using NxShort.Domain.Menu.Enums;

namespace NxShort.Domain.Menu.Strategies.Factories
{
    public static class ShortcutFactory
    {
        public static IShortcutStrategy CreateByType(EntryType type)
        {
            var creatorStrategy = default(IShortcutStrategy);

            switch (type)
            {
                case EntryType.AllUsers:
                    creatorStrategy = new AllUsersStrategy();
                    break;
                case EntryType.CurrentUser:
                    creatorStrategy = new CurrentUserStrategy();
                    break;
            }

            return creatorStrategy;
        }
    }
}
