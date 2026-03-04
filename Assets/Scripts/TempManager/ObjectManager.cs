using System.Collections.Generic;
using UnityEngine;

using BT;
using FSM;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Slime slimePrefab;

    private Queue<FSM.BaseMonster> fsmMonsterPool = new Queue<FSM.BaseMonster>(MONSTER_CAPACITY);
    private Queue<BT.BaseMonster> btMonsterPool = new Queue<BT.BaseMonster>(MONSTER_CAPACITY);

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

    public void CreateMonster(StructDataManager structDataManager, int monsterCount = 1, eMonsterBase monsterBase = eMonsterBase.StateMachine)
    {
        for(int i = 0; i < monsterCount; i++)
        {
            int randID = Random.Range(0, (int)eMonsterID.End);

            CreateMonsterByFsm(structDataManager.GetMonsterStatData((eMonsterID)randID));
        }
    }

    private void CreateMonsterByFsm(MonsterStatData monsterStatData)
    {
        FSM.BaseMonster newMonster = Instantiate(slimePrefab, Vector2.zero, Quaternion.identity);

        newMonster.CacheTarget(playerTransform);
        newMonster.StartStateMachine(eState.Idle);

        fsmMonsterPool.Enqueue(newMonster);
    }

    private void CreateMonsterByBT()
    {

    }
}
