using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    private GameObject content;
    private Slider effectsVolumeSlider;

    void Start()
    {
        Transform contentTransform = transform.Find("Content");
        content = contentTransform.gameObject;
        effectsVolumeSlider = contentTransform.Find("EffectsSlider").GetComponent<Slider>();
        GameState.effectsVolume = effectsVolumeSlider.value;
        Time.timeScale = content.activeInHierarchy ? 0.0f : 1.0f;
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = content.activeInHierarchy ? 1.0f : 0.0f;
            content.SetActive(!content.activeInHierarchy);

        }
    }
    public void OnEffectsVolumeChanged(Single value) => GameState.effectsVolume = value;
}