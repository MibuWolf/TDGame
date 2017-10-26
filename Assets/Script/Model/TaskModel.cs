using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskModel : MonoBehaviour {

    public TextAsset file;

    // 所有道具数据
    private Dictionary<int, Task> datas = new Dictionary<int, Task>();


    public static TaskModel instance;

    void Awake ()
    {
        init();
	}


    // 初始化配置数据
    void init()
    {
        string strFile = file.ToString();

        string[] strTask = strFile.Split('\n');

        foreach (string strItem in strTask)
        {
            string[] strInfo = strItem.Split('|');

            Task task = initTask(strInfo);

            datas.Add(task.Id, task);

        }
    }


    // 初始化Task数据
    private Task initTask(string[] strInfo)
    {
        Task task = new Task();

        task.Id = int.Parse(strInfo[0]);

        switch (strInfo[1])
        {
            case "Main":
                task.Type = TaskType.Main;
                break;
            case "Reward":
                task.Type = TaskType.Reward;
                break;
            case "Daily":
                task.Type = TaskType.Daily;
                break;
        }
        task.TaskName = strInfo[2];
        task.Icon = strInfo[3];
        task.Des = strInfo[4];
        task.CoinCount = int.Parse( strInfo[5] );
        task.DiamondCount = int.Parse( strInfo[6] );
        task.NpcTalk = strInfo[7];
        task.NpcID = int.Parse( strInfo[8] );
        task.MapID = int.Parse(strInfo[9]);

        return task;

    }
}