using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*to control player
 *************
 to implement movement with accelerometer and gyroscope on mobile*/
public class PlayerController : MonoBehaviour
{
    public float f_Speed;

    public int i_RightItemID;

    private Rigidbody rg_Rigidbody;

	// Use this for initialization
	void Start ()
    {
        i_RightItemID = 0;

        rg_Rigidbody = this.GetComponent<Rigidbody>();
    }
	
	void FixedUpdate ()
    {
        float f_Horizontal = Input.GetAxis ( "Horizontal" );
        float f_Vertical = Input.GetAxis ( "Vertical" );

        Vector3 v_MovementDirection = new Vector3 ( f_Horizontal, 0.0f, f_Vertical );

        rg_Rigidbody.AddForce ( v_MovementDirection * f_Speed );
	}

    public void FnUpdateRightItem(int i_RightOneID)
    {
        i_RightItemID = i_RightOneID;
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Item") &&  i_RightItemID== other.gameObject.GetInstanceID())
        {
            Destroy (other.gameObject);

            GameObject.FindGameObjectWithTag("GameController").SendMessage("FnUpdateScore");
        }
    }
}
