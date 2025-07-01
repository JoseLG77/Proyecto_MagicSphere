using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource AudioMusic;
    [SerializeField] private AudioSource AudioSFX;
    
    [Header("Audio Clip")]
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioClip[] sfx;

    [SerializeField] private AudioData audioData;

    private int currentIndex = 0;
    private void Awake()
    {
        for (int i = 0; i < music.Length; i++)
        {
            if (music[i] == null)
            {
                music[i] = audioData.music[i];
            }
        }
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfx[i] == null)
            {
                sfx[i] = audioData.sfx[i];
            }
        }
    }
    private void Start()
    {
        PlaySound(currentIndex);
    }
    private void Update()
    {
        if (!AudioMusic.isPlaying && music != null)//Si no se esta reproduciendo musica, y la lista musica no esta vacia que se reproduzca la siquiente
        {
            currentIndex += 1;
            if (currentIndex >= music.Length)
                currentIndex = 0;
            PlaySound(currentIndex);
        }
    }
    #region Methods
    private void PlayAudioSFX(AudioClip SFX)
    {
        AudioSFX.PlayOneShot(SFX);
    }
    public void PlaySound(int index)
    {
        AudioMusic.clip = music[index];
        AudioMusic.Play();
    }
    #endregion
}
