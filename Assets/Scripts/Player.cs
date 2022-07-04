using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life;
    public float Speed;
    public Item Item;

    private void Update()
    {
        transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * Speed * Time.deltaTime,
                            Input.GetAxisRaw("Vertical") * Speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space))
            Item.Execute();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Life--;
    }
}