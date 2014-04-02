using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class battleCry2 : generalMove
    {
        Charictor player;

        public battleCry2(Charictor player) { 
        
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
