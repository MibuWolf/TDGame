using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Item,
    Equip
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

    // 品质
    private int _quality = 0;

    // 等级
    private int _level = 1;

    // 战斗力
    private int _power = 0;

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

    // 等级
    public int level
    {
        get
        {
            return _level;
        }

        set
        {
            _level = value;
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

    #endregion
}
