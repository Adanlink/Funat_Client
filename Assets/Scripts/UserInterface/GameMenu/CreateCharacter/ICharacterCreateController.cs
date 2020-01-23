namespace UserInterface.GameMenu.CreateCharacter
{
    public interface ICharacterCreateController : IHudHolder
    {
        void Update();
        
        void ShowCharacterCreate();

        void RemoveThisHud();
    }
}