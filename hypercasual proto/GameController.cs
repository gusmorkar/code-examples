using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*overall controller*/
public class GameController : MonoBehaviour
{
    Canvas c_CanvasController;

    private int i_Score;
    private int i_Game;

    private bool b_Control;
    private bool b_EndGame;

    public Text uiTx_Score, uiTx_Question;
    public Button uiBt_Math, uiBt_Colors, uiBt_Size, uiBt_Rotation;

    public Material mat_NewColor;

    void Awake()
    {
        b_Control = false;
        b_EndGame = false;

        i_Score = -1;
        FnUpdateScore();
        uiTx_Score.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (b_EndGame)
        { 
            FnGameEnds();

            if (Input.GetKey("R"))
                SceneManager.LoadScene(0);
        }

        if (b_Control)
            FnGenerateQuestion();
    }

    public void FnUpdateScore()
    {
        i_Score++;

        if (i_Score < 11)
        {
            uiTx_Score.text = "Score: " + i_Score.ToString();

            b_Control = true;
        }
        else
            b_EndGame = true;
    }

    private void FnGameEnds()
    {
        uiTx_Score.text = "MAX >> 12 << MAX";

        //no more control
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().f_Speed = 0.0f;

        uiTx_Question.text = "YOU WON! PRESS (R) TO RESTART";
    }

    public void FnStarts(int i)
    {
        i_Game = i;
        
        Destroy(uiBt_Math.gameObject);
        Destroy(uiBt_Colors.gameObject);
        Destroy(uiBt_Size.gameObject);
        Destroy(uiBt_Rotation.gameObject);

        uiTx_Score.gameObject.SetActive(true);
        b_Control = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().f_Speed = 10.0f;
    }

    private void FnGenerateQuestion()
    {
        GameObject[] go_Items = GameObject.FindGameObjectsWithTag("Item"); ;

        int i_RightItem = Random.Range(0, go_Items.Length);

        switch (i_Game)
        {
            case 1:
                int i_NumberA, i_NumberB;

                i_NumberA = Random.Range(-100, 100);
                i_NumberB = Random.Range(-100, 100);

                uiTx_Question.text = i_NumberA.ToString() + " + " + i_NumberB.ToString() + "?";

                int i_RightAnswer = i_NumberA + i_NumberB;

                for ( int i = 0; i != go_Items.Length; i++)
                {
                    if (i != i_RightItem)
                    {
                        int i_FakeAnswer = Random.Range(-100, 100);

                        if (i_FakeAnswer == i_RightAnswer)
                            i_FakeAnswer++;

                        go_Items[i].GetComponentInChildren<TextMesh>().text = i_FakeAnswer.ToString();
                    }
                    else
                    {
                        go_Items[i].GetComponentInChildren<TextMesh>().text = i_RightAnswer.ToString();

                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FnUpdateRightItem(go_Items[i].GetInstanceID());
                    }
                }
                break;

            case 2:
                uiTx_Question.text = "Which item rotates different?";

                for (int i = 0; i != go_Items.Length; i++)
                {
                    if (i == i_RightItem)
                    {
                        go_Items[i].gameObject.transform.eulerAngles -= new Vector3(Random.RandomRange(0.0f, 10.0f),
                             Random.RandomRange(0.0f, 10.0f), Random.RandomRange(0.0f, 10.0f));

                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FnUpdateRightItem(go_Items[i].GetInstanceID());
                    }
                }

                break;

            case 3:
                uiTx_Question.text = "Which item has a different color?";

                mat_NewColor.color = new Vector4(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f),
                    Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));

                for (int i = 0; i != go_Items.Length; i++)
                {
                    if (i == i_RightItem)
                    {
                        go_Items[i].GetComponent<Renderer>().material = mat_NewColor;

                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FnUpdateRightItem(go_Items[i].GetInstanceID());
                    }
                }
                break;

            case 4:
                uiTx_Question.text = "Which item has different size?";

                for (int i = 0; i != go_Items.Length; i++)
                {
                    if (i == i_RightItem)
                    {
                        go_Items[i].gameObject.transform.localScale += new Vector3( Random.RandomRange(0.1f, 1.0f),
                             Random.RandomRange(0.1f, 1.0f), Random.RandomRange(0.1f, 1.0f));

                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().FnUpdateRightItem(go_Items[i].GetInstanceID());
                    }
                }
            break;
        }

        b_Control = false;
    }
}
