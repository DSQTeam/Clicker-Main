using UnityEngine;

[CreateAssetMenu(fileName = "New Hands", menuName = "Custom/BodyParts/Hands")]
public class HandsContainer : BodyPartContainer
{
    [SerializeField] private Hands _hands;

    public override BodyPart Item => _hands;
}
