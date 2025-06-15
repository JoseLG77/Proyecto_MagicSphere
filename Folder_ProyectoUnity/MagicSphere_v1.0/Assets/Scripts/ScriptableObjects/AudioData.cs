using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "Audio Data", menuName = "AudioSettings/AudioData", order = 2)]
public class AudioData : ScriptableObject
{
    public AudioClip[] music;
    public AudioClip[] sfx;
}
