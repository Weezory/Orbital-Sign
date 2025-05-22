using System;
using UnityEngine;

public class TRAPS : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.collider.TryGetComponent(out PlayerController player)) {

            player.die();

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player)) {

            player.die();

        }
    }
}