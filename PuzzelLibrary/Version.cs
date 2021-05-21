namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 166; }
        public static int Build { get => 539; }
        public static string Hash { get => "3c0c7c4b"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-21 12:53:14 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
