namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 157; }
        public static int Build { get => 453; }
        public static string Hash { get => "7f861b85"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-06 19:20:41 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
