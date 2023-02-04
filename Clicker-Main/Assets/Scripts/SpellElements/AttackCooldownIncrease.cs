using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/AttackCooldownIncrease")]
public class AttackCooldownIncrease : SpellElement
{
    [SerializeField] private int _percent;
    [SerializeField] private float _duration;

    public override void Apply()
    {
        Target.AutoAttacker.IncreaseAttackCooldown(_percent);

        Action action = () => Target?.AutoAttacker.IncreaseAttackCooldown(-_percent);
        CoroutineMaster.Instance.InvokeAfterDelay(action, _duration);
    }
}