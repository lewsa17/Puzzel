namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 132; }
        public static int Build { get => 225; }
        public static string Hash { get => "2bfa0a5d"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("07.11.2020 13:58:28"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
