using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBehaviourScript: MonoBehaviour {
    public GameObject TopPanel;
    public GameObject BottomPanel;
  public GameObject WaveHigher;
  public GameObject WaveLower;
  void Start() {
    WaveLower.SetActive(false);
    WaveHigher.SetActive(false);
  }


    // Update is called once per frame
    void Update() {

    }

    enum slideVector {
        nullVector,
        up,
        down,
        left,
        right
    };
    private Vector2 touchFirst = Vector2.zero; //手指开始按下的位置  
    private Vector2 touchSecond = Vector2.zero; //手指拖动的位置  
    private slideVector currentVector = slideVector.nullVector; //当前滑动方向  
    private float timer; //时间计数器    
    public float offsetTime = 0.1f; //判断的时间间隔   
    public float SlidingDistance = 80f;

    
    void OnGUI() // 滑动方法02  
    {
        if (Event.current.type == EventType.MouseDown)
        //判断当前手指是按下事件   
        {
            touchFirst = Event.current.mousePosition; //记录开始按下的位置  
        }
        if (Event.current.type == EventType.MouseDrag)
        //判断当前手指是拖动事件  
        {
            touchSecond = Event.current.mousePosition;

            timer += Time.deltaTime; //计时器  

            if (timer > offsetTime) {
                touchSecond = Event.current.mousePosition; //记录结束下的位置  
                Vector2 slideDirection = touchFirst - touchSecond;
                float x = slideDirection.x;
                float y = slideDirection.y;
               
                if (y + SlidingDistance < x && y > -x - SlidingDistance) {

                    if (currentVector == slideVector.left) {
                        return;
                    }

                    Debug.Log("right");

                    currentVector = slideVector.left;
                } else if (y > x + SlidingDistance && y < -x - SlidingDistance) {
                    if (currentVector == slideVector.right) {
                        return;
                    }

                    Debug.Log("left");

                    currentVector = slideVector.right;
                } else if (y > x + SlidingDistance && y - SlidingDistance > -x) {
                    if (currentVector == slideVector.up) {
                        return;
                    }

                    Debug.Log("up");

                    currentVector = slideVector.up;

                    TopPanel.GetComponent<CanvasGroup>().alpha = 0;
                    TopPanel.GetComponent<CanvasGroup>().interactable = false;
                    TopPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

                    BottomPanel.GetComponent<CanvasGroup>().alpha = 0;
                    BottomPanel.GetComponent<CanvasGroup>().interactable = false;
                    BottomPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

                } else if (y + SlidingDistance < x && y < -x - SlidingDistance) {
                    if (currentVector == slideVector.down) {
                        return;
                    }

                    Debug.Log("Down");

                    currentVector = slideVector.down;

                    TopPanel.GetComponent<CanvasGroup>().alpha = 1;
                    TopPanel.GetComponent<CanvasGroup>().interactable = true;
                    TopPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;

                    BottomPanel.GetComponent<CanvasGroup>().alpha = 1;
                    BottomPanel.GetComponent<CanvasGroup>().interactable = true;
                    BottomPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                }

                timer = 0;
                touchFirst = touchSecond;
            }
            if (Event.current.type == EventType.MouseUp) { //滑动结束    
                currentVector = slideVector.nullVector;
            }
        } // 滑动方法  
    }
}