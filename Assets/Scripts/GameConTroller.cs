using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameConTroller : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameConTroller instance;

    public static GameConTroller Instance { get => instance; set => instance=value; }
    public GameObject menuPn;
    public Text diemTxt;
    private void Awake()
    {
        InsGameCtl();
    }

   
    void InsGameCtl()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void EndGame()
    {
        if (menuPn != null)
        {
            menuPn.SetActive(true);
        }
      
    }
    public void ResetScene()
    {

        if (menuPn != null)
        {
            menuPn.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    public void CongDiem(int diem)
    {
        
        diemTxt.text = "Point: " + diem.ToString();
    }    
}
