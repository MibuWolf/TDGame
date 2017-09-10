using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InfoType
{
    Name,
    HeadPic,
    LV,
    Power,
    Exp,
    Diamonds,
    Coin,
    Spirit,
    Experience,
    ALL
}

public class PlayerInfo : MonoBehaviour {


    //姓名
    //头像
    //等级
    //战斗力
    //经验数
    //钻石数
    //金币数
    //体力数
    //历练数


    #region RoleProperty

    // 姓名
    private string _name;
    // 头像
    private string _headPic;
    // 等级
    private int _lv;
    // VIP
    private int _vip;
    // 战斗力
    private int _power;
    // 经验值
    private int _exp;
    // 钻石数
    private int _diamonds;
    // 金币数
    private int _coin;
    // 体力数
    private int _spirit;
    // 历练数
    private int _experience;

    #endregion


    #region GetSetProperty

    // 姓名
    public string Name
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



    // 头像
    public string headPic
    {
        get
        {
            return _headPic;
        }

        set
        {
            _headPic = value;
        }
    }


    // 等级
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


    // VIP
    public int vip
    {
        get
        {
            return _vip;
        }

        set
        {
            _vip = value;
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


    // 经验值
    public int exp
    {
        get
        {
            return _exp;
        }

        set
        {
            _exp = value;
        }
    }


    // 钻石数
    public int diamonds
    {
        get
        {
            return _diamonds;
        }

        set
        {
            _diamonds = value;
        }
    }


    // 钻石数
    public int coin
    {
        get
        {
            return _coin;
        }

        set
        {
            _coin = value;
        }
    }



    // 体力数
    public int spirit
    {
        get
        {
            return _spirit;
        }

        set
        {
            _spirit = value;
        }
    }


    // 历练数
    public int experience
    {
        get
        {
            return _experience;
        }

        set
        {
            _experience = value;
        }
    }

    #endregion


    #region UnityEvent

    public static PlayerInfo instance;

    // 体力恢复时间
    private float fTLTime = 0.0f;
    // 历练恢复时间
    private float fLLTime = 0.0f;

    void Awake()
    {
        PlayerInfo.instance = this;
    }


    void Start()
    {
        init();
    }


    //  初始化数据
    private void init()
    {
        Name = "MibuWolf";
        headPic = "头像底板女性";
        lv = 1;
        vip = 1;
        power = 10000;
        exp = 5000;
        diamonds = 100;
        coin = 1000;
        spirit = 50;
        experience = 20;

        PlayerInfoChangeEvent(InfoType.ALL);

    }


    void Update()
    {
        if (_spirit < 100)
        {
            fTLTime += Time.deltaTime;

            if (fTLTime > 60)
            {
                _spirit++;
                fTLTime -= 60;

                PlayerInfoChangeEvent(InfoType.Spirit);
            }
        }


        if (_experience < 50)
        {
            fLLTime += Time.deltaTime;

            if (fLLTime > 60)
            {
                _experience++;
                fLLTime -= 60;

                PlayerInfoChangeEvent(InfoType.Experience);
            }
        }
    }

    #endregion


    #region Logic

    public delegate void onPlayerInfoChanged( InfoType type );
    public event onPlayerInfoChanged PlayerInfoChangeEvent;
    
    #endregion
}
