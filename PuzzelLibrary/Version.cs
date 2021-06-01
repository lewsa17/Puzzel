namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 169; }
        public static int Build { get => 549; }
        public static string Hash { get => "c695e407"; }
        public static System.DateTime BuildDate { get => System.DateTime.Parse("2021-05-28 15:20:37 +0200"); }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
