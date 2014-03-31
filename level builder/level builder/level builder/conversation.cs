using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace level_builder
{
    class conversation
    {
        List<string> talk = new List<string>();

        public void addTalk(String talk) {
            this.talk.Add(talk);
        }

        internal List<string> getList()
        {
            return talk;
        }
    }
}
