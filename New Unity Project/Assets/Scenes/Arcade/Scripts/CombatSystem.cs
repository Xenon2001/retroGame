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
    public int bonus0;//10
    public int bonus1;//10
    public int bonus2;//10
    public int bonus3;//5
    public int bonus4;//1
    public int bonus5;//10

    void Start()
    {
        if (this.name == "Cardridge1")
        {
            string json1 = File.ReadAllText(Application.dataPath + "/Effects.json");
            effect ef = JsonUtility.FromJson<effect>(json1);

            ef.turn = ef.turn + 1;

            string json2 = JsonUtility.ToJson(ef);
            File.WriteAllText(Application.dataPath + "/Effects.json", json2);
        }
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
                string json3 = File.ReadAllText(Application.dataPath + "/card" + cardIndex.ToString() + ".json");

                Card card = JsonUtility.FromJson<Card>(json3);

               // effectUsed = card.effectUsed;
                wasPlayed = card.wasPlayed;

                if (/*(effectUsed)&&*/  wasPlayed)
                {
                    string json4 = File.ReadAllText(Application.dataPath + "/game.json");
                    Game game = JsonUtility.FromJson<Game>(json4);

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
        string check = File.ReadAllText(Application.dataPath + "/GameInProgress.json");
        gameInProgress GIP = JsonUtility.FromJson<gameInProgress>(check);
        if (GIP.IsPlaying)
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
    public class effect
    {
        public int turn;
        //public int whoToExplode;
        public int bombermanDamageTurn1;
        public int bombermanDamageTurn2;
        //public int whoNoDamage;
        public int noInvincibleTurn1;
        public int noInvincibleTurn2;
        public int whoReflectDamage;
        public int turnToReflect1;
        public int turnToReflect2;
        //public int whoPoisoned;
        public int turnToStopPoison1;
        public int turnToStopPoison2;
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
        /*
         * heal-pacman 
         * both take dmg, winner less -minesweeper 
         * reflect dmg next turn if damaged-pong 
         * high dmg after 2 turns-bomberman 
         * take no next damage-space inv 
         * low damage over 4 turns-snake 
         */


        string json1 = File.ReadAllText(Application.dataPath + "/Effects.json");
        effect ef = JsonUtility.FromJson<effect>(json1);

        int initialPlayerHP = playerHP;
        int initialEnemyHP = enemyHP;

        int tempPlayerHP = playerHP;
        int tempEnemyHP = enemyHP;

        switch (gamePlayed)
        {

            case "bomberman"://dupa ce a fost folosita,explodeaza in a3a tura(dupa 2 ture)
                if (won)
                { if(ef.bombermanDamageTurn2==-1) ef.bombermanDamageTurn2 = ef.turn + 2;  }
                else
                { if (ef.bombermanDamageTurn1 == -1) ef.bombermanDamageTurn1 = ef.turn + 2;}
                break;
           case "minesweeper":
               if (won)
               { tempEnemyHP -= 20 + bonus1; tempPlayerHP -= 10 + bonus1; }
               else
               { tempPlayerHP -= 20 + bonus1; tempEnemyHP -= 10 + bonus1; }
               break;
           case "Pong":
               if (won)
               { ef.whoReflectDamage = 1; ef.turnToReflect1 = ef.turn+1; }
               else
               { ef.whoReflectDamage = 2; ef.turnToReflect2 = ef.turn+1; }
               break;
            case "Snake"://damage-ul se termina in a 5 tura(tine 4 ture dupa ce e folosit)
                if (won)
               { ef.turnToStopPoison2 = ef.turn + 4; }
               else
               { ef.turnToStopPoison1 = ef.turn + 4; }
               break;
           case "SpaceInvaders":
               if (won)
                    ef.noInvincibleTurn1 = ef.turn + 1; //the player will not take damage
               else
                    ef.noInvincibleTurn2 = ef.turn + 1;//the enemy will not take damage
               break;
           case "PacMan":
               if (won)
               tempPlayerHP += 10 + bonus5;
               else
                   tempEnemyHP += 10 + bonus5;
               break;

        }


        if (ef.turn < ef.turnToStopPoison1)
        {
            ///if (ef.whoPoisoned == 1)
            tempPlayerHP -= 5 + bonus3;
        }
        else
            ef.turnToStopPoison1 = -1;
        if (ef.turn < ef.turnToStopPoison2)
        {
            ///if (ef.whoPoisoned == 2)
            tempEnemyHP -= 5 + bonus3;
        }
        else
            ef.turnToStopPoison2 = -1;

        if (ef.turn == ef.bombermanDamageTurn1)
        ///if (ef.whoToExplode == 1)
        { tempPlayerHP -= 35 + bonus0; /*ef.whoToExplode = 0;*/ ef.bombermanDamageTurn1 = -1; }
        if (ef.turn == ef.bombermanDamageTurn2)
        ///if (ef.whoToExplode == 2)
        { tempEnemyHP -= 35 + bonus0; /*ef.whoToExplode = 0;*/ ef.bombermanDamageTurn2 = -1; }

       // if (ef.whoNoDamage == 1)
       if(ef.turn<ef.noInvincibleTurn1+bonus4)
            { tempPlayerHP = initialPlayerHP; /*ef.whoNoDamage = 0; */}
       else
            ef.noInvincibleTurn1 = -1;
        // if (ef.whoNoDamage == 2)
        if (ef.turn < ef.noInvincibleTurn2+bonus4)
            { tempEnemyHP = initialEnemyHP; /*ef.whoNoDamage = 0; */}
        else
            ef.noInvincibleTurn2 = -1;

        if (ef.whoReflectDamage == 1 && ef.turn == ef.turnToReflect1)
        {
            //if (tempPlayerHP < initialPlayerHP)
            //{
            tempEnemyHP -= (initialPlayerHP - tempPlayerHP) + bonus2;
            tempPlayerHP = initialPlayerHP;
            //}
            ef.turnToReflect1 = -1;
            ef.whoReflectDamage = 0;
        }
        if (ef.whoReflectDamage == 2 && ef.turn == ef.turnToReflect2)
        {
            //if (tempEnemyHP < initialEnemyHP)
            //{
            tempPlayerHP -= (initialEnemyHP - tempEnemyHP) + bonus2;
            tempEnemyHP = initialEnemyHP;
            //}
            ef.turnToReflect2 = -1;
            ef.whoReflectDamage = 0;
        }
        string json2 = JsonUtility.ToJson(ef);
        File.WriteAllText(Application.dataPath + "/Effects.json", json2);

        playerHP = tempPlayerHP;
        enemyHP = tempEnemyHP;
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
        { 
            enemy.nextEnemyNr++; 
            spawnPoint.ifToSpawn(false); 
            enemyHP = 100; 
        }
        else if (playerHP <= 0)
        { 
            enemyHP = 100; 
            spawnPoint.ifToSpawn(true); respawn(); 
            playerHP = 100; 
        }

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



