using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*so' pra ativar interface*/

public class MainController : MonoBehaviour {

    Canvas canvas;

    public Text gText;
    public Text tText;

    public float nG = 0;
    public float nT = 0;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void  Idealize() {


        if ( nG == 0)
        {
            gText.text = "";
        }
        else
        {
            gText.text = "";
            for (int i = 0; i < nG; i++)
            {
                gText.text += GameObject.Find("Main Camera").GetComponent<ReadXML>().ReturnGenere(); ;
                gText.text += "\n";
            }
        }
        tText.text = nT.ToString();
    }

    public void AtualizaG()
    {
        nG = GameObject.Find("SliderGen").GetComponent<Slider>().value;
    }

    public void AtualizaT()
    {
        nT = GameObject.Find("SliderTem").GetComponent<Slider>().value;
    }
}
