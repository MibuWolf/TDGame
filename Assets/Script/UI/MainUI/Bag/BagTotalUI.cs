using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagTotalUI : MonoBehaviour {

    public static BagTotalUI instance;

    // 装备详细信息
    private popEquipWin popEquip;

    // 出现动画
    private TweenPosition openTween;

    // 关闭按钮
    private UIButton btnClose;

    public bool bShow = false;

    public delegate void onSelectEquip(int equipid);
    public event onSelectEquip selectEquip;

    private void Awake()
    {
        instance = this;

        popEquip = transform.Find("popEquip").GetComponent<popEquipWin>();
        openTween = transform.GetComponent<TweenPosition>();
        btnClose = transform.Find("btnClose").GetComponent<UIButton>();

        EventDelegate closeClick = new EventDelegate(this, "onClose");
        btnClose.onClick.Add(closeClick);

    }

    // Use this for initialization
    void Start () {
        this.gameObject.SetActive(false);		
    }

    // Update is called once per frame
    void Update () {
		
	}

    //  玩家选中一个装备
    public void onSelectEquipItem( int equipID )
    {
        popEquip.onSelectEquip(equipID);
    }


    // 打开背包界面
    public void showBag()
    {
        this.gameObject.SetActive(true);
        openTween.PlayForward();
        bShow = true;
    }


    // 关闭背包界面
    public void onClose()
    {
        openTween.PlayReverse();

        StartCoroutine(closeBag());
    }


    //  关闭背包界面协程
    private IEnumerator closeBag()
    {
        yield return new WaitForSeconds(1);

        this.gameObject.SetActive(false);
        bShow = false;
    }

}
