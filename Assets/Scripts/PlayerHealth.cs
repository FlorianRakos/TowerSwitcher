using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healtPoints = 5;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip goalReachedSFX;

    void Start () {
        healthText.text = healtPoints.ToString();
    }

    private void OnTriggerEnter() {
        healtPoints = healtPoints - healthDecrease;
        healthText.text = healtPoints.ToString();
        GetComponent<AudioSource>().PlayOneShot(goalReachedSFX);
        
    }
    
}
