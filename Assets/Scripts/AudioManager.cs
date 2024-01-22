using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public InputActionProperty RshowMenu;
    public InputActionProperty LshowMenu;

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
        float volumeValue = PlayerPrefs.GetFloat("masterVolume");
        masterSlider.value = volumeValue;
        masterVolumeText.text = volumeValue.ToString();
        audioMixer.SetFloat("master", volumeValue);

        volumeValue = PlayerPrefs.GetFloat("musicVolume");
        musicSlider.value = volumeValue;
        musicVolumeText.text = volumeValue.ToString();
        audioMixer.SetFloat("music", volumeValue);

        volumeValue = PlayerPrefs.GetFloat("sfxVolume");
        sfxSlider.value = volumeValue;
        sfxVolumeText.text = volumeValue.ToString();
        audioMixer.SetFloat("sfx", volumeValue);
    }

    public void updateVolume()
    {
        float volumeValue = masterSlider.value;
        masterVolumeText.text=volumeValue.ToString();
        audioMixer.SetFloat("master", volumeValue);
        PlayerPrefs.SetFloat("masterVolume",volumeValue);

        volumeValue = musicSlider.value;
        musicVolumeText.text = volumeValue.ToString();
        audioMixer.SetFloat("music", volumeValue);
        PlayerPrefs.SetFloat("musicVolume", volumeValue);

        volumeValue = sfxSlider.value;
        sfxVolumeText.text = volumeValue.ToString();
        audioMixer.SetFloat("sfx", volumeValue);
        PlayerPrefs.SetFloat("sfxVolume", volumeValue);


    }
}
