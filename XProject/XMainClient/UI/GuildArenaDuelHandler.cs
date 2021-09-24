using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildArenaDuelHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildArena/DuelFrame";
			}
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendIntegralBattleInfo();
			this.RefreshData();
		}

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

		private XGuildArenaDocument _Doc;

		private List<GuildArenaDuelInfo> m_duelInfos;

		private Transform m_UnApply;

		private Transform m_DuelList;

		private int m_length = 4;

		private IXUILabel m_DuelHelp;
	}
}
