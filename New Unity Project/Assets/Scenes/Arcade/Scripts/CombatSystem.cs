using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CombatSystem : MonoBehaviour
{
    public Sprite minesweeperSprite;
    public Sprite bombermanSprite;
    public Sprite snakeSprite;
    public Sprite pacmanSprite;
    public Sprite spaceinvadersSprite;
    public Sprite pongSprite;
    public bool effectUsed, wasPlayed;
    public GameBegin GameBeginScript;
    public int playerHP,enemyHP;
    //public GameObject enemy;
    GameObject lastClicked;
    Ray ray;
    RaycastHit rayHit;
    public scenesChange scChange;


       

    void Awake()
    {
        string Hp = File.ReadAllText(Application.dataPath + "/HPs.json");

        HP hps = JsonUtility.FromJson<HP>(Hp);

        playerHP=hps.playerHP;
        enemyHP=hps.enemyHP;
        if (this.name == "Cardridge1")
        {
            string json = File.ReadAllText(Application.dataPath + "/card1.json");

            Card card = JsonUtility.FromJson<Card>(json);

            effectUsed = card.effectUsed; 
            wasPlayed=card.wasPlayed;

            switch(card.name)
            {
                case "bomberman":
                    gameObject.GetComponent<SpriteRenderer>().sprite = bombermanSprite;
                    break;
                case "minesweeper":
                    gameObject.GetComponent<SpriteRenderer>().sprite = minesweeperSprite;
                    break;
                case "Pong":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pongSprite;
                    break;
                case "Snake":
                    gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
                    break;
                case "SpaceInvaders":
                    gameObject.GetComponent<SpriteRenderer>().sprite = spaceinvadersSprite;
                    break;
                case "PacMan":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pacmanSprite;
                    break;

            }

        }
        if (this.name == "Cardridge2")
        {
            string json = File.ReadAllText(Application.dataPath + "/card2.json");

            Card card = JsonUtility.FromJson<Card>(json);

            effectUsed = card.effectUsed;
            wasPlayed = card.wasPlayed;

            switch (card.name)
            {
                case "bomberman":
                    gameObject.GetComponent<SpriteRenderer>().sprite = bombermanSprite;
                    break;
                case "minesweeper":
                    gameObject.GetComponent<SpriteRenderer>().sprite = minesweeperSprite;
                    break;
                case "Pong":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pongSprite;
                    break;
                case "Snake":
                    gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
                    break;
                case "SpaceInvaders":
                    gameObject.GetComponent<SpriteRenderer>().sprite = spaceinvadersSprite;
                    break;
                case "PacMan":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pacmanSprite;
                    break;

            }

        }
        if (this.name == "Cardridge3")
        {
            string json = File.ReadAllText(Application.dataPath + "/card3.json");

            Card card = JsonUtility.FromJson<Card>(json);

            effectUsed = card.effectUsed;
            wasPlayed = card.wasPlayed;

            switch (card.name)
            {
                case "bomberman":
                    gameObject.GetComponent<SpriteRenderer>().sprite = bombermanSprite;
                    break;
                case "minesweeper":
                    gameObject.GetComponent<SpriteRenderer>().sprite = minesweeperSprite;
                    break;
                case "Pong":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pongSprite;
                    break;
                case "Snake":
                    gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
                    break;
                case "SpaceInvaders":
                    gameObject.GetComponent<SpriteRenderer>().sprite = spaceinvadersSprite;
                    break;
                case "PacMan":
                    gameObject.GetComponent<SpriteRenderer>().sprite = pacmanSprite;
                    break;

            }

        }

    }

    void Update()
    {

        if (playerHP <= 0 || enemyHP <= 0)
            GameOver();
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out rayHit))
                {
                    lastClicked = rayHit.collider.gameObject;
                    if (lastClicked != null)
                        print(lastClicked.name);
                }
                print("bre");
                string json = "";
                print(this.name);
                if (this.name == "Cardridge1")
                    json = File.ReadAllText(Application.dataPath + "/card1.json");

                if (this.name == "Cardridge2")
                    json = File.ReadAllText(Application.dataPath + "/card2.json");

                if (this.name == "Cardridge3")
                    json = File.ReadAllText(Application.dataPath + "/card3.json");


                Card card = JsonUtility.FromJson<Card>(json);
                if (this.name == "Cardridge1")
                    scChange.arcadeToGame(card.name);
                if (this.name == "Cardridge2")
                    scChange.arcadeToGame(card.name);
                if (this.name == "Cardridge3")
                    scChange.arcadeToGame(card.name);
            }

            if (GameBeginScript.IsPlaying)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
                gameObject.GetComponent<SpriteRenderer>().enabled = false;

            if (!effectUsed && wasPlayed)
            {
                string json = File.ReadAllText(Application.dataPath + "/game.json");

                Game game = JsonUtility.FromJson<Game>(json);
                useEffect(game.name, game.win);
                if (this.name == "Cardridge1")
                    getNewCard("card1");
                if (this.name == "Cardridge2")
                    getNewCard("card2");
                if (this.name == "Cardridge3")
                    getNewCard("card3");

            }
        }
    }
    private class Card
    {
        public string name;
        public bool effectUsed,wasPlayed;
    }
    private class Game
    {
        public string name;
        public bool win;
    }
    public class HP
    {
        public int enemyHP;
        public int playerHP;
    }
    public class gameInProgress
    {
        public bool IsPlaying;
    }
    void GameOver()
    {
        gameInProgress GIP = new gameInProgress();
        GIP.IsPlaying = false;

        string json = JsonUtility.ToJson(GIP);

        File.WriteAllText(Application.dataPath + "/GameInProgress.json", json);
    }
    void getNewCard(string cardNr)
    {
        Card card = new Card();
 
        int i = Random.Range(1, 7);
        switch(i)
        {
            case 1:
                card.name = "bomberman";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 2:
                card.name = "minesweeper";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 3:
                card.name = "Pong";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 4:
                card.name = "Snake";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 5:
                card.name = "SpaceInvaders";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 6:
                card.name = "PacMan";
                card.effectUsed = false;
                card.wasPlayed = false;
                break;

        }
        string json = JsonUtility.ToJson(card);

        File.WriteAllText(Application.dataPath + "/"+cardNr+ ".json", json);
    }
    void useEffect(string gamePlayed,bool won)
    {
        switch (gamePlayed)
        {
            case "bomberman":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;
            case "minesweeper":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;
            case "Pong":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;
            case "Snake":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;
            case "SpaceInvaders":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;
            case "PacMan":
                if (won)
                    enemyHP -= 10;
                else
                    playerHP -= 10;
                break;

        }
    }
}
    /*json info
            name
            efect used
            card used
            sprite



        void awake()
    {
        if name == card 1
                    get from json card 1 info

            if name == card 2
                    get from json card 2 info

            if name == card 3
                    get from jsom card 3 info
        }

    void update()
    {
        if (!use effect && used)
                use effect
                get new card
        }

    void onclick
            used = true
            update json
            play game
        */

    
    /*void Start()
    {
        gameInProgress hp = new gameInProgress();
        hp.IsPlaying = false;

        string json = JsonUtility.ToJson(hp);

        File.WriteAllText(Application.dataPath + "/GameInProgress.json", json);

    }*/


