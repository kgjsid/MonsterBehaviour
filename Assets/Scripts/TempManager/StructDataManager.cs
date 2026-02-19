using UnityEngine;

public class StructDataManager : MonoBehaviour
{
    [SerializeField] private MonsterStatData[] monsterStatDatas = new MonsterStatData[(int)eMonsterID.End];

    private const string ID_ERROR_MESSAGE = "ID does not exist";

    public void SetMonsterStatDatas(eMonsterID monsterID, MonsterStatData monsterStatData)
    {
        VerifyMonsterDataExists((int)monsterID);

        monsterStatDatas[(int)monsterID] = monsterStatData;
    }

    public MonsterStatData GetMonsterStatData(eMonsterID monsterID)
    {
        VerifyMonsterDataExists((int)monsterID);

        return monsterStatDatas[(int)monsterID];
    }

    public MonsterStatData[] GetMonsterStatDatas()
    {
        return monsterStatDatas;
    }

    private void VerifyMonsterDataExists(int monsterID)
    {
        if (monsterStatDatas.Length < monsterID) Debug.LogError(ID_ERROR_MESSAGE);
    }
}
