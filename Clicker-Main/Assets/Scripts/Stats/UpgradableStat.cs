using UnityEngine;

[System.Serializable]
public abstract class UpgradableStat
{
    [SerializeField] protected UpgradingSettings UpgradingSettings;

    public void Upgrade() => ChangeValue(UpgradingSettings.UpgradingPercent, UpgradingSettings.UpgradingAction);

    public void Downgrade() => ChangeValue(UpgradingSettings.UpgradingPercent, UpgradingSettings.DowngradingAction);

    public abstract void Spread(int maxSpreadPercent);

    public abstract void ChangeValue(float percentage, UpgradingAction upgradingAction);
}
