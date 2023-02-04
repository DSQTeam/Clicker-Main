using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/StunWithChance")]
public class StunWithChance : SpellElement
{
    [SerializeField] private float _time;
    [Tooltip("0-100..")]
    [SerializeField] private int _chance;

    public override void Apply()
    {
        if (Random.Range(1, 100) < _chance)
        {
            Target.Stun();
            CoroutineMaster.Instance.InvokeAfterDelay(() => Target.UnStun(), _time);
        }
    }
}
