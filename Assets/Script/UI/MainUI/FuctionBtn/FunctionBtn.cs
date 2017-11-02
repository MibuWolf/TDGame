using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBtn : MonoBehaviour {

    // 战斗按钮

    //  背包按钮
    private UIButton btnBag;

    //  任务按钮
    private UIButton btnTask;

    void Awake()
    {
        btnBag = transform.Find("bagBar").GetComponent<UIButton>();
        btnTask = transform.Find("taskBar").GetComponent<UIButton>();

        EventDelegate bagClick = new EventDelegate(this, "onClickBag");
        btnBag.onClick.Add(bagClick);


        EventDelegate taskClick = new EventDelegate(this, "onClickTask");
        btnTask.onClick.Add(taskClick);
    }


    private void onClickBag()
    {
        if (BagTotalUI.instance.bShow)
            BagTotalUI.instance.onClose();
        else
            BagTotalUI.instance.showBag();
    }


    private void onClickTask()
    {
        if (TaskUI.instance.bShow)
            TaskUI.instance.onClose();
        else
            TaskUI.instance.Show();
    }

}
