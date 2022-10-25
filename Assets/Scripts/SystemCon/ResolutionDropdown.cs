using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdown : MonoBehaviour
{
    [Header("解像度選択用")]
    [SerializeField]
    Dropdown dropdown;
    List<Resolution> resolutions = new();

    [Header("フルスクリーン")]
    [SerializeField]
    Toggle toggle;



    void Start()
    {
        SetDropdown();
    }
    void SetDropdown()
    {
        resolutions.Clear();
        dropdown.ClearOptions();
        int currentIndex = 0;
        List<string> options = new();
        Resolution resolution;
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].width == Screen.width && Screen.resolutions[i].height == Screen.height)
            {
                currentIndex = i;
            }
            resolution = new();
            resolution.width = Screen.resolutions[i].width;
            resolution.height = Screen.resolutions[i].height;
            resolutions.Add(resolution);
            options.Add(Screen.resolutions[i].width.ToString() + "x" + Screen.resolutions[i].height.ToString());
        }
        dropdown.AddOptions(options);
        dropdown.value = currentIndex;
        dropdown.onValueChanged.AddListener((x) => SetResolution(resolutions[x]));
    }
    void SetResolution(Resolution resolution)
    {
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    sealed class Resolution
    {
        public int width;
        public int height;
    }
}
