using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Server...", this);
        //AuthenticationValues authValues = new AuthenticationValues("0")
        //PhotonNetwork.AuthValues = authValues;
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server", this);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        if (!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnet from Server for " + cause.ToString(), this);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby", this);
    }
}
