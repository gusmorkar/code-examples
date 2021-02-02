using UnityEngine;
using System.Collections;
/*ccontrola celula: viva ou morta*/
public class Celula : MonoBehaviour
{
    public bool viva;

    void Update()
	{
        if ( !viva )
            Morre();
        else
            Nasce();
    }
	
    public void Nasce()
	{
        viva = true;
        renderer.material.color = Color.red;;
    }

    public void Morre()
	{
        viva = false;
        renderer.material.color = Color.black;
    }
}
