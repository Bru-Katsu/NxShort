namespace NxShort.Domain.Menu
{
    public class MenuEntry
    {
        public MenuEntry()
        {
            Path = string.Empty;
            Folder = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Arguments = string.Empty;
        }
        public MenuEntry(string path, string folder, string name, string description, string arguments)
        {
            Path = path;
            Folder = folder;
            Name = name;
            Description = description;
            Arguments = arguments;
        }

        public string Path { get; private set; }
        public string Folder { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Arguments { get; private set; }
        public void SetPath(string path) => Path = path;
        public void SetFolder(string folder) => Folder = folder;
        public void SetName(string name) => Name = name;
        public void SetDescription(string description) => Description = description;
        public void SetArguments(string arguments) => Arguments = arguments;
    }
}
