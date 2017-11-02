using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUI : MonoBehaviour {

    private UIGrid gird;

    public GameObject itemPrefab;

    public static TaskUI instance;

    private TweenPosition tween;

    private UIButton btnClose;

    public bool bShow = false;
    // Use this for initialization
    void Awake ()
    {
        instance = this;
        this.gameObject.SetActive(false);

        gird = this.transform.Find("Scroll/Grid").GetComponent<UIGrid>();
        btnClose = this.transform.Find("btnClose").GetComponent<UIButton>();
        tween = this.transform.GetComponent<TweenPosition>();

        EventDelegate closeEvt = new EventDelegate(this, "onClose");
        btnClose.onClick.Add(closeEvt);

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


    public void Show()
    {
        this.gameObject.SetActive(true);
        tween.PlayForward();
        bShow = true;
    }


    // Update is called once per frame
    public void onClose()
    {
        tween.PlayReverse();

        StartCoroutine(tweenClose(0.8f));

    }


    IEnumerator tweenClose(float time)
    {
        yield return new WaitForSeconds(time);

        this.gameObject.SetActive(false);

        bShow = false;
    }
}
