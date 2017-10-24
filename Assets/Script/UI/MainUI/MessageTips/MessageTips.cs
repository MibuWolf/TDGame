using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTips : MonoBehaviour {

    public static MessageTips instance;

    private UILabel lbMsg;
    private TweenAlpha twAlpha;
    private TweenPosition twPosition;

    private bool bForward = true;
    private void Awake()
    {
        instance = this;

        lbMsg = this.transform.Find("message").GetComponent<UILabel>();
        twAlpha = this.GetComponent<TweenAlpha>();
        twPosition = this.GetComponent<TweenPosition>();

        EventDelegate ev = new EventDelegate(this, "onFinished");
        twPosition.onFinished.Add(ev);

        gameObject.SetActive(false);
    }


    public void showMessage(string msg)
    {
        gameObject.SetActive(true);
        StartCoroutine(playMessage(msg));
    }


    private IEnumerator playMessage(string msg)
    {
        lbMsg.text = msg;
        twPosition.PlayForward();
        twAlpha.PlayForward();
        bForward = true;

        yield return new WaitForSeconds(1);

        bForward = false;
        twPosition.PlayReverse();
        twAlpha.PlayReverse();
    }


    private void onFinished()
    {
        if(!bForward)
            this.gameObject.SetActive(false);
    }

}
