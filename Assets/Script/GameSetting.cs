using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]

public class GameSetting : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField]
    private string _gameVersion = "0.0.1";
    public string GameVersion { get { return _gameVersion; } }
    [SerializeField]
    private string _nickName = "Danilo";
    
    public string NickName
    {
        get 
        {

            int value = Random.Range(0, 9999);
            return _gameVersion+ value;
        
        }
    }

    
}
