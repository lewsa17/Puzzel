namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 171; }
        public static int Build { get => 557; }
        public static string Hash { get => "8acebb67"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-06-10 09:05:01 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
