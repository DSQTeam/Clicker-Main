using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/UseIfOwnerGetsDamage")]
public class UseIfOwnerGetsDamage : SpellElement
{
    [SerializeField] private SpellElement _element;
    [SerializeField] private float _duration;
    [SerializeField] private bool _disableOnTargetChanged;

    private Coroutine _disableTask;

    public override void Apply()
    {
        Owner.Health.DamageTaken += OnDamageTaken;
        Owner.TargetChanged += OnTargetChanged;

        _disableTask = CoroutineMaster.Instance.InvokeAfterDelay(DisableEffect, _duration);
    }

    private void OnTargetChanged(Combatant combatant)
    {
        if (_disableOnTargetChanged)
        {
            DisableEffect();
        }
    }

    private void OnDamageTaken(int damage, DamageType damageType)
    {
        _element.Apply();
    }

    private void DisableEffect()
    {
        if (_disableTask != null)
            CoroutineMaster.Instance.StopCoroutine(_disableTask);

        Owner.Health.DamageTaken -= OnDamageTaken;
        Owner.TargetChanged -= OnTargetChanged;
    }
}
