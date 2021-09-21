using System;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200176C RID: 5996
	internal class GuildQualifierHandler : DlgHandlerBase
	{
		// Token: 0x17003816 RID: 14358
		// (get) Token: 0x0600F78C RID: 63372 RVA: 0x0038617C File Offset: 0x0038437C
		protected override string FileName
		{
			get
			{
				return "Guild/GuildQualifierRankFrame";
			}
		}

		// Token: 0x0600F78D RID: 63373 RVA: 0x00386194 File Offset: 0x00384394
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildQualifierDocument>(XGuildQualifierDocument.uuID);
			this.m_qualifierContent = (base.transform.FindChild("ScrollView/Rank").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_qualifierScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_timeLabel = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_qualifierContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GuildQualifierWrapUpdate));
		}

		// Token: 0x0600F78E RID: 63374 RVA: 0x00386240 File Offset: 0x00384440
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
		}

		// Token: 0x0600F78F RID: 63375 RVA: 0x0038625B File Offset: 0x0038445B
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
			base.OnUnload();
		}

		// Token: 0x0600F790 RID: 63376 RVA: 0x00386276 File Offset: 0x00384476
		public override void OnUpdate()
		{
			base.OnUpdate();
			this.CheckActive();
		}

		// Token: 0x0600F791 RID: 63377 RVA: 0x00386288 File Offset: 0x00384488
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

		// Token: 0x0600F792 RID: 63378 RVA: 0x00386330 File Offset: 0x00384530
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

		// Token: 0x0600F793 RID: 63379 RVA: 0x003863A6 File Offset: 0x003845A6
		private void UpdateTimeFrame(object o)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.refreshTime);
			this._Doc.SendGuildLadderRankInfo();
		}

		// Token: 0x0600F794 RID: 63380 RVA: 0x003863C8 File Offset: 0x003845C8
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

		// Token: 0x04006BCE RID: 27598
		private IXUIWrapContent m_qualifierContent;

		// Token: 0x04006BCF RID: 27599
		private IXUIScrollView m_qualifierScrollView;

		// Token: 0x04006BD0 RID: 27600
		private IXUILabel m_timeLabel;

		// Token: 0x04006BD1 RID: 27601
		private XGuildQualifierDocument _Doc;

		// Token: 0x04006BD2 RID: 27602
		private uint refreshTime = 0U;
	}
}
