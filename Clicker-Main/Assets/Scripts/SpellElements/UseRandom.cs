using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/UseRandom")]
public class UseRandom : SpellElement
{
    [SerializeField] private SpellElement[] _elements;

    public override void Apply()
    {
        int index = Random.Range(0, _elements.Length);
        _elements[index].Apply();
    }
}
