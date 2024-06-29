// Script that monitors the time and ends game if the mothership doesn't
// have the required funds


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeKeeper : MonoBehaviour
{
    public float turnTime = 60f;  // 
    float timeRemaining;
    int rentDue = 10;

    int score = 0;

    [SerializeField] Mothership mothership;

    [SerializeField] TMP_Text timeCounter, rentalPayment, scoreCounter;

    [SerializeField] Rigidbody2D astronautPrefab;

    [SerializeField] AudioClip timesUp;

    private void Start() {
        StartCoroutine(KeepTime());
    }


    IEnumerator KeepTime() {
        bool gameOver = false;

        while (!gameOver) {
            rentalPayment.text = rentDue.ToString();
            yield return Countdown();

            if (mothership.storedOre >= rentDue) {
                Debug.Log("Afforded!");
                mothership.storedOre -= rentDue;
                rentDue += 10;
                score += 1;
                scoreCounter.text = score.ToString();
            } else {
                gameOver = true;
                mothership.audioSource.PlayOneShot(timesUp, PlayerData.maxSFXVolume);
            }
        }

        // Instantiate astronaut
        Rigidbody2D astronaut = Instantiate(astronautPrefab, PlayerData.controller.transform.position, Quaternion.identity);
        astronaut.AddForce(Random.insideUnitCircle, ForceMode2D.Impulse);
        astronaut.AddTorque(0.05f);

        if (score > PlayerPrefs.GetInt("high", 0)) PlayerPrefs.SetInt("high", score);

        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene("Title");
    }

    IEnumerator Countdown() {
        timeRemaining = turnTime;

        while (timeRemaining > 0) {
            timeCounter.text = timeRemaining.ToString("00.00");
            yield return PlayerData.updateCheck;
            timeRemaining -= 0.1f;
        }

        timeCounter.text = "00.00";
    }
}
