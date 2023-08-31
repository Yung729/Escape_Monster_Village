using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Potions"))
        {
            Destroy(collision.gameObject);
        }
    
    }

}
