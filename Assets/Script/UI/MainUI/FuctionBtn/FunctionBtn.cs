using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBtn : MonoBehaviour {

    // 战斗按钮

    //  背包按钮
    private UIButton btnBag;

    void Awake()
    {
        btnBag = transform.Find("bagBar").GetComponent<UIButton>();

        EventDelegate bagClick = new EventDelegate(this, "onClickBag");
        btnBag.onClick.Add(bagClick);
    }


    private void onClickBag()
    {
        if (BagTotalUI.instance.bShow)
            BagTotalUI.instance.onClose();
        else
            BagTotalUI.instance.showBag();
    }

}
