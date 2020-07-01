using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="PlayerState", menuName="States/PlayerState")]
public class PlayerState : SingletonScriptableObject<PlayerState>
{
    public string PlayerName { get; set;}

}
