namespace netcore_api_docker.Api
{
    public class Settings
    {
        public string ConnectionString { get; set; }
        public SettingItem[] Items { get; set; }
    }

    public class SettingItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
