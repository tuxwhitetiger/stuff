using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class tisButAScratch : generalMove
    {
        Charictor player;

        public tisButAScratch(Charictor player)
        { 
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
