using System;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildSignRedPackageView : DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSignRedPacketDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 2;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
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

		protected override void Init()
		{
			this._Doc = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			base.uiBehaviour.m_instructionTitle.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("GuildRedPacketTitle"));
			base.uiBehaviour.m_scrollContent.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XSingleton<XGlobalConfig>.singleton.GetValue("GuildRedPacketDesc")));
			base.uiBehaviour.m_scrollView.ResetPosition();
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("GuildCheckInBonusTime");
			string[] array = value.Split(XGlobalConfig.ListSeparator);
			string[] array2 = array[0].Split(XGlobalConfig.SequenceSeparator);
			string[] array3 = array[1].Split(XGlobalConfig.SequenceSeparator);
			this.m_startTime = int.Parse(array2[0]) * 3600 + int.Parse(array2[1]) * 60;
			this.m_overTime = int.Parse(array3[0]) * 3600 + int.Parse(array3[1]) * 60;
			XSingleton<XDebug>.singleton.AddLog(string.Format("m_startime = {0},m_endtime ={1} ", this.m_startTime, this.m_overTime), null, null, null, null, null, XDebugColor.XDebug_None);
			base.uiBehaviour.m_redPoint.gameObject.SetActive(false);
			base.uiBehaviour.m_fixedRedPoint.gameObject.SetActive(false);
			base.uiBehaviour.m_AakLabel.SetText(XStringDefineProxy.GetString("QUICK_REPLY_2"));
		}

		public void RefreshRedPoint()
		{
			base.uiBehaviour.m_redPoint.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_GuildRedPacket));
			base.uiBehaviour.m_fixedRedPoint.gameObject.SetActive(XSingleton<XGameSysMgr>.singleton.GetSysRedPointState(XSysDefine.XSys_GuildBoon_FixedRedPacket));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.GetGuildCheckInBonusInfo();
			this.RefreshSignInfo();
			this.RefreshRedPoint();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this.RefreshRedPoint();
			this._Doc.GetGuildCheckInBonusInfo();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this._Doc == null || this._Doc.GuildBonus == null;
			if (!flag)
			{
				bool flag2 = this._Doc.GuildBonus.timeofday > (double)this.m_startTime && this._Doc.GuildBonus.timeofday < (double)this.m_overTime;
				bool flag3 = this.InActive != flag2;
				if (flag3)
				{
					this.InActive = flag2;
					bool flag4 = this.m_updateAction != null;
					if (flag4)
					{
						this.m_updateAction(this.InActive);
					}
				}
				double leftAskBonusTime = this._Doc.GuildBonus.leftAskBonusTime;
				bool flag5 = base.uiBehaviour.m_Ask.IsVisible();
				if (flag5)
				{
					bool flag6 = leftAskBonusTime > 0.0;
					if (flag6)
					{
						base.uiBehaviour.m_AakLabel.SetText(string.Format("{0}{1}", XStringDefineProxy.GetString("INVITATION_SENT_NOTIFICATION"), (int)this._Doc.GuildBonus.leftAskBonusTime));
					}
					else
					{
						base.uiBehaviour.m_AakLabel.SetText(XStringDefineProxy.GetString("QUICK_REPLY_2"));
					}
				}
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.m_History.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHistoryClick));
			base.uiBehaviour.m_sign.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSignClick));
			base.uiBehaviour.m_Send.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSendClick));
			base.uiBehaviour.m_Ask.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAskClick));
			base.uiBehaviour.m_Fiexd.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFiexdClick));
			int i = 0;
			int num = base.uiBehaviour.m_SignNodes.Length;
			while (i < num)
			{
				base.uiBehaviour.m_SignNodes[i].m_pressCircle.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCircleClick));
				i++;
			}
		}

		public void RefreshSignInfo()
		{
			XGuildCheckInBonusInfo guildBonus = this._Doc.GuildBonus;
			this.SetOnLineNum(guildBonus.onLineNum, guildBonus.guildMemberNum);
			this.SetSignValue(guildBonus.checkInNumber, guildBonus.guildMemberNum);
			this.SetBonusBrief(guildBonus);
			this.SetActiveCount(guildBonus.ActiveCount);
			this.RefreshPermission();
			this.RefreshSignStatu();
		}

		public void SetActiveCount(int activeCount)
		{
			int i = 0;
			int num = base.uiBehaviour.m_redPakages.Length;
			while (i < num)
			{
				bool flag = i < activeCount;
				if (flag)
				{
					base.uiBehaviour.m_redPakages[i].SetVisible(true);
				}
				else
				{
					base.uiBehaviour.m_redPakages[i].SetVisible(false);
				}
				i++;
			}
			this.m_uiBehaviour.m_redNumber.SetText(string.Format("{0}/4", activeCount));
		}

		public void SetOnLineNum(int cur, int total)
		{
			this.m_uiBehaviour.m_OnlineValue.SetText(string.Format("{0}", cur));
			this.m_uiBehaviour.m_BufferValue.SetText(string.Format("{0}%", this._Doc.GuildBonus.GetAddPercent(cur)));
		}

		public void SetSignValue(int signValue, int guildMemberNum)
		{
			string @string = XStringDefineProxy.GetString("GUILDRED_SIGN_VALUE", new object[]
			{
				string.Format("{0}", signValue)
			});
			this.m_uiBehaviour.m_SignValue.SetText(@string);
			this.m_uiBehaviour.m_CurSignValue.SetText(signValue.ToString());
		}

		private void RefreshSignStatu()
		{
			bool isCheckIn = this._Doc.GuildBonus.isCheckIn;
			this.m_uiBehaviour.m_sign.SetVisible(!isCheckIn);
		}

		private void OnCircleClick(IXUISprite uiSprite)
		{
			XGuildCheckInBonusInfo guildBonus = this._Doc.GuildBonus;
			bool flag = (int)uiSprite.ID < guildBonus.BonusBriefs.Length;
			if (flag)
			{
				XGuildCheckInBonusBrief xguildCheckInBonusBrief = this._Doc.GuildBonus.BonusBriefs[(int)uiSprite.ID];
				bool flag2 = xguildCheckInBonusBrief == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("OnCircleClick  Brief is null..", uiSprite.ID.ToString(), null, null, null, null);
				}
				else
				{
					bool flag3 = xguildCheckInBonusBrief.bonusState == BonusState.Bonus_UnActive;
					if (flag3)
					{
						GuildBonusTable.RowData redPacketConfig = XGuildRedPacketDocument.GetRedPacketConfig(xguildCheckInBonusBrief.bonusType);
						bool flag4 = redPacketConfig == null;
						if (!flag4)
						{
							int itemID = (int)redPacketConfig.GuildBonusReward[0];
							uint num = redPacketConfig.GuildBonusReward[1];
							string text = XBagDocument.GetItemConf(itemID).ItemName[0];
							string @string = XStringDefineProxy.GetString("GUILD_SIGN_REDPACKEGT_INFO", new object[]
							{
								xguildCheckInBonusBrief.brief.maxCount,
								num,
								text
							});
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format("{0},{1}", @string, XStringDefineProxy.GetString("ERR_GUILDCHECKIN_BOXLIMIT")), "fece00");
						}
					}
					else
					{
						bool flag5 = xguildCheckInBonusBrief.bonusState == BonusState.Bonus_Active;
						if (flag5)
						{
							GuildBonusTable.RowData redPacketConfig2 = XGuildRedPacketDocument.GetRedPacketConfig(xguildCheckInBonusBrief.bonusType);
							bool flag6 = redPacketConfig2 == null;
							if (!flag6)
							{
								int itemID2 = (int)redPacketConfig2.GuildBonusReward[0];
								uint num2 = redPacketConfig2.GuildBonusReward[1];
								string text2 = XBagDocument.GetItemConf(itemID2).ItemName[0];
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format("{0}{1}", XStringDefineProxy.GetString("GUILD_SIGN_REDPACKEGT_INFO", new object[]
								{
									xguildCheckInBonusBrief.brief.maxCount,
									num2,
									text2
								}), XStringDefineProxy.GetString("SIGN_REDPAKCAGE_TIPS")), "fece00");
							}
						}
						else
						{
							bool flag7 = xguildCheckInBonusBrief.bonusState == BonusState.Bonus_Actived;
							if (flag7)
							{
								DlgBase<XGuildRedPacketView, XGuildRedPacketBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							}
						}
					}
				}
			}
		}

		private void SetBonusBrief(XGuildCheckInBonusInfo bonusInfo)
		{
			XGuildCheckInBonusBrief[] bonusBriefs = bonusInfo.BonusBriefs;
			int i = 0;
			int num = bonusBriefs.Length;
			while (i < num)
			{
				XGuildSignNode xguildSignNode = base.uiBehaviour.m_SignNodes[i];
				bool flag = bonusBriefs[i] == null || xguildSignNode == null;
				if (!flag)
				{
					xguildSignNode.SetSignNumber(bonusBriefs[i].bonueMemberCount);
					xguildSignNode.SetBonusStatu(bonusBriefs[i].bonusState);
					float bonusProgress = 0f;
					bool flag2 = bonusBriefs[i].needMemberCount > 0U;
					if (flag2)
					{
						bool flag3 = (long)bonusInfo.checkInNumber > (long)((ulong)bonusBriefs[i].bonueMemberCount);
						if (flag3)
						{
							bonusProgress = 1f;
						}
						else
						{
							bool flag4 = (long)bonusInfo.checkInNumber < (long)((ulong)bonusBriefs[i].frontBonusMemberCount);
							if (flag4)
							{
								bonusProgress = 0f;
							}
							else
							{
								bonusProgress = (float)((long)bonusInfo.checkInNumber - (long)((ulong)bonusBriefs[i].frontBonusMemberCount)) / bonusBriefs[i].needMemberCount;
							}
						}
					}
					xguildSignNode.SetBonusProgress(bonusProgress);
				}
				i++;
			}
		}

		private void RefreshGuildLeader(bool state)
		{
			bool flag = this.InActive && this._Doc.GuildBonus.HasActive();
			if (flag)
			{
				this.m_uiBehaviour.m_Send.SetGrey(true);
			}
			else
			{
				this.m_uiBehaviour.m_Send.SetGrey(false);
			}
		}

		private void RefreshGuildMember(bool state)
		{
			bool flag = this._Doc.GuildBonus.AllActived();
			bool flag2 = this.InActive || !flag;
			if (flag2)
			{
				base.uiBehaviour.m_Ask.SetGrey(true);
			}
			else
			{
				base.uiBehaviour.m_Ask.SetGrey(false);
			}
		}

		private void RefreshPermission()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.ResetPermission();
			bool flag = specificDocument.IHavePermission(GuildPermission.GPEM_SENDCHECKINBONUS);
			if (flag)
			{
				base.uiBehaviour.m_Send.SetVisible(true);
				this.m_updateAction = new Action<bool>(this.RefreshGuildLeader);
			}
			else
			{
				base.uiBehaviour.m_Ask.SetVisible(true);
				this.m_updateAction = new Action<bool>(this.RefreshGuildMember);
			}
			bool flag2 = this.m_updateAction != null;
			if (flag2)
			{
				this.m_updateAction(this.InActive);
			}
		}

		private void ResetPermission()
		{
			base.uiBehaviour.m_Send.SetVisible(false);
			base.uiBehaviour.m_Ask.SetVisible(false);
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnFiexdClick(IXUIButton btn)
		{
			DlgBase<GuildFiexdRedPackageView, GuildFiexdRedPackageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return false;
		}

		private bool OnHistoryClick(IXUIButton btn)
		{
			DlgBase<XGuildRedPacketView, XGuildRedPacketBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private bool OnSignClick(IXUIButton btn)
		{
			bool flag = !this._GuildDoc.CheckInGuild();
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !this._GuildDoc.CheckUnlockLevel(XSysDefine.XSys_GuildHall_SignIn);
				if (flag2)
				{
					result = true;
				}
				else
				{
					DlgBase<XGuildSignInView, XGuildSignInBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					result = true;
				}
			}
			return result;
		}

		private bool OnSendClick(IXUIButton btn)
		{
			bool flag = !this.InActive;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONUSOUTTIME"), "fece00");
				XSingleton<XDebug>.singleton.AddGreenLog(XSingleton<XCommon>.singleton.StringCombine("ServerTime;", XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)this._Doc.GuildBonus.timeofday, 5)), null, null, null, null, null);
				result = false;
			}
			else
			{
				XGuildCheckInBonusBrief xguildCheckInBonusBrief;
				bool flag2 = this._Doc.GuildBonus.TryGetFreeBrief(out xguildCheckInBonusBrief);
				if (flag2)
				{
					string @string = XStringDefineProxy.GetString("GUILD_BONUSSENDIALOG", new object[]
					{
						this._Doc.GuildBonus.onLineNum,
						this._Doc.GuildBonus.GetAddPercent(this._Doc.GuildBonus.onLineNum),
						xguildCheckInBonusBrief.brief.maxCount
					});
					XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.OnSureSendGuildBonus));
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONUSONOTFREE"), "fece00");
				}
				result = true;
			}
			return result;
		}

		private bool OnSureSendGuildBonus(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._Doc.GetSendGuildBonus();
			return true;
		}

		private bool OnAskClick(IXUIButton btn)
		{
			bool flag = !this.InActive;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONUSOUTTIME"), "fece00");
				result = false;
			}
			else
			{
				XGuildCheckInBonusBrief xguildCheckInBonusBrief;
				bool flag2 = this._Doc.GuildBonus.TryGetFreeBrief(out xguildCheckInBonusBrief);
				if (flag2)
				{
					bool flag3 = this._Doc.GuildBonus.leftAskBonusTime > 0.0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONES_AFTER_TIME", new object[]
						{
							(int)this._Doc.GuildBonus.leftAskBonusTime
						}), "fece00");
					}
					else
					{
						DlgBase<QuickReplyDlg, XQuickReplyBehavior>.singleton.ShowView(2, new Action<bool>(this.ShowAskForCheckInBonues));
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GUILD_BONUSONOTFREE"), "fece00");
				}
				result = true;
			}
			return result;
		}

		private void ShowAskForCheckInBonues(bool state)
		{
			if (state)
			{
				XQuickReplyDocument specificDocument = XDocuments.GetSpecificDocument<XQuickReplyDocument>(XQuickReplyDocument.uuID);
				specificDocument.GetAskForCheckInBonus();
				this._Doc.GuildBonus.leftAskBonusTime = (double)XSingleton<XGlobalConfig>.singleton.GetInt("GuildBonusAskTimeSpan");
			}
		}

		private XGuildRedPacketDocument _Doc;

		private XGuildDocument _GuildDoc;

		private bool InActive = false;

		private int m_startTime;

		private int m_overTime;

		private Action<bool> m_updateAction;
	}
}
