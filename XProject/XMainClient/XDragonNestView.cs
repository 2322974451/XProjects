using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CD2 RID: 3282
	internal class XDragonNestView : DlgBase<XDragonNestView, XDragonNestBehaviour>
	{
		// Token: 0x1700327A RID: 12922
		// (get) Token: 0x0600B801 RID: 47105 RVA: 0x0024D58C File Offset: 0x0024B78C
		public override string fileName
		{
			get
			{
				return "GameSystem/DragonNestDlg";
			}
		}

		// Token: 0x1700327B RID: 12923
		// (get) Token: 0x0600B802 RID: 47106 RVA: 0x0024D5A4 File Offset: 0x0024B7A4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700327C RID: 12924
		// (get) Token: 0x0600B803 RID: 47107 RVA: 0x0024D5B8 File Offset: 0x0024B7B8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700327D RID: 12925
		// (get) Token: 0x0600B804 RID: 47108 RVA: 0x0024D5CC File Offset: 0x0024B7CC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700327E RID: 12926
		// (get) Token: 0x0600B805 RID: 47109 RVA: 0x0024D5E0 File Offset: 0x0024B7E0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700327F RID: 12927
		// (get) Token: 0x0600B806 RID: 47110 RVA: 0x0024D5F4 File Offset: 0x0024B7F4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B807 RID: 47111 RVA: 0x0024D608 File Offset: 0x0024B808
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			this._expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this._mainDoc = XDocuments.GetSpecificDocument<XMainInterfaceDocument>(XMainInterfaceDocument.uuID);
			this._sweepDoc = XDocuments.GetSpecificDocument<XSweepDocument>(XSweepDocument.uuID);
		}

		// Token: 0x0600B808 RID: 47112 RVA: 0x0024D660 File Offset: 0x0024B860
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseButtonClicked));
			base.uiBehaviour.m_SweepButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSweepButtonClicked));
			base.uiBehaviour.m_EnterButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterButtonClicked));
			base.uiBehaviour.m_WeakBlock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnWeakTipBlockClicked));
			base.uiBehaviour.m_WeakPercent.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnWeakPercentClicked));
			base.uiBehaviour.m_WeakPPTHelp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnWeakPPTHelpClicked));
			base.uiBehaviour.m_Help.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpClicked));
			base.uiBehaviour.m_HelpClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHelpCloseClicked));
			base.uiBehaviour.m_quanMinSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._onClickQuanMinSpr));
			base.uiBehaviour.m_DiffEasyCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnDiffCheckBoxClicked));
			base.uiBehaviour.m_DiffNormalCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnDiffCheckBoxClicked));
			base.uiBehaviour.m_DiffHardCheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnDiffCheckBoxClicked));
			base.uiBehaviour.m_DiffEasyCheckBox.ID = 0UL;
			base.uiBehaviour.m_DiffNormalCheckBox.ID = 1UL;
			base.uiBehaviour.m_DiffHardCheckBox.ID = 2UL;
			base.uiBehaviour.m_DiffHardLock.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDiffHardLockClicked));
		}

		// Token: 0x0600B809 RID: 47113 RVA: 0x0024D828 File Offset: 0x0024BA28
		private bool OnDiffCheckBoxClicked(IXUICheckBox box)
		{
			bool flag = !box.bChecked;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.OnDiffChange((uint)box.ID);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B80A RID: 47114 RVA: 0x0024D85A File Offset: 0x0024BA5A
		private void OnDiffHardLockClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("DRAGON_NEST_HARD_LOCK_TIP"), "fece00");
		}

		// Token: 0x0600B80B RID: 47115 RVA: 0x0024D877 File Offset: 0x0024BA77
		private void OnWeakPPTHelpClicked(IXUISprite sp)
		{
			base.uiBehaviour.m_WeakTip.gameObject.SetActive(true);
			base.uiBehaviour.m_WeakBlock.SetVisible(true);
		}

		// Token: 0x0600B80C RID: 47116 RVA: 0x0024D877 File Offset: 0x0024BA77
		private void OnWeakPercentClicked(IXUILabel label)
		{
			base.uiBehaviour.m_WeakTip.gameObject.SetActive(true);
			base.uiBehaviour.m_WeakBlock.SetVisible(true);
		}

		// Token: 0x0600B80D RID: 47117 RVA: 0x0024D8A3 File Offset: 0x0024BAA3
		private void OnHelpClicked(IXUISprite sp)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_DragonNest);
		}

		// Token: 0x0600B80E RID: 47118 RVA: 0x0024D8B6 File Offset: 0x0024BAB6
		private void OnHelpCloseClicked(IXUISprite sp)
		{
			base.uiBehaviour.m_HelpFrame.gameObject.SetActive(false);
		}

		// Token: 0x0600B80F RID: 47119 RVA: 0x0024D8D0 File Offset: 0x0024BAD0
		private void _onClickQuanMinSpr(IXUISprite spr)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_DragonNest_QuanMin);
		}

		// Token: 0x0600B810 RID: 47120 RVA: 0x0024D8E4 File Offset: 0x0024BAE4
		private bool OnCloseButtonClicked(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B811 RID: 47121 RVA: 0x0024D900 File Offset: 0x0024BB00
		private bool OnSweepButtonClicked(IXUIButton button)
		{
			this._sweepDoc.TrySweepQuery(0U, this._doc.CurrentExpID, 1U);
			return true;
		}

		// Token: 0x0600B812 RID: 47122 RVA: 0x0024D92C File Offset: 0x0024BB2C
		private bool OnEnterButtonClicked(IXUIButton button)
		{
			this._OnRealEnter((int)this._doc.CurrentExpID);
			return true;
		}

		// Token: 0x0600B813 RID: 47123 RVA: 0x0024D954 File Offset: 0x0024BB54
		private void _OnRealEnter(int id)
		{
			XTeamDocument specificDocument = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			specificDocument.SetAndMatch(id);
		}

		// Token: 0x0600B814 RID: 47124 RVA: 0x0024D978 File Offset: 0x0024BB78
		private void OnDiffChange(uint value)
		{
			this._doc.CurrentDiff = value;
			this._doc.CurrentWeakState = this._doc.GetWeakState(this._doc.CurrentType, this._doc.CurrentDiff);
			this._doc.CurrentWeakType = this._doc.GetWeakType(this._doc.CurrentType, this._doc.CurrentDiff);
			uint num = this._doc.CheckWave(this._doc.CurrentType, this._doc.CurrentDiff);
			num = ((num == 7U) ? 6U : num);
			num = ((num == 0U) ? 1U : num);
			bool flag = this._doc.CurrentDiff == 2U;
			if (flag)
			{
				num = 1U;
			}
			this._doc.CurrentExpID = this._doc.GetDragonNestByTypeAndDiffAndWave(this._doc.CurrentType, this._doc.CurrentDiff, num).DragonNestID;
			this.SetupResertTip();
			this.SetDiffFrame(this._doc.CurrentDiff);
			this.SetupNestFrame();
			this.SetupDetailFrame();
		}

		// Token: 0x0600B815 RID: 47125 RVA: 0x0024DA8E File Offset: 0x0024BC8E
		private void OnWeakTipBlockClicked(IXUISprite sp)
		{
			base.uiBehaviour.m_WeakTip.gameObject.SetActive(false);
			base.uiBehaviour.m_WeakBlock.SetVisible(false);
		}

		// Token: 0x0600B816 RID: 47126 RVA: 0x0024DABC File Offset: 0x0024BCBC
		private void OnTabClicked(IXUISprite sp)
		{
			bool flag = this._doc.CurrentType == (uint)sp.ID;
			if (!flag)
			{
				this._doc.CurrentType = (uint)sp.ID;
				this._doc.CurrentDiff = 0U;
				this.SetupTabFrame();
				this.SetupNormalDragon();
			}
		}

		// Token: 0x0600B817 RID: 47127 RVA: 0x0024DB14 File Offset: 0x0024BD14
		public void ShowDragonNestByTypeAndDiff(uint type, uint diff)
		{
			XDragonNestDocument specificDocument = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			bool flag = specificDocument.CurrentType != type || specificDocument.CurrentDiff != diff;
			if (flag)
			{
				specificDocument.CurrentType = type;
				specificDocument.CurrentDiff = diff;
			}
			bool flag2 = !base.IsVisible();
			if (flag2)
			{
				this.SetVisible(true, true);
			}
		}

		// Token: 0x0600B818 RID: 47128 RVA: 0x0024DB74 File Offset: 0x0024BD74
		private void OnTabLockClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByLevel", new object[]
			{
				this._expDoc.GetExpeditionDataByID((int)this._doc.GetDragonNestByTypeAndDiffAndWave((uint)sp.ID, 1U, 1U).DragonNestID).RequiredLevel.ToString(),
				this._doc.GetDragonNestTypeDataByID((uint)sp.ID).TypeName
			}), "fece00");
		}

		// Token: 0x0600B819 RID: 47129 RVA: 0x0024DBED File Offset: 0x0024BDED
		private void OnFinishedNestClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("OnlyCanEnterCurrentStage"), "fece00");
		}

		// Token: 0x0600B81A RID: 47130 RVA: 0x0024DBED File Offset: 0x0024BDED
		private void OnFinishedNestClicked(IXUITexture tex)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("OnlyCanEnterCurrentStage"), "fece00");
		}

		// Token: 0x0600B81B RID: 47131 RVA: 0x0024DC0C File Offset: 0x0024BE0C
		private void OnNestLockByLevelClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByLevel", new object[]
			{
				this._expDoc.GetExpeditionDataByID((int)sp.ID).RequiredLevel.ToString(),
				this._expDoc.GetExpeditionDataByID((int)sp.ID).DNExpeditionName
			}), "fece00");
		}

		// Token: 0x0600B81C RID: 47132 RVA: 0x0024DC74 File Offset: 0x0024BE74
		private void OnNestLockByLevelClicked(IXUITexture tex)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByLevel", new object[]
			{
				this._expDoc.GetExpeditionDataByID((int)tex.ID).RequiredLevel.ToString(),
				this._expDoc.GetExpeditionDataByID((int)tex.ID).DNExpeditionName
			}), "fece00");
		}

		// Token: 0x0600B81D RID: 47133 RVA: 0x0024DCDC File Offset: 0x0024BEDC
		private void OnNestLockClicked(IXUISprite sp)
		{
			DragonNestTable.RowData dragonNestByID = this._doc.GetDragonNestByID((uint)sp.ID);
			uint dragonNestID = this._doc.GetDragonNestByTypeAndDiffAndWave(dragonNestByID.DragonNestType, dragonNestByID.DragonNestDifficulty, dragonNestByID.DragonNestWave - 1U).DragonNestID;
			string dnexpeditionName = this._expDoc.GetExpeditionDataByID((int)dragonNestID).DNExpeditionName;
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByFinishPreStage", new object[]
			{
				dnexpeditionName
			}), "fece00");
		}

		// Token: 0x0600B81E RID: 47134 RVA: 0x0024DD58 File Offset: 0x0024BF58
		private void OnNestLockClicked(IXUITexture tex)
		{
			DragonNestTable.RowData dragonNestByID = this._doc.GetDragonNestByID((uint)tex.ID);
			uint dragonNestID = this._doc.GetDragonNestByTypeAndDiffAndWave(dragonNestByID.DragonNestType, dragonNestByID.DragonNestDifficulty, dragonNestByID.DragonNestWave - 1U).DragonNestID;
			string dnexpeditionName = this._expDoc.GetExpeditionDataByID((int)dragonNestID).DNExpeditionName;
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByFinishPreStage", new object[]
			{
				dnexpeditionName
			}), "fece00");
		}

		// Token: 0x0600B81F RID: 47135 RVA: 0x0024DDD4 File Offset: 0x0024BFD4
		private void OnDiffLockByLevelClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByLevel", new object[]
			{
				this._expDoc.GetExpeditionDataByID((int)this._doc.GetDragonNestByTypeAndDiffAndWave(this._doc.CurrentType, 1U, 1U).DragonNestID).RequiredLevel.ToString(),
				this._doc.GetDragonNestTypeDataByID(this._doc.CurrentType).TypeName
			}), "fece00");
		}

		// Token: 0x0600B820 RID: 47136 RVA: 0x0024DE55 File Offset: 0x0024C055
		private void OnDiffLockClicked(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("UnlockByPreDiff"), "fece00");
		}

		// Token: 0x0600B821 RID: 47137 RVA: 0x0024DE72 File Offset: 0x0024C072
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendReqDragonNestInfo();
			this.SetupTabFrame();
			this.SetupNormalDragon();
			this.SetupHelpFrame();
		}

		// Token: 0x0600B822 RID: 47138 RVA: 0x0024DEA0 File Offset: 0x0024C0A0
		protected override void OnHide()
		{
			base.OnHide();
			this._doc.ResetData();
			XSingleton<XInput>.singleton.Freezed = false;
			base.uiBehaviour.m_NestNormalBg.SetTexturePath("");
			base.uiBehaviour.m_NestHardBg.SetTexturePath("");
			XSingleton<UiUtility>.singleton.DestroyTextureInActivePool(base.uiBehaviour.m_NestNormalTplPool, "Boss");
		}

		// Token: 0x0600B823 RID: 47139 RVA: 0x0024DF14 File Offset: 0x0024C114
		protected override void OnUnload()
		{
			this._doc.ResetData();
			base.OnUnload();
		}

		// Token: 0x0600B824 RID: 47140 RVA: 0x0024DF2C File Offset: 0x0024C12C
		public override int[] GetTitanBarItems()
		{
			int[] array = new int[1];
			ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)this._doc.CurrentExpID);
			bool flag = expeditionDataByID == null;
			int[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = expeditionDataByID.CostItem.Count == 0;
				if (flag2)
				{
					uint sceneIDByExpID = this._expDoc.GetSceneIDByExpID(expeditionDataByID.DNExpeditionID);
					SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
					bool flag3 = sceneData == null || sceneData.SweepTicket == null || sceneData.SweepTicket.Length == 0;
					if (flag3)
					{
						result = null;
					}
					else
					{
						array[0] = (int)sceneData.SweepTicket[0];
						result = array;
					}
				}
				else
				{
					array[0] = expeditionDataByID.CostItem[0, 0];
					result = array;
				}
			}
			return result;
		}

		// Token: 0x0600B825 RID: 47141 RVA: 0x0024DFE4 File Offset: 0x0024C1E4
		private string GetWeekDayString(int day)
		{
			string result;
			switch (day)
			{
			case 1:
				result = XStringDefineProxy.GetString("Monday");
				break;
			case 2:
				result = XStringDefineProxy.GetString("Tuesday");
				break;
			case 3:
				result = XStringDefineProxy.GetString("Wednesday");
				break;
			case 4:
				result = XStringDefineProxy.GetString("Thursday");
				break;
			case 5:
				result = XStringDefineProxy.GetString("Friday");
				break;
			case 6:
				result = XStringDefineProxy.GetString("Saturday");
				break;
			case 7:
				result = XStringDefineProxy.GetString("Sunday");
				break;
			default:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x0600B826 RID: 47142 RVA: 0x0024E080 File Offset: 0x0024C280
		private void SetupResertTip()
		{
			string[] array = null;
			switch (this._doc.CurrentDiff)
			{
			case 0U:
				array = XSingleton<XGlobalConfig>.singleton.GetValue("SmallDragonResetWeekDay").Split(new char[]
				{
					'|'
				});
				break;
			case 1U:
				array = XSingleton<XGlobalConfig>.singleton.GetValue("DragonResetWeekDay").Split(new char[]
				{
					'|'
				});
				break;
			case 2U:
				array = XSingleton<XGlobalConfig>.singleton.GetValue("HardDragonResetWeekDay").Split(new char[]
				{
					'|'
				});
				break;
			}
			string text = "";
			for (int i = 0; i < array.Length; i++)
			{
				text = string.Format("{0}{1}{2}", text, (text == "") ? " " : ",", this.GetWeekDayString(int.Parse(array[i])));
			}
			base.uiBehaviour.m_ResertTip.SetText(XStringDefineProxy.GetString("RESERT_TIME", new object[]
			{
				text
			}));
		}

		// Token: 0x0600B827 RID: 47143 RVA: 0x0024E190 File Offset: 0x0024C390
		private void SetupTabFrame()
		{
			DragonNestType.RowData[] dragonNestTypeList = this._doc.GetDragonNestTypeList();
			base.uiBehaviour.m_TabTplPool.FakeReturnAll();
			for (int i = 0; i < dragonNestTypeList.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_TabTplPool.FetchGameObject(false);
				this.SetupTabTpl(gameObject, dragonNestTypeList[i]);
				gameObject.transform.localPosition = base.uiBehaviour.m_TabTplPool.TplPos - new Vector3(0f, (float)(i * base.uiBehaviour.m_TabTplPool.TplHeight));
			}
			base.uiBehaviour.m_TabTplPool.ActualReturnAll(false);
		}

		// Token: 0x0600B828 RID: 47144 RVA: 0x0024E23C File Offset: 0x0024C43C
		private void SetupTabTpl(GameObject go, DragonNestType.RowData data)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Bg/Label").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite2 = go.transform.Find("Bg/Fx").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite3 = go.transform.Find("Bg/Icon").GetComponent("XUISprite") as IXUISprite;
			Transform transform = go.transform.Find("Lock");
			bool flag = this._doc.CheckLock(data.DragonNestType, 1U);
			ixuilabel.SetText(data.TypeName);
			transform.gameObject.SetActive(flag);
			ixuisprite2.SetVisible(this._doc.CurrentType == data.DragonNestType);
			ixuisprite3.SetSprite(data.TypeIcon);
			ixuisprite.ID = (ulong)data.DragonNestType;
			bool flag2 = flag;
			if (flag2)
			{
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTabLockClicked));
			}
			else
			{
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnTabClicked));
			}
		}

		// Token: 0x0600B829 RID: 47145 RVA: 0x0024E368 File Offset: 0x0024C568
		private void SetupNormalDragon()
		{
			base.uiBehaviour.m_DiffEasyCheckBox.ForceSetFlag(false);
			base.uiBehaviour.m_DiffNormalCheckBox.ForceSetFlag(false);
			base.uiBehaviour.m_DiffHardCheckBox.ForceSetFlag(false);
			switch (this._doc.CurrentDiff)
			{
			case 0U:
				base.uiBehaviour.m_DiffEasyCheckBox.bChecked = true;
				break;
			case 1U:
				base.uiBehaviour.m_DiffNormalCheckBox.bChecked = true;
				break;
			case 2U:
				base.uiBehaviour.m_DiffHardCheckBox.bChecked = true;
				break;
			}
			bool visible = this._doc.CheckLock(this._doc.CurrentType, 2U);
			base.uiBehaviour.m_DiffHardLock.SetVisible(visible);
			this.OnDiffChange(this._doc.CurrentDiff);
		}

		// Token: 0x0600B82A RID: 47146 RVA: 0x0024E444 File Offset: 0x0024C644
		private void SetDiffFrame(uint diff)
		{
			base.uiBehaviour.m_NestFrameNormal.gameObject.SetActive(diff == 1U || diff == 0U);
			base.uiBehaviour.m_NestFrameHard.gameObject.SetActive(diff == 2U);
		}

		// Token: 0x0600B82B RID: 47147 RVA: 0x0024E484 File Offset: 0x0024C684
		private void SetupNestFrame()
		{
			List<DragonNestTable.RowData> dragonNestListByTypeAndDiff = this._doc.GetDragonNestListByTypeAndDiff(this._doc.CurrentType, this._doc.CurrentDiff);
			uint num = this._doc.CheckWave(this._doc.CurrentType, this._doc.CurrentDiff);
			num = ((num == 7U) ? 6U : num);
			num = ((num == 0U) ? 1U : num);
			bool flag = this._doc.CurrentDiff == 2U;
			if (flag)
			{
				num = 1U;
			}
			switch (this._doc.CurrentDiff)
			{
			case 0U:
				base.uiBehaviour.m_NestNormalTplPool.FakeReturnAll();
				for (int i = 0; i < dragonNestListByTypeAndDiff.Count; i++)
				{
					GameObject go = base.uiBehaviour.m_NestNormalTplPool.FetchGameObject(false);
					this.SetupNestTpl(go, dragonNestListByTypeAndDiff[i], num);
					bool flag2 = dragonNestListByTypeAndDiff[i].DragonNestWave == num;
					if (flag2)
					{
						base.uiBehaviour.m_WeakTip.parent.gameObject.SetActive(false);
					}
				}
				base.uiBehaviour.m_NestNormalTplPool.ActualReturnAll(false);
				break;
			case 1U:
				base.uiBehaviour.m_NestNormalTplPool.FakeReturnAll();
				for (int j = 0; j < dragonNestListByTypeAndDiff.Count; j++)
				{
					GameObject gameObject = base.uiBehaviour.m_NestNormalTplPool.FetchGameObject(false);
					this.SetupNestTpl(gameObject, dragonNestListByTypeAndDiff[j], num);
					bool flag3 = dragonNestListByTypeAndDiff[j].DragonNestWave == num;
					if (flag3)
					{
						base.uiBehaviour.m_WeakTip.parent.gameObject.SetActive(true);
						base.uiBehaviour.m_WeakTip.parent.localPosition = gameObject.transform.localPosition;
					}
				}
				base.uiBehaviour.m_NestNormalTplPool.ActualReturnAll(false);
				break;
			case 2U:
			{
				base.uiBehaviour.m_NestHardBossIcon.SetTexturePath(dragonNestListByTypeAndDiff[0].DragonNestIcon);
				ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)dragonNestListByTypeAndDiff[0].DragonNestID);
				base.uiBehaviour.m_NestHardName.SetText(expeditionDataByID.DNExpeditionName);
				break;
			}
			}
		}

		// Token: 0x0600B82C RID: 47148 RVA: 0x0024E6D8 File Offset: 0x0024C8D8
		private void SetupNestTpl(GameObject go, DragonNestTable.RowData data, uint wave)
		{
			IXUISprite ixuisprite = go.GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			Transform transform = go.transform.Find("Bg");
			IXUISprite ixuisprite2 = go.transform.Find("Bg/Icon").GetComponent("XUISprite") as IXUISprite;
			Transform transform2 = go.transform.Find("Bg/Lock");
			Transform transform3 = go.transform.Find("Bg/Fx");
			IXUITexture ixuitexture = go.transform.Find("Boss").GetComponent("XUITexture") as IXUITexture;
			Transform transform4 = go.transform.Find("Boss/Fx");
			ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)data.DragonNestID);
			ixuilabel.SetText(expeditionDataByID.DNExpeditionName);
			go.transform.localPosition = new Vector3((float)data.DragonNestPosX, (float)data.DragonNestPosY);
			bool flag = (ulong)data.DragonNestWave == (ulong)((long)this._doc.DragonNestBOSSWave);
			if (flag)
			{
				transform.gameObject.SetActive(false);
				ixuitexture.SetVisible(true);
				transform4.gameObject.SetActive(wave == data.DragonNestWave);
				ixuitexture.SetTexturePath(data.DragonNestIcon);
				ixuitexture.ID = (ulong)expeditionDataByID.DNExpeditionID;
				bool flag2 = wave > data.DragonNestWave;
				if (flag2)
				{
					ixuitexture.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnFinishedNestClicked));
				}
				else
				{
					bool flag3 = wave < data.DragonNestWave;
					if (flag3)
					{
						bool flag4 = data.DragonNestWave == 1U;
						if (flag4)
						{
							ixuitexture.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnNestLockByLevelClicked));
						}
						else
						{
							ixuitexture.RegisterLabelClickEventHandler(new TextureClickEventHandler(this.OnNestLockClicked));
						}
					}
					else
					{
						ixuitexture.RegisterLabelClickEventHandler(null);
					}
				}
			}
			else
			{
				transform.gameObject.SetActive(true);
				ixuitexture.SetVisible(false);
				ixuisprite2.SetSprite(data.DragonNestIcon, data.DragonNestAtlas, false);
				transform2.gameObject.SetActive(wave < data.DragonNestWave);
				transform3.gameObject.SetActive(wave == data.DragonNestWave);
				ixuisprite.ID = (ulong)expeditionDataByID.DNExpeditionID;
				bool flag5 = wave > data.DragonNestWave;
				if (flag5)
				{
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFinishedNestClicked));
				}
				else
				{
					bool flag6 = wave < data.DragonNestWave;
					if (flag6)
					{
						bool flag7 = data.DragonNestWave == 1U;
						if (flag7)
						{
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNestLockByLevelClicked));
						}
						else
						{
							ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnNestLockClicked));
						}
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(null);
					}
				}
			}
		}

		// Token: 0x0600B82D RID: 47149 RVA: 0x0024E9B8 File Offset: 0x0024CBB8
		private void SetupDetailFrame()
		{
			ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)this._doc.CurrentExpID);
			DragonNestTable.RowData dragonNestByID = this._doc.GetDragonNestByID(this._doc.CurrentExpID);
			bool flag = expeditionDataByID == null || dragonNestByID == null;
			if (!flag)
			{
				DragonNestType.RowData dragonNestTypeDataByID = this._doc.GetDragonNestTypeDataByID(this._doc.CurrentType);
				base.uiBehaviour.m_NestName.SetText(expeditionDataByID.DNExpeditionName);
				switch (this._doc.CurrentDiff)
				{
				case 0U:
					base.uiBehaviour.m_NormalDetail.gameObject.SetActive(false);
					base.uiBehaviour.m_EasyDetail.gameObject.SetActive(true);
					base.uiBehaviour.m_quanMinSpr.gameObject.SetActive(true);
					base.uiBehaviour.m_EasySugAttr.SetText(dragonNestByID.SuggestAttr);
					base.uiBehaviour.m_EasySugLevel.SetText(expeditionDataByID.DisplayLevel.ToString());
					base.uiBehaviour.m_EasySugMember.SetText(expeditionDataByID.PlayerNumber.ToString());
					base.uiBehaviour.m_NestNormalBg.SetTexturePath(dragonNestTypeDataByID.TypeBg);
					break;
				case 1U:
					base.uiBehaviour.m_NormalDetail.gameObject.SetActive(true);
					base.uiBehaviour.m_EasyDetail.gameObject.SetActive(false);
					base.uiBehaviour.m_quanMinSpr.gameObject.SetActive(false);
					base.uiBehaviour.m_NormalCurPPT.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic).ToString("0"));
					base.uiBehaviour.m_NormalSugPPT.SetText(expeditionDataByID.DisplayPPT.ToString());
					base.uiBehaviour.m_NormalSugAttr.SetText(dragonNestByID.SuggestAttr);
					base.uiBehaviour.m_NormalSugLevel.SetText(expeditionDataByID.DisplayLevel.ToString());
					base.uiBehaviour.m_NormalSugMember.SetText(expeditionDataByID.PlayerNumber.ToString());
					base.uiBehaviour.m_NestNormalBg.SetTexturePath(dragonNestTypeDataByID.TypeBg);
					this.SetupWeakDetail(dragonNestByID, expeditionDataByID);
					break;
				case 2U:
					base.uiBehaviour.m_NormalDetail.gameObject.SetActive(true);
					base.uiBehaviour.m_EasyDetail.gameObject.SetActive(false);
					base.uiBehaviour.m_quanMinSpr.gameObject.SetActive(false);
					base.uiBehaviour.m_NormalCurPPT.SetText(XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic).ToString("0"));
					base.uiBehaviour.m_NormalSugPPT.SetText(expeditionDataByID.DisplayPPT.ToString());
					base.uiBehaviour.m_NormalSugAttr.SetText(dragonNestByID.SuggestAttr);
					base.uiBehaviour.m_NormalSugLevel.SetText(expeditionDataByID.DisplayLevel.ToString());
					base.uiBehaviour.m_NormalSugMember.SetText(expeditionDataByID.PlayerNumber.ToString());
					base.uiBehaviour.m_NestHardBg.SetTexturePath(dragonNestTypeDataByID.TypeBg);
					break;
				}
				base.uiBehaviour.m_WeakTip.gameObject.SetActive(false);
				base.uiBehaviour.m_WeakBlock.SetVisible(false);
				this.SetupItemList(expeditionDataByID);
				this.SetupEnterCost(expeditionDataByID);
				this.SetupSweepCost(expeditionDataByID);
				this._mainDoc.OnTopUIRefreshed(this);
			}
		}

		// Token: 0x0600B82E RID: 47150 RVA: 0x0024ED64 File Offset: 0x0024CF64
		private void SetupWeakDetail(DragonNestTable.RowData data, ExpeditionTable.RowData expData)
		{
			base.uiBehaviour.m_WeakName.SetText(expData.DNExpeditionName);
			switch (this._doc.CurrentWeakType)
			{
			case DragonWeakType.DragonWeakType_Null:
				base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(false);
				base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(1f, 1f, 1f));
				base.uiBehaviour.m_WeakTip1.SetText(data.WeakNotPassTip1);
				base.uiBehaviour.m_WeakTip2.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(data.WeakNotPassTip2));
				base.uiBehaviour.m_WeakPercent.SetText(XStringDefineProxy.GetString("DragonNestNotPassTip"));
				break;
			case DragonWeakType.DragonWeakType_Pass:
			{
				int num = 0;
				for (int i = 0; i < data.WeakInfo.Count; i++)
				{
					bool flag = (ulong)data.WeakInfo[i, 0] <= (ulong)((long)this._doc.CurrentWeakState);
					if (flag)
					{
						num = i;
					}
				}
				bool flag2 = data.WeakTip1.Length != 0;
				if (flag2)
				{
					base.uiBehaviour.m_WeakTip1.SetText((num < data.WeakTip1.Length) ? data.WeakTip1[num] : data.WeakTip1[data.WeakTip1.Length - 1]);
				}
				else
				{
					base.uiBehaviour.m_WeakTip1.SetText("");
				}
				bool flag3 = data.WeakTip2.Length != 0;
				if (flag3)
				{
					base.uiBehaviour.m_WeakTip2.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn((num < data.WeakTip2.Length) ? data.WeakTip2[num] : data.WeakTip2[data.WeakTip2.Length - 1]));
				}
				else
				{
					base.uiBehaviour.m_WeakTip2.SetText("");
				}
				bool flag4 = data.WeakPercent.Length != 0;
				if (flag4)
				{
					base.uiBehaviour.m_WeakPercent.SetText(string.Format("{0}%", (num < data.WeakPercent.Length) ? data.WeakPercent[num].ToString() : data.WeakPercent[data.WeakPercent.Length - 1].ToString()));
				}
				else
				{
					base.uiBehaviour.m_WeakPercent.SetText("");
				}
				bool flag5 = data.WeakCombat.Length != 0;
				if (flag5)
				{
					bool flag6 = expData.DisplayPPT == ((num < data.WeakCombat.Length) ? data.WeakCombat[num] : data.WeakCombat[data.WeakCombat.Length - 1]);
					if (flag6)
					{
						base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(false);
						base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(1f, 1f, 1f));
					}
					else
					{
						base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(true);
						base.uiBehaviour.m_WeakPPT.SetText((num < data.WeakCombat.Length) ? data.WeakCombat[num].ToString() : data.WeakCombat[data.WeakCombat.Length - 1].ToString());
						base.uiBehaviour.m_WeakPPT.MakePixelPerfect();
						base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(0.5f, 0.5f, 0.5f));
					}
				}
				else
				{
					base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(false);
					base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(1f, 1f, 1f));
				}
				break;
			}
			case DragonWeakType.DragonWeakType_NotPass:
			{
				int num2 = 0;
				for (int j = 0; j < data.WeakInfoEx.Count; j++)
				{
					bool flag7 = (ulong)data.WeakInfoEx[j, 0] <= (ulong)((long)this._doc.CurrentWeakState);
					if (flag7)
					{
						num2 = j;
					}
				}
				bool flag8 = data.WeakTip1EX.Length != 0;
				if (flag8)
				{
					base.uiBehaviour.m_WeakTip1.SetText((num2 < data.WeakTip1EX.Length) ? data.WeakTip1EX[num2] : data.WeakTip1EX[data.WeakTip1EX.Length - 1]);
				}
				else
				{
					base.uiBehaviour.m_WeakTip1.SetText("");
				}
				bool flag9 = data.WeakTip2EX.Length != 0;
				if (flag9)
				{
					base.uiBehaviour.m_WeakTip2.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn((num2 < data.WeakTip2EX.Length) ? data.WeakTip2EX[num2] : data.WeakTip2EX[data.WeakTip2EX.Length - 1]));
				}
				else
				{
					base.uiBehaviour.m_WeakTip2.SetText("");
				}
				bool flag10 = data.WeakPercentEX.Length != 0;
				if (flag10)
				{
					base.uiBehaviour.m_WeakPercent.SetText(string.Format("{0}%", (num2 < data.WeakPercentEX.Length) ? data.WeakPercentEX[num2].ToString() : data.WeakPercentEX[data.WeakPercentEX.Length - 1].ToString()));
				}
				else
				{
					base.uiBehaviour.m_WeakPercent.SetText("");
				}
				bool flag11 = data.WeakCombatEX.Length != 0;
				if (flag11)
				{
					bool flag12 = expData.DisplayPPT == ((num2 < data.WeakCombatEX.Length) ? data.WeakCombatEX[num2] : data.WeakCombatEX[data.WeakCombatEX.Length - 1]);
					if (flag12)
					{
						base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(false);
						base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(1f, 1f, 1f));
					}
					else
					{
						base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(true);
						base.uiBehaviour.m_WeakPPT.SetText((num2 < data.WeakCombatEX.Length) ? data.WeakCombatEX[num2].ToString() : data.WeakCombatEX[data.WeakCombatEX.Length - 1].ToString());
						base.uiBehaviour.m_WeakPPT.MakePixelPerfect();
						base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(0.5f, 0.5f, 0.5f));
					}
				}
				else
				{
					base.uiBehaviour.m_WeakPPTFrame.gameObject.SetActive(false);
					base.uiBehaviour.m_NormalSugPPT.SetColor(new Color(1f, 1f, 1f));
				}
				break;
			}
			}
		}

		// Token: 0x0600B82F RID: 47151 RVA: 0x0024F458 File Offset: 0x0024D658
		private void SetupItemList(ExpeditionTable.RowData expData)
		{
			bool flag = expData.ViewableDropList == null;
			if (!flag)
			{
				base.uiBehaviour.m_ItemTplPool.FakeReturnAll();
				for (int i = 0; i < expData.ViewableDropList.Length; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_ItemTplPool.FetchGameObject(false);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)expData.ViewableDropList[i], 0, false);
					gameObject.transform.localPosition = new Vector3(base.uiBehaviour.m_ItemTplPool.TplPos.x + (float)(i * base.uiBehaviour.m_ItemTplPool.TplWidth), base.uiBehaviour.m_ItemTplPool.TplPos.y);
					IXUISprite ixuisprite = gameObject.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)expData.ViewableDropList[i];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				base.uiBehaviour.m_ItemTplPool.ActualReturnAll(false);
			}
		}

		// Token: 0x0600B830 RID: 47152 RVA: 0x0024F580 File Offset: 0x0024D780
		private void SetupEnterCost(ExpeditionTable.RowData expData)
		{
			bool flag = expData.CostItem.Count > 0;
			if (flag)
			{
				base.uiBehaviour.m_CostItem.SetActive(true);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_CostItem, expData.CostItem[0, 0], 0, false);
				base.uiBehaviour.m_CostItemNum.SetText(string.Format("x{0}", expData.CostItem[0, 1]));
				IXUISprite ixuisprite = base.uiBehaviour.m_CostItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)expData.CostItem[0, 0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
			}
			else
			{
				base.uiBehaviour.m_CostItem.SetActive(false);
			}
			XDragonNestDocument.DragonNestData dragonNestData = this._doc.GetDragonNestData(this._doc.CurrentType, this._doc.CurrentDiff);
			bool flag2 = dragonNestData == null;
			if (!flag2)
			{
				bool flag3 = dragonNestData.Wave == 0U;
				if (flag3)
				{
					base.uiBehaviour.m_EnterText.SetText(XStringDefineProxy.GetString("IS_LOCK"));
					base.uiBehaviour.m_EnterButton.SetEnable(false, false);
					base.uiBehaviour.m_SweepButton.SetEnable(false, false);
				}
				else
				{
					bool flag4 = dragonNestData.Wave == 7U;
					if (flag4)
					{
						base.uiBehaviour.m_EnterText.SetText(XStringDefineProxy.GetString("IS_FINISH"));
						base.uiBehaviour.m_EnterButton.SetEnable(false, false);
						base.uiBehaviour.m_SweepButton.SetEnable(false, false);
					}
					else
					{
						base.uiBehaviour.m_EnterText.SetText(XStringDefineProxy.GetString("TEAM_ENTER"));
						base.uiBehaviour.m_EnterButton.SetEnable(true, false);
						base.uiBehaviour.m_SweepButton.SetEnable(true, false);
					}
				}
			}
		}

		// Token: 0x0600B831 RID: 47153 RVA: 0x0024F798 File Offset: 0x0024D998
		private void SetupSweepCost(ExpeditionTable.RowData expData)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_DragonNest_Sweep);
			if (flag)
			{
				base.uiBehaviour.m_SweepButton.SetVisible(false);
			}
			else
			{
				uint sceneIDByExpID = this._expDoc.GetSceneIDByExpID(expData.DNExpeditionID);
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(sceneIDByExpID);
				bool flag2 = this._doc.CurrentDiff == 0U && sceneData.SweepTicket != null && sceneData.SweepTicket.Length != 0;
				if (flag2)
				{
					base.uiBehaviour.m_SweepButton.SetVisible(true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_SweepCostItem, (int)sceneData.SweepTicket[0], 0, false);
					base.uiBehaviour.m_SweepCostItemNum.SetText("x1");
					IXUISprite ixuisprite = base.uiBehaviour.m_SweepCostItem.transform.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)sceneData.SweepTicket[0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				else
				{
					base.uiBehaviour.m_SweepButton.SetVisible(false);
				}
			}
		}

		// Token: 0x0600B832 RID: 47154 RVA: 0x0024F8D4 File Offset: 0x0024DAD4
		private void SetupHelpFrame()
		{
			base.uiBehaviour.m_HelpFrame.gameObject.SetActive(false);
			base.uiBehaviour.m_HelpTip.SetText(XStringDefineProxy.GetString("DragonNestHelpTip"));
		}

		// Token: 0x0600B833 RID: 47155 RVA: 0x0024F909 File Offset: 0x0024DB09
		public void RefreshUI()
		{
			this.SetupTabFrame();
			this.SetupNormalDragon();
		}

		// Token: 0x040048BA RID: 18618
		private XDragonNestDocument _doc = null;

		// Token: 0x040048BB RID: 18619
		private XExpeditionDocument _expDoc = null;

		// Token: 0x040048BC RID: 18620
		private XMainInterfaceDocument _mainDoc = null;

		// Token: 0x040048BD RID: 18621
		private XSweepDocument _sweepDoc = null;
	}
}
