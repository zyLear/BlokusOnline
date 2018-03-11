using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUIController : MonoBehaviour {

    public AudioClip AudioClipOne;
    public AudioClip AudioClipTwo;
    public AudioClip AudioClipThree;

    //public Toggle bgmOneToggle;
    //public Toggle bgmTwoToggle;
    //public Toggle bgmThreeToggle;

    public Slider slider;   
    public AudioSource audioSource;
    //public Toggle musicOn;


    public void onSliderChange() {
        audioSource.volume = slider.value;
    }

    public void onMusicSwitchOn(bool isOn) {
        //if (musicOn.isOn)// && !audioSource.isPlaying) {
        //    audioSource.Play();
        //}else if (audioSource.isPlaying) {
        //    audioSource.Stop();
        //}
        if (isOn) {
            audioSource.Play();
        }
    }

    public void onMusicSwitchOff(bool isOn) {
        if (isOn) {
            audioSource.Stop();
        }
    }

    public void onBgmOneChange(bool isOn) {
        if (isOn) {
            audioSource.clip = AudioClipOne;
            audioSource.Play();
        }
    }
    public void onBgmTwoChange(bool isOn) {
        if (isOn) {
            audioSource.clip = AudioClipTwo;
            audioSource.Play();
        }      
    }

    public void onBgmThreeChange(bool isOn) {
        if (isOn) {
            audioSource.clip = AudioClipThree;
            audioSource.Play();
        }
    }




    public void onQuit() {
        Application.Quit();
    }

    // Use this for initialization
    void Start() {
        //audioSource=GameCache
    }

    // Update is called once per frame
    void Update() {

    }
}
