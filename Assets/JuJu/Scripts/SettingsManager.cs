using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
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
}
