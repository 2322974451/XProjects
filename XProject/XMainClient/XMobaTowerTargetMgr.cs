using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMobaTowerTargetMgr
	{

		public void Clear()
		{
			for (int i = 0; i < this.m_TowerList.Count; i++)
			{
				this.m_TowerList[i].Destroy();
			}
			this.m_TowerList.Clear();
		}

		public void TryAddTower(XEntity newEntity)
		{
			bool flag = !XEntity.ValideEntity(newEntity);
			if (!flag)
			{
				bool flag2 = newEntity.IsRole || newEntity.Attributes == null;
				if (!flag2)
				{
					bool flag3 = !XSingleton<XEntityMgr>.singleton.IsOpponent(newEntity.Attributes.FightGroup);
					if (!flag3)
					{
						XOthersAttributes xothersAttributes = newEntity.Attributes as XOthersAttributes;
						bool flag4 = xothersAttributes == null;
						if (!flag4)
						{
							bool flag5 = newEntity.Attributes == null || (newEntity.Attributes.Tag & EntityMask.Moba_Tower) == 0U;
							if (!flag5)
							{
								for (int i = 0; i < this.m_TowerList.Count; i++)
								{
									bool flag6 = this.m_TowerList[i].UID == newEntity.ID;
									if (flag6)
									{
										return;
									}
								}
								TowerInfo towerInfo = new TowerInfo();
								towerInfo.UID = newEntity.ID;
								towerInfo.Entity = newEntity;
								towerInfo.WarningSqrRadius = xothersAttributes.EnterFightRange + XSingleton<XGlobalConfig>.singleton.MobaTowerFxOffset;
								towerInfo.WarningSqrRadius *= towerInfo.WarningSqrRadius;
								this.m_TowerList.Add(towerInfo);
								XSingleton<XDebug>.singleton.AddGreenLog("Tower ", newEntity.ID.ToString(), " add, Type ID = ", newEntity.Attributes.TypeID.ToString(), null, null);
							}
						}
					}
				}
			}
		}

		public void OnTargetChange(EntityTargetData data)
		{
			bool flag = data == null;
			if (!flag)
			{
				for (int i = 0; i < this.m_TowerList.Count; i++)
				{
					TowerInfo towerInfo = this.m_TowerList[i];
					bool flag2 = towerInfo.UID == data.entityUID;
					if (flag2)
					{
						towerInfo.TargetUID = data.targetUID;
						towerInfo.Update();
						break;
					}
				}
			}
		}

		public void Update()
		{
			for (int i = 0; i < this.m_TowerList.Count; i++)
			{
				TowerInfo towerInfo = this.m_TowerList[i];
				bool flag = !XEntity.ValideEntity(towerInfo.Entity);
				if (flag)
				{
					towerInfo.Destroy();
					XSingleton<XDebug>.singleton.AddGreenLog("Tower remove ", towerInfo.Entity.ID.ToString(), null, null, null, null);
					this.m_TowerList.RemoveAt(i);
					i--;
				}
				else
				{
					towerInfo.Update();
				}
			}
		}

		private List<TowerInfo> m_TowerList = new List<TowerInfo>();
	}
}
