using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInterface.GameMenu;

namespace Assets.Scripts.UserInterface.GameInterface
{
    public interface IChatHandler : IHudHolder
    {
        bool Writing { get; }

        void RecieveMessage(string Message);

        void EnableChat();
    }
}
