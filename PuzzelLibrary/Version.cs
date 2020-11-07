namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 132; }
        public static int Build { get => 216; }
        public static string Hash { get => "b8a73262"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("26.09.2020 02:51:34"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
