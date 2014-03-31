using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class moveController
    {

        public Object getMove(Charictor player,Move move) {

            switch (move) {

                case Move.animal_within:  return new moves.animalWithin(player); 
                case Move.battleCry1:     return new moves.battleCry1(player); 
                case Move.battleCry2:     return new moves.battleCry2(player); 
                case Move.battleCry3:     return new moves.battleCry3(player); 
                case Move.bloodRage:      return new moves.bloodRage(player); 
                case Move.circle_of_fire: return new moves.circleOfFire(player); 
                case Move.dead_shot:      return new moves.deadShot(player); 
                case Move.decapitate:     return new moves.decapitate(player); 
                case Move.explosive_shot: return new moves.explosiveShot(player); 
                case Move.fireblast:      return new moves.fireBlast(player); 
                case Move.forkShot:       return new moves.forkShot(player); 
                case Move.icefire:        return new moves.iceFire(player); 
                case Move.mana_shild:     return new moves.manaSheild(player); 
                case Move.ninga_furry:    return new moves.ningaFurry(player); 
                case Move.poisen:         return new moves.poisen(player); 
                case Move.sole_rip:       return new moves.soleRip(player); 
                case Move.speed_stabs:    return new moves.speedStabs(player); 
                case Move.stoneSkin:      return new moves.stoneSkin(player); 
                case Move.takedown:       return new moves.takedown(player); 
                case Move.target:         return new moves.traget(player); 
                case Move.taunt:          return new moves.taunt(player); 
                case Move.taunt2:         return new moves.taunt2(player); 
                case Move.thunderPuntch:  return new moves.thunderPunch(player); 
                case Move.tisButAScratch: return new moves.tisButAScratch(player);
                case Move.to_the_shadows: return new moves.toTheShadows(player);
                case Move.shoot:          return new moves.shoot(player);
                case Move.zap:            return new moves.zap(player);
                case Move.stab:           return new moves.stab(player);
                case Move.whack:          return new moves.whack(player); 
            }
            return null;
        }

    }
    public enum Move
    {
        bloodRage,
        stoneSkin, 
        battleCry1,
        battleCry2,
        battleCry3, 
        decapitate, 
        taunt,
        taunt2,
        thunderPuntch,
        takedown,
        tisButAScratch,
        mana_shild, 
        fireblast,
        circle_of_fire,
        sole_rip,
        icefire,
        poisen,
        speed_stabs,
        dead_shot,
        animal_within,
        to_the_shadows,
        forkShot,
        target,
        ninga_furry,
        explosive_shot,
        shoot,
        zap,
        stab,
        whack
    }
    public enum TalentEffect {
        none,
        bag_space_plus_5,
        bloodRage,
        stoneSkin,
        dualWeild,
        dualWeild2,
        battleCry1,
        battleCry2,
        battleCry3,
        decapitate,
        critChance_plus_5,
        taunt,
        taunt2,
        thunderPuntch,
        takedown,
        tisButAScratch,
        mana_shild,
        mana_cristle,
        fireblast,
        circle_of_fire,
        sole_rip,
        icefire,
        poisen,
        speed_stabs,
        dead_shot,
        animal_within,
        to_the_shadows,
        forkShot,
        target,
        ninga_furry,
        explosive_shot
    
    }
}
