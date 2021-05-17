namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 163; }
        public static int Build { get => 513; }
        public static string Hash { get => "2e367cec"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-17 16:07:43 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
