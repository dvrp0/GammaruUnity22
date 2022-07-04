using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FasterItem", menuName = "Item/Faster")]
public class FasterItem : Item
{
    public float Duration;
    public float Speed;

    public override void Execute()
    {
        GameManager.Instance.StartCoroutine(SpeedUp());
    }

    private IEnumerator SpeedUp()
    {
        GameManager.Instance.Player.GetComponent<Player>().Speed += Speed;
        yield return new WaitForSeconds(Duration);
        GameManager.Instance.Player.GetComponent<Player>().Speed -= Speed;
    }
}