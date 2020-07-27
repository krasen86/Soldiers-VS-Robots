using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Gamestate", menuName="States/GameState")]
public class GameState : SingletonScriptableObject<GameState>
{
    public float MissionTime { get; set; }    
    public float GameDifficulty { get; set; }

}
