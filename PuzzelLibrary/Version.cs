namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 165; }
        public static int Build { get => 532; }
        public static string Hash { get => "b85194b4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 09:30:27 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
