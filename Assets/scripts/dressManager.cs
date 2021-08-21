using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dressManager : MonoBehaviour
{
  public Sprite[] characters;
  public int curentSprite;
  public Image characterLook;
  public characterData cd,oldCd;

  void Start(){
    cd.sprites=characters;
    cd.spriteNumber=curentSprite;
    curentSprite=oldCd.spriteNumber;
    characterLook.sprite=characters[curentSprite];
    cd.sprites=characters;
    cd.spriteNumber=curentSprite;
  }

  public void hange(int count){
    curentSprite+=count;
    if (curentSprite<0) {
      curentSprite=characters.Length-1;
    }else if(curentSprite>characters.Length-1){
      curentSprite=0;
    }
    characterLook.sprite=characters[curentSprite];
    cd.sprites=characters;
    cd.spriteNumber=curentSprite;
  }

  public void Back(){
    SceneManager.LoadScene("lobby");
  }
}
