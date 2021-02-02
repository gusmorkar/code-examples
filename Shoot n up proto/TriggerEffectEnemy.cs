using UnityEngine;
using System.Collections;

/*particle instatiator*/
public class TriggerEffectEnemy : MonoBehaviour {

	public GameObject effect_go;
	
	public void mtInstantiateEffect (Vector3 p)
	{
		Instantiate (effect_go, p, this.transform.rotation);
	}
}
