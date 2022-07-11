using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform[] Items;
    public float Delay;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            float x = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y,
                                        Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float y = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x,
                                        Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            Instantiate(Items[Random.Range(0, Items.Length)], new Vector2(x, y), Quaternion.Euler(0, 0, 45));
            yield return new WaitForSeconds(Delay);
        }
    }
}