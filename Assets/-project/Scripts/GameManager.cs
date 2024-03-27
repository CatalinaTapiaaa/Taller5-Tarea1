using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    [Header("Barra Tiempo")]
    public Image bar;
    public float speedTime;
    float t = 100;
    bool apagar;
    [Header("Temblor")]
    public Camera cam;
    public float temblorDuracion;
    bool temblor;
    [Header("Canvas")]
    public GameObject menugameOver;
    public GameObject menuVictory;

    //public Animator aniVictory;



    void Update()
    {
        if (!apagar)
        {
            t -= speedTime * Time.deltaTime;

            if (t < 0)
            {
                GameOver();
                apagar = true;
            }
            if (player.victory)
            {
                Victory();
                apagar = true;
            }


            bar.fillAmount = t / 100;
        }
    }
       


    void Victory()
    {
        StartCoroutine(MenuVictory());
    }
    IEnumerator MenuVictory()
    {
        yield return new WaitForSeconds(3);
        menuVictory.SetActive(true);
    }


    void GameOver()
    {
        StartCoroutine(Tembror());
        player.Muerte();
    }
    IEnumerator Tembror()
    {
        if (temblor)
        {
            yield return null;
        }

        temblor = true;
        Vector3 originalPos = cam.transform.position;
        float temblorCantidad = 0.2f;
        float elapsed = 0;

        while (elapsed < temblorDuracion)
        {
            float x = Random.Range(-1f, 1f) * temblorCantidad;
            float y = Random.Range(-1f, 1f) * temblorCantidad;
            cam.transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cam.transform.localPosition = originalPos;
        temblor = false;
        StartCoroutine(MenuGameOver());
    }
    IEnumerator MenuGameOver()
    {
        yield return new WaitForSeconds(3);
        menugameOver.SetActive(true);
    }
}
