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
    Transform cardTransform;
    public HealthBar HPBar;
    public EnemyHPBar EHPBar;
    public Effects effectsScript;
    public EnemyEffects enemyEffectsScript;
    public Texture2D basicCursor;
    public Texture2D gameCursor;

    void Start()
    {
        Cursor.visible = false;
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

                wasPlayed = card.wasPlayed;

                if (wasPlayed)
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
    void OnMouseOver()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null)
        {
            cardTransform = hit.collider.gameObject.transform;
            nameGot = hit.collider.gameObject.name;
        }
        if(nameGot == "Cardridge1"|| nameGot == "Cardridge2"|| nameGot == "Cardridge3")
        {
            cardTransform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 3f);
            cardTransform.position = Vector3.MoveTowards(cardTransform.position, new Vector3(cardTransform.position.x, 0, 0),Time.deltaTime);
            Cursor.SetCursor(gameCursor, new Vector2(0, 0), CursorMode.ForceSoftware);
        }
    }
    void OnMouseExit()
    {
        cardTransform.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1.5f, 1.5f);
        cardTransform.position =new Vector3(cardTransform.position.x, -0.3f, 0);
        Cursor.SetCursor(basicCursor, new Vector2(0, 0), CursorMode.ForceSoftware);
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
                Cursor.visible = true;
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

                    Card card2 = new Card();
                    card2.wasPlayed = true;


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
        public bool effectUsed=false, wasPlayed;
    }
    private class Game
    {
        public string name="";
        public bool win=false;
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
        public int bombermanDamageTurn1;
        public int bombermanDamageTurn2;
        public int noInvincibleTurn1;
        public int noInvincibleTurn2;
        public int whoReflectDamage;
        public int turnToReflect1;
        public int turnToReflect2;
        public int turnToStopPoison1;
        public int turnToStopPoison2;
        public int bonus0;
        public int bonus1;
        public int bonus2;
        public int bonus3;
        public int bonus4;
        public int bonus5;
    }
    void getNewCard(string cardNr)
    {
        Card card = new Card();

        int i = Random.Range(1, 7);
        switch (i)
        {
            case 1:
                card.name = "bomberman";
                card.wasPlayed = false;
                break;
            case 2:
                card.name = "minesweeper";
                card.wasPlayed = false;
                break;
            case 3:
                card.name = "Pong";
                card.wasPlayed = false;
                break;
            case 4:
                card.name = "Snake";
                card.wasPlayed = false;
                break;
            case 5:
                card.name = "SpaceInvaders";
                card.wasPlayed = false;
                break;
            case 6:
                card.name = "PacMan";
                card.wasPlayed = false;
                break;

        }
        string json = JsonUtility.ToJson(card);

        File.WriteAllText(Application.dataPath + "/" + cardNr + ".json", json);
    }
    void useEffect(string gamePlayed, bool won)
    {
        string json1 = File.ReadAllText(Application.dataPath + "/Effects.json");
        effect ef = JsonUtility.FromJson<effect>(json1);

        int initialPlayerHP = playerHP;
        int initialEnemyHP = enemyHP;

        int tempPlayerHP = playerHP;
        int tempEnemyHP = enemyHP;

        switch (gamePlayed)
        {

            case "bomberman":
                if (won)
                { if(ef.bombermanDamageTurn2==-1) ef.bombermanDamageTurn2 = ef.turn + 2;}
                else
                { if (ef.bombermanDamageTurn1 == -1) ef.bombermanDamageTurn1 = ef.turn + 2;}
                break;
           case "minesweeper":
               if (won)
               { tempEnemyHP -= 20 + ef.bonus1; tempPlayerHP -= 10; }
               else
               { tempPlayerHP -= 20 + ef.bonus1; tempEnemyHP -= 10; }
               break;
           case "Pong":
               if (won)
               { ef.whoReflectDamage = 1; ef.turnToReflect1 = ef.turn+1; }
               else
               { ef.whoReflectDamage = 2; ef.turnToReflect2 = ef.turn+1; }
               break;
            case "Snake":
                if (won)
               { ef.turnToStopPoison2 = ef.turn + 4; }
               else
               { ef.turnToStopPoison1 = ef.turn + 4; }
               break;
           case "SpaceInvaders":
                if (won)
                    ef.noInvincibleTurn1 = ef.turn + 1;
                else
                    ef.noInvincibleTurn2 = ef.turn + 1;
               break;
           case "PacMan":
               if (won)
               tempPlayerHP += 10 + ef.bonus5;
               else
                   tempEnemyHP += 10 + ef.bonus5;
               break;

        }


        if (ef.turn < ef.turnToStopPoison1)
        {
            tempPlayerHP -= 5 + ef.bonus3;
        }
        else
            ef.turnToStopPoison1 = -1;
        if (ef.turn < ef.turnToStopPoison2)
        {
            tempEnemyHP -= 5 + ef.bonus3;
        }
        else
            ef.turnToStopPoison2 = -1;

        if (ef.turn == ef.bombermanDamageTurn1)
        { tempPlayerHP -= 35 + ef.bonus0; ef.bombermanDamageTurn1 = -1; }
        if (ef.turn == ef.bombermanDamageTurn2)
        { tempEnemyHP -= 35 + ef.bonus0; ef.bombermanDamageTurn2 = -1; }

       if(ef.turn<ef.noInvincibleTurn1+ ef.bonus4)
            { tempPlayerHP = initialPlayerHP; }
       else
            ef.noInvincibleTurn1 = -1;
        if (ef.turn < ef.noInvincibleTurn2+ ef.bonus4)
            { tempEnemyHP = initialEnemyHP; }
        else
            ef.noInvincibleTurn2 = -1;

        if (ef.whoReflectDamage == 1 && ef.turn == ef.turnToReflect1)
        {
            tempEnemyHP -= (initialPlayerHP - tempPlayerHP) + ef.bonus2;
            tempPlayerHP = initialPlayerHP;
            ef.turnToReflect1 = -1;
            ef.whoReflectDamage = 0;
        }
        if (ef.whoReflectDamage == 2 && ef.turn == ef.turnToReflect2)
        {
            tempPlayerHP -= (initialEnemyHP - tempEnemyHP) + ef.bonus2;
            tempEnemyHP = initialEnemyHP;
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

        if (ef.bombermanDamageTurn1 != -1)
            effectsScript.Effect1(ef.bombermanDamageTurn1 - ef.turn);
        if (ef.turnToStopPoison1 != -1)
            effectsScript.Effect2(ef.turnToStopPoison1 - ef.turn);
        if (ef.noInvincibleTurn1 != -1)
            effectsScript.Effect3(ef.noInvincibleTurn1 - ef.turn);
        if (ef.whoReflectDamage == 1)
            effectsScript.Effect4(true);

        if (ef.bombermanDamageTurn2 != -1)
            enemyEffectsScript.Effect1(ef.bombermanDamageTurn2 - ef.turn);
        if (ef.turnToStopPoison2!= -1)
            enemyEffectsScript.Effect2(ef.turnToStopPoison2 - ef.turn);
        if (ef.noInvincibleTurn2 != -1)
            enemyEffectsScript.Effect3(ef.noInvincibleTurn2 - ef.turn);
        if (ef.whoReflectDamage == 2)
            enemyEffectsScript.Effect4(true);
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
            json = JsonUtility.ToJson(card);
            File.WriteAllText(Application.dataPath + "/card" + i.ToString() + ".json", json);
        }

        string json1 = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(json1);


        if (enemyHP <= 0)
        { 
            enemy.nextEnemyNr++; 
            spawnPoint.ifToSpawn(false);
            if (enemy.nextEnemyNr == 9)
                enemyHP = 200;
            else
                if (enemy.nextEnemyNr == 2 || enemy.nextEnemyNr == 5 || enemy.nextEnemyNr == 8)
                    enemyHP = 150;
            else
                enemyHP = 100;

            if (playerHP < 1)
                playerHP = 1;
        }
        else if (playerHP <= 0)
        {
            if (enemy.nextEnemyNr == 9)
                enemyHP = 200;
            else
                if (enemy.nextEnemyNr == 2 || enemy.nextEnemyNr == 5 || enemy.nextEnemyNr == 8)
                enemyHP = 150;
            else
                enemyHP = 100;
            spawnPoint.ifToSpawn(true); respawn(); 
            playerHP = 100; 
        }
        else
            spawnPoint.ifToSpawn(false);

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



