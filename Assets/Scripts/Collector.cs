using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Collector : MonoBehaviour
{
    public TMP_Text objtos;
    public LevelItemsController itemsController;
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
        itemsController.TomarItem();
        objtos.text = "Objetos: " + itemsController.ItemsTomados + "/2";
    }
}
