namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 132; }
        public static int Build { get => 226; }
        public static string Hash { get => "9fb244a3"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("Sat Nov 7 14:04:25"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
