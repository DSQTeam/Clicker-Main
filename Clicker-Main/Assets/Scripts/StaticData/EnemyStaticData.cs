using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Custom/Enemy")]
public class EnemyStaticData : ScriptableObject
{
    public int MaxHealth;
    public int Damage;
    public DamageType DamageType;
    public int CritDamageInPercent;
    public int CritChance;
    public int Armor;
    public int DodgeChance;
    public float AttackCooldown;
    public float AttackCooldownSpread;
    public Spell[] AttackModifiers;
    public int ManaRegen;
    public int MaxMana;
    public Loot Loot;
    public Combatant Prefab;
}
