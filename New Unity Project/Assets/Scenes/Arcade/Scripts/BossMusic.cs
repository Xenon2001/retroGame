using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BossMusic : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {

        string enemyJson = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(enemyJson);

        if (("Enemy" + (enemy.nextEnemyNr).ToString()) == enemy.currentEnemyNr)
        {
            if (col.name == "Player")
                if (!SoundManager.instance.SoundIsPlaying("BossMusic" + enemy.currentEnemyNr[5]) && !SoundManager.instance.SoundIsPlaying("BossMusic9intro"))
                    PlayBossMusic();
        }
        else
            SoundManager.instance.StopSound();
    }


    void PlayBossMusic()
    {

        string enemyJson = File.ReadAllText(Application.dataPath + "/enemyToBattle.json");
        enemyToBattle enemy = JsonUtility.FromJson<enemyToBattle>(enemyJson);

        string json1 = File.ReadAllText(Application.dataPath + "/Effects.json");
        effect ef = JsonUtility.FromJson<effect>(json1);


        if (enemy.currentEnemyNr != "Enemy9")
            SoundManager.instance.PlaySound("BossMusic" + enemy.currentEnemyNr[5]);
        else
        {
            if (ef.turn == 0)
                SoundManager.instance.PlaySound("BossMusic9intro");
            if (!SoundManager.instance.SoundIsPlaying("BossMusic9intro"))
                SoundManager.instance.PlaySound("BossMusic9");
        }
    }

    public class gameInProgress
    {
        public bool IsPlaying;
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
}
