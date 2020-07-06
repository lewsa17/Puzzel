namespace Puzzel.Properties {
    
    
    // Ta klasa umożliwia obsługę określonych zdarzeń w klasie ustawień:
    //  Zdarzenie SettingChanging jest wywoływane przed zmianą wartości ustawień.
    //  Zdarzenie PropertyChanged jest wywoływane po zmianie wartości ustawień.
    //  Zdarzenie SettingsLoaded jest wywoływane po załadowaniu wartości ustawień.
    //  Zdarzenie SettingsSaving jest wywoływane przed zapisaniem wartości ustawień.
    sealed partial class Settings {
        
        public Settings() {
            // // Aby dodać obsługę zdarzeń dla zapisu i zmiany ustawień, należy usunąć komentarz w poniższych wierszach:
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // Dodaj tutaj kod obsługi zdarzenia SettingChangingEvent.
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // Dodaj tutaj kod obsługi zdarzenia SettingsSaving.
            Save();
            
        }

        public void ShortcutEntry(params object[] setttings)
        {
            //ComboBox1 = setttings[0].ToString();
            //ComboBox2 = setttings[1].ToString();
            //ComboBox3 = setttings[2].ToString();
            //UserLog = setttings[3].ToString();
            //Profil_VFS = setttings[4].ToString();
            //Profil_TS = setttings[5].ToString();
            //Profil_ERI = setttings[6].ToString();
            //Profil_EXT = setttings[7].ToString();
            //Info_z_AD = setttings[8].ToString();
            //Szukaj_sesji = setttings[9].ToString();
            //Polacz = setttings[10].ToString();
            //Logoff = setttings[11].ToString();
            //KomputerLog = setttings[12].ToString();
            //KomputerInfo = setttings[13].ToString();
            //DW = setttings[14].ToString();
            //ExplorerC = setttings[15].ToString();
            //ZdalneCMD = setttings[16].ToString();
            //Ping = setttings[17].ToString();
            //Zarzadzanie = setttings[18].ToString();
            //Pulpit_Zdalny = setttings[19].ToString();
            //Lista_program = setttings[20].ToString();
            //Karty_sieciowe = setttings[21].ToString();
            //Remote_Ping = setttings[22].ToString();
            //Remote_Tracert = setttings[23].ToString();
            //Flush_DNS = setttings[24].ToString();
            //Reload_logs = setttings[25].ToString();
        }
    }
}
