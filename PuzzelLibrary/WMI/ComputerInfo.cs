﻿using System;
using System.Management;
using System.Windows.Forms;

namespace PuzzelLibrary.WMI
{
    public static class ComputerInfo
    {
        public const string pathCIMv2 = @"\root\CIMV2";
        public const string pathWMI = @"\root\wmi";
        public const string queryComputerSystem = "Win32_ComputerSystem";
        public const string queryOperatingSystem = "Win32_OperatingSystem";
        public const string queryComputerSystemProduct = "Win32_ComputerSystemProduct";
        public const string querySystemInformation = "MS_SystemInformation";
        public const string queryPhysicalMemory = "Win32_PhysicalMemory";
        public const string queryProcessor = "Win32_Processor";
        public const string queryDesktop = "Win32_Desktop";
        public const string queryLogicalDisk = "Win32_LogicalDisk";
        public const string queryPrinterConfiguration = "Win32_PrinterConfiguration";
        public const string queryShare = "Win32_Share";
        public const string queryStartupCommand = "Win32_StartupCommand";
        public const string queryEnvironment = "Win32_Environment";
        public const string queryNetworkConnection = "Win32_NetworkConnection";
        public const string queryNetworkAdapterConfiguration = "Win32_NetworkAdapterConfiguration";
        public const string queryBios = "Win32_BIOS";
        public const string queryDesktopMonitor = "Win32_DesktopMonitor";
        public const string queryProduct = "Win32_Product";

        public static int getProgressValue { get; set; }

        public static string AllComputerInfo(string HostName)
        {
            string StringBuilder = string.Empty;
            StringBuilder += ("Nazwa komputera: ");
            getProgressValue = 1;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryComputerSystem, "DNSHostName");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Domena: ");
            getProgressValue = 2;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryComputerSystem, "Domain");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Uptime: ");
            getProgressValue = 3;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryOperatingSystem, "LastBootUpTime");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("SN: ");
            getProgressValue = 4;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryComputerSystemProduct, "IdentifyingNumber");
            StringBuilder += ("PN: ");
            getProgressValue = 5;
            StringBuilder += GetInfo(HostName, pathWMI, querySystemInformation, "SystemSKU");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Model: ");
            getProgressValue = 6;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryComputerSystem, "Model");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("OS: ");
            getProgressValue = 7;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version");
            StringBuilder += ("----------------------------------------\n");
            //TotalCapacity
            StringBuilder += ("Pamięć TOTAL: \n");
            getProgressValue = 8;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryPhysicalMemory, "Capacity");
            StringBuilder += ("\n");
            StringBuilder += GetInfo(HostName, pathCIMv2, queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber");
            StringBuilder += ("\n");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("CPU \n");
            getProgressValue = 9;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryProcessor, "Name");
            StringBuilder += ("Rdzenie: ");
            getProgressValue = 10;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryProcessor, "NumberOfCores");
            StringBuilder += ("Wątki: ");
            getProgressValue = 11;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryProcessor, "NumberOfLogicalProcessors");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Użytkownik: ");
            getProgressValue = 12;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryComputerSystem, "UserName");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Profile\n");
            getProgressValue = 13;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryDesktop, "Name");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Dyski: \n");
            getProgressValue = 14;
            StringBuilder += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
            StringBuilder += GetInfo(HostName, pathCIMv2, queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Zasoby sieciowe\n\n");
            getProgressValue = 15;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryNetworkConnection, "LocalName", "RemoteName");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Drukarki sieciowe\n\n");
            getProgressValue = 16;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryPrinterConfiguration, "DeviceName");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Udziały\n");
            getProgressValue = 17;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryShare, "Name", "Path", "Description");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("AutoStart\n");
            getProgressValue = 18;
            StringBuilder += GetInfo(HostName, pathCIMv2, queryStartupCommand, "Caption", "Command");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Środowisko uruchomieniowe\n");
            getProgressValue = 19;
            StringBuilder += ("Nazwa zmiennej           Wartość zmiennej\n");
            StringBuilder += GetInfo(HostName, pathCIMv2, queryEnvironment, "Name", "VariableValue");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("Podłączone ekrany\n");
            StringBuilder += GetInfo(HostName, pathCIMv2, queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status");
            StringBuilder += ("----------------------------------------\n");
            StringBuilder += ("BIOS\n");
            StringBuilder += GetInfo(HostName, pathCIMv2, queryBios, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate");
            return StringBuilder;
        }
        public static string GetInfo(string nazwaKomputera, string path, string query, params object[] args)
        {
            UInt64 TotalCapacity = 0;
            int warunek = 0;
            int warunek1 = 0;

            string StringBuilder = string.Empty;
            ManagementScope scope = new ManagementScope();
            try
            {
                ConnectionOptions options = new ConnectionOptions()
                {
                    EnablePrivileges = true
                };
                scope = new ManagementScope(@"\\" + nazwaKomputera + path, options);
                scope.Connect();

                SelectQuery Squery = new SelectQuery(query);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, Squery);
                searcher.Dispose();
                using (ManagementObjectCollection queryCollection = searcher.Get())
                {
                    foreach (ManagementObject m in queryCollection)
                    {
                        switch (args.Length)
                        {
                            case 1:
                                {
                                    //bootTime
                                    //args0 = lastbootuptime
                                    if (args[0].ToString() == "LastBootUpTime")
                                        if (query == queryOperatingSystem)
                                        {
                                            StringBuilder += BootTime(args, m);
                                            break;
                                        }

                                    //memoryTotal
                                    //args0 = capacity
                                    if (query == queryPhysicalMemory)
                                    {
                                        StringBuilder += MemoryTotal(args, ref TotalCapacity, ref warunek1, queryCollection, m);
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        StringBuilder += (m[args[0].ToString()] + "\n");
                                    break;
                                }
                            case 2:
                                {

                                    if (query == queryNetworkConnection)
                                    {
                                        StringBuilder += NetworkResources(args, m);
                                        break;
                                    }
                                    //autostart
                                    //args0 = caption
                                    //args1 = command
                                    if (query == queryStartupCommand)
                                    {
                                        StringBuilder += AutoStart(args, m);
                                        break;
                                    }

                                    //Zmienna PATH
                                    //args0 = name
                                    //args1 = variablevalue
                                    if (query == queryEnvironment)
                                    {
                                        StringBuilder += EnvironmentPath(args, m);
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        StringBuilder += (m[args[0].ToString()] + "     " + m[args[1].ToString()] + "\n");
                                    break;
                                }
                            case 3:
                                {
                                    //Lista programów
                                    //args1 = Name
                                    //args2 = InstallDate
                                    //args3 = Version
                                    if (query == queryProduct)
                                    {
                                        StringBuilder += InstalledPrograms(args, m);
                                        break;
                                    }


                                    //zasoby sieciowe
                                    //args0 = name
                                    //args1 = path
                                    //args2 = description
                                    if (query == queryShare)
                                    {
                                        StringBuilder += NetworkResources(args, m);
                                        break;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    //system
                                    //args0 = caption
                                    //args1 = csdversion
                                    //args2 = osarchitecture
                                    //args3 = version
                                    if (query == queryOperatingSystem)
                                    {
                                        StringBuilder += osInfo(args, m);
                                        break;
                                    }

                                    //bios
                                    //args0 = manufacturer
                                    //args1 = biosversion
                                    //args2 = smbiobiosversion
                                    //args3 = releasedate
                                    if (query == queryBios)
                                    {
                                        StringBuilder += BiosInfo(args, m);
                                        break;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    //Disk
                                    //args0 = name
                                    //args1 = description
                                    //args2 = filesystem
                                    //args3 = freespace
                                    //args4 = size
                                    if (query == queryLogicalDisk)
                                    {
                                        StringBuilder += Disk(args, m);
                                        break;
                                    }
                                    //args[0] = Caption
                                    //args[1] = DeviceID
                                    //args[2] = ScreenHeight
                                    //args[3] = ScreenWidth
                                    //args[4] = Status
                                    if (query == queryDesktopMonitor)
                                    {
                                        StringBuilder += DesktopMonitor(args, m);
                                        StringBuilder += "\n";
                                        break;
                                    }
                                    StringBuilder += "\n";
                                    break;
                                }
                            case 6:
                                {
                                    //Memory
                                    //args0 = devicelocator
                                    //args1 = manufacturer
                                    //args2 = capacity
                                    //args3 = speed
                                    //args4 = partnumber
                                    //args5 = serialnumber
                                    StringBuilder += Memory(args, warunek, m);
                                    //StringBuilder += ("\n");
                                    break;
                                }
                            case 7:
                                {
                                    //networkAdapter
                                    //args0 = IPEnabled
                                    //args1 = Description
                                    //args2 = DNSDomainSuffixSearchOrder
                                    //args3 = DNSHostName
                                    //args4 = IPAddress
                                    //args5 = IPSubnet
                                    //args6 = MACAddress
                                    StringBuilder += NetworkAdapter(args, m);
                                    break;
                                }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Dostęp zabroniony na obecnych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return string.Empty;
            }

            catch (Exception ex)
            {
                Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return string.Empty;
            }
                return StringBuilder;

        }

        private static string Memory(object[] args, int warunek, ManagementObject m)
        {
            string _capacity = null;
            string devicelocator = null;
            string manufacturer = null;
            string partnumber = null;
            string serialnumber = null;
            string speed = null;
            int capacitySize = 0;
            int devicelocatorSize = 0;
            int manufacturerSize = 0;
            int partnumberSize = 0;
            int speedSize = 0;
            string StringBuilder = string.Empty;

            //wyrzucanie nazw
            capacitySize = 6;
            speedSize = 2;
            partnumberSize = 11;

            if (m[args[0].ToString()] != null)
            {
                devicelocator = m[args[0].ToString()].ToString();
                if (devicelocator.Length > 7)
                {
                    devicelocatorSize = 18;
                }
                else if (devicelocator.Length < 7)
                {
                    devicelocatorSize = 3;
                }
            }

            if (m[args[1].ToString()] != null)
            {
                manufacturer = m[args[1].ToString()].ToString();
                if (devicelocator.Length > 7)
                {
                    manufacturerSize = 5;
                }
                else if (devicelocator.Length < 7)
                {
                    manufacturerSize = 7;
                }
            }
            warunek++;
            if (warunek == 1)
            {
                StringBuilder += ("Rozmiar");
                for (int i = 0; i < capacitySize; i++)
                    StringBuilder += (" ");

                StringBuilder += ("Speed");
                for (int i = 0; i < speedSize; i++)
                    StringBuilder += (" ");

                StringBuilder += ("Slot");
                for (int i = 0; i < devicelocatorSize; i++)
                    StringBuilder += (" ");

                StringBuilder += ("Producent");
                for (int i = 0; i < manufacturerSize; i++)
                    StringBuilder += (" ");

                StringBuilder += ("Nr Partii");
                for (int i = 0; i < partnumberSize; i++)
                    StringBuilder += (" ");
                StringBuilder += ("Nr Seryjny");
                StringBuilder += ("\n");
            }
            //wyrzucanie wartości
            if (m[args[2].ToString()] != null)
            {
                _capacity = m[args[2].ToString()].ToString();
                StringBuilder += _capacity;
                int a = 13 - _capacity.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                speed = m[args[3].ToString()].ToString();
                StringBuilder += (speed);
                int a = 7 - speed.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[0].ToString()] != null)
            {
                devicelocator = m[args[0].ToString()].ToString();
                StringBuilder += (devicelocator);

                if (devicelocator.Length > 7)
                {
                    int a = 22 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        StringBuilder += (" ");
                    }
                }
                else if (devicelocator.Length < 7)
                {
                    int a = 7 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        StringBuilder += (" ");
                    }
                }
            }

            if (m[args[1].ToString()] != null)
            {
                manufacturer = m[args[1].ToString()].ToString();
                StringBuilder += (manufacturer);
                int a = 14 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                partnumber = m[args[4].ToString()].ToString();
                StringBuilder += (partnumber);
                int a = 20 - partnumber.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[5].ToString()] != null)
            {
                serialnumber = m[args[5].ToString()].ToString();
                StringBuilder += (serialnumber);
            }

            return StringBuilder;
        }

        private static string NetworkAdapter(object[] args, ManagementObject m)
        {
            string[] Suffix = null;
            string[] Ipaddress = null;
            string[] IPSubnet = null;
            string StringBuilder = string.Empty;

            if (args.Length > 1)
            {
                if (m[args[2].ToString()] != null)
                    Suffix = (string[])m[args[2].ToString()];
                if (m[args[4].ToString()] != null)
                    Ipaddress = (string[])m[args[4].ToString()];
                if (m[args[5].ToString()] != null)
                    IPSubnet = (string[])m[args[5].ToString()];

                StringBuilder += ("\nNazwa karty sieciowej   " + m[args[1].ToString()].ToString() + "\n");
                StringBuilder += ("IP Włączone             " + m[args[0].ToString()].ToString() + "\n");

                if (m[args[0].ToString()].ToString() == "True")
                {
                    StringBuilder += ("DNS Suffix              ");
                    if (Suffix != null)
                        for (int i = 0; i < Suffix.Length; i++)
                            StringBuilder += (Suffix[i] + "; ");
                    StringBuilder += ("\n");
                    if (m[args[3].ToString()] != null)
                        StringBuilder += ("Nazwa hosta DNS         " + m[args[3].ToString()].ToString() + "\n");
                    StringBuilder += ("Adres IP                ");
                    if (Ipaddress != null)
                        for (int i = 0; i < Ipaddress.Length; i++)
                            StringBuilder += (Ipaddress[i] + "; ");
                    StringBuilder += ("\n");
                    StringBuilder += ("Maska podsieci          ");
                    if (IPSubnet != null)
                        for (int i = 0; i < IPSubnet.Length; i++)
                            StringBuilder += (IPSubnet[i] + "; ");
                    StringBuilder += ("\n");
                    StringBuilder += ("Adres MAC               " + m[args[6].ToString()].ToString() + ";\n");
                }
            }
            return StringBuilder;
        }

        private static string DesktopMonitor(object[] args, ManagementObject m)
        {
            string caption = null;
            string deviceID = null;
            string screenHeight = null;
            string screenWidth = null;
            string status = null;
            string StringBuilder = string.Empty;
            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                StringBuilder += (caption);
                int a = 25 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                deviceID = m[args[1].ToString()].ToString();
                StringBuilder += (deviceID);
                int a = 25 - deviceID.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                screenHeight = m[args[2].ToString()].ToString();
                StringBuilder += (screenHeight);
                int a = 6 - screenHeight.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                screenWidth = m[args[3].ToString()].ToString();
                StringBuilder += (screenWidth);
                int a = 6 - screenWidth.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                status = m[args[4].ToString()].ToString();
                StringBuilder += (status);
            }
            return StringBuilder;
        }

        private static string Disk(object[] args, ManagementObject m)
        {
            string name = null;
            string description = null;
            string filesystem = null;
            string freespace = null;
            string size = null;
            string StringBuilder = string.Empty;

            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                StringBuilder += (name);
                int a = 8 - name.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                description = m[args[1].ToString()].ToString();
                StringBuilder += (description);
                if (description.Length != 22)
                {
                    int a = 22 - description.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            else
            {
                description = "-";
                StringBuilder += (description);
                int a = 22 - description.Length;
                for (int i = 0; i < a; i++)
                    StringBuilder += (" ");
            }

            if (m[args[2].ToString()] != null)
            {
                filesystem = m[args[2].ToString()].ToString();
                StringBuilder += (filesystem);
                if (filesystem.Length != 16)
                {
                    int a = 16 - filesystem.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            else
            {
                filesystem = "-";
                StringBuilder += (filesystem);
                int a = 16 - filesystem.Length;
                for (int i = 0; i < a; i++)
                    StringBuilder += (" ");
            }

            if (m[args[3].ToString()] != null)
            {
                freespace = m[args[3].ToString()].ToString();
                UInt64 b = ((UInt64)m[args[3].ToString()]) / 1024 / 1024 / 1024;
                freespace += " (" + b.ToString() + "GB)";
                StringBuilder += (freespace);
                if (freespace.Length < 23)
                {
                    int a = 23 - freespace.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }

            }
            else
            {
                freespace = "-"; StringBuilder += (freespace);
                int a = 23 - freespace.Length;
                for (int i = 0; i < a; i++)
                    StringBuilder += (" ");
            }

            if (m["size"] != null)
            {
                size = m["size"].ToString();
                UInt64 b = ((UInt64)m["size"]) / 1024 / 1024 / 1024;
                size += " (" + b.ToString() + "GB)";
                StringBuilder += (size);
            }
            else { size = "-"; StringBuilder += (size); }

            StringBuilder += ("\n");
            return StringBuilder;
        }

        private static string BiosInfo(object[] args, ManagementObject m)
        {
            string manufacturer = null;
            string smbiosVersion = null;
            string releaseDate = null;
            string StringBuilder = string.Empty;

            StringBuilder += "Producent                Wersja Bios      Data wydania\n";

            if (m[args[0].ToString()] != null)
            {
                manufacturer = m[args[0].ToString()].ToString();
                StringBuilder += (manufacturer);
                int a = "Producent".Length + 16 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                smbiosVersion = m[args[2].ToString()].ToString();
                StringBuilder += (smbiosVersion);
                int a = "Wersja SMBios".Length + 3 - smbiosVersion.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                releaseDate = m[args[3].ToString()].ToString();
                StringBuilder += (releaseDate.Remove(8, releaseDate.Length - 8));
            }
            return StringBuilder;
        }

        private static string osInfo(object[] args, ManagementObject m)
        {
            string caption = null;
            string csdversion = null;
            string osarchitecture = null;
            string version = null;
            string StringBuilder = string.Empty;

            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                StringBuilder += (caption);
                int a = 44 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    StringBuilder += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                csdversion = m[args[1].ToString()].ToString();
                StringBuilder += (csdversion);
                if (csdversion.Length != 22)
                {
                    StringBuilder += ("  ");
                }
            }
            else
            {
                csdversion = "-";
                StringBuilder += (csdversion);
                StringBuilder += ("  ");
            }

            if (m[args[2].ToString()] != null)
            {
                osarchitecture = m[args[2].ToString()].ToString();
                StringBuilder += (osarchitecture);
                if (osarchitecture.Length != 16)
                {
                    StringBuilder += ("  ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                version = m[args[3].ToString()].ToString();
                StringBuilder += (version);
                if (version.Length < 23)
                {
                    StringBuilder += (" ");
                }
            }
            StringBuilder += ("\n");
            return StringBuilder;
        }

        private static string NetworkResources(object[] args, ManagementObject m)
        {
            string name;
            string StringBuilder = string.Empty;
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                StringBuilder += (name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            else
            {
                name = "-";
                StringBuilder += (name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }

            string Path;
            if (m[args[1].ToString()] != null)
            {
                Path = m[args[1].ToString()].ToString();
                StringBuilder += (Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            else
            {
                Path = "-";
                StringBuilder += (Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            if (args.Length > 2)
            {
                string description;
                if (m[args[2].ToString()] != null)
                {
                    description = m[args[2].ToString()].ToString();
                    StringBuilder += (description);
                }
                else
                {
                    description = "-";
                    StringBuilder += (description);
                }
                StringBuilder += ("\n");
            }
            return StringBuilder;
        }

        private static string InstalledPrograms(object[] args, ManagementObject m)
        {
            string nazwa = null;
            string wersja = null;
            string data = null;
            int firstoptimvalue = 80;
            int secondoptimvalue = 31;
            nazwa = m[args[0].ToString()].ToString();
            data = m[args[1].ToString()].ToString();
            wersja = m[args[2].ToString()].ToString();
            string StringBuilder = string.Empty;

            int firstObjLength = nazwa.Length;
            int secondObjLenght = wersja.Length;
            int thirdObjLenght = data.Length;
            int addspace = 0;
            if (firstObjLength > 1)
                if (!nazwa.Contains("for Microsoft") && !nazwa.Contains("(KB"))
                {
                    StringBuilder += nazwa + " ";
                    if (firstObjLength < firstoptimvalue)
                    {
                        addspace = firstoptimvalue - firstObjLength;
                        for (int i = 0; i < addspace; i++)
                            StringBuilder += " ";
                    }
                    else
                    {
                        StringBuilder += "   ";
                    }
                    if (secondObjLenght > 1 && thirdObjLenght > 1)
                    {
                        StringBuilder += data + " ";
                        if (firstoptimvalue > firstObjLength)
                        {
                            addspace = secondoptimvalue - secondObjLenght;
                            for (int i = 0; i < addspace; i++)
                                StringBuilder += " ";
                        }
                        if (firstoptimvalue < firstObjLength)
                        {
                            if (firstoptimvalue + secondoptimvalue > firstObjLength + secondObjLenght + 3)
                            {
                                addspace = firstoptimvalue + secondoptimvalue - firstObjLength - secondObjLenght - 3;
                                for (int i = 0; i < addspace; i++)
                                    StringBuilder += " ";
                            }
                            else StringBuilder += "  ";
                        }
                    }
                    if (secondObjLenght < 4 && thirdObjLenght > 1)
                    {
                        if (firstoptimvalue > firstObjLength)
                            addspace = secondoptimvalue;
                        else addspace = firstoptimvalue + secondoptimvalue - firstObjLength - 3;
                        for (int i = 0; i < addspace; i++)
                            StringBuilder += " ";
                    }
                    if (secondObjLenght < 1 && thirdObjLenght < 1)
                    {
                        StringBuilder += "\n";
                    }
                    if (wersja.Length < 2)
                        wersja = "";
                    StringBuilder += wersja + " " + "\n";
                }
            return StringBuilder;
        }

        private static string EnvironmentPath(object[] args, ManagementObject m)
        {
            string name;
            string variablevalue;
            string StringBuilder = string.Empty;
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                StringBuilder += (name);
                if (name.Length <= 25)
                {
                    int a = 25 - name.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                variablevalue = m[args[1].ToString()].ToString();
                StringBuilder += (variablevalue);

            }
            StringBuilder += ("\n");
            return StringBuilder;
        }

        private static string AutoStart(object[] args, ManagementObject m)
        {
            string caption = null;
            string StringBuilder = string.Empty;
            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                StringBuilder += (caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }
            else
            {
                caption = "-";
                StringBuilder += (caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        StringBuilder += (" ");
                }
            }

            string command = null;
            if (m[args[1].ToString()] != null)
            {
                command = m[args[1].ToString()].ToString();
                StringBuilder += (command);
            }
            else { command = "-"; StringBuilder += (command); }
            StringBuilder += ("\n");
            return StringBuilder;
        }

        private static string MemoryTotal(object[] args, ref ulong TotalCapacity, ref int warunek1, ManagementObjectCollection queryCollection, ManagementObject m)
        {
            string StringBuilder = string.Empty;
            warunek1++;
            TotalCapacity += (UInt64)(m[args[0].ToString()]) / 1024 / 1024 / 1024;
            if (queryCollection.Count == warunek1)
                StringBuilder += TotalCapacity + " GB";
            return StringBuilder;
        }

        private static string BootTime(object[] args, ManagementObject m)
        {
            string boottime = null;
            boottime = m[args[0].ToString()].ToString();
            string year = null;
            string month = null;
            string day = null;
            string hour = null;
            string minute = null;
            string second = null;
            string StringBuilder = string.Empty;
            for (int i = 0; i < 4; i++)
                year += boottime[i];
            for (int i = 4; i < 6; i++)
                month += boottime[i];
            for (int i = 6; i < 8; i++)
                day += boottime[i];
            for (int i = 8; i < 10; i++)
                hour += boottime[i];
            for (int i = 10; i < 12; i++)
                minute += boottime[i];
            for (int i = 12; i < 14; i++)
                second += boottime[i];

            TimeSpan bootTime;
            DateTime czas = DateTime.ParseExact(year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second/*+"."+milisekunda*/, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            bootTime = DateTime.Now - czas;
            string[] dayArr = { " dzień ", " dni " };
            string[] hourArr = { " godzina ", " godziny ", " godzin " };
            string[] minuteArr = { " minuta ", " minuty ", " minut " };
            string[] secondArr = { " sekunda ", "sekundy", " sekund" };
            if (bootTime.Days == 1)
                StringBuilder += (bootTime.Days + " " + dayArr[0] + ",");
            if (bootTime.Days == 0 | bootTime.Days > 1)
                StringBuilder += (bootTime.Days + " " + dayArr[1] + ",");

            if (bootTime.Hours == 0 | bootTime.Hours > 4)
                StringBuilder += (bootTime.Hours + " " + hourArr[2] + ",");
            if (bootTime.Hours == 1)
                StringBuilder += (bootTime.Hours + " " + hourArr[0] + ",");
            if (bootTime.Hours > 1 && bootTime.Hours < 5)
                StringBuilder += (bootTime.Hours + " " + hourArr[1] + ",");

            if (bootTime.Minutes == 0 | bootTime.Minutes > 4)
                StringBuilder += (bootTime.Minutes + " " + minuteArr[2] + ",");
            if (bootTime.Minutes == 1)
                StringBuilder += (bootTime.Minutes + " " + minuteArr[0] + ",");
            if (bootTime.Minutes > 1 && bootTime.Minutes < 5)
                StringBuilder += (bootTime.Minutes + " " + minuteArr[1] + ",");

            if (bootTime.Seconds == 0 | bootTime.Seconds > 4)
                StringBuilder += (bootTime.Seconds + " " + secondArr[2]);
            if (bootTime.Seconds == 1)
                StringBuilder += (bootTime.Seconds + " " + secondArr[0]);
            if (bootTime.Seconds > 1 && bootTime.Seconds < 5)
                StringBuilder += (bootTime.Seconds + " " + secondArr[1]);
            StringBuilder += ("\n");
            return StringBuilder;
        }
    }
}
