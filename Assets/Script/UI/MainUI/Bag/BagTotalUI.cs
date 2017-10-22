using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTotalUI : MonoBehaviour {

    public static BagTotalUI instance;

    // 装备详细信息
    private popEquipWin popEquip;

    public delegate void onSelectEquip(int equipid);
    public event onSelectEquip selectEquip;

    private void Awake()
    {
        instance = this;

        popEquip = transform.Find("popEquip").GetComponent<popEquipWin>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //  玩家选中一个装备
    public void onSelectEquipItem( int equipID )
    {
        popEquip.onSelectEquip(equipID);
    }
}
