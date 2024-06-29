// Attached to the music

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    static AudioSource audioSource;
    static float _volume = 0.5f;

    public static float volume {
        get { return _volume; }
        set {
            _volume = value;
            audioSource.volume = _volume;
            PlayerPrefs.SetFloat("Music", _volume);
        }
    }

    private void Awake() {
        audioSource = GetComponent<AudioSource>();

        _volume = PlayerPrefs.GetFloat("Music", 0.25f);
    }
}
