namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 176; }
        public static int Build { get => 574; }
        public static string Hash { get => "f61183fb"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-28 15:53:03 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
