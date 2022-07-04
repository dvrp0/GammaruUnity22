using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntervalEnemy : Enemy
{
    public float Interval;

    public override IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            yield return new WaitForSeconds(Interval);
        }
    }
}