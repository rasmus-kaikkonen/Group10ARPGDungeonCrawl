using UnityEngine;

public class LevelUpManager : MonoBehaviour
{
    public static LevelUpManager instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public PlayerCharacter playerCharacter;
}
