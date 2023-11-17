using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  Vector2 moveInput;
  Rigidbody2D rb2d;
  [SerializeField] float runSpeed = 10f;
  IInteractibleObject lastCollidedObject;


  // Start is called before the first frame update
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    Run();
  }

  void OnMove(InputValue value)
  {
    moveInput = value.Get<Vector2>();
  }

  void Run()
  {
    Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, moveInput.y * runSpeed);
    rb2d.velocity = playerVelocity;
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.collider.GetComponent<IInteractibleObject>() != null)
      lastCollidedObject = other.collider.GetComponent<IInteractibleObject>();
  }

  private void OnCollisionExit2D(Collision2D other)
  {
    lastCollidedObject = null;
  }

  // private void OnCollisionStay2D(Collision2D other) {
  //   bool isInteractible = other.collider.GetComponent<IInteractibleObject>() != null;
  //   Debug.Log(Input.GetKeyDown("space"));
  //   if (Input.GetKeyDown("space") && isInteractible) {
  //       Debug.Log("ye");
  //       other.collider.GetComponent<IInteractibleObject>().Interact();
  //   }
  // }

  void OnAct()
  {
    if (lastCollidedObject != null)
    {
      lastCollidedObject.Interact();
    }
    // Check if collision detection sees player is next to tree
    // 'Shake' tree -> 
    //    tree visual shake fx, 
    //    fruit fall on ground
    // Pick up nearby fruit with Action
  }

  void OnMenu()
  {

  }

  void OnInventory()
  {

  }

}
