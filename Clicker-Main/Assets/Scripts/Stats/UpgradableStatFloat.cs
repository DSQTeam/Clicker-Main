using System;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[Serializable]
public class UpgradableStatFloat : UpgradableStat
{
    private const int DIGITS_AFTER_POINT = 5;

    [FormerlySerializedAs("_currentValue")]
    [SerializeField] private float _value;

    public float Value => _value;

    public override void Spread(int maxSpreadPercent)
    {
         _value *= Random.Range(-maxSpreadPercent, maxSpreadPercent) / 100f;
        ClampAndRound();
    }

    public override void ChangeValue(float percentage, UpgradingAction upgradingAction)
    {
        float delta = _value * percentage;
        _value = upgradingAction == UpgradingAction.Increasing ? _value + delta : _value - delta;

        ClampAndRound();
    }

    public override string ToString() => _value.ToString();

    private void ClampAndRound()
    {
        _value = Mathf.Clamp(_value, UpgradingSettings.MinValue, UpgradingSettings.MaxValue);
        _value = (float)Math.Round(_value, DIGITS_AFTER_POINT);
    }
}
