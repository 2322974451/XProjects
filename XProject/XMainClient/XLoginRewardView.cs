using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F02 RID: 3842
	internal class XLoginRewardView : DlgHandlerBase
	{
		// Token: 0x1700358F RID: 13711
		// (get) Token: 0x0600CC14 RID: 52244 RVA: 0x002EDAAC File Offset: 0x002EBCAC
		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/LoginFrame";
			}
		}

		// Token: 0x0600CC15 RID: 52245 RVA: 0x002EDAC4 File Offset: 0x002EBCC4
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLoginRewardDocument>(XLoginRewardDocument.uuID);
			this._doc.View = this;
			this._welfDoc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.m_LoginItemPool.SetupPool(base.PanelObject.transform.FindChild("Panel").gameObject, base.PanelObject.transform.FindChild("Panel/LoginTpl").gameObject, 30U, false);
			this.criticalConfirmPanel = base.PanelObject.transform.FindChild("CriticalConfirm").gameObject;
			this.criticalConfirmOK = (this.criticalConfirmPanel.transform.FindChild("P/OK").GetComponent("XUIButton") as IXUIButton);
			this.criticalEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_gorgeous", null, true);
			this.inputBlocker = base.PanelObject.transform.FindChild("InputBlocker").gameObject;
			this.itemListPanel = (base.PanelObject.transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TQTips = base.PanelObject.transform.FindChild("P/T2").gameObject;
			this.m_Fx = base.PanelObject.transform.FindChild("effect").gameObject;
			this.m_Fx.SetActive(false);
			this.m_QQVipIcon = base.PanelObject.transform.FindChild("QQVIPTS/QQVIP").gameObject;
			this.m_QQSVipIcon = base.PanelObject.transform.FindChild("QQVIPTS/QQSVIP").gameObject;
			this.m_QQVipTip = (base.PanelObject.transform.FindChild("QQVIPTS").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_QQGameCenter = base.PanelObject.transform.Find("QQ").gameObject;
			this.m_WXGameCenter = base.PanelObject.transform.Find("Wechat").gameObject;
		}

		// Token: 0x0600CC16 RID: 52246 RVA: 0x002EDCEB File Offset: 0x002EBEEB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.criticalConfirmOK.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCriticalBtnOKClicked));
		}

		// Token: 0x0600CC17 RID: 52247 RVA: 0x002EDD10 File Offset: 0x002EBF10
		protected override void OnShow()
		{
			base.OnShow();
			this.criticalConfirmPanel.SetActive(false);
			this.inputBlocker.SetActive(false);
			this.m_TQTips.SetActive(this._welfDoc.IsOwnMemberPrivilege(MemberPrivilege.KingdomPrivilege_Commerce));
			this.RefreshPage();
			this.RefreshPlatformAbilityInfo();
		}

		// Token: 0x0600CC18 RID: 52248 RVA: 0x002EDD65 File Offset: 0x002EBF65
		protected override void OnHide()
		{
			base.OnHide();
			this.m_Fx.SetActive(false);
		}

		// Token: 0x0600CC19 RID: 52249 RVA: 0x002EDD7C File Offset: 0x002EBF7C
		public void ShowTQFx()
		{
			this.m_Fx.SetActive(false);
			this.m_Fx.SetActive(true);
		}

		// Token: 0x0600CC1A RID: 52250 RVA: 0x002EDD99 File Offset: 0x002EBF99
		private void RefreshPlatformAbilityInfo()
		{
			this.RefreshQQVipInfo();
			this.RefreshQQWXGameCenterInfo();
		}

		// Token: 0x0600CC1B RID: 52251 RVA: 0x002EDDAC File Offset: 0x002EBFAC
		private void RefreshQQVipInfo()
		{
			QQVipInfoClient qqvipInfo = XPlatformAbilityDocument.Doc.QQVipInfo;
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_QQVIP) && qqvipInfo != null;
			if (flag)
			{
				this.m_QQVipTip.SetVisible(qqvipInfo.is_svip || qqvipInfo.is_vip);
				SeqList<int> seqList = qqvipInfo.is_svip ? XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQSVipSignIn", true) : XSingleton<XGlobalConfig>.singleton.GetSequenceList("QQVipSignIn", true);
				bool flag2 = seqList.Count > 0;
				if (flag2)
				{
					int itemID = seqList[0, 0];
					int num = seqList[0, 1];
					string @string = XStringDefineProxy.GetString(qqvipInfo.is_svip ? "QQVIP_LOGIN_SVIP_TIP" : "QQVIP_LOGIN_VIP_TIP");
					string inputText = XSingleton<XCommon>.singleton.StringCombine(@string, XLabelSymbolHelper.FormatImage(itemID), num.ToString());
					this.m_QQVipTip.InputText = inputText;
				}
				this.m_QQVipIcon.SetActive(qqvipInfo.is_vip && !qqvipInfo.is_svip);
				this.m_QQSVipIcon.SetActive(qqvipInfo.is_svip);
			}
			else
			{
				this.m_QQVipTip.SetVisible(false);
				this.m_QQVipIcon.SetActive(false);
				this.m_QQSVipIcon.SetActive(false);
			}
		}

		// Token: 0x0600CC1C RID: 52252 RVA: 0x002EDF00 File Offset: 0x002EC100
		private void RefreshQQWXGameCenterInfo()
		{
			StartUpType launchTypeServerInfo = XSingleton<XLoginDocument>.singleton.GetLaunchTypeServerInfo();
			bool flag = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_QQ && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_QQ;
			if (flag)
			{
				string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("QQGameCenterSingnIn", XGlobalConfig.AllSeparators);
				IXUILabelSymbol ixuilabelSymbol = this.m_QQGameCenter.transform.FindChild("T").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				string text = XSingleton<XStringTable>.singleton.GetString("GAMECENTER_SIGN_IN_QQ");
				for (int i = 0; i < andSeparateValue.Length; i += 2)
				{
					bool flag2 = i + 1 < andSeparateValue.Length;
					if (flag2)
					{
						text = XSingleton<XCommon>.singleton.StringCombine(text, XLabelSymbolHelper.FormatImage(int.Parse(andSeparateValue[i])), andSeparateValue[i + 1]);
					}
				}
				ixuilabelSymbol.InputText = text;
				this.m_QQGameCenter.SetActive(true);
				bool flag3 = this.m_QQVipTip.IsVisible();
				if (flag3)
				{
					IXUILabel ixuilabel = this.m_QQVipTip.gameObject.transform.GetComponent("XUILabel") as IXUILabel;
					Vector3 localPosition = this.m_QQVipTip.gameObject.transform.localPosition;
					this.m_QQGameCenter.transform.localPosition = new Vector3(localPosition.x + (float)ixuilabel.spriteWidth + 20f, localPosition.y, localPosition.z);
				}
			}
			else
			{
				this.m_QQGameCenter.SetActive(false);
			}
			bool flag4 = XSingleton<XLoginDocument>.singleton.Channel == XAuthorizationChannel.XAuthorization_WeChat && XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Platform_StartPrivilege) && launchTypeServerInfo == StartUpType.StartUp_WX;
			if (flag4)
			{
				string[] andSeparateValue2 = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WXGameCenterSingnIn", XGlobalConfig.SequenceSeparator);
				IXUILabel ixuilabel2 = this.m_WXGameCenter.transform.FindChild("T").GetComponent("XUILabel") as IXUILabel;
				bool flag5 = andSeparateValue2.Length == 2;
				if (flag5)
				{
					ixuilabel2.SetText(XStringDefineProxy.GetString("GAMECENTER_SIGN_IN_WX", new object[]
					{
						andSeparateValue2[1],
						XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(int.Parse(andSeparateValue2[0])).ItemName, 0U)
					}));
				}
				this.m_WXGameCenter.SetActive(true);
			}
			else
			{
				this.m_WXGameCenter.SetActive(false);
			}
		}

		// Token: 0x0600CC1D RID: 52253 RVA: 0x002EE164 File Offset: 0x002EC364
		public override void OnUnload()
		{
			bool flag = this._doc != null;
			if (flag)
			{
				this._doc.View = null;
			}
			base.OnUnload();
		}

		// Token: 0x0600CC1E RID: 52254 RVA: 0x002EE194 File Offset: 0x002EC394
		public void RefreshPage()
		{
			List<uint> itemIDs = this._doc.ItemIDs;
			List<uint> itemCounts = this._doc.ItemCounts;
			int num = Math.Max(itemIDs.Count, this.m_LoginItemList.Count);
			for (int i = this.m_LoginItemList.Count; i < num; i++)
			{
				GameObject gameObject = this.m_LoginItemPool.FetchGameObject(false);
				this.m_LoginItemList.Add(gameObject);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Bg/Item/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)i);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
			}
			num = Math.Min(itemIDs.Count, this.m_LoginItemList.Count);
			for (int j = this.m_LoginItemList.Count - 1; j >= num; j--)
			{
				GameObject go = this.m_LoginItemList[j];
				this.m_LoginItemList.RemoveAt(j);
				this.m_LoginItemPool.ReturnInstance(go, false);
			}
			for (int k = 0; k < itemIDs.Count; k++)
			{
				uint itemID = itemIDs[k];
				uint itemCount = itemCounts[k];
				GameObject gameObject2 = this.m_LoginItemList[k];
				this._updateItemBasicInfo(gameObject2, itemID, itemCount, k);
				gameObject2.transform.localPosition = new Vector3(this.m_LoginItemPool.TplPos.x + (float)(k % XLoginRewardView.COLUMN * this.m_LoginItemPool.TplWidth), this.m_LoginItemPool.TplPos.y - (float)(k / XLoginRewardView.COLUMN * this.m_LoginItemPool.TplHeight), this.m_LoginItemPool.TplPos.z);
			}
			float num2 = 1f;
			bool flag = itemIDs.Count > XLoginRewardView.COLUMN;
			if (flag)
			{
				num2 = (float)((itemIDs.Count - 1) / XLoginRewardView.COLUMN);
			}
			float num3 = (float)((ulong)this._doc.DayChecked / (ulong)((long)XLoginRewardView.COLUMN));
			float position = num3 / num2;
			this.itemListPanel.SetPosition(position);
			uint dayChecked = this._doc.DayChecked;
			bool flag2 = (ulong)dayChecked < (ulong)((long)this.m_LoginItemList.Count);
			if (flag2)
			{
				IXUITweenTool ixuitweenTool = base.PanelObject.transform.FindChild("SignPlayTween").GetComponent("XUIPlayTween") as IXUITweenTool;
				GameObject gameObject3 = this.m_LoginItemList[(int)dayChecked].transform.Find("Signed").gameObject;
				ixuitweenTool.SetTargetGameObject(gameObject3);
			}
			this.RefreshStates();
		}

		// Token: 0x0600CC1F RID: 52255 RVA: 0x002EE454 File Offset: 0x002EC654
		public void RefreshStates()
		{
			uint dayChecked = this._doc.DayChecked;
			uint dayCanCheck = this._doc.DayCanCheck;
			bool todaySigned = this._doc.IsTodayChecked();
			GameObject gameObject = base.PanelObject.transform.FindChild("Check").gameObject;
			bool flag = dayChecked >= dayCanCheck;
			if (flag)
			{
				gameObject.SetActive(false);
			}
			else
			{
				gameObject.SetActive(true);
				IXUIButton ixuibutton = base.PanelObject.transform.FindChild("Check").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCheckClicked));
				GameObject gameObject2 = base.PanelObject.transform.FindChild("Check/RedPoint").gameObject;
				GameObject gameObject3 = base.PanelObject.transform.FindChild("Check/T").gameObject;
				GameObject gameObject4 = base.PanelObject.transform.FindChild("Check/Cost").gameObject;
				bool flag2 = this._doc.IsTodayChecked();
				if (flag2)
				{
					int replenishCost = (int)this._doc.GetReplenishCost();
					IXUILabel ixuilabel = base.PanelObject.transform.FindChild("Check/Cost").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(replenishCost.ToString());
					gameObject3.SetActive(false);
					gameObject4.SetActive(true);
					gameObject2.SetActive(false);
				}
				else
				{
					gameObject3.SetActive(true);
					gameObject4.SetActive(false);
					gameObject2.SetActive(true);
				}
			}
			for (int i = 0; i < this.m_LoginItemList.Count; i++)
			{
				GameObject go = this.m_LoginItemList[i];
				this._updateItemState(go, i, dayChecked, dayCanCheck, todaySigned);
			}
		}

		// Token: 0x0600CC20 RID: 52256 RVA: 0x002EE624 File Offset: 0x002EC824
		private void _canResign(GameObject go, bool can)
		{
			GameObject gameObject = go.transform.FindChild("ReSign").gameObject;
			if (can)
			{
				gameObject.SetActive(true);
			}
			else
			{
				gameObject.SetActive(false);
			}
		}

		// Token: 0x0600CC21 RID: 52257 RVA: 0x002EE664 File Offset: 0x002EC864
		private void _updateItemState(GameObject go, int index, uint daychecked, uint daycancheck, bool todaySigned)
		{
			GameObject gameObject = go.transform.FindChild("Cover").gameObject;
			GameObject gameObject2 = go.transform.FindChild("Signed").gameObject;
			IXUISprite ixuisprite = go.transform.FindChild("Bg").GetComponent("XUISprite") as IXUISprite;
			GameObject gameObject3 = go.transform.FindChild("RedPoint").gameObject;
			gameObject3.SetActive(false);
			bool flag = (long)index < (long)((ulong)daychecked);
			if (flag)
			{
				gameObject.SetActive(true);
				gameObject2.SetActive(true);
				this._canResign(go, false);
				ixuisprite.SetSprite("kz_lan");
			}
			else
			{
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
				bool flag2 = (long)index == (long)((ulong)daychecked) && daychecked < daycancheck;
				if (flag2)
				{
					ixuisprite.SetSprite("kz_lan2");
				}
				else
				{
					ixuisprite.SetSprite("kz_lan");
				}
				bool flag3 = (long)index < (long)((ulong)daycancheck);
				if (flag3)
				{
					bool flag4 = (long)index == (long)((ulong)daychecked) && !todaySigned;
					if (flag4)
					{
						this._canResign(go, false);
					}
					else
					{
						this._canResign(go, true);
					}
				}
				else
				{
					this._canResign(go, false);
				}
			}
		}

		// Token: 0x0600CC22 RID: 52258 RVA: 0x002EE7A0 File Offset: 0x002EC9A0
		private void _updateItemBasicInfo(GameObject go, uint itemID, uint itemCount, int index)
		{
			GameObject gameObject = go.transform.FindChild("Bg/Item").gameObject;
			IXUISprite ixuisprite = go.transform.FindChild("TQ").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.FindChild("TQ/Text").GetComponent("XUILabel") as IXUILabel;
			bool flag = (this._doc.DoubleTQ & 1 << index + 1) != 0;
			ixuisprite.SetVisible(flag);
			bool flag2 = flag;
			if (flag2)
			{
				ixuisprite.SetVisible(true);
			}
			else
			{
				ixuisprite.SetVisible(false);
			}
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)itemID, (int)itemCount, false);
		}

		// Token: 0x0600CC23 RID: 52259 RVA: 0x002EE858 File Offset: 0x002ECA58
		private bool OnCheckClicked(IXUIButton iSp)
		{
			uint dayChecked = this._doc.DayChecked;
			uint dayCanCheck = this._doc.DayCanCheck;
			bool flag = dayChecked < dayCanCheck;
			if (flag)
			{
				bool flag2 = this._doc.IsTodayChecked();
				if (flag2)
				{
					int replenishCost = (int)this._doc.GetReplenishCost();
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("LOGINREWARD_RESIGN_CONFIRM", new object[]
					{
						XLabelSymbolHelper.FormatCostWithIcon(replenishCost, ItemEnum.DRAGON_COIN)
					}), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnResignBtnOKClicked));
				}
				else
				{
					this._doc.ReqCheckin();
					GameObject gameObject = base.PanelObject.transform.FindChild("Check/RedPoint").gameObject;
					gameObject.SetActive(false);
				}
			}
			return true;
		}

		// Token: 0x0600CC24 RID: 52260 RVA: 0x002EE92C File Offset: 0x002ECB2C
		private void OnItemClicked(IXUISprite iSp)
		{
			uint dayChecked = this._doc.DayChecked;
			uint dayCanCheck = this._doc.DayCanCheck;
			bool flag = iSp.ID >= (ulong)dayChecked;
			if (flag)
			{
				List<uint> itemIDs = this._doc.ItemIDs;
				int num = (int)iSp.ID;
				bool flag2 = num >= itemIDs.Count;
				if (!flag2)
				{
					int itemID = (int)itemIDs[num];
					XSingleton<UiUtility>.singleton.ShowTooltipDialog(itemID, iSp, 0U);
				}
			}
		}

		// Token: 0x0600CC25 RID: 52261 RVA: 0x002EE9A8 File Offset: 0x002ECBA8
		private bool OnResignBtnOKClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._doc.ReqCheckin();
			return true;
		}

		// Token: 0x0600CC26 RID: 52262 RVA: 0x002EE9D4 File Offset: 0x002ECBD4
		public void SignTweenPlay()
		{
			IXUITweenTool ixuitweenTool = base.PanelObject.transform.FindChild("SignPlayTween").GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.PlayTween(true, -1f);
			uint dayChecked = this._doc.DayChecked;
			bool flag = (ulong)dayChecked < (ulong)((long)this.m_LoginItemList.Count);
			if (flag)
			{
				GameObject gameObject = this.m_LoginItemList[(int)dayChecked].transform.Find("Signed").gameObject;
				ixuitweenTool.SetTargetGameObject(gameObject);
			}
		}

		// Token: 0x0600CC27 RID: 52263 RVA: 0x002EEA60 File Offset: 0x002ECC60
		private bool OnCriticalBtnOKClicked(IXUIButton btn)
		{
			this.criticalConfirmPanel.SetActive(false);
			this.inputBlocker.SetActive(false);
			return true;
		}

		// Token: 0x0600CC28 RID: 52264 RVA: 0x002EEA90 File Offset: 0x002ECC90
		public void ShowCritical()
		{
			IXUILabel ixuilabel = this.criticalConfirmPanel.transform.FindChild("P/Times0").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = this.criticalConfirmPanel.transform.FindChild("P/Times1").GetComponent("XUILabel") as IXUILabel;
			GameObject gameObject = this.criticalConfirmPanel.transform.FindChild("P/Item").gameObject;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this._doc.ItemIDs[(int)(this._doc.DayChecked - 1U)], (int)this._doc.ItemCounts[(int)(this._doc.DayChecked - 1U)], true);
			ixuilabel.SetText(this._doc.Bonus.ToString());
			ixuilabel2.SetText(this._doc.Bonus.ToString());
			this.PlayCritical();
		}

		// Token: 0x0600CC29 RID: 52265 RVA: 0x002EEB8C File Offset: 0x002ECD8C
		public void PlayCritical()
		{
			this.inputBlocker.SetActive(true);
			this.criticalEffect.Play(Vector3.zero, Quaternion.identity, Vector3.one, 1f);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/yanhua", true, AudioChannel.Action);
			XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this._OnFinishPlayCriticalFx), null);
		}

		// Token: 0x0600CC2A RID: 52266 RVA: 0x002EEBF6 File Offset: 0x002ECDF6
		private void _OnFinishPlayCriticalFx(object o = null)
		{
			this.criticalConfirmPanel.SetActive(true);
		}

		// Token: 0x04005A9D RID: 23197
		public XUIPool m_LoginItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005A9E RID: 23198
		private List<GameObject> m_LoginItemList = new List<GameObject>();

		// Token: 0x04005A9F RID: 23199
		private XLoginRewardDocument _doc = null;

		// Token: 0x04005AA0 RID: 23200
		private XWelfareDocument _welfDoc = null;

		// Token: 0x04005AA1 RID: 23201
		private GameObject criticalConfirmPanel;

		// Token: 0x04005AA2 RID: 23202
		private IXUIButton criticalConfirmOK;

		// Token: 0x04005AA3 RID: 23203
		private XFx criticalEffect;

		// Token: 0x04005AA4 RID: 23204
		private GameObject inputBlocker;

		// Token: 0x04005AA5 RID: 23205
		private IXUIScrollView itemListPanel;

		// Token: 0x04005AA6 RID: 23206
		private GameObject m_TQTips;

		// Token: 0x04005AA7 RID: 23207
		private GameObject m_Fx;

		// Token: 0x04005AA8 RID: 23208
		private GameObject m_QQVipIcon;

		// Token: 0x04005AA9 RID: 23209
		private GameObject m_QQSVipIcon;

		// Token: 0x04005AAA RID: 23210
		private IXUILabelSymbol m_QQVipTip;

		// Token: 0x04005AAB RID: 23211
		private GameObject m_QQGameCenter;

		// Token: 0x04005AAC RID: 23212
		private GameObject m_WXGameCenter;

		// Token: 0x04005AAD RID: 23213
		private static readonly int COLUMN = 5;
	}
}
