using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    #region Privates
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSettingsData audioSettingsData;
    [SerializeField] private Slider sliderMaster;
    [SerializeField] private Slider sliderMusic;
    [SerializeField] private Slider sliderSFX;
    public static AudioSettings Instance { get; private set; }//Singleton
    #endregion

    private void OnEnable()
    {
        if (sliderMaster == null)
            sliderMaster = GameObject.Find("SliderMaster")?.GetComponent<Slider>();

        if (sliderMusic == null)
            sliderMusic = GameObject.Find("SliderMusic")?.GetComponent<Slider>();

        if (sliderSFX == null)
            sliderSFX = GameObject.Find("SliderSFX")?.GetComponent<Slider>();
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //Cuando empiece se aplicaran los valores guardados
        Volumen(audioSettingsData.masterVolume);
        VolumenMusic(audioSettingsData.musicVolume);
        VolumenSFX(audioSettingsData.sfxVolume);
    }
    #region VoidVolume
    public void Volumen(float sliderValue)
    {
        
        audioMixer.SetFloat("SoundMaster", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.masterVolume = sliderValue;
        sliderMaster.value = sliderValue;
        PlayerPrefs.SetFloat("SoundMaster", sliderValue);

    }
    public void VolumenMusic(float sliderValue)
    {
        audioMixer.SetFloat("SoundMusic", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.musicVolume = sliderValue;
        sliderMusic.value = sliderValue;
        PlayerPrefs.SetFloat("SoundMusic", sliderValue);
    }
    public void VolumenSFX(float sliderValue)
    {
        audioMixer.SetFloat("SoundSFX", Mathf.Log10(sliderValue) * 20);
        audioSettingsData.sfxVolume = sliderValue;
        PlayerPrefs.SetFloat("SoundSFX", sliderValue);
        sliderSFX.value = sliderValue;
    }
    #endregion
}
