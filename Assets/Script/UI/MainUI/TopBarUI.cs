using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBarUI : MonoBehaviour {

    // 金币数量
    private UILabel lbCoin;
    // 钻石数量
    private UILabel lbDiamonds;


    void Awake()
    {
        lbCoin = transform.Find("coinbg/lb_coin").GetComponent<UILabel>();
        lbDiamonds = transform.Find("diabg/lb_dia").GetComponent<UILabel>();

        PlayerInfo.instance.PlayerInfoChangeEvent += onPlayerInfpChanged;
    }


    private void onPlayerInfpChanged(InfoType type)
    {
        if (type == InfoType.ALL || type == InfoType.Coin || type == InfoType.Diamonds  )
        {
            updataInfo();
        }
    }

    private void updataInfo()
    {
        lbCoin.text = PlayerInfo.instance.coin.ToString();
        lbDiamonds.text = PlayerInfo.instance.diamonds.ToString();
    }
}
