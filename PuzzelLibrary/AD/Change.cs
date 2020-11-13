using System.Management.Automation;

namespace PuzzelLibrary.AD
{
    class Change
    {
        public void replaceProperty(string cnObject, string propertyName, string propertyValue)
        {
            var ps = PowerShell.Create().AddCommand("Set-ADComputer").AddParameter("Identity",  cnObject ).AddParameter("Replace"," @{" + "'" + propertyName + "'" + "=" + propertyValue + "}");
            ps.Invoke();
            ps.ToString();
            ps.Dispose();
        }
    }
}
