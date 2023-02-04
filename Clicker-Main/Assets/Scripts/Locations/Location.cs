using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Location", menuName = "Custom/Location")]
public class Location : ScriptableObject
{
    public static readonly int WavesPerLocation = 5;

    [SerializeField] private Sprite _icon;
    [SerializeField] private string _label;
    [SerializeField] private Sprite _background;
    [SerializeField] private AudioClip _music;
    [SerializeField] private Vector2 _enemyPosition;
    [SerializeField] private Vector2 _playerPosition;
    [SerializeField] private Vector2 _particleSystemPosition;
    [SerializeField] private EnemyStaticData _boss;
    [SerializeField] private Wave[] _waves;

    public Sprite Icon => _icon;
    public string Label => _label;
    public Sprite Background => _background;
    public AudioClip Music => _music;
    public EnemyStaticData Boss => _boss;
    public IReadOnlyList<Wave> Waves => _waves;
    public int Index { get; private set; }
    public Vector2 EnemyPosition => _enemyPosition;
    public Vector2 PlayerPosition => _playerPosition;

    public void SetIndex(int index)
    {
        Index = index;
    }
}
