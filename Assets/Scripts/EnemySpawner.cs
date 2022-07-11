using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyEntry[] Enemies;
    public float Delay;
    public float ScaleInterval;
    public float ScaleValue;
    public float ScaleMinimum;

    private float cumulativeSum = 0;

    private void Start()
    {
        foreach (var entry in Enemies)
            cumulativeSum += entry.Weight;

        StartCoroutine(Spawn());
        StartCoroutine(ScaleDifficulty());
    }

    private Transform GetWeightedRandomEnemy()
    {
        float cumulative = 0, roll = Random.Range(0, cumulativeSum);

        foreach (var entry in Enemies)
        {
            cumulative += entry.Weight;

            if (cumulative > roll)
                return entry.Enemy;
        }

        return Enemies[0].Enemy;
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            int angle = Random.Range(-180, 181); // -180 ~ 180
            var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * 10;

            var enemy = Instantiate(GetWeightedRandomEnemy(), offset, Quaternion.identity);
            enemy.up = GameManager.Instance.Player.position - enemy.position;

            yield return new WaitForSeconds(Delay);
        }
    }

    private IEnumerator ScaleDifficulty()
    {
        while (true)
        {
            if (Delay > ScaleMinimum)
                Delay -= ScaleValue;

            yield return new WaitForSeconds(ScaleInterval);
        }
    }
}