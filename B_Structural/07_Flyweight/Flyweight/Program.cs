using Flyweight;

Console.Title = "Flyweight";

string bounchOfCharactersToTest = "abba";
CharacterFactory characterFactory = new CharacterFactory();

//Firstime having the character => construction to draw
ICharacter? characterObject = characterFactory.GetCharacter(bounchOfCharactersToTest[0]);
characterObject?.Draw("BNazanin", 12);

characterObject = characterFactory.GetCharacter(bounchOfCharactersToTest[1]);
characterObject?.Draw("Arial", 14);

//had the character before => reuse to draw(don't need to new an object all 4 times)
characterObject = characterFactory.GetCharacter(bounchOfCharactersToTest[2]);
characterObject?.Draw("Comic Sans", 18);

characterObject = characterFactory.GetCharacter(bounchOfCharactersToTest[3]);
characterObject?.Draw("Times New", 10);

var paragraph = characterFactory.CreateParagraph(1, new List<ICharacter> { characterObject });
paragraph.Draw("Lucinda", 12);