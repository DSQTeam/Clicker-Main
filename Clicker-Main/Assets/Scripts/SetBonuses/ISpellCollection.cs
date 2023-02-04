using System.Collections.Generic;

public interface ISpellCollection
{
    IReadOnlyList<Spell> Spells { get; }

    void Add(Spell spell);

    void Remove(Spell spell);

    void AddRemoved(Spell spell);

    void DestroyCreatedSpellEntities();
}
