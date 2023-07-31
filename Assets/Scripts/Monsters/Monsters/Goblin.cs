using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEditor.Playables;
using UnityEngine;

public class Goblin : MonsterBase
{
    void Start()
    {
        // Set stats for Goblin
        name = "Goblin";
        maxHP = 10;
        currentHP = 10;
        attack = 10;
        strength = 10;
        intellect = 10;
        defence = 10;
        spellguard = 10;
        agility = 10;
        luck = 10;
        karma = 10;
    }

    public override void Attack()
    {
        base.Attack();
        // Implement Goblin-specific attack logic here
    }

    // You can add Goblin-specific methods here if needed
}
