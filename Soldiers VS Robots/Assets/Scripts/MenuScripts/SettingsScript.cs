using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsScript : MonoBehaviour
{
	private GameObject screenToggle;
	private static string currentResolution = "";
    [SerializeField] private AudioMixer audioMixer;
	[SerializeField] private TMP_Dropdown dropDown;
	
	[SerializeField] private TMP_Text currentResolutionText;

	

	public void Start()
    {
		screenToggle = GameObject.Find(GameConstants.fullScreenToggle);
		UpdateCurrentRosolutionText();

		if (Screen.fullScreen)
        {
            screenToggle.GetComponent<Toggle>().isOn = true;
        }
		else 
        {
	        screenToggle.GetComponent<Toggle>().isOn = false;

	    }
        dropDown.AddOptions(new List<string>(){GameConstants.resolutionDropDownLebal, GameConstants.resolutionLow, GameConstants.resolutionMedium,
	        GameConstants.resolutionRegular, GameConstants.resolutionHigh});
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
	                currentResolution = GameConstants.resolutionLow;
	                break;
                case 2:
	                Screen.SetResolution(GameConstants.resolutionMediumWidth, GameConstants.resolutionMediumHeight,Screen.fullScreen);
	                currentResolution = GameConstants.resolutionMedium;
	                break;
                case 3:
	                Screen.SetResolution(GameConstants.resolutionRegularWidth,GameConstants.resolutionRegularHeight,Screen.fullScreen);
	                currentResolution = GameConstants.resolutionRegular;
	                break;
                case 4:
	                Screen.SetResolution(GameConstants.resolutionHighWidth,GameConstants.resolutionHighHeight,Screen.fullScreen);
	                currentResolution = GameConstants.resolutionHigh;
	                break;

        }

        UpdateCurrentRosolutionText();

    }

    public void UpdateCurrentRosolutionText()
    {
	    if ( currentResolution == "")
	    {
		    currentResolutionText.text = GameConstants.currentResolutionDefault;
	    }
	    else
	    {
		    currentResolutionText.text = GameConstants.currentResolutionHeader + currentResolution;

	    }
    }
	public void FullScreenUpdate(bool fullScreen)
	{
		Screen.fullScreen = fullScreen;
	}
}
