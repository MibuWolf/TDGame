using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour {

    // 任务类型
    private UISprite taskType;
    // 任务图标
    private UISprite taskIcon;
    // 任务名称
    private UILabel taskName;
    // 任务描述
    private UILabel taskInfo;
    // 金币数量
    private UILabel coinCount;
    // 钻石数量
    private UILabel diCount;
    // 任务状态按钮1
    private UIButton btnState1;
    // 任务状态按钮1的文字
    private UILabel lbState;
    // 任务状态2
    private UIButton btnState2;

    // 当前任务ID
    private int taskID = -1;

    //  主角
    private GameObject _mainRole;

	void Awake ()
    {
        taskType = this.transform.Find("imgTaskType").GetComponent<UISprite>();
        taskIcon = this.transform.Find("imgD/taskImg").GetComponent<UISprite>();
        taskName = this.transform.Find("taskName").GetComponent<UILabel>();
        taskInfo = this.transform.Find("taskInfo").GetComponent<UILabel>();
        coinCount = this.transform.Find("lbJB").GetComponent<UILabel>();
        diCount = this.transform.Find("lbZS").GetComponent<UILabel>();
        btnState1 = this.transform.Find("btnGo").GetComponent<UIButton>();
        lbState = this.transform.Find("btnGo/Label").GetComponent<UILabel>();
        btnState2 = this.transform.Find("btnGet").GetComponent<UIButton>();

        EventDelegate evt = new EventDelegate(this, "onClickBtn");
        btnState1.onClick.Add(evt);
    }


    //  设置任务数据
    public void initTask(int id)
    {
        Task task = TaskModel.instance.getTask(id);

        if (task == null)
            return;

        taskID = id;

        switch (task.Type)
        {
            case TaskType.Main:
                taskType.spriteName = "pic_主线";
                break;
            case TaskType.Reward:
                taskType.spriteName = "pic_奖赏";
                break;
            case TaskType.Daily:
                taskType.spriteName = "pic_日常";
                break;
        }

        taskIcon.spriteName = task.Icon;
        taskName.text = task.TaskName;
        taskInfo.text = task.Des;
        coinCount.text = task.CoinCount.ToString();
        diCount.text = task.DiamondCount.ToString();

        switch (task.CurState)
        {
            case TaskState.NoStart:
                {
                    btnState1.gameObject.SetActive(true);
                    btnState1.enabled = true;
                    btnState2.gameObject.SetActive(false);
                    lbState.text = "领取";
                }
                break;
            case TaskState.Acceptable:
                {
                    btnState1.gameObject.SetActive(true);
                    btnState1.enabled = true;
                    btnState2.gameObject.SetActive(false);
                    lbState.text = "领取";
                }
                break;
            case TaskState.Acceptted:
                {
                    btnState1.gameObject.SetActive(false);
                    btnState2.gameObject.SetActive(true);
                    btnState2.enabled = false;
                }
                break;
            case TaskState.Done:
                {
                    btnState1.gameObject.SetActive(false);
                    btnState2.gameObject.SetActive(true);
                    btnState2.enabled = true;
                }
                break;
        }

    }


    //  主角
    private GameObject mainRole
    {
        get
        {
            if (_mainRole == null)
            {
                _mainRole = GameObject.FindGameObjectWithTag("Player");
            }

            return _mainRole;
        }
    }


    //  点击接受按钮
    private void onClickBtn()
    {
        Task task = TaskModel.instance.getTask(taskID);

        if (task == null)
            return;

        if (task.CurState == TaskState.NoStart)
        {
            GameObject npc = NpcManager.instance.getNpc(task.NpcID);

            if (npc == null)
                return;

            MoveByNavMesh moveByNav = mainRole.GetComponent<MoveByNavMesh>();
            moveByNav.setDestination(npc.transform.position);
        }
    }


}
