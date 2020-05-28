using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int healtPoints = 5;
    [SerializeField] int healthDecrease = 1;

    private void OnTriggerEnter() {
        print("triggered");
        healtPoints = healtPoints - healthDecrease;
    }
    
}
