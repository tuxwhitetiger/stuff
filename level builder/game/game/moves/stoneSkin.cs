using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class stoneSkin : generalMove
    {
        Charictor player;

        public stoneSkin(Charictor player) {
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            throw new NotImplementedException();
        }
    }
}
