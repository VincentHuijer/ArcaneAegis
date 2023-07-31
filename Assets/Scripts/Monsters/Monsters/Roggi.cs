//using UnityEngine;

//public class RoggiMonster : MonoBehaviour
//{
//    // Create a new instance of the MonsterBase scriptable object
//    [SerializeField] public MonsterBase roggiMonster;

//    private void Start()
//    {
//        // Set the name for the monster
//        roggiMonster.name = "Roggi";

//        // Set the type to normal
//        roggiMonster.Type1 = MonsterType.normal;

//        // Set all stats to 20
//        roggiMonster.MaxHP = 20;
//        roggiMonster.CurrentHP = 20;
//        roggiMonster.Attack = 20;
//        roggiMonster.Strength = 20;
//        roggiMonster.Intellect = 20;
//        roggiMonster.Defence = 20;
//        roggiMonster.SpellGuard = 20;
//        roggiMonster.Agility = 20;
//        roggiMonster.Luck = 20;
//        roggiMonster.Karma = 20;
//    }
//}


public class Roggi : MonsterBase
{
    void Start()
    {
        // Set stats for Turnip
        name = "Roggi";
        maxHP = 6;
        currentHP = 6;
        attack = 6;
        strength = 6;
        intellect = 6;
        defence = 6;
        spellguard = 6;
        agility = 6;
        luck = 6;
        karma = 6;
    }

    public override void Attack()
    {
        base.Attack();
        // Implement Turnip-specific attack logic here
    }

    // You can add Turnip-specific methods here if needed
}


