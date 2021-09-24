using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XAchieveView : DlgHandlerBase
	{

		private void InitDetail()
		{
			this.m_PanelScrollView = (base.PanelObject.transform.FindChild("detail/detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.FindChild("detail/detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		private void ReqDetailInfo(int index)
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this.m_achieveType = (AchieveType)index;
				this._doc.FetchAchieveType(this.m_achieveType);
			}
		}

		public void RefreshDetails()
		{
			this.m_WrapContent.SetContentCount(this._doc.achievesDetails.Count, false);
			this.m_PanelScrollView.ResetPosition();
		}

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

		public bool UnCompleteTipsBtn(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Achi_Or_Des_UnComplete"), "fece00");
			return true;
		}

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

		public bool OnGetRewardBtnClick(IXUIButton btn)
		{
			bool flag = this._doc != null && this._doc.achieveSurveyInfo != null;
			if (flag)
			{
				this._doc.SendQueryGetAchiPointReward(this._doc.achieveSurveyInfo.rewardId);
			}
			return true;
		}

		public void RequstSurvey()
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.FetchAchieveSurvey();
			}
		}

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

		private void RefreshProAll()
		{
			uint achievePoint = this._doc.achieveSurveyInfo.achievePoint;
			uint maxAchievePoint = this._doc.achieveSurveyInfo.maxAchievePoint;
			float value = achievePoint / maxAchievePoint;
			this.m_proAchiAll.value = value;
			this.m_lblAchiAll.SetText(achievePoint + "/" + maxAchievePoint);
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
		}

		public override void OnUnload()
		{
			this._doc = null;
			base.OnUnload();
		}

		public bool OnTabControlStateChange(IXUICheckBox chkBox)
		{
			bool bChecked = chkBox.bChecked;
			if (bChecked)
			{
				this.OnTabClick((int)chkBox.ID);
			}
			return true;
		}

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

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_PanelScrollView;

		public AchieveType m_achieveType;

		private List<AchieveItemInfo> list = new List<AchieveItemInfo>();

		private IXUILabel m_labAchipoint;

		private IXUIProgress m_proAchiAll;

		private IXUILabel m_lblAchiAll;

		private IXUILabel m_rewarDesc;

		private IXUIButton m_getBtn;

		private IXUISprite m_sprRed;

		private IXUIProgress[] m_proAchivType = new IXUIProgress[5];

		private IXUILabel[] m_lblAchiType = new IXUILabel[5];

		private GameObject[] m_rwds = new GameObject[3];

		private bool canClaimPoint = false;

		private XDesignationDocument _doc = null;

		private IXUICheckBox[] m_padTabs = new IXUICheckBox[6];

		private IXUISprite[] m_padPoint = new IXUISprite[6];

		private GameObject m_objSurvey;

		private GameObject m_objDetail;
	}
}
