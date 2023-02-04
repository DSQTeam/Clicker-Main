using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/CPSRelativeDamageModifier")]
public class CPSRelativeDamageModifier : SpellElement
{
    [SerializeField] private int _percentage;
    [SerializeField] private int _maxRewardedCPS;
    [SerializeField] private int _minRewardedCPS;

    public override void Apply()
    {
        int cps = SpellArgsProvider.Instance.AttackListener.ClicksPerSecond;
        int rewardedClicks = Mathf.Clamp((cps - _minRewardedCPS) + 1, 0, _maxRewardedCPS - _minRewardedCPS);
        int damage = Mathf.CeilToInt((Owner.Damage * _percentage / 100f) * rewardedClicks);

        Owner.IncreaseDamage(damage);
    }
}
