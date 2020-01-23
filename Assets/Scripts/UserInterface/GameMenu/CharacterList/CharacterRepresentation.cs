using Server.SharedThings.Packets.Representations;
using TMPro;

namespace UserInterface.GameMenu.CharacterList
{
    public class CharacterRepresentation : CharacterRepresentationBase
    {
        public TextMeshProUGUI Nickname;

        public TextMeshProUGUI Authority;

        public TextMeshProUGUI TimeOfCreation;

        public TextMeshProUGUI LastTimePlayed;

        public TextMeshProUGUI MapId;

        public FlexibleButton FlexibleButton;

        public override void SetAsPlayableCharacter(Character character)
        {
            Character = character;
            if (Nickname != null) Nickname.SetText("Nickname: " + character.Nickname);
            if (Authority != null) Authority.SetText("Authority: " + character.Authority);
            if (TimeOfCreation != null) TimeOfCreation.SetText("TimeOfCreation: " + character.TimeOfCreation);
            if (LastTimePlayed != null) LastTimePlayed.SetText("LastTimePlayed: " + character.LastTimePlayed);
            if (MapId != null) MapId.SetText("MapId: " + character.MapId);
            
            FlexibleButton.SetFunction(FlexibleButtonStatus.Play);
            //TODO set sprite of player
        }

        public override void SetAsCreateNewCharacter()
        {
            Authority.SetText("Create new character");
            FlexibleButton.SetFunction(FlexibleButtonStatus.Create);
        }

        public override void ToggleDeleteMode()
        { 
            FlexibleButton.ToggleDeleteMethod();
        }
    }
}