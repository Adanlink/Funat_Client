using System;
using Server.SharedThings.Packets.Representations;
using UnityEngine;

namespace UserInterface.GameMenu.CharacterList
{
    public abstract class CharacterRepresentationBase : MonoBehaviour
    {
        public Character Character { get; set; }
        
        public virtual void SetAsPlayableCharacter(Character character)
        {
            throw new NotImplementedException();
        }

        public virtual void SetAsCreateNewCharacter()
        {
            throw new NotImplementedException();
        }
        
        public virtual void ToggleDeleteMode()
        {
            throw new NotImplementedException();
        }
    }
}