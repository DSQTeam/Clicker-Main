using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/UseWithChance")]
public class UseWithChance : SpellElement
{
    [Tooltip("0-100..")]
    [SerializeField] private int _chance;
    [SerializeField] private SpellElement _element;

    public override void Apply()
    {
        if(Random.Range(1, 100) < _chance)
        {
            _element.Apply();
        }
    }
}
