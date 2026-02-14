using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int PlayerScore1 = 0; // Pontuação do player 1
    public static int PlayerScore2 = 0; // Pontuação do player 2

    public GUISkin layout;              // Fonte do placar
    public GameObject theBall;                 // Referência ao objeto bola

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        theBall = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GolCima(){
        PlayerScore1 ++;
        this.OnGUI();
    }

    // incrementa a potuação
    public static void Score (string wallID) {
        if (wallID == "GolCima")
        {
            PlayerScore1++;
        } else
        {
            PlayerScore2++;
        }
    }

    // Gerência da pontuação e fluxo do jogo
    void OnGUI () {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width - 220, 20, 100, 100), "" + PlayerScore1); // Player 1 mais à esquerda
        GUI.Label(new Rect(Screen.width - 120, 20, 100, 100), "" + PlayerScore2); // Player 2 mais à direita


        if (GUI.Button(new Rect(Screen.width - 210, 80, 120, 53), "RESTART"))
        {
            PlayerScore1 = 0;
            PlayerScore2 = 0;
            theBall.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
        if (PlayerScore1 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        } else if (PlayerScore2 == 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            theBall.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }


}
