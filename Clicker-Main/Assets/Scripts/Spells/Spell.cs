using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Spell", menuName = "Custom/Spell")]
public class Spell : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private float _cooldown;
    [SerializeField] private int _manaCostInPercent;
    [SerializeField] private bool _needEnemyToUse;
    [SerializeField] private List<SpellElement> _spellElements;

    public int Id => _id;
    public float Cooldown => _cooldown;
    public float ManaCostInPercent => _manaCostInPercent;
    public Sprite Icon => _icon;
    public string Label => _label;
    public bool NeedEnemyToUse => _needEnemyToUse;

    public void Awake()
    {
        if (_id == 0)
            _id = GetInstanceID();
    }

    public void Apply()
    {
        for (int i = 0; i < _spellElements.Count; i++)
        {
            _spellElements[i].Apply();
        }
    }

    public void DestroyCreatedEntities()
    {
        foreach (SpellElement spellElement in _spellElements)
        {
            (spellElement as ICreateSpellEntity)?.DestroyEntity();
        }
    }

    public override bool Equals(object obj)
    {
        Spell otherSpell = obj as Spell;
        return otherSpell != null && otherSpell.Id == _id;
    }

    public override int GetHashCode()
    {
        return 1969571243 + _id.GetHashCode();
    }
}
