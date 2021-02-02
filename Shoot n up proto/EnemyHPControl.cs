using UnityEngine;
using System.Collections;

/*enemy resiliance*/
public class EnemyHPControl : MonoBehaviour {

	public int hp_i;
	
	public float timeToDestroy_f;

	public GameObject forDestroy_go;
	
	public void mtDamage (int d)
	{
		hp_i -= d;

		if (hp_i <= 0)
		{
			mtTriggerStart();

			Destroy (this.forDestroy_go, this.timeToDestroy_f);
			Destroy (this);
		}
	}

	private void mtTriggerStart()
	{
		GetComponent<TriggerEffectEnemy> ().mtInstantiateEffect (this.transform.position);
	}
}