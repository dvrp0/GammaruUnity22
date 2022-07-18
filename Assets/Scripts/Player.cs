using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life;
    public float Speed;
    public Transform OnHitParticle;
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
        {
            Life--;
            Instantiate(OnHitParticle, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            Item = collision.gameObject.GetComponent<ItemContainer>().Item;
            StartCoroutine(PlayAudio(collision.gameObject));
        }
    }

    private IEnumerator PlayAudio(GameObject gameObject)
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(gameObject.GetComponent<AudioSource>().clip.length);
        Destroy(gameObject);
    }
}