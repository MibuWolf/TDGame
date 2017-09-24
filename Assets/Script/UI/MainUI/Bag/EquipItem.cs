using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour {

    // 图片
    private UISprite _img;

    // 堆叠数
    private UILabel _lbCount;

	void Awake ()
    {
        img = transform.Find("img").GetComponent<UISprite>();
        lbCount = transform.Find("lbCount").GetComponent<UILabel>();	
	}


    public UISprite img
    {
        get
        {
            if( _img == null )
                _img = transform.Find("img").GetComponent<UISprite>();

            return _img;
        }

        set
        {
            _img = value;
        }
    }


    public UILabel lbCount
    {
        get
        {
            if( _lbCount == null )
                _lbCount = transform.Find("lbCount").GetComponent<UILabel>();

            return _lbCount;
        }

        set
        {
            _lbCount = value;
        }
    }

	
	// 设置装备ID
    public void setEquip( int id )
    {
        ItemVO vo = ItemModel.instance.getBagItem(id);

        if (vo == null)
        {
            img.spriteName = "";
            lbCount.text = "";
        }
        else
        {
            img.spriteName = vo.item.icon;
            lbCount.text = vo.count.ToString();
        }
    }

}
