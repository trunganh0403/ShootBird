using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UisManager : MonoBehaviour
{
    private static UisManager instance; // private static + tên classs + tên biến instance;
    public static UisManager Instance { get => instance; set => instance=value; }


    public GameObject homePn;
    public GameObject gamePn;
    public Dialog gameDialog;
    public Dialog gamePaus;


    public Text timeTx;
    public Text killTx;
    public Image filled;


    private void Awake()
    {
        MakeSingleton();



    }


    void MakeSingleton()
    {
        if (instance == null)// kiểm tra instance có phải là duy nhất k 
            instance = this;// gán biến này bằng toàn bộ class này
        else // nếu có 2 báo lỗi
        {
            Debug.Log("lỗi");
        }
    }
    public void ShowHomePn(bool isShow)
    {
        if (homePn != null)
        {
            homePn.SetActive(isShow);
        }
        if (gamePn != null)
        {
            gamePn.SetActive(!isShow);
        }
    }
    public void SetTime(string time)//tgian game
    {
        if (timeTx != null)
        {

            timeTx.text = time;

        }
    }
    public void SetKillTx(string kill)//kill game
    {
        if (killTx != null)
        {

            killTx.text = kill;

        }
    }
    public void Setfilled(float fill)//kill game
    {
        if (filled != null)
        {

            filled.fillAmount = fill;

        }
    }
    public void PausGame()
    {
        Time.timeScale = 0;
        if (gamePaus != null)
        {
            gamePaus.Show(true);
        }
    }
    public void ResumeBt()//tiep tuc
    {
        Time.timeScale = 1;
        if (gamePaus != null)
        {
            gamePaus.Show(false);
        }
    }
    public void ReplayBt()//choi lai
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    public void HomeBt()
    {
        ResumeBt();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitBt()
    {
        Application.Quit();
    }



}
