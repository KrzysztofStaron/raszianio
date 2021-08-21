using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class gameController : MonoBehaviourPunCallbacks
{
    public Sprite[] sprites;

    public void Start(){
        GameObject characterDataObj=GameObject.FindGameObjectWithTag("data");
        sprites=characterDataObj.GetComponent<characterData>().sprites;
    }

    [PunRPC]
    public void addCharacter(string nick, int index)
    {
      GameObject.Find(nick).GetComponent<move>().actualPlayer.GetComponent<SpriteRenderer>().sprite=sprites[index];
    }
}
