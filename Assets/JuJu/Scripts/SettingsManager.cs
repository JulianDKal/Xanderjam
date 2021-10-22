using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    FMOD.Studio.VCA vcaMusic;
    FMOD.Studio.VCA vcaMaster;
    FMOD.Studio.VCA vcaSFX;

    private static float masterVolume = 1;
    private static float musicVolume = 1;
    private static float SFXVolume = 1;

    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider SFXSlider; 

    private void Start()
    {
        musicSlider.value = musicVolume;
        masterSlider.value = masterVolume;
        SFXSlider.value = SFXVolume;

        vcaMusic = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        vcaMaster = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        vcaSFX = FMODUnity.RuntimeManager.GetVCA("vca:/SFX");
    }


    List<int> widths = new List<int> { 1920, 1366, 1280};
    List<int> heights = new List<int> { 1080, 768, 800 };

    public void SetScreenSize(int resolutionIndex)
    {
        bool isFullScreen = Screen.fullScreen;
        int width = widths[resolutionIndex];
        int height = heights[resolutionIndex];
        Screen.SetResolution(width, height, isFullScreen);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetMusicVolume(float volume)
    {
        vcaMusic.setVolume(volume);
        musicVolume = volume;
    }

    public void SetMasterVolume(float volume)
    {
        vcaMaster.setVolume(volume);
        masterVolume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        vcaSFX.setVolume(volume);
        SFXVolume = volume;
    }
}
