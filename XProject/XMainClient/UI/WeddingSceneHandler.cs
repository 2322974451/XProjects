using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001790 RID: 6032
	internal class WeddingSceneHandler : DlgHandlerBase
	{
		// Token: 0x17003845 RID: 14405
		// (get) Token: 0x0600F8E7 RID: 63719 RVA: 0x00390290 File Offset: 0x0038E490
		protected override string FileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingSceneHandler";
			}
		}

		// Token: 0x0600F8E8 RID: 63720 RVA: 0x003902A8 File Offset: 0x0038E4A8
		protected override void Init()
		{
			this.m_exitHomeBtn = (base.PanelObject.transform.FindChild("ExitHome").GetComponent("XUIButton") as IXUIButton);
			this.m_Happiness = (base.PanelObject.transform.FindChild("Happiness/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_HappinessMax = (base.PanelObject.transform.FindChild("Happiness/Max").GetComponent("XUILabel") as IXUILabel);
			this.m_HappinessBtn = (base.PanelObject.transform.FindChild("Happiness/P").GetComponent("XUISprite") as IXUISprite);
			this.m_FlowerBtn = (base.PanelObject.transform.FindChild("Grid/SysAFlower").GetComponent("XUIButton") as IXUIButton);
			this.m_FlowerCDTime = (base.PanelObject.transform.FindChild("Grid/SysAFlower/Mask/time").GetComponent("XUILabel") as IXUILabel);
			this.m_FlowerCD = base.PanelObject.transform.FindChild("Grid/SysAFlower/Mask").gameObject;
			this.m_FlowerCD.SetActive(false);
			this.m_FireworksBtn = (base.PanelObject.transform.FindChild("Grid/SysBFireworks").GetComponent("XUIButton") as IXUIButton);
			this.m_FireworksCDTime = (base.PanelObject.transform.FindChild("Grid/SysBFireworks/Mask/time").GetComponent("XUILabel") as IXUILabel);
			this.m_FireworksCD = base.PanelObject.transform.FindChild("Grid/SysBFireworks/Mask").gameObject;
			this.m_FireworksCD.SetActive(false);
			this.m_SwearBtn = (base.PanelObject.transform.FindChild("Grid/SysDSwear").GetComponent("XUIButton") as IXUIButton);
			this.m_InviteFriendsBtn = (base.PanelObject.transform.FindChild("Grid/SysCInvite").GetComponent("XUIButton") as IXUIButton);
			this.m_InviteRedPoint = base.PanelObject.transform.FindChild("Grid/SysCInvite/RedPoint").gameObject;
			this.m_WeddingName = (base.PanelObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnsGrid = (base.PanelObject.transform.FindChild("Grid").GetComponent("XUIList") as IXUIList);
			this.m_SwearFX = base.PanelObject.transform.FindChild("Grid/SysDSwear/FX").gameObject;
			this.m_SwearDlg = base.PanelObject.transform.FindChild("SwearDlg").gameObject;
			this.m_AskSwearBtn = (base.PanelObject.transform.FindChild("SwearDlg/Bg/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_CloseSwearBtn = (base.PanelObject.transform.FindChild("SwearDlg/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_HappinessValue = (base.PanelObject.transform.FindChild("SwearDlg/Bg/Happiness/Value").GetComponent("XUILabel") as IXUILabel);
			this.m_Content = (base.PanelObject.transform.FindChild("SwearDlg/Bg/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_SwearDlg.gameObject.SetActive(false);
			this.m_Tip1 = (base.PanelObject.transform.FindChild("Tip1").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip1.gameObject.SetActive(false);
			this.m_Tip2 = (base.PanelObject.transform.FindChild("Tip2").GetComponent("XUILabel") as IXUILabel);
			this.m_Tip2.gameObject.SetActive(false);
			base.Init();
		}

		// Token: 0x0600F8E9 RID: 63721 RVA: 0x003906A4 File Offset: 0x0038E8A4
		public override void RegisterEvent()
		{
			this.m_exitHomeBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickExitHome));
			this.m_FlowerBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFlowerBtn));
			this.m_FireworksBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFireworksBtn));
			this.m_SwearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSwearBtn));
			this.m_InviteFriendsBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickInviteFriendsBtn));
			this.m_AskSwearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAskSwearBtn));
			this.m_CloseSwearBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseSwear));
			this.m_HappinessBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHappinessClick));
			base.RegisterEvent();
		}

		// Token: 0x0600F8EA RID: 63722 RVA: 0x0039077C File Offset: 0x0038E97C
		protected override void OnShow()
		{
			base.OnShow();
			this.m_HappinessMax.SetText(string.Format("/{0}", XSingleton<XGlobalConfig>.singleton.GetValue("WeddingMaxHappyness")));
			this.m_vecGuestShowTime = XSingleton<XGlobalConfig>.singleton.GetUIntList("WeddingGuestShowTime");
			this.m_weddingRunTime = uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("WeddingRunningTime"));
			this.m_Content.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingSwearTip")));
			bool flag = XWeddingDocument.Doc.CurrWeddingInfo != null && XWeddingDocument.Doc.CurrWeddingInfo.role1 != null && XWeddingDocument.Doc.CurrWeddingInfo.role2 != null;
			if (flag)
			{
				this.m_WeddingName.SetText(XStringDefineProxy.GetString("WeddingName", new object[]
				{
					XWeddingDocument.Doc.CurrWeddingInfo.role1.name,
					XWeddingDocument.Doc.CurrWeddingInfo.role2.name
				}));
				this.m_SwearBtn.gameObject.SetActive(this.IsWeddingLover());
				this.m_InviteFriendsBtn.gameObject.SetActive(this.IsWeddingLover());
				this.m_BtnsGrid.Refresh();
			}
			this.m_FlowerCD.SetActive(false);
			this.m_FireworksCD.SetActive(false);
			this.m_HasVows = false;
			this.m_SwearFX.SetActive(false);
			this.m_InviteRedPoint.SetActive(XWeddingDocument.Doc.HasApplyCandidate);
			this.m_HasShowVows = false;
		}

		// Token: 0x0600F8EB RID: 63723 RVA: 0x00390914 File Offset: 0x0038EB14
		private bool IsWeddingLover()
		{
			bool flag = XWeddingDocument.Doc.CurrWeddingInfo != null && XWeddingDocument.Doc.CurrWeddingInfo.role1 != null && XWeddingDocument.Doc.CurrWeddingInfo.role2 != null;
			bool result;
			if (flag)
			{
				ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				result = (roleID == XWeddingDocument.Doc.CurrWeddingInfo.role1.roleid || roleID == XWeddingDocument.Doc.CurrWeddingInfo.role2.roleid);
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600F8EC RID: 63724 RVA: 0x003909A4 File Offset: 0x0038EBA4
		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this.m_Fireworks != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fireworks, true);
				this.m_Fireworks = null;
			}
			bool flag2 = this.m_Candy != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Candy, true);
				this.m_Candy = null;
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_Tip1CDToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFlower);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFireworks);
		}

		// Token: 0x0600F8ED RID: 63725 RVA: 0x00390A3C File Offset: 0x0038EC3C
		private bool OnClickExitHome(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

		// Token: 0x0600F8EE RID: 63726 RVA: 0x00390A5C File Offset: 0x0038EC5C
		private bool OnClickFlowerBtn(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WeddingFlowerCost", XGlobalConfig.SequenceSeparator);
			uint num = uint.Parse(andSeparateValue[1]) * XWeddingDocument.Doc.AllAttendPlayerCount;
			string text = "";
			ItemList.RowData itemConf = XBagDocument.GetItemConf(int.Parse(andSeparateValue[0]));
			bool flag = itemConf != null;
			if (flag)
			{
				text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			}
			string mainLabel = string.Format(XStringDefineProxy.GetString("WeddingFlowerTip", new object[]
			{
				num,
				text
			}), new object[0]);
			string @string = XStringDefineProxy.GetString(XStringDefine.COMMON_OK);
			string string2 = XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, @string, string2);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.EnsureFlower), null);
			return true;
		}

		// Token: 0x0600F8EF RID: 63727 RVA: 0x00390B48 File Offset: 0x0038ED48
		private bool EnsureFlower(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Flower);
			return true;
		}

		// Token: 0x0600F8F0 RID: 63728 RVA: 0x00390B74 File Offset: 0x0038ED74
		public void RefreshInviteRedPoint()
		{
			this.m_InviteRedPoint.SetActive(XWeddingDocument.Doc.HasApplyCandidate);
		}

		// Token: 0x0600F8F1 RID: 63729 RVA: 0x00390B90 File Offset: 0x0038ED90
		public void OnFlowerRain()
		{
			Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingFlowerFxPath");
			XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(value, transform, false);
			xfx.DelayDestroy = 3f;
			XSingleton<XFxMgr>.singleton.DestroyFx(xfx, false);
		}

		// Token: 0x0600F8F2 RID: 63730 RVA: 0x00390BF0 File Offset: 0x0038EDF0
		private bool OnClickFireworksBtn(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WeddingFireworksCost", XGlobalConfig.SequenceSeparator);
			uint num = uint.Parse(andSeparateValue[1]) * XWeddingDocument.Doc.AllAttendPlayerCount;
			string text = "";
			ItemList.RowData itemConf = XBagDocument.GetItemConf(int.Parse(andSeparateValue[0]));
			bool flag = itemConf != null;
			if (flag)
			{
				text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			}
			string mainLabel = string.Format(XStringDefineProxy.GetString("WeddingFireworksTip", new object[]
			{
				num,
				text
			}), new object[0]);
			string @string = XStringDefineProxy.GetString(XStringDefine.COMMON_OK);
			string string2 = XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, @string, string2);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.EnsureFireworks), null);
			return true;
		}

		// Token: 0x0600F8F3 RID: 63731 RVA: 0x00390CDC File Offset: 0x0038EEDC
		private bool EnsureFireworks(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Fireworks);
			return true;
		}

		// Token: 0x0600F8F4 RID: 63732 RVA: 0x00390D08 File Offset: 0x0038EF08
		public void OnFireworks()
		{
			bool flag = this.m_Fireworks != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Fireworks, true);
			}
			Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingFireworksPath");
			this.m_Fireworks = XSingleton<XFxMgr>.singleton.CreateUIFx(value, transform, false);
		}

		// Token: 0x0600F8F5 RID: 63733 RVA: 0x00390D74 File Offset: 0x0038EF74
		public void OnCandyFx()
		{
			bool flag = this.m_Candy != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_Candy, true);
			}
			Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingCandyPath");
			this.m_Candy = XSingleton<XFxMgr>.singleton.CreateUIFx(value, transform, false);
		}

		// Token: 0x0600F8F6 RID: 63734 RVA: 0x00390DE0 File Offset: 0x0038EFE0
		private bool OnClickSwearBtn(IXUIButton btn)
		{
			this.m_SwearDlg.SetActive(true);
			return true;
		}

		// Token: 0x0600F8F7 RID: 63735 RVA: 0x00390E00 File Offset: 0x0038F000
		public void CoolDownBtn(WeddingOperType type)
		{
			if (type != WeddingOperType.WeddingOper_Flower)
			{
				if (type == WeddingOperType.WeddingOper_Fireworks)
				{
					this.m_FireworksTime = XSingleton<XGlobalConfig>.singleton.GetInt("WeddingFireworksCD");
					this.m_FireworksCDTime.SetText(this.m_FireworksTime.ToString());
					this.m_FireworksCD.SetActive(true);
					this.StarFireworksTimer();
				}
			}
			else
			{
				this.m_FlowerTime = XSingleton<XGlobalConfig>.singleton.GetInt("WeddingFlowCD");
				this.m_FlowerCDTime.SetText(this.m_FlowerTime.ToString());
				this.m_FlowerCD.SetActive(true);
				this.StarFlowerTimer();
			}
		}

		// Token: 0x0600F8F8 RID: 63736 RVA: 0x00390EA4 File Offset: 0x0038F0A4
		private void StarFlowerTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFlower);
				this._CDTokenFlower = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFlower), null);
			}
		}

		// Token: 0x0600F8F9 RID: 63737 RVA: 0x00390EF4 File Offset: 0x0038F0F4
		private void StarFireworksTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFireworks);
				this._CDTokenFireworks = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFireworks), null);
			}
		}

		// Token: 0x0600F8FA RID: 63738 RVA: 0x00390F44 File Offset: 0x0038F144
		private void LeftTimeUpdateFlower(object o)
		{
			this.m_FlowerTime--;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFlower);
			bool flag = this.m_FlowerTime <= 0;
			if (flag)
			{
				this.m_FlowerCD.SetActive(false);
			}
			else
			{
				this.m_FlowerCDTime.SetText(this.m_FlowerTime.ToString());
				this._CDTokenFlower = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFlower), null);
			}
		}

		// Token: 0x0600F8FB RID: 63739 RVA: 0x00390FCC File Offset: 0x0038F1CC
		private void LeftTimeUpdateFireworks(object o)
		{
			this.m_FireworksTime--;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFireworks);
			bool flag = this.m_FireworksTime <= 0;
			if (flag)
			{
				this.m_FireworksCD.SetActive(false);
			}
			else
			{
				this.m_FireworksCDTime.SetText(this.m_FireworksTime.ToString());
				this._CDTokenFireworks = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFireworks), null);
			}
		}

		// Token: 0x0600F8FC RID: 63740 RVA: 0x00391054 File Offset: 0x0038F254
		private bool OnClickInviteFriendsBtn(IXUIButton btn)
		{
			DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600F8FD RID: 63741 RVA: 0x00391074 File Offset: 0x0038F274
		public void ShowPartnerSwearNtf(string name)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
			string @string = XStringDefineProxy.GetString("WeddingSwearTitle");
			string mainLabel = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingSwearContent")), name);
			string string2 = XStringDefineProxy.GetString(XStringDefine.COMMON_OK);
			string string3 = XStringDefineProxy.GetString("WeddingSwearCancel");
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTitle(@string);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, string2, string3);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.EnsureSwear), new ButtonClickEventHandler(this.NotEnsureSwear));
		}

		// Token: 0x0600F8FE RID: 63742 RVA: 0x00391118 File Offset: 0x0038F318
		private bool EnsureSwear(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_AgreeVows);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F8FF RID: 63743 RVA: 0x00391144 File Offset: 0x0038F344
		private bool NotEnsureSwear(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_DisAgreeVows);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F900 RID: 63744 RVA: 0x00391170 File Offset: 0x0038F370
		private bool OnAskSwearBtn(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_ApplyVows);
			return true;
		}

		// Token: 0x0600F901 RID: 63745 RVA: 0x00391190 File Offset: 0x0038F390
		public void ApplyVowsSuss()
		{
			bool activeSelf = this.m_SwearDlg.activeSelf;
			if (activeSelf)
			{
				this.m_SwearDlg.SetActive(false);
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingSwearSucc"), "fece00");
		}

		// Token: 0x0600F902 RID: 63746 RVA: 0x003911D4 File Offset: 0x0038F3D4
		private bool OnCloseSwear(IXUIButton btn)
		{
			this.m_SwearDlg.SetActive(false);
			return true;
		}

		// Token: 0x0600F903 RID: 63747 RVA: 0x003911F4 File Offset: 0x0038F3F4
		public void UpdateHappiness(uint happiness)
		{
			bool flag = (ulong)happiness >= (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("WeddingMaxHappyness")) && !this.m_HasVows && this.IsWeddingLover() && !this.m_HasShowVows;
			if (flag)
			{
				this.OnSwearPop();
				this.m_SwearFX.SetActive(true);
				this.m_HasShowVows = true;
			}
			this.m_HappinessValue.SetText(happiness.ToString());
			this.m_Happiness.SetText(happiness.ToString());
		}

		// Token: 0x0600F904 RID: 63748 RVA: 0x0039127C File Offset: 0x0038F47C
		public void OnVowsPrepare()
		{
			this.m_HasVows = true;
			bool flag = this.IsWeddingLover();
			if (flag)
			{
				this.m_SwearFX.SetActive(false);
			}
		}

		// Token: 0x0600F905 RID: 63749 RVA: 0x003912AC File Offset: 0x0038F4AC
		public void UpdateWeddingState(WeddingState state, uint lefttime, bool vows)
		{
			this.m_HasVows = vows;
			XSingleton<XDebug>.singleton.AddLog("weddingstate:" + state.ToString() + ", lefttime:" + lefttime.ToString(), null, null, null, null, null, XDebugColor.XDebug_None);
			WeddingState weddingState = state;
			if (weddingState != WeddingState.WeddingState_Prepare)
			{
				if (weddingState == WeddingState.WeddingState_Running)
				{
					this.m_Tip1Content = "WeddingState2";
					this.m_UpdateTip2 = true;
					XSingleton<XTimerMgr>.singleton.KillTimer(this.m_Tip1CDToken);
					this.m_Tip1CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTime1Update), lefttime);
					this.SetTipTime(this.m_Tip1, lefttime, this.m_Tip1Content);
					this.CheckGuestShow(lefttime);
				}
			}
			else
			{
				this.m_Tip1Content = "WeddingState1";
				this.m_UpdateTip2 = false;
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_Tip1CDToken);
				this.m_Tip1CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTime1Update), lefttime);
				this.SetTipTime(this.m_Tip1, lefttime, this.m_Tip1Content);
				bool flag = this.IsWeddingLover();
				if (flag)
				{
					this.m_Tip2.SetText(XStringDefineProxy.GetString("WeddingState4"));
					this.m_Tip2.gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x0600F906 RID: 63750 RVA: 0x0039140C File Offset: 0x0038F60C
		private void LeftTime1Update(object o)
		{
			uint num = (uint)o - 1U;
			this.SetTipTime(this.m_Tip1, num, this.m_Tip1Content);
			bool updateTip = this.m_UpdateTip2;
			if (updateTip)
			{
				this.CheckGuestShow(num);
			}
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_Tip1CDToken);
			bool flag = num > 0U;
			if (flag)
			{
				this.m_Tip1CDToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTime1Update), num);
			}
		}

		// Token: 0x0600F907 RID: 63751 RVA: 0x0039148C File Offset: 0x0038F68C
		private void CheckGuestShow(uint weddingLeftTime)
		{
			bool flag = this.m_guestIndex >= this.m_vecGuestShowTime.Count;
			if (!flag)
			{
				uint num = this.m_weddingRunTime - weddingLeftTime;
				uint num2 = this.m_vecGuestShowTime[this.m_guestIndex];
				uint time = (num2 > num) ? (num2 - num) : 0U;
				this.SetTipTime(this.m_Tip2, time, "WeddingState3");
				bool flag2 = num2 <= num;
				if (flag2)
				{
					this.m_guestIndex++;
				}
			}
		}

		// Token: 0x0600F908 RID: 63752 RVA: 0x0039150C File Offset: 0x0038F70C
		private void SetTipTime(IXUILabel label, uint time, string content)
		{
			bool flag = time > 0U && time < 60U;
			if (flag)
			{
				label.SetText(XStringDefineProxy.GetString(content, new object[]
				{
					time,
					XSingleton<XStringTable>.singleton.GetString("SECOND_DUARATION")
				}));
			}
			else
			{
				uint num = time / 60U;
				label.SetText(XStringDefineProxy.GetString(content, new object[]
				{
					num,
					XSingleton<XStringTable>.singleton.GetString("MINUTE_DUARATION")
				}));
			}
			label.gameObject.SetActive(time > 0U);
		}

		// Token: 0x0600F909 RID: 63753 RVA: 0x003915A4 File Offset: 0x0038F7A4
		private void OnHappinessClick(IXUISprite btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
			string @string = XStringDefineProxy.GetString("WeddingHappinessTitle");
			string mainLabel = string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XStringTable>.singleton.GetString("WeddingHappinessContent")), new object[0]);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetTitle(@string);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(mainLabel, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.CloseHappinessDlg), null);
		}

		// Token: 0x0600F90A RID: 63754 RVA: 0x00391638 File Offset: 0x0038F838
		private bool CloseHappinessDlg(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600F90B RID: 63755 RVA: 0x00391658 File Offset: 0x0038F858
		public void OnSwearPop()
		{
			this.m_SwearDlg.SetActive(true);
		}

		// Token: 0x04006CA3 RID: 27811
		private IXUIButton m_exitHomeBtn;

		// Token: 0x04006CA4 RID: 27812
		private IXUIButton m_FlowerBtn;

		// Token: 0x04006CA5 RID: 27813
		private GameObject m_FlowerCD;

		// Token: 0x04006CA6 RID: 27814
		private IXUILabel m_FlowerCDTime;

		// Token: 0x04006CA7 RID: 27815
		private IXUIButton m_FireworksBtn;

		// Token: 0x04006CA8 RID: 27816
		private GameObject m_FireworksCD;

		// Token: 0x04006CA9 RID: 27817
		private IXUILabel m_FireworksCDTime;

		// Token: 0x04006CAA RID: 27818
		private IXUIButton m_SwearBtn;

		// Token: 0x04006CAB RID: 27819
		private IXUIButton m_InviteFriendsBtn;

		// Token: 0x04006CAC RID: 27820
		private IXUILabel m_Happiness;

		// Token: 0x04006CAD RID: 27821
		private IXUILabel m_HappinessMax;

		// Token: 0x04006CAE RID: 27822
		private IXUILabel m_Content;

		// Token: 0x04006CAF RID: 27823
		private IXUILabel m_WeddingName;

		// Token: 0x04006CB0 RID: 27824
		private IXUIList m_BtnsGrid;

		// Token: 0x04006CB1 RID: 27825
		private IXUISprite m_HappinessBtn;

		// Token: 0x04006CB2 RID: 27826
		private GameObject m_SwearDlg;

		// Token: 0x04006CB3 RID: 27827
		private IXUIButton m_AskSwearBtn;

		// Token: 0x04006CB4 RID: 27828
		private IXUILabel m_HappinessValue;

		// Token: 0x04006CB5 RID: 27829
		private IXUIButton m_CloseSwearBtn;

		// Token: 0x04006CB6 RID: 27830
		private GameObject m_SwearFX;

		// Token: 0x04006CB7 RID: 27831
		private GameObject m_InviteRedPoint;

		// Token: 0x04006CB8 RID: 27832
		private IXUILabel m_Tip1;

		// Token: 0x04006CB9 RID: 27833
		private IXUILabel m_Tip2;

		// Token: 0x04006CBA RID: 27834
		private XFx m_Fireworks;

		// Token: 0x04006CBB RID: 27835
		private XFx m_Candy;

		// Token: 0x04006CBC RID: 27836
		private uint m_Tip1CDToken;

		// Token: 0x04006CBD RID: 27837
		private string m_Tip1Content;

		// Token: 0x04006CBE RID: 27838
		private bool m_UpdateTip2 = false;

		// Token: 0x04006CBF RID: 27839
		private int m_FlowerTime = 0;

		// Token: 0x04006CC0 RID: 27840
		private int m_FireworksTime = 0;

		// Token: 0x04006CC1 RID: 27841
		private uint _CDTokenFlower = 0U;

		// Token: 0x04006CC2 RID: 27842
		private uint _CDTokenFireworks = 0U;

		// Token: 0x04006CC3 RID: 27843
		private List<uint> m_vecGuestShowTime = new List<uint>();

		// Token: 0x04006CC4 RID: 27844
		private int m_guestIndex = 0;

		// Token: 0x04006CC5 RID: 27845
		private uint m_weddingRunTime = 0U;

		// Token: 0x04006CC6 RID: 27846
		private bool m_HasVows = false;

		// Token: 0x04006CC7 RID: 27847
		private bool m_HasShowVows = false;
	}
}
