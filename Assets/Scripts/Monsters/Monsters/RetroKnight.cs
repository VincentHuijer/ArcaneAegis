using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEditor.Playables;
using UnityEngine;

public class Knight : MonsterBase
{
    void Start()
    {
        // Set stats for Knight
        name = "Retro Knight";
        maxHP = 20;
        currentHP = 20;
        attack = 20;
        strength = 20;
        intellect = 20;
        defence = 20;
        spellguard = 20;
        agility = 20;
        luck = 20;
        karma = 20;
    }

    public override void Attack()
    {
        base.Attack();
        // Implement Knight-specific attack logic here
    }

    // You can add Knight-specific methods here if needed
}
