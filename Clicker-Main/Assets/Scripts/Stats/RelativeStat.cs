using System;
using UnityEngine;

[Serializable]
public class RelativeStat
{
    [SerializeField] private int _value;
    [SerializeField] private RelationType _relation;
    [SerializeField] private RelativeStatType _relativeTo;

    public int Value => _value;

    public int GetRelativeValue(Combatant target, Combatant owner)
    {
        return _relation == RelationType.Percentage
            ? SpellArgsProvider.Instance.GetRelativeValue(_value, _relativeTo, target, owner)
            : _value;
    }

    private enum RelationType
    {
        None,
        Percentage
    }
}
