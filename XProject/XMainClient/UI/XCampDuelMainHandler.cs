using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017DF RID: 6111
	internal class XCampDuelMainHandler : DlgHandlerBase
	{
		// Token: 0x170038B3 RID: 14515
		// (get) Token: 0x0600FD45 RID: 64837 RVA: 0x003B4D84 File Offset: 0x003B2F84
		public string CampName
		{
			get
			{
				bool flag = this.SelectID == 1;
				string result;
				if (flag)
				{
					result = XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME");
				}
				else
				{
					bool flag2 = this.SelectID == 2;
					if (flag2)
					{
						result = XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME");
					}
					else
					{
						result = "";
					}
				}
				return result;
			}
		}

		// Token: 0x170038B4 RID: 14516
		// (get) Token: 0x0600FD46 RID: 64838 RVA: 0x003B4DD0 File Offset: 0x003B2FD0
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CampDuelFrame";
			}
		}

		// Token: 0x0600FD47 RID: 64839 RVA: 0x003B4DE8 File Offset: 0x003B2FE8
		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XCampDuelDocument>(XCampDuelDocument.uuID);
			this.doc.handler = this;
			this.m_JoinFrame = base.transform.FindChild("JoinFrame");
			this.m_MainFrame = base.transform.FindChild("MainFrame");
			this.m_TexLeft = (this.m_JoinFrame.FindChild("Left/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_TexRight = (this.m_JoinFrame.FindChild("Right/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_BtnSelectLeft = (this.m_JoinFrame.FindChild("Left/BtnSelect").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSelectRight = (this.m_JoinFrame.FindChild("Right/BtnSelect").GetComponent("XUIButton") as IXUIButton);
			this.m_LeftName = (this.m_JoinFrame.FindChild("Left/T").GetComponent("XUILabel") as IXUILabel);
			this.m_RightName = (this.m_JoinFrame.FindChild("Right/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Icon = (this.m_JoinFrame.FindChild("Detail/Avatar/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_Intro = (this.m_JoinFrame.FindChild("Detail/Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_Empty = this.m_JoinFrame.FindChild("Detail/CampSelect/Empty");
			this.m_Content = this.m_JoinFrame.FindChild("Detail/CampSelect/Content");
			this.m_BtnJoin = (this.m_JoinFrame.FindChild("Detail/CampSelect/BtnJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_SelectReward = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Reward").GetComponent("XUILabel") as IXUILabel);
			this.m_SelectName = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnJoinHelp = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_MainTips = (this.m_MainFrame.FindChild("Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCampTex = (this.m_MainFrame.FindChild("Camp/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_MainName = (this.m_MainFrame.FindChild("Camp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCondition = (this.m_MainFrame.FindChild("Camp/Condition").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnMainHelp = (this.m_MainFrame.FindChild("Camp/Condition/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMainHelpTips = (this.m_MainFrame.FindChild("Camp/Condition/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnMainHelpTips.gameObject.SetActive(false);
			this.m_MainBlah = (this.m_MainFrame.FindChild("Camp/Blah").GetComponent("XUILabel") as IXUILabel);
			this.m_MainBlah.gameObject.SetActive(false);
			this.m_MainPoint = (this.m_MainFrame.FindChild("Point").GetComponent("XUILabel") as IXUILabel);
			this.m_MainAddPointTween = (this.m_MainFrame.FindChild("Point/AddPoint").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_MainAddPoint = (this.m_MainFrame.FindChild("Point/AddPoint").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCurRewardPoint = (this.m_MainFrame.FindChild("CurrnetReward/Point").GetComponent("XUILabel") as IXUILabel);
			this.m_MainAddPoint.gameObject.SetActive(false);
			this.m_MainCurRewardText = this.m_MainFrame.FindChild("CurrnetReward/ChestTpl/T");
			this.m_MainRewardItemList = this.m_MainFrame.FindChild("ItemIconList");
			this.m_MainCurRewardItemList = this.m_MainFrame.FindChild("CurrnetReward/ItemIconList");
			this.m_MainNextRewardItemList = this.m_MainFrame.FindChild("NextReward/ItemIconList");
			this.m_MainCurChest = (this.m_MainFrame.FindChild("CurrnetReward/ChestTpl").GetComponent("XUISprite") as IXUISprite);
			this.m_MainChestFx = this.m_MainFrame.FindChild("CurrnetReward/ChestTpl/Fx");
			this.m_MainBtnReward = (this.m_MainFrame.FindChild("BtnReward").GetComponent("XUIButton") as IXUIButton);
			this.m_MainBtnRank = (this.m_MainFrame.FindChild("BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_MainEndTime = (this.m_MainFrame.FindChild("EndTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform = this.m_MainFrame.FindChild("Operate/Contribute");
			this.m_MainItem = transform.FindChild("ItemTpl");
			this.m_MainItemIcon = (transform.FindChild("ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MainBtnConfirm = (transform.FindChild("BtnSubmit").GetComponent("XUIButton") as IXUIButton);
			this.m_MainConfirmPoint = (transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			transform = this.m_MainFrame.FindChild("Operate/Courage");
			this.m_MainFreeCourageCount = (transform.FindChild("Detail/FreeNum").GetComponent("XUILabel") as IXUILabel);
			this.m_MainDragonCoinCourageCount = (transform.FindChild("Detail/DragonCoinNum").GetComponent("XUILabel") as IXUILabel);
			this.m_MainBtnCourage = (transform.FindChild("BtnCourage").GetComponent("XUIButton") as IXUIButton);
			this.m_MainBtnCourageRedPoint = transform.FindChild("BtnCourage/RedPoint");
			this.m_MainFree = transform.FindChild("BtnCourage/Free");
			this.m_MainDragonCoin = (transform.FindChild("BtnCourage/DragonCoin").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCouragePoint = (transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (this.m_MainFrame.FindChild("Title/Help").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x0600FD48 RID: 64840 RVA: 0x003B5478 File Offset: 0x003B3678
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnSelectLeft.ID = 1UL;
			this.m_BtnSelectLeft.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelectClicked));
			this.m_BtnSelectRight.ID = 2UL;
			this.m_BtnSelectRight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelectClicked));
			this.m_BtnJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			this.m_BtnJoinHelp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnJoinHelpClicked));
			this.m_BtnMainHelp.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnHelpBtnPress));
			this.m_MainBtnConfirm.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnConfirmClicked));
			this.m_MainBtnCourage.ID = (ulong)uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelInspireAddPoint"));
			this.m_MainBtnCourage.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCourageClicked));
			this.m_MainCurChest.ID = 1UL;
			this.m_MainCurChest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			this.m_MainBtnReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
			this.m_MainBtnRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
			this.m_MainItemIcon.ID = (ulong)((long)XCampDuelDocument.Doc.ConfirmItemID);
			this.m_MainItemIcon.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		// Token: 0x0600FD49 RID: 64841 RVA: 0x003B560F File Offset: 0x003B380F
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowUI();
		}

		// Token: 0x0600FD4A RID: 64842 RVA: 0x003B5620 File Offset: 0x003B3820
		protected override void OnHide()
		{
			this.m_TexLeft.SetTexturePath("");
			this.m_TexRight.SetTexturePath("");
			this.m_MainCampTex.SetTexturePath("");
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoRefresheTimeID);
			this._AutoRefresheTimeID = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseBlahTimeID);
			this._AutoCloseBlahTimeID = 0U;
			this.UnloadFx(this._BoxUpFx);
			this.UnloadFx(this._NPCFx);
			this.m_MainBlah.gameObject.SetActive(false);
			base.OnHide();
		}

		// Token: 0x0600FD4B RID: 64843 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FD4C RID: 64844 RVA: 0x003B56C4 File Offset: 0x003B38C4
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XCampDuelPointRewardHandler>(ref this._PointRewardHandler);
			this.doc.handler = null;
			base.OnUnload();
		}

		// Token: 0x0600FD4D RID: 64845 RVA: 0x003B56E8 File Offset: 0x003B38E8
		public void ShowUI()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.doc.campID == 0;
				if (flag2)
				{
					this.m_JoinFrame.gameObject.SetActive(true);
					this.m_MainFrame.gameObject.SetActive(false);
					this.ShowJoin();
				}
				else
				{
					this.m_JoinFrame.gameObject.SetActive(false);
					this.m_MainFrame.gameObject.SetActive(true);
					bool flag3 = this._AutoRefresheTimeID == 0U;
					if (flag3)
					{
						this._AutoRefresh(null);
					}
					this.ShowMain();
				}
			}
		}

		// Token: 0x0600FD4E RID: 64846 RVA: 0x003B578C File Offset: 0x003B398C
		private bool OnSelectClicked(IXUIButton btn)
		{
			this.SelectID = (int)btn.ID;
			this.m_TexLeft.SetColor((btn.ID == 1UL) ? Color.white : Color.gray);
			this.m_TexRight.SetColor((btn.ID == 1UL) ? Color.gray : Color.white);
			this.m_Icon.SetSprite((btn.ID == 1UL) ? XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftIcon") : XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightIcon"));
			this.m_Empty.gameObject.SetActive(false);
			this.m_Content.gameObject.SetActive(true);
			this.m_SelectName.SetText(this.CampName);
			this.m_SelectReward.SetText((btn.ID == 1UL) ? XStringDefineProxy.GetString("CAMPDUEL_LEFT_REWARD") : XStringDefineProxy.GetString("CAMPDUEL_RIGHT_REWARD"));
			return true;
		}

		// Token: 0x0600FD4F RID: 64847 RVA: 0x003B5888 File Offset: 0x003B3A88
		private bool OnJoinClicked(IXUIButton btn)
		{
			bool flag = this.SelectID == 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CAMPDUEL_JOIN_TIP"), "fece00");
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("CAMPDUEL_JOIN_CONFIRM"), this.CampName), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Compose), null, false, XTempTipDefine.OD_START, 50);
				result = true;
			}
			return result;
		}

		// Token: 0x0600FD50 RID: 64848 RVA: 0x003B5914 File Offset: 0x003B3B14
		private bool _Compose(IXUIButton button)
		{
			XCampDuelDocument.Doc.ReqCampDuel(2U, (uint)this.SelectID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		// Token: 0x0600FD51 RID: 64849 RVA: 0x003B5944 File Offset: 0x003B3B44
		private void OnJoinHelpClicked(IXUISprite btn)
		{
			DlgHandlerBase.EnsureCreate<XCampDuelPointRewardHandler>(ref this._PointRewardHandler, this.m_JoinFrame, false, null);
			this._PointRewardHandler.CampID = this.SelectID;
			this._PointRewardHandler.SetVisible(true);
		}

		// Token: 0x0600FD52 RID: 64850 RVA: 0x003B597C File Offset: 0x003B3B7C
		public void ShowJoin()
		{
			this.SelectID = 0;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftTex");
			this.m_TexLeft.SetTexturePath(value);
			this.m_TexLeft.SetColor(Color.gray);
			this.m_LeftName.SetText(XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME"));
			value = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightTex");
			this.m_TexRight.SetTexturePath(value);
			this.m_TexRight.SetColor(Color.gray);
			this.m_RightName.SetText(XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME"));
			this.m_Icon.SetSprite("");
			string arg = XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_JOIN_INTRO_TIME"));
			this.m_Intro.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CAMPDUEL_JOIN_INTRO")), arg));
			this.m_Empty.gameObject.SetActive(true);
			this.m_Content.gameObject.SetActive(false);
		}

		// Token: 0x0600FD53 RID: 64851 RVA: 0x003B5A9C File Offset: 0x003B3C9C
		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CampDuel);
			return true;
		}

		// Token: 0x0600FD54 RID: 64852 RVA: 0x003B5AC0 File Offset: 0x003B3CC0
		private bool OnConfirmClicked(IXUIButton btn)
		{
			XCampDuelDocument.Doc.ReqCampDuel(3U, (uint)btn.ID);
			return true;
		}

		// Token: 0x0600FD55 RID: 64853 RVA: 0x003B5AE8 File Offset: 0x003B3CE8
		private bool OnCourageClicked(IXUIButton btn)
		{
			bool flag = XCampDuelDocument.Doc.FreeCourageCount != 0;
			if (flag)
			{
				XCampDuelDocument.Doc.ReqCampDuel(4U, (uint)btn.ID);
			}
			else
			{
				XCampDuelDocument.Doc.ReqCampDuel(5U, (uint)btn.ID);
			}
			return true;
		}

		// Token: 0x0600FD56 RID: 64854 RVA: 0x003B5B34 File Offset: 0x003B3D34
		private bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<XCampDuelPointRewardHandler>(ref this._PointRewardHandler, this.m_MainFrame, false, null);
			this._PointRewardHandler.CampID = XCampDuelDocument.Doc.campID;
			this._PointRewardHandler.SetVisible(true);
			return true;
		}

		// Token: 0x0600FD57 RID: 64855 RVA: 0x003B5B80 File Offset: 0x003B3D80
		private bool OnRankClicked(IXUIButton btn)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_CampDuel);
			return true;
		}

		// Token: 0x0600FD58 RID: 64856 RVA: 0x001AE886 File Offset: 0x001ACA86
		private void OnItemClicked(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
		}

		// Token: 0x0600FD59 RID: 64857 RVA: 0x003B5BA4 File Offset: 0x003B3DA4
		private void OnChestClicked(IXUISprite btn)
		{
			CampDuelPointReward.RowData rowData = this.doc.GetPointReward(this.doc.point);
			bool flag = rowData == null;
			if (flag)
			{
				rowData = this.doc.GetNextPointReward(this.doc.point);
			}
			bool flag2 = rowData == null;
			if (!flag2)
			{
				this.itemid.Clear();
				this.itemCount.Clear();
				for (int i = 0; i < (int)rowData.Reward.count; i++)
				{
					this.itemid.Add((uint)rowData.Reward[i, 0]);
					this.itemCount.Add((uint)rowData.Reward[i, 1]);
				}
				this.itemid.Add((uint)rowData.EXReward[0]);
				this.itemCount.Add((uint)rowData.EXReward[1]);
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.Show(this.itemid, this.itemCount, true);
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.SetGlobalPosition(btn.gameObject.transform.position);
			}
		}

		// Token: 0x0600FD5A RID: 64858 RVA: 0x003B5CC0 File Offset: 0x003B3EC0
		private void OnItemCloseClicked(IXUISprite btn)
		{
			this.m_MainRewardItemList.gameObject.SetActive(false);
		}

		// Token: 0x0600FD5B RID: 64859 RVA: 0x003B5CD8 File Offset: 0x003B3ED8
		private void OnHelpBtnPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_BtnMainHelpTips.gameObject.activeInHierarchy != state;
			if (flag)
			{
				this.m_BtnMainHelpTips.gameObject.SetActive(state);
			}
		}

		// Token: 0x0600FD5C RID: 64860 RVA: 0x003B5D14 File Offset: 0x003B3F14
		public void ShowMain()
		{
			this.m_MainTips.SetText(XStringDefineProxy.GetString("CAMPDUEL_MAIN_TIP"));
			this.m_MainCampTex.SetTexturePath((this.doc.campID == 1) ? XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftTex") : XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightTex"));
			this.m_MainName.SetText((this.doc.campID == 1) ? XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME") : XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME"));
			this.m_MainCondition.SetSprite((this.doc.aheadCampID == this.doc.campID) ? "Spr_Ahead" : "Spr_Beyond");
			this.m_MainCondition.gameObject.SetActive(this.doc.aheadCampID != 0);
			this.m_BtnMainHelpTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CAMPDUEL_MAIN_HELP")));
			this.RefreshPoint();
			int confirmItemID = XCampDuelDocument.Doc.ConfirmItemID;
			ulong num = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(confirmItemID);
			this.m_MainBtnConfirm.ID = num;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_MainItem.gameObject, confirmItemID, (int)num, true);
			this.m_MainConfirmPoint.SetText(((int)num * int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelItemPoint"))).ToString());
			this.m_MainBtnConfirm.SetEnable(num > 0UL, false);
			this.RefresheCourage();
			this.m_MainCouragePoint.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelInspireAddPoint"));
			this.m_MainEndTime.SetText(XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_END_TIME")));
		}

		// Token: 0x0600FD5D RID: 64861 RVA: 0x003B5EF8 File Offset: 0x003B40F8
		public void RefreshPoint()
		{
			this.m_MainPoint.SetText(this.doc.point.ToString());
			CampDuelPointReward.RowData pointReward = this.doc.GetPointReward(this.doc.point);
			CampDuelPointReward.RowData nextPointReward = this.doc.GetNextPointReward(this.doc.point);
			this.m_MainChestFx.gameObject.SetActive(pointReward != null);
			this.m_MainCurRewardText.gameObject.SetActive(pointReward != null);
			this.m_MainCurChest.SetColor((pointReward != null) ? Color.white : Color.gray);
			bool flag = pointReward == null && nextPointReward != null;
			if (flag)
			{
				this.m_MainCurChest.SetSprite(nextPointReward.Icon);
				this.m_MainCurRewardPoint.SetText(string.Format(XStringDefineProxy.GetString("CAMPDUEL_REWARD_FIRST"), nextPointReward.Point - this.doc.point));
			}
			else
			{
				bool flag2 = pointReward != null && nextPointReward == null;
				if (flag2)
				{
					this.m_MainCurChest.SetSprite(pointReward.Icon);
					this.m_MainCurRewardPoint.SetText(XStringDefineProxy.GetString("CAMPDUEL_REWARD_MAX"));
				}
				else
				{
					bool flag3 = pointReward != null && nextPointReward != null;
					if (flag3)
					{
						this.m_MainCurChest.SetSprite(pointReward.Icon);
						this.m_MainCurRewardPoint.SetText(string.Format(XStringDefineProxy.GetString("CAMPDUEL_REWARD_NEXT"), nextPointReward.Point - this.doc.point));
					}
				}
			}
		}

		// Token: 0x0600FD5E RID: 64862 RVA: 0x003B6080 File Offset: 0x003B4280
		public void RefresheCourage()
		{
			this.m_MainFreeCourageCount.SetText(string.Format("{0}/{1}", this.doc.FreeCourageCount, this.doc.FreeCourageMAX));
			this.m_MainDragonCoinCourageCount.SetText(string.Format("{0}/{1}", this.doc.DragonCoinCourageCount, this.doc.DragonCoinCourageCost.Length));
			this.m_MainFreeCourageCount.gameObject.SetActive(this.doc.FreeCourageCount != 0);
			this.m_MainDragonCoinCourageCount.gameObject.SetActive(this.doc.FreeCourageCount == 0);
			this.m_MainBtnCourageRedPoint.gameObject.SetActive(this.doc.IsRedPoint());
			bool flag = this.doc.FreeCourageCount > 0;
			if (flag)
			{
				this.m_MainFree.gameObject.SetActive(true);
				this.m_MainDragonCoin.gameObject.SetActive(false);
				this.m_MainBtnCourage.SetEnable(true, false);
			}
			else
			{
				this.m_MainFree.gameObject.SetActive(false);
				this.m_MainDragonCoin.gameObject.SetActive(true);
				this.m_MainBtnCourage.SetEnable(this.doc.DragonCoinCourageCount > 0, false);
				int num = Mathf.Clamp(this.doc.DragonCoinCourageCost.Length - this.doc.DragonCoinCourageCount, 0, this.doc.DragonCoinCourageCost.Length - 1);
				this.m_MainDragonCoin.SetText(this.doc.DragonCoinCourageCost[num]);
			}
		}

		// Token: 0x0600FD5F RID: 64863 RVA: 0x003B622C File Offset: 0x003B442C
		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XCampDuelDocument.Doc.ReqCampDuel(1U, 0U);
				this._AutoRefresheTimeID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		// Token: 0x0600FD60 RID: 64864 RVA: 0x003B6275 File Offset: 0x003B4475
		private void _AutoCloseBlah(object param)
		{
			this.m_MainBlah.gameObject.SetActive(false);
		}

		// Token: 0x0600FD61 RID: 64865 RVA: 0x003B628C File Offset: 0x003B448C
		public void ShowBlah()
		{
			int num = Random.Range(0, 5);
			this.m_MainBlah.gameObject.SetActive(true);
			this.m_MainBlah.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("CAMPDUEL_BLAH", num.ToString())));
			this._AutoCloseBlahTimeID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this._AutoCloseBlah), null);
		}

		// Token: 0x0600FD62 RID: 64866 RVA: 0x003B62FD File Offset: 0x003B44FD
		public void AddNumPlayTween(int addPoint)
		{
			this.m_MainAddPoint.SetText(string.Format("+{0}", addPoint.ToString()));
			this.m_MainAddPointTween.PlayTween(true, -1f);
		}

		// Token: 0x0600FD63 RID: 64867 RVA: 0x003B6330 File Offset: 0x003B4530
		public void PlayBoxUpFx()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._BoxUpFx != null && this._BoxUpFx.FxName == "Effects/FX_Particle/UIfx/UI_duelcampframe_Clip02";
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._BoxUpFx, true);
				}
				this._BoxUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_duelcampframe_Clip02", this.m_MainCurChest.transform, Vector3.zero, Vector3.one, 1f, true, 6f, true);
			}
		}

		// Token: 0x0600FD64 RID: 64868 RVA: 0x003B63BC File Offset: 0x003B45BC
		public void PlayNPCFx()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._NPCFx != null && this._NPCFx.FxName == "Effects/FX_Particle/UIfx/UI_duelcampframe_Clip03";
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._NPCFx, true);
				}
				this._NPCFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_duelcampframe_Clip03", this.m_MainCampTex.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, 6f, true);
			}
		}

		// Token: 0x0600FD65 RID: 64869 RVA: 0x003B644C File Offset: 0x003B464C
		public void UnloadFx(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		// Token: 0x04006F86 RID: 28550
		private XCampDuelDocument doc = null;

		// Token: 0x04006F87 RID: 28551
		private XCampDuelPointRewardHandler _PointRewardHandler;

		// Token: 0x04006F88 RID: 28552
		private int SelectID;

		// Token: 0x04006F89 RID: 28553
		private uint _AutoRefresheTimeID;

		// Token: 0x04006F8A RID: 28554
		private uint _AutoCloseBlahTimeID;

		// Token: 0x04006F8B RID: 28555
		private Transform m_JoinFrame;

		// Token: 0x04006F8C RID: 28556
		private Transform m_MainFrame;

		// Token: 0x04006F8D RID: 28557
		private IXUITexture m_TexLeft;

		// Token: 0x04006F8E RID: 28558
		private IXUITexture m_TexRight;

		// Token: 0x04006F8F RID: 28559
		private IXUISprite m_Icon;

		// Token: 0x04006F90 RID: 28560
		private IXUIButton m_BtnSelectLeft;

		// Token: 0x04006F91 RID: 28561
		private IXUIButton m_BtnSelectRight;

		// Token: 0x04006F92 RID: 28562
		private IXUILabel m_Intro;

		// Token: 0x04006F93 RID: 28563
		private Transform m_Content;

		// Token: 0x04006F94 RID: 28564
		private Transform m_Empty;

		// Token: 0x04006F95 RID: 28565
		private IXUIButton m_BtnJoin;

		// Token: 0x04006F96 RID: 28566
		private IXUILabel m_SelectReward;

		// Token: 0x04006F97 RID: 28567
		private IXUILabel m_SelectName;

		// Token: 0x04006F98 RID: 28568
		private IXUISprite m_BtnJoinHelp;

		// Token: 0x04006F99 RID: 28569
		private IXUILabel m_LeftName;

		// Token: 0x04006F9A RID: 28570
		private IXUILabel m_RightName;

		// Token: 0x04006F9B RID: 28571
		private IXUILabel m_MainBlah;

		// Token: 0x04006F9C RID: 28572
		private IXUILabel m_MainTips;

		// Token: 0x04006F9D RID: 28573
		private IXUITexture m_MainCampTex;

		// Token: 0x04006F9E RID: 28574
		private IXUILabel m_MainName;

		// Token: 0x04006F9F RID: 28575
		private IXUISprite m_MainCondition;

		// Token: 0x04006FA0 RID: 28576
		private IXUIButton m_BtnMainHelp;

		// Token: 0x04006FA1 RID: 28577
		private IXUILabel m_BtnMainHelpTips;

		// Token: 0x04006FA2 RID: 28578
		private IXUILabel m_MainPoint;

		// Token: 0x04006FA3 RID: 28579
		private IXUILabel m_MainCurRewardPoint;

		// Token: 0x04006FA4 RID: 28580
		private Transform m_MainCurRewardText;

		// Token: 0x04006FA5 RID: 28581
		private Transform m_MainItem;

		// Token: 0x04006FA6 RID: 28582
		private IXUISprite m_MainItemIcon;

		// Token: 0x04006FA7 RID: 28583
		private IXUIButton m_MainBtnConfirm;

		// Token: 0x04006FA8 RID: 28584
		private IXUILabel m_MainConfirmPoint;

		// Token: 0x04006FA9 RID: 28585
		private IXUILabel m_MainFreeCourageCount;

		// Token: 0x04006FAA RID: 28586
		private IXUILabel m_MainDragonCoinCourageCount;

		// Token: 0x04006FAB RID: 28587
		private IXUIButton m_MainBtnCourage;

		// Token: 0x04006FAC RID: 28588
		private Transform m_MainBtnCourageRedPoint;

		// Token: 0x04006FAD RID: 28589
		private Transform m_MainFree;

		// Token: 0x04006FAE RID: 28590
		private IXUILabel m_MainDragonCoin;

		// Token: 0x04006FAF RID: 28591
		private IXUILabel m_MainCouragePoint;

		// Token: 0x04006FB0 RID: 28592
		private Transform m_MainRewardItemList;

		// Token: 0x04006FB1 RID: 28593
		private Transform m_MainCurRewardItemList;

		// Token: 0x04006FB2 RID: 28594
		private Transform m_MainNextRewardItemList;

		// Token: 0x04006FB3 RID: 28595
		private Transform m_MainChestFx;

		// Token: 0x04006FB4 RID: 28596
		private IXUISprite m_MainCurChest;

		// Token: 0x04006FB5 RID: 28597
		private IXUIButton m_MainBtnReward;

		// Token: 0x04006FB6 RID: 28598
		private IXUIButton m_MainBtnRank;

		// Token: 0x04006FB7 RID: 28599
		private IXUILabel m_MainEndTime;

		// Token: 0x04006FB8 RID: 28600
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006FB9 RID: 28601
		private IXUITweenTool m_MainAddPointTween;

		// Token: 0x04006FBA RID: 28602
		private IXUILabel m_MainAddPoint;

		// Token: 0x04006FBB RID: 28603
		private IXUIButton m_Help;

		// Token: 0x04006FBC RID: 28604
		private List<uint> itemid = new List<uint>();

		// Token: 0x04006FBD RID: 28605
		private List<uint> itemCount = new List<uint>();

		// Token: 0x04006FBE RID: 28606
		private XFx _BoxUpFx;

		// Token: 0x04006FBF RID: 28607
		private XFx _NPCFx;
	}
}
