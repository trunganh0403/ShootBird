using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GameControllers : MonoBehaviour
{
    public GameObject[] birdPrefab;
    public float minY;
    public float maxY;
    public float maxtimeGame;
    public bool isDeslay;

    float timeGame;
    float maxTime;
    float time;
    bool isSpawm;
    
    // Dialog dialog;
    private static GameControllers instance; // private static + tên classs + tên biến instance;

    public static GameControllers Instance1 { get => instance; } // getter cho bên ngoài sử dụng Instance1 == instance1

    private void Awake()
    {
        MakeSingleton();
        time=maxTime;
        timeGame = maxtimeGame;
        isDeslay = false;


    }
    private void Start()
    {
        // dialog = GetComponent<Dialog>();
    }
    private void Update()
    {
      

        DelayTime();
        SpamwBir();
        GameOver();
        UisManager.Instance.Setfilled(timeGame/maxtimeGame);


    }

  

    void SpamwBir()
    {
        if (birdPrefab.Length > 0 && birdPrefab !=null && isSpawm)
        {
            time = maxTime;
            isSpawm = false;
            Vector3 tager = Vector3.zero;
            int ranDomInt = Random.Range(0, 2);
            int ranDomBird = Random.Range(0, 2);

            if (ranDomInt == 0)
            {
                tager = new Vector3(12f, Random.Range(minY, maxY), tager.z);
                GameObject obj = Instantiate(birdPrefab[ranDomBird], tager, Quaternion.identity);
                obj.tag = "Bird";
            }
            if (ranDomInt == 1)
            {
                tager = new Vector3(-12f, Random.Range(minY, maxY), tager.z);
                GameObject obj = Instantiate(birdPrefab[ranDomBird], tager, Quaternion.identity);
                obj.tag = "Bird";
            }

        }
    }
    void DelayTime()//delay time spam bird
    {
        if (isDeslay)
        {
            maxTime = Random.Range(0, 3f);
            time -= Time.deltaTime;
            if (time < 0)
            {
                isSpawm = true;
            }

        }


    }

    IEnumerator ResetTimeGame() // time game
    {
        yield return new WaitForSeconds(1);


        timeGame--;
        UisManager.Instance.SetTime("00 : " + timeGame);
        
        StartCoroutine(ResetTimeGame());


    }
    public void StatBtClik()
    {
        isDeslay= true;
        UisManager.Instance.ShowHomePn(false);
        StartCoroutine(ResetTimeGame());

    }


    void MakeSingleton()
    {
        if (instance == null)// kiểm tra instance có phải là duy nhất k 
        {
            instance = this;// gán biến này bằng toàn bộ class này
        }

    }
    public void GameOver()
    {
        if (timeGame <= 0)
        {
            
            isDeslay = false;
            
            UisManager.Instance.SetTime("00 : 00");
            UisManager.Instance.gameDialog.SetTex("Game Over", "Game Over");
            UisManager.Instance.gameDialog.Show(true);
         
        }

    }

}    





