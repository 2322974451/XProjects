using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildQualifierHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/GuildQualifierRankFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			this.m_qualifierContent = (base.transform.FindChild("ScrollView/Rank").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_qualifierScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_timeLabel = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_qualifierContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GuildQualifierWrapUpdate));
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
		}

		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
			base.OnUnload();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.CheckActive();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = this.refreshTime > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
			}
			this.CheckActive();
			this.refreshTime = XSingleton<XTimerMgr>.singleton.SetTimer((float)XSingleton<XGlobalConfig>.singleton.GetInt("GuildLadderRefreshTime"), new XTimerMgr.ElapsedEventHandler(this.UpdateTimeFrame), null);
			bool flag2 = this._Doc.GuildRankList == null;
			if (flag2)
			{
				this.m_qualifierContent.SetContentCount(0, false);
			}
			else
			{
				this.m_qualifierContent.SetContentCount(this._Doc.GuildRankList.Count, false);
			}
		}

		private void CheckActive()
		{
			bool flag = this._Doc.ActiveTime > 0.0;
			if (flag)
			{
				this.m_timeLabel.SetText(XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE1", new object[]
				{
					XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.ActiveTime, 5)
				}));
			}
			else
			{
				this.m_timeLabel.SetText(XStringDefineProxy.GetString("GUILD_QUALIFER_STYLE2"));
			}
		}

		private void UpdateTimeFrame(object o)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
			this._Doc.SendGuildLadderRankInfo();
		}

		private void GuildQualifierWrapUpdate(Transform t, int index)
		{
			bool flag = index >= this._Doc.GuildRankList.Count;
			if (!flag)
			{
				GuildLadderRank guildLadderRank = this._Doc.GuildRankList[index];
				IXUISprite ixuisprite = t.FindChild("IndexSprite").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.FindChild("Index").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Winner").GetComponent("XUILabel") as IXUILabel;
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				string s = XLabelSymbolHelper.FormatImage("common/Billboard", XGuildDocument.GetPortraitName((int)guildLadderRank.icon));
				ixuilabel2.SetText(guildLadderRank.wintimes.ToString());
				ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.StringCombine(s, guildLadderRank.guildname);
				bool flag2 = index < 3;
				if (flag2)
				{
					ixuilabel.Alpha = 0f;
					ixuisprite.SetAlpha(1f);
					ixuisprite.SetSprite(XSingleton<XCommon>.singleton.StringCombine("N", (index + 1).ToString()));
				}
				else
				{
					ixuilabel.Alpha = 1f;
					ixuisprite.SetAlpha(0f);
				}
			}
		}

		private IXUIWrapContent m_qualifierContent;

		private IXUIScrollView m_qualifierScrollView;

		private IXUILabel m_timeLabel;

		private XGuildQualifierDocument _Doc;

		private uint refreshTime = 0U;
	}
}
