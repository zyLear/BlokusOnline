using protos.blokus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MessageFormater {

    public static MessageBean createRoom(string roomName, int gameType) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CREATE_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSCreateRoom bLOKUSCreateRoom = new BLOKUSCreateRoom();
        bLOKUSCreateRoom.roomName = roomName;
        bLOKUSCreateRoom.gameType = gameType;

        message.data = ProtobufHelper.SerializerToBytes(bLOKUSCreateRoom);
        return message;
    }

    public static MessageBean chooseColor(string account, string roomName, int color) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHOOSE_COLOR;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSColor bLOKUSColor = new BLOKUSColor();
        //bLOKUSColor.account = account;
        //bLOKUSColor.roomName = roomName;
        bLOKUSColor.color = color;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSColor);
        return message;
    }

    public static MessageBean formatLoginMessage(string accountText, string password) {
        BLOKUSAccount account = new BLOKUSAccount();
        account.account = accountText;
        account.password = password;

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LOGIN;
        message.statusCode = StatusCode.SUCCESS;
        message.data = ProtobufHelper.SerializerToBytes(account);
        return message;
    }

    public static MessageBean formatHeartbeatMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.HEARTBEAT;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatInitPlayerInfoInGameMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.INIT_PLAYER_INFO_IN_GAME;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatLeaveRoomMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LEAVE_ROOM;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatReadyMessage(string account, string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.READY;
        message.statusCode = StatusCode.SUCCESS;

        //BLOKUSChooseColor bLOKUSChooseColor = new BLOKUSChooseColor();
        //bLOKUSChooseColor.account = account;
        //bLOKUSChooseColor.roomName = roomName;
        //message.data = ProtobufHelper.SerializerToBytes(bLOKUSChooseColor);
        return message;
    }

    public static MessageBean formatWinMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.WIN;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatJoinRoomMessage(string roomName) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.JOIN_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSRoomName bLOKUSRoomName = new BLOKUSRoomName();
        bLOKUSRoomName.roomName = roomName;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSRoomName);
        return message;
    }

    public static MessageBean formatLoseMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LOSE;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatRoomListMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.ROOM_LIST;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }

    public static MessageBean formatCheckVersionMessage(string version) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHECK_VERSION;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSVersion bLOKUSVersion = new BLOKUSVersion();
        bLOKUSVersion.version = version;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSVersion);
        return message;
    }

    public static MessageBean formatChessDoneMessage(BLOKUSChessDoneInfo chessDoneInfoTemp) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHESS_DONE;
        message.statusCode = StatusCode.SUCCESS;
        message.data = ProtobufHelper.SerializerToBytes(chessDoneInfoTemp);
        return message;
    }

    public static MessageBean formatChessDoneMessage(int x, int y, string currentSquareName, int rotationFlag, int symmetryFlag, int[,] model) {

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHESS_DONE;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChessDoneInfo chessDoneInfo = new BLOKUSChessDoneInfo();
        chessDoneInfo.x = x;
        chessDoneInfo.y = y;
        chessDoneInfo.squareName = currentSquareName;
        chessDoneInfo.rotationFlag = rotationFlag;
        chessDoneInfo.symmetryFlag = symmetryFlag;
        chessDoneInfo.model = getModelBytes(model);
        message.data = ProtobufHelper.SerializerToBytes(chessDoneInfo);
        return message;
    }

    public static MessageBean formatGiveUpMessage(int myColor) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.GIVE_UP;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSColor bLOKUSColor = new BLOKUSColor();
        bLOKUSColor.color = myColor;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSColor);
        return message;
    }

    public static MessageBean formatChatInGameMessage(string str) {

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHAT_IN_GAME;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChatMessage bLOKUSChatMessage = new BLOKUSChatMessage();
        bLOKUSChatMessage.chatMessage = str;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSChatMessage);
        return message;

    }

    internal static MessageBean formatChatInRoomMessage(string str) {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.CHAT_IN_ROOM;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSChatMessage bLOKUSChatMessage = new BLOKUSChatMessage();
        bLOKUSChatMessage.chatMessage = str;
        message.data = ProtobufHelper.SerializerToBytes(bLOKUSChatMessage);
        return message;
    }

    internal static MessageBean formatRegisterMessage(string account, string password) {

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.REGISTER;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSGameAccount gameAccount = new BLOKUSGameAccount();
        gameAccount.account = account;
        gameAccount.password = password;
        message.data = ProtobufHelper.SerializerToBytes(gameAccount);
        return message;
    }


    public static MessageBean formatRankInfoMessagae() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.RANK_INFO;
        message.statusCode = StatusCode.SUCCESS;

        return message;
    }


    public static MessageBean formatProfileMessage(string account) {

        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.PROFILE;
        message.statusCode = StatusCode.SUCCESS;

        BLOKUSGameAccount gameAccount = new BLOKUSGameAccount();
        gameAccount.account = account;
        message.data = ProtobufHelper.SerializerToBytes(gameAccount);
        return message;
    }


    internal static MessageBean formatLogoutMessage() {
        MessageBean message = new MessageBean();
        message.operationCode = OperationCode.LOGOUT;
        message.statusCode = StatusCode.SUCCESS;
        return message;
    }




    private static byte[] getModelBytes(int[,] model) {
        byte[] modelBytes = new byte[25];

        for (int i = 0; i < 25; i++) {
            modelBytes[i] = (byte)model[i / 5, i % 5];
        }

        return modelBytes;
    }


}

