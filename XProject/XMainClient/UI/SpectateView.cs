using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001858 RID: 6232
	internal class SpectateView : DlgBase<SpectateView, SpectateBehaviour>
	{
		// Token: 0x1700397F RID: 14719
		// (get) Token: 0x06010374 RID: 66420 RVA: 0x003E7B70 File Offset: 0x003E5D70
		public override string fileName
		{
			get
			{
				return "GameSystem/SpectateDlg";
			}
		}

		// Token: 0x17003980 RID: 14720
		// (get) Token: 0x06010375 RID: 66421 RVA: 0x003E7B88 File Offset: 0x003E5D88
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003981 RID: 14721
		// (get) Token: 0x06010376 RID: 66422 RVA: 0x003E7B9C File Offset: 0x003E5D9C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003982 RID: 14722
		// (get) Token: 0x06010377 RID: 66423 RVA: 0x003E7BB0 File Offset: 0x003E5DB0
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003983 RID: 14723
		// (get) Token: 0x06010378 RID: 66424 RVA: 0x003E7BC4 File Offset: 0x003E5DC4
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003984 RID: 14724
		// (get) Token: 0x06010379 RID: 66425 RVA: 0x003E7BD8 File Offset: 0x003E5DD8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003985 RID: 14725
		// (get) Token: 0x0601037A RID: 66426 RVA: 0x003E7BEC File Offset: 0x003E5DEC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003986 RID: 14726
		// (get) Token: 0x0601037B RID: 66427 RVA: 0x003E7C00 File Offset: 0x003E5E00
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Spectate);
			}
		}

		// Token: 0x0601037C RID: 66428 RVA: 0x003E7C1C File Offset: 0x003E5E1C
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpectateDocument>(XSpectateDocument.uuID);
			this._guildTagStr = XLabelSymbolHelper.FormatImage(SpectateView.TAG_ICON_ATLAS, "chat_tag_2");
			this._friendTagStr = XLabelSymbolHelper.FormatImage(SpectateView.TAG_ICON_ATLAS, "chat_tag_8");
			this._crossTagStr = XLabelSymbolHelper.FormatImage(SpectateView.TAG_ICON_ATLAS, "chat_tag_11");
			this._leagueTagStr = XLabelSymbolHelper.FormatImage(SpectateView.TAG_ICON_ATLAS, "chat_tag_9");
			this.SetupTabs();
			List<int> list = new List<int>();
			list.Add(0);
			list.Add(1);
			List<string> list2 = new List<string>();
			for (int i = 0; i < 2; i++)
			{
				list2.Add(string.Format("SpectateTags_{0}", i.ToString()));
			}
			base.uiBehaviour.m_tabControl.SetupTabs(list, list2, new XUITabControl.UITabControlCallback(this.OnTagCheckBoxClick), false, 1f, -1, true);
			this._spectateTabCheckBox = base.uiBehaviour.m_tabControl.GetByCheckBoxId(0UL);
			this.PROFRESSION_ICON_ATLAS = XSingleton<XGlobalConfig>.singleton.GetValue("PROFRESSION_ICON_ATLAS");
			base.uiBehaviour.m_SettingBtn.SetVisible(XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall);
		}

		// Token: 0x0601037D RID: 66429 RVA: 0x003E7D5C File Offset: 0x003E5F5C
		protected override void OnShow()
		{
			base.OnShow();
			this._spectateTabCheckBox.bChecked = true;
			this.OnTagCheckBoxClick(0UL);
			base.uiBehaviour.m_PKTips.SetVisible(false);
			base.uiBehaviour.m_SettingFrame.SetActive(false);
			base.uiBehaviour.m_BroadcastCamera.SetVisible(false);
			this.MyRecordInit();
		}

		// Token: 0x0601037E RID: 66430 RVA: 0x003E7DC4 File Offset: 0x003E5FC4
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_RefreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshBtnClick));
			base.uiBehaviour.m_PreviousBtn.ID = 0UL;
			base.uiBehaviour.m_PreviousBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.TurnPageBtnClick));
			base.uiBehaviour.m_NextBtn.ID = 1UL;
			base.uiBehaviour.m_NextBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.TurnPageBtnClick));
			base.uiBehaviour.m_BroadcastCamera.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnBroadcastCamera));
			base.uiBehaviour.m_SettingBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSettingBtnClick));
			base.uiBehaviour.m_SettingCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSettingCloseBtnClick));
			base.uiBehaviour.m_SettingSureBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSettingOkBtnClick));
			base.uiBehaviour.m_SettingAllow.ID = 0UL;
			base.uiBehaviour.m_SettingDeny.ID = 1UL;
			base.uiBehaviour.m_SettingAllow.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSettingCheckBoxClick));
			base.uiBehaviour.m_SettingDeny.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSettingCheckBoxClick));
		}

		// Token: 0x0601037F RID: 66431 RVA: 0x003E7F40 File Offset: 0x003E6140
		private void SetupTabs()
		{
			base.uiBehaviour.m_SpectateTabs.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_SpectateTabs.TplPos;
			this._tabCount = XSingleton<XGlobalConfig>.singleton.GetInt("Spectate_PVP_TabCount");
			for (int i = 0; i < this._tabCount; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_SpectateTabs.FetchGameObject(false);
				IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)i + 1L);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSpectateTabsClick));
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/Selected/TextLabel").GetComponent("XUILabel") as IXUILabel;
				string @string = XStringDefineProxy.GetString("Spectate_Type_" + (i + 1).ToString());
				ixuilabel.SetText(@string);
				ixuilabel2.SetText(@string);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(base.uiBehaviour.m_SpectateTabs.TplHeight * i), 0f);
				bool flag = i == 0;
				if (flag)
				{
					this._recommendCheckBox = ixuicheckBox;
				}
			}
		}

		// Token: 0x06010380 RID: 66432 RVA: 0x003E80B0 File Offset: 0x003E62B0
		private void SpectateInit()
		{
			this._recommendCheckBox.bChecked = true;
			this.OnSpectateTabsClick(this._recommendCheckBox);
		}

		// Token: 0x06010381 RID: 66433 RVA: 0x003E80CD File Offset: 0x003E62CD
		private void MyRecordInit()
		{
			this._doc.SendQueryMyLiveInfo();
		}

		// Token: 0x06010382 RID: 66434 RVA: 0x003E80DC File Offset: 0x003E62DC
		protected bool OnCloseClicked(IXUIButton go)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SetVisibleWithAnimation(false, null);
			}
			else
			{
				bool flag2 = Time.time - this.LastLevelSceneTime < 5f;
				if (flag2)
				{
					return false;
				}
				this.LastLevelSceneTime = Time.time;
				XSingleton<XScene>.singleton.ReqLeaveScene();
			}
			return true;
		}

		// Token: 0x06010383 RID: 66435 RVA: 0x003E8144 File Offset: 0x003E6344
		private bool OnSpectateTabsClick(IXUICheckBox icheckBox)
		{
			bool flag = !icheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = icheckBox.ID == 2UL;
				if (flag2)
				{
					base.uiBehaviour.m_PKTips.SetVisible(true);
					base.uiBehaviour.m_PKTips.SetText(XStringDefineProxy.GetString("Spectate_PK_Tips"));
				}
				else
				{
					base.uiBehaviour.m_PKTips.SetVisible(false);
				}
				this._doc.SendQuerySpectateInfo((int)icheckBox.ID);
				result = true;
			}
			return result;
		}

		// Token: 0x06010384 RID: 66436 RVA: 0x003E81CC File Offset: 0x003E63CC
		private void OnTagCheckBoxClick(ulong id)
		{
			bool flag = id == 0UL;
			if (flag)
			{
				base.uiBehaviour.m_SpectateFrame.SetActive(true);
				this.SpectateInit();
				base.uiBehaviour.m_MyLiveRecordFrame.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_SpectateFrame.SetActive(false);
				base.uiBehaviour.m_MyLiveRecordFrame.SetActive(true);
				this.RefreshMyRecord();
			}
		}

		// Token: 0x06010385 RID: 66437 RVA: 0x003E8240 File Offset: 0x003E6440
		private void TurnPageBtnClick(IXUISprite btn)
		{
			bool flag = btn.ID == 0UL;
			int num;
			if (flag)
			{
				num = this._doc.CurrPage - 1;
			}
			else
			{
				num = this._doc.CurrPage + 1;
			}
			bool flag2 = num < 0 || num >= this._doc.MaxPage;
			if (!flag2)
			{
				this.RefreshSpectate(num);
			}
		}

		// Token: 0x06010386 RID: 66438 RVA: 0x003E82A0 File Offset: 0x003E64A0
		private bool OnBroadcastCamera(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnOpenWebView();
			return true;
		}

		// Token: 0x06010387 RID: 66439 RVA: 0x003E82C0 File Offset: 0x003E64C0
		private bool OnRefreshBtnClick(IXUIButton btn)
		{
			this._doc.SendQuerySpectateInfo(this._doc.CurrTabs);
			return true;
		}

		// Token: 0x06010388 RID: 66440 RVA: 0x003E82EC File Offset: 0x003E64EC
		private bool OnWatchLiveBtnClick(IXUIButton btn)
		{
			this._currClickBtn = btn;
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.WatchNum = this._doc.SpectateRecord[(int)btn.ID].watchNum;
			specificDocument.CommendNum = this._doc.SpectateRecord[(int)btn.ID].commendNum;
			this._doc.EnterSpectateBattle(this._doc.SpectateRecord[(int)btn.ID].liveID, this._doc.SpectateRecord[(int)btn.ID].liveType);
			return true;
		}

		// Token: 0x06010389 RID: 66441 RVA: 0x003E839C File Offset: 0x003E659C
		public void SetWatchBtnGrey(bool isOver)
		{
			if (isOver)
			{
				this._doc.SpectateRecord[(int)this._currClickBtn.ID].canEnter = false;
			}
			this._currClickBtn.SetGrey(false);
		}

		// Token: 0x0601038A RID: 66442 RVA: 0x003E83E4 File Offset: 0x003E65E4
		public void RefreshSpectate(int page)
		{
			base.uiBehaviour.m_EmptyTips.SetActive(this._doc.MaxPage == 0);
			base.uiBehaviour.m_PageNum.gameObject.SetActive(this._doc.MaxPage != 0);
			base.uiBehaviour.m_SpectateLivePool.ReturnAll(false);
			bool flag = this._doc.MaxPage == 0;
			if (flag)
			{
				this._doc.CurrPage = 0;
				base.uiBehaviour.m_PreviousBtn.gameObject.SetActive(false);
				base.uiBehaviour.m_NextBtn.gameObject.SetActive(false);
			}
			else
			{
				this._doc.CurrPage = page;
				base.uiBehaviour.m_PreviousBtn.gameObject.SetActive(page > 0);
				base.uiBehaviour.m_NextBtn.gameObject.SetActive(page < this._doc.MaxPage - 1);
				base.uiBehaviour.m_PageNum.SetText((page + 1).ToString() + "/" + this._doc.MaxPage.ToString());
				for (int i = 0; i < this._doc.ITEMPERPAGE; i++)
				{
					int num = page * this._doc.ITEMPERPAGE + i;
					bool flag2 = num < 0 || num >= this._doc.SpectateRecord.Count;
					GameObject gameObject;
					if (flag2)
					{
						for (int j = i; j < this._doc.ITEMPERPAGE; j++)
						{
							gameObject = base.uiBehaviour.m_SpectateLivePool.FetchGameObject(false);
							gameObject.SetActive(false);
						}
						break;
					}
					OneLiveRecordInfo info = this._doc.SpectateRecord[num];
					gameObject = base.uiBehaviour.m_SpectateLivePool.FetchGameObject(false);
					Vector3 tplPos = base.uiBehaviour.m_SpectateLivePool.TplPos;
					gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * base.uiBehaviour.m_SpectateLivePool.TplHeight), 0f);
					this.SetMessageInTpl(gameObject, info, true, num);
				}
			}
		}

		// Token: 0x0601038B RID: 66443 RVA: 0x003E8634 File Offset: 0x003E6834
		public void RefreshMyRecord()
		{
			this.SetVisibleSettingTextState();
			IXUILabel ixuilabel = base.uiBehaviour.m_MyLiveRecordFrame.transform.Find("Watch").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("Spectate_MyRecord_TotalWatchText"), this._doc.TotalWatch));
			IXUILabel ixuilabel2 = base.uiBehaviour.m_MyLiveRecordFrame.transform.Find("Commend").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("Spectate_MyRecord_TotalCommendText"), this._doc.TotalCommend));
			GameObject gameObject = base.uiBehaviour.m_MyLiveRecordFrame.transform.Find("NA").gameObject;
			gameObject.SetActive(this._doc.WatchMostRecord == null);
			GameObject gameObject2 = base.uiBehaviour.m_MyLiveRecordFrame.transform.Find("UpView/Watch/itemTpl").gameObject;
			gameObject2.SetActive(this._doc.WatchMostRecord != null);
			bool flag = this._doc.WatchMostRecord != null;
			if (flag)
			{
				this.SetMessageInTpl(gameObject2, this._doc.WatchMostRecord, false, 0);
			}
			GameObject gameObject3 = base.uiBehaviour.m_MyLiveRecordFrame.transform.Find("UpView/Commend/itemTpl").gameObject;
			gameObject3.SetActive(this._doc.CommendMostRecord != null);
			bool flag2 = this._doc.CommendMostRecord != null;
			if (flag2)
			{
				this.SetMessageInTpl(gameObject3, this._doc.CommendMostRecord, false, 0);
			}
			base.uiBehaviour.m_MyLiveUpView.SetActive(this._doc.WatchMostRecord != null);
			base.uiBehaviour.m_MyLiveDownView.SetActive(this._doc.WatchMostRecord != null);
			base.uiBehaviour.m_MyLivePool.ReturnAll(false);
			for (int i = 0; i < this._doc.MyRecentRecord.Count; i++)
			{
				GameObject gameObject4 = base.uiBehaviour.m_MyLivePool.FetchGameObject(false);
				Vector3 tplPos = base.uiBehaviour.m_MyLivePool.TplPos;
				gameObject4.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * base.uiBehaviour.m_MyLivePool.TplHeight), 0f);
				this.SetMessageInTpl(gameObject4, this._doc.MyRecentRecord[i], false, 0);
			}
		}

		// Token: 0x0601038C RID: 66444 RVA: 0x003E88D8 File Offset: 0x003E6AD8
		private void SetMessageInTpl(GameObject go, OneLiveRecordInfo info, bool showWatchBtn, int index = 0)
		{
			if (showWatchBtn)
			{
				IXUIButton ixuibutton = go.transform.Find("Bg/Message/WatchBtn").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnWatchLiveBtnClick));
				ixuibutton.SetGrey(info.canEnter);
				int num = this._doc.CurrTime - info.beginTime;
				bool flag = num < 0;
				if (flag)
				{
					num = 0;
				}
				IXUILabel ixuilabel = go.transform.Find("Bg/Desc/Time").GetComponent("XUILabel") as IXUILabel;
				bool flag2 = num < 3600;
				if (flag2)
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString(num, 3, 0) + XStringDefineProxy.GetString("AGO"));
				}
				else
				{
					ixuilabel.SetText(XSingleton<UiUtility>.singleton.TimeAccFormatString(num, 2, 0) + XStringDefineProxy.GetString("AGO"));
				}
			}
			IXUILabel ixuilabel2 = go.transform.Find("Bg/Desc/Commend/Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel2.SetText(info.commendNum.ToString() + XStringDefineProxy.GetString("Spectate_times"));
			IXUILabel ixuilabel3 = go.transform.Find("Bg/Desc/Watch/Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel3.SetText(info.watchNum.ToString() + XStringDefineProxy.GetString("Spectate_times"));
			IXUILabelSymbol ixuilabelSymbol = go.transform.Find("Bg/Desc/Title").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			string text = this._doc.GetTitle(info);
			bool hasGuild = info.hasGuild;
			if (hasGuild)
			{
				text += this._guildTagStr;
			}
			bool hasFriend = info.hasFriend;
			if (hasFriend)
			{
				text += this._friendTagStr;
			}
			bool isCross = info.isCross;
			if (isCross)
			{
				text += this._crossTagStr;
			}
			ixuilabelSymbol.InputText = text;
			GameObject gameObject = go.transform.Find("Bg/Message/1V1").gameObject;
			GameObject gameObject2 = go.transform.Find("Bg/Message/NVN").gameObject;
			GameObject gameObject3 = go.transform.Find("Bg/Message/Center").gameObject;
			GameObject gameObject4 = go.transform.Find("Bg/Message/VS").gameObject;
			bool flag3 = info.liveType != LiveType.LIVE_DRAGON && info.liveType != LiveType.LIVE_NEST;
			bool flag4 = info.liveType == LiveType.LIVE_PVP2 || ((info.liveType == LiveType.LIVE_PROTECTCAPTAIN || info.liveType == LiveType.LIVE_HEROBATTLE) && showWatchBtn);
			gameObject.SetActive(flag3 && !flag4);
			gameObject2.SetActive(flag3 && flag4);
			gameObject3.SetActive(!flag3);
			gameObject4.SetActive(flag3);
			IXUILabelSymbol ixuilabelSymbol2 = gameObject.transform.Find("L").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol3 = gameObject.transform.Find("R").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol4 = gameObject2.transform.Find("DL").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol5 = gameObject2.transform.Find("DR").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol6 = gameObject2.transform.Find("UL").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol7 = gameObject2.transform.Find("UR").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabelSymbol ixuilabelSymbol8 = gameObject3.transform.Find("Min").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			string text2 = "";
			string text3 = "";
			switch (info.liveType)
			{
			case LiveType.LIVE_PVP:
			case LiveType.LIVE_CUSTOMPK:
				ixuilabelSymbol2.InputText = this.GetProIconString(info.nameInfos[0].roleInfo.type) + this._splitSpace + info.nameInfos[0].roleInfo.name;
				ixuilabelSymbol3.InputText = this.GetProIconString(info.nameInfos[1].roleInfo.type) + this._splitSpace + info.nameInfos[1].roleInfo.name;
				return;
			case LiveType.LIVE_NEST:
			case LiveType.LIVE_DRAGON:
				for (int i = 0; i < info.nameInfos.Count; i++)
				{
					bool flag5 = info.nameInfos[i].teamLeaderName != "";
					if (flag5)
					{
						text2 = string.Format(XStringDefineProxy.GetString("TEAM_NAME"), info.nameInfos[i].teamLeaderName);
					}
				}
				text2 += this._splitBigSpace;
				for (int j = 0; j < info.nameInfos.Count; j++)
				{
					text2 += this.GetProIconString(info.nameInfos[j].roleInfo.type);
				}
				ixuilabelSymbol8.InputText = text2;
				return;
			case LiveType.LIVE_PROTECTCAPTAIN:
			case LiveType.LIVE_HEROBATTLE:
				if (showWatchBtn)
				{
					for (int k = 0; k < info.nameInfos.Count; k++)
					{
						bool isLeft = info.nameInfos[k].isLeft;
						if (isLeft)
						{
							bool flag6 = info.nameInfos[k].teamLeaderName != "";
							if (flag6)
							{
								ixuilabelSymbol6.InputText = string.Format(XStringDefineProxy.GetString("TEAM_NAME"), info.nameInfos[k].teamLeaderName);
							}
							text2 += this.GetProIconString(info.nameInfos[k].roleInfo.type);
						}
						else
						{
							bool flag7 = info.nameInfos[k].teamLeaderName != "";
							if (flag7)
							{
								ixuilabelSymbol7.InputText = string.Format(XStringDefineProxy.GetString("TEAM_NAME"), info.nameInfos[k].teamLeaderName);
							}
							text3 += this.GetProIconString(info.nameInfos[k].roleInfo.type);
						}
					}
					ixuilabelSymbol4.InputText = text2;
					ixuilabelSymbol5.InputText = text3;
				}
				else
				{
					for (int l = 0; l < info.nameInfos.Count; l++)
					{
						bool isLeft2 = info.nameInfos[l].isLeft;
						if (isLeft2)
						{
							bool flag8 = info.nameInfos[l].teamLeaderName != "";
							if (flag8)
							{
								text2 = string.Format(XStringDefineProxy.GetString("TEAM_NAME"), info.nameInfos[l].teamLeaderName);
							}
						}
						else
						{
							bool flag9 = info.nameInfos[l].teamLeaderName != "";
							if (flag9)
							{
								text3 = string.Format(XStringDefineProxy.GetString("TEAM_NAME"), info.nameInfos[l].teamLeaderName);
							}
						}
					}
					text2 += this._splitSpace;
					text3 += this._splitSpace;
					for (int m = 0; m < info.nameInfos.Count; m++)
					{
						bool isLeft3 = info.nameInfos[m].isLeft;
						if (isLeft3)
						{
							text2 += this.GetProIconString(info.nameInfos[m].roleInfo.type);
						}
						else
						{
							text3 += this.GetProIconString(info.nameInfos[m].roleInfo.type);
						}
					}
					ixuilabelSymbol2.InputText = text2;
					ixuilabelSymbol3.InputText = text3;
				}
				return;
			case LiveType.LIVE_GUILDBATTLE:
				ixuilabelSymbol2.InputText = this.GetGuildIconString(info.nameInfos[0].guildIcon) + info.nameInfos[0].guildName;
				ixuilabelSymbol3.InputText = this.GetGuildIconString(info.nameInfos[1].guildIcon) + info.nameInfos[1].guildName;
				return;
			case LiveType.LIVE_LEAGUEBATTLE:
				ixuilabelSymbol2.InputText = string.Format("{0}{1}", this._leagueTagStr, info.nameInfos[0].teamName);
				ixuilabelSymbol3.InputText = string.Format("{0}{1}", this._leagueTagStr, info.nameInfos[1].teamName);
				return;
			case LiveType.LIVE_PVP2:
			{
				bool flag10 = true;
				bool flag11 = true;
				ixuilabelSymbol6.SetVisible(false);
				ixuilabelSymbol4.SetVisible(false);
				ixuilabelSymbol7.SetVisible(false);
				ixuilabelSymbol5.SetVisible(false);
				for (int n = 0; n < info.nameInfos.Count; n++)
				{
					bool isLeft4 = info.nameInfos[n].isLeft;
					if (isLeft4)
					{
						bool flag12 = flag10;
						if (flag12)
						{
							flag10 = false;
							ixuilabelSymbol6.SetVisible(true);
							ixuilabelSymbol6.InputText = this.GetProIconString(info.nameInfos[n].roleInfo.type) + this._splitSpace + info.nameInfos[n].roleInfo.name;
						}
						else
						{
							ixuilabelSymbol4.SetVisible(true);
							ixuilabelSymbol4.InputText = this.GetProIconString(info.nameInfos[n].roleInfo.type) + this._splitSpace + info.nameInfos[n].roleInfo.name;
						}
					}
					else
					{
						bool flag13 = flag11;
						if (flag13)
						{
							flag11 = false;
							ixuilabelSymbol7.SetVisible(true);
							ixuilabelSymbol7.InputText = this.GetProIconString(info.nameInfos[n].roleInfo.type) + this._splitSpace + info.nameInfos[n].roleInfo.name;
						}
						else
						{
							ixuilabelSymbol5.SetVisible(true);
							ixuilabelSymbol5.InputText = this.GetProIconString(info.nameInfos[n].roleInfo.type) + this._splitSpace + info.nameInfos[n].roleInfo.name;
						}
					}
				}
				return;
			}
			case LiveType.LIVE_CROSSGVG:
			{
				string arg = this.GetGuildIconString(info.nameInfos[0].guildIcon) + info.nameInfos[0].guildName;
				ixuilabelSymbol2.InputText = string.Format(XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME"), info.nameInfos[0].serverid, arg);
				arg = this.GetGuildIconString(info.nameInfos[1].guildIcon) + info.nameInfos[1].guildName;
				ixuilabelSymbol3.InputText = string.Format(XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME"), info.nameInfos[1].serverid, arg);
				return;
			}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("UnDefine LiveType.", null, null, null, null, null);
		}

		// Token: 0x0601038D RID: 66445 RVA: 0x003E94C4 File Offset: 0x003E76C4
		private string GetProIconString(RoleType type)
		{
			int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(type);
			return XLabelSymbolHelper.FormatImage(this.PROFRESSION_ICON_ATLAS, XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID));
		}

		// Token: 0x0601038E RID: 66446 RVA: 0x003E94F4 File Offset: 0x003E76F4
		private string GetGuildIconString(int guildIconID)
		{
			return XLabelSymbolHelper.FormatImage(SpectateView.GUILD_ICON_ATLAS, "ghicon_" + guildIconID.ToString());
		}

		// Token: 0x0601038F RID: 66447 RVA: 0x003E9524 File Offset: 0x003E7724
		private bool OnSettingBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_SettingFrame.SetActive(true);
			base.uiBehaviour.m_SettingDesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpectateSettingStr")));
			this._doc.TempSetting = this._doc.VisibleSetting;
			base.uiBehaviour.m_SettingAllow.bChecked = this._doc.TempSetting;
			base.uiBehaviour.m_SettingDeny.bChecked = !this._doc.TempSetting;
			return true;
		}

		// Token: 0x06010390 RID: 66448 RVA: 0x003E95C0 File Offset: 0x003E77C0
		private bool OnSettingCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_SettingFrame.SetActive(false);
			return true;
		}

		// Token: 0x06010391 RID: 66449 RVA: 0x003E95E8 File Offset: 0x003E77E8
		private bool OnSettingCheckBoxClick(IXUICheckBox icb)
		{
			bool flag = !icb.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._doc.TempSetting = (icb.ID == 0UL);
				result = true;
			}
			return result;
		}

		// Token: 0x06010392 RID: 66450 RVA: 0x003E9624 File Offset: 0x003E7824
		private bool OnSettingOkBtnClick(IXUIButton btn)
		{
			RpcC2G_ChangeLiveVisible rpcC2G_ChangeLiveVisible = new RpcC2G_ChangeLiveVisible();
			rpcC2G_ChangeLiveVisible.oArg.visible = this._doc.TempSetting;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeLiveVisible);
			this.OnSettingCloseBtnClick(null);
			return true;
		}

		// Token: 0x06010393 RID: 66451 RVA: 0x003E9668 File Offset: 0x003E7868
		public void SetVisibleSettingTextState()
		{
			base.uiBehaviour.m_VisText.SetActive(this._doc.VisibleSetting);
			base.uiBehaviour.m_UnVisText.SetActive(!this._doc.VisibleSetting);
		}

		// Token: 0x04007456 RID: 29782
		private XSpectateDocument _doc;

		// Token: 0x04007457 RID: 29783
		private string PROFRESSION_ICON_ATLAS = "SkillIcon/SkillTree";

		// Token: 0x04007458 RID: 29784
		private static readonly string GUILD_ICON_ATLAS = "common/Billboard";

		// Token: 0x04007459 RID: 29785
		private static readonly string TAG_ICON_ATLAS = "common/Universal";

		// Token: 0x0400745A RID: 29786
		private string _guildTagStr;

		// Token: 0x0400745B RID: 29787
		private string _friendTagStr;

		// Token: 0x0400745C RID: 29788
		private string _crossTagStr;

		// Token: 0x0400745D RID: 29789
		private string _leagueTagStr;

		// Token: 0x0400745E RID: 29790
		private string _splitSpace = " ";

		// Token: 0x0400745F RID: 29791
		private string _splitBigSpace = "      ";

		// Token: 0x04007460 RID: 29792
		private float LastLevelSceneTime = 0f;

		// Token: 0x04007461 RID: 29793
		private IXUICheckBox _recommendCheckBox;

		// Token: 0x04007462 RID: 29794
		private IXUICheckBox _spectateTabCheckBox;

		// Token: 0x04007463 RID: 29795
		private IXUIButton _currClickBtn;

		// Token: 0x04007464 RID: 29796
		private int _tabCount;
	}
}
