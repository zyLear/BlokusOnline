using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System;
using protos.blokus;

public class NetManager : Singleton<NetManager> {

    private string ip = "127.0.0.1"; //172.19.56.1    172.19.87.1   127.0.0.1  111.231.66.159
    private int port = 9090;
    private Socket client;
    //public Queue<string> messageQueue = new Queue<string>();
    private Thread startupThread;


    private void NetworkStartup() {
        if (startupThread != null) {
            startupThread.Abort();
        }
        startupThread = new Thread(Connect);
        startupThread.Start();
    }

    public void Start() {

        NetworkStartup();
    }


    public void TransferMessage(MessageBean message) {
        if (client != null) {
            client.Send(CodeUtil.encode(message));
        }
    }


    private void Connect() {
        try {
            Debug.Log("connecting");
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress iPAddress = IPAddress.Parse(ip);
            EndPoint endPoint = new IPEndPoint(iPAddress, port);
            client.Connect(endPoint);
            int retryCount = 5;
            while (retryCount-- > 0) {
                if (client.Connected) {
                    Debug.Log("connected!");
                    // TransferMessage();
                    connectSuccess();
                    break;
                }
                Thread.Sleep(5 * 1000);
                client.Connect(endPoint);
            }
        } catch (Exception e) {
            //TODO
            Debug.Log(e);
            Debug.Log("connecte to server fail");
            disconnect();
            return;
        }

        try {
            //Thread.Sleep(5 * 1000);
            while (true) {
                byte[] data = new byte[1024];
                int length = client.Receive(data);
                //string message = Encoding.UTF8.GetString(data);
                //string[] messages = message.Split('\n');
                //for (int i = 0; i < messages.Length - 1; i++) {
                //    messageQueue.Enqueue(messages[i]);
                //}
                if (length != 0) {
                    List<MessageBean> messages = CodeUtil.decode(data, length);
                    Debug.Log("message size:" + messages.Count);
                    MessageQueue.put(messages);
                }

                Thread.Sleep(50);

            }
        } catch {
            //TODO
            Debug.Log("receive message error");
            disconnect();
            //   GameObject.Find("UIController").SendMessage("","");


        }
    }

    private void connectSuccess() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CONNECT_SUCCESS;
        message.statusCode = StatusCode.SUCCESS;
        List<MessageBean> list = new List<MessageBean>();
        list.Add(message);
        MessageQueue.put(list);
    }

    private void disconnect() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.DISCONNECT;
        message.statusCode = StatusCode.SUCCESS;
        List<MessageBean> list = new List<MessageBean>();
        list.Add(message);
        MessageQueue.put(list);
    }




    //private void handleMessage(string message) {

    //    TODO

    //    try {
    //        Debug.Log(message);
    //        GameObject.Find("UIController").GetComponent<Text>().text = message;
    //    } catch {
    //        Debug.Log("set text fail");
    //    }

    //}


    ////发送消息
    //public void TransferMessage(string message) {
    //    if (client != null && client.Connected) {
    //        //client.Send(Encoding.UTF8.GetBytes("hello!I'm from unity\n"));
    //    }
    //}

    //public void TransferMessage() {

    //    BLOKUSAccount account = new BLOKUSAccount();
    //    account.account = "csharpAccount";
    //    account.password = "csharpPassword";

    //    MessageBean message = new MessageBean();
    //    message.operationCode = 2;
    //    message.statusCode = 0;
    //    message.data = ProtobufHelper.SerializerToBytes(account);
    //    Debug.Log(message.data);
    //    client.Send(CodeUtil.encode(message));

    //}



    // Update is called once per frame
    void Update() {

        MessageBean message = MessageQueue.take();
        if (message != null) {
            try {
                handleMessage(message);
            } catch (Exception e) {
            }
        }

    }

    private void OnDestroy() {
        if (client != null) {
            client.Close();
        }
    }

    private void handleMessage(MessageBean message) {

        Debug.Log("enter");

        switch (message.operationCode) {
            case OperationCode.CONNECT_SUCCESS: connectSuccess(message); break;
            case OperationCode.DISCONNECT: disconnect(message); break;
            case OperationCode.LOGIN: login(message); break;
            case OperationCode.CREATE_ROOM: createRoom(message); break;
            case OperationCode.UPDATE_ROOM_PLAYERS_INFO: updateRoomPlayersInfo(message); break;
            case OperationCode.JOIN_ROOM: joinRoom(message); break;
            case OperationCode.START_BLOKUS: startBlokus(message); break;
            case OperationCode.CHESS_DONE: chessDone(message); break;
            case OperationCode.GIVE_UP: giveUp(message); break;
            case OperationCode.CHAT_IN_GAME: chatInGame(message); break;
            case OperationCode.ROOM_LIST: RoomList(message); break;
            case OperationCode.REGISTER: register(message); break;
            case OperationCode.RANK_INFO: rankInfo(message); break;


            default: break;
        }
    }

    private void disconnect(MessageBean message) {
        GameObject.Find("UIController").GetComponent<UIController>().SendMessage("showOffline");
    }

    private void rankInfo(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSRankInfo bLOKUSRankInfo = ProtobufHelper.DederializerFromBytes<BLOKUSRankInfo>(message.data);
            GameObject.Find("UIController").SendMessage("updateRankInfo", bLOKUSRankInfo);
        }
    }

    private void register(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            GameObject.Find("UIController").SendMessage("registerSuccess");
        } else {
            GameObject.Find("UIController").SendMessage("registerFail");
        }
    }

    private void RoomList(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSRoomList bLOKUSRoomList = ProtobufHelper.DederializerFromBytes<BLOKUSRoomList>(message.data);
            GameObject.Find("UIController").SendMessage("OnRoomListUpdate", bLOKUSRoomList);
        }
    }

    private void chatInGame(MessageBean message) {

        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSChatMessage bLOKUSChatMessage = ProtobufHelper.DederializerFromBytes<BLOKUSChatMessage>(message.data);
            GameObject.Find("BlokusUIController").SendMessage("chatInGame", bLOKUSChatMessage.chatMessage);
        }

    }

    private void giveUp(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSChooseColor bLOKUSChooseColor = ProtobufHelper.DederializerFromBytes<BLOKUSChooseColor>(message.data);
            GameObject.Find("BlokusUIController").SendMessage("lose", bLOKUSChooseColor.color);
        }
    }

    private void chessDone(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSChessDoneInfo bLOKUSChessDoneInfo = ProtobufHelper.DederializerFromBytes<BLOKUSChessDoneInfo>(message.data);
            GameObject.Find("BlokusController").SendMessage("chessDone", bLOKUSChessDoneInfo);
        }
    }

    private void startBlokus(MessageBean message) {
        if (message.statusCode == StatusCode.SUCCESS) {
            GameObject.Find("BlokusRoomUIController").SendMessage("StartBlokus");
        } else {
            //GameObject.Find("UIController").SendMessage("createRoomFail");
        }
    }

    private void joinRoom(MessageBean message) {
        BLOKUSCreateRoom room = ProtobufHelper.DederializerFromBytes<BLOKUSCreateRoom>(message.data);
        if (message.statusCode == StatusCode.SUCCESS) {
            GameCache.roomName = room.roomName;
            GameCache.roomType = room.roomType;
            GameCache.isInRoom = true;
            GameObject.Find("UIController").SendMessage("joinRoomSuccess");
        } else {
            //GameObject.Find("UIController").SendMessage("createRoomFail");
        }
    }

    private void updateRoomPlayersInfo(MessageBean message) {
        BLOKUSRoomPlayerList bLOKUSRoomPlayerList = ProtobufHelper.DederializerFromBytes<BLOKUSRoomPlayerList>(message.data);
        GameObject.Find("BlokusRoomUIController").SendMessage("updateRoomPlayersInfo", bLOKUSRoomPlayerList);
    }

    private void connectSuccess(MessageBean message) {
        GameObject.Find("UIController").SendMessage("hidePanel", GameObject.Find("ConnectionPanel").transform);
        GameObject.Find("UIController").SendMessage("showPanel", GameObject.Find("LoginPanel").transform);
    }

    private void login(MessageBean message) {
        //Debug.Log(message.operationCode);
        //Debug.Log(message.statusCode);
        //Debug.Log(message.data);

        if (message.statusCode == StatusCode.SUCCESS) {
            BLOKUSAccount account = ProtobufHelper.DederializerFromBytes<BLOKUSAccount>(message.data);
            GameCache.account = account.account;
            GameObject.Find("UIController").SendMessage("hidePanel", GameObject.Find("LoginPanel").transform);
            GameObject.Find("UIController").SendMessage("showPanel", GameObject.Find("RoomListPanel").transform);
        } else {
            //GameObject.Find("UIController").SendMessage("show", "login fail!");
        }

    }

    private void createRoom(MessageBean message) {
        BLOKUSCreateRoom room = ProtobufHelper.DederializerFromBytes<BLOKUSCreateRoom>(message.data);
        if (message.statusCode == StatusCode.SUCCESS) {
            GameCache.roomName = room.roomName;
            GameCache.roomType = room.roomType;
            GameCache.isInRoom = true;
            GameObject.Find("UIController").SendMessage("createRoomSuccess");
        } else {
            GameObject.Find("UIController").SendMessage("createRoomFail");
        }
    }


    public void show() {
        print("BlokusOnline");
    }

}
