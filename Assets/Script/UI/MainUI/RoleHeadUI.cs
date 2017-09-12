using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleHeadUI : MonoBehaviour {

    // 头像
    private UISprite imgHead;
    // 等级
    private UILabel lbLV;
    // 血量
    private UILabel lbHP;
    // 体力值
    private UILabel lbMP;
    // 添加HP
    private UIButton btnAddHP;
    // 添加MP
    private UIButton btnAddMP;

    // 头像按钮
    private UIButton btnHead;

    void Awake()
    {
        imgHead = transform.Find("img_Head").GetComponent<UISprite>();
        lbLV = transform.Find("lb_LV").GetComponent<UILabel>();
        lbHP = transform.Find("HP_con/HP/lb_hp").GetComponent<UILabel>();
        lbMP = transform.Find("MP_con/mp/lb_mp").GetComponent<UILabel>();
        btnAddHP = transform.Find("btn_AddHp").GetComponent<UIButton>();
        btnAddMP = transform.Find("btn_AddMP").GetComponent<UIButton>();

        btnHead = transform.Find("img_Head/btnHead").GetComponent<UIButton>();

        EventDelegate headEvent = new EventDelegate(this, "onClickHead");
        btnHead.onClick.Add(headEvent);

        PlayerInfo.instance.PlayerInfoChangeEvent += onPlayerInfpChanged;
    }


    private void onPlayerInfpChanged(InfoType type)
    {
        if (type == InfoType.ALL || type == InfoType.HeadPic || type == InfoType.LV || type == InfoType.Spirit || type == InfoType.Experience)
        {
            updataInfo();
        }
    }


    private void updataInfo()
    {
        imgHead.spriteName = PlayerInfo.instance.headPic;
        lbLV.text = PlayerInfo.instance.lv.ToString();
        lbHP.text = PlayerInfo.instance.spirit.ToString() + " / 100";
        lbMP.text = PlayerInfo.instance.experience.ToString() + " / 50";
    }


    //  点击头像
    private void onClickHead()
    {
        PlayerStatusUI.instance.Show();
    }

}
