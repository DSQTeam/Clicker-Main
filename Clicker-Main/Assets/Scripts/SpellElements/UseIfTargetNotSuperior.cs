using UnityEngine;

[CreateAssetMenu(fileName = "new SpellElement", menuName = "Custom/SpellElements/UseIfTargetNotSuperior")]
public class UseIfTargetNotSuperior : SpellElement
{
    [SerializeField] private SpellElement _element;

    public override void Apply()
    {
        if(Target.IsSuperior == false)
        {
            _element.Apply();
        }
    }
}
