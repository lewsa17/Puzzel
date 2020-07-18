namespace PuzzelLibrary.Settings
{
    interface ISettings
    {
        string UserName { get; }
        string Password { get; }
        string Version { get; }
    }
}
