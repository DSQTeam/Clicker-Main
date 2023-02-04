using System;
using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/UseIfTargetDied")]
public class UseIfTargetDied : SpellElement
{
    [SerializeField] private float _duration;
    [SerializeField] private SpellElement _element;

    private Health _targetHealth;

    public override void Apply()
    {
        _targetHealth = Target.Health;
        _targetHealth.Died += OnTargetDied;

        Action action = () =>
        {
            if (_targetHealth != null) 
                _targetHealth.Died -= OnTargetDied;
        };
        CoroutineMaster.Instance.InvokeAfterDelay(action, _duration);
    }

    private void OnTargetDied(Health targetHealth)
    {
        _targetHealth.Died -= OnTargetDied;
        _element.Apply();

        _targetHealth = null;
    }
}
