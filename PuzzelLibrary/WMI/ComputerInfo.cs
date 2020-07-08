﻿using System;
using System.Linq;
using System.Management;
using System.Net.Sockets;
using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PuzzelLibrary.WMI
{
    public static class ComputerInfo
    {
        public static int ProgressBarValue = 0;
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

        public static string AllComputerInfo(string HostName)
        {
            string Data = null;
            Data += ("Nazwa komputera: ");
            ProgressBarValue = 1;
            GetInfo(HostName, pathCIMv2, queryComputerSystem, "DNSHostName");
            Data += ("----------------------------------------\n");
            Data += ("Domena: ");
            ProgressBarValue = 2;
            GetInfo(HostName, pathCIMv2, queryComputerSystem, "Domain");
            Data += ("----------------------------------------\n");
            Data += ("Uptime: ");
            ProgressBarValue = 3;
            GetInfo(HostName, pathCIMv2, queryOperatingSystem, "LastBootUpTime");
            Data += ("----------------------------------------\n");
            Data += ("SN: ");
            ProgressBarValue = 4;
            GetInfo(HostName, pathCIMv2, queryComputerSystemProduct, "IdentifyingNumber");
            Data += ("PN: ");
            ProgressBarValue = 5;
            GetInfo(HostName, pathWMI, querySystemInformation, "SystemSKU");
            Data += ("----------------------------------------\n");
            Data += ("Model: ");
            ProgressBarValue = 6;
            GetInfo(HostName, pathCIMv2, queryComputerSystem, "Model");
            Data += ("----------------------------------------\n");
            Data += ("OS: ");
            ProgressBarValue = 7;
            GetInfo(HostName, pathCIMv2, queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version");
            Data += ("----------------------------------------\n");
            //TotalCapacity
            Data += ("Pamięć TOTAL: \n");
            ProgressBarValue = 8;
            GetInfo(HostName, pathCIMv2, queryPhysicalMemory, "Capacity");
            Data += ("\n");
            GetInfo(HostName, pathCIMv2, queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber");
            Data += ("----------------------------------------\n");
            Data += ("CPU \n");
            ProgressBarValue = 9;
            GetInfo(HostName, pathCIMv2, queryProcessor, "Name");
            Data += ("Rdzenie: ");
            ProgressBarValue = 10;
            GetInfo(HostName, pathCIMv2, queryProcessor, "NumberOfCores");
            Data += ("Wątki: ");
            ProgressBarValue = 11;
            GetInfo(HostName, pathCIMv2, queryProcessor, "NumberOfLogicalProcessors");
            Data += ("----------------------------------------\n");
            Data += ("Użytkownik: ");
            ProgressBarValue = 12;
            GetInfo(HostName, pathCIMv2, queryComputerSystem, "UserName");
            Data += ("----------------------------------------\n");
            Data += ("Profile\n");
            ProgressBarValue = 13;
            GetInfo(HostName, pathCIMv2, queryDesktop, "Name");
            Data += ("----------------------------------------\n");
            Data += ("Dyski: \n");
            ProgressBarValue = 14;
            Data += ("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
            GetInfo(HostName, pathCIMv2, queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size");
            Data += ("----------------------------------------\n");
            Data += ("Zasoby sieciowe\n\n");
            ProgressBarValue = 15;
            GetInfo(HostName, pathCIMv2, queryNetworkConnection, "LocalName", "RemoteName");
            Data += ("----------------------------------------\n");
            Data += ("Drukarki sieciowe\n\n");
            ProgressBarValue = 16;
            GetInfo(HostName, pathCIMv2, queryPrinterConfiguration, "DeviceName");
            Data += ("----------------------------------------\n");
            Data += ("Udziały\n");
            ProgressBarValue = 17;
            GetInfo(HostName, pathCIMv2, queryShare, "Name", "Path", "Description");
            Data += ("----------------------------------------\n");
            Data += ("AutoStart\n");
            ProgressBarValue = 18;
            GetInfo(HostName, pathCIMv2, queryStartupCommand, "Caption", "Command");
            Data += ("----------------------------------------\n");
            Data += ("Środowisko uruchomieniowe\n");
            ProgressBarValue = 19;
            Data += ("Nazwa zmiennej           Wartość zmiennej\n");
            GetInfo(HostName, pathCIMv2, queryEnvironment, "Name", "VariableValue");
            Data += ("----------------------------------------\n");
            Data += ("Podłączone ekrany\n");
            GetInfo(HostName, pathCIMv2, queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status");
            Data += ("----------------------------------------\n");
            Data += ("BIOS\n");
            GetInfo(HostName, pathCIMv2, queryBios, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate");
            return Data;
        }
        public static string GetInfo(string nazwaKomputera, string path, string query, params object[] args)
        {
            UInt64 TotalCapacity = 0;
            int warunek = 0;
            int warunek1 = 0;
            string Data = null;
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
                                        BootTime(args, m);
                                        break;
                                    }

                                    //memoryTotal
                                    //args0 = capacity
                                    if (query == queryPhysicalMemory)
                                    {
                                        MemoryTotal(args, ref TotalCapacity, ref warunek1, queryCollection, m);
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        Data += (m[args[0].ToString()] + "\n");
                                    break;
                                }
                            case 2:
                                {
                                    //autostart
                                    //args0 = caption
                                    //args1 = command
                                    if (query == queryStartupCommand)
                                    {
                                        AutoStart(args, m);
                                        break;
                                    }

                                    //Zmienna PATH
                                    //args0 = name
                                    //args1 = variablevalue
                                    if (query == queryEnvironment)
                                    {
                                        EnvironmentPath(args, m);
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        Data += (m[args[0].ToString()] + "     " + m[args[1].ToString()] + "\n");
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
                                        InstalledPrograms(m);
                                        break;
                                    }



                                    //zasoby sieciowe
                                    //args0 = name
                                    //args1 = path
                                    //args2 = description
                                    if (query == queryNetworkConnection)
                                    {
                                        NetworkResources(args, m);
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
                                        osInfo(args, m);
                                    }

                                    //bios
                                    //args0 = manufacturer
                                    //args1 = biosversion
                                    //args2 = smbiobiosversion
                                    //args3 = releasedate
                                    if (query == queryBios)
                                    {
                                        BiosInfo(args, m);
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
                                        Disk(args, m);
                                    }
                                    //args[0] = Caption
                                    //args[1] = DeviceID
                                    //args[2] = ScreenHeight
                                    //args[3] = ScreenWidth
                                    //args[4] = Status
                                    if (query == queryDesktopMonitor)
                                    {
                                        DesktopMonitor(args, m);
                                    }
                                    Data += "\n";
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
                                    warunek = Memory(args, warunek, m);
                                    Data += ("\n");
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
                                    NetworkAdapter(args, m);
                                    break;
                                }
                        }
                    }
                }
                    return Data;
            }
            catch (UnauthorizedAccessException ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Dostęp zabroniony na obecnych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return string.Empty;
            }

            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, nazwaKomputera + "," + path + "," + query);
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return string.Empty;
            }
            
        }

        private static int Memory(object[] args, int warunek, ManagementObject m)
        {
            string Data = null;
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
                Data += ("Rozmiar");
                for (int i = 0; i < capacitySize; i++)
                    Data += (" ");

                Data += ("Speed");
                for (int i = 0; i < speedSize; i++)
                    Data += (" ");

                Data += ("Slot");
                for (int i = 0; i < devicelocatorSize; i++)
                    Data += (" ");

                Data += ("Producent");
                for (int i = 0; i < manufacturerSize; i++)
                    Data += (" ");

                Data += ("Nr Partii");
                for (int i = 0; i < partnumberSize; i++)
                    Data += (" ");
                Data += ("Nr Seryjny");
                Data += ("\n");
            }
            //wyrzucanie wartości
            if (m[args[2].ToString()] != null)
            {
                _capacity = m[args[2].ToString()].ToString();
                Data += _capacity;
                int a = 13 - _capacity.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                speed = m[args[3].ToString()].ToString();
                Data += (speed);
                int a = 7 - speed.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[0].ToString()] != null)
            {
                devicelocator = m[args[0].ToString()].ToString();
                Data += (devicelocator);

                if (devicelocator.Length > 7)
                {
                    int a = 22 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        Data += (" ");
                    }
                }
                else if (devicelocator.Length < 7)
                {
                    int a = 7 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        Data += (" ");
                    }
                }
            }

            if (m[args[1].ToString()] != null)
            {
                manufacturer = m[args[1].ToString()].ToString();
                Data += (manufacturer);
                int a = 14 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                partnumber = m[args[4].ToString()].ToString();
                Data += (partnumber);
                int a = 20 - partnumber.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[5].ToString()] != null)
            {
                serialnumber = m[args[5].ToString()].ToString();
                Data += (serialnumber);
            }

            return warunek;
        }

        private static string NetworkAdapter(object[] args, ManagementObject m)
        {
            string Data = null;
            string[] Suffix = null;
            string[] Ipaddress = null;
            string[] IPSubnet = null;

            if (args.Length > 1)
            {
                if (m[args[2].ToString()] != null)
                    Suffix = (string[])m[args[2].ToString()];
                if (m[args[4].ToString()] != null)
                    Ipaddress = (string[])m[args[4].ToString()];
                if (m[args[5].ToString()] != null)
                    IPSubnet = (string[])m[args[5].ToString()];

                Data += ("\nNazwa karty sieciowej   " + m[args[1].ToString()].ToString() + "\n");
                Data += ("IP Włączone             " + m[args[0].ToString()].ToString() + "\n");

                if (m[args[0].ToString()].ToString() == "True")
                {
                    Data += ("DNS Suffix              ");
                    if (Suffix != null)
                        for (int i = 0; i < Suffix.Length; i++)
                            Data += (Suffix[i] + "; ");
                    Data += ("\n");
                    if (m[args[3].ToString()] != null)
                        Data += ("Nazwa hosta DNS         " + m[args[3].ToString()].ToString() + "\n");
                    Data += ("Adres IP                ");
                    if (Ipaddress != null)
                        for (int i = 0; i < Ipaddress.Length; i++)
                            Data += (Ipaddress[i] + "; ");
                    Data += ("\n");
                    Data += ("Maska podsieci          ");
                    if (IPSubnet != null)
                        for (int i = 0; i < IPSubnet.Length; i++)
                            Data += (IPSubnet[i] + "; ");
                    Data += ("\n");
                    Data += ("Adres MAC               " + m[args[6].ToString()].ToString() + ";\n");
                }
            }
            return Data;
        }

        private static string DesktopMonitor(object[] args, ManagementObject m)
        {
            string Data = null;
            string caption = null;
            string deviceID = null;
            string screenHeight = null;
            string screenWidth = null;
            string status = null;
            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                Data += (caption);
                int a = 25 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                deviceID = m[args[1].ToString()].ToString();
                Data += (deviceID);
                int a = 25 - deviceID.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                screenHeight = m[args[2].ToString()].ToString();
                Data += (screenHeight);
                int a = 6 - screenHeight.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                screenWidth = m[args[3].ToString()].ToString();
                Data += (screenWidth);
                int a = 6 - screenWidth.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                status = m[args[4].ToString()].ToString();
                Data += (status);
            }
            return Data;
        }

        private static string Disk(object[] args, ManagementObject m)
        {
            string Data = null;
            string name = null;
            string description = null;
            string filesystem = null;
            string freespace = null;
            string size = null;

            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                Data += (name);
                int a = 8 - name.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                description = m[args[1].ToString()].ToString();
                Data += (description);
                if (description.Length != 22)
                {
                    int a = 22 - description.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }
            else
            {
                description = "-";
                Data += (description);
                int a = 22 - description.Length;
                for (int i = 0; i < a; i++)
                    Data += (" ");
            }

            if (m[args[2].ToString()] != null)
            {
                filesystem = m[args[2].ToString()].ToString();
                Data += (filesystem);
                if (filesystem.Length != 16)
                {
                    int a = 16 - filesystem.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }
            else
            {
                filesystem = "-";
                Data += (filesystem);
                int a = 16 - filesystem.Length;
                for (int i = 0; i < a; i++)
                    Data += (" ");
            }

            if (m[args[3].ToString()] != null)
            {
                freespace = m[args[3].ToString()].ToString();
                UInt64 b = ((UInt64)m[args[3].ToString()]) / 1024 / 1024 / 1024;
                freespace += " (" + b.ToString() + "GB)";
                Data += (freespace);
                if (freespace.Length < 23)
                {
                    int a = 23 - freespace.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }

            }
            else
            {
                freespace = "-"; Data += (freespace);
                int a = 23 - freespace.Length;
                for (int i = 0; i < a; i++)
                    Data += (" ");
            }

            if (m["size"] != null)
            {
                size = m["size"].ToString();
                UInt64 b = ((UInt64)m["size"]) / 1024 / 1024 / 1024;
                size += " (" + b.ToString() + "GB)";
                Data += (size);
            }
            else { size = "-"; Data += (size); }

            Data += ("\n");
            return Data;
        }

        private static string BiosInfo(object[] args, ManagementObject m)
        {
            string Data = null;
            string manufacturer = null;
            //string[] biosVersion = null;
            string smbiosVersion = null;
            string releaseDate = null;


            Data += "Producent                Wersja Bios     " +
                // "Wersja SMBios   " +
                "Data wydania\n";

            if (m[args[0].ToString()] != null)
            {
                manufacturer = m[args[0].ToString()].ToString();
                Data += (manufacturer);
                int a = "Producent".Length + 16 - manufacturer.Length;
                //17 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            //if (m[args[1].ToString()] != null)
            //{
            //    biosVersion = ((string[])m[args[1].ToString()]);
            //    Puzzel.Form1.ComputerInfo_TEMP += (biosVersion[0]);
            //    int a = "Wersja Bios".Length + 8 - biosVersion[0].Length;
            //    //20 - biosVersion[0].Length;
            //    for (int i = 0; i < a; i++)
            //    {
            //        Puzzel.Form1.ComputerInfo_TEMP += (" ");
            //    }
            //}

            if (m[args[1].ToString()] != null)
            {
                smbiosVersion = m[args[2].ToString()].ToString();
                Data += (smbiosVersion);
                int a = "Wersja SMBios".Length + 3 - smbiosVersion.Length;//12 - smbiosVersion.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                releaseDate = m[args[3].ToString()].ToString();
                Data += (releaseDate.Remove(8, releaseDate.Length - 8));
            }
            return Data;
        }

        private static string osInfo(object[] args, ManagementObject m)
        {
            string Data = null;
            string caption = null;
            string csdversion = null;
            string osarchitecture = null;
            string version = null;

            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                Data += (caption);
                int a = 44 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    Data += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                csdversion = m[args[1].ToString()].ToString();
                Data += (csdversion);
                if (csdversion.Length != 22)
                {
                    //int a = 15 - csdversion.Length;
                    //for (int i = 0; i < a; i++)
                    Data += ("  ");
                }
            }
            else
            {
                csdversion = "-";
                Data += (csdversion);
                //int a = 15 - csdversion.Length;
                //for (int i = 0; i < a; i++)
                Data += ("  ");
            }

            if (m[args[2].ToString()] != null)
            {
                osarchitecture = m[args[2].ToString()].ToString();
                Data += (osarchitecture);
                if (osarchitecture.Length != 16)
                {
                    //int a = 14 - osarchitecture.Length;
                    //for (int i = 0; i < a; i++)
                    Data += ("  ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                version = m[args[3].ToString()].ToString();
                Data += (version);
                if (version.Length < 23)
                {
                    Data += (" ");
                }
            }
            Data += ("\n");
            return Data;
        }

        private static string NetworkResources(object[] args, ManagementObject m)
        {
            string Data = null;
            string name;
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                Data += (name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }
            else
            {
                name = "-";
                Data += (name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }

            string Path;
            if (m[args[1].ToString()] != null)
            {
                Path = m[args[1].ToString()].ToString();
                Data += (Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }
            else
            {
                Path = "-";
                Data += (Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }

            string description;
            if (m[args[2].ToString()] != null)
            {
                description = m[args[2].ToString()].ToString();
                Data += (description);
            }
            else
            {
                description = "-";
                Data += (description);
            }
            Data += ("\n");
            return Data;
        }

        private static string InstalledPrograms(ManagementObject m)
        {
            string Data = null;
            string nazwa = null;
            string wersja = null;
            string data = null;
            //nazwa_dlugosc = 0;
            int firstoptimvalue = 80;
            int secondoptimvalue = 31;
            nazwa = m["Name"].ToString();
            data = m["InstallDate"].ToString();
            wersja = m["Version"].ToString();

            int firstObjLength = nazwa.Length;
            int secondObjLenght = wersja.Length;
            int thirdObjLenght = data.Length;
            int addspace = 0;
            if (firstObjLength > 1)
                if (!nazwa.Contains("for Microsoft") && !nazwa.Contains("(KB"))
                {
                    Data += nazwa + " ";
                    if (firstObjLength < firstoptimvalue)
                    {
                        addspace = firstoptimvalue - firstObjLength;
                        for (int i = 0; i < addspace; i++)
                            Data += " ";
                    }
                    else
                    {
                        Data += "   ";
                    }
                    if (secondObjLenght > 1 && thirdObjLenght > 1)
                    {
                        Data += data + " ";
                        if (firstoptimvalue > firstObjLength)
                        {
                            addspace = secondoptimvalue - secondObjLenght;
                            for (int i = 0; i < addspace; i++)
                                Data += " ";
                        }
                        if (firstoptimvalue < firstObjLength)
                        {
                            if (firstoptimvalue + secondoptimvalue > firstObjLength + secondObjLenght + 3)
                            {
                                addspace = firstoptimvalue + secondoptimvalue - firstObjLength - secondObjLenght - 3;
                                for (int i = 0; i < addspace; i++)
                                    Data += " ";
                            }
                            else Data += "  ";
                        }
                    }
                    if (secondObjLenght < 4 && thirdObjLenght > 1)
                    {
                        if (firstoptimvalue > firstObjLength)
                            addspace = secondoptimvalue;
                        else addspace = firstoptimvalue + secondoptimvalue - firstObjLength - 3;
                        for (int i = 0; i < addspace; i++)
                            Data += " ";
                    }
                    if (secondObjLenght < 1 && thirdObjLenght < 1)
                    {
                        Data += "\n";
                    }
                    if (wersja.Length < 2)
                        wersja = "";
                    Data += wersja + " " + "\n";
                }
            return Data;
        }

        private static string EnvironmentPath(object[] args, ManagementObject m)
        {
            string Data = null;
            string name;
            string variablevalue;
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                Data += (name);
                if (name.Length <= 25)
                {
                    int a = 25 - name.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                variablevalue = m[args[1].ToString()].ToString();
                Data += (variablevalue);

            }
            Data += ("\n");
            return Data;
        }

        private static string AutoStart(object[] args, ManagementObject m)
        {
            string Data = null;
            string caption = null;
            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                Data += (caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }
            else
            {
                caption = "-";
                Data += (caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        Data += (" ");
                }
            }

            string command = null;
            if (m[args[1].ToString()] != null)
            {
                command = m[args[1].ToString()].ToString();
                Data += (command);
            }
            else { command = "-"; Data += (command); }
            Data += ("\n");
            return Data;
        }

        private static void MemoryTotal(object[] args, ref ulong TotalCapacity, ref int warunek1, ManagementObjectCollection queryCollection, ManagementObject m)
        {
            string Data = null;
            warunek1++;
            TotalCapacity += (UInt64)(m[args[0].ToString()]) / 1024 / 1024 / 1024;
            if (queryCollection.Count == warunek1)
                Data += TotalCapacity + " GB";
        }

        private static string BootTime(object[] args, ManagementObject m)
        {
            string Data = null;
            string boottime = null;
            //string[] date = null;
            boottime = m[args[0].ToString()].ToString();
            string rok = null;
            string miesiac = null;
            string dzien = null;
            string godzina = null;
            string minuta = null;
            string sekunda = null;
            for (int i = 0; i < 4; i++)
                rok += boottime[i];
            for (int i = 4; i < 6; i++)
                miesiac += boottime[i];
            for (int i = 6; i < 8; i++)
                dzien += boottime[i];
            for (int i = 8; i < 10; i++)
                godzina += boottime[i];
            for (int i = 10; i < 12; i++)
                minuta += boottime[i];
            for (int i = 12; i < 14; i++)
                sekunda += boottime[i];

            TimeSpan czasbootowania;
            DateTime czas = DateTime.ParseExact(rok + "-" + miesiac + "-" + dzien + " " + godzina + ":" + minuta + ":" + sekunda/*+"."+milisekunda*/, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            czasbootowania = DateTime.Now - czas;
            string[] dzien1 = { " dzień ", " dni " };
            string[] godzina1 = { " godzina ", " godziny ", " godzin " };
            string[] minuta1 = { " minuta ", " minuty ", " minut " };
            string[] sekunda1 = { " sekunda ", "sekundy", " sekund" };
            if (czasbootowania.Days == 1)
                Data += (czasbootowania.Days + " " + dzien1[0] + ",");
            if (czasbootowania.Days == 0 | czasbootowania.Days > 1)
                Data += (czasbootowania.Days + " " + dzien1[1] + ",");

            if (czasbootowania.Hours == 0 | czasbootowania.Hours > 4)
                Data += (czasbootowania.Hours + " " + godzina1[2] + ",");
            if (czasbootowania.Hours == 1)
                Data += (czasbootowania.Hours + " " + godzina1[0] + ",");
            if (czasbootowania.Hours > 1 && czasbootowania.Hours < 5)
                Data += (czasbootowania.Hours + " " + godzina1[1] + ",");

            if (czasbootowania.Minutes == 0 | czasbootowania.Minutes > 4)
                Data += (czasbootowania.Minutes + " " + minuta1[2] + ",");
            if (czasbootowania.Minutes == 1)
                Data += (czasbootowania.Minutes + " " + minuta1[0] + ",");
            if (czasbootowania.Minutes > 1 && czasbootowania.Minutes < 5)
                Data += (czasbootowania.Minutes + " " + minuta1[1] + ",");

            if (czasbootowania.Seconds == 0 | czasbootowania.Seconds > 4)
                Data += (czasbootowania.Seconds + " " + sekunda1[2]);
            if (czasbootowania.Seconds == 1)
                Data += (czasbootowania.Seconds + " " + sekunda1[0]);
            if (czasbootowania.Seconds > 1 && czasbootowania.Seconds < 5)
                Data += (czasbootowania.Seconds + " " + sekunda1[1]);
            Data += ("\n");
            return Data;
        }

        public static string Fast(string hostname, string path, string query)
        {
            string Data = null;
            try
            {
                if (System.IO.Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Microsoft.NET\assembly\GAC_MSIL\Microsoft.PowerShell.ConsoleHost")))
                {
                    using (var ps = PowerShell.Create())
                    {
                        ps.AddScript("Invoke-Command -ComputerName " + hostname + @" -Command {Get-ItemProperty -Path HKLM:\SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\* | Select-Object DisplayName, InstallDate, DisplayVersion}");
                        System.Collections.Generic.List<PSObject> items = ps.Invoke().ToList();
                        string[] objItem = null;
                        int firstoptimvalue = 80;
                        int secondoptimvalue = 31;
                        Data += (string.Format("{0,-80}{1,-31}{2,-1}", "DisplayName", "InstallDate", "DisplayVersion" + "\n"));
                        foreach (PSObject item in items)
                        {
                            objItem = item.ToString().Split(';');
                            objItem[0] = objItem[0].Replace("@{DisplayName=", " ");
                            objItem[1] = objItem[1].Replace("InstallDate=", "");
                            objItem[2] = objItem[2].Replace("DisplayVersion=", "").Replace("}", "");

                            int firstObjLength = objItem[0].Length;
                            int secondObjLenght = objItem[1].Length;
                            int thirdObjLenght = objItem[2].Length;
                            int addspace = 0;
                            if (firstObjLength > 1)
                                if (!objItem[0].Contains("for Microsoft") && !objItem[0].Contains("(KB"))
                                {
                                    Data += objItem[0];
                                    if (firstObjLength < firstoptimvalue)
                                    {
                                        addspace = firstoptimvalue - firstObjLength;
                                        for (int i = 0; i < addspace; i++)
                                            Data += " ";
                                    }
                                    else
                                    {
                                        Data += "   ";
                                    }
                                    if (secondObjLenght > 1 && thirdObjLenght > 1)
                                    {
                                        Data += objItem[1];
                                        if (firstoptimvalue > firstObjLength)
                                        {
                                            addspace = secondoptimvalue - secondObjLenght;
                                            for (int i = 0; i < addspace; i++)
                                                Data += " ";
                                        }
                                        if (firstoptimvalue < firstObjLength)
                                        {
                                            if (firstoptimvalue + secondoptimvalue > firstObjLength + secondObjLenght + 3)
                                            {
                                                addspace = firstoptimvalue + secondoptimvalue - firstObjLength - secondObjLenght - 3;
                                                for (int i = 0; i < addspace; i++)
                                                    Data += " ";
                                            }
                                            else Data += "  ";
                                        }
                                    }
                                    if (secondObjLenght < 4 && thirdObjLenght > 1)
                                    {
                                        if (firstoptimvalue > firstObjLength)
                                            addspace = secondoptimvalue;
                                        else addspace = firstoptimvalue + secondoptimvalue - firstObjLength - 3;
                                        for (int i = 0; i < addspace; i++)
                                            Data += " ";
                                    }
                                    if (secondObjLenght < 1 && thirdObjLenght < 1)
                                    {
                                        Data += "\n";
                                    }
                                    if (objItem[2].Length < 2)
                                        objItem[2] = "";
                                    Data += objItem[2] + "\n";
                                }
                        }
                        //ps.Dispose();
                    }
                }
                if (Data == null)
                {
                    Data += ("Nazwa komputera: ");
                    Data += GetInfo(hostname,pathCIMv2, queryComputerSystem, "DNSHostName");
                    Data += GetInfo(hostname, path, query, "Name", "InstallDate", "Version");
                }
                //else
                //{
                //    System.Collections.Generic.List<string> trind = Form1.ComputerInfo_TEMP.Split('\n').ToList();
                //    trind.Sort();
                //    foreach (var line in trind)
                //        if (line.Length > 3)
                //            Form1.UpdateRichTextBox(line + "\n");
                //}
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, "szybka metoda");
            }
            return Data;
        }

        public static string Fast2(string nazwaKomputera, string path, string query)
        {
            string Data = null;
            try
            {
                if (System.IO.Directory.Exists(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"Microsoft.NET\assembly\GAC_MSIL\Microsoft.PowerShell.ConsoleHost")))
                {
                    using (PowerShell ps = PowerShell.Create())
                    {
                        ps.AddScript("Invoke-Command -ComputerName " + nazwaKomputera + @" -Command {Get-ItemProperty -Path HKLM:\HARDWARE\DESCRIPTION\System\BIOS\ | Select-Object SystemManufacturer, BIOSVersion, BIOSReleaseDate}");
                        string[] objItem = ps.Invoke()[0].ToString().Split(';');

                        objItem[0] = objItem[0].Replace("@{SystemManufacturer=", " ");
                        objItem[1] = objItem[1].Replace("BIOSVersion=", "");
                        objItem[2] = objItem[2].Replace("BIOSReleaseDate=", "");

                        Data += "Producent                Wersja Bios     " + "Data wydania\n";
                        Data += objItem[0];
                        int a = "Producent".Length + 16 - objItem[0].Length;
                        for (int i = 0; i < a; i++)
                        {
                            Data += (" ");
                        }

                        Data += objItem[1];
                        a = "Wersja SMBios".Length + 3 - objItem[1].Length;
                        for (int i = 0; i < a; i++)
                        {
                            Data += (" ");
                        }
                        Data += objItem[2];
                    }
                }

                if (Data == null)
                {
                    Data += GetInfo(nazwaKomputera, path, query, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate");
                }
            }
            catch (Exception ex)
            {
                PuzzelLibrary.Debug.LogsCollector.GetLogs(ex, nazwaKomputera + ",'" + path + "," + query);
            }
            return Data;
        }
    }
}