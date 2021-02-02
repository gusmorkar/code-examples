using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*to rotate item*/
public class ItemRotator : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}
}
