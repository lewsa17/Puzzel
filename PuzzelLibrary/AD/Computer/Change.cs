using System.DirectoryServices;

namespace PuzzelLibrary.AD.Computer
{
    class Change
    {
        public void Property(string cnObject, string propertyName, string propertyValue)
        {

            var compObject = Search.ByComputerName(cnObject, propertyName);
            if (compObject != null)
            {
                var d = new DirectoryEntry();
                d.Path = compObject[0].GetDirectoryEntry().Path;
                try
                {
                    d.Properties[propertyName].Value = propertyValue;
                    d.CommitChanges();
                }
                catch (System.Exception e)
                {
                    Debug.LogsCollector.GetLogs(e, nameof(cnObject) + "=" + cnObject + "," +
                                                   nameof(propertyName) + "=" + propertyName + "," +
                                                   nameof(propertyValue) + "=" + propertyValue);
                }
                finally
                {
                    d.Dispose();
                }
            }
        }
    }
}
