using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    private AudioClip _previous;
    private int _previousPosition;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Pause()
    {
        _audioSource.Pause();
    }

    public void Stop()
    {
        _audioSource.Stop();
    }

    public void ChangeClip(AudioClip next)
    {
        if (next == _audioSource.clip)
            return;

        _previousPosition = _audioSource.timeSamples;
        Stop();
        _previous = _audioSource.clip;
        _audioSource.clip = next;
        _audioSource.timeSamples = 0;

        Play();
    }

    public void ChangeClip(AudioClip next, int position)
    {
        if (next == _audioSource.clip)
            return;

        _previousPosition = _audioSource.timeSamples;
        Stop();
        _previous = _audioSource.clip;
        _audioSource.clip = next;
        _audioSource.timeSamples = position;
        Play();
    }

    public void ContinuePreviousClip()
    {
        if (_previous == null)
            _previous = _audioSource.clip;

        ChangeClip(_previous, _previousPosition);
    }
}
