using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/ChangePercentTargetArmor")]
public class ChangePercentTargetArmor : SpellElement
{
    [SerializeField] private int percent;
    [SerializeField] private float _duration;

    private int _basepercent = 0;
    private Combatant _combatant;

    public override void Apply()
    {
        _combatant = Target;
        _combatant.ChangePercentArmor(percent);

        Action action = () =>
        {
            if (_combatant != null)
            {
                _combatant.ChangePercentArmor(_basepercent);
            }
        };
        CoroutineMaster.Instance.InvokeAfterDelay(action, _duration);
    }
}
