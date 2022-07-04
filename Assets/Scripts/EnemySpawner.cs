using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] Enemies;
    public float Delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int angle = Random.Range(-180, 181); // -180 ~ 180
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * 10;

            var enemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], offset, Quaternion.identity);
            enemy.up = GameManager.Instance.Player.position - enemy.position;

            yield return new WaitForSeconds(Delay);
        }
    }
}