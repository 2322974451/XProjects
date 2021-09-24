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

	internal class SpectateView : DlgBase<SpectateView, SpectateBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SpectateDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Spectate);
			}
		}

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

		private void SpectateInit()
		{
			this._recommendCheckBox.bChecked = true;
			this.OnSpectateTabsClick(this._recommendCheckBox);
		}

		private void MyRecordInit()
		{
			this._doc.SendQueryMyLiveInfo();
		}

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

		private bool OnBroadcastCamera(IXUIButton btn)
		{
			XSingleton<XChatIFlyMgr>.singleton.OnOpenWebView();
			return true;
		}

		private bool OnRefreshBtnClick(IXUIButton btn)
		{
			this._doc.SendQuerySpectateInfo(this._doc.CurrTabs);
			return true;
		}

		private bool OnWatchLiveBtnClick(IXUIButton btn)
		{
			this._currClickBtn = btn;
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			specificDocument.WatchNum = this._doc.SpectateRecord[(int)btn.ID].watchNum;
			specificDocument.CommendNum = this._doc.SpectateRecord[(int)btn.ID].commendNum;
			this._doc.EnterSpectateBattle(this._doc.SpectateRecord[(int)btn.ID].liveID, this._doc.SpectateRecord[(int)btn.ID].liveType);
			return true;
		}

		public void SetWatchBtnGrey(bool isOver)
		{
			if (isOver)
			{
				this._doc.SpectateRecord[(int)this._currClickBtn.ID].canEnter = false;
			}
			this._currClickBtn.SetGrey(false);
		}

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

		private string GetProIconString(RoleType type)
		{
			int profID = XFastEnumIntEqualityComparer<RoleType>.ToInt(type);
			return XLabelSymbolHelper.FormatImage(this.PROFRESSION_ICON_ATLAS, XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(profID));
		}

		private string GetGuildIconString(int guildIconID)
		{
			return XLabelSymbolHelper.FormatImage(SpectateView.GUILD_ICON_ATLAS, "ghicon_" + guildIconID.ToString());
		}

		private bool OnSettingBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_SettingFrame.SetActive(true);
			base.uiBehaviour.m_SettingDesc.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("SpectateSettingStr")));
			this._doc.TempSetting = this._doc.VisibleSetting;
			base.uiBehaviour.m_SettingAllow.bChecked = this._doc.TempSetting;
			base.uiBehaviour.m_SettingDeny.bChecked = !this._doc.TempSetting;
			return true;
		}

		private bool OnSettingCloseBtnClick(IXUIButton btn)
		{
			base.uiBehaviour.m_SettingFrame.SetActive(false);
			return true;
		}

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

		private bool OnSettingOkBtnClick(IXUIButton btn)
		{
			RpcC2G_ChangeLiveVisible rpcC2G_ChangeLiveVisible = new RpcC2G_ChangeLiveVisible();
			rpcC2G_ChangeLiveVisible.oArg.visible = this._doc.TempSetting;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChangeLiveVisible);
			this.OnSettingCloseBtnClick(null);
			return true;
		}

		public void SetVisibleSettingTextState()
		{
			base.uiBehaviour.m_VisText.SetActive(this._doc.VisibleSetting);
			base.uiBehaviour.m_UnVisText.SetActive(!this._doc.VisibleSetting);
		}

		private XSpectateDocument _doc;

		private string PROFRESSION_ICON_ATLAS = "SkillIcon/SkillTree";

		private static readonly string GUILD_ICON_ATLAS = "common/Billboard";

		private static readonly string TAG_ICON_ATLAS = "common/Universal";

		private string _guildTagStr;

		private string _friendTagStr;

		private string _crossTagStr;

		private string _leagueTagStr;

		private string _splitSpace = " ";

		private string _splitBigSpace = "      ";

		private float LastLevelSceneTime = 0f;

		private IXUICheckBox _recommendCheckBox;

		private IXUICheckBox _spectateTabCheckBox;

		private IXUIButton _currClickBtn;

		private int _tabCount;
	}
}
