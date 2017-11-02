using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popTaskUI : MonoBehaviour {

    public static popTaskUI instance;

    private UILabel lbDia;

    private UILabel lbCoin;

    private UIButton btnGet;

    private UIButton btnClose;

	// Use this for initialization
	void Awake ()
    {
        instance = this;

        lbDia = this.transform.Find("lbDi").GetComponent<UILabel>();
        lbDia = this.transform.Find("lbCoin").GetComponent<UILabel>();
        btnGet = this.transform.Find("btGetTask").GetComponent<UIButton>();
        btnClose = this.transform.Find("btnClose").GetComponent<UIButton>();

        EventDelegate gettedEvent = new EventDelegate(this, "onClickGetted");
        btnGet.onClick.Add(gettedEvent);

        EventDelegate closeEvent = new EventDelegate(this, "onClickClose");
        btnClose.onClick.Add(gettedEvent);
    }
	
	// Update is called once per frame
	public void showPopWindow ( int id )
    {
		
	}
}
