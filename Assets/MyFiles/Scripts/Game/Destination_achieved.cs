using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination_achieved : MonoBehaviour {

	
	
// void OnCollisionEnter2D(Collision2D coll)
//     {
//         Debug.Log("OnCollisionEnter2D");
//     }
// }

void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("as");
    }
}