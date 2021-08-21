using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class move : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed;
  public Vector2 mousepos;
  public GameObject playerCam, nickObj;
  public PhotonView pv;
  public Text nickNameText,pingText;
  public Camera cam;
  public GameObject actualPlayer;

  public void Awake(){
    if (pv.IsMine) {
      playerCam.SetActive (true);
      nickNameText.text = PhotonNetwork.NickName;
      GameObject cd = GameObject.FindGameObjectWithTag("data");
      actualPlayer.GetComponent<SpriteRenderer>().sprite=cd.GetComponent<characterData>().sprites[cd.GetComponent<characterData>().spriteNumber];
      GameObject.Find("GameManager").GetComponent<gameController>().sprites = cd.GetComponent<characterData>().sprites;
      GameObject.Find("GameManager").GetComponent<PhotonView>().RPC("addCharacter", RpcTarget.Others, PhotonNetwork.NickName, cd.GetComponent<characterData>().spriteNumber);
    }else{
      nickNameText.text=pv.Owner.NickName;
    }
    gameObject.name=nickNameText.text;
}

void Update ()
{
  if (pv.IsMine) {
    pingText.text = "Ping: "+PhotonNetwork.GetPing();
    mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
    float angle=Mathf.Atan2(mousepos.y - rb.position.y, mousepos.x - rb.position.x) * Mathf.Rad2Deg - 90;
    actualPlayer.transform.rotation = Quaternion.Euler(0,0,angle);
  }
}

void FixedUpdate()
 {
  if (pv.IsMine) {
    rb.MovePosition (transform.position + new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"), 0) * speed * Time.deltaTime);
  }
 }
}
