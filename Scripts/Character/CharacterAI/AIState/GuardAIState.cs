using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����״̬
public class GuardAIState : IAIState
{
    bool m_bOnMove = false;
    Vector3 m_Position = Vector3.zero;
    const int GUARD_DISTANCE = 3;

    public GuardAIState()
    { }

    // ����
    public override void Update(List<ICharacter> Targets)
    {
        // ��Ŀ��ʱ,��Ϊ����״̬
        if (Targets != null && Targets.Count > 0)
        {
            m_CharacterAI.ChangeAIState(new IdleAIState());
            return;
        }

        if (m_Position == Vector3.zero)
            GetMovePosition();

        // �Ѿ�Ŀ���ƶ�
        if (m_bOnMove)
        {
            //  �Ƿ񵽴�Ŀ��
            float dist = Vector3.Distance(m_Position, m_CharacterAI.GetPosition());
            if (dist > 0.5f)
                return;

            // ����һ��λ��
            GetMovePosition();
        }

        // ��Ŀ���ƶ�
        m_bOnMove = true;
        m_CharacterAI.MoveTo(m_Position);
    }

    // �趨�ƶ���λ��
    private void GetMovePosition()
    {
        m_bOnMove = false;

        // ȡ�����λ��
        Vector3 RandPos = new Vector3(UnityEngine.Random.Range(-GUARD_DISTANCE, GUARD_DISTANCE), 0, UnityEngine.Random.Range(-GUARD_DISTANCE, GUARD_DISTANCE));

        //�趨Ϊ�µ�λ��
        m_Position = m_CharacterAI.GetPosition() + RandPos;
    }
}