using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class ningaFurry : generalMove
    {
        private Charictor player;

        public ningaFurry(Charictor player)
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
