using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    
    [SerializeField] private ObjectManager objectManager;
    [SerializeField] private StructDataManager structDataManager;

    public static GameManager Game { get { return gameManager; } }
    public ObjectManager Object { get { return objectManager; } }
    public StructDataManager StructData { get { return structDataManager; } }

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(this);

            return;
        }
        gameManager = this;

        DontDestroyOnLoad(this);
        InitSetting();
    }

    private void OnDestroy()
    {
        if (gameManager == this)
        {
            gameManager = null;
            Destroy(this);
        }
    }

    private void InitSetting()
    {
        objectManager.CreatePlayer();

        SetMonsterData();

        objectManager.CreateMonster(structDataManager);
    }

    private void SetMonsterData()
    {
        MonsterStatData slimeData = new MonsterStatData();

        slimeData.name = "Slime";
        slimeData.hp = 50;
        slimeData.damage = 5;
        slimeData.detectionRange = 7f;
        slimeData.detectionAngle = 45f;
        slimeData.attackRange = 2f;
        slimeData.moveSpeed = 4;

        structDataManager.SetMonsterStatDatas(eMonsterID.Slime, slimeData);

        MonsterStatData orcData = new MonsterStatData();

        orcData.name = "Orc";
        orcData.hp = 100;
        orcData.damage = 10;
        orcData.detectionRange = 5f;
        orcData.detectionAngle = 60f;
        orcData.attackRange = 2f;
        orcData.moveSpeed = 3;

        structDataManager.SetMonsterStatDatas(eMonsterID.Orc, orcData);
    }
}
