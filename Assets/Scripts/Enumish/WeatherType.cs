using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeatherType : ScriptableObject
{
  [Tooltip("The particle system triggered when the weather occurs")]
  [SerializeField] ParticleSystem weatherParticleSystem;
  [Tooltip("The value added to the temperature when this weather occurs")]
  [SerializeField] FloatReference tempModifier;
}

// FOR REFERENCE
// public class Elemental : MonoBehaviour
// {
//   [Tooltip("Element represented by this elemental.")]
//   public AttackElement Element;

//   [Tooltip("Text to fill in with the element name.")]
//   public Text Label;

//   private void OnEnable()
//   {
//     if (Label != null)
//       Label.text = Element.name;
//   }

//   private void OnTriggerEnter(Collider other)
//   {
//     Elemental e = other.gameObject.GetComponent<Elemental>();
//     if (e != null)
//     {
//       if (e.Element.DefeatedElements.Contains(Element))
//         Destroy(gameObject);
//     }
//   }
// }