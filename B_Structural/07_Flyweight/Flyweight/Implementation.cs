namespace Flyweight;

//Flyweight
public interface ICharacter
{
    void Draw(string fontFamily, int fontSize); //One method is required, which gets the extrinsic states passed in: fontFamily and fontSize.
}

//ConcreteFlyweight
public class CharacterA: ICharacter
{
    private char _actualCharacter = 'a'; //Intrinsic state
    private int _fontSize;
    private string _fontFamily = string.Empty;
    //Extrinsic states: these can be changed(via the Draw method)

    public void Draw(string fontFamily, int fontSize)
    {
        _fontSize = fontSize;
        _fontFamily = fontFamily;
        Console.WriteLine($"Drawing {_actualCharacter} with {_fontFamily}, {_fontSize}.");
    }
}

//ConcreteFlyweight
public class CharacterB : ICharacter
{
    private char _actualCharacter = 'b'; 
    private int _fontSize;
    private string _fontFamily = string.Empty;

    public void Draw(string fontFamily, int fontSize)
    {
        _fontSize = fontSize;
        _fontFamily = fontFamily;
        Console.WriteLine($"Drawing {_actualCharacter} with {_fontFamily}, {_fontSize}.");
    }
}

//FlyweightFactory
public class CharacterFactory
{
    private readonly Dictionary<char, ICharacter> _characters = new Dictionary<char, ICharacter>();

    public ICharacter? GetCharacter(char characterIdentifier)
    {
        if(_characters.ContainsKey(characterIdentifier))
        {
            Console.WriteLine("Character reuse.");
            return _characters[characterIdentifier];
        }

        Console.WriteLine("Character construction");
        switch (characterIdentifier)
        {
            case 'a':
                _characters[characterIdentifier] = new CharacterA();
                return _characters[characterIdentifier];

            case 'b':
                _characters[characterIdentifier] = new CharacterB();
                return _characters[characterIdentifier];

            //and so on...(for other alphabet characters)
        }

        return null;
    }

    public ICharacter CreateParagraph(int location, List<ICharacter> characters)
    {
        return new Paragraph(location, characters); //Working with unshared concrete flyweight => always working with new instances(no sharing)
    }
}

//UnsharedConcreteFlyweight
public class Paragraph : ICharacter
{
    //The flyweight interface enables sharing, but it does not enforce it. It enables acting on extrinsic state while having unshareable intrinsic state.

    private int _location;
    private List<ICharacter> characters = new List<ICharacter>();
    //The location and the characters paragraph contains, are linked to the paragraph. We cannot reuse the paragraph instance => A new paragraph means we need a new instance

    public Paragraph(int location, List<ICharacter> characters)
    {
        _location = location;
        this.characters = characters;
    }

    public void Draw(string fontFamily, int fontSize)
    {
        Console.WriteLine($"Drawing paragraph in location {_location}");
        foreach (ICharacter character in characters)
        {
            character.Draw(fontFamily, fontSize);
        }
    }
}