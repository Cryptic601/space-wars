using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
   public float lifetime = 1.0f; // set this tothe length of your explosion animation

   void ExplosionDone()
   {
    Destroy(gameObject, lifetime);
   }
}
