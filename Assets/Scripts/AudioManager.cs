using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public InputActionProperty RshowMenu;
    public InputActionProperty LshowMenu;
	
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] GameObject volumeCanvas;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TextMeshProUGUI masterVolumeText;
    [SerializeField] TextMeshProUGUI musicVolumeText;
    [SerializeField] TextMeshProUGUI sfxVolumeText;


    // Start is called before the first frame update
    void Start()
    {
        //Canvas deactivate
        deactivateMenu();

        //load saved Volume
	masterSlider.value = 1 ;
	musicSlider.value = 1;
	sfxSlider.value = 1;
        loadVolume();
    }

    // Update is called once per frame
    void Update()
    {
        if (RshowMenu.action.WasPressedThisFrame() || LshowMenu.action.WasPressedThisFrame())
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (volumeCanvas != null)
        {
            volumeCanvas.SetActive(!volumeCanvas.activeSelf);
        }
        else
        {
            Debug.LogError("Canvas object reference is not set!");
        }

    }
    public void deactivateMenu()
    {
        if (volumeCanvas != null)
        {
            volumeCanvas.SetActive(false);
            updateVolume();
        }
        else
        {
            Debug.LogError("Canvas object reference is not set!");
        }

    }

    private void loadVolume()
    {
	float volumeValue = 0f ;
	if(PlayerPrefs.HasKey("masterVolume")){
       	   volumeValue = PlayerPrefs.GetFloat("masterVolume");
	   masterSlider.value = volumeValue;
	}else{
	   volumeValue = masterSlider.value; 	
        }
        masterVolumeText.text = volumeValue.ToString("0.0");
        audioMixer.SetFloat("master", Mathf.Log10(volumeValue)*20);

	if(PlayerPrefs.HasKey("musicVolume")){
           volumeValue = PlayerPrefs.GetFloat("musicVolume");
	   musicSlider.value = volumeValue;
	}else{
	   volumeValue = musicSlider.value;
	}
        musicVolumeText.text = volumeValue.ToString("0.0");
        audioMixer.SetFloat("music", Mathf.Log10(volumeValue)*20);

	if(PlayerPrefs.HasKey("sfxVolume")){
           volumeValue = PlayerPrefs.GetFloat("sfxVolume");
	   sfxSlider.value = volumeValue;
	}else{
	   volumeValue = sfxSlider.value;	
        }
        sfxVolumeText.text = volumeValue.ToString("0.0");
        audioMixer.SetFloat("sfx", Mathf.Log10(volumeValue)*20);
    }

    public void updateVolume()
    {
        float volumeValue = masterSlider.value;
        masterVolumeText.text=volumeValue.ToString("0.0");
        audioMixer.SetFloat("master", Mathf.Log10(volumeValue)*20);
        PlayerPrefs.SetFloat("masterVolume",volumeValue);

        volumeValue = musicSlider.value;
        musicVolumeText.text = volumeValue.ToString("0.0");
        audioMixer.SetFloat("music", Mathf.Log10(volumeValue)*20);
        PlayerPrefs.SetFloat("musicVolume", volumeValue);

        volumeValue = sfxSlider.value;
        sfxVolumeText.text = volumeValue.ToString("0.0");
        audioMixer.SetFloat("sfx", Mathf.Log10(volumeValue)*20);
        PlayerPrefs.SetFloat("sfxVolume", volumeValue);


    }
}
