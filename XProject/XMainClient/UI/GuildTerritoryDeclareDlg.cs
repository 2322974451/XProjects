using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001772 RID: 6002
	internal class GuildTerritoryDeclareDlg : DlgBase<GuildTerritoryDeclareDlg, GuildTerritoryDeclareBehaviour>
	{
		// Token: 0x17003820 RID: 14368
		// (get) Token: 0x0600F7C8 RID: 63432 RVA: 0x00387CEC File Offset: 0x00385EEC
		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryDeclareDlg";
			}
		}

		// Token: 0x0600F7C9 RID: 63433 RVA: 0x00387D04 File Offset: 0x00385F04
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mMessage.SetText(XStringDefineProxy.GetString("TB_DECLEAR_MESSAGE"));
			base.uiBehaviour.mAllianceWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnTerritoryUpdate));
		}

		// Token: 0x0600F7CA RID: 63434 RVA: 0x00387D64 File Offset: 0x00385F64
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.mTerritoryDeclare.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTerritoryDeclareClick));
			base.uiBehaviour.mTerritoryJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTerritoryJoinClick));
		}

		// Token: 0x0600F7CB RID: 63435 RVA: 0x00387DD0 File Offset: 0x00385FD0
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshWhenShow();
		}

		// Token: 0x0600F7CC RID: 63436 RVA: 0x00387DE1 File Offset: 0x00385FE1
		protected override void OnUnload()
		{
			this.m_lastTime = null;
			base.OnUnload();
		}

		// Token: 0x0600F7CD RID: 63437 RVA: 0x00387DF2 File Offset: 0x00385FF2
		protected override void OnHide()
		{
			base.uiBehaviour.mAllianceWrapContent.SetContentCount(0, false);
			base.OnHide();
		}

		// Token: 0x0600F7CE RID: 63438 RVA: 0x00387E10 File Offset: 0x00386010
		private bool OnTerritoryDeclareClick(IXUIButton btn)
		{
			CityData cityData;
			bool flag = !this._Doc.TryGetCityData(this._Doc.CurrentTerritoryID, out cityData);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = cityData.type != GUILDTERRTYPE.ALLIANCE;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TB_ENTRANCE_NO_PERMISSION"), "fece00");
					result = false;
				}
				else
				{
					string territoryname = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._Doc.CurrentTerritoryID).territoryname;
					string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("GuildTerritoryCost", XGlobalConfig.SequenceSeparator);
					string arg = XLabelSymbolHelper.FormatCostWithIcon(int.Parse(andSeparateValue[1]), (ItemEnum)int.Parse(andSeparateValue[0]));
					string format = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("TB_DECLEAR_COST"));
					string label = string.Format(format, arg, territoryname);
					string @string = XStringDefineProxy.GetString("COMMON_OK");
					string string2 = XStringDefineProxy.GetString("COMMON_CANCEL");
					XSingleton<UiUtility>.singleton.ShowModalDialog(label, @string, string2, new ButtonClickEventHandler(this.OnSureAllianceGuildTerr), 100);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600F7CF RID: 63439 RVA: 0x00387F24 File Offset: 0x00386124
		private bool OnSureAllianceGuildTerr(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.SendAllianceGuildTerr(this._Doc.CurrentTerritoryID);
			return true;
		}

		// Token: 0x0600F7D0 RID: 63440 RVA: 0x00387F5C File Offset: 0x0038615C
		private bool OnTerritoryJoinClick(IXUIButton btn)
		{
			bool flag = this.m_lastTime != null && this.m_lastTime.LeftTime > 0f;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TERRITORY_CDTIME", new object[]
				{
					(int)this.m_lastTime.LeftTime
				}), "fece00");
				result = false;
			}
			else
			{
				this._Doc.SendWaitScene(this._Doc.CurrentTerritoryID);
				result = true;
			}
			return result;
		}

		// Token: 0x0600F7D1 RID: 63441 RVA: 0x00387FE0 File Offset: 0x003861E0
		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F7D2 RID: 63442 RVA: 0x00387FFC File Offset: 0x003861FC
		private void OnListUpdate(Transform t, int index)
		{
			GuildTerrChallInfo guildTerrChallInfo = this._Doc.GuildTerrChallList[index];
			IXUILabel ixuilabel = t.FindChild("Index").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText((index + 1).ToString());
			ixuilabel2.SetText(guildTerrChallInfo.guildname);
		}

		// Token: 0x0600F7D3 RID: 63443 RVA: 0x00388074 File Offset: 0x00386274
		private void OnTerritoryUpdate(Transform t, int index)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			GuildTerritoryAllianceInfo guildTerritoryAllianceInfo = this._Doc.GuildTerrAllianceInfos[index];
			IXUILabel ixuilabel = t.FindChild("Index").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = t.FindChild("Alliance").GetComponent("XUISprite") as IXUISprite;
			IXUISprite ixuisprite2 = t.FindChild("Allianced").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText((index + 1).ToString());
			ixuilabel2.SetText(guildTerritoryAllianceInfo.GetAllinceString());
			IXUIButton ixuibutton = t.FindChild("Get").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.ID = guildTerritoryAllianceInfo.GuildID;
			CityData cityData;
			bool flag = this._Doc.TryGetCityData(this._Doc.CurrentTerritoryID, out cityData);
			if (flag)
			{
				ixuibutton.SetVisible(!guildTerritoryAllianceInfo.isAllicance && this._Doc.SelfAllianceID == 0UL && this._Doc.CurrentTerritoryID != this._Doc.SelfGuildTerritoryID && !guildTerritoryAllianceInfo.Contains(specificDocument.BasicData.uid) && specificDocument.BasicData.uid != guildTerritoryAllianceInfo.GuildID && this._Doc.CurrentTerritoryID == this._Doc.SelfTargetTerritoryID && cityData.guildid > 0UL);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAllianceClick));
				ixuisprite2.SetVisible(guildTerritoryAllianceInfo.isAllicance);
				ixuisprite.SetVisible(!guildTerritoryAllianceInfo.isAllicance && this._Doc.SelfAllianceID == 0UL && guildTerritoryAllianceInfo.Contains(specificDocument.BasicData.uid));
			}
			else
			{
				ixuibutton.SetVisible(false);
				ixuisprite.SetVisible(false);
				ixuisprite2.SetVisible(false);
			}
		}

		// Token: 0x0600F7D4 RID: 63444 RVA: 0x00388270 File Offset: 0x00386470
		private bool OnAllianceClick(IXUIButton btn)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Alliance:", btn.ID.ToString(), null, null, null, null);
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = specificDocument.Position != GuildPosition.GPOS_LEADER && specificDocument.Position != GuildPosition.GPOS_VICELEADER;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TB_ALLIANCE_NO_PERMISSON"), "fece00");
				result = false;
			}
			else
			{
				bool flag2 = this._Doc.CurrentTerritoryID != this._Doc.SelfTargetTerritoryID;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TB_ALLIANCE_NO_DECLEAR"), "fece00");
					result = false;
				}
				else
				{
					CityData cityData;
					bool flag3 = !this._Doc.TryGetCityData(this._Doc.CurrentTerritoryID, out cityData);
					if (flag3)
					{
						result = false;
					}
					else
					{
						string text;
						bool flag4 = !this._Doc.TryGetTerritoryGuildName(btn.ID, out text);
						if (flag4)
						{
							result = false;
						}
						else
						{
							bool flag5 = cityData.guildid > 0UL;
							if (flag5)
							{
								string territoryname = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._Doc.CurrentTerritoryID).territoryname;
								string @string = XStringDefineProxy.GetString("TB_ALLIANCE_SEND", new object[]
								{
									text,
									territoryname
								});
								string string2 = XStringDefineProxy.GetString("COMMON_OK");
								string string3 = XStringDefineProxy.GetString("COMMON_CANCEL");
								this.AllianceGuildID = btn.ID;
								XSingleton<UiUtility>.singleton.ShowModalDialog(@string, string2, string3, new ButtonClickEventHandler(this.TrySendTryAlliance), 100);
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ERR_TB_DECLEAR_NO_ALLIANCE"), "fece00");
							}
							result = true;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600F7D5 RID: 63445 RVA: 0x00388430 File Offset: 0x00386630
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = !this.mCountDown;
			if (!flag)
			{
				bool flag2 = this.m_lastTime == null;
				if (flag2)
				{
					this.mCountDown = false;
				}
				else
				{
					this.m_lastTime.Update();
					bool flag3 = this.m_lastTime.LeftTime <= 0f;
					if (flag3)
					{
						this.mCountDown = false;
						this._Doc.RefreshGuildTerritoryInfo();
					}
				}
			}
		}

		// Token: 0x0600F7D6 RID: 63446 RVA: 0x003884A8 File Offset: 0x003866A8
		private bool TrySendTryAlliance(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			bool flag = this.AllianceGuildID > 0UL;
			if (flag)
			{
				this._Doc.SendTryAlliance(this.AllianceGuildID);
			}
			return false;
		}

		// Token: 0x0600F7D7 RID: 63447 RVA: 0x003884E8 File Offset: 0x003866E8
		private bool CheckDeclare(CityData cityData)
		{
			return cityData.id != this._Doc.SelfTargetTerritoryID && cityData.type == GUILDTERRTYPE.ALLIANCE;
		}

		// Token: 0x0600F7D8 RID: 63448 RVA: 0x0038851C File Offset: 0x0038671C
		public void RefreshWhenShow()
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			TerritoryBattle.RowData byID = XGuildTerritoryDocument.mGuildTerritoryList.GetByID(this._Doc.CurrentTerritoryID);
			bool flag = byID == null;
			if (flag)
			{
				base.uiBehaviour.mTerritoryName.SetText(string.Empty);
				base.uiBehaviour.mTerritoryLevel.SetText(string.Empty);
				base.uiBehaviour.mSprite.SetSprite(string.Empty);
				base.uiBehaviour.mTerritoryCount.SetText("0");
				base.uiBehaviour.mSprite.MakePixelPerfect();
			}
			else
			{
				base.uiBehaviour.mTerritoryName.SetText(byID.territoryname);
				base.uiBehaviour.mTerritoryLevel.SetText(byID.territorylevelname);
				base.uiBehaviour.mSprite.SetSprite(byID.territoryIcon);
				base.uiBehaviour.mTerritoryCount.SetText(this._Doc.GuildTerrChallList.Count.ToString());
				base.uiBehaviour.mSprite.MakePixelPerfect();
			}
			CityData cityData;
			bool flag2 = this._Doc.TryGetCityData(this._Doc.CurrentTerritoryID, out cityData);
			if (flag2)
			{
				bool flag3 = cityData.guildid > 0UL;
				if (flag3)
				{
					base.uiBehaviour.mTerritoryGuildName.SetText(cityData.guildname);
				}
				else
				{
					base.uiBehaviour.mTerritoryGuildName.SetText(XStringDefineProxy.GetString("TERRITORY_EMPTY"));
				}
				bool flag4 = cityData.type == GUILDTERRTYPE.TERR_WARING || cityData.type == GUILDTERRTYPE.WAITING;
				bool flag5 = this.CheckDeclare(cityData);
				base.uiBehaviour.mTerritoryDeclare.SetVisible(flag5);
				base.uiBehaviour.mTerritoryJoin.SetVisible(flag4);
				int num = 0;
				bool flag6 = !flag4 && (this._Doc.CurrentType == GUILDTERRTYPE.TERR_WARING || this._Doc.CurrentType == GUILDTERRTYPE.WAITING);
				if (flag6)
				{
					int targetTerrioryType = (int)this._Doc.GetTargetTerrioryType(cityData.id);
					int targetTerrioryType2 = (int)this._Doc.GetTargetTerrioryType(this._Doc.SelfGuildTerritoryID);
					int num2 = targetTerrioryType - targetTerrioryType2;
					bool flag7 = num2 == 1;
					if (flag7)
					{
						base.uiBehaviour.mTerritoryMessage.SetText(XStringDefineProxy.GetString("ERR_TB_ALLIANCE_NO_DECLEAR"));
					}
					else
					{
						base.uiBehaviour.mTerritoryMessage.SetText(XStringDefineProxy.GetString("ERR_TB_ENTRANCE_NO_PERMISSION"));
					}
				}
				else
				{
					bool flag8 = this._Doc.CurrentType == GUILDTERRTYPE.ALLIANCE && !flag5 && !this._Doc.TryTerritoryAlliance(cityData.id, out num) && num > 0;
					if (flag8)
					{
						string @string = XStringDefineProxy.GetString(string.Format("ERR_TB_DECLEAR_LIMIT{0}", num));
						base.uiBehaviour.mTerritoryMessage.SetText(@string);
					}
					else
					{
						base.uiBehaviour.mTerritoryMessage.SetText(string.Empty);
					}
				}
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("{0} -- {1}", this._Doc.CurrentType, num), null, null, null, null, null);
				bool flag9 = cityData.type == GUILDTERRTYPE.WAITING;
				if (flag9)
				{
					bool flag10 = this.m_lastTime == null;
					if (flag10)
					{
						this.m_lastTime = new XElapseTimer();
					}
					this.m_lastTime.LeftTime = this._Doc.EnterBattleTime;
					this.mCountDown = true;
				}
			}
			else
			{
				base.uiBehaviour.mTerritoryGuildName.SetText(XStringDefineProxy.GetString("TERRITORY_EMPTY"));
				base.uiBehaviour.mTerritoryDeclare.SetVisible(false);
				base.uiBehaviour.mTerritoryJoin.SetVisible(false);
				base.uiBehaviour.mTerritoryMessage.SetText(string.Empty);
				this.mCountDown = false;
			}
			this.RefreshAllianceContent();
		}

		// Token: 0x0600F7D9 RID: 63449 RVA: 0x003888F8 File Offset: 0x00386AF8
		private void RefreshAllianceContent()
		{
			bool flag = !base.uiBehaviour.mAllianceScrollView.IsVisible();
			if (!flag)
			{
				bool flag2 = this._Doc.GuildTerrAllianceInfos == null;
				if (flag2)
				{
					base.uiBehaviour.mAllianceWrapContent.SetContentCount(0, false);
				}
				else
				{
					base.uiBehaviour.mAllianceWrapContent.SetContentCount(this._Doc.GuildTerrAllianceInfos.Count, false);
				}
				base.uiBehaviour.mAllianceWrapContent.RefreshAllVisibleContents();
			}
		}

		// Token: 0x04006C0E RID: 27662
		private XGuildTerritoryDocument _Doc;

		// Token: 0x04006C0F RID: 27663
		private XElapseTimer m_lastTime;

		// Token: 0x04006C10 RID: 27664
		private bool mCountDown = false;

		// Token: 0x04006C11 RID: 27665
		private ulong AllianceGuildID = 0UL;
	}
}
