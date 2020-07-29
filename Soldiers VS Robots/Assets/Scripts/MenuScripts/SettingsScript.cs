using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsScript : MonoBehaviour
{
	private GameObject screenToggle;
    [SerializeField] private AudioMixer audioMixer;
	[SerializeField] private TMP_Dropdown dropDown;
	private List<string> resolutions;

    public void Start()
    {
		screenToggle = GameObject.Find(GameConstants.fullScreenToggle);
        if (Screen.fullScreen)
        {
            screenToggle.GetComponent<Toggle>().isOn = true;
        }
		else 
        {
	        screenToggle.GetComponent<Toggle>().isOn = false;

	    }
		PopulateDropDown();
    }

	private void PopulateDropDown()
	{
		string currentResulutionString = Screen.currentResolution.width + "x" + Screen.currentResolution.height + "(current)";
		
		resolutions = new List<string>(){currentResulutionString, GameConstants.resolutionLow, GameConstants.resolutionMedium,
										GameConstants.resolutionRegular, GameConstants.resolutionHigh};

		dropDown.AddOptions(resolutions);
	}

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(GameConstants.volume, volume);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Screen.fullScreen = false;
        }
    }
    public void SetResolution(int resolutionIndex)
    {
 		switch (resolutionIndex) 
        {
                case 1:
					Screen.SetResolution(GameConstants.resolutionLowWidth, GameConstants.resolutionLowHeight,Screen.fullScreen);
                    break;
                case 2:
					Screen.SetResolution(GameConstants.resolutionMediumWidth, GameConstants.resolutionMediumHeight,Screen.fullScreen);
                    break;
                case 3:
					Screen.SetResolution(GameConstants.resolutionRegularWidth,GameConstants.resolutionRegularHeight,Screen.fullScreen);
                    break;
                case 4:
					Screen.SetResolution(GameConstants.resolutionHighWidth,GameConstants.resolutionHighHeight,Screen.fullScreen);
                    break;
		}
	
    }
	
	public void FullScreenUpdate(bool fullScreen)
	{
		Screen.fullScreen = fullScreen;
	}
}
