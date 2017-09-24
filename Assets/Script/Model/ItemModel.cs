using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : MonoBehaviour {

    public TextAsset file;

    // 所有道具数据
    private Dictionary<int, Item> datas = new Dictionary<int, Item>();

    // 当前主角所拥有的道具数据
    private Dictionary<int,ItemVO> items = new Dictionary<int,ItemVO>();

    public static ItemModel instance;

	void Awake ()
    {
        instance = this;
        init();
        initBag();
    }


    // 获取道具数据
    public Item getItem( int id )
    {
        Item item = null;

        datas.TryGetValue(id, out item);

        return item;
    }


    // 获取背包数据
    public ItemVO getBagItem(int id)
    {
        ItemVO vo = null;

        items.TryGetValue(id, out vo);

        return vo;
    }


    // 初始化配置数据
    void init()
    {
       string strFile = file.ToString();

        string[] strItems = strFile.Split('\n');

        foreach ( string strItem in strItems )
        {
            string[] strInfo = strItem.Split('|');

            Item item = initItem(strInfo);

            datas.Add(item.id, item);

        }
    }


    // 初始化拥有道具数据（应该是服务器下发）
    private void initBag()
    {
        for (int i = 0; i < 20; i++)
        {
            int id = Random.Range(1001, 1020);

            Item item = null;
            datas.TryGetValue( id, out item );

            if ( item == null )
                continue;

            ItemVO vo = null;

            items.TryGetValue( id, out vo );

            if (vo == null)
            {
                vo = new ItemVO();
                vo.item = item;
                vo.count = 1;
                items.Add(item.id, vo);

                if (item.type == ItemType.Item)
                    vo.count = Random.Range(1, 50);
            }
            else
            {
                if (item.type == ItemType.Equip)
                    vo.count = 1;
                else
                    vo.count++;
            }


            // 初始化主角装备
            if (item.type == ItemType.Equip)
            {
                initRoleEquip(item);
            }

        }
    }


    // 初始化主角装备
    private void initRoleEquip(Item item)
    {
        if (item == null)
            return;

        switch( item.equipType )
        {
            case EquipType.Helm:
                {
                    PlayerInfo.instance.helmID = item.id;
                }break;
            case EquipType.Necklace:
                {
                    PlayerInfo.instance.necklaceID = item.id;
                }
                break;
            case EquipType.Cloth:
                {
                    PlayerInfo.instance.bodyID = item.id;
                }
                break;
            case EquipType.Ring:
                {
                    PlayerInfo.instance.ringID = item.id;
                }
                break;
            case EquipType.Weapon:
                {
                    PlayerInfo.instance.weaponID = item.id;
                }
                break;
            case EquipType.Shoes:
                {
                    PlayerInfo.instance.shoesID = item.id;
                }
                break;
            case EquipType.Wing:
                {
                    PlayerInfo.instance.wingID = item.id;
                }
                break;
            case EquipType.Bracelet:
                {
                    PlayerInfo.instance.braceletID = item.id;
                }
                break;
        }

    }


    // 初始化Item数据
    private Item initItem( string[] strInfo)
    {
        Item item = new Item();

        item.id = int.Parse(strInfo[0]);
        item.itemname = strInfo[1];
        item.icon = strInfo[2];

        switch (strInfo[3])
        {
            case "Equip":
                {
                    item.type = ItemType.Equip;

                    switch (strInfo[4])
                    {
                        case "Helm":
                            {
                                item.equipType = EquipType.Helm;
                            }
                            break;
                        case "Cloth":
                            {
                                item.equipType = EquipType.Cloth;
                            }
                            break;
                        case "Weapon":
                            {
                                item.equipType = EquipType.Weapon;
                            }
                            break;
                        case "Shoes":
                            {
                                item.equipType = EquipType.Shoes;
                            }
                            break;
                        case "Necklace":
                            {
                                item.equipType = EquipType.Necklace;
                            }
                            break;
                        case "Bracelet":
                            {
                                item.equipType = EquipType.Bracelet;
                            }
                            break;
                        case "Ring":
                            {
                                item.equipType = EquipType.Ring;
                            }
                            break;
                        case "Wing":
                            {
                                item.equipType = EquipType.Wing;
                            }
                            break;
                    }

                }
                break;

            case "Drug":
            case "Box":
                {
                    item.type = ItemType.Equip;
                    item.equipType = EquipType.INVALID;
                }
                break;
        }

        item.price = int.Parse(strInfo[5]);
        item.star = int.Parse(strInfo[6]);
        item.quality = int.Parse(strInfo[7]);
        item.danmage = int.Parse(strInfo[8]);
        item.hp = int.Parse(strInfo[9]);
        item.power = int.Parse(strInfo[10]);
        item.actionType = strInfo[11];
        item.actionValue = strInfo[12];
        item.describe = strInfo[13];

        return item;
    }

}
