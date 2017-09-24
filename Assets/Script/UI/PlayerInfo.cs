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
    HP,
    Diamonds,
    Coin,
    Spirit,
    Experience,
    Equip,
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
    private int _lv = 5;
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
    // 血量
    private int _hp;
    // 头盔ID
    private int _helmID;
    // 项链ID
    private int _necklaceID;
    // 身体ID
    private int _bodyID;
    // 武器
    private int _weaponID;
    // 戒指
    private int _ringID;
    // 鞋子
    private int _shoesID;
    // 手镯
    private int _braceletID;
    // 翅膀
    private int _wingID;

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

            PlayerInfoChangeEvent(InfoType.Name);
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


    // 血量
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


    // 头盔ID
    public int helmID
    {
        get
        {
            return _helmID;
        }

        set
        {
            updataPower(_helmID, false);
            _helmID = value;
            updataPower(_helmID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }


    // 项链ID
    public int necklaceID
    {
        get
        {
            return _necklaceID;
        }

        set
        {
            updataPower(_necklaceID, false);
            _necklaceID = value;
            updataPower(_necklaceID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }

    // 服装ID
    public int bodyID
    {
        get
        {
            return _bodyID;
        }

        set
        {
            updataPower(_bodyID, false);
            _bodyID = value;
            updataPower(_bodyID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }

    // 武器ID
    public int weaponID
    {
        get
        {
            return _weaponID;
        }

        set
        {
            updataPower(_weaponID, false);
            _weaponID = value;
            updataPower(_weaponID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }


    // 戒指ID
    public int ringID
    {
        get
        {
            return _ringID;
        }

        set
        {
            updataPower(_ringID, false);
            _ringID = value;
            updataPower(_ringID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }


    // 翅膀ID
    public int wingID
    {
        get
        {
            return _wingID;
        }

        set
        {
            updataPower(_wingID, false);
            _wingID = value;
            updataPower(_wingID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }


    // 鞋子
    public int shoesID
    {
        get
        {
            return _shoesID;
        }

        set
        {
            updataPower(_shoesID, false);
            _shoesID = value;
            updataPower(_shoesID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }


    // 镯子
    public int braceletID
    {
        get
        {
            return _braceletID;
        }

        set
        {
            updataPower(_braceletID, false);
            _braceletID = value;
            updataPower(_braceletID, true);
            PlayerInfoChangeEvent(InfoType.Equip);
        }
    }

    #endregion


    #region UnityEvent

    public static PlayerInfo instance;

    // 体力恢复时间
    public float fTLTime = 0.0f;
    // 历练恢复时间
    public float fLLTime = 0.0f;

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
        lv = 12;
        vip = 1;
        power = 10000;
        exp = 680;
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

    // 根据等级计算这个等级的经验值
    public float getLevelExp( int level )
    {
        return level * 100.0f;
    }

    // 计算当前的战斗力
    private void updataPower( int id, bool bAdd = true )
    {
        int basicPower = _lv * 100 + hp;

        if(id > 0 )
        {
            Item item = ItemModel.instance.getItem(id);

            if (item != null)
            {
                if (bAdd)
                {
                    basicPower += item.hp;
                    basicPower += item.danmage;
                }
                else
                {
                    basicPower -= item.hp;
                    basicPower -= item.danmage;
                }
            }

        }

        power = basicPower;
    }

    #endregion
}
