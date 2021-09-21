using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017CB RID: 6091
	internal class MilitaryRankDlg : DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>
	{
		// Token: 0x17003898 RID: 14488
		// (get) Token: 0x0600FC51 RID: 64593 RVA: 0x003ACFEC File Offset: 0x003AB1EC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003899 RID: 14489
		// (get) Token: 0x0600FC52 RID: 64594 RVA: 0x003AD000 File Offset: 0x003AB200
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700389A RID: 14490
		// (get) Token: 0x0600FC53 RID: 64595 RVA: 0x003AD014 File Offset: 0x003AB214
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700389B RID: 14491
		// (get) Token: 0x0600FC54 RID: 64596 RVA: 0x003AD028 File Offset: 0x003AB228
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700389C RID: 14492
		// (get) Token: 0x0600FC55 RID: 64597 RVA: 0x003AD03C File Offset: 0x003AB23C
		public override string fileName
		{
			get
			{
				return "GameSystem/MilitaryRankDlg";
			}
		}

		// Token: 0x1700389D RID: 14493
		// (get) Token: 0x0600FC56 RID: 64598 RVA: 0x003AD054 File Offset: 0x003AB254
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MilitaryRank);
			}
		}

		// Token: 0x0600FC57 RID: 64599 RVA: 0x003AD070 File Offset: 0x003AB270
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XMilitaryRankDocument>(XMilitaryRankDocument.uuID);
			this.SetRewardInfo();
			base.uiBehaviour.m_RewardFrame.SetActive(false);
			DlgHandlerBase.EnsureCreate<BattleRecordHandler>(ref this.m_BattleRecordHandler, base.uiBehaviour.m_BattleRecordFrame, null, false);
		}

		// Token: 0x0600FC58 RID: 64600 RVA: 0x003AD0C8 File Offset: 0x003AB2C8
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_RewardBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRewardBtnClick));
			base.uiBehaviour.m_RecordBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRecordBtnClick));
			base.uiBehaviour.m_RewardCloseBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRewardCloseBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdated));
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseBtnClick));
			base.uiBehaviour.m_RewardSeasonIcb.ID = 1UL;
			base.uiBehaviour.m_RewardResultIcb.ID = 2UL;
			base.uiBehaviour.m_RewardSeasonIcb.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRewardCheckBoxClick));
			base.uiBehaviour.m_RewardResultIcb.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRewardCheckBoxClick));
			base.uiBehaviour.m_RecordHBtab.ID = 1UL;
			base.uiBehaviour.m_RecordCPtab.ID = 0UL;
			base.uiBehaviour.m_RecordHBtab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRecordTabClick));
			base.uiBehaviour.m_RecordCPtab.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnRecordTabClick));
			IXUIButton ixuibutton = base.uiBehaviour.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpBtnClicked));
		}

		// Token: 0x0600FC59 RID: 64601 RVA: 0x003AD266 File Offset: 0x003AB466
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.m_snapshotTransfrom);
			this._doc.QueryRankInfo();
		}

		// Token: 0x0600FC5A RID: 64602 RVA: 0x003AD293 File Offset: 0x003AB493
		protected override void OnHide()
		{
			this.m_BattleRecordHandler.SetVisible(false);
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
			base.OnHide();
		}

		// Token: 0x0600FC5B RID: 64603 RVA: 0x003AD2B7 File Offset: 0x003AB4B7
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FC5C RID: 64604 RVA: 0x003AD2C1 File Offset: 0x003AB4C1
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
		}

		// Token: 0x0600FC5D RID: 64605 RVA: 0x003AD2CB File Offset: 0x003AB4CB
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<BattleRecordHandler>(ref this.m_BattleRecordHandler);
			base.OnUnload();
		}

		// Token: 0x0600FC5E RID: 64606 RVA: 0x003AD2E4 File Offset: 0x003AB4E4
		public void Refresh()
		{
			this.SetBaseInfo();
			base.uiBehaviour.m_WrapContent.SetContentCount(this._doc.RankList.Count, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
			this.SetRankData(base.uiBehaviour.m_MyRank, true, 0);
		}

		// Token: 0x0600FC5F RID: 64607 RVA: 0x003AD340 File Offset: 0x003AB540
		private void SetBaseInfo()
		{
			XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
			DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
			int hours = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).Hours;
			dateTime = dateTime.AddSeconds((double)((ulong)specificDocument.ServerTimeSince1970 + (ulong)((long)(hours * 3600))));
			int num = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
			string arg = string.Format("{0}.{1}.1-{2}.{3}.{4}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Year,
				dateTime.Month,
				num
			});
			base.uiBehaviour.m_DateTime.SetText(string.Format(XStringDefineProxy.GetString("MilitaryDateTime"), arg));
			MilitaryRankByExploit.RowData byMilitaryRank = this._doc.MilitaryReader.GetByMilitaryRank(this._doc.MyData.MilitaryLevel);
			bool flag = byMilitaryRank == null;
			if (!flag)
			{
				MilitaryRankByExploit.RowData byMilitaryRank2 = this._doc.MilitaryReader.GetByMilitaryRank(this._doc.MyData.MilitaryLevel + 1U);
				base.uiBehaviour.m_MilitaryValue.SetText(this._doc.MyData.MilitaryPoint.ToString());
				base.uiBehaviour.m_MilitaryRange.SetText(byMilitaryRank.ShowRange);
				base.uiBehaviour.m_NextMilitary.SetText((byMilitaryRank2 == null) ? XStringDefineProxy.GetString("MilitaryLevelMax") : byMilitaryRank2.Name);
				base.uiBehaviour.m_NextMilitaryIcon.spriteName = ((byMilitaryRank2 == null) ? "" : byMilitaryRank2.Icon);
				base.uiBehaviour.m_MilitaryName.SetText(byMilitaryRank.Name);
				base.uiBehaviour.m_MilitaryIcon.spriteName = byMilitaryRank.Icon;
			}
		}

		// Token: 0x0600FC60 RID: 64608 RVA: 0x003AD53C File Offset: 0x003AB73C
		private void WrapListUpdated(Transform t, int i)
		{
			bool flag = i < 0 || i >= this._doc.RankList.Count;
			if (!flag)
			{
				base.uiBehaviour.m_EmptyRank.SetActive(this._doc.RankList.Count == 0);
				this.SetRankData(t, false, i);
			}
		}

		// Token: 0x0600FC61 RID: 64609 RVA: 0x003AD59C File Offset: 0x003AB79C
		private void SetRankData(Transform t, bool isMy, int index)
		{
			MilitaryRankData militaryRankData = isMy ? this._doc.MyData : this._doc.RankList[index];
			MilitaryRankByExploit.RowData byMilitaryRank = this._doc.MilitaryReader.GetByMilitaryRank(militaryRankData.MilitaryLevel);
			IXUILabel ixuilabel = t.Find("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.Find("RankImage").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel2 = t.Find("MilitaryName").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = t.Find("MilitaryIcon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel3 = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = t.Find("Value").GetComponent("XUILabel") as IXUILabel;
			if (isMy)
			{
				GameObject gameObject = t.Find("OutOfRange").gameObject;
				ixuilabel.SetVisible(militaryRankData.rank != uint.MaxValue);
				gameObject.SetActive(militaryRankData.rank == uint.MaxValue);
			}
			bool flag = militaryRankData.rank < 3U;
			if (flag)
			{
				ixuisprite.SetVisible(true);
				ixuisprite.spriteName = string.Format("N{0}", militaryRankData.rank + 1U);
			}
			else
			{
				ixuisprite.SetVisible(false);
				ixuilabel.SetText((militaryRankData.rank + 1U).ToString());
			}
			ixuisprite2.spriteName = ((byMilitaryRank == null) ? "" : byMilitaryRank.Icon);
			ixuilabel2.SetText((byMilitaryRank == null) ? XStringDefineProxy.GetString("NONE") : byMilitaryRank.Name);
			ixuilabel3.SetText(militaryRankData.name);
			ixuilabel4.SetText(militaryRankData.MilitaryPoint.ToString());
		}

		// Token: 0x0600FC62 RID: 64610 RVA: 0x003AD77C File Offset: 0x003AB97C
		private void SetRewardInfo()
		{
			base.uiBehaviour.m_RewardItemPool.ReturnAll(true);
			base.uiBehaviour.m_RewardSeasonPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_RewardSeasonPool.TplPos;
			for (int i = 0; i < this._doc.MilitarySeasonReader.Table.Length; i++)
			{
				MilitaryRankReward.RowData rowData = this._doc.MilitarySeasonReader.Table[i];
				GameObject gameObject = base.uiBehaviour.m_RewardSeasonPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * base.uiBehaviour.m_RewardSeasonPool.TplHeight));
				IXUILabel ixuilabel = gameObject.transform.Find("Rank").GetComponent("XUILabel") as IXUILabel;
				Transform parent = gameObject.transform.Find("Reward");
				bool flag = rowData.Rank[0] == rowData.Rank[1];
				if (flag)
				{
					ixuilabel.SetText(string.Format("No.{0}", rowData.Rank[0]));
				}
				else
				{
					ixuilabel.SetText(string.Format("No.{0}-{1}", rowData.Rank[0], rowData.Rank[1]));
				}
				for (int j = 0; j < (int)rowData.Reward.count; j++)
				{
					GameObject gameObject2 = base.uiBehaviour.m_RewardItemPool.FetchGameObject(false);
					gameObject2.transform.parent = parent;
					gameObject2.transform.localScale = Vector3.one;
					gameObject2.transform.localPosition = new Vector3((float)(j * base.uiBehaviour.m_RewardItemPool.TplWidth), 0f);
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)rowData.Reward[j, 0]);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, itemConf, (int)rowData.Reward[j, 1], false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject2, (int)rowData.Reward[j, 0]);
				}
			}
			base.uiBehaviour.m_RewardResultPool.ReturnAll(false);
			tplPos = base.uiBehaviour.m_RewardResultPool.TplPos;
			for (int k = 0; k < this._doc.MilitaryReader.Table.Length; k++)
			{
				MilitaryRankByExploit.RowData rowData2 = this._doc.MilitaryReader.Table[k];
				bool flag2 = rowData2.MilitaryExploit[0] == 0U && rowData2.MilitaryExploit[1] == 0U;
				GameObject gameObject3 = base.uiBehaviour.m_RewardResultPool.FetchGameObject(false);
				gameObject3.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(k * base.uiBehaviour.m_RewardResultPool.TplHeight));
				IXUISprite ixuisprite = gameObject3.transform.Find("MilitaryIcon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = gameObject3.transform.Find("MilitaryName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject3.transform.Find("Value").GetComponent("XUILabel") as IXUILabel;
				ixuisprite.spriteName = rowData2.Icon;
				ixuilabel2.SetText(rowData2.Name);
				bool flag3 = flag2;
				if (flag3)
				{
					ixuilabel3.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(rowData2.RewardTips));
				}
				else
				{
					ixuilabel3.SetText(string.Format("{0}-{1}", rowData2.MilitaryExploit[0], rowData2.MilitaryExploit[1]));
				}
				Transform parent2 = gameObject3.transform.Find("Reward");
				for (int l = 0; l < (int)rowData2.Reward.count; l++)
				{
					GameObject gameObject4 = base.uiBehaviour.m_RewardItemPool.FetchGameObject(false);
					gameObject4.transform.parent = parent2;
					gameObject4.transform.localScale = Vector3.one;
					gameObject4.transform.localPosition = new Vector3((float)(l * base.uiBehaviour.m_RewardItemPool.TplWidth), 0f);
					ItemList.RowData itemConf2 = XBagDocument.GetItemConf((int)rowData2.Reward[l, 0]);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject4, itemConf2, (int)rowData2.Reward[l, 1], false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.OpenClickShowTooltipEvent(gameObject4, (int)rowData2.Reward[l, 0]);
				}
			}
		}

		// Token: 0x0600FC63 RID: 64611 RVA: 0x003ADC70 File Offset: 0x003ABE70
		private bool OnCloseBtnClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600FC64 RID: 64612 RVA: 0x003ADC8C File Offset: 0x003ABE8C
		private void OnRewardBtnClick(IXUISprite iSp)
		{
			base.uiBehaviour.m_RewardFrame.SetActive(true);
		}

		// Token: 0x0600FC65 RID: 64613 RVA: 0x003ADCA4 File Offset: 0x003ABEA4
		private void OnRecordBtnClick(IXUISprite iSp)
		{
			this.m_BattleRecordHandler.SetVisible(true);
			bool bChecked = base.uiBehaviour.m_RecordHBtab.bChecked;
			if (bChecked)
			{
				this.OnRecordTabClick(base.uiBehaviour.m_RecordHBtab);
			}
			else
			{
				this.OnRecordTabClick(base.uiBehaviour.m_RecordCPtab);
			}
		}

		// Token: 0x0600FC66 RID: 64614 RVA: 0x003ADCFC File Offset: 0x003ABEFC
		private bool OnRecordTabClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = icb.ID == 1UL;
				if (flag2)
				{
					XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					specificDocument.QueryBattleRecord();
				}
				else
				{
					XCaptainPVPDocument specificDocument2 = XDocuments.GetSpecificDocument<XCaptainPVPDocument>(XCaptainPVPDocument.uuID);
					specificDocument2.ReqGetHistory();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600FC67 RID: 64615 RVA: 0x003ADD5A File Offset: 0x003ABF5A
		private void OnRewardCloseBtnClick(IXUISprite iSp)
		{
			base.uiBehaviour.m_RewardFrame.SetActive(false);
		}

		// Token: 0x0600FC68 RID: 64616 RVA: 0x003ADD70 File Offset: 0x003ABF70
		private bool OnRewardCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				base.uiBehaviour.m_RewardSeasonFrame.SetActive(icb.ID == 1UL);
				base.uiBehaviour.m_RewardResultFrame.SetActive(icb.ID != 1UL);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FC69 RID: 64617 RVA: 0x003ADDD0 File Offset: 0x003ABFD0
		private bool OnHelpBtnClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_MilitaryRank);
			return true;
		}

		// Token: 0x04006EEB RID: 28395
		private XMilitaryRankDocument _doc = null;

		// Token: 0x04006EEC RID: 28396
		public BattleRecordHandler m_BattleRecordHandler;
	}
}
