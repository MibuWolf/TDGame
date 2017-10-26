using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//  任务类型
enum TaskType
{
    // 主线任务
    Main,
    Reward,
    Daily
}

//  任务状态
enum TaskState
{
    // 尚未激活
    NoStart,
    // 可接受的任务
    Acceptable,
    // 已接受尚未完成
    Acceptted,
    // 已完成尚未交任务
    Done,
    // 任务完成
    Finish
}

public class Task
{
    #region attribute
    // 任务ID
    private int _id;
    // 任务类型
    private TaskType _type = TaskType.Main;
    // 名称
    private string _taskName;
    // 图标
    private string _icon;
    // 任务描述
    private string _des;
    //  金币奖励
    private int _coinCount;
    // 钻石奖励
    private int _diamondCount;
    // 跟NPC对话内容
    private string _npcTalk;
    // npc id
    private int _npcID;
    // 任务MapID
    private int _mapID;
    // 当前任务状态
    private TaskState _curState = TaskState.NoStart;

    #endregion

    #region Attribute
    public int Id
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    internal TaskType Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public string TaskName
    {
        get
        {
            return _taskName;
        }

        set
        {
            _taskName = value;
        }
    }

    public string Icon
    {
        get
        {
            return _icon;
        }

        set
        {
            _icon = value;
        }
    }

    public string Des
    {
        get
        {
            return _des;
        }

        set
        {
            _des = value;
        }
    }

    public int CoinCount
    {
        get
        {
            return _coinCount;
        }

        set
        {
            _coinCount = value;
        }
    }

    public int DiamondCount
    {
        get
        {
            return _diamondCount;
        }

        set
        {
            _diamondCount = value;
        }
    }

    public string NpcTalk
    {
        get
        {
            return _npcTalk;
        }

        set
        {
            _npcTalk = value;
        }
    }

    public int NpcID
    {
        get
        {
            return _npcID;
        }

        set
        {
            _npcID = value;
        }
    }

    internal TaskState CurState
    {
        get
        {
            return _curState;
        }

        set
        {
            _curState = value;
        }
    }

    public int MapID
    {
        get
        {
            return _mapID;
        }

        set
        {
            _mapID = value;
        }
    }

    #endregion




}
