using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private bool _sfxMuted = false;
    private bool _musicMuted = false;
    private bool _masterMuted = false;


    public void SetMasterVolume(float level) //same procedure for sfx or music possible
    {
        //audioMixer.SetFloat("MasterVolume", level); //der exposed Mixer aus dem AudioMixer Fenster
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f); //mit der Sound linear leiser/lauter wird
    }
    public void ToggleMaster()
    {
        if (_sfxMuted)
        {
            audioMixer.ClearFloat("MasterVolume"); //clearfloat setzt auf den vorigen wert zurück
            _masterMuted = false;
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", -80); //-80 entspricht quasi mute
            _masterMuted = true;
        }

        
    }
    public void ToggleSFX()
    {
        if (_sfxMuted)
        {
            audioMixer.ClearFloat("SFXVolume"); //clearfloat setzt auf den vorigen wert zurück
            _sfxMuted = false;
        }
        else
        {
           audioMixer.SetFloat("SFXVolume", -80); //-80 entspricht quasi mute
           _sfxMuted = true;
        }

        
    }

    public void ToggleMusic()
    {
        if (_musicMuted)
        {
            audioMixer.ClearFloat("MusicVolume");
            _musicMuted = false;
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", -80);
            _musicMuted = true;
        }
    }

}
