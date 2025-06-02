using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioMusicData", menuName = "AudioSettings/AudioMusicData", order = 2)]
public class AudioMusicData : ScriptableObject
{
    public AudioMixerGroup musicMixer;
    public AudioClip EndLevel;
    public AudioClip[] musicClip;
}
