using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour {

    public static NpcManager instance;

    public GameObject[] npcs;

    private Dictionary<int, GameObject> npcDic = new Dictionary<int, GameObject>();

	// Use this for initialization
	void Awake ()
    {
        instance = this;

        init();

    }
	
	// 初始化NPC列表
	void init ()
    {
        foreach (GameObject go in npcs)
        {
            int id = int.Parse(go.name.Substring(0, 4));
            npcDic.Add(id, go);
        }
	}

    //  获取NPC
    public GameObject getNpc(int id)
    {
        GameObject go = null;

        npcDic.TryGetValue(id, out go);

        return go;
    }

}
