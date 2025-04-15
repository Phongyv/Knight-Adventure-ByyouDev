using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;
    [SerializeField] private AudioSource jumpAudioSource;
    [SerializeField] private AudioSource coinAudioSource;
    [SerializeField] private AudioSource deadAudioSource;

    [SerializeField] private AudioClip backgroundClip;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip deadClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void PlayBackGroundMusic()
    {
        backgroundAudioSource.clip = backgroundClip;
        backgroundAudioSource.Play();
    }

    public void PlayJumpSound()
    {
        jumpAudioSource.clip = jumpClip;
        jumpAudioSource.Play();
    }
    public void PlayCoinSound()
    {
        coinAudioSource.clip = coinClip;
        coinAudioSource.Play();
    }

    public void PlayDeadSound()
    {
        deadAudioSource.clip = deadClip;
        deadAudioSource.Play();
    }

}
