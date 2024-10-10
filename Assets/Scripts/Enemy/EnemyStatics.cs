using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyStatics
{
    public static float TimeBetweenAttacks { get { return timeBetweenAttacks; } private set { timeBetweenAttacks = value; } }
    private static float timeBetweenAttacks = 0.5f;
    public static int AttackDamage { get { return attackDamage; } private set { attackDamage = value; } }
    private static int attackDamage = 10;
    public static int StartingHealth { get { return startingHealth; } private set { startingHealth = value; } }
    private static int startingHealth = 100;
    public static float SinkSpeed { get { return sinkSpeed; } private set { sinkSpeed = value; } }
    private static float sinkSpeed = 2.5f;
    public static int ScoreValue { get { return scoreValue; } private set { scoreValue = value; } }
    private static int scoreValue = 10;
}
