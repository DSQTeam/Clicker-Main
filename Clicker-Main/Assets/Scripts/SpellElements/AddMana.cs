using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/AddMana")]
public class AddMana : SpellElement
{
    [SerializeField] private float _percentage;

    public override void Apply()
    {
        Mana mana = Owner.SpellUser.Mana;
        mana.Add(Mathf.RoundToInt(mana.MaxValue * _percentage / 100f));
    }
}
