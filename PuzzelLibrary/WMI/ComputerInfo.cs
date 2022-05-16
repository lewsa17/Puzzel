using System;
using System.Management;
using System.Runtime.InteropServices;
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
        public const string queryPnpDevice = "Win32_PnPSignedDriver";

        public static int GetProgressValue { get; set; }

        public static string AllComputerInfo(string HostName)
        {
            System.Text.StringBuilder sb = new();
            ManagementScope scope = new();
            if (wmiConnect(HostName, pathCIMv2, out scope))
            {
                sb.Append("Nazwa komputera: ");
                GetProgressValue = 1;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryComputerSystem, "DNSHostName"));
                sb.Append("----------------------------------------\n");
                sb.Append("Domena: ");
                GetProgressValue = 2;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryComputerSystem, "Domain"));
                sb.Append("----------------------------------------\n");
                sb.Append("Uptime: ");
                GetProgressValue = 3;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryOperatingSystem, "LastBootUpTime"));
                sb.Append("----------------------------------------\n");
                sb.Append("SN: ");
                GetProgressValue = 4;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryComputerSystemProduct, "IdentifyingNumber"));
                sb.Append("PN: ");
                GetProgressValue = 5;
                sb.Append(GetInfo(HostName, pathWMI, scope, querySystemInformation, "SystemSKU"));
                sb.Append("----------------------------------------\n");
                sb.Append("Model: ");
                GetProgressValue = 6;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryComputerSystem, "Model"));
                sb.Append("----------------------------------------\n");
                sb.Append("OS: ");
                GetProgressValue = 7;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryOperatingSystem, "Caption", "CsdVersion", "OsArchitecture", "Version"));
                sb.Append("----------------------------------------\n");
                //TotalCapacity
                sb.Append("Pamięć TOTAL: \n");
                GetProgressValue = 8;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryPhysicalMemory, "Capacity"));
                sb.Append("\n");
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryPhysicalMemory, "DeviceLocator", "Manufacturer", "Capacity", "Speed", "PartNumber", "SerialNumber"));
                sb.Append("\n");
                sb.Append("----------------------------------------\n");
                sb.Append("CPU \n");
                GetProgressValue = 9;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryProcessor, "Name"));
                sb.Append("Rdzenie: ");
                GetProgressValue = 10;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryProcessor, "NumberOfCores"));
                sb.Append("Wątki: ");
                GetProgressValue = 11;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryProcessor, "NumberOfLogicalProcessors"));
                sb.Append("----------------------------------------\n");
                sb.Append("Użytkownik: ");
                GetProgressValue = 12;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryComputerSystem, "UserName"));
                sb.Append("----------------------------------------\n");
                sb.Append("Profile\n");
                GetProgressValue = 13;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryDesktop, "Name"));
                sb.Append("----------------------------------------\n");
                sb.Append("Dyski: \n");
                GetProgressValue = 14;
                sb.Append("Nazwa   Opis                  System plików   Wolna przestrzeń       Rozmiar \n");
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryLogicalDisk, "Name", "Description", "FileSystem", "FreeSpace", "Size"));
                sb.Append("----------------------------------------\n");
                sb.Append("Zasoby sieciowe\n\n");
                GetProgressValue = 15;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryNetworkConnection, "LocalName", "RemoteName"));
                sb.Append("----------------------------------------\n");
                sb.Append("Drukarki sieciowe\n\n");
                GetProgressValue = 16;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryPrinterConfiguration, "DeviceName"));
                sb.Append("----------------------------------------\n");
                sb.Append("Udziały\n");
                GetProgressValue = 17;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryShare, "Name", "Path", "Description"));
                sb.Append("----------------------------------------\n");
                sb.Append("AutoStart\n");
                GetProgressValue = 18;
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryStartupCommand, "Caption", "Command"));
                sb.Append("----------------------------------------\n");
                sb.Append("Środowisko uruchomieniowe\n");
                GetProgressValue = 19;
                sb.Append("Nazwa zmiennej           Wartość zmiennej\n");
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryEnvironment, "Name", "VariableValue"));
                sb.Append("----------------------------------------\n");
                sb.Append("Podłączone ekrany\n");
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryDesktopMonitor, "Caption", "DeviceID", "ScreenHeight", "ScreenWidth", "Status"));
                sb.Append("----------------------------------------\n");
                sb.Append("BIOS\n");
                sb.Append(GetInfo(HostName, pathCIMv2, scope, queryBios, "Manufacturer", "BIOSVersion", "SMBIOSBIOSVersion", "ReleaseDate"));
            }
            return sb.ToString();
        }
        public static bool wmiConnect(string computerName, string path, out ManagementScope scope)
        {
            ConnectionOptions options = new()
            {
                EnablePrivileges = true
            };
            scope = new ManagementScope(@"\\" + computerName + path, options);
            try
            {
                scope.Connect();
                if (scope.IsConnected) return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Dostęp jest zabroniony");
            }
            catch (COMException comErr)
            {
                MessageBox.Show(new Form(), comErr.Message, "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Debug.LogsCollector.GetLogs(ex, computerName + "," + path);
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false;
            }
            return false;
        }
        public static string GetInfo(string nazwaKomputera, string path, ManagementScope scope, string query, params object[] args)
        {
            UInt64 TotalCapacity = 0;
            int warunek = 0;
            int warunek1 = 0;

            System.Text.StringBuilder sb = new();
            SelectQuery Squery = new(query);
            if (scope.Path.Path != $"\\\\{nazwaKomputera}{path}")
                scope = new ManagementScope($"\\\\{nazwaKomputera}{path}", new ConnectionOptions() { EnablePrivileges = true });
            using ManagementObjectSearcher searcher = new(scope, Squery);
            using ManagementObjectCollection queryCollection = searcher.Get();
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
                                    sb.Append(BootTime(args, m));
                                    break;
                                }

                            //memoryTotal
                            //args0 = capacity
                            if (query == queryPhysicalMemory)
                            {
                                sb.Append(MemoryTotal(args, ref TotalCapacity, ref warunek1, queryCollection, m));
                                break;
                            }
                            if (m[args[0].ToString()] != null)
                                sb.Append(m[args[0].ToString()] + "\n");
                            break;
                        }
                    case 2:
                        {

                            if (query == queryNetworkConnection)
                            {
                                sb.Append(NetworkResources(args, m));
                                break;
                            }
                            //autostart
                            //args0 = caption
                            //args1 = command
                            if (query == queryStartupCommand)
                            {
                                sb.Append(AutoStart(args, m));
                                break;
                            }

                            //Zmienna PATH
                            //args0 = name
                            //args1 = variablevalue
                            if (query == queryEnvironment)
                            {
                                sb.Append(EnvironmentPath(args, m));
                                break;
                            }
                            if (m[args[0].ToString()] != null)
                                sb.Append(m[args[0].ToString()] + "     " + m[args[1].ToString()] + "\n");
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
                                sb.Append(InstalledPrograms(args, m));
                                break;
                            }


                            //zasoby sieciowe
                            //args0 = name
                            //args1 = path
                            //args2 = description
                            if (query == queryShare)
                            {
                                sb.Append(NetworkResources(args, m));
                                break;
                            }
                            
                            break;
                        }
                    case 4:
                        {
                            //Lista sterowników
                            //args0 = Desription
                            //args1 = Manufacturer
                            //args2 = DriverVersion
                            //args3 = DriverDate
                            if (query == queryPnpDevice)
                            {
                                sb.Append(PNPDevice(args, m));
                                break;
                            }
                            //system
                            //args0 = caption
                            //args1 = csdversion
                            //args2 = osarchitecture
                            //args3 = version
                            if (query == queryOperatingSystem)
                            {
                                sb.Append(OsInfo(args, m));
                                break;
                            }

                            //bios
                            //args0 = manufacturer
                            //args1 = biosversion
                            //args2 = smbiobiosversion
                            //args3 = releasedate
                            if (query == queryBios)
                            {
                                sb.Append(BiosInfo(args, m));
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
                                sb.Append(Disk(args, m));
                                break;
                            }
                            //args[0] = Caption
                            //args[1] = DeviceID
                            //args[2] = ScreenHeight
                            //args[3] = ScreenWidth
                            //args[4] = Status
                            if (query == queryDesktopMonitor)
                            {
                                sb.Append(DesktopMonitor(args, m));
                                sb.Append("\n");
                                break;
                            }
                            sb.Append("\n");
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
                            sb.Append(Memory(args, ref warunek, m));
                            sb.Append("\n");
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
                            sb.Append(NetworkAdapter(args, m));
                            break;
                        }
                }
            }
            return sb.ToString();
        }
        private static string Memory(object[] args, ref int warunek, ManagementObject m)
        {
            string devicelocator = null;
            int devicelocatorSize = 0;
            int manufacturerSize = 0;
            System.Text.StringBuilder sb = new();

            //wyrzucanie nazw
            int capacitySize = 6;
            int speedSize = 2;
            int partnumberSize = 11;

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
                sb.Append("Rozmiar");
                for (int i = 0; i < capacitySize; i++)
                    sb.Append(" ");

                sb.Append("Speed");
                for (int i = 0; i < speedSize; i++)
                    sb.Append(" ");

                sb.Append("Slot");
                for (int i = 0; i < devicelocatorSize; i++)
                    sb.Append(" ");

                sb.Append("Producent");
                for (int i = 0; i < manufacturerSize; i++)
                    sb.Append(" ");

                sb.Append("Nr Partii");
                for (int i = 0; i < partnumberSize; i++)
                    sb.Append(" ");
                sb.Append("Nr Seryjny");
                sb.Append("\n");
            }
            //wyrzucanie wartości
            if (m[args[2].ToString()] != null)
            {
                string _capacity = m[args[2].ToString()].ToString();
                sb.Append(_capacity);
                int a = 13 - _capacity.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                string speed = m[args[3].ToString()].ToString();
                sb.Append(speed);
                int a = 7 - speed.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[0].ToString()] != null)
            {
                devicelocator = m[args[0].ToString()].ToString();
                sb.Append(devicelocator);

                if (devicelocator.Length > 7)
                {
                    int a = 22 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        sb.Append(" ");
                    }
                }
                else if (devicelocator.Length < 7)
                {
                    int a = 7 - devicelocator.Length;
                    for (int i = 0; i < a; i++)
                    {
                        sb.Append(" ");
                    }
                }
            }

            if (m[args[1].ToString()] != null)
            {
                string manufacturer = m[args[1].ToString()].ToString();
                sb.Append(manufacturer);
                int a = 14 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                string partnumber = m[args[4].ToString()].ToString();
                sb.Append(partnumber);
                int a = 20 - partnumber.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[5].ToString()] != null)
            {
                string serialnumber = m[args[5].ToString()].ToString();
                sb.Append(serialnumber);
            }

            return sb.ToString();
        }

        private static string NetworkAdapter(object[] args, ManagementObject m)
        {
            string[] Suffix = null;
            string[] Ipaddress = null;
            string[] IPSubnet = null;
            System.Text.StringBuilder sb = new();

            if (args.Length > 1)
            {
                if (m[args[2].ToString()] != null)
                    Suffix = (string[])m[args[2].ToString()];
                if (m[args[4].ToString()] != null)
                    Ipaddress = (string[])m[args[4].ToString()];
                if (m[args[5].ToString()] != null)
                    IPSubnet = (string[])m[args[5].ToString()];

                sb.Append("\nNazwa karty sieciowej   " + m[args[1].ToString()].ToString() + "\n");
                sb.Append("IP Włączone             " + m[args[0].ToString()].ToString() + "\n");

                if (m[args[0].ToString()].ToString() == "True")
                {
                    sb.Append("DNS Suffix              ");
                    if (Suffix != null)
                        for (int i = 0; i < Suffix.Length; i++)
                            sb.Append(Suffix[i] + "; ");
                    sb.Append("\n");
                    if (m[args[3].ToString()] != null)
                        sb.Append("Nazwa hosta DNS         " + m[args[3].ToString()].ToString() + "\n");
                    sb.Append("Adres IP                ");
                    if (Ipaddress != null)
                        for (int i = 0; i < Ipaddress.Length; i++)
                            sb.Append(Ipaddress[i] + "; ");
                    sb.Append("\n");
                    sb.Append("Maska podsieci          ");
                    if (IPSubnet != null)
                        for (int i = 0; i < IPSubnet.Length; i++)
                            sb.Append(IPSubnet[i] + "; ");
                    sb.Append("\n");
                    sb.Append("Adres MAC               " + m[args[6].ToString()].ToString() + ";\n");
                }
            }
            return sb.ToString();
        }

        private static string DesktopMonitor(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();
            if (m[args[0].ToString()] != null)
            {
                string caption = m[args[0].ToString()].ToString();
                sb.Append(caption);
                int a = 25 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                string deviceID = m[args[1].ToString()].ToString();
                sb.Append(deviceID);
                int a = 25 - deviceID.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                string screenHeight = m[args[2].ToString()].ToString();
                sb.Append(screenHeight);
                int a = 6 - screenHeight.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                string screenWidth = m[args[3].ToString()].ToString();
                sb.Append(screenWidth);
                int a = 6 - screenWidth.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[4].ToString()] != null)
            {
                string status = m[args[4].ToString()].ToString();
                sb.Append(status);
            }
            return sb.ToString();
        }

        private static string Disk(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();

            if (m[args[0].ToString()] != null)
            {
                string name = m[args[0].ToString()].ToString();
                sb.Append(name);
                int a = 8 - name.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            string description;
            if (m[args[1].ToString()] != null)
            {
                description = m[args[1].ToString()].ToString();
                sb.Append(description);
                if (description.Length != 22)
                {
                    int a = 22 - description.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            else
            {
                description = "-";
                sb.Append(description);
                int a = 22 - description.Length;
                for (int i = 0; i < a; i++)
                    sb.Append(" ");
            }

            string filesystem;
            if (m[args[2].ToString()] != null)
            {
                filesystem = m[args[2].ToString()].ToString();
                sb.Append(filesystem);
                if (filesystem.Length != 16)
                {
                    int a = 16 - filesystem.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            else
            {
                filesystem = "-";
                sb.Append(filesystem);
                int a = 16 - filesystem.Length;
                for (int i = 0; i < a; i++)
                    sb.Append(" ");
            }

            string freespace;
            if (m[args[3].ToString()] != null)
            {
                freespace = m[args[3].ToString()].ToString();
                UInt64 b = ((UInt64)m[args[3].ToString()]) / 1024 / 1024 / 1024;
                freespace += " (" + b.ToString() + "GB)";
                sb.Append(freespace);
                if (freespace.Length < 23)
                {
                    int a = 23 - freespace.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }

            }
            else
            {
                freespace = "-";
                sb.Append(freespace);
                int a = 23 - freespace.Length;
                for (int i = 0; i < a; i++)
                    sb.Append(" ");
            }

            string size;
            if (m["size"] != null)
            {
                size = m["size"].ToString();
                UInt64 b = ((UInt64)m["size"]) / 1024 / 1024 / 1024;
                size += " (" + b.ToString() + "GB)";
                sb.Append(size);
            }
            else { size = "-"; sb.Append(size); }

            sb.Append("\n");
            return sb.ToString();
        }

        private static string BiosInfo(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();

            sb.Append("Producent                Wersja Bios      Data wydania\n");

            if (m[args[0].ToString()] != null)
            {
                string manufacturer = m[args[0].ToString()].ToString();
                sb.Append(manufacturer);
                int a = "Producent".Length + 16 - manufacturer.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                string smbiosVersion = m[args[2].ToString()].ToString();
                sb.Append(smbiosVersion);
                int a = "Wersja SMBios".Length + 3 - smbiosVersion.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            if (m[args[2].ToString()] != null)
            {
                string releaseDate = m[args[3].ToString()].ToString();
                sb.Append(releaseDate.Remove(8, releaseDate.Length - 8));
            }
            return sb.ToString();
        }

        private static string OsInfo(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();

            if (m[args[0].ToString()] != null)
            {
                string caption = m[args[0].ToString()].ToString();
                sb.Append(caption);
                int a = 44 - caption.Length;
                for (int i = 0; i < a; i++)
                {
                    sb.Append(" ");
                }
            }

            string csdversion;
            if (m[args[1].ToString()] != null)
            {
                csdversion = m[args[1].ToString()].ToString();
                sb.Append(csdversion);
                if (csdversion.Length != 22)
                {
                    sb.Append("  ");
                }
            }
            else
            {
                csdversion = "-";
                sb.Append(csdversion);
                sb.Append("  ");
            }

            if (m[args[2].ToString()] != null)
            {
                string osarchitecture = m[args[2].ToString()].ToString();
                sb.Append(osarchitecture);
                if (osarchitecture.Length != 16)
                {
                    sb.Append("  ");
                }
            }

            if (m[args[3].ToString()] != null)
            {
                string version = m[args[3].ToString()].ToString();
                sb.Append(version);
                if (version.Length < 23)
                {
                    sb.Append(" ");
                }
            }
            sb.Append("\n");
            return sb.ToString();
        }

        private static string NetworkResources(object[] args, ManagementObject m)
        {
            string name;
            System.Text.StringBuilder sb = new();
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                sb.Append(name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            else
            {
                name = "-";
                sb.Append(name);
                if (name.Length <= 9)
                {
                    int a = 9 - name.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }

            string Path;
            if (m[args[1].ToString()] != null)
            {
                Path = m[args[1].ToString()].ToString();
                sb.Append(Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            else
            {
                Path = "-";
                sb.Append(Path);
                if (Path.Length != 13)
                {
                    int a = 13 - Path.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            if (args.Length > 2)
            {
                string description;
                if (m[args[2].ToString()] != null)
                {
                    description = m[args[2].ToString()].ToString();
                    sb.Append(description);
                }
                else
                {
                    description = "-";
                    sb.Append(description);
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

        private static string InstalledPrograms(object[] args, ManagementObject m)
        {
            int firstoptimvalue = 80;
            int secondoptimvalue = 31;
            string nazwa = m[args[0].ToString()].ToString();
            string data = m[args[1].ToString()].ToString();
            string wersja = m[args[2].ToString()].ToString();
            System.Text.StringBuilder sb = new();

            int firstObjLength = nazwa.Length;
            int secondObjLenght = wersja.Length;
            int thirdObjLenght = data.Length;
            if (firstObjLength > 1)
                if (!nazwa.Contains("for Microsoft") && !nazwa.Contains("(KB"))
                {
                    int addspace;
                    sb.Append(nazwa + " ");
                    if (firstObjLength < firstoptimvalue)
                    {
                        addspace = firstoptimvalue - firstObjLength;
                        for (int i = 0; i < addspace; i++)
                            sb.Append(" ");
                    }
                    else
                    {
                        sb.Append("   ");
                    }
                    if (secondObjLenght > 1 && thirdObjLenght > 1)
                    {
                        sb.Append(data + " ");
                        if (firstoptimvalue > firstObjLength)
                        {
                            addspace = secondoptimvalue - secondObjLenght;
                            for (int i = 0; i < addspace; i++)
                                sb.Append(" ");
                        }
                        if (firstoptimvalue < firstObjLength)
                        {
                            if (firstoptimvalue + secondoptimvalue > firstObjLength + secondObjLenght + 3)
                            {
                                addspace = firstoptimvalue + secondoptimvalue - firstObjLength - secondObjLenght - 3;
                                for (int i = 0; i < addspace; i++)
                                    sb.Append(" ");
                            }
                            else sb.Append("  ");
                        }
                    }
                    if (secondObjLenght < 4 && thirdObjLenght > 1)
                    {
                        if (firstoptimvalue > firstObjLength)
                            addspace = secondoptimvalue;
                        else addspace = firstoptimvalue + secondoptimvalue - firstObjLength - 3;
                        for (int i = 0; i < addspace; i++)
                            sb.Append(" ");
                    }
                    if (secondObjLenght < 1 && thirdObjLenght < 1)
                    {
                        sb.Append("\n");
                    }
                    if (wersja.Length < 2)
                        wersja = "";
                    sb.Append(wersja + " " + "\n");
                }
            return sb.ToString();
        }

        private static string EnvironmentPath(object[] args, ManagementObject m)
        {
            string name;
            string variablevalue;
            System.Text.StringBuilder sb = new();
            if (m[args[0].ToString()] != null)
            {
                name = m[args[0].ToString()].ToString();
                sb.Append(name);
                if (name.Length <= 25)
                {
                    int a = 25 - name.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }

            if (m[args[1].ToString()] != null)
            {
                variablevalue = m[args[1].ToString()].ToString();
                sb.Append(variablevalue);

            }
            sb.Append("\n");
            return sb.ToString();
        }

        private static string AutoStart(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();
            string caption;
            if (m[args[0].ToString()] != null)
            {
                caption = m[args[0].ToString()].ToString();
                sb.Append(caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }
            else
            {
                caption = "-";
                sb.Append(caption);
                if (caption.Length <= 25)
                {
                    int a = 25 - caption.Length;
                    for (int i = 0; i < a; i++)
                        sb.Append(" ");
                }
            }

            string command;
            if (m[args[1].ToString()] != null)
            {
                command = m[args[1].ToString()].ToString();
                sb.Append(command);
            }
            else { command = "-"; sb.Append(command); }
            sb.Append("\n");
            return sb.ToString();
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
            string boottime = m[args[0].ToString()].ToString();
            string year = null;
            string month = null;
            string day = null;
            string hour = null;
            string minute = null;
            string second = null;
            System.Text.StringBuilder sb = new();
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
                sb.Append(bootTime.Days + " " + dayArr[0] + ",");
            if (bootTime.Days == 0 | bootTime.Days > 1)
                sb.Append(bootTime.Days + " " + dayArr[1] + ",");

            if (bootTime.Hours == 0 | bootTime.Hours > 4)
                sb.Append(bootTime.Hours + " " + hourArr[2] + ",");
            if (bootTime.Hours == 1)
                sb.Append(bootTime.Hours + " " + hourArr[0] + ",");
            if (bootTime.Hours > 1 && bootTime.Hours < 5)
                sb.Append(bootTime.Hours + " " + hourArr[1] + ",");

            if (bootTime.Minutes == 0 | bootTime.Minutes > 4)
                sb.Append(bootTime.Minutes + " " + minuteArr[2] + ",");
            if (bootTime.Minutes == 1)
                sb.Append(bootTime.Minutes + " " + minuteArr[0] + ",");
            if (bootTime.Minutes > 1 && bootTime.Minutes < 5)
                sb.Append(bootTime.Minutes + " " + minuteArr[1] + ",");

            if (bootTime.Seconds == 0 | bootTime.Seconds > 4)
                sb.Append(bootTime.Seconds + " " + secondArr[2]);
            if (bootTime.Seconds == 1)
                sb.Append(bootTime.Seconds + " " + secondArr[0]);
            if (bootTime.Seconds > 1 && bootTime.Seconds < 5)
                sb.Append(bootTime.Seconds + " " + secondArr[1]);
            sb.Append("\n");
            return sb.ToString();
        }

        private static string PNPDevice(object[] args, ManagementObject m)
        {
            System.Text.StringBuilder sb = new();
            if (m[args[0].ToString()] != null && m[args[1].ToString()] != null && m[args[2].ToString()] != null && m[args[3].ToString()] != null)
            {
                string Description = m[args[0].ToString()].ToString();
                sb.Append(Description);
                for (int i = 0; i < 75 - Description.Length; i++)
                {
                    sb.Append(" ");
                }            
                string Manufacturer = m[args[1].ToString()].ToString();
                sb.Append(Manufacturer);
                for (int i = 0; i < 32 - Manufacturer.Length; i++)
                {
                    sb.Append(" ");
                }
                string DriverDate = m[args[2].ToString()].ToString();
                //Skrócenie ciągu do 8 znaków i format do yyyy-MM-dd
                DriverDate = DriverDate.Remove(8).Insert(6, "-").Insert(4, "-");
                DriverDate += "        ";
                sb.Append(DriverDate);
                string DriverVersion = m[args[3].ToString()].ToString();
                sb.Append(DriverVersion);
                sb.Append('\n');
            }
            return sb.ToString();

        }
    }
}
