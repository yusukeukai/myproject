using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * カメラのｚ位置とtransform(自分自身)のz位置を比較して、もしカメラの位置よりtransformが後ろに行ったらDestroy(自分自身);
         */
        if (transform.localPosition.z < Camera.main.transform.localPosition.z)
        {
            Destroy(this.gameObject);
        }
    }
}
