using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/Healing")]
public class Healing : SpellElement
{
    [Header("To owner health")]
    [SerializeField] private RelativeStat _amount;

    public override void Apply()
    {
        Owner.Health.Heal(_amount.GetRelativeValue(Target, Owner));
    }
}