using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemy : Enemy
{
    public override IEnumerator Move()
    {
        while (true)
        {
            transform.Translate(Vector3.up * Speed * Time.deltaTime);
            transform.up = GameManager.Instance.Player.transform.position - transform.position;
            yield return null;
        }
    }
}