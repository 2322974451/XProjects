using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class WeddingSceneHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Wedding/WeddingSceneHandler";
			}
		}

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

		private bool OnClickExitHome(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

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

		private bool EnsureFlower(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Flower);
			return true;
		}

		public void RefreshInviteRedPoint()
		{
			this.m_InviteRedPoint.SetActive(XWeddingDocument.Doc.HasApplyCandidate);
		}

		public void OnFlowerRain()
		{
			Transform transform = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingFlowerFxPath");
			XFx xfx = XSingleton<XFxMgr>.singleton.CreateUIFx(value, transform, false);
			xfx.DelayDestroy = 3f;
			XSingleton<XFxMgr>.singleton.DestroyFx(xfx, false);
		}

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

		private bool EnsureFireworks(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Fireworks);
			return true;
		}

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

		private bool OnClickSwearBtn(IXUIButton btn)
		{
			this.m_SwearDlg.SetActive(true);
			return true;
		}

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

		private void StarFlowerTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFlower);
				this._CDTokenFlower = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFlower), null);
			}
		}

		private void StarFireworksTimer()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._CDTokenFireworks);
				this._CDTokenFireworks = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LeftTimeUpdateFireworks), null);
			}
		}

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

		private bool OnClickInviteFriendsBtn(IXUIButton btn)
		{
			DlgBase<XWeddingInviteView, XWeddingInviteBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private bool EnsureSwear(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_AgreeVows);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private bool NotEnsureSwear(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_DisAgreeVows);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		private bool OnAskSwearBtn(IXUIButton btn)
		{
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_ApplyVows);
			return true;
		}

		public void ApplyVowsSuss()
		{
			bool activeSelf = this.m_SwearDlg.activeSelf;
			if (activeSelf)
			{
				this.m_SwearDlg.SetActive(false);
			}
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("WeddingSwearSucc"), "fece00");
		}

		private bool OnCloseSwear(IXUIButton btn)
		{
			this.m_SwearDlg.SetActive(false);
			return true;
		}

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

		public void OnVowsPrepare()
		{
			this.m_HasVows = true;
			bool flag = this.IsWeddingLover();
			if (flag)
			{
				this.m_SwearFX.SetActive(false);
			}
		}

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

		private bool CloseHappinessDlg(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public void OnSwearPop()
		{
			this.m_SwearDlg.SetActive(true);
		}

		private IXUIButton m_exitHomeBtn;

		private IXUIButton m_FlowerBtn;

		private GameObject m_FlowerCD;

		private IXUILabel m_FlowerCDTime;

		private IXUIButton m_FireworksBtn;

		private GameObject m_FireworksCD;

		private IXUILabel m_FireworksCDTime;

		private IXUIButton m_SwearBtn;

		private IXUIButton m_InviteFriendsBtn;

		private IXUILabel m_Happiness;

		private IXUILabel m_HappinessMax;

		private IXUILabel m_Content;

		private IXUILabel m_WeddingName;

		private IXUIList m_BtnsGrid;

		private IXUISprite m_HappinessBtn;

		private GameObject m_SwearDlg;

		private IXUIButton m_AskSwearBtn;

		private IXUILabel m_HappinessValue;

		private IXUIButton m_CloseSwearBtn;

		private GameObject m_SwearFX;

		private GameObject m_InviteRedPoint;

		private IXUILabel m_Tip1;

		private IXUILabel m_Tip2;

		private XFx m_Fireworks;

		private XFx m_Candy;

		private uint m_Tip1CDToken;

		private string m_Tip1Content;

		private bool m_UpdateTip2 = false;

		private int m_FlowerTime = 0;

		private int m_FireworksTime = 0;

		private uint _CDTokenFlower = 0U;

		private uint _CDTokenFireworks = 0U;

		private List<uint> m_vecGuestShowTime = new List<uint>();

		private int m_guestIndex = 0;

		private uint m_weddingRunTime = 0U;

		private bool m_HasVows = false;

		private bool m_HasShowVows = false;
	}
}
