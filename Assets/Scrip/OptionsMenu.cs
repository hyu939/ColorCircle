using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    //Resolution
    public Dropdown resolutionDropdown;
    int currentResolutionIndex;
    Resolution[] resolutions;

    //fullScreen
    public Toggle fullScreenTog;

    //Volume
    [SerializeField]public AudioMixer myMixer;
    [SerializeField]private Slider masterSlider, musicSlider, fxsSlider;

    void Start(){
        //Lấy kích thước và thêm vào options
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            currentResolutionIndex = PlayerPrefs.GetInt("currentResolutionIndex", i);
        }      

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        fullScreenTog.isOn = Screen.fullScreen;

        //Volume
        if(PlayerPrefs.HasKey("masterVolume")){
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetFxsVolume();
        }

    }

    //Set Resolution
    public void SetResolution (int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("currentResolutionIndex", resolutionIndex);
    }
    public void SetFullScreen (){
        Screen.fullScreen = fullScreenTog.isOn;
    }

    //Set Volume
    public void SetMasterVolume () {
        float vol = masterSlider.value;
        myMixer.SetFloat("masterVol", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("masterVolume", vol);
    }

    public void SetMusicVolume () {
        float vol = musicSlider.value;
        myMixer.SetFloat("musicVol", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("musicVolume", vol);
    }

    public void SetFxsVolume () {
        float vol = fxsSlider.value;
        myMixer.SetFloat("fxsVol", Mathf.Log10(vol)*20);
        PlayerPrefs.SetFloat("fxsVolume", vol);
    }

    //Load Volume
    private void LoadVolume(){
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        fxsSlider.value = PlayerPrefs.GetFloat("fxsVolume");
    }

}
