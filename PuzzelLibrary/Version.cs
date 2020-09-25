namespace PuzzelLibrary
{
    public static class Version
    {
        public static int Major { get => 0; }
        public static int Minor { get => 131; }
        public static int Build { get => 0; }
        public static string GetVersion() => Major + "." + Minor + "." + Build;
    }
}
