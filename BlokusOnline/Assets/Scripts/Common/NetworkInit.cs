using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;


public class NetworkInit : MonoBehaviour {

    // Use this for initialization
    void Start() {
        NetManager.Instance.show();
        Debug.Log("after instance");
    }

   

   // public void OnClick() {
   //    // NetManager.Instance.show();
   //     NetManager.Instance.TransferMessage("");
   // }

  


   //public void jumpScene() {
   //     Application.LoadLevel("two");
   // }

}
