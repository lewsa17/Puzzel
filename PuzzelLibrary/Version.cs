namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 135; }
        public static int Build { get => 251; }
        public static string Hash { get => "d7f5d5f2"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-14 01:46:16 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
