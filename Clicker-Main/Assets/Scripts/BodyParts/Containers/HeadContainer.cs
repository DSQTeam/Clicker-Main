using UnityEngine;

[CreateAssetMenu(fileName = "New Head", menuName = "Custom/BodyParts/Head")]
public class HeadContainer : BodyPartContainer
{
    [SerializeField] private Head _head;

    public override BodyPart Item => _head;
}
