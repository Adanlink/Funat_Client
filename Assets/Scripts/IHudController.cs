using Assets.Scripts.UserInterface.GameInterface;
using UserInterface.GameInterface;
using UserInterface.GameMenu.CharacterList;
using UserInterface.GameMenu.CreateCharacter;

public interface IHudController
{
    ICharacterListController CharacterListController { get; set; }
    
    ICharacterCreateController CharacterCreateController { get; set; }

    IChatHandler ChatController { get; set; }
}