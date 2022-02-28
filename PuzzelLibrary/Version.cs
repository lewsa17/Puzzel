namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 201; }
        public static int Build { get => 664; }
        public static string Hash { get => "b4560e10"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-02-28 13:00:44 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
