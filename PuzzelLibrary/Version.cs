namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 165; }
        public static int Build { get => 534; }
        public static string Hash { get => "17768397"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 11:18:08 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
