using UnityEngine;
using System.Linq;

[System.Serializable]
public class Hands : BodyPartWithSpells
{
    [SerializeField] private BodyPartStatInt _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private BodyPartStatFloat _autoAttackCooldown;

    public int Damage => _damage.StatInt.Value;
    public DamageType DamageType => _damageType;
    public float AutoAttackCooldown => _autoAttackCooldown.StatFloat.Value;

    public override void SetStatNames()
    {
        base.SetStatNames();
        _damage.SetStatName(nameof(_damage));
        _autoAttackCooldown.SetStatName(nameof(_autoAttackCooldown));
    }

    public override string GetStatsLine()
    {
        return $"Damage: {_damage}\nAuto Attack CD: {_autoAttackCooldown}";
    }

    public void ChangeDamageType(DamageType damageType)
    {
        _damageType = damageType;
    }

    protected override BodyPartStat[] GetStats()
    {
        BodyPartStat[] baseStats = base.GetStats();
        BodyPartStat[] stats = new BodyPartStat[]
        {
            _damage,
            _autoAttackCooldown
        };


        return baseStats.Union(stats).ToArray();
    }
}
