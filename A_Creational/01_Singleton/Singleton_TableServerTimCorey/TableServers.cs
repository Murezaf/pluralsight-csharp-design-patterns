namespace Singleton_TableServerTimCorey
{
    //public class TableServers
    //{
    //    private List<string> Servers = new List<string>();
    //    private int nextServer = 0;

    //    public TableServers()
    //    {
    //        Servers.Add("Bob");
    //        Servers.Add("Tim");
    //        Servers.Add("Sue");
    //        Servers.Add("Mary");
    //    }

    //    public string NextServer()
    //    {
    //        string next = Servers[nextServer];

    //        nextServer += 1;
    //        if (nextServer == Servers.Count)
    //            nextServer = 0;
    //        //nextServer = (nextServer + 1) % Servers.Count;

    //        return next;
    //    }
    //}

    public class TableServers
    {
        private static readonly TableServers _instance = new TableServers();
     
        private List<string> Servers = new List<string>();
        private int nextServer = 0;

        private TableServers()
        {
            Servers.Add("Bob");
            Servers.Add("Tim");
            Servers.Add("Sue");
            Servers.Add("Mary");
        }

        public static TableServers GetTableServers()
        {
            return _instance;
        }

        public string NextServer()
        {
            string next = Servers[nextServer];

            nextServer = (nextServer + 1) % Servers.Count;

            return next;
        }
    }
}