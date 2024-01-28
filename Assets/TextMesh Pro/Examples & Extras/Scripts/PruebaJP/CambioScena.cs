using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioScena : MonoBehaviour
{
    public void Scene()
    {
        GameManager.Instance.ChangeScene(1,true);
    }
}
