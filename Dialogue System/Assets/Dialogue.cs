using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tao class NPC Dialogue

[System.Serializable]
public class Dialogue {

    //Ten NPC
	public string name;

    //kick thuoc Text
	[TextArea(3, 10)]
    //cac string hoi thoai( cac cau hoi thoai)
	public string[] sentences;

}
