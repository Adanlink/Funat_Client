using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.GameInterface
{
    public interface IChatController
    {
        bool Writing { get; }

        void AddChatMessage(string Message);
    }
}
