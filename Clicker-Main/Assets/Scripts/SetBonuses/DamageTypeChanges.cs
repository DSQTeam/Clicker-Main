using UnityEngine;

[CreateAssetMenu(fileName = "New DamageTypeChanges", menuName = "Custom/Bonuses/DamageTypeChanges")]
public class DamageTypeChanges : Bonus
{
    [SerializeField] private DamageType _newDamageType;

    private Hands _target;
    private DamageType _previousDamageType;

    public override void DisableOn(Body body)
    {
        if(_target != null)
        {
            _target.ChangeDamageType(_previousDamageType);
        }
    }

    public override void EnableOn(Body body)
    {
        _target = body.Hands;
        _previousDamageType = _target.DamageType;
        _target.ChangeDamageType(_newDamageType);
    }
}
