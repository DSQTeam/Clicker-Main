using System;
using UnityEngine;

[Serializable]
public class UpgradingSettings
{
    [Range(0, 6)] 
    public float UpgradingPercent;
    public UpgradingAction UpgradingAction;
    public float MaxValue;
    public float MinValue;

    public UpgradingAction DowngradingAction => UpgradingAction == UpgradingAction.Increasing
        ? UpgradingAction.Decreasing
        : UpgradingAction.Increasing;
}
