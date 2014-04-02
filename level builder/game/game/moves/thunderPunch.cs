using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class thunderPunch : generalMove
    {
        Charictor player;

        public thunderPunch(Charictor player)
        { 
            this.player = player;
        }

        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
