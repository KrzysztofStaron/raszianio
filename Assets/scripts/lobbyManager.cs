using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class lobbyManager : MonoBehaviourPunCallbacks
{
   public Player[] playersList;
   public List<GameObject> playersGameObjects;
   public GameObject player,startGame;
   public Transform playerListTransform;

   void Awake(){
     if (GameObject.FindGameObjectWithTag("data")==null) {
       Dress();
     }
     playersList = PhotonNetwork.PlayerList;
     generateList();
   }

   void Start(){
     playersList = PhotonNetwork.PlayerList;
     generateList();
   }

   public override void OnPlayerEnteredRoom (Player newPlayer){
     playersList = PhotonNetwork.PlayerList;
     generateList();
     Debug.Log(newPlayer.NickName+" Join");
   }

   public override void OnPlayerLeftRoom (Player otherPlayer){
     playersList = PhotonNetwork.PlayerList;
     if (otherPlayer.IsMasterClient) {
       PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
     }
     generateList();
     Debug.Log(otherPlayer.NickName+" Leave");
   }

   void generateList(){
     startGame.SetActive(PhotonNetwork.IsMasterClient);
     foreach (GameObject payerObj in playersGameObjects) {
       Destroy(payerObj);
     }
     playersGameObjects.Clear();
     for (int i=0; i<playersList.Length; i++) {
       GameObject newPlayer = Instantiate (player, new Vector3(0,0-i*55, 0) , Quaternion.identity);
       newPlayer.transform.SetParent(playerListTransform);
       newPlayer.GetComponent<textInPlayer>().txt.text=playersList[i].NickName;
       newPlayer.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
       newPlayer.GetComponent<RectTransform>().anchoredPosition=new Vector3(0,0-i*55, 0);
       playersGameObjects.Add(newPlayer);
     }
   }

  public void SartGame(){
    PhotonNetwork.CurrentRoom.IsOpen = false;
    PhotonNetwork.LoadLevel("game");
  }

  public void Dress (){
    SceneManager.LoadScene("dress");
  }
}
