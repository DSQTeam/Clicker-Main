using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public abstract class BodyPartWithSpells : BodyPart, ISpellCollection
{
    [SerializeField] private List<Spell> _spells;

    [HideInInspector] [SerializeField]
    private List<Spell> _removedSpells;

    public IReadOnlyList<Spell> Spells => _spells;

    public void Add(Spell spell)
    {
        _spells.Add(spell);
    }

    public void Remove(Spell spell)
    {
        _spells.Remove(spell);
        _removedSpells.Add(spell);
    }

    public void AddRemoved(Spell spell)
    {
        int index = _removedSpells.IndexOf(spell);

        if (index == -1)
            return;

        _spells.Add(_removedSpells[index]);
        _removedSpells.RemoveAt(index);
    }

    public void DestroyCreatedSpellEntities()
    {
        foreach (Spell spell in _spells)
        {
            spell.DestroyCreatedEntities();
        }
    }
}
