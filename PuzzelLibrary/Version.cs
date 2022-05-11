namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 202; }
        public static int Build { get => 669; }
        public static string Hash { get => "00268b0e"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-03-31 09:27:59 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
