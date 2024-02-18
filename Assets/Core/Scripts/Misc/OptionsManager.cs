using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    public AudioMixer masterMixer;
    public AudioMixer musicMixer;
    public Slider musicSlider;
    public Slider masterSlider;


    private const string masterVolumeKey = "MasterVolume";
    private const string musicVolumeKey = "MusicVolume";

    private void Awake() {
        LoadSettings();
    }

    public void SetMasterVolume(float volume) {
        masterMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat(masterVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume) {
        musicMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat(musicVolumeKey, volume);
        PlayerPrefs.Save();
    }

    public void SetQuality(int qualityIndex) { QualitySettings.SetQualityLevel(qualityIndex); }

    private void LoadSettings() {
        if (PlayerPrefs.HasKey(masterVolumeKey)) {
            float masterVolume = PlayerPrefs.GetFloat(masterVolumeKey);
            SetMasterVolume(masterVolume);
            masterSlider.value = masterVolume;
        }
        if (PlayerPrefs.HasKey(musicVolumeKey)) {
            float musicVolume = PlayerPrefs.GetFloat(musicVolumeKey);
            SetMusicVolume(musicVolume);
            musicSlider.value = musicVolume;
        }
    }
}
