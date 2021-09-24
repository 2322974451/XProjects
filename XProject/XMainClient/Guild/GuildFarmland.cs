using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GuildFarmland : Farmland
	{

		public GuildFarmland(uint farmlandId) : base(farmlandId)
		{
		}

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

		protected override Vector3 BoardRotation
		{
			get
			{
				return new Vector3(-90f, 30f, 0f);
			}
		}

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
