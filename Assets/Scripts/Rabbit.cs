using System.Collections;
using UnityEngine;

public class Rabbit : MonoBehaviour
{
    public bool invincibility;
    Material rabbit;

    void Start()
    {
        rabbit = GetComponent<Renderer>().material;
        invincibility = false;
    }
    public void Sparkle()
    {
        StartCoroutine("Blink");
    }
    IEnumerator Blink()
    {
        invincibility = true;
        for (int i = 0; i < 2; i++)
        {
            rabbit.color = new Color32(255, 140, 140, 255);
            yield return new WaitForSeconds(0.25f);
            rabbit.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.25f);
        }
        rabbit.color = new Color32(255, 255, 255, 255);
        invincibility = false;
    }
}
