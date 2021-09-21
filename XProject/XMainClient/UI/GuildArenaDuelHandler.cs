using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001751 RID: 5969
	internal class GuildArenaDuelHandler : DlgHandlerBase
	{
		// Token: 0x170037F3 RID: 14323
		// (get) Token: 0x0600F69F RID: 63135 RVA: 0x0037F9E8 File Offset: 0x0037DBE8
		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/DuelFrame";
			}
		}

		// Token: 0x0600F6A0 RID: 63136 RVA: 0x0037FA00 File Offset: 0x0037DC00
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
			this.m_UnApply = base.transform.FindChild("UnApply");
			this.m_DuelList = base.transform.FindChild("DuelList");
			this.m_DuelHelp = (base.transform.FindChild("Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_duelInfos = new List<GuildArenaDuelInfo>();
			for (int i = 0; i < this.m_length; i++)
			{
				GuildArenaDuelInfo guildArenaDuelInfo = new GuildArenaDuelInfo();
				guildArenaDuelInfo.Init(base.transform.FindChild(XSingleton<XCommon>.singleton.StringCombine("DuelList/Duel", i.ToString())), i);
				guildArenaDuelInfo.Reset();
				this.m_duelInfos.Add(guildArenaDuelInfo);
			}
		}

		// Token: 0x0600F6A1 RID: 63137 RVA: 0x0037FADB File Offset: 0x0037DCDB
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendIntegralBattleInfo();
			this.RefreshData();
		}

		// Token: 0x0600F6A2 RID: 63138 RVA: 0x0037FAF8 File Offset: 0x0037DCF8
		public override void RefreshData()
		{
			base.RefreshData();
			this.m_UnApply.gameObject.SetActive(!this._Doc.RegistrationStatu);
			this.m_DuelList.gameObject.SetActive(this._Doc.RegistrationStatu);
			bool registrationStatu = this._Doc.RegistrationStatu;
			if (registrationStatu)
			{
				int i = 0;
				int count = this.m_duelInfos.Count;
				while (i < count)
				{
					this.m_duelInfos[i].Refresh();
					i++;
				}
			}
		}

		// Token: 0x04006B24 RID: 27428
		private XGuildArenaDocument _Doc;

		// Token: 0x04006B25 RID: 27429
		private List<GuildArenaDuelInfo> m_duelInfos;

		// Token: 0x04006B26 RID: 27430
		private Transform m_UnApply;

		// Token: 0x04006B27 RID: 27431
		private Transform m_DuelList;

		// Token: 0x04006B28 RID: 27432
		private int m_length = 4;

		// Token: 0x04006B29 RID: 27433
		private IXUILabel m_DuelHelp;
	}
}
