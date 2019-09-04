using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Windows.Forms;

namespace Puzzel
{
    public class ComputerInfo
    {
        public static string pathCIMv2 = @"\root\CIMV2";
        public static string pathWMI = @"\root\wmi";
        public static string queryComputerSystem = "Win32_ComputerSystem";
        public static string queryOperatingSystem = "Win32_OperatingSystem";
        public static string queryComputerSystemProduct = "Win32_ComputerSystemProduct";
        public static string querySystemInformation = "MS_SystemInformation";
        public static string queryPhysicalMemory = "Win32_PhysicalMemory";
        public static string queryProcessor = "Win32_Processor";
        public static string queryDesktop = "Win32_Desktop";
        public static string queryLogicalDisk = "Win32_LogicalDisk";
        public static string queryPrinterConfiguration = "Win32_PrinterConfiguration";
        public static string queryShare = "Win32_Share";
        public static string queryStartupCommand = "Win32_StartupCommand";
        public static string queryEnvironment = "Win32_Environment";
        public static string queryNetworkConnection = "Win32_NetworkConnection";
        public static string queryNetworkAdapterConfiguration = "Win32_NetworkAdapterConfiguration";

        public void GetInfo(string nazwaKomputera, string path, string query, params object[] args)
        {
            UInt64 TotalCapacity = 0;
            //string _TotalCapacity = null;
            int warunek = 0;
            int warunek1 = 0;
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
                                    if (query == queryOperatingSystem)
                                    {
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
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Days + " " + dzien1[0] + ",");
                                        if (czasbootowania.Days == 0 | czasbootowania.Days > 1)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Days + " " + dzien1[1] + ",");

                                        if (czasbootowania.Hours == 0 | czasbootowania.Hours > 4)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Hours + " " + godzina1[2] + ",");
                                        if (czasbootowania.Hours == 1)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Hours + " " + godzina1[0] + ",");
                                        if (czasbootowania.Hours > 1 && czasbootowania.Hours < 5)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Hours + " " + godzina1[1] + ",");

                                        if (czasbootowania.Minutes == 0 | czasbootowania.Minutes > 4)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Minutes + " " + minuta1[2] + ",");
                                        if (czasbootowania.Minutes == 1)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Minutes + " " + minuta1[0] + ",");
                                        if (czasbootowania.Minutes > 1 && czasbootowania.Minutes < 5)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Minutes + " " + minuta1[1] + ",");

                                        if (czasbootowania.Seconds == 0 | czasbootowania.Seconds > 4)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Seconds + " " + sekunda1[2]);
                                        if (czasbootowania.Seconds == 1)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Seconds + " " + sekunda1[0]);
                                        if (czasbootowania.Seconds > 1 && czasbootowania.Seconds < 5)
                                            Puzzel.Form1.ComputerInfo_TEMP += (czasbootowania.Seconds + " " + sekunda1[1]);
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        break;
                                    }

                                    //memoryTotal
                                    //args0 = capacity
                                    if (query == queryPhysicalMemory)
                                    {
                                        warunek1++;
                                        TotalCapacity += (UInt64)(m[args[0].ToString()]) / 1024 / 1024 / 1024;
                                        if (queryCollection.Count == warunek1)
                                            Puzzel.Form1.ComputerInfo_TEMP += TotalCapacity + " GB";
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        Puzzel.Form1.ComputerInfo_TEMP += (m[args[0].ToString()] + "\n");
                                    break;
                                }
                            case 2:
                                {
                                    //autostart
                                    //args0 = caption
                                    //args1 = command
                                    if (query == queryStartupCommand)
                                    {
                                        string caption = null;
                                        if (m[args[0].ToString()] != null)
                                        {
                                            caption = m[args[0].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (caption);
                                            if (caption.Length <= 25)
                                            {
                                                int a = 25 - caption.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                        else
                                        {
                                            caption = "-";
                                            Puzzel.Form1.ComputerInfo_TEMP += (caption);
                                            if (caption.Length <= 25)
                                            {
                                                int a = 25 - caption.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }

                                        string command = null;
                                        if (m[args[1].ToString()] != null)
                                        {
                                            command = m[args[1].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (command);
                                        }
                                        else { command = "-"; Puzzel.Form1.ComputerInfo_TEMP += (command); }
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        break;
                                    }

                                    //Zmienna PATH
                                    //args0 = name
                                    //args1 = variablevalue
                                    if (query == queryEnvironment)
                                    {
                                        string name;
                                        string variablevalue;
                                        if (m[args[0].ToString()] != null)
                                        {
                                            name = m[args[0].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (name);
                                            if (name.Length <= 25)
                                            {
                                                int a = 25 - name.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }

                                        if (m[args[1].ToString()] != null)
                                        {
                                            variablevalue = m[args[1].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (variablevalue);

                                        }
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        break;
                                    }
                                    if (m[args[0].ToString()] != null)
                                        Puzzel.Form1.ComputerInfo_TEMP += (m[args[0].ToString()] + "     " + m[args[1].ToString()] + "\n");
                                    break;
                                }
                            case 3:
                                {
                                    //zasoby sieciowe
                                    //args0 = name
                                    //args1 = path
                                    //args2 = description
                                    string name;
                                    if (m[args[0].ToString()] != null)
                                    {
                                        name = m[args[0].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (name);
                                        if (name.Length <= 9)
                                        {
                                            int a = 9 - name.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }
                                    else
                                    {
                                        name = "-";
                                        Puzzel.Form1.ComputerInfo_TEMP += (name);
                                        if (name.Length <= 9)
                                        {
                                            int a = 9 - name.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    string Path;
                                    if (m[args[1].ToString()] != null)
                                    {
                                        Path = m[args[1].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (Path);
                                        if (Path.Length != 13)
                                        {
                                            int a = 13 - Path.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }
                                    else
                                    {
                                        Path = "-";
                                        Puzzel.Form1.ComputerInfo_TEMP += (Path);
                                        if (Path.Length != 13)
                                        {
                                            int a = 13 - Path.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    string description;
                                    if (m[args[2].ToString()] != null)
                                    {
                                        description = m[args[2].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (description);
                                    }
                                    else
                                    {
                                        description = "-";
                                        Puzzel.Form1.ComputerInfo_TEMP += (description);
                                    }
                                    Puzzel.Form1.ComputerInfo_TEMP += ("\n");
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
                                        string caption = null;
                                        string csdversion = null;
                                        string osarchitecture = null;
                                        string version = null;

                                        if (m[args[0].ToString()] != null)
                                        {
                                            caption = m[args[0].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (caption);
                                            int a = 44 - caption.Length;
                                            for (int i = 0; i < a; i++)
                                            {
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }

                                        if (m[args[1].ToString()] != null)
                                        {
                                            csdversion = m[args[1].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (csdversion);
                                            if (csdversion.Length != 22)
                                            {
                                                //int a = 15 - csdversion.Length;
                                                //for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += ("  ");
                                            }
                                        }
                                        else
                                        {
                                            csdversion = "-";
                                            Puzzel.Form1.ComputerInfo_TEMP += (csdversion);
                                            //int a = 15 - csdversion.Length;
                                            //for (int i = 0; i < a; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += ("  ");
                                        }

                                        if (m[args[2].ToString()] != null)
                                        {
                                            osarchitecture = m[args[2].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (osarchitecture);
                                            if (osarchitecture.Length != 16)
                                            {
                                                //int a = 14 - osarchitecture.Length;
                                                //for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += ("  ");
                                            }
                                        }

                                        if (m[args[3].ToString()] != null)
                                        {
                                            version = m[args[3].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (version);
                                            if (version.Length < 23)
                                            {
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
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
                                        string name = null;
                                        string description = null;
                                        string filesystem = null;
                                        string freespace = null;
                                        string size = null;

                                        if (m[args[0].ToString()] != null)
                                        {
                                            name = m[args[0].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (name);
                                            int a = 8 - name.Length;
                                            for (int i = 0; i < a; i++)
                                            {
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }

                                        if (m[args[1].ToString()] != null)
                                        {
                                            description = m[args[1].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (description);
                                            if (description.Length != 22)
                                            {
                                                int a = 22 - description.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                        else
                                        {
                                            description = "-";
                                            Puzzel.Form1.ComputerInfo_TEMP += (description);
                                            int a = 22 - description.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }

                                        if (m[args[2].ToString()] != null)
                                        {
                                            filesystem = m[args[2].ToString()].ToString();
                                            Puzzel.Form1.ComputerInfo_TEMP += (filesystem);
                                            if (filesystem.Length != 16)
                                            {
                                                int a = 16 - filesystem.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                        else
                                        {
                                            filesystem = "-";
                                            Puzzel.Form1.ComputerInfo_TEMP += (filesystem);
                                            int a = 16 - filesystem.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }

                                        if (m[args[3].ToString()] != null)
                                        {
                                            freespace = m[args[3].ToString()].ToString();
                                            UInt64 b = ((UInt64)m[args[3].ToString()]) / 1024 / 1024 / 1024;
                                            freespace += " (" + b.ToString() + "GB)";
                                            Puzzel.Form1.ComputerInfo_TEMP += (freespace);
                                            if (freespace.Length < 23)
                                            {
                                                int a = 23 - freespace.Length;
                                                for (int i = 0; i < a; i++)
                                                    Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }

                                        }
                                        else
                                        {
                                            freespace = "-"; Puzzel.Form1.ComputerInfo_TEMP += (freespace);
                                            int a = 23 - freespace.Length;
                                            for (int i = 0; i < a; i++)
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }

                                        if (m["size"] != null)
                                        {
                                            size = m["size"].ToString();
                                            UInt64 b = ((UInt64)m["size"]) / 1024 / 1024 / 1024;
                                            size += " (" + b.ToString() + "GB)";
                                            Puzzel.Form1.ComputerInfo_TEMP += (size);
                                        }
                                        else { size = "-"; Puzzel.Form1.ComputerInfo_TEMP += (size); }

                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                    }
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
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Rozmiar");
                                        for (int i = 0; i < capacitySize; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");

                                        Puzzel.Form1.ComputerInfo_TEMP += ("Speed");
                                        for (int i = 0; i < speedSize; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");

                                        Puzzel.Form1.ComputerInfo_TEMP += ("Slot");
                                        for (int i = 0; i < devicelocatorSize; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");

                                        Puzzel.Form1.ComputerInfo_TEMP += ("Producent");
                                        for (int i = 0; i < manufacturerSize; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");

                                        Puzzel.Form1.ComputerInfo_TEMP += ("Nr Partii");
                                        for (int i = 0; i < partnumberSize; i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Nr Seryjny");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                    }
                                    //wyrzucanie wartości
                                    if (m[args[2].ToString()] != null)
                                    {
                                        _capacity = m[args[2].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += _capacity;
                                        int a = 13 - _capacity.Length;
                                        for (int i = 0; i < a; i++)
                                        {
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    if (m[args[3].ToString()] != null)
                                    {
                                        speed = m[args[3].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (speed);
                                        int a = 7 - speed.Length;
                                        for (int i = 0; i < a; i++)
                                        {
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    if (m[args[0].ToString()] != null)
                                    {
                                        devicelocator = m[args[0].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (devicelocator);

                                        if (devicelocator.Length > 7)
                                        {
                                            int a = 22 - devicelocator.Length;
                                            for (int i = 0; i < a; i++)
                                            {
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                        else if (devicelocator.Length < 7)
                                        {
                                            int a = 7 - devicelocator.Length;
                                            for (int i = 0; i < a; i++)
                                            {
                                                Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                            }
                                        }
                                    }

                                    if (m[args[1].ToString()] != null)
                                    {
                                        manufacturer = m[args[1].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (manufacturer);
                                        int a = 14 - manufacturer.Length;
                                        for (int i = 0; i < a; i++)
                                        {
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    if (m[args[4].ToString()] != null)
                                    {
                                        partnumber = m[args[4].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (partnumber);
                                        int a = 20 - partnumber.Length;
                                        for (int i = 0; i < a; i++)
                                        {
                                            Puzzel.Form1.ComputerInfo_TEMP += (" ");
                                        }
                                    }

                                    if (m[args[5].ToString()] != null)
                                    {
                                        serialnumber = m[args[5].ToString()].ToString();
                                        Puzzel.Form1.ComputerInfo_TEMP += (serialnumber);
                                    }
                                    Puzzel.Form1.ComputerInfo_TEMP += ("\n");
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

                                    string[] Suffix;
                                    string[] Ipaddress;
                                    string[] IPSubnet;

                                    if (args.Length > 1)
                                    {
                                        Suffix = (string[])m[args[2].ToString()];
                                        Ipaddress = (string[])m[args[4].ToString()];
                                        IPSubnet = (string[])m[args[5].ToString()];

                                        Puzzel.Form1.ComputerInfo_TEMP += ("Nazwa karty sieciowej   " + m[args[1].ToString()].ToString() + "\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("IP Włączone             " + m[args[0].ToString()].ToString() + "\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("DNS Suffix              ");
                                        for (int i = 0; i < Suffix.Count(); i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (Suffix[i] + "; ");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Nazwa hosta DNS         " + m[args[3].ToString()].ToString() + "\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Adres IP                ");
                                        for (int i = 0; i < Ipaddress.Count(); i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (Ipaddress[i] + "; ");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Maska podsieci          ");
                                        for (int i = 0; i < IPSubnet.Count(); i++)
                                            Puzzel.Form1.ComputerInfo_TEMP += (IPSubnet[i] + "; ");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("\n");
                                        Puzzel.Form1.ComputerInfo_TEMP += ("Adres MAC               " + m[args[6].ToString()].ToString() + ";\n");
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Dostęp zabroniony na obecnych poświadczeniach", "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Nie można się połączyć z powodu błędu: " + ex.Message, "WMI Testing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return;
            }

        }
    }
}
