using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class battleCry3 : generalMove
    {
        Charictor player;

        public battleCry3(Charictor player) { 
        
            this.player = player;
        }

        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
