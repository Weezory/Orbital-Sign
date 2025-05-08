using UnityEngine;

public class TRAPS : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.collider.GetComponent<PlayerController>()) {

            collision.collider.GetComponent<PlayerController>().die();

        }

    }

}