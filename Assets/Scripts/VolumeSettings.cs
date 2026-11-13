using UnityEngine;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{

    [SerializeField]private AudioMixer mixer;


//The SetFloat() method modifies an exposed mixer parameter,
//which operates in decibels (dB)—a logarithmic scale where 0 dB corresponds
//to the original volume and -80 dB to silence. The calculation using Mathf.Log10()
//converts a slider value—ranging from 0.0001 to 1—into this scale.
// The minimum slider value cannot be 0 because the logarithm of 0 (Mathf.Log10(0)) is mathematically undefined
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20f);
    }

    public void SetSfxVolume(float value)
     { 
        mixer.SetFloat("SFXVolume", Mathf.Log10(value) * 20f);
     }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
