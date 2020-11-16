namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 137; }
        public static int Build { get => 270; }
        public static string Hash { get => "435012fb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2020-11-16 23:26:11 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
