using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001820 RID: 6176
	internal class XDesignationView : DlgHandlerBase
	{
		// Token: 0x17003919 RID: 14617
		// (get) Token: 0x0601008E RID: 65678 RVA: 0x003D07D8 File Offset: 0x003CE9D8
		protected override string FileName
		{
			get
			{
				return "ItemNew/DesignationFrame";
			}
		}

		// Token: 0x0601008F RID: 65679 RVA: 0x003D07F0 File Offset: 0x003CE9F0
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XDesignationDocument.uuID) as XDesignationDocument);
			this._currentClickID = this.UNSELECT;
			this.m_ScrollView = (base.PanelObject.transform.Find("Right/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TabTpl = base.PanelObject.transform.Find("Tabs/TabTpl").gameObject;
			this.m_TabPool.SetupPool(this.m_TabTpl.transform.parent.gameObject, this.m_TabTpl, 6U, false);
			this.m_DesListWrapContent = (this.m_ScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_CoverDesignation = (base.PanelObject.transform.Find("Left/CoverDes/Designation").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_AbilityLabel = (base.PanelObject.transform.Find("Left/Message/AttsLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_FightLabel = (base.PanelObject.transform.Find("Left/Message/FightLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_CoverBtn = (base.PanelObject.transform.Find("Right/Bottom/CoverBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_AbilityBtn = (base.PanelObject.transform.Find("Right/Bottom/AbilityBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_CoverBtnLabel = (this.m_CoverBtn.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_AbilityBtnLabel = (this.m_AbilityBtn.gameObject.transform.Find("TextLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_AbilityBtnRedPoint = this.m_AbilityBtn.gameObject.transform.Find("RedPoint").gameObject;
			this.m_AbilityBtnRedPoint.SetActive(false);
			this.m_PlayerName = (base.PanelObject.transform.Find("Left/CoverDes/Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_PlayerName.InputText = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
			this._doc.SendQueryDesignationInfo();
			this.SetDesTab();
		}

		// Token: 0x06010090 RID: 65680 RVA: 0x003D0A8C File Offset: 0x003CEC8C
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_CoverBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCoverBtnClicked));
			this.m_AbilityBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAbilityBtnClicked));
			this.m_DesListWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.DesWrapListUpdated));
			this.m_DesListWrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.ItemWrapListInit));
		}

		// Token: 0x06010091 RID: 65681 RVA: 0x003D0B04 File Offset: 0x003CED04
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.SendQueryDesignationInfo();
			this.m_GeneralDes.bChecked = true;
			this._doc.DesList[0].Clear();
			bool firstClick = this._firstClick;
			if (firstClick)
			{
				this._firstClick = false;
			}
			else
			{
				this._doc.SendQueryDesignationList(1U);
				this.SetDesignationList(this._doc.DesList[0], 0, true);
			}
		}

		// Token: 0x06010092 RID: 65682 RVA: 0x001E669E File Offset: 0x001E489E
		public override void OnUpdate()
		{
			base.OnUpdate();
		}

		// Token: 0x06010093 RID: 65683 RVA: 0x003D0B87 File Offset: 0x003CED87
		protected override void OnHide()
		{
			base.OnHide();
			base.PanelObject.SetActive(false);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._reqTimeToken);
		}

		// Token: 0x06010094 RID: 65684 RVA: 0x003D0BC0 File Offset: 0x003CEDC0
		public override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
			XSingleton<XTimerMgr>.singleton.KillTimer(this._reqTimeToken);
			base.OnUnload();
		}

		// Token: 0x06010095 RID: 65685 RVA: 0x003D0BEC File Offset: 0x003CEDEC
		private void ItemWrapListInit(Transform t, int i)
		{
			this._timeLabel[i] = (t.Find("LeftTime").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x06010096 RID: 65686 RVA: 0x003D0C14 File Offset: 0x003CEE14
		public bool OnDesTabClicked(IXUICheckBox checkBox)
		{
			bool flag = !checkBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._doc.LastDisPlayTab != (int)checkBox.ID;
				if (flag2)
				{
					this._currentClickID = this.UNSELECT;
					this.m_AbilityBtnRedPoint.SetActive(false);
				}
				this._doc.SendQueryDesignationList((uint)checkBox.ID + 1U);
				result = true;
			}
			return result;
		}

		// Token: 0x06010097 RID: 65687 RVA: 0x003D0C84 File Offset: 0x003CEE84
		public bool OnCoverBtnClicked(IXUIButton btn)
		{
			bool flag = this._currentClickID == this.UNSELECT;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = (ulong)this._doc.CoverDesignationID == (ulong)((long)this._currentClickID);
				if (flag2)
				{
					this._doc.SendQuerySetDesignation(1U, 0U);
				}
				else
				{
					this._doc.SendQuerySetDesignation(1U, (uint)this._currentClickID);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010098 RID: 65688 RVA: 0x003D0CEC File Offset: 0x003CEEEC
		public bool OnAbilityBtnClicked(IXUIButton iSp)
		{
			bool flag = this._currentClickID == this.UNSELECT;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = (ulong)this._doc.AbilityDesignationID == (ulong)((long)this._currentClickID);
				if (flag2)
				{
					this._doc.SendQuerySetDesignation(2U, 0U);
				}
				else
				{
					this._doc.SendQuerySetDesignation(2U, (uint)this._currentClickID);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06010099 RID: 65689 RVA: 0x003D0D54 File Offset: 0x003CEF54
		public void OnItemClick(IXUISprite iSp)
		{
			bool flag = this._currentClickID == (int)iSp.ID;
			if (!flag)
			{
				this.m_CoverBtn.SetEnable(true, false);
				this.m_AbilityBtn.SetEnable(true, false);
				bool flag2 = this.m_CurrentClickSprite != null;
				if (flag2)
				{
					this.m_CurrentClickSprite.gameObject.transform.Find("Select").gameObject.SetActive(false);
				}
				this._currentClickID = (int)iSp.ID;
				this.m_CurrentClickSprite = iSp;
				iSp.gameObject.transform.Find("Select").gameObject.SetActive(true);
				this.m_AbilityBtnRedPoint.SetActive(this._doc.GetPPTOfAbilityDes((uint)this._currentClickID) == this._doc.MaxAbilityDesNum && !this._doc.IsMaxAbilityDes);
				this.RefreshBtnText();
			}
		}

		// Token: 0x0601009A RID: 65690 RVA: 0x003D0E40 File Offset: 0x003CF040
		public void RefreshBtnText()
		{
			this.m_AbilityBtnLabel.SetText(XStringDefineProxy.GetString(((long)this._currentClickID == (long)((ulong)this._doc.AbilityDesignationID)) ? "Designation_Btn_Text2" : "Designation_Btn_Text1"));
			this.m_CoverBtnLabel.SetText(XStringDefineProxy.GetString(((long)this._currentClickID == (long)((ulong)this._doc.CoverDesignationID)) ? "Designation_Btn_Text4" : "Designation_Btn_Text3"));
		}

		// Token: 0x0601009B RID: 65691 RVA: 0x003D0EB2 File Offset: 0x003CF0B2
		public void UnCompleteTips(IXUISprite iSp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("Achi_Or_Des_UnComplete"), "fece00");
		}

		// Token: 0x0601009C RID: 65692 RVA: 0x003D0ED0 File Offset: 0x003CF0D0
		public void HideTabRedPoint()
		{
			this.m_AbilityBtnRedPoint.SetActive(false);
			for (int i = 0; i < 6; i++)
			{
				this.m_TabRedPoint[i].SetActive(false);
			}
			XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Design_Designation, false);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item, true);
		}

		// Token: 0x0601009D RID: 65693 RVA: 0x003D0F2C File Offset: 0x003CF12C
		public void SetTabRedPoint(List<bool> state)
		{
			bool flag = state.Count == 0;
			if (!flag)
			{
				bool flag2 = false;
				int num = (state.Count < 6) ? state.Count : 6;
				for (int i = 0; i < num; i++)
				{
					this.m_TabRedPoint[i].SetActive(state[i]);
					flag2 |= state[i];
				}
				XSingleton<XGameSysMgr>.singleton.SetSysRedPointState(XSysDefine.XSys_Design_Designation, flag2);
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Item, true);
			}
		}

		// Token: 0x0601009E RID: 65694 RVA: 0x003D0FB0 File Offset: 0x003CF1B0
		public void SetDesTab()
		{
			this.m_TabPool.ReturnAll(false);
			GameObject gameObject = this.m_TabPool.FetchGameObject(false);
			IXUICheckBox ixuicheckBox = gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
			this.m_TabRedPoint[0] = gameObject.transform.FindChild("Bg/RedPoint").gameObject;
			this.m_GeneralDes = ixuicheckBox;
			ixuicheckBox.ID = 0UL;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnDesTabClicked));
			Vector3 tplPos = this.m_TabPool.TplPos;
			for (int i = 1; i < 6; i++)
			{
				string @string = XStringDefineProxy.GetString("Designation_Tab_Name" + i.ToString());
				gameObject = this.m_TabPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(this.m_TabPool.TplHeight * i), 0f);
				this.m_TabRedPoint[i] = gameObject.transform.FindChild("Bg/RedPoint").gameObject;
				ixuicheckBox = (gameObject.transform.FindChild("Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				ixuicheckBox.ID = (ulong)((long)i);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnDesTabClicked));
				IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(@string);
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Bg/SelectedTextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(@string);
			}
		}

		// Token: 0x0601009F RID: 65695 RVA: 0x003D1164 File Offset: 0x003CF364
		public void SetCurrentChooseDes(uint type, uint ID)
		{
			this.RefreshBtnText();
			bool flag = ID == 0U;
			if (flag)
			{
				bool flag2 = type == 1U;
				if (flag2)
				{
					this.m_CoverDesignation.InputText = "";
				}
				else
				{
					this.m_AbilityLabel.SetText("");
					this.m_FightLabel.SetText(XStringDefineProxy.GetString("NONE"));
				}
			}
			else
			{
				DesignationTable.RowData byID = this._doc._DesignationTable.GetByID((int)ID);
				bool flag3 = type == 1U;
				if (flag3)
				{
					bool flag4 = byID.Effect == "";
					if (flag4)
					{
						bool special = byID.Special;
						if (special)
						{
							this.m_CoverDesignation.InputText = byID.Color + this._doc.SpecialDesignation;
						}
						else
						{
							this.m_CoverDesignation.InputText = byID.Color + byID.Designation;
						}
					}
					else
					{
						this.m_CoverDesignation.InputText = XLabelSymbolHelper.FormatDesignation(byID.Atlas, byID.Effect, 16);
					}
				}
				else
				{
					string text = "";
					uint num = 0U;
					this._doc.GetPPT(out text, out num, byID.Attribute, true);
					this.m_AbilityLabel.SetText(text);
					this.m_FightLabel.SetText(num.ToString());
				}
			}
		}

		// Token: 0x060100A0 RID: 65696 RVA: 0x003D12B8 File Offset: 0x003CF4B8
		private void DesWrapListUpdated(Transform t, int i)
		{
			bool flag = this._doc.LastDisPlayTab >= this._doc.DesList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("tab_index is out of range of designation list. index = ", this._doc.LastDisPlayTab.ToString(), " cout = ", this._doc.DesList.Count.ToString(), null, null);
			}
			else
			{
				bool flag2 = i >= this._doc.DesList[this._doc.LastDisPlayTab].Count;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("i is out of range of designation list. i = ", i.ToString(), " cout = ", this._doc.DesList[this._doc.LastDisPlayTab].Count.ToString(), null, null);
				}
				else
				{
					DesignationInfo designationInfo = this._doc.DesList[this._doc.LastDisPlayTab][i];
					IXUILabelSymbol ixuilabelSymbol = t.Find("Animation").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUISprite ixuisprite = t.Find("Sign/CoverSign").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = t.Find("Sign/AbilitySign").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = t.Find("DescLabel").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = t.Find("AttsLabel").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel3 = t.Find("FightLabel").GetComponent("XUILabel") as IXUILabel;
					GameObject gameObject = t.Find("New").gameObject;
					IXUISprite ixuisprite3 = t.GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)((long)designationInfo.ID);
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClick));
					bool flag3 = designationInfo.completed && this._currentClickID == this.UNSELECT && i == 0;
					if (flag3)
					{
						this.OnItemClick(ixuisprite3);
					}
					t.Find("Select").gameObject.SetActive(this._currentClickID == designationInfo.ID);
					GameObject gameObject2 = t.FindChild("UnCompleted").gameObject;
					gameObject.SetActive(designationInfo.isNew);
					bool flag4 = designationInfo.effect == "";
					string inputText;
					if (flag4)
					{
						inputText = designationInfo.color + designationInfo.desName;
					}
					else
					{
						inputText = XLabelSymbolHelper.FormatDesignation(designationInfo.atlas, designationInfo.effect, 16);
					}
					ixuilabelSymbol.InputText = inputText;
					IXUILabel ixuilabel4 = t.Find("LeftTime").GetComponent("XUILabel") as IXUILabel;
					bool flag5 = designationInfo.leftTime < 0;
					if (flag5)
					{
						this._leftTime[i % XDesignationView.MAXSHOWITEM] = -1;
						this._timeLabel[i % XDesignationView.MAXSHOWITEM] = null;
						ixuilabel4.SetVisible(false);
					}
					else
					{
						ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString(designationInfo.leftTime - (int)(this._doc.GetNowTime() - this._doc.GetSignTime), 5));
						this._timeLabel[i % XDesignationView.MAXSHOWITEM] = ixuilabel4;
						this._leftTime[i % XDesignationView.MAXSHOWITEM] = designationInfo.leftTime;
						ixuilabel4.SetVisible(true);
					}
					ixuisprite.SetVisible((long)designationInfo.ID == (long)((ulong)this._doc.CoverDesignationID));
					ixuisprite2.SetVisible((long)designationInfo.ID == (long)((ulong)this._doc.AbilityDesignationID));
					bool flag6 = (long)designationInfo.ID == (long)((ulong)this._doc.AbilityDesignationID);
					if (flag6)
					{
						bool flag7 = (long)designationInfo.ID == (long)((ulong)this._doc.CoverDesignationID);
						if (flag7)
						{
							ixuisprite2.gameObject.transform.localPosition = new Vector3((float)ixuisprite.spriteWidth, 0f);
						}
						else
						{
							ixuisprite2.gameObject.transform.localPosition = Vector3.zero;
						}
					}
					ixuilabel.SetText(designationInfo.explanation);
					string text = "";
					uint num = 0U;
					this._doc.GetPPT(out text, out num, designationInfo.attribute, false);
					GameObject gameObject3 = t.Find("RedPoint").gameObject;
					bool flag8 = designationInfo.completed && !this._doc.IsMaxAbilityDes && num == this._doc.MaxAbilityDesNum;
					if (flag8)
					{
						gameObject3.SetActive(true);
					}
					else
					{
						gameObject3.SetActive(false);
					}
					ixuilabel2.SetText(text);
					ixuilabel3.SetText(XStringDefineProxy.GetString("FRIENDS_FIGHT_POINT") + "+" + num.ToString());
					bool completed = designationInfo.completed;
					if (completed)
					{
						gameObject2.SetActive(false);
					}
					else
					{
						gameObject2.SetActive(true);
						IXUISprite ixuisprite4 = gameObject2.GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.UnCompleteTips));
					}
				}
			}
		}

		// Token: 0x060100A1 RID: 65697 RVA: 0x003D17DC File Offset: 0x003CF9DC
		public void SetDesignationList(List<DesignationInfo> list, int type, bool resetScrollPos = true)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				if (resetScrollPos)
				{
					this._currentClickID = this.UNSELECT;
					this.m_CoverBtn.SetEnable(false, false);
					this.m_AbilityBtn.SetEnable(false, false);
				}
				this._doc.LastDisPlayTab = type;
				for (int i = 0; i < XDesignationView.MAXSHOWITEM; i++)
				{
					this._leftTime[i] = -1;
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
				XSingleton<XTimerMgr>.singleton.KillTimer(this._reqTimeToken);
				int num = -1;
				for (int j = 0; j < list.Count; j++)
				{
					bool flag2 = list[j].leftTime > 0;
					if (flag2)
					{
						bool flag3 = num == -1 || list[j].leftTime < num;
						if (flag3)
						{
							num = list[j].leftTime;
						}
					}
				}
				bool flag4 = num != -1;
				if (flag4)
				{
					num -= (int)(this._doc.GetNowTime() - this._doc.GetSignTime);
					bool flag5 = num < 0;
					if (flag5)
					{
						num = 0;
					}
					this._reqTimeToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)num + 1.1f, new XTimerMgr.ElapsedEventHandler(this.ReqInfo), null);
					this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.RefreshLeftTime), null);
				}
				this.m_DesListWrapContent.SetContentCount(list.Count, false);
				if (resetScrollPos)
				{
					this.m_ScrollView.ResetPosition();
				}
			}
		}

		// Token: 0x060100A2 RID: 65698 RVA: 0x003D1981 File Offset: 0x003CFB81
		private void ReqInfo(object o = null)
		{
			this._doc.SendQueryDesignationInfo();
			this._doc.SendQueryDesignationList((uint)(this._doc.LastDisPlayTab + 1));
		}

		// Token: 0x060100A3 RID: 65699 RVA: 0x003D19AC File Offset: 0x003CFBAC
		private void RefreshLeftTime(object o = null)
		{
			for (int i = 0; i < XDesignationView.MAXSHOWITEM; i++)
			{
				bool flag = this._leftTime[i] >= 0;
				if (flag)
				{
					int num = this._leftTime[i] - (int)(this._doc.GetNowTime() - this._doc.GetSignTime);
					bool flag2 = num < 0;
					if (flag2)
					{
						this._leftTime[i] = -1;
						num = 0;
					}
					this._timeLabel[i].SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString(num, 5));
				}
			}
			this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.RefreshLeftTime), null);
		}

		// Token: 0x04007208 RID: 29192
		private XDesignationDocument _doc = null;

		// Token: 0x04007209 RID: 29193
		public GameObject m_TabTpl;

		// Token: 0x0400720A RID: 29194
		public GameObject[] m_TabRedPoint = new GameObject[6];

		// Token: 0x0400720B RID: 29195
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400720C RID: 29196
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400720D RID: 29197
		public IXUIWrapContent m_DesListWrapContent;

		// Token: 0x0400720E RID: 29198
		public IXUICheckBox m_GeneralDes;

		// Token: 0x0400720F RID: 29199
		private bool _firstClick = true;

		// Token: 0x04007210 RID: 29200
		public IXUILabelSymbol m_CoverDesignation;

		// Token: 0x04007211 RID: 29201
		public IXUILabel m_AbilityLabel;

		// Token: 0x04007212 RID: 29202
		public IXUILabel m_FightLabel;

		// Token: 0x04007213 RID: 29203
		public IXUIButton m_CoverBtn;

		// Token: 0x04007214 RID: 29204
		public IXUIButton m_AbilityBtn;

		// Token: 0x04007215 RID: 29205
		public IXUILabel m_CoverBtnLabel;

		// Token: 0x04007216 RID: 29206
		public IXUILabel m_AbilityBtnLabel;

		// Token: 0x04007217 RID: 29207
		public GameObject m_AbilityBtnRedPoint;

		// Token: 0x04007218 RID: 29208
		public IXUILabelSymbol m_PlayerName;

		// Token: 0x04007219 RID: 29209
		private IXUILabel[] _timeLabel = new IXUILabel[8];

		// Token: 0x0400721A RID: 29210
		private int[] _leftTime = new int[8];

		// Token: 0x0400721B RID: 29211
		private static readonly int MAXSHOWITEM = 8;

		// Token: 0x0400721C RID: 29212
		private uint _timeToken;

		// Token: 0x0400721D RID: 29213
		private uint _reqTimeToken;

		// Token: 0x0400721E RID: 29214
		public readonly int UNSELECT = 10000;

		// Token: 0x0400721F RID: 29215
		private int _currentClickID;

		// Token: 0x04007220 RID: 29216
		public IXUISprite m_CurrentClickSprite;
	}
}
