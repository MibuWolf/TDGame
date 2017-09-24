using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleBag : MonoBehaviour {

    // 装备Item
    private EquipItem helmItem;
    private EquipItem clothItem;
    private EquipItem weaponItem;
    private EquipItem shoesItem;
    private EquipItem necklaceItem;
    private EquipItem braceletItem;
    private EquipItem ringItem;
    private EquipItem wingItem;

    // 血量
    private UILabel lbHP;
    private UILabel lbPower;
    private UIProgressBar exp;
    private UILabel lbExp;

    void Awake ()
    {
        helmItem = transform.Find("headItem").GetComponent<EquipItem>();
        clothItem = transform.Find("bodyItem").GetComponent<EquipItem>();
        weaponItem = transform.Find("footItem").GetComponent<EquipItem>();
        shoesItem = transform.Find("footItem").GetComponent<EquipItem>();
        necklaceItem = transform.Find("handItem").GetComponent<EquipItem>();
        braceletItem = transform.Find("braceletItem").GetComponent<EquipItem>();
        ringItem = transform.Find("ringItem").GetComponent<EquipItem>();
        wingItem = transform.Find("ringItem").GetComponent<EquipItem>();

        lbHP = transform.Find("hpBg/lbHP").GetComponent<UILabel>();
        lbPower = transform.Find("powerBg/lbPower").GetComponent<UILabel>();
        exp = transform.Find("exp_prograss").GetComponent<UIProgressBar>();

        lbExp = transform.Find("exp_prograss/lb_exp").GetComponent<UILabel>();

        PlayerInfo.instance.PlayerInfoChangeEvent += onEquipChanged;
    }


    private void onEquipChanged(InfoType type)
    {
        if (type == InfoType.ALL || type == InfoType.Equip || type == InfoType.Exp || type == InfoType.HP || type == InfoType.Power)
        {
            updataView();
        }
    }


    //  更新界面数据
    private void updataView()
    {
        helmItem.setEquip( PlayerInfo.instance.helmID );
        clothItem.setEquip(PlayerInfo.instance.bodyID);
        weaponItem.setEquip(PlayerInfo.instance.weaponID);
        shoesItem.setEquip(PlayerInfo.instance.shoesID);
        necklaceItem.setEquip(PlayerInfo.instance.necklaceID);
        braceletItem.setEquip(PlayerInfo.instance.braceletID);
        ringItem.setEquip(PlayerInfo.instance.ringID);
        wingItem.setEquip(PlayerInfo.instance.wingID);

        lbHP.text = PlayerInfo.instance.hp.ToString();
        lbPower.text = PlayerInfo.instance.power.ToString();
        lbExp.text = PlayerInfo.instance.exp.ToString() + " / " + PlayerInfo.instance.getLevelExp(PlayerInfo.instance.lv + 1);
        float curValue = PlayerInfo.instance.exp;
        float nextValue = PlayerInfo.instance.getLevelExp(PlayerInfo.instance.lv + 1);
        exp.value = curValue / nextValue;
    }


    private void OnDestroy()
    {
        PlayerInfo.instance.PlayerInfoChangeEvent -= onEquipChanged;
    }
}
