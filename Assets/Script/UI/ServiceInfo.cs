using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceInfo : MonoBehaviour {

    //  服务器IP端口号
    public string IP = "";

    //  服务器名称
    public string name
    {
        get { return name; }

        set
        {   
            transform.Find("Label").GetComponent<UILabel>().text = value;;
        }
    }

    //  服务器人数
    public int count = 0;
}
