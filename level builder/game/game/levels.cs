using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace game
{
    class levels
    {
       // Hashtable xpUperLimit;

        Dictionary<int,int> xpUperLimit;

        public levels() {
            xpUperLimit = new Dictionary<int,int>();
            xpUperLimit.Add(0,0);
            xpUperLimit.Add(1,200);
            xpUperLimit.Add(2,230);
            xpUperLimit.Add(3,265);
            xpUperLimit.Add(4,304);
            xpUperLimit.Add(5,350);
            xpUperLimit.Add(6,402);
            xpUperLimit.Add(7,463);
            xpUperLimit.Add(8,532);
            xpUperLimit.Add(9,612);
            xpUperLimit.Add(10,704);
            xpUperLimit.Add(11,809);
            xpUperLimit.Add(12,930);
            xpUperLimit.Add(13,1070);
            xpUperLimit.Add(14,1231);
            xpUperLimit.Add(15,1415);
            xpUperLimit.Add(16,1627);
            xpUperLimit.Add(17,1872);
            xpUperLimit.Add(18,2152);
            xpUperLimit.Add(19,2475);
            xpUperLimit.Add(20,2846);
            xpUperLimit.Add(21,3273);
            xpUperLimit.Add(22,3764);
            xpUperLimit.Add(23,4329);
            xpUperLimit.Add(24,4978);
            xpUperLimit.Add(25,5725);
            xpUperLimit.Add(26,6584);
            xpUperLimit.Add(27,7571);
            xpUperLimit.Add(28,8707);
            xpUperLimit.Add(29,10013);
            xpUperLimit.Add(30,11515);
            xpUperLimit.Add(31,13242);
            xpUperLimit.Add(32,15229);
            xpUperLimit.Add(33,17513);
            xpUperLimit.Add(34,20140);
            xpUperLimit.Add(35,23161);
            xpUperLimit.Add(36,26635);
            xpUperLimit.Add(37,30630);
            xpUperLimit.Add(38,35225);
            xpUperLimit.Add(39,40509);
            xpUperLimit.Add(40,46585);
            xpUperLimit.Add(41,53573);
            xpUperLimit.Add(42,61609);
            xpUperLimit.Add(43,70850);
            xpUperLimit.Add(44,81477);
            xpUperLimit.Add(45,93699);
            xpUperLimit.Add(46,107754);
            xpUperLimit.Add(47,123917);
            xpUperLimit.Add(48,142504);
            xpUperLimit.Add(49,163880);
            xpUperLimit.Add(50, 188462);

        }

        public int fetchDing(int level) {
            int value = 0;
            if (xpUperLimit.TryGetValue(level, out value))
            {
                return value;
            }
            return 0;
        }

    }
}
