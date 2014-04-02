using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class bloodRage : generalMove
    {
        Charictor player;

        public bloodRage(Charictor player)
        {
            // TODO: Complete member initialization
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
