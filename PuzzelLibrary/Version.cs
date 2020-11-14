namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 134; }
        public static int Build { get => 250; }
        public static string Hash { get => "2fb7e731"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 01:01:43 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
