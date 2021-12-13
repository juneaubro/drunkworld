using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public AudioMixer audioMixerBG;
    public AudioMixer audioMixerMaster;

    public void SetVolumebackground(float volume)
    {
        audioMixerBG.SetFloat("BackgroundMusic", volume);

    }
    public void SetVolumeMaster(float volume)
    {
        audioMixerMaster.SetFloat("Master", volume);
    }
}
