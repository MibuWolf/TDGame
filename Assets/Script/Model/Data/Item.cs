using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Equip
}


public enum EquipType
{
    INVALID,
    Helm,
    Cloth,
    Weapon,
    Shoes,
    Necklace,
    Bracelet,
    Ring,
    Wing
}


public class Item
{

    #region ItemProperty

    // 道具ID
    private int _id;

    // 道具名称
    private string _name;

    // 道具ICON
    private string _icon;

    // 道具类型
    private ItemType _type;

    // 装备类型
    private EquipType _equipType;

    // 价格
    private int _price = 0;

    // 星级
    private int _star = 0;

    // 品质
    private int _quality = 0;

    // 伤害
    private int _damage = 0;

    // 生命
    private int _hp = 0;

    // 战斗力
    private int _power = 0;

    // 作用类型
    private string _actionType = "";

    // 作用值
    private string _actionValue = "";

    // 描述信息
    private string _describe;

    #endregion


    #region ItemPropertyFuc

    // 道具ID
    public int id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    // 道具名称
    public string itemname
    {
        get
        {
            return _name;
        }

        set
        {
            _name = value;
        }
    }

    // 道具ICON
    public string icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
        }
    }

    // 道具类型
    public ItemType type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }


    // 装备类型
    public EquipType equipType
    {
        get
        {
            return _equipType;
        }

        set
        {
            _equipType = value;
        }
    }


    // 价格
    public int price
    {
        get
        {
            return _price;
        }

        set
        {
            _price = value;
        }
    }


    // 星级
    public int star
    {
        get
        {
            return _star;
        }

        set
        {
            _star = value;
        }
    }

    // 品质
    public int quality
    {
        get
        {
            return _quality;
        }

        set
        {
            _quality = value;
        }
    }


    // 伤害值
    public int danmage
    {
        get
        {
            return _damage;
        }

        set
        {
            _damage = value;
        }
    }


    // 血量值
    public int hp
    {
        get
        {
            return _hp;
        }

        set
        {
            _hp = value;
        }
    }


    // 战斗力
    public int power
    {
        get
        {
            return _power;
        }

        set
        {
            _power = value;
        }
    }


    // 作用类型
    public string actionType
    {
        get
        {
            return _actionType;
        }

        set
        {
            _actionType = value;
        }
    }


    // 作用值
    public string actionValue
    {
        get
        {
            return _actionValue;
        }

        set
        {
            _actionValue = value;
        }
    }


    // 描述信息
    public string describe
    {
        get
        {
            return _describe;
        }

        set
        {
            _describe = value;
        }
    }

    #endregion
}
