using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterData : MonoBehaviour
{
  public dressManager dm;
  public Sprite[] sprites;
  public int spriteNumber;

  public void Start(){
    GameObject[] go=GameObject.FindGameObjectsWithTag("data");
    if (go[0]!=this.gameObject) {
      dm.oldCd=go[0].GetComponent<characterData>();
    }else if(go.Length>1){
      dm.oldCd=go[1].GetComponent<characterData>();
    }else{
      dm.oldCd=GetComponent<characterData>();
    }

    foreach (GameObject dataObj in go) {
      if (dataObj!=this.gameObject) {
        Destroy(dataObj);
      }
    }
    DontDestroyOnLoad(this.gameObject);
  }
}
