namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 163; }
        public static int Build { get => 514; }
        public static string Hash { get => "cd3989b4"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-17 16:36:08 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
