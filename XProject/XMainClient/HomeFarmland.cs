using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C2F RID: 3119
	internal class HomeFarmland : Farmland
	{
		// Token: 0x0600B0B3 RID: 45235 RVA: 0x0021C2AD File Offset: 0x0021A4AD
		public HomeFarmland(uint farmlandId) : base(farmlandId)
		{
		}

		// Token: 0x17003134 RID: 12596
		// (get) Token: 0x0600B0B4 RID: 45236 RVA: 0x0021C464 File Offset: 0x0021A664
		public override int BreakLevel
		{
			get
			{
				bool flag = this.m_breakLevel == -1;
				if (flag)
				{
					this.m_breakLevel = 0;
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BreakFarmlandLevel", true);
					for (int i = 0; i < (int)sequenceList.Count; i++)
					{
						bool flag2 = (long)sequenceList[i, 0] == (long)((ulong)this.m_farmlandId);
						if (flag2)
						{
							this.m_breakLevel = sequenceList[i, 1];
							break;
						}
					}
				}
				return this.m_breakLevel;
			}
		}

		// Token: 0x17003135 RID: 12597
		// (get) Token: 0x0600B0B5 RID: 45237 RVA: 0x0021C4E8 File Offset: 0x0021A6E8
		protected override Vector3 BoardRotation
		{
			get
			{
				bool flag = this.m_farmlandId > 3U;
				Vector3 result;
				if (flag)
				{
					result = new Vector3(-90f, 120f, 0f);
				}
				else
				{
					result = new Vector3(-90f, -120f, 0f);
				}
				return result;
			}
		}

		// Token: 0x0600B0B6 RID: 45238 RVA: 0x0021C534 File Offset: 0x0021A734
		protected override void SetPerfab()
		{
			base.DestroyPerfab();
			bool flag = !base.IsLock || base.Doc.HomeType != HomeTypeEnum.MyHome;
			if (!flag)
			{
				XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(base.NpcId);
				bool flag2 = npc == null;
				if (!flag2)
				{
					bool flag3 = (long)this.BreakLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					string value;
					if (flag3)
					{
						value = XSingleton<XGlobalConfig>.singleton.GetValue("FarmBoardPath1");
					}
					else
					{
						value = XSingleton<XGlobalConfig>.singleton.GetValue("FarmBoardPath");
					}
					this.m_boardGo = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(value, npc.EngineObject.Position, Quaternion.identity, true, false);
					bool flag4 = this.m_boardGo != null;
					if (flag4)
					{
						this.m_boardGo.transform.localEulerAngles = this.BoardRotation;
					}
					base.SetPerfab();
				}
			}
		}
	}
}
