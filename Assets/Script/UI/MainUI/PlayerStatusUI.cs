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
    // 经验数
    private UILabel lbExp;
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

    // 动画
    private TweenPosition tweenPos;
    // 关闭按钮
    private UIButton btnClose;

    // 单例
    public static PlayerStatusUI instance;

    //---------------------------------------------------------------------------------------
    
    // 改名界面
    private GameObject changeName;

    // 名称输入框
    private UIInput iptName;

    // 确定按钮
    private UIButton btnSure;

    // 取消按钮
    private UIButton btnCancle;

    void Awake()
    {
        instance = this;

        imgHead = transform.Find("img_head").GetComponent<UISprite>();
        lbLV = transform.Find("lb_LV").GetComponent<UILabel>();
        lbVIP = transform.Find("titleContainer/lv_vip").GetComponent<UILabel>();
        lbName = transform.Find("titleContainer/lv_name").GetComponent<UILabel>();
        lbPower = transform.Find("titleContainer/lv_power").GetComponent<UILabel>();
        btnChangeName = transform.Find("titleContainer/btn_ChangeName").GetComponent<UIButton>();
        prograssExp = transform.Find("titleContainer/exp_prograss").GetComponent<UIProgressBar>();
        lbExp = transform.Find("titleContainer/exp_prograss/lb_exp").GetComponent<UILabel>();
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
        btnClose = transform.Find("btnClose").GetComponent<UIButton>();

        // -------------------------------------------------------------------------

        changeName = transform.Find("changeName").gameObject;
        iptName = changeName.transform.Find("ipt_Name").GetComponent<UIInput>();
        btnSure = changeName.transform.Find("btn_Sure").GetComponent<UIButton>();
        btnCancle = changeName.transform.Find("btn_Cancel").GetComponent<UIButton>();
        changeName.SetActive(false);

        EventDelegate changeNameEvt = new EventDelegate(this, "onClickChangeName");
        btnChangeName.onClick.Add(changeNameEvt);

        EventDelegate btnSureEvt = new EventDelegate(this, "onClickSure");
        btnSure.onClick.Add(btnSureEvt);

        EventDelegate btnCancleEvt = new EventDelegate(this, "onClickCancel");
        btnCancle.onClick.Add(btnCancleEvt);

        tweenPos = transform.GetComponent<TweenPosition>();

        EventDelegate closeEvent = new EventDelegate(this, "onCloseBtn");
        btnClose.onClick.Add(closeEvent);

        PlayerInfo.instance.PlayerInfoChangeEvent += onPlayerInfoChanged;

    }


    void Update()
    {
        updataTL();
    }



    // 显示界面
    public void Show()
    {
        tweenPos.PlayForward();
    }


    // 隐藏界面
    private void onCloseBtn()
    {
        tweenPos.PlayReverse();
    }


    // 点击改名按钮
    private void onClickChangeName()
    {
        changeName.SetActive(true);
    }


    // 点击确认修改名称
    private void onClickSure()
    {
        PlayerInfo.instance.Name = iptName.text;
        changeName.SetActive(false);
    }

    // 点击取消改名
    private void onClickCancel()
    {
        changeName.SetActive(false);
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
            prograssExp.value = (float)PlayerInfo.instance.exp / PlayerInfo.instance.getLevelExp( PlayerInfo.instance.lv );
            lbExp.text = PlayerInfo.instance.exp.ToString() + " / " + PlayerInfo.instance.getLevelExp( PlayerInfo.instance.lv ).ToString();
            lbDiamonds.text = PlayerInfo.instance.diamonds.ToString();
            lbCoin.text = PlayerInfo.instance.coin.ToString();
            lbJS.text = PlayerInfo.instance.spirit.ToString();
            lbStar.text = PlayerInfo.instance.experience.ToString();

            updataTL();
        }
    }


    // 更新体力恢复倒计时
    private void updataTL()
    {
        if (PlayerInfo.instance.spirit < 100)
        {
            int waitTime = 60 - (int)PlayerInfo.instance.fTLTime;
            lbTLTime.text = waitTime > 9 ? "00:00:" + waitTime.ToString() : "00:00:" + "0" + waitTime.ToString();
            lbTLTime1.text = waitTime > 9 ? "00:00:" + waitTime.ToString() : "00:00:" + "0" + waitTime.ToString();
        }
        else
        {
            lbTLTime.text = "00:00:00";
        }

        if (PlayerInfo.instance.experience < 50)
        {
            int waitTime = 60 - (int)PlayerInfo.instance.fLLTime;
            lbLLTime.text = waitTime > 9 ? "00:00:" + waitTime.ToString() : "00:00:" + "0" + waitTime.ToString();
            lbLLTime1.text = waitTime > 9 ? "00:00:" + waitTime.ToString() : "00:00:" + "0" + waitTime.ToString();
        }
        else
        {
            lbLLTime.text = "00:00:00";
        }

    }

}
