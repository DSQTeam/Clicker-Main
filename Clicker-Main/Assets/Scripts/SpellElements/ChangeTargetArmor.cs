using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/ChangeTargetArmor")]
public class ChangeTargetArmor : SpellElement
{
    [SerializeField] private int _newArmor;
    [SerializeField] private float _duration;

    private int _oldValue;
    private Combatant _combatant;

    public override void Apply()
    {
        _combatant = Target;
        _oldValue = _combatant.Armor;
        _combatant.ChangeArmor(_newArmor);

        Action action = () =>
        {
            if (_combatant != null)
            {
                _combatant.ChangeArmor(_oldValue);
            }
        };
        CoroutineMaster.Instance.InvokeAfterDelay(action, _duration);
    }
}
