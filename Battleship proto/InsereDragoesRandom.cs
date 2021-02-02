using UnityEngine;
using System.Collections;

/**************************************************************************************************************
This script controls how the AI inserts dragons/ships randomly in the board
**************************************************************************************************************/
public class InsereDragoesRandom : MonoBehaviour {

    //all the enemy dragons in 1 vector
    private int[] iDragoesInimigo = new int[4];

    //
    private GameObject goDragaoInimigoSelecionado;

    //
    private GameObject[] goTiles;

    //
    public SetGrid scCriaCenario;

    private int iTiles = 0;

    public Transform[] tDragoesInimigo = new Transform[4];

    private GameObject iTileSelecionado;

    void Start ()
    {
        //inicializing
        iTileSelecionado = new GameObject();

        for (int i = 0; i < 4; i++)
        {
            iDragoesInimigo[i] = 0;
        }

        goTiles = new GameObject[scCriaCenario.goEnemyGrid.transform.childCount];

        while (iTiles < scCriaCenario.goEnemyGrid.transform.childCount)
        {
            goTiles[iTiles] = scCriaCenario.goEnemyGrid.transform.GetChild(iTiles).gameObject;
            iTiles++;
        }

        for (int idragoes  = 0; idragoes < 4; idragoes++ )
        {
            goDragaoInimigoSelecionado = Instantiate(tDragoesInimigo[idragoes],
                                                        new Vector3(0, 0, 0),
                                                        Quaternion.identity).gameObject;
            goDragaoInimigoSelecionado.name = "Inimigo";

            while (iDragoesInimigo[idragoes] == 0) 
            {
                if (fnCheca())
                {
                    mtInserePecas();
                    iDragoesInimigo[idragoes] = 1;
                }
            }
        }

        Destroy(this);
    }

    bool fnCheca()
    {
        bool bCria = true;

        iTileSelecionado = goTiles[ Random.Range( 0, iTiles) ];

        Vector3 vNovaPos = new Vector3 (iTileSelecionado.transform.position.x,
                                            iTileSelecionado.transform.position.y + 30,
                                            iTileSelecionado.transform.position.z);

        goDragaoInimigoSelecionado.transform.position = vNovaPos;

        Ray rRay = new Ray(vNovaPos, -Vector3.up);

        RaycastHit rcColisorRayCast;

        if ( Physics.Raycast (rRay, out rcColisorRayCast, 200) )
        {
            int iQntFilhos = goDragaoInimigoSelecionado.transform.childCount;

            for (int i = 0; i < iQntFilhos; i++)
            {
                Vector3 posFilho = goDragaoInimigoSelecionado.transform.GetChild(i).transform.position;

                if (Physics.Raycast(posFilho, -Vector3.up, out rcColisorRayCast, Mathf.Infinity))
                {
                    if (rcColisorRayCast.transform.tag != "GridInimigo" || rcColisorRayCast.transform.tag == "Dragao")
                    {
                        bCria = false;
                    }
                }
            }
        }
        

        return bCria;
    }

	void mtInserePecas ()
	{
        goDragaoInimigoSelecionado.transform.position = new Vector3 (iTileSelecionado.transform.position.x,
                                                                        iTileSelecionado.transform.position.y + 3,
                                                                        iTileSelecionado.transform.position.z);
    }
}
