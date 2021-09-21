using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C14 RID: 3092
	internal class GuildPassMgr : XSingleton<GuildPassMgr>
	{
		// Token: 0x0600AFA2 RID: 44962 RVA: 0x002153C0 File Offset: 0x002135C0
		public void InitBoard()
		{
			bool flag = this.attachDic == null;
			if (flag)
			{
				this.attachDic = new Dictionary<uint, GuildPassBoard>();
			}
			this.ClearAll();
			this.isOpen = false;
			for (uint num = 0U; num < 6U; num += 1U)
			{
				uint num2 = num + 1U;
				GameObject gameObject = GameObject.Find("guadian/board" + num2);
				GuildPassBoard guildPassBoard = gameObject.AddComponent<GuildPassBoard>();
				uint sceneid = XGuildTerritoryDocument.mGuildTransfer.GetByid(num2).sceneid;
				guildPassBoard.Init(num2, sceneid, gameObject);
				this.attachDic.Add(num2, guildPassBoard);
			}
			for (uint num3 = 0U; num3 < 6U; num3 += 1U)
			{
				uint num4 = num3 + 6U + 1U;
				GameObject gameObject2 = GameObject.Find("guadian/board" + num4);
				GuildPassBoard guildPassBoard2 = gameObject2.AddComponent<GuildPassBoard>();
				uint sceneid2 = XGuildTerritoryDocument.mGuildTransfer.GetByid(num4).sceneid;
				guildPassBoard2.Init(num4, sceneid2, gameObject2);
				this.attachDic.Add(num4, guildPassBoard2);
			}
			this.m_wait_blue = GameObject.Find("DynamicScene/wait_scene/wait_blue");
			this.m_wait_red = GameObject.Find("DynamicScene/wait_scene/wait_red");
		}

		// Token: 0x0600AFA3 RID: 44963 RVA: 0x002154EC File Offset: 0x002136EC
		public void UpdateInfo(List<GCFZhanChBriefInfo> infos)
		{
			bool flag = infos != null;
			if (flag)
			{
				for (int i = 0; i < infos.Count; i++)
				{
					foreach (KeyValuePair<uint, GuildPassBoard> keyValuePair in this.attachDic)
					{
						bool flag2 = keyValuePair.Value.sceneid == infos[i].mapid;
						if (flag2)
						{
							keyValuePair.Value.UpdateBoard(infos[i]);
							this.isOpen = infos[i].isopen;
						}
					}
				}
				bool flag3 = this.m_wait_red != null && this.m_wait_blue != null;
				if (flag3)
				{
					this.m_wait_blue.SetActive(!this.isOpen);
					this.m_wait_red.SetActive(!this.isOpen);
				}
				bool flag4 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible();
				if (flag4)
				{
					bool flag5 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler != null;
					if (flag5)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler.ShowPrepare(!this.isOpen);
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.m_miniReportHandler.ShowBegin(this.isOpen);
					}
				}
			}
		}

		// Token: 0x0600AFA4 RID: 44964 RVA: 0x00215658 File Offset: 0x00213858
		public void OpenAll()
		{
			foreach (KeyValuePair<uint, GuildPassBoard> keyValuePair in this.attachDic)
			{
				keyValuePair.Value.UpdateOpenState(true);
			}
		}

		// Token: 0x0600AFA5 RID: 44965 RVA: 0x002156B8 File Offset: 0x002138B8
		public void ClearAll()
		{
			bool flag = this.attachDic != null;
			if (flag)
			{
				foreach (KeyValuePair<uint, GuildPassBoard> keyValuePair in this.attachDic)
				{
					keyValuePair.Value.ResetOpenState();
					keyValuePair.Value.DestroyGameObjects();
					UnityEngine.Object.Destroy(keyValuePair.Value);
				}
				this.attachDic.Clear();
			}
		}

		// Token: 0x040042FF RID: 17151
		public Dictionary<uint, GuildPassBoard> attachDic;

		// Token: 0x04004300 RID: 17152
		private const int cnt = 6;

		// Token: 0x04004301 RID: 17153
		public bool isOpen = false;

		// Token: 0x04004302 RID: 17154
		public GameObject m_wait_blue;

		// Token: 0x04004303 RID: 17155
		public GameObject m_wait_red;
	}
}
