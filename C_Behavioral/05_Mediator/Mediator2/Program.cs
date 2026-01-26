using Mediator2;

Console.Title = "Mediator";

TeamChatRoom chatRoom = new TeamChatRoom();

Lawyer sven = new Lawyer("Sven");
Lawyer kevin = new Lawyer("Kevin");
AccountManager sarah = new AccountManager("Sarah");
AccountManager tom = new AccountManager("Tom");
AccountManager john = new AccountManager("John");

chatRoom.Register(sven);
chatRoom.Register(kevin);
chatRoom.Register(sarah);
chatRoom.Register(tom);
chatRoom.Register(john);

kevin.Send("Hi everyone! can someone look at the file A1224B.pdf?");
john.Send("On it!");

Console.WriteLine();

john.Send("Kevin", "Can you join me in a team call?");

Console.WriteLine();

kevin.Send<AccountManager>("The file was approved.");