using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class spawnPlayer : MonoBehaviour
{
  public GameObject playerPrefub;
  public GameObject sceneCamera;

    void Awake()
    {
      GameObject newPlayer = PhotonNetwork.Instantiate(playerPrefub.name, new Vector2(Random.Range(-2, 2),Random.Range(-2, 2)),Quaternion.identity, 0);
      sceneCamera.SetActive(false);
    }
}
