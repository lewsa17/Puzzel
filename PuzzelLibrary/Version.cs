namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 165; }
        public static int Build { get => 530; }
        public static string Hash { get => "bc31a3db"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-20 21:16:32 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
