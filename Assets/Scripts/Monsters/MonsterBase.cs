//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu(fileName = "Monster", menuName = "Monster/Create new monster")]
//public class MonsterBase : ScriptableObject //vergelijkbaar met een extend of interface. Je kan er van afwijken
//{
//    [SerializeField] string name;
//    [TextArea]
//    //[SerializeField] string description;
//    [SerializeField] Sprite battleSprite; //sidesprite
//    [SerializeField] Sprite defeatedSprite;

//    //mogelijk meer dan 1 type maken
//    [SerializeField] MonsterType type1;
//    //[SerializeField] MonsterType type2;

//    //Stats
//    [SerializeField] int maxHP;
//    [SerializeField] int currentHP;
//    [SerializeField] int attack;
//    [SerializeField] int strength;
//    [SerializeField] int intellect;
//    [SerializeField] int defence;
//    [SerializeField] int spellguard;
//    [SerializeField] int agility;
//    [SerializeField] int luck;
//    [SerializeField] int karma; //good things if you do good(less enemies, more items) bad things if you do bad(stronger enemies, more XP)


//    public string GetName()
//    {
//        return name;
//    }

//    public string Name
//    {
//        get { return name; }
//        set { name = value; }
//    }

//    public Sprite BattleSprite
//    {
//        get { return battleSprite; }
//        set { battleSprite = value; }
//    }

//    public Sprite DefeatedSprite
//    {
//        get { return defeatedSprite; }
//        set { defeatedSprite = value; }
//    }

//    public MonsterType Type1
//    {
//        get { return type1; }
//        set { type1 = value; }
//    }

//    public int MaxHP
//    {
//        get { return maxHP; }
//        set { maxHP = value; }
//    }

//    public int CurrentHP
//    {
//        get { return currentHP; }
//        set { currentHP = value; }
//    }

//    public int Attack
//    {
//        get { return attack; }
//        set { attack = value; }
//    }

//    public int Strength
//    {
//        get { return strength; }
//        set { strength = value; }
//    }

//    public int Intellect
//    {
//        get { return intellect; }
//        set { intellect = value; }
//    }

//    public int Defence
//    {
//        get { return defence; }
//        set { defence = value; }
//    }

//    public int SpellGuard
//    {
//        get { return spellguard; }
//        set { spellguard = value; }
//    }

//    public int Agility
//    {
//        get { return agility; }
//        set { agility = value; }
//    }

//    public int Luck
//    {
//        get { return luck; }
//        set { luck = value; }
//    }

//    public int Karma
//    {
//        get { return karma; }
//        set { karma = value; }
//    }
//}
//public enum MonsterType{
//    //none,
//    normal,
//    nature,
//    ghost,
//    demon,
//    undead,
//    metal,
//    aquatic,
//    flying,
//    dragon,
//    nuclear,
//    mythical
//}

using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public string name;
    public int maxHP = 5;
    public int currentHP = 5;
    public int attack = 5;
    public int strength = 5;
    public int intellect = 5;
    public int defence = 5;
    public int spellguard = 5;
    public int agility = 5;
    public int luck = 5;
    public int karma = 5;


    public virtual void Attack()
    {
        // Implement attack logic here
    }

    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Implement death logic here
        Destroy(gameObject);
    }
}
