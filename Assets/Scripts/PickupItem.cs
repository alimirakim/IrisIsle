using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
  // stretch goal: on trigger area (player has magnet sphere zone) the item goes toward player
  
  // on trigger contact, sfx plays, player 'gets' item, and item is destroyed
  
  [SerializeField] AudioClip pickupSFX;
    
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.tag == "Player") {
        // TODO find way to play sound from other source so it doesn't cut from destroy
        GetComponent<AudioSource>().PlayOneShot(pickupSFX);
        Destroy(gameObject);
      }
    }
}
