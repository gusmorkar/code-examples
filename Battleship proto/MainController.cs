using UnityEngine;
using System.Collections;

/*******************************************************************************************
This script controls the PHASES of the game
Phase of setup > gameplay >> endgame/gameover
*******************************************************************************************/

public class MainController : MonoBehaviour
{
    //Game's phases: Insert the Dragons, Gameplay, end of the game
	public enum GamePhase { insertDragons, gameplay, gameover };
	
    //current phase
	private GamePhase enPhase;
	
    //check phase
	void mtUpdatePhase()
	{
		switch (enPhase)
		{
            //if the phase is Insert Dragons
            //get the script TesteInserirDragoes (players insert) n put on
            //get the script InsereDragoesRandom (computer insert) n put on
            case GamePhase.insertDragons:
				this.transform.GetComponent<TesteInserirDragoes>().enabled = true;
                this.transform.GetComponent<InsereDragoesRandom>().enabled = true;
                break;

            //if the phase is Gameplay
            //get the script ControlaJogo n put on
            //get the script ControlaTurno n put on
            case GamePhase.gameplay:
				this.transform.GetComponent<ControlaJogo>().enabled = true;
				this.transform.GetComponent<TurnsControl>().enabled = true;
			break;
			
			case GamePhase.gameover:
			
			break;
		}
	}

    //switch the phase by a code
    //0 switch to Insert
    //1 switch to gameplay
    //2 switch to end of the game
    //n check the phase to switch at the end of this metod
	public void mtSwitchPhase ( int iCodPhase )
	{
		switch (iCodPhase)
		{
			case 0:
				enPhase = GamePhase.insertDragons;
			break;
				
			case 1:
				enPhase = GamePhase.gameplay;
			break;
			
			case 2:
				enPhase = GamePhase.gameover;
			break;
		}

        mtUpdatePhase();
	}
}
