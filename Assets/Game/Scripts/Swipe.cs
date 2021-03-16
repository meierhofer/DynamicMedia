using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject player;
    public float x1;
    public float x2;

    public float move = 0;


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            x1 = Input.mousePosition.x;
        }

        if(Input.GetMouseButtonUp(0))
        {
            x2 = Input.mousePosition.x;

            if(x1 > x2)
            {
                move = 1f;
            }
            if(x2 > x1)
            {
                move = 2f;
            }
        }


        if(move == 2)
        {
            player.transform.Translate(Vector2.left * (3 * Time.deltaTime));
        }

        if (move == 1)
        {
            player.transform.Translate(Vector2.right * (5 * Time.deltaTime));
        }
    }
}
