// Plays screenshakes


using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class Screenshake : MonoBehaviour
{
    [SerializeField] CinemachineImpulseListener vcamListener;
    public UnityEvent smallShake;



    /**** Eventual settings menu ****/
    // private void OnEnable() { Data.screenshakeChanged += UpdateScreenshake; }
    // private void OnDisable() { Data.screenshakeChanged -= UpdateScreenshake; }
    // private void UpdateScreenshake() { vcamListener.m_Gain = Data.Screenshake; }

    public void Play(float scale) {
        vcamListener.m_Gain = scale;
        smallShake.Invoke();
    }
}