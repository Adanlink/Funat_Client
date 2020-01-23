using System.Collections.Generic;
using Server.SharedThings.Packets.Representations;

namespace UserInterface.GameMenu.CharacterList
{
    public interface ICharacterListController : IHudHolder
    {
        void Update();

        void ShowCharacterList(IEnumerable<Character> characters);

        void ToggleDeleteMode();
    }
}