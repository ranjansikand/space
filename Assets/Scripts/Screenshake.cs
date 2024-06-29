// Plays screenshakes


using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Screenshake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseListener vcamListener;
    public UnityEvent smallShake;

    public static float shakeScaling = 1f;

    private void Start() {
        shakeScaling = PlayerPrefs.GetFloat("shake", 1f);
    }

    public void Play(float scale) {
        vcamListener.m_Gain = scale * shakeScaling;
        smallShake.Invoke();
    }
}