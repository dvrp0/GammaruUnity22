using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    public float Speed;

    private void Start()
    {
        StartCoroutine(Move());
    }

    public virtual IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}