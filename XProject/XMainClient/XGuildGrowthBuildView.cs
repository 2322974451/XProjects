using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildGrowthBuildView : DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildGrowth/GuildGrowthBuildDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XGuildGrowthDocument>(XGuildGrowthDocument.uuID);
			this._guildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
		}

		protected override void OnHide()
		{
			base.OnHide();
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.QueryBuildRank();
			this.RefreshRank();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.QueryBuildRank();
			this.RefreshRank();
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisible(false, true);
			return false;
		}

		private bool OnHelpBtnClick(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildLab_Build);
			return true;
		}

		private void OnHelpClick(IXUISprite iSp)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp((XSysDefine)iSp.ID);
		}

		public bool OnDonateClick(IXUIButton btn)
		{
			DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.DonateType = GuildDonateType.GrowthDonate;
			DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisible(true, true);
			return true;
		}

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

		public void WrapListUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.RankList.Count;
			if (!flag)
			{
				this.SetRankTpl(t, index, false);
			}
		}

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

		private XGuildGrowthDocument _doc;

		private XGuildDocument _guildDoc;
	}
}
