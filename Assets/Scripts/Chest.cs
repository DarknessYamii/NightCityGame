using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{

    public Sprite emptyChest;
    public int moneyAmount = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            Debug.Log("Grant money");
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + moneyAmount + " money");
        }

    }
}
