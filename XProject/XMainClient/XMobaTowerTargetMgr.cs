using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B1D RID: 2845
	internal class XMobaTowerTargetMgr
	{
		// Token: 0x0600A745 RID: 42821 RVA: 0x001D8E24 File Offset: 0x001D7024
		public void Clear()
		{
			for (int i = 0; i < this.m_TowerList.Count; i++)
			{
				this.m_TowerList[i].Destroy();
			}
			this.m_TowerList.Clear();
		}

		// Token: 0x0600A746 RID: 42822 RVA: 0x001D8E6C File Offset: 0x001D706C
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

		// Token: 0x0600A747 RID: 42823 RVA: 0x001D8FE4 File Offset: 0x001D71E4
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

		// Token: 0x0600A748 RID: 42824 RVA: 0x001D9050 File Offset: 0x001D7250
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

		// Token: 0x04003DBF RID: 15807
		private List<TowerInfo> m_TowerList = new List<TowerInfo>();
	}
}
