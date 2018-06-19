using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextScreenController : MonoBehaviour {

    private string[] myText = new string[15];
    int last = -1;
    int current = 0;
    float speed = 0.3f;

	void Start () {
        myText[0] = "发声体产生的振动在空气或其他物质中的传播叫做声波";
        myText[1] = "声波借助各种介质向四面八方传播";
        myText[2] = "声波通常是纵波，也有横波";
        myText[3] = "声波所到之处的质点沿着传播方向在平衡位置附近振动";
        myText[4] = "声波的传播实质上是能量在介质中的传递";
        myText[5] = "在两个或更多声波相遇时";
        myText[6] = "它们会彼此相加或减去";
        myText[7] = "相互影响叠加";
        myText[8] = "这种现象称为波的干涉";
        myText[9] = "如果它们的波峰和波谷完全同相";
        myText[10] = "则互相加强";
        myText[11] = "因此产生的波形的振幅高于任何单个波形的振幅";
        myText[12] = "如果两个波形的波峰和波谷完全异相";
        myText[13] = "则会相互抵消";
        myText[14] = "导致完全没有波形";
    }
	
	void Update () {
        current = (int)Math.Floor(Time.fixedTime * speed);
        if (current != last && current < myText.Length) {
            last = current;
            this.gameObject.GetComponent<Text>().text = myText[current];
        }
        else if (current >= myText.Length)
            this.gameObject.GetComponent<Text>().text = "开始你的自由操作吧！";
    }
}
