using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class networkThinks : MonoBehaviourPunCallbacks
{
    public override void OnPlayerLeftRoom (Player otherPlayer){
      if (otherPlayer.IsMasterClient) {
        PhotonNetwork.SetMasterClient(PhotonNetwork.PlayerList[0]);
      }
      Destroy(GameObject.Find(otherPlayer.NickName));
    }
}
