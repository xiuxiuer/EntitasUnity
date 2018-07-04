﻿using System;
using Entitas;
using Entitas.Data;
using ScriptableData;
using ScriptableSystem;
using UnityClient;
using Util;

namespace SceneCommand
{
    internal class CreateCharacterCommand : AbstractCommand
    {
        protected override void Load(CallData callData)
        {
            if(callData.GetParamNum() >= 3)
            {
                m_CharacterId = int.Parse(callData.GetParamId(0));

                m_LocalPosition = ScriptableDataUtility.CalcVector3(callData.GetParam(1) as ScriptableData.CallData);
                m_LocalRotation = ScriptableDataUtility.CalcVector3(callData.GetParam(2) as ScriptableData.CallData);
            }
        }
        protected override void Load(FunctionData funcData)
        {
            ScriptableData.CallData callData = funcData.Call;
            if (null == callData)
                return;
            Load(callData);
            for(int i = 0; i < funcData.Statements.Count; ++i)
            {
                ScriptableData.CallData stCall = funcData.Statements[i] as ScriptableData.CallData;
                if (null == stCall)
                    continue;
                if(stCall.GetId() == "mainplayer")
                {
                    m_MainPlayer = true;
                }
                if(stCall.GetId() == "skill")
                {
                    if(stCall.GetParamNum() >= 1)
                    {
                        m_SkillId = int.Parse(stCall.GetParamId(0));
                    }
                }
                if(stCall.GetId() == "ai")
                {
                    if(stCall.GetParamNum() >= 1)
                    {
                        m_AIScript = stCall.GetParamId(0);
                    }
                }
                if(stCall.GetId() == "collision")
                {
                    if(stCall.GetParamNum() >= 2)
                    {
                        m_HasCollision = true;
                        m_CollisionOffset = ScriptableDataUtility.CalcVector3(stCall.GetParam(0) as CallData);
                        m_CollisionSize = ScriptableDataUtility.CalcVector3(stCall.GetParam(1) as CallData);
                    }
                }
            }
        }
        protected override ExecResult ExecCommand(Instance instance, long delta)
        {
            var gameContext = Contexts.sharedInstance.game;

            var target = instance.Target as GameEntity;
            if (null == target)
                return ExecResult.Finished;

            CharacterConfig config = CharacterConfigProvider.Instance.GetCharacterConfig(m_CharacterId);
            if(null != config)
            {
                uint entityId = IdSystem.Instance.GenId(IdEnum.Entity);
                GameEntity entity = gameContext.CreateEntity();
                entity.AddId(entityId);

                entity.isMainPlayer = m_MainPlayer;
                entity.isSpatial = !entity.isMainPlayer;


                // res
                uint resId = IdSystem.Instance.GenId(IdEnum.Resource);
                GfxSystem.Instantiate(resId, config.Model);
                entity.AddResource(resId);

                // animation
                entity.AddAnimation(config.ActionId, config.ActionPrefix);

                // movement
                entity.AddMovement(MoveState.Idle, 0, 0);
                entity.AddPosition(target.position.Value + m_LocalPosition);
                entity.AddRotation(RotateState.UserRotate, m_LocalRotation.y + target.rotation.RotateDir);

                // AI
                if(!string.IsNullOrEmpty(m_AIScript))
                {
                    var agent = new CharacterAgent();
                    agent.Init(entityId);
                    bool ret = agent.btload(m_AIScript);
                    agent.btsetcurrent(m_AIScript);
                    entity.AddAI(agent);
                }
                // skill
                entity.AddSkill(null);
                entity.AddBuff(new System.Collections.Generic.List<BuffInstanceInfo>());

                // 考虑采用skillinputcomponent类似的形式替换这种直接释放技能的形式。减少依赖。
                if(m_SkillId > 0)
                {
                    SkillSystem.Instance.StartSkill(target, entity, m_SkillId, target.position.Value, target.rotation.RotateDir);
                }

                // collision
                if(m_HasCollision)
                {
                    SpatialSystem.BoxCollider boxCollider = new SpatialSystem.BoxCollider(Vector3.zero, m_CollisionSize);
                    entity.AddCollision(null, boxCollider, m_CollisionOffset);
                }

            }
            else
            {
                LogUtil.Error("CreateCharacterCommand.ExecCommand : character config {0} not found!", m_CharacterId);
            }

            return ExecResult.Finished;
        }
        private void LogCollision(uint targetId)
        {
            LogUtil.Info("LogCollision {0}.", targetId);
        }

        private int m_CharacterId;
        private bool m_MainPlayer = false;
        private Vector3 m_LocalPosition;
        private Vector3 m_LocalRotation;
        private int m_SkillId = 0;
        private string m_AIScript = string.Empty;
        private bool m_HasCollision = false;
        private Vector3 m_CollisionOffset = Vector3.zero;
        private Vector3 m_CollisionSize = Vector3.one;
    }
}
