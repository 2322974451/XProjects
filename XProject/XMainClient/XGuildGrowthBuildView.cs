using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A65 RID: 2661
	internal class XGuildGrowthBuildView : DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>
	{
		// Token: 0x17002F20 RID: 12064
		// (get) Token: 0x0600A157 RID: 41303 RVA: 0x001B4AEC File Offset: 0x001B2CEC
		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthBuildDlg";
			}
		}

		// Token: 0x17002F21 RID: 12065
		// (get) Token: 0x0600A158 RID: 41304 RVA: 0x001B4B04 File Offset: 0x001B2D04
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F22 RID: 12066
		// (get) Token: 0x0600A159 RID: 41305 RVA: 0x001B4B18 File Offset: 0x001B2D18
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17002F23 RID: 12067
		// (get) Token: 0x0600A15A RID: 41306 RVA: 0x001B4B2C File Offset: 0x001B2D2C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F24 RID: 12068
		// (get) Token: 0x0600A15B RID: 41307 RVA: 0x001B4B40 File Offset: 0x001B2D40
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F25 RID: 12069
		// (get) Token: 0x0600A15C RID: 41308 RVA: 0x001B4B54 File Offset: 0x001B2D54
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600A15D RID: 41309 RVA: 0x001B4B67 File Offset: 0x001B2D67
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			this._guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		// Token: 0x0600A15E RID: 41310 RVA: 0x001B4B8A File Offset: 0x001B2D8A
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600A15F RID: 41311 RVA: 0x001B4B94 File Offset: 0x001B2D94
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600A160 RID: 41312 RVA: 0x001B4BA0 File Offset: 0x001B2DA0
		public override void RegisterEvent()
		{
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClick));
			base.uiBehaviour.m_RankWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			base.uiBehaviour.HuntTips.ID = 825UL;
			base.uiBehaviour.HuntTips.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClick));
			base.uiBehaviour.DonateTips.ID = 826UL;
			base.uiBehaviour.DonateTips.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClick));
			base.uiBehaviour.HuntBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHuntClick));
			base.uiBehaviour.DonateBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDonateClick));
			base.uiBehaviour.Tag1Click.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTagClickTip1));
			base.uiBehaviour.Tag2Click.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTagClickTip2));
		}

		// Token: 0x0600A161 RID: 41313 RVA: 0x001B4CE1 File Offset: 0x001B2EE1
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuildRank();
			this.RefreshRank();
		}

		// Token: 0x0600A162 RID: 41314 RVA: 0x001B4CFE File Offset: 0x001B2EFE
		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.QueryBuildRank();
			this.RefreshRank();
		}

		// Token: 0x0600A163 RID: 41315 RVA: 0x001B4D1C File Offset: 0x001B2F1C
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return false;
		}

		// Token: 0x0600A164 RID: 41316 RVA: 0x001B4D38 File Offset: 0x001B2F38
		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildLab_Build);
			return true;
		}

		// Token: 0x0600A165 RID: 41317 RVA: 0x001B4D5B File Offset: 0x001B2F5B
		private void OnHelpClick(IXUISprite iSp)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp((XSysDefine)iSp.ID);
		}

		// Token: 0x0600A166 RID: 41318 RVA: 0x001B4D70 File Offset: 0x001B2F70
		public bool OnDonateClick(IXUIButton btn)
		{
			DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.DonateType = GuildDonateType.GrowthDonate;
			DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x0600A167 RID: 41319 RVA: 0x001B4D9C File Offset: 0x001B2F9C
		public void OnTagClickTip1(IXUISprite iSp)
		{
			GuildConfigTable.RowData dataByLevel = XGuildDocument.GuildConfig.GetDataByLevel(this._guildDoc.Level);
			bool flag = dataByLevel == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("can't find guild data form guildconfig, level = ", this._guildDoc.Level.ToString(), null, null, null, null);
			}
			else
			{
				string label = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildGrowthTagTips1")), dataByLevel.JZSalaryOpen);
				XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"));
			}
		}

		// Token: 0x0600A168 RID: 41320 RVA: 0x001B4E30 File Offset: 0x001B3030
		public void OnTagClickTip2(IXUISprite iSp)
		{
			GuildConfigTable.RowData dataByLevel = XGuildDocument.GuildConfig.GetDataByLevel(this._guildDoc.Level);
			bool flag = dataByLevel == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("can't find guild data form guildconfig, level = ", this._guildDoc.Level.ToString(), null, null, null, null);
			}
			else
			{
				string label = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildGrowthTagTips2")), dataByLevel.JZSaleOpen);
				XSingleton<UiUtility>.singleton.ShowModalDialog(label, XStringDefineProxy.GetString("COMMON_OK"));
			}
		}

		// Token: 0x0600A169 RID: 41321 RVA: 0x001B4EC4 File Offset: 0x001B30C4
		public bool OnHuntClick(IXUIButton btn)
		{
			bool flag = XSingleton<XScene>.singleton.SceneID == 4U;
			if (flag)
			{
				this.SetVisible(false, true);
				bool flag2 = DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.SetVisible(false, true);
				}
				this._doc.FindNpc();
			}
			else
			{
				this._doc.AutoFindNpc = true;
				this._guildDoc.TryEnterGuildScene();
			}
			return true;
		}

		// Token: 0x0600A16A RID: 41322 RVA: 0x001B4F38 File Offset: 0x001B3138
		public void RefreshRank()
		{
			bool flag = this._doc.RankList.Count == 0;
			if (!flag)
			{
				this.SetRankTpl(base.uiBehaviour.m_MyRankTs, 0, true);
				base.uiBehaviour.m_RankWrapContent.SetContentCount(this._doc.RankList.Count, false);
				base.uiBehaviour.m_RankScrollView.ResetPosition();
				GuildConfigTable.RowData dataByLevel = XGuildDocument.GuildConfig.GetDataByLevel(this._guildDoc.Level);
				bool flag2 = dataByLevel == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("can't find guild data form guildconfig, level = ", this._guildDoc.Level.ToString(), null, null, null, null);
				}
				else
				{
					float num = dataByLevel.JZHallTotalmax + dataByLevel.JZSchoolTotalMax;
					base.uiBehaviour.m_ProgressNum.SetText(string.Format("{0}/{1}", this._doc.WeekHallPoint + this._doc.WeekSchoolPoint, dataByLevel.JZHallTotalmax + dataByLevel.JZSchoolTotalMax));
					base.uiBehaviour.m_Progress.value = (this._doc.WeekHallPoint + this._doc.WeekSchoolPoint) / num;
					float y = base.uiBehaviour.Tag2.localPosition.y;
					base.uiBehaviour.Tag1.transform.localPosition = new Vector3(base.uiBehaviour.startX + base.uiBehaviour.allDepth * dataByLevel.JZSalaryOpen / num, y);
					base.uiBehaviour.Tag2.transform.localPosition = new Vector3(base.uiBehaviour.startX + base.uiBehaviour.allDepth * dataByLevel.JZSaleOpen / num, y);
					base.uiBehaviour.Tag1Num.SetText(string.Format("{0:F1}{1}", dataByLevel.JZSalaryOpen / 10000f, XStringDefineProxy.GetString("NumberSeparator0")));
					base.uiBehaviour.Tag2Num.SetText(string.Format("{0:F1}{1}", dataByLevel.JZSaleOpen / 10000f, XStringDefineProxy.GetString("NumberSeparator0")));
					base.uiBehaviour.m_WeekNumShow.SetText(string.Format(XStringDefineProxy.GetString("GuildGrowthMyNum"), this._doc.MyData.HallPoint + this._doc.MyData.SchoolPoint));
					base.uiBehaviour.HuntText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildGrowthHuntTips")));
					base.uiBehaviour.DonateText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildGrowthDonateTips")));
					int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GuildJZHuntMaxCount");
					int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("GuildJZDonateMaxCount");
					base.uiBehaviour.HuntTimes.SetText(string.Format("{0}/{1}", this._doc.WeekHuntTimes, @int));
					base.uiBehaviour.DonateTimes.SetText(string.Format("{0}/{1}", this._doc.WeekDonateTimes, int2));
					base.uiBehaviour.HuntRedPoint.SetActive((ulong)this._doc.WeekHuntTimes < (ulong)((long)@int));
					base.uiBehaviour.DonateRedPoint.SetActive((ulong)this._doc.WeekDonateTimes < (ulong)((long)int2));
				}
			}
		}

		// Token: 0x0600A16B RID: 41323 RVA: 0x001B52D8 File Offset: 0x001B34D8
		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.RankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

		// Token: 0x0600A16C RID: 41324 RVA: 0x001B5314 File Offset: 0x001B3514
		public void SetRankTpl(Transform t, int index, bool isMy)
		{
			XGuildGrowthDocument.GuildGrowthRankData guildGrowthRankData = isMy ? this._doc.MyData : this._doc.RankList[index];
			IXUILabel ixuilabel = t.Find("Rank3").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.Find("Rank").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("Point").GetComponent("XUILabel") as IXUILabel;
			int num = isMy ? this._doc.MyRank : index;
			bool flag = num < 3;
			if (flag)
			{
				ixuisprite.SetVisible(true);
				ixuilabel.SetVisible(false);
				ixuisprite.spriteName = string.Format("N{0}", num + 1);
			}
			else
			{
				ixuisprite.SetVisible(false);
				ixuilabel.SetVisible(true);
				ixuilabel.SetText(string.Format("No.{0}", num + 1));
			}
			bool flag2 = !isMy;
			if (flag2)
			{
				ixuilabel2.SetText(guildGrowthRankData.Name);
			}
			ixuilabel3.SetText((guildGrowthRankData.HallPoint + guildGrowthRankData.SchoolPoint).ToString());
		}

		// Token: 0x04003A30 RID: 14896
		private XGuildGrowthDocument _doc;

		// Token: 0x04003A31 RID: 14897
		private XGuildDocument _guildDoc;
	}
}
