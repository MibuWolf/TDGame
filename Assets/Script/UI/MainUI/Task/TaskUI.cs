using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {

    private UIGrid gird;

    public GameObject itemPrefab;
	// Use this for initialization
	void Awake ()
    {
        gird = this.transform.Find("Scroll/Grid").GetComponent<UIGrid>();
        print("");
	}


    private void Start()
    {
        Dictionary<int, Task> tasks =  TaskModel.instance.getAllTask();

        foreach (int val in tasks.Keys)

        {
            GameObject itemObj = NGUITools.AddChild(this.gameObject, itemPrefab);
            TaskItem item = itemObj.GetComponent<TaskItem>();
            item.initTask(val);
            gird.AddChild(itemObj.transform);
        }
    }


    // Update is called once per frame
	void Update () {
		
	}
}
