using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour {
    public bool loopCurrentSong;
    
    [SerializeField] private AudioClip[] music;

    private AudioSource _source;
    private short _currentMusicIndex;

    private const string VolumeKey = "Volume";

    private void Start(){
        _source.volume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
    }

    private void Update(){
        if (Input.GetKey(KeyCode.Period)) {
            IncreaseVolume();
        }

        if (Input.GetKey(KeyCode.Comma)) {
            DecreaseVolume();
        }
        
        if (!_source.isPlaying) {
            if (loopCurrentSong) {
                _source.Play();
            }
            else {
                _currentMusicIndex++;
                if (_currentMusicIndex >= music.Length) {
                    _currentMusicIndex = 0;
                    _source.Play();
                }
            }
        }
    }

    void IncreaseVolume(){
        _source.volume += 0.005f;
        PlayerPrefs.SetFloat(VolumeKey, _source.volume);
    }

    void DecreaseVolume(){
        _source.volume -= 0.005f;
        PlayerPrefs.SetFloat(VolumeKey, _source.volume);
    }

    public void PlaySpecificSongInLoop(AudioClip clip){
        loopCurrentSong = true;
        _source.clip = clip;
        _source.Play();
    }

    public void StopPlaying(){
        _source.Stop();
    }
}
