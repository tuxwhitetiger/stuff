using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class decapitate : generalMove
    {
        Charictor player;

        public decapitate(Charictor player)
        { 
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
