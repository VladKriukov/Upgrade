using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomShopKeeper : MonoBehaviour
{
    [SerializeField] Sprite[] shopKeeperSprites;
    [SerializeField] Image shopKeeper;

    void Start()
    {
        int num = Random.Range(0,shopKeeperSprites.Length);
        shopKeeper.sprite = shopKeeperSprites[num];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
