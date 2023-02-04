using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LootBox : MonoBehaviour
{
    [SerializeField] private float _openDelay = 0.7f;

    private BodyPart _loot;
    private Coroutine _task;

    public event Action<LootBox, BodyPart> Opened;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (_task != null)
            return;

        if (collision.transform.TryGetComponent(out Ground ground))
        {
            _task = CoroutineMaster.Instance.InvokeAfterDelay(Open, _openDelay);
        }
    }

    public void Init(BodyPart loot)
    {
        _loot = loot;
    }

    private void Open()
    {
        Opened?.Invoke(this, _loot);
        Destroy(gameObject);
    }
}
