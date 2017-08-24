using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInfo : MonoBehaviour {

    //  服务器IP端口号
    public string IP = "";

    //  服务器名称
    private string _name;
    public string name
    {
        get { return _name; }

        set
        {   
            transform.Find("Label").GetComponent<UILabel>().text = value;
            _name = value;
        }
    }

    //  服务器人数
    public int count = 0;



    //  对象被点击
    public void OnPress( bool ispress )
    {
        if (ispress == false)
        {
            this.transform.root.SendMessage("onSelectService", this.gameObject,SendMessageOptions.RequireReceiver);
        }
    }

}
