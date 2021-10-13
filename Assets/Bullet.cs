using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);
        Vector3 pos = contact.point;
        GameObject effect = Instantiate(hitEffect, pos, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
