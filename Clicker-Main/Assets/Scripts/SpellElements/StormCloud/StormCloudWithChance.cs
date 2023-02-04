using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/StormCloudWithChance")]
public class StormCloudWithChance : SpellElement, ICreateSpellEntity
{
    [SerializeField] private RelativeStat _damage;
    [SerializeField] private DamageType _damageType;
    [SerializeField] private float _attackInterval;
    [SerializeField] private int _tickCount;
    [SerializeField] private float _reloadDelay;
    [SerializeField] private int _chance;
    [SerializeField] private Vector3 _offset;

    private StormCloud _entity;

    public override void Apply()
    {
        if (Random.Range(1, 100) < _chance == false)
            return;

        if (_entity == null)
        {
            _entity = SpellArgsProvider.Instance.GameFactory.CreateStormCloud(Target.transform.position + _offset);
        }
        else if (_entity.Reloaded == false)
        {
            return;
        }

        _entity.Init(Owner, _damage, _damageType, _attackInterval, _tickCount, _reloadDelay);
        _entity.StartAttacking();
    }

    public void DestroyEntity()
    {
        if (_entity == null)
            return;

        Destroy(_entity);
    }
}
