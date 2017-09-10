using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUI : MonoBehaviour {

    // 头像
    private UISprite imgHead;
    // 等级
    private UILabel lbLV;
    // VIP等级
    private UILabel lbVIP;
    // 姓名
    private UILabel lbName;
    // 战斗力
    private UILabel lbPower;
    // 更改名称
    private UIButton btnChangeName;
    // 经验条
    private UIProgressBar prograssExp;
    // 钻石数
    private UILabel lbDiamonds;
    // 金币数
    private UILabel lbCoin;
    // 晶石数
    private UILabel lbJS;
    // 星星数
    private UILabel lbStar;
    // 体力值
    private UILabel lbTL;
    // 体力恢复时间
    private UILabel lbTLTime;
    // 体力恢复时间2
    private UILabel lbTLTime1;
    // 历练值
    private UILabel lbLL;
    // 历练恢复时间
    private UILabel lbLLTime;
    // 历练恢复时间2
    private UILabel lbLLTime1;


    void Awake()
    {
        imgHead = transform.Find("img_head").GetComponent<UISprite>();
        lbLV = transform.Find("lb_LV").GetComponent<UILabel>();
        lbVIP = transform.Find("titleContainer/lv_vip").GetComponent<UILabel>();
        lbName = transform.Find("titleContainer/lv_name").GetComponent<UILabel>();
        lbPower = transform.Find("titleContainer/lv_power").GetComponent<UILabel>();
        btnChangeName = transform.Find("titleContainer/btn_ChangeName").GetComponent<UIButton>();
        prograssExp = transform.Find("titleContainer/exp_prograss").GetComponent<UIProgressBar>();
        lbDiamonds = transform.Find("middleContainer/diaItem/lb_value").GetComponent<UILabel>();
        lbCoin = transform.Find("middleContainer/coinItem/lb_value").GetComponent<UILabel>();
        lbJS = transform.Find("middleContainer/jsItem/lb_value").GetComponent<UILabel>();
        lbStar = transform.Find("middleContainer/starItem/lb_value").GetComponent<UILabel>();
        lbTL = transform.Find("tlContainer/lb_TL").GetComponent<UILabel>();
        lbTLTime = transform.Find("tlContainer/lb_time").GetComponent<UILabel>();
        lbTLTime1 = transform.Find("tlContainer/lb_time1").GetComponent<UILabel>();
        lbLL = transform.Find("llContainer/lb_TL").GetComponent<UILabel>();
        lbLLTime = transform.Find("llContainer/lb_time").GetComponent<UILabel>();
        lbLLTime1 = transform.Find("llContainer/lb_time1").GetComponent<UILabel>();

        PlayerInfo.instance.PlayerInfoChangeEvent += onPlayerInfoChanged;

    }


    // 角色属性更改
    private void onPlayerInfoChanged( InfoType type )
    {
        if ( type == InfoType.ALL || type == InfoType.Coin || type == InfoType.Diamonds || type == InfoType.Exp || type == InfoType.Experience || type == InfoType.HeadPic 
            || type == InfoType.LV || type == InfoType.Name || type == InfoType.Power || type == InfoType.Spirit )
        {
            imgHead.spriteName = PlayerInfo.instance.headPic;
            lbLV.text = PlayerInfo.instance.lv.ToString();
            lbVIP.text = PlayerInfo.instance.vip.ToString();
            lbName.text = PlayerInfo.instance.Name;
            lbPower.text = PlayerInfo.instance.power.ToString();
            prograssExp.value = PlayerInfo.instance.exp / 10000.0f;
            lbDiamonds.text = PlayerInfo.instance.diamonds.ToString();
            lbCoin.text = PlayerInfo.instance.coin.ToString();
            lbJS.text = PlayerInfo.instance.spirit.ToString();
            lbStar.text = PlayerInfo.instance.experience.ToString();
        }
    }


}
