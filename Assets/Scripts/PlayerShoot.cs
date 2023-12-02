using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{

    public GameObject DeatEffect;
    public float maxTimeDelay = 1f;
    public float speedView = 1f;

    Vector3 mousPos;
    float timeDelay;
    bool isShoot;
    int kill;

    private void Awake()
    {
        timeDelay= maxTimeDelay;
    }

    void Update()
    {
        Shoot();

    }
    void Shoot()
    {

        Vector3 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        ResetTime();
        if (Input.GetMouseButtonDown(0) && GameControllers.Instance1.isDeslay)
        {
            if (isShoot)
            {
                RayTaget(mousPos);

                isShoot = false;
            }



        }

    }

    void RayTaget(Vector3 mousPos)
    {
        Vector3 shootDir = Camera.main.transform.position - mousPos;
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousPos, shootDir);
        if (hits !=null && hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                if (hit.collider != null && (Vector3.Distance((Vector2)hit.collider.transform.position, (Vector2)mousPos)<=0.4f))
                {
                    if (hit.collider.tag == "Bird")
                    {
                        timeDelay=0;
                        Audios.Instance.PlayShoot();
                        kill++;

                        Destroy(hit.collider.gameObject);
                        UisManager.Instance.SetKillTx("x"+kill);
                        if (DeatEffect)
                        {
                            GameObject obj = Instantiate(DeatEffect, mousPos, Quaternion.identity);//hieu ung mau
                            Destroy(obj, 2f);
                        }

                    }
                }

            }

        }
    }
    private void ResetTime()
    {
        timeDelay +=Time.deltaTime;
        if (timeDelay >= maxTimeDelay)
        {
            isShoot = true;



        }
    }

}
