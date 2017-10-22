using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagView : MonoBehaviour {

    private List<EquipItem> items;


    private void Awake()
    {
        items = new List<EquipItem>();

        for (int i = 0; i < 50; ++i)
        {
            string itemName = "scrollList/bagItem"+i.ToString();
            EquipItem item = this.transform.Find(itemName).GetComponent<EquipItem>();

            if (item)
                items.Add(item);
             
        }
    }

    // Use this for initialization
    void Start ()
    {
        Dictionary<int, ItemVO> bagItems = ItemModel.instance.items;

        int count = bagItems.Count;
        int index = 0;

        foreach (KeyValuePair<int, ItemVO> kv in bagItems)
        {
            EquipItem item = items[index++];

            item.setEquip(kv.Key);
        }


        for( int i = count; i < 50; ++i )
        {
            EquipItem item = items[i];

            item.setEquip(-1);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
