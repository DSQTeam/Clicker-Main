using UnityEngine;

public class FlyingText : TextView
{
    private const float MIN_ALPHA = 0.2f;

    [SerializeField] private float _fadeSpeed;
    [SerializeField] private float _verticalSpeed;

    private float _startAlpha;

    private void Awake()
    {
        _startAlpha = Text.alpha;
    }

    private void OnEnable()
    {
        Text.alpha = _startAlpha;
    }

    public void Update()
    {
        transform.position = transform.position + Vector3.up * _verticalSpeed * Time.deltaTime;
        Text.alpha = Mathf.Lerp(Text.alpha, 0, _fadeSpeed * Time.deltaTime);

        if (Text.alpha <= MIN_ALPHA)
            Kill();
    }
}
