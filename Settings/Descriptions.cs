namespace Settings
{
    internal static class Descriptions
    {
        public static readonly string _default = "Najedź kursorem na opcję aby wyświetlić tutaj jej opis";
        public static readonly string AutoOpenPort = "Zmiana tej wartości wyłączy pytanie o otwarcie portu 135 (RPC) odpowiedzialny za wykonywanie niektórych funkcji - będzie to wykonywane automatycznie";
        public static readonly string AutoStartUpdate = "Automatyczne sprawdzanie aktualizacji przy uruchomieniu";
        public static readonly string AutoUnlockFirewall = "Zmiana tej wartości wyłączy pytanie o odblokowywanie Zdalnej Zapory - będzie to wykonywane automatycznie";
        public static readonly string CheckLogsBeforeStartUp = "Ustaw czy podczas uruchomienia logi mają być odświeżane";
        public static readonly string CompMaxLogs = "Zmiana tej wartości ustala maksymalną liczbę logowań do komputera jaką można wyszukać";
        public static readonly string ComputerInput = "Ustawienie tej wartości spowododuje podstawianie ostatnio używanej nazwy komputera przy wyszukiwaniu użytkownika";
        public static readonly string ComputerLogsFolder = "Podaj lokalizację zawierająca logi komputera";
        public static readonly string ComputerSNFile = "Podaj nazwę pliku zawierającego numery seryjne komputerów";
        public static readonly string CustomDataSourceTextBox = "Podaj nazwę terminali z których będa wyszukiwane sesje, musi być odzielone przecinkami";
        public static readonly string CustomSourceCheck = "Zezwala na wyszukiwanie sesji z ręcznie przygotowanej listy";
        public static readonly string DomainController = "Podaj nazwę kontrolera(hosta) po którym program będzie odpytywał domenę o informacje.";
        public static readonly string HistoryLog = "Ustawienie tej opcji będzie wyświetlać lub nie ostatnio wyszukiwanej wartości";
        public static readonly string LocalUpdate = "Zmienia miejsce wyszukiwania aktualizacji / ze zdalnie na lokalnie";
        public static readonly string MotpLogName = "Podaj nazwę dziennika dla serwera motp";
        public static readonly string MotpServers = "Podaj nazwę/y hosta dla serwerów motp (Odzielone , lub ;)";
        public static readonly string SaveUserDataCheck = "Zamiana tej wartości wyłączy pytanie o zapisywanie danych użytkownika przy usuwaniu - będzie to wykonywane automatycznie";
        public static readonly string SessionShortcut = "Ustaw skrót klawiszowy odpowiedzialny za rozłączanie się od sesji zdalnej. \nWystarczy zaznaczyć kursorem na pole tekstowe i nacisnąć klawisze\nDziała tylko do serwera terminali 2008R2";
        public static readonly string TerminalLogsFile = "Podaj nazwy plików odzielone przecinkiem zawierające logi terminali";
        public static readonly string TerminalLogsFolder = "Podaj lokalizację zawierająca logi terminali";
        public static readonly string TerminalLogsSNFile = "Podaj nazwę pliku zawierającego numery seryjne terminali";
        public static readonly string UserMaxLogs = "Zmiana tej wartości ustala maksymalną liczbę logowań użytkownika jaką można wyszukać";
        public static readonly string KeywordSearching = "Ustawienie tej opcji spowoduje zmianę sposobu wyszukiwania nazw, domyślnie wyszukianie jest po słowie kluczowym. Po zmianie aby wyszukiwać należy po wyszukiwanym słowie podać *(gwiazdkę)";
    }
}
