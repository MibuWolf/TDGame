using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVO
{
    private Item _item;
    private int _count;
    private int _lv;


    public Item item
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
        }
    }


    public int count
    {
        get
        {
            return _count;
        }
        set
        {
            _count = value;
        }
    }

    public int lv
    {
        get
        {
            return _lv;
        }
        set
        {
            _lv = value;
        }
    }

}
