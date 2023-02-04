using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/SingleDamageInRange")]
public class SingleDamageInRange : SpellElement
{
    [SerializeField] private RelativeStat _damage;
    [SerializeField] private DamageType _damageType;
    [Tooltip("0-100..")]
    [SerializeField] private float _spread;

    public override void Apply()
    {
        int damage = _damage.GetRelativeValue(Target, Owner);
        int min = Mathf.RoundToInt(damage - damage * _spread / 100f);
        int max = Mathf.RoundToInt(damage + damage * _spread / 100f);
        damage = Random.Range(min, max);

        Target.TakeDamage(damage, _damageType);
    }
}
