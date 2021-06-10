namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 172; }
        public static int Build { get => 560; }
        public static string Hash { get => "e1adf79c"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-10 09:35:55 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
