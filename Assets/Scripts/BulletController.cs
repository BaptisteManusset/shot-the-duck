using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Target"))
    {
      this.transform.parent = collision.transform;
    }
  }
}
