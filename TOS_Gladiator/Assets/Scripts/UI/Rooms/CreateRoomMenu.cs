using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    public Text _roomName;

    private RoomsCanvases _roomsCanavases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanavases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, null);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created " + _roomName.text, this);
        _roomsCanavases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: " + message, this);
    }

}
