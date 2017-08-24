using UnityEngine;
using System.Collections;

public class StartGameUI : MonoBehaviour {

    //  各个界面
    public TweenScale entergame;
	public TweenScale login;
	public TweenScale register;
    public TweenScale service;

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

	// Use this for initialization  
	void Start () {

        initServiceList();

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


    IEnumerator Wait( GameObject obj )  
	{  
		yield return new WaitForSeconds(0.8f);
        obj.SetActive (false);
	}

}
