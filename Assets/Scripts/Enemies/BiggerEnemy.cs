using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerEnemy : Enemy
{
    public float Ratio;

    public override IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            transform.localScale += new Vector3(Ratio, Ratio);
            yield return null;
        }
    }
}