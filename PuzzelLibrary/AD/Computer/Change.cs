using System.Management.Automation;

namespace PuzzelLibrary.AD.Computer
{
    class Change
    {
        public void Property(string cnObject, string propertyName, string propertyValue)
        {
            using (var ps = PowerShell.Create())
            {
                ps.AddScript("Set-ADComputer -Identity " + cnObject + " -Replace @{" + "'" + propertyName + "'" + "=" + propertyValue + "}");
                ps.Invoke();
            }
        }
    }
}
