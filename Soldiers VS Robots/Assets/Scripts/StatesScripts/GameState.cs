using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Gamestate", menuName="States/GameState")]
public class GameState : ScriptableObject
{
    [SerializeField] public float MissionTime { get; set; }
}
