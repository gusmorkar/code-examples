using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script is to insert the players ships/dragons
*******************************************************************************************/

public class TesteInserirDragoes : MonoBehaviour
{
	private GameObject goDragaoSelecionado;

    private bool bSelecionado = false;
	
	private bool bPodeCriar;
	
	private int ind;
	
	public Transform[] tDragoes = new Transform[4];

    int[] iDragoes = new int[4];

    bool inseriu = false;
    // Use this for initialization
    void Start ()
	{
        for (int i = 0; i < 4; i++)
        {
            iDragoes[i] = 0;
        }
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyUp(KeyCode.Alpha1))
            mtAtualizaPosicaoInicial(0);

        if ( Input.GetKeyUp (KeyCode.Alpha2) )
            mtAtualizaPosicaoInicial(1);

        if (Input.GetKeyUp (KeyCode.Alpha3))
            mtAtualizaPosicaoInicial(2);

        if (Input.GetKeyUp (KeyCode.Alpha4))
            mtAtualizaPosicaoInicial(3);

        if (bSelecionado)
        {
            mtRotaciona();

            mtChecaEspaco();
        }

        mtChecaInicio();
					
	}

	void mtAtualizaPosicaoInicial( int v )
	{
        ind = v;

        Destroy(GameObject.Find(tDragoes[ind].name + "(Clone)"));

        goDragaoSelecionado = Instantiate (tDragoes[ind],
                                        new Vector3(0, 0, 0),
                                            Quaternion.identity).gameObject;

        goDragaoSelecionado.gameObject.GetComponent<BoxCollider>().enabled = false;
        goDragaoSelecionado.gameObject.SetActive(false);

        iDragoes[ind] = 0;

        bSelecionado = true;
    }

	public void mtDestroi ()
	{
		Destroy(this);
	}

    void mtRotaciona()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetAxis("Mouse ScrollWheel") > 0)
            goDragaoSelecionado.transform.eulerAngles = new Vector3(0,
                    goDragaoSelecionado.transform.eulerAngles.y + 90, 0);

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetAxis("Mouse ScrollWheel") < 0)
            goDragaoSelecionado.transform.eulerAngles = new Vector3(0,
                goDragaoSelecionado.transform.eulerAngles.y - 90, 0);
    }

    void mtChecaEspaco()
    {
        Ray rRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rcColisorRayCast;

        if (Physics.Raycast(rRay, out rcColisorRayCast, 200) )
        {
            goDragaoSelecionado.gameObject.SetActive(true);
            
            goDragaoSelecionado.transform.position = new Vector3(rcColisorRayCast.transform.position.x,
                                                2 + transform.lossyScale.y,
                                                rcColisorRayCast.transform.position.z);

            bPodeCriar = true;

            int iQntFilhos = goDragaoSelecionado.transform.childCount;

            for ( int i = 0; i < iQntFilhos; i++ )
            {
                Vector3 vFilho = goDragaoSelecionado.transform.GetChild(i).transform.position;

                vFilho = new Vector3( vFilho.x,
                                       vFilho.y + 10,
                                       vFilho.z );

                if ( Physics.Raycast( vFilho, -Vector3.up, out rcColisorRayCast, Mathf.Infinity ) )
                {
                    if (rcColisorRayCast.transform.tag != "Grid" || rcColisorRayCast.transform.tag == "Dragao")
                    {
                        bPodeCriar = false;
                        goDragaoSelecionado.gameObject.SetActive(false);
                        break;
                    }
                }
            }

            if (bPodeCriar)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    goDragaoSelecionado.gameObject.GetComponent<BoxCollider>().enabled = true;
                    iDragoes[ind] = 1;
                    mtAnulaSelecao();
                }
            }
        }
        else
            goDragaoSelecionado.gameObject.SetActive(false);
    }

    void mtChecaInicio() {

        bool allGood = true;

        for (int i = 0; i < 4; i++)
        {
            if (iDragoes[i] == 0)
                allGood = false;
        }

        if (allGood)
        {
            this.transform.GetComponent<MainController>().mtSwitchPhase(1);
            Destroy(this);
        }
    }

    void mtAnulaSelecao()
    {
        bSelecionado = false;
        goDragaoSelecionado = null;
    }
}
