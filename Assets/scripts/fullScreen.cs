using UnityEngine;

public class fullScreen : MonoBehaviour
{
  void Start(){
    DontDestroyOnLoad(this.gameObject);
  }

    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape)) {
        Screen.fullScreen = !Screen.fullScreen;
      }
    }
}
