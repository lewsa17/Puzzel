namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 155; }
        public static int Build { get => 423; }
        public static string Hash { get => "45ee616f"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-04-29 21:30:39 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
