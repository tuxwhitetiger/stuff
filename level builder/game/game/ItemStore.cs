using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class ItemStore
    {
        Dictionary<int,Item> ItemDB;

        public ItemStore()
        {// 0-head 1-cheast 2-hands 3-legs 4-feet 5-leftwep 6-rightwep
            ItemDB = new Dictionary<int, Item>();
            //weapons lv1
            ItemDB.Add(0, new Item(ItemType.axe, "dull axe", "+2 damage", 0, 0, 0, 0, 0, 0, 0, 0, 2, 0,0,7));
            ItemDB.Add(1, new Item(ItemType.dagger, "dull dagger", "+1 damage", 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,1,7));
            ItemDB.Add(2, new Item(ItemType.staff, "small stick", "+2 damage", 0, 0, 0, 0, 0, 0, 0, 0, 2, 0,2,7));
            ItemDB.Add(3, new Item(ItemType.bow, "stick and string", "+2 damage", 0, 0, 0, 0, 0, 0, 0, 0, 2, 0,3,7));

            //armor lv1

            ItemDB.Add(4, new Item(ItemType.platehead, "simple iron helm", "+3 armor", 0, 0, 0, 0, 0, 3, 0, 0, 0, 0,4,0));
            ItemDB.Add(5, new Item(ItemType.platecheast, "simple iron cheastplate", "+3 armor", 0, 0, 0, 0, 0, 3, 0, 0, 0, 0,5,1));
            ItemDB.Add(6, new Item(ItemType.platehands, "simple iron gauntlets", "+3 armor", 0, 0, 0, 0, 0, 3, 0, 0, 0, 0,6,2));
            ItemDB.Add(7, new Item(ItemType.platelegs, "simple iron leg plates","+3 armor", 0, 0, 0, 0, 0, 3, 0, 0, 0, 0,7,3));
            ItemDB.Add(8, new Item(ItemType.platefeet, "simple iron boots", "+3 armor", 0, 0, 0, 0, 0, 3, 0, 0, 0, 0,8,4));

            ItemDB.Add(9, new Item(ItemType.leatherhead, "simple leather hood", "+2 armor", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0,9,0));
            ItemDB.Add(10, new Item(ItemType.leathercheast, "simple leather jacket", "+2 armor", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0,10,1));
            ItemDB.Add(11, new Item(ItemType.leatherhands, "simple leather gloves", "+2 armor", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0,11,2));
            ItemDB.Add(12, new Item(ItemType.leatherlegs, "simple leather trousers", "+2 armor", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0,12,3));
            ItemDB.Add(13, new Item(ItemType.leatherfeet, "simple leather boots", "+2 armor", 0, 0, 0, 0, 0, 2, 0, 0, 0, 0,13,4));

            ItemDB.Add(14, new Item(ItemType.clothhead, "simple cloth hood", "+1 armor", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,14,0));
            ItemDB.Add(15, new Item(ItemType.clothcheast, "simple cloth shirt", "+1 armor", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,15,1));
            ItemDB.Add(16, new Item(ItemType.clothhands, "simple cloth gloves", "+1 armor", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,16,2));
            ItemDB.Add(17, new Item(ItemType.clothlegs, "simple cloth trousers", "+1 armor", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,17,3));
            ItemDB.Add(18, new Item(ItemType.clothfeet, "simple cloth shoes ", "+1 armor", 0, 0, 0, 0, 0, 0, 1, 0, 0, 0,18,4));

            //pots lv 1
            ItemDB.Add(19, new Item(ItemType.potion, "simple mana potion", "+10 mana", 0, 0, 0, 0, 0, 10, 0, 0, 0, 0,19,8));
            ItemDB.Add(20, new Item(ItemType.potion, "simple health potion", "+10 health", 0, 0, 0, 0, 10, 0, 0, 0, 0, 0,20,8));
            //'type','name','discription','strengthTotal','int','dex','HP','mana','armor','dodge','damreduc','melee','spell'
        }

        public Item fetchItem(int ID)
        {
            Item value;
            if (ItemDB.TryGetValue(ID, out value))
            {
                return value;
            }
            return null;
        }

    }
}
