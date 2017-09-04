using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectRole : MonoBehaviour {


    public void OnPress(bool ispress)
    {
        if (ispress)
            StartGameUI.instance.onRoleSelected(transform.parent.gameObject);
    }

}
