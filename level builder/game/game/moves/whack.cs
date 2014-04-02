using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game.moves
{
    class whack : generalMove
    {
        private Charictor player;

        public whack(Charictor player)
        {
            // TODO: Complete member initialization
            this.player = player;
        }
        public override void use(EventCharictor enamy)
        {
            enamy.dealdamage(player.getTotalMeleeDamage());
        }
    }
}
