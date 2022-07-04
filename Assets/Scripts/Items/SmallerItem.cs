using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmallerItem", menuName = "Item/Smaller")]
public class SmallerItem : Item
{
    public float Duration;
    public float Scale;

    public override void Execute()
    {
        GameManager.Instance.StartCoroutine(Dwindle());
    }

    private IEnumerator Dwindle()
    {
        GameManager.Instance.Player.localScale -= new Vector3(Scale, Scale);
        yield return new WaitForSeconds(Duration);
        GameManager.Instance.Player.localScale += new Vector3(Scale, Scale);
    }
}