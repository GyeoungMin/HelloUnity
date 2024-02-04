using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private GameObject itemBoomGo;
    [SerializeField] private GameObject itemCoinGo;
    [SerializeField] private GameObject itemPowerGo;

    private GameObject EnemyB;
    private GameObject EnemyC;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ItemInstantiate(Vector3 position)
    {
        GameObject item = this.ItemPrefab();
        item.transform.position = position;
        Instantiate(item);
    }

    private GameObject ItemPrefab()
    {
        float item = Random.Range(0, 3);
        switch (item)
        {
            case 0:
                return this.itemBoomGo;
            case 1:
                return this.itemCoinGo;
            case 2:
                return this.itemPowerGo;
            default: return null;
        }
    }
}
