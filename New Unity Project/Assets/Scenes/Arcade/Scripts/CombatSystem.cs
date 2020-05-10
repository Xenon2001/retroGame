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
    public int playerHP, enemyHP;
    public scenesChange scChange;
    string nameGot;
    public HealthBar HPBar;
    public EnemyHPBar EHPBar;

    void Start()
    {
        //enemyToBattle enemy = new enemyToBattle();
        //string json4 = JsonUtility.ToJson(enemy);
        //enemy.currentEnemyNr = "Enemy0";
        //enemy.nextEnemyNr = 0;
        //File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json4);

        string Hp = File.ReadAllText(Application.dataPath + "/HPs.json");

        HP hps = JsonUtility.FromJson<HP>(Hp);

        playerHP = hps.playerHP;
        enemyHP = hps.enemyHP;
        HPBar.SetHealth(playerHP);
        EHPBar.SetEHealth(enemyHP);
        for (int cardIndex = 1; cardIndex <= 3; ++cardIndex)
        {

            if (this.name == "Cardridge" + cardIndex.ToString())
            {
                string json = File.ReadAllText(Application.dataPath + "/card" + cardIndex.ToString() + ".json");

                Card card = JsonUtility.FromJson<Card>(json);

               // effectUsed = card.effectUsed;
                wasPlayed = card.wasPlayed;

                if (/*(effectUsed)&&*/  wasPlayed)
                {
                    string json2 = File.ReadAllText(Application.dataPath + "/game.json");
                    Game game = JsonUtility.FromJson<Game>(json2);

                    useEffect(game.name, game.win);
                    getNewCard("card" + cardIndex.ToString());

                }

                if (card.name == "")
                {
                    getNewCard("card" + cardIndex.ToString());
                }
                switch (card.name)
                {
                    case "bomberman":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = bombermanSprite;
                        break;
                    case "minesweeper":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = minesweeperSprite;
                        break;
                    case "Pong":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = pongSprite;
                        break;
                    case "Snake":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
                        break;
                    case "SpaceInvaders":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceinvadersSprite;
                        break;
                    case "PacMan":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = pacmanSprite;
                        break;

                }
            }
        }
    }
  
    void Update()
    {
        string json4 = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json4);
        if (playerHP <= 0 || enemyHP <= 0 || ("Enemy" + (enemy.nextEnemyNr).ToString()) != enemy.currentEnemyNr)
            GameOver();
        else
        {
            string Hp = File.ReadAllText(Application.dataPath + "/HPs.json");
            HP hps = JsonUtility.FromJson<HP>(Hp);

            playerHP = hps.playerHP;
            enemyHP = hps.enemyHP;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    nameGot = hit.collider.gameObject.name;
                }

                string json = "";

                if (nameGot == "Cardridge1")
                    json = File.ReadAllText(Application.dataPath + "/card1.json");

                if (nameGot == "Cardridge2")
                    json = File.ReadAllText(Application.dataPath + "/card2.json");

                if (nameGot == "Cardridge3")
                    json = File.ReadAllText(Application.dataPath + "/card3.json");


                Card card = JsonUtility.FromJson<Card>(json);

                //scChange.arcadeToGame(card.name);

                Card card2 = new Card();
                card2.wasPlayed = true;
                //card2.effectUsed = true;


                if (nameGot == "Cardridge1")
                {
                    
                    card2.name = card.name;
                    json = JsonUtility.ToJson(card2);
                    File.WriteAllText(Application.dataPath + "/card1.json", json);

                    scChange.arcadeToGame(card.name);

                }
                if (nameGot == "Cardridge2")
                {

                    card2.name = card.name;
                    json = JsonUtility.ToJson(card2);
                    File.WriteAllText(Application.dataPath + "/card2.json", json);

                    scChange.arcadeToGame(card.name);

                }
                if (nameGot == "Cardridge3")
                {

                    card2.name = card.name;
                    json = JsonUtility.ToJson(card2);
                    File.WriteAllText(Application.dataPath + "/card3.json", json);

                    scChange.arcadeToGame(card.name);
                }
            }
        }
    }
    void LateUpdate()
    {
        for (int cardIndex = 1; cardIndex <= 3; ++cardIndex)
        {
            if (this.name == "Cardridge" + cardIndex.ToString())
            {
                string json = File.ReadAllText(Application.dataPath + "/card" + cardIndex.ToString() + ".json");
                Card card = JsonUtility.FromJson<Card>(json);
                switch (card.name)
                {
                    case "bomberman":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = bombermanSprite;
                        break;
                    case "minesweeper":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = minesweeperSprite;
                        break;
                    case "Pong":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = pongSprite;
                        break;
                    case "Snake":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = snakeSprite;
                        break;
                    case "SpaceInvaders":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = spaceinvadersSprite;
                        break;
                    case "PacMan":
                        this.gameObject.GetComponent<SpriteRenderer>().sprite = pacmanSprite;
                        break;

                }
            }
            
        }
    }

    private class Card
    {
        public string name;
        public bool effectUsed, wasPlayed;
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

    public class zona
    {
        public string x;
    }
    public class enemyToBattle
    {
        public string currentEnemyNr;
        public int nextEnemyNr;
    }
    void getNewCard(string cardNr)
    {
        Card card = new Card();

        int i = Random.Range(1, 7);
        switch (i)
        {
            case 1:
                card.name = "bomberman";
                //card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 2:
                card.name = "minesweeper";
                //card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 3:
                card.name = "Pong";
                //card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 4:
                card.name = "Snake";
                //card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 5:
                card.name = "SpaceInvaders";
                //card.effectUsed = false;
                card.wasPlayed = false;
                break;
            case 6:
                card.name = "PacMan";
               // card.effectUsed = false;
                card.wasPlayed = false;
                break;

        }
        string json = JsonUtility.ToJson(card);

        File.WriteAllText(Application.dataPath + "/" + cardNr + ".json", json);
    }
    void useEffect(string gamePlayed, bool won)
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
        HPBar.SetHealth(playerHP);
        EHPBar.SetEHealth(enemyHP);
        HP x = new HP();
        x.playerHP = playerHP;
        x.enemyHP = enemyHP;
        string json = JsonUtility.ToJson(x);
        File.WriteAllText(Application.dataPath + "/HPs.json", json);

    }

    void GameOver()
    {
        gameInProgress GIP = new gameInProgress();
        GIP.IsPlaying = false;

        string json = JsonUtility.ToJson(GIP);

        File.WriteAllText(Application.dataPath + "/GameInProgress.json", json);

        for (int i = 1; i <= 3; i++)
        {
            Card card = new Card();
            card.name = "";
            card.wasPlayed = false;
            //card.effectUsed = false;
            json = JsonUtility.ToJson(card);
            File.WriteAllText(Application.dataPath + "/card" + i.ToString() + ".json", json);
        }

        string json1 = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json1);

        if (enemyHP <= 0)
        { enemy.nextEnemyNr++; /*enemy.currentEnemyNr = enemy.currentEnemyNr;*/ spawnPoint.ifToSpawn(false); enemyHP = 100; }
        else if (playerHP <= 0)
        { enemyHP = 100; spawnPoint.ifToSpawn(true); respawn(); playerHP = 100; }

        HP x = new HP();
        x.playerHP = playerHP;
        x.enemyHP = enemyHP;

        

        string json2 = JsonUtility.ToJson(enemy);
        File.WriteAllText(Application.dataPath + "/enemyToBattle.json", json2);
        string json3 = JsonUtility.ToJson(x);
        File.WriteAllText(Application.dataPath + "/HPs.json", json3);
    }

    void respawn()
    {
        Vector2 spawnPoint = new Vector2(0f, 0f);

        Vector2 zona1 = new Vector2(-10.39f, 11.16f);
        Vector2 zona2 = new Vector2(308.58f, 21.46f);
        Vector2 zona3 = new Vector2(556.03f, 35.44f);



        string json3 = File.ReadAllText(Application.dataPath + "/zona.json");

        zona Zona = JsonUtility.FromJson<zona>(json3);

        if (Zona.x == "zona1")
            spawnPoint = zona1;
        if (Zona.x == "zona2")
            spawnPoint = zona2;
        if (Zona.x == "zona3")
            spawnPoint = zona3;

        playerMovement.loadPosition(new Vector3(spawnPoint.x, spawnPoint.y, 0));
        scChange.arcadeToMap();
    }
}



