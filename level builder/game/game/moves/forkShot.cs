using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class forkShot : generalMove
    {
        private Charictor player;

        public forkShot(Charictor player)
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
