using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181F RID: 6175
	internal class XAchieveView : DlgHandlerBase
	{
		// Token: 0x06010075 RID: 65653 RVA: 0x003CF804 File Offset: 0x003CDA04
		private void InitDetail()
		{
			this.m_PanelScrollView = (base.PanelObject.transform.FindChild("detail/detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("detail/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x06010076 RID: 65654 RVA: 0x003CF880 File Offset: 0x003CDA80
		private void ReqDetailInfo(int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this.m_achieveType = (AchieveType)index;
				this._doc.FetchAchieveType(this.m_achieveType);
			}
		}

		// Token: 0x06010077 RID: 65655 RVA: 0x003CF8B6 File Offset: 0x003CDAB6
		public void RefreshDetails()
		{
			this.m_WrapContent.SetContentCount(this._doc.achievesDetails.Count, false);
			this.m_PanelScrollView.ResetPosition();
		}

		// Token: 0x06010078 RID: 65656 RVA: 0x003CF8E4 File Offset: 0x003CDAE4
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				bool flag2 = index < this._doc.achievesDetails.Count && index >= 0;
				if (flag2)
				{
					AchieveItemInfo info = this._doc.achievesDetails[index];
					this._SetRecord(t, info);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("_doc is nil or index: ", index.ToString(), null, null, null, null);
			}
		}

		// Token: 0x06010079 RID: 65657 RVA: 0x003CF960 File Offset: 0x003CDB60
		protected void _SetRecord(Transform t, AchieveItemInfo info)
		{
			IXUILabel ixuilabel = t.Find("TLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.Find("DLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.Find("CLabel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel4 = t.Find("ch").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.Find("Get").GetComponent("XUIButton") as IXUIButton;
			IXUISprite ixuisprite = t.Find("Icon").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.Find("Fini").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite3 = t.Find("RedPoint").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject = t.Find("ch_desc").gameObject;
			GameObject gameObject2 = t.Find("bj").gameObject;
			GameObject gameObject3 = t.Find("bj/bj").gameObject;
			ixuilabel.SetText(info.row.Achievement);
			ixuilabel2.SetText(info.row.Explanation);
			string text = string.Empty;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("AchieveColor");
			for (int i = 0; i < info.row.Reward.Count; i++)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(info.row.Reward[i, 0]);
				text = string.Concat(new object[]
				{
					text,
					"[c]",
					value,
					itemConf.ItemName[0],
					"[-][/c] ",
					info.row.Reward[i, 1]
				});
				bool flag = i != info.row.Reward.Count - 1;
				if (flag)
				{
					text += "\n";
				}
			}
			ixuilabel3.SetText(text);
			gameObject3.SetActive(info.state == AchieveState.Claim);
			ixuisprite3.SetVisible(info.state == AchieveState.Claim);
			ixuisprite2.SetVisible(info.state == AchieveState.Claimed);
			ixuibutton.SetVisible(info.state != AchieveState.Claimed);
			gameObject2.SetActive(info.state != AchieveState.Normal);
			ixuisprite.SetSprite(info.row.ICON);
			bool flag2 = info.row.DesignationName != "";
			if (flag2)
			{
				ixuilabel4.gameObject.SetActive(true);
				gameObject.SetActive(true);
				ixuilabel4.SetText(info.row.DesignationName);
			}
			else
			{
				ixuilabel4.gameObject.SetActive(false);
				gameObject.SetActive(false);
			}
			ixuibutton.SetEnable(info.state != AchieveState.Normal, false);
			ixuibutton.ID = (ulong)((long)info.row.ID);
			bool flag3 = info.state != AchieveState.Normal;
			if (flag3)
			{
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBtnClick));
			}
		}

		// Token: 0x0601007A RID: 65658 RVA: 0x003CFCA4 File Offset: 0x003CDEA4
		public bool UnCompleteTipsBtn(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Achi_Or_Des_UnComplete"), "fece00");
			return true;
		}

		// Token: 0x0601007B RID: 65659 RVA: 0x003CFCD4 File Offset: 0x003CDED4
		private bool OnBtnClick(IXUIButton btn)
		{
			AchieveItemInfo achieveItemInfo = new AchieveItemInfo();
			bool flag = false;
			for (int i = 0; i < this._doc.achievesDetails.Count; i++)
			{
				bool flag2 = this._doc.achievesDetails[i].row.ID == (int)btn.ID;
				if (flag2)
				{
					flag = true;
					achieveItemInfo = this._doc.achievesDetails[i];
					break;
				}
			}
			bool flag3 = flag && achieveItemInfo.state == AchieveState.Claim;
			if (flag3)
			{
				this._doc.ClaimAchieve(achieveItemInfo.row.ID);
			}
			return true;
		}

		// Token: 0x0601007C RID: 65660 RVA: 0x003CFD84 File Offset: 0x003CDF84
		private void InitSurvey()
		{
			this.m_labAchipoint = (base.PanelObject.transform.Find("survey/title/Bg/TextLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_proAchiAll = (base.PanelObject.transform.Find("survey/slider").GetComponent("XUIProgress") as IXUIProgress);
			this.m_lblAchiAll = (base.PanelObject.transform.Find("survey/slider/PLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_rewarDesc = (base.PanelObject.transform.Find("survey/desc/DescLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_getBtn = (base.PanelObject.transform.Find("survey/Get").GetComponent("XUIButton") as IXUIButton);
			this.m_sprRed = (base.PanelObject.transform.Find("survey/Get/RedPoint").GetComponent("XUISprite") as IXUISprite);
			for (int i = 0; i < this.m_proAchivType.Length; i++)
			{
				this.m_proAchivType[i] = (base.PanelObject.transform.Find("survey/right/cj" + i + "/slider1").GetComponent("XUIProgress") as IXUIProgress);
				this.m_lblAchiType[i] = (base.PanelObject.transform.Find("survey/right/cj" + i + "/slider1/PLabel").GetComponent("XUILabel") as IXUILabel);
			}
			for (int j = 0; j < this.m_rwds.Length; j++)
			{
				this.m_rwds[j] = base.PanelObject.transform.Find("survey/items/item" + j).gameObject;
			}
			this.m_getBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetRewardBtnClick));
		}

		// Token: 0x0601007D RID: 65661 RVA: 0x003CFF80 File Offset: 0x003CE180
		public bool OnGetRewardBtnClick(IXUIButton btn)
		{
			bool flag = this._doc != null && this._doc.achieveSurveyInfo != null;
			if (flag)
			{
				this._doc.SendQueryGetAchiPointReward(this._doc.achieveSurveyInfo.rewardId);
			}
			return true;
		}

		// Token: 0x0601007E RID: 65662 RVA: 0x003CFFCC File Offset: 0x003CE1CC
		public void RequstSurvey()
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.FetchAchieveSurvey();
			}
		}

		// Token: 0x0601007F RID: 65663 RVA: 0x003CFFF4 File Offset: 0x003CE1F4
		public void RefreshSurvey()
		{
			bool flag = this._doc != null && this._doc.achieveSurveyInfo != null;
			if (flag)
			{
				this.m_labAchipoint.SetText(this._doc.achieveSurveyInfo.achievePoint.ToString());
			}
			this.RefreshRws();
			this.RefreshTypes();
			this.RefreshProAll();
			this.RefreshPoints();
		}

		// Token: 0x06010080 RID: 65664 RVA: 0x003D0060 File Offset: 0x003CE260
		private void RefreshRws()
		{
			AchievementPointRewardTable.RowData[] table = XDesignationDocument.achieveRwdTable.Table;
			uint achievePoint = this._doc.achieveSurveyInfo.achievePoint;
			SeqListRef<int> seqListRef = default(SeqListRef<int>);
			bool flag = this._doc.achieveSurveyInfo.rewardId == 0U;
			if (flag)
			{
				this.m_rewarDesc.SetText(XStringDefineProxy.GetString("Achi_Point_Reward_Desc_NULL"));
			}
			else
			{
				this.m_rewarDesc.SetText(string.Format(XStringDefineProxy.GetString("Achi_Point_Reward_Desc"), table[(int)(this._doc.achieveSurveyInfo.rewardId - 1U)].Point));
				seqListRef = table[(int)(this._doc.achieveSurveyInfo.rewardId - 1U)].Reward;
			}
			bool flag2 = this._doc.achieveSurveyInfo.rewardId != 0U && (ulong)achievePoint >= (ulong)((long)table[(int)(this._doc.achieveSurveyInfo.rewardId - 1U)].Point) && seqListRef.Count > 0;
			if (flag2)
			{
				this.m_getBtn.SetEnable(true, false);
				this.m_sprRed.SetVisible(true);
				this.canClaimPoint = true;
			}
			else
			{
				this.m_getBtn.SetEnable(false, false);
				this.m_sprRed.SetVisible(false);
				this.canClaimPoint = false;
			}
			int num = Math.Min(this.m_rwds.Length, seqListRef.Count);
			IXUISprite ixuisprite = this.m_rwds[0].GetComponent("XUISprite") as IXUISprite;
			int spriteWidth = ixuisprite.spriteWidth;
			for (int i = 0; i < num; i++)
			{
				this.m_rwds[i].SetActive(true);
				this.m_rwds[i].transform.localPosition = new Vector3(((float)i - (float)(num - 1) / 2f) * (float)spriteWidth, 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_rwds[i], seqListRef[i, 0], seqListRef[i, 1], false);
			}
			bool flag3 = seqListRef.Count < this.m_rwds.Length;
			if (flag3)
			{
				for (int j = seqListRef.Count; j < this.m_rwds.Length; j++)
				{
					this.m_rwds[j].SetActive(false);
				}
			}
		}

		// Token: 0x06010081 RID: 65665 RVA: 0x003D02BC File Offset: 0x003CE4BC
		private void RefreshTypes()
		{
			for (int i = 0; i < this.m_lblAchiType.Length; i++)
			{
				List<AchieveBriefInfo> dataList = this._doc.achieveSurveyInfo.dataList;
				AchieveBriefInfo achieveBriefInfo = this.ParseBriefInfo(i);
				this.m_lblAchiType[i].SetText(achieveBriefInfo.achievePoint + "/" + achieveBriefInfo.maxAchievePoint);
				float value = achieveBriefInfo.achievePoint / achieveBriefInfo.maxAchievePoint;
				bool flag = achieveBriefInfo.maxAchievePoint == 0U;
				if (flag)
				{
					value = 0f;
				}
				this.m_proAchivType[i].value = value;
			}
		}

		// Token: 0x06010082 RID: 65666 RVA: 0x003D0368 File Offset: 0x003CE568
		private AchieveBriefInfo ParseBriefInfo(int index)
		{
			List<AchieveBriefInfo> dataList = this._doc.achieveSurveyInfo.dataList;
			for (int i = 0; i < dataList.Count; i++)
			{
				bool flag = dataList[i].achieveClassifyType == (uint)(index + 1);
				if (flag)
				{
					return dataList[i];
				}
			}
			return null;
		}

		// Token: 0x06010083 RID: 65667 RVA: 0x003D03C4 File Offset: 0x003CE5C4
		private void RefreshProAll()
		{
			uint achievePoint = this._doc.achieveSurveyInfo.achievePoint;
			uint maxAchievePoint = this._doc.achieveSurveyInfo.maxAchievePoint;
			float value = achievePoint / maxAchievePoint;
			this.m_proAchiAll.value = value;
			this.m_lblAchiAll.SetText(achievePoint + "/" + maxAchievePoint);
		}

		// Token: 0x06010084 RID: 65668 RVA: 0x003D0430 File Offset: 0x003CE630
		public void RefreshPoints()
		{
			bool bState = false;
			bool flag = this.canClaimPoint;
			if (flag)
			{
				bState = true;
			}
			bool flag2 = base.IsVisible();
			if (flag2)
			{
				this.m_padPoint[0].SetVisible(this.canClaimPoint);
				for (int i = 1; i < this.m_padPoint.Length; i++)
				{
					AchieveBriefInfo achieveBriefInfo = this.ParseBriefInfo(i - 1);
					bool flag3 = achieveBriefInfo != null;
					if (flag3)
					{
						bool flag4 = achieveBriefInfo.canRewardCount > 0U;
						if (flag4)
						{
							bState = true;
						}
						this.m_padPoint[i].SetVisible(achieveBriefInfo.canRewardCount > 0U);
					}
				}
			}
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Design_Achieve, bState);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Design_Achieve, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Design, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward, true);
		}

		// Token: 0x06010085 RID: 65669 RVA: 0x003D0508 File Offset: 0x003CE708
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			for (int i = 0; i < this.m_padTabs.Length; i++)
			{
				this.m_padTabs[i] = (base.PanelObject.transform.Find("padTabs/TabTpl" + i + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this.m_padPoint[i] = (base.PanelObject.transform.Find("padTabs/TabTpl" + i + "/Bg/RedPoint").GetComponent("XUISprite") as IXUISprite);
				this.m_padPoint[i].gameObject.SetActive(false);
				bool flag = this.m_padTabs[i] != null;
				if (flag)
				{
					this.m_padTabs[i].ID = (ulong)i;
					this.m_padTabs[i].ForceSetFlag(i == 0);
					this.m_padTabs[i].RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnTabControlStateChange));
				}
			}
			this.m_objSurvey = base.PanelObject.transform.Find("survey").gameObject;
			this.m_objDetail = base.PanelObject.transform.Find("detail").gameObject;
			this.InitSurvey();
			this.InitDetail();
		}

		// Token: 0x06010086 RID: 65670 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06010087 RID: 65671 RVA: 0x003D0674 File Offset: 0x003CE874
		protected override void OnShow()
		{
			base.OnShow();
			this._doc = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
			this._doc.achieveView = this;
			this.m_objSurvey.SetActive(true);
			this.m_objDetail.SetActive(false);
			this.m_padTabs[0].ForceSetFlag(true);
			this.RequstSurvey();
		}

		// Token: 0x06010088 RID: 65672 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x06010089 RID: 65673 RVA: 0x0025083F File Offset: 0x0024EA3F
		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		// Token: 0x0601008A RID: 65674 RVA: 0x003D06D5 File Offset: 0x003CE8D5
		public override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		// Token: 0x0601008B RID: 65675 RVA: 0x003D06E8 File Offset: 0x003CE8E8
		public bool OnTabControlStateChange(IXUICheckBox chkBox)
		{
			bool bChecked = chkBox.bChecked;
			if (bChecked)
			{
				this.OnTabClick((int)chkBox.ID);
			}
			return true;
		}

		// Token: 0x0601008C RID: 65676 RVA: 0x003D0718 File Offset: 0x003CE918
		private void OnTabClick(int index)
		{
			this.m_objDetail.SetActive(index > 0);
			this.m_objSurvey.SetActive(index <= 0);
			bool flag = index <= 0;
			if (flag)
			{
				this.RequstSurvey();
			}
			else
			{
				this.ReqDetailInfo(index);
			}
		}

		// Token: 0x040071F5 RID: 29173
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040071F6 RID: 29174
		public IXUIScrollView m_PanelScrollView;

		// Token: 0x040071F7 RID: 29175
		public AchieveType m_achieveType;

		// Token: 0x040071F8 RID: 29176
		private List<AchieveItemInfo> list = new List<AchieveItemInfo>();

		// Token: 0x040071F9 RID: 29177
		private IXUILabel m_labAchipoint;

		// Token: 0x040071FA RID: 29178
		private IXUIProgress m_proAchiAll;

		// Token: 0x040071FB RID: 29179
		private IXUILabel m_lblAchiAll;

		// Token: 0x040071FC RID: 29180
		private IXUILabel m_rewarDesc;

		// Token: 0x040071FD RID: 29181
		private IXUIButton m_getBtn;

		// Token: 0x040071FE RID: 29182
		private IXUISprite m_sprRed;

		// Token: 0x040071FF RID: 29183
		private IXUIProgress[] m_proAchivType = new IXUIProgress[5];

		// Token: 0x04007200 RID: 29184
		private IXUILabel[] m_lblAchiType = new IXUILabel[5];

		// Token: 0x04007201 RID: 29185
		private GameObject[] m_rwds = new GameObject[3];

		// Token: 0x04007202 RID: 29186
		private bool canClaimPoint = false;

		// Token: 0x04007203 RID: 29187
		private XDesignationDocument _doc = null;

		// Token: 0x04007204 RID: 29188
		private IXUICheckBox[] m_padTabs = new IXUICheckBox[6];

		// Token: 0x04007205 RID: 29189
		private IXUISprite[] m_padPoint = new IXUISprite[6];

		// Token: 0x04007206 RID: 29190
		private GameObject m_objSurvey;

		// Token: 0x04007207 RID: 29191
		private GameObject m_objDetail;
	}
}
