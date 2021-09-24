

using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XLevelSpawnTask : XLevelBaseTask
    {
        public uint _EnemyID;
        public int _MonsterRotate;
        public int _MonsterIndex;
        public Vector3 _MonsterPos;
        public LevelSpawnType _SpawnType;
        public bool _IsSummonTask;

        public XLevelSpawnTask(XLevelSpawnInfo ls)
          : base(ls)
        {
            this._IsSummonTask = false;
        }

        public XEntity CreateClientMonster(uint id, float yRotate, Vector3 pos, int _waveid)
        {
            Quaternion rotation = Quaternion.Euler(0.0f, yRotate, 0.0f);
            XEntity entity = XSingleton<XEntityMgr>.singleton.CreateEntity(id, pos, rotation, true);
            if (entity == null)
                return (XEntity)null;
            entity.Wave = _waveid;
            entity.CreateTime = Time.realtimeSinceStartup;
            XAIEventArgs xaiEventArgs = XEventPool<XAIEventArgs>.GetEvent();
            xaiEventArgs.DepracatedPass = true;
            xaiEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
            xaiEventArgs.EventType = 1;
            xaiEventArgs.EventArg = "SpawnMonster";
            int num = (int)XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xaiEventArgs, 0.05f);
            return entity;
        }

        public XEntity CreateServerAttrMonster(
          UnitAppearance data,
          float yRotate,
          Vector3 pos,
          int _waveid)
        {
            XAttributes attr = XSingleton<XAttributeMgr>.singleton.InitAttrFromServer(data.uID, data.nickid, data.unitType, data.unitName, data.attributes, data.fightgroup, data.isServerControl, data.skills, data.bindskills, new XOutLookAttr((OutLookGuild)null), data.level);
            attr.Outlook.SetData(data.outlook, attr.TypeID);
            XEntity entity = attr.Type != EntitySpecies.Species_Role ? XSingleton<XEntityMgr>.singleton.Add(XSingleton<XEntityMgr>.singleton.CreateEntity(attr, pos, Quaternion.Euler(0.0f, yRotate, 0.0f), false)) : XSingleton<XEntityMgr>.singleton.Add((XEntity)XSingleton<XEntityMgr>.singleton.CreateRole(attr, pos, Quaternion.Euler(0.0f, yRotate, 0.0f), false));
            if (entity == null)
                return (XEntity)null;
            entity.Wave = _waveid;
            if (XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_BOSSRUSH)
            {
                XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID).GetBossRushConfig(XSingleton<XScene>.singleton.SceneID, (uint)(XSingleton<XLevelStatistics>.singleton.ls._total_kill + 1));
                if (data != null)
                {
                    float num1 = 1f;
                    double num2 = entity.Attributes.GetAttr(XAttributeDefine.XAttr_MaxHP_Basic) * (double)num1;
                    entity.Attributes.SetAttr(XAttributeDefine.XAttr_MaxHP_Basic, num2);
                    entity.Attributes.SetAttr(XAttributeDefine.XAttr_CurrentHP_Basic, num2);
                }
            }
            if (!data.IsDead)
                return entity;
            XSingleton<XDeath>.singleton.DeathDetect(entity, (XEntity)null, true);
            return (XEntity)null;
        }

        public override bool Execute(float time)
        {
            base.Execute(time);
            XLevelDynamicInfo xlevelDynamicInfo = (XLevelDynamicInfo)null;
            if (!this._IsSummonTask)
            {
                xlevelDynamicInfo = this._spawner.GetWaveDynamicInfo(this._id);
                if (xlevelDynamicInfo == null)
                    return true;
            }
            XEntity xentity = (XEntity)null;
            if (this._SpawnType == LevelSpawnType.Spawn_Source_Monster)
            {
                xentity = this.CreateClientMonster(this._EnemyID, (float)this._MonsterRotate, this._MonsterPos + new Vector3(0.0f, 0.02f, 0.0f), this._id);
                XSingleton<XLevelStatistics>.singleton.ls.AddLevelSpawnEntityCount(xentity.ID);
            }
            else if (this._SpawnType != LevelSpawnType.Spawn_Source_Doodad)
            {
                UnitAppearance cacheServerMonster = XSingleton<XLevelSpawnMgr>.singleton.GetCacheServerMonster((uint)this._id);
                if (cacheServerMonster != null)
                    xentity = this.CreateServerAttrMonster(cacheServerMonster, (float)this._MonsterRotate, this._MonsterPos + new Vector3(0.0f, 0.02f, 0.0f), this._id);
                XSingleton<XLevelStatistics>.singleton.ls.AddLevelSpawnEntityCount(xentity.ID);
            }
            if (xlevelDynamicInfo != null)
            {
                if (xentity != null)
                {
                    ++xlevelDynamicInfo._generateCount;
                    xlevelDynamicInfo._enemyIds.Add(xentity.ID);
                }
                if (xlevelDynamicInfo._generateCount == xlevelDynamicInfo._TotalCount)
                    xlevelDynamicInfo._generatetime = time;
                if (xentity != null && xentity.IsBoss)
                {
                    XSingleton<XTutorialHelper>.singleton.HasBoss = true;
                    return false;
                }
            }
            return true;
        }
    }
}
