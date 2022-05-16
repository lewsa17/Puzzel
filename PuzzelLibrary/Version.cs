namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 204; }
        public static int Build { get => 676; }
        public static string Hash { get => "2c98733b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-05-16 12:59:48 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
