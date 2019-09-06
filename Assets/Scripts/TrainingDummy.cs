using System;
using UnityEngine;

public class TrainingDummy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TOCHED");
    }
}
