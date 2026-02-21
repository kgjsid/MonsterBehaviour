using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Slime slimePrefab;

    private Queue<BaseMonster> monsterPool = new Queue<BaseMonster>();

    private PlayerController playerController;
    private Transform playerTransform;

    private const int MONSTER_CAPACITY = 100;

    public Vector3 PlayerPos
    {
        get
        {
            if (playerTransform == null) return Vector3.zero;
            return playerTransform.position;
        }
    }

    public void CreatePlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);

        playerController = newPlayer.GetComponent<PlayerController>();
        playerTransform = newPlayer.transform;
    }

    public void CreateMonster(StructDataManager structDataManager, int monsterCount = 1)
    {
        if (monsterPool == null)
            monsterPool = new Queue<BaseMonster>(MONSTER_CAPACITY);

        for(int i = 0; i < monsterCount; i++)
        {
            int randID = Random.Range(0, (int)eMonsterID.End);

            BaseMonster newMonster = Instantiate(slimePrefab, Vector2.zero, Quaternion.identity);

            newMonster.InitMonsterSetting(structDataManager.GetMonsterStatData((eMonsterID)randID));
            newMonster.CacheTarget(playerTransform);
            newMonster.StartStateMachine(eState.Idle);

            monsterPool.Enqueue(newMonster);
        }
    }
}
