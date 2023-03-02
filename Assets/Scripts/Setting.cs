using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "SettingsPreset", fileName = "SettingsPreset")]
public class Setting : ScriptableObject
{
    public AudioMixer AudioMixer;

    public bool musicOn = true;
    public bool SFXOn = true;

    private void Awake()
    {
        LoadSetting();
    }

    public void LoadSetting()
    {
        if (musicOn)
            AudioMixer.SetFloat("MusicVolume", 0f);
        else
            AudioMixer.SetFloat("MusicVolume", -80f);

        if (SFXOn)
            AudioMixer.SetFloat("SFXVolume", 0f);
        else
            AudioMixer.SetFloat("SFXVolume", -80f);
    }


}
