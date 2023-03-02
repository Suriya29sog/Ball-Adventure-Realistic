using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Setting settingPreset;

    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _SFXToggle;

    // Start is called before the first frame update
    void Awake()
    {
        _musicToggle.isOn = settingPreset.musicOn;
        _SFXToggle.isOn = settingPreset.SFXOn;

        OnMusicToggle();
        OnSFXToggle();
    }


    public void OnMusicToggle ()
    {
        if (_musicToggle.isOn)
            settingPreset.AudioMixer.SetFloat("MusicVolume", 0f);
        else
            settingPreset.AudioMixer.SetFloat("MusicVolume", -80f);

        settingPreset.musicOn = _musicToggle.isOn;

    }

    public void OnSFXToggle ()
    {
        if (_SFXToggle.isOn)
            settingPreset.AudioMixer.SetFloat("SFXVolume", 0f);
        else
            settingPreset.AudioMixer.SetFloat("SFXVolume", -80f);

        settingPreset.SFXOn = _SFXToggle.isOn;
    }

}
