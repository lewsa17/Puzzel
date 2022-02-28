namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 201; }
        public static int Build { get => 660; }
        public static string Hash { get => "3b44d428"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2022-02-28 10:05:05 +0100"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
