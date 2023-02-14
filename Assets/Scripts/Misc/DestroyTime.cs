using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{

    public int destroyTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenDie());
    }
    IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }


}
