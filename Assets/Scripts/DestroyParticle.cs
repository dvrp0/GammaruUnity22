using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        var particle = GetComponent<ParticleSystem>();
        yield return new WaitUntil(() => particle && !particle.IsAlive());

        Destroy(gameObject);
    }
}