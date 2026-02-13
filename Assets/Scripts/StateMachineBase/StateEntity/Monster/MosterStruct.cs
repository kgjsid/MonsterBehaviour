using System;

[Serializable]
public struct MonsterStatData
{
    public string name;             // 이름
    public int hp;                  // 체력
    public int damage;              // 데미지
    public float detectionRange;    // 탐지 거리
    public float detectionAngle;    // 탐지 각도
    public float attackRange;       // 공격 사거리
    public int moveSpeed;           // 이동 속도

    public MonsterStatData (string name
                            , int hp
                            , int damage
                            , float detectionRange
                            , float detectionAngle
                            , float attackRange
                            , int moveSpeed)
    {
        this.name = name;
        this.hp = hp;
        this.damage = damage;
        this.detectionRange = detectionRange;
        this.detectionAngle = detectionAngle;
        this.attackRange = attackRange;
        this.moveSpeed = moveSpeed;
    }
}