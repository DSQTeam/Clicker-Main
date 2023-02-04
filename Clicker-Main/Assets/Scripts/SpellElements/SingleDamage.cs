using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/SingleDamage")]
public class SingleDamage : SpellElement
{
    [SerializeField] private RelativeStat _damage;
    [SerializeField] private DamageType _damageType;

    public override void Apply()
    {
        Target.TakeDamage(_damage.GetRelativeValue(Target, Owner), _damageType);
    }
}