using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C2E RID: 3118
	internal class GuildFarmland : Farmland
	{
		// Token: 0x0600B0AF RID: 45231 RVA: 0x0021C2AD File Offset: 0x0021A4AD
		public GuildFarmland(uint farmlandId) : base(farmlandId)
		{
		}

		// Token: 0x17003132 RID: 12594
		// (get) Token: 0x0600B0B0 RID: 45232 RVA: 0x0021C2B8 File Offset: 0x0021A4B8
		public override int BreakLevel
		{
			get
			{
				bool flag = this.m_breakLevel == -1;
				if (flag)
				{
					this.m_breakLevel = 0;
					SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("BreakFarmlandLevel_Guild", true);
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

		// Token: 0x17003133 RID: 12595
		// (get) Token: 0x0600B0B1 RID: 45233 RVA: 0x0021C33C File Offset: 0x0021A53C
		protected override Vector3 BoardRotation
		{
			get
			{
				return new Vector3(-90f, 30f, 0f);
			}
		}

		// Token: 0x0600B0B2 RID: 45234 RVA: 0x0021C364 File Offset: 0x0021A564
		protected override void SetPerfab()
		{
			base.DestroyPerfab();
			bool flag = !base.IsLock || base.Doc.HomeType != HomeTypeEnum.GuildHome;
			if (!flag)
			{
				XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(base.NpcId);
				bool flag2 = npc == null;
				if (!flag2)
				{
					string text = "";
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					bool flag3 = specificDocument.bInGuild && (long)this.BreakLevel > (long)((ulong)specificDocument.Level);
					if (flag3)
					{
						text = XSingleton<XGlobalConfig>.singleton.GetValue("FarmBoardPath1");
					}
					bool flag4 = string.IsNullOrEmpty(text);
					if (!flag4)
					{
						this.m_boardGo = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(text, npc.EngineObject.Position, Quaternion.identity, true, false);
						bool flag5 = this.m_boardGo != null;
						if (flag5)
						{
							this.m_boardGo.transform.localEulerAngles = this.BoardRotation;
						}
						base.SetPerfab();
					}
				}
			}
		}
	}
}
