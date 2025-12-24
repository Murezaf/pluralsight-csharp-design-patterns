using Singleton_TableServerTimCorey;

//TableServers tableServers = new TableServers();

//for(int i = 0; i < 5; i++)
//{
//    Console.WriteLine("The next server is: " + tableServers.NextServer());
//}



//TableServers host1List = new TableServers();
//TableServers host2List = new TableServers();

//void Host1NextServer()
//{
//    Console.WriteLine("The next server is: " + host1List.NextServer());
//}

//void Host2NextServer()
//{
//    Console.WriteLine("The next server is: " + host2List.NextServer());
//}

//for (int i = 0; i < 5; i++)
//{
//    Host1NextServer();
//    Host2NextServer();
//}



TableServers host1List = TableServers.GetTableServers();
TableServers host2List = TableServers.GetTableServers();

void Host1NextServer()
{
    Console.WriteLine("The next server is: " + host1List.NextServer());
}

void Host2NextServer()
{
    Console.WriteLine("The next server is: " + host2List.NextServer());
}

for (int i = 0; i < 5; i++)
{
    Host1NextServer();
    Host2NextServer();
}