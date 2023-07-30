using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Monster", menuName ="Monster/Create new monster")]
public class MonsterBase : ScriptableObject //vergelijkbaar met een extend of interface. Je kan er van afwijken
{
    [SerializeField] string name;
    [TextArea]
    //[SerializeField] string description;
    [SerializeField] Sprite battleSprite; //sidesprite
    [SerializeField] Sprite defeatedSprite;

    //mogelijk meer dan 1 type maken
    [SerializeField] MonsterType type1;
    //[SerializeField] MonsterType type2;

    //Stats
    [SerializeField] int maxHP;
    [SerializeField] int currentHP;
    [SerializeField] int attack;
    [SerializeField] int strength;
    [SerializeField] int intellect;
    [SerializeField] int defence;
    [SerializeField] int spellguard;
    [SerializeField] int agility;
    [SerializeField] int luck;
    [SerializeField] int karma; //good things if you do good(less enemies, more items) bad things if you do bad(stronger enemies, more XP)
}

public enum MonsterType{
    //none,
    normal,
    nature,
    ghost,
    demon,
    undead,
    metal,
    aquatic,
    flying,
    dragon,
    nuclear,
    mythical
}
