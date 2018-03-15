﻿

class OperationCode {

    public const short CHECK_VERSION = 1;

    public const short LOGIN = 2;

    public const short CREATE_ROOM = 3;

    public const short JOIN_ROOM = 4;

    public const short LEAVE_ROOM = 5;

    public const short READY = 6;

    public const short CHESS_DONE = 7;

    public const short UPDATE_ROOM_PLAYERS_INFO = 8;

    public const short CHOOSE_COLOR = 9;

    public const short START_BLOKUS = 10;

    public const short START_BLOKUS_TWO_PEOPLE = 11;

    public const short WIN = 12;

    public const short LOSE = 13;

    public const short GIVE_UP = 14;

    public const short CHAT_IN_GAME = 15;

    public const short ROOM_LIST = 16;

    public const short REGISTER = 17;

    public const short RANK_INFO = 18;

    public const short PROFILE = 19;

    public const short CHAT_IN_ROOM = 20;

    public const short INIT_PLAYER_INFO_IN_GAME = 22;

    public const short LOGOUT = 23;





    public const short HEARTBEAT = 10000;

    public const short CONNECT_SUCCESS = 10001;

    public const short DISCONNECT = 10002;
}

