using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class menuManager : MonoBehaviourPunCallbacks
{
    public GameObject menu,joinMenu,hostMenu,tryConnectButton;
    public InputField nickname,roomToJoinName,roomToCreateName;
    public Button joinMenuButton,hostMenuButton,joinMenuPlayButton,hostMenuPlayButton;
    public Text onJoinError,onHostError,menuError;
    public bool conected=false;

    void Update (){
      joinMenuButton.interactable=nickname.text.Length>=3 && conected;
      hostMenuButton.interactable=nickname.text.Length>=3 && conected;
      joinMenuPlayButton.interactable=roomToJoinName.text.Length!=0;
      hostMenuPlayButton.interactable=roomToCreateName.text.Length!=0;

      if (Application.internetReachability == NetworkReachability.NotReachable) {
        menuError.text="can't connect";
        tryConnectButton.SetActive(true);
        conected=false;
      }
    }

    public void tryConnect (){
      PhotonNetwork.ConnectUsingSettings();
      tryConnectButton.SetActive(false);
      Debug.Log("Connecting...");
    }

    void Awake (){
      tryConnect();
    }

    public void joinRoom (){
      PhotonNetwork.JoinRoom(roomToJoinName.text);
    }

    public override void OnJoinedRoom (){
      Debug.Log("joined to room");
      PhotonNetwork.LoadLevel("dress");
    }

    public void createRoom (){
      PhotonNetwork.CreateRoom(roomToCreateName.text);
    }

    public override void OnCreatedRoom (){
      Debug.Log("Room created");
    }

    public override void OnCreateRoomFailed (short returnCode, string msg){
      onHostError.text=msg;
      Debug.Log(msg);
    }

    public override void OnJoinRoomFailed (short returnCode, string msg){
      if (msg=="Game closed") {
        onJoinError.text="The game has already started";
      }else{
        onJoinError.text=msg;
      }

      Debug.Log(msg);
    }

    public override void OnConnectedToMaster (){
      PhotonNetwork.JoinLobby(TypedLobby.Default);
      PhotonNetwork.AutomaticallySyncScene = true;
      conected=true;
      menuError.text="";
      Debug.Log("Connected");
    }

    public void SetNickName (){
      PhotonNetwork.NickName=nickname.text;
      Debug.Log(PhotonNetwork.NickName);
    }

    public void back (){
      joinMenu.SetActive(false);
      hostMenu.SetActive(false);
      menu.SetActive(true);
    }

    public void showJoin (){
      menu.SetActive(false);
      joinMenu.SetActive(true);
    }

    public void showHost (){
      menu.SetActive(false);
      hostMenu.SetActive(true);
    }

    public void quit (){
      Application.Quit();
    }
}
