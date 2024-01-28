using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{
    public TMP_Text objtos;
    private int obTomados;
    // Start is called before the first frame update
    void Start()
    {
        objtos.text = "Objetos: " + 0 + "/2";
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        obTomados += 1;
        objtos.text = "Objetos: " + obTomados + "/2";
    }
}
