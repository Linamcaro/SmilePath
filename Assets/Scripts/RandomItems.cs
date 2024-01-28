using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItems : MonoBehaviour
{

    public GameObject[] items = new GameObject[8];
    public Transform[] positions = new Transform[8];
    
 


    // Start is called before the first frame update


    private void Awake()
    {
     
    }
    void Start() 
    {
        RandomItemsGen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomItemsGen()
    {
        int[] listItems = new int[items.Length];
        int[] listpositions = new int[this.positions.Length];

        for (int conPos = 0;conPos < listpositions.Length;conPos++)
        {
            int randomPos = Random.Range(0, listpositions.Length);
            bool posRep = false;

            for (int cont = 0;cont < conPos;cont++)
            {
                if (listpositions[cont] == randomPos)
                {
                    posRep = true;
                    break;
                }
            }

            if (!posRep)
            {
                listpositions[conPos] = randomPos;
            }
            else
            {
                conPos--;
            }
        }

        for (int conItem = 0; conItem < listItems.Length; conItem++)
        {
            int randomItem = Random.Range(0, listItems.Length);
            bool itemRep = false;

            for (int cont = 0; cont < conItem; cont++)
            {
                if (listItems[cont] == randomItem)
                {
                    itemRep = true;
                    break;
                }
            }

            if (!itemRep)
            {
                listItems[conItem] = randomItem;
            }
            else
            {
                conItem--;
            }
        }



        Debug.Log("Posiciones");
        for (int i = 0;i<listpositions.Length;i++)
        {
            Instantiate(items[listItems[i]],positions[listpositions[i]].position, Quaternion.identity);
        }
        //Debug.Log("items");
        //for(int i = 0; i < listItems.Length; i++)
        //{
        //    Debug.Log(listItems[i]);
        //}
        
    }
}



//using System;
//using System.Linq;
//using UnityEngine;

//public class YourScript : MonoBehaviour
//{
//    void Start()
//    {
//        System.Random random = new System.Random();

//        int[] pos = new int[6];
//        for (int i = 0; i < pos.Length; i++)
//        {
//            pos[i] = i + 1;
//            Debug.Log(pos[i]);
//        }
//        Debug.Log("-----------separacion--------------");
//        String[] items = new string[4];
//        items[0] = "Stones";
//        items[1] = "sticks";
//        items[2] = "clothes";
//        items[3] = "wood";

//        int[] listaPos = new int[pos.Length];

//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

//        for (int conGen = 0; conGen < listaPos.Length; conGen++)
//        {
//            bool posDif = false;
//            int ranPos;

//            do
//            {
//                ranPos = random.Next(0, pos.Length);

//                // Verificar si ranPos ya está en listaPos
//                posDif = !Array.Exists(listaPos, element => element == ranPos);

//            } while (!posDif);

//            listaPos[conGen] = ranPos;
//        }

//        for (int i = 0; i < listaPos.Length; i++)
//        {
//            Debug.Log(listaPos[i]);
//        }
//    }
//}
