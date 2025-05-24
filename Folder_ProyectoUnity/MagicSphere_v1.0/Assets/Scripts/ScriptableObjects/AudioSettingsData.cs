using UnityEngine;

[CreateAssetMenu(fileName = "AudioSettingsData", menuName = "ScriptableObjects/AudioSettingsData", order = 1)]
public class AudioSettingsData : ScriptableObject
{
    [Range(0.0001f, 1f)] public float masterVolume = 0.75f;
    [Range(0.0001f, 1f)] public float musicVolume = 0.75f;
    [Range(0.0001f, 1f)] public float sfxVolume = 0.75f;
}