using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌方角色AI
public class EnemyAI : ICharacterAI
{
    private static StageSystem m_StageSystem = null;
    private Vector3 m_AttackPosition = Vector3.zero;

    // 直接將关卡系统直接注入给EnemyAI类别使用
    public static void SetStageSystem(StageSystem StageSystem)
    {
        m_StageSystem = StageSystem;
    }
    public EnemyAI(ICharacter character ,Vector3 AttackPosition) : base(character)
    {
        m_AttackPosition = AttackPosition;

        //一开始起始的状态
        ChangeAIState(new IdleAIState());
    }


    //更换AI状态
    public override void ChangeAIState(IAIState NewAIState)
    {
        base.ChangeAIState(NewAIState);
        //Enemy的AI要设定攻击的目标
        NewAIState.SetAttackPosition(m_AttackPosition);
    }

    //是否可以攻击Heart
    public override bool CanAttackHeart()
    {
        //通知去少一个心
        m_StageSystem.LoseHeart();
        return true;
    }
}
