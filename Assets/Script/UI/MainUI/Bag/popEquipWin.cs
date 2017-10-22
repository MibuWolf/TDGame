using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popEquipWin : MonoBehaviour {

    private bool bShow = false;
    // Use this for initialization

    // 选择的装备图片
    private UISprite equipImg;
    // 装备名称
    private UILabel lbEquipName;
    // 品质
    private UILabel lbPZ;
    // 战斗力
    private UILabel lbPower;
    // 攻击力
    private UILabel lbFight;
    // 装备说明
    private UILabel lbInfo;


    void Awake()
    {
        equipImg = this.transform.Find("bagItem/img").GetComponent<UISprite>();
        lbEquipName = this.transform.Find("lbName").GetComponent<UILabel>();
        lbPZ = this.transform.Find("lbPZ").GetComponent<UILabel>();
        lbPower = this.transform.Find("lbPower").GetComponent<UILabel>();
        lbFight = this.transform.Find("lbTotalPower").GetComponent<UILabel>();
        lbInfo = this.transform.Find("lbInfo").GetComponent<UILabel>();

        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }


    //  选中装备
    public void onSelectEquip(int equipID)
    {
        ItemVO vo = ItemModel.instance.getBagItem(equipID);

        if (vo == null)
            return;

        this.gameObject.SetActive(true);
        bShow = true;

        equipImg.spriteName = vo.item.icon;
        lbEquipName.text = vo.item.itemname;
        lbPZ.text = vo.item.quality.ToString();
        lbPower.text = vo.item.power.ToString();
        lbFight.text = vo.item.power.ToString();
        lbInfo.text = vo.item.describe;

    }

    //  关闭界面
    public void onClose()
    {
        this.gameObject.SetActive(false);
        bShow = false;
    }

    private void OnDestroy()
    {
        BagTotalUI.instance.selectEquip -= onSelectEquip;
    }
}
