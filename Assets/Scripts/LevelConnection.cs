using UnityEngine;

[CreateAssetMenu(menuName = "levels/connection")]

public class LevelConnection : ScriptableObject { 
    public static LevelConnection ActiveConnection { get; set; }
}