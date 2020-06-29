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
		screenToggle = GameObject.Find("Full Screen toggle");
        if (Screen.fullScreen)
        {
            screenToggle.GetComponent<Toggle>().isOn = true;
        }
		else {
            screenToggle.GetComponent<Toggle>().isOn = false;

			}
		PopulateDropDown();
    }

	private void PopulateDropDown(){
		resolutions = new List<string>(){
										Screen.currentResolution.width + "x" + Screen.currentResolution.height+"(current)",
										"1280x720", "1366x768", "1920x1080", "3840x2160"};

		dropDown.AddOptions(resolutions);
	}

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.fullScreen = false;
        }
    }
    public void SetResolution(int resolutionIndex){
 		switch (resolutionIndex) {
                case 1:
					Screen.SetResolution(1280, 720,Screen.fullScreen);
                    break;
                case 2:
					Screen.SetResolution(1366, 768,Screen.fullScreen);
                    break;
                case 3:
					Screen.SetResolution(1920,1080,Screen.fullScreen);
                    break;
                case 4:
					Screen.SetResolution(3840,2160,Screen.fullScreen);
                    break;
		}
	
    }
	
	public void FullScreenUpdate(bool fullScreen){
		Screen.fullScreen = fullScreen;
	}
}
