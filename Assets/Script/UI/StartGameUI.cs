﻿using UnityEngine;
using System.Collections;

public class StartGameUI : MonoBehaviour {

    //  各个界面
    public TweenScale entergame;
	public TweenScale login;
	public TweenScale register;
    public TweenScale service;
    public TweenPosition entergameGO;
    public TweenPosition selectRole;

    //  登陆界面角色名称
    public UILabel lb_loginName;
    //  进入游戏的角色名称
    public UILabel lb_entergameName;

    // 服务器列表
    public UIGrid servicelist;

    //  火爆服务器预设
    public GameObject hb_obj;
    //  流畅服务器预设
    public GameObject lc_obj;

    // 当前选中的服务器
    public GameObject sltService;


    public static StartGameUI instance;

    // 当前选中的角色
    private GameObject curSelectRole;

    void Awake()
    {
        StartGameUI.instance = this;
    }

    // Use this for initialization  
    void Start () {

        initServiceList();

    }


    //  点击开始游戏按钮进入切换角色界面
    public void onEnterSelectRole()
    {
        entergameGO.PlayForward();
        Wait(entergameGO.gameObject);
        selectRole.gameObject.SetActive(true);
        selectRole.PlayForward();
    }


    // 点击进入游戏选择用户按钮
    public void onClickUserName()
    {
		login.PlayForward ();
		login.gameObject.SetActive (true);
		entergame.PlayForward ();

		StartCoroutine (Wait (entergame.gameObject));
    }


	// 点击服务器更换按钮
	public void onClickChangeService()
	{
        service.PlayForward();
        service.gameObject.SetActive(true);
        entergame.PlayForward();

        StartCoroutine(Wait(entergame.gameObject));
    }


	// 点击开始游戏
	public void onClickEnterGame()
	{
		// send request to service
	}


	// 点击登陆界面的登陆按钮
	public void onClickLoginEnter()
	{
        login.PlayReverse();
        StartCoroutine(Wait(login.gameObject));
        entergame.gameObject.SetActive(true);
        entergame.PlayReverse();

        lb_entergameName.text = lb_loginName.text;
    }


    // 点击登陆界面的注册按钮
    public void onClickLoginRegist()
    {
        login.PlayReverse();
        StartCoroutine(Wait(login.gameObject));
        register.gameObject.SetActive(true);
        register.PlayForward();
    }


    // 点击注册界面的注册按钮
    public void onClickRegisterRegisterBtn()
	{
		// 发送消息给服务器
	}


    // 点击注册界面的取消按钮
    public void onClickRegisterCancelBtn()
    {
        register.PlayReverse();
        StartCoroutine(Wait(register.gameObject));
        login.gameObject.SetActive(true);
        login.PlayForward();
        
    }

    //  初始化服务器列表
    private void initServiceList()
    {
        for (int i = 1; i < 21; i++)
        {
            string ip = "127.0.0.1:8080";
            string name = i.ToString() + "区 勇者大陆";
            int count = Random.Range(0, 100);

            GameObject obj = null;

            if (count > 50)
            {
                obj = NGUITools.AddChild(servicelist.gameObject, hb_obj);
            }
            else
            {
                obj = NGUITools.AddChild(servicelist.gameObject, lc_obj);
            }

            ServiceInfo info = obj.GetComponent<ServiceInfo>();
            info.IP = ip;
            info.name = name;
            info.count = count;
            servicelist.AddChild(obj.transform);
        }
    }


    // 打开服务器列表界面
    public void onOpenServiceList()
    {
        entergame.PlayForward();
        StartCoroutine(Wait(entergame.gameObject));

        service.gameObject.SetActive(true);
        service.PlayForward();
    }


    //  从服务器列表中选中服务器
    public void onSelectService(GameObject selectObj)
    {
        ServiceInfo selectInfo = selectObj.GetComponent<ServiceInfo>();

        sltService.transform.Find("Label").GetComponent<UILabel>().text = selectInfo.name;
        UIButton uiBtn = sltService.GetComponent<UIButton>();
        UIButton selectBtn = selectObj.GetComponent<UIButton>();

        uiBtn.normalSprite = selectBtn.normalSprite;
        uiBtn.hoverSprite = selectBtn.hoverSprite;
        uiBtn.pressedSprite = selectBtn.pressedSprite;
        uiBtn.disabledSprite = selectBtn.disabledSprite;
    }


    // 确认选中服务器
    public void onSureService()
    {
        service.PlayReverse();
        StartCoroutine(Wait( service.gameObject ));

        entergame.gameObject.SetActive(true);
        entergame.PlayReverse();
    }



    // 选中角色回调
    public void onRoleSelected(GameObject obj)
    {
        if (curSelectRole)
        {
            iTween.ScaleTo(curSelectRole, new Vector3( 1.0f,1.0f,1.0f ), 0.8f);
        }

        iTween.ScaleTo(obj, new Vector3(1.5f, 1.5f, 1.5f), 0.8f);

        curSelectRole = obj;
    }



    IEnumerator Wait( GameObject obj )  
	{  
		yield return new WaitForSeconds(0.8f);
        obj.SetActive (false);
	}

}
