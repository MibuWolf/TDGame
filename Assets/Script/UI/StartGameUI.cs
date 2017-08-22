using UnityEngine;
using System.Collections;

public class StartGameUI : MonoBehaviour {

    public TweenScale entergame;
	public TweenScale login;
	public TweenScale register;

    public UILabel lb_loginName;
    public UILabel lb_entergameName;

	// Use this for initialization  
	void Start () {
	
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


    IEnumerator Wait( GameObject obj )  
	{  
		yield return new WaitForSeconds(0.8f);
        obj.SetActive (false);
	}  
}
