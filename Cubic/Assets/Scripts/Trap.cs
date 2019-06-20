using System.Collections;
using UnityEngine;


public class Trap : MonoBehaviour
{
    public float delayTime;
    private Animation anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        while (true)
        {
            anim.Play();
            yield return new WaitForSeconds(delayTime);
        }
    }
}
