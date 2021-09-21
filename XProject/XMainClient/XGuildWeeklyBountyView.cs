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
	// Token: 0x02000A5F RID: 2655
	internal class XGuildWeeklyBountyView : DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>
	{
		// Token: 0x17002F13 RID: 12051
		// (get) Token: 0x0600A0FC RID: 41212 RVA: 0x001B0E68 File Offset: 0x001AF068
		public override string fileName
		{
			get
			{
				return "Guild/GuildWeeklyBountyView";
			}
		}

		// Token: 0x17002F14 RID: 12052
		// (get) Token: 0x0600A0FD RID: 41213 RVA: 0x001B0E80 File Offset: 0x001AF080
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F15 RID: 12053
		// (get) Token: 0x0600A0FE RID: 41214 RVA: 0x001B0E94 File Offset: 0x001AF094
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17002F16 RID: 12054
		// (get) Token: 0x0600A0FF RID: 41215 RVA: 0x001B0EA8 File Offset: 0x001AF0A8
		public override int sysid
		{
			get
			{
				return 904;
			}
		}

		// Token: 0x0600A100 RID: 41216 RVA: 0x001B0EBF File Offset: 0x001AF0BF
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600A101 RID: 41217 RVA: 0x001B0EC9 File Offset: 0x001AF0C9
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600A102 RID: 41218 RVA: 0x001B0ED4 File Offset: 0x001AF0D4
		protected override void OnUnload()
		{
			bool flag = this._refreshTaskEffect != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._refreshTaskEffect, true);
			}
			bool flag2 = this._completedTaskEffect != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this._completedTaskEffect, true);
			}
			base.OnUnload();
		}

		// Token: 0x0600A103 RID: 41219 RVA: 0x001B0F27 File Offset: 0x001AF127
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600A104 RID: 41220 RVA: 0x001B0F38 File Offset: 0x001AF138
		protected override void OnHide()
		{
			this._curSelectIndex = 0U;
			base.OnHide();
		}

		// Token: 0x0600A105 RID: 41221 RVA: 0x001B0F4C File Offset: 0x001AF14C
		protected override void OnShow()
		{
			base.OnShow();
			bool flag = this._completedTaskEffect != null;
			if (flag)
			{
				this._completedTaskEffect.SetActive(false);
			}
			bool flag2 = this._refreshTaskEffect != null;
			if (flag2)
			{
				this._completedTaskEffect.SetActive(false);
			}
			base.uiBehaviour.MailRoot.gameObject.SetActive(false);
			XGuildWeeklyBountyDocument.Doc.SendGetWeeklyTaskInfo();
		}

		// Token: 0x0600A106 RID: 41222 RVA: 0x001B0FB8 File Offset: 0x001AF1B8
		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = this._completedTaskEffect != null;
			if (flag)
			{
				this._completedTaskEffect.SetActive(false);
			}
			bool flag2 = this._refreshTaskEffect != null;
			if (flag2)
			{
				this._refreshTaskEffect.SetActive(false);
			}
			base.uiBehaviour.MailRoot.gameObject.SetActive(false);
			XGuildWeeklyBountyDocument.Doc.SendGetWeeklyTaskInfo();
		}

		// Token: 0x0600A107 RID: 41223 RVA: 0x001B1024 File Offset: 0x001AF224
		public override void OnUpdate()
		{
			base.OnUpdate();
			double num = XGuildWeeklyBountyDocument.Doc.ActivityLeftTime;
			num -= (double)Time.deltaTime;
			XGuildWeeklyBountyDocument.Doc.ActivityLeftTime = num;
			bool flag = (int)num >= 1;
			if (flag)
			{
				bool flag2 = num >= 43200.0;
				string str;
				if (flag2)
				{
					str = XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)num, 4);
				}
				else
				{
					str = XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)num, 5);
				}
				base.uiBehaviour.LeftTimeLabel.SetText(XStringDefineProxy.GetString("WeeklyTaskLeftTime") + str);
			}
			else
			{
				base.uiBehaviour.LeftTimeLabel.SetText(XStringDefineProxy.GetString("WeeklyTaskFinished"));
			}
		}

		// Token: 0x0600A108 RID: 41224 RVA: 0x001B10DE File Offset: 0x001AF2DE
		public void RefreshUI()
		{
			this.RefreshMailInfo();
			this.RefreshTaskList(true);
			this.RefreshChestList();
		}

		// Token: 0x0600A109 RID: 41225 RVA: 0x001B10F8 File Offset: 0x001AF2F8
		public void RefreshTaskItem()
		{
			GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
			DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID((taskInfoByIndex == null) ? 0U : taskInfoByIndex.taskID);
			bool flag = dailyTaskTableInfoByID == null;
			if (!flag)
			{
				this.SetOpBtnState(taskInfoByIndex, dailyTaskTableInfoByID);
				IXUISprite ixuisprite = base.uiBehaviour.RightItem.transform.Find("Quality").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = base.uiBehaviour.RightItem.transform.Find("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + dailyTaskTableInfoByID.taskquality);
				ixuisprite2.SetSprite(dailyTaskTableInfoByID.TaskIcon, dailyTaskTableInfoByID.AtlasName, false);
				bool flag2 = dailyTaskTableInfoByID.tasktype == 1U || dailyTaskTableInfoByID.tasktype == 4U;
				base.uiBehaviour.GetLabel.SetText(flag2 ? XSingleton<XStringTable>.singleton.GetString("GotoObtain") : XSingleton<XStringTable>.singleton.GetString("PVPActivity_Go"));
				base.uiBehaviour.TaskDecLabel.SetText((dailyTaskTableInfoByID == null) ? "" : dailyTaskTableInfoByID.taskdescription);
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("WeeklyTaskAskHelpNum");
				base.uiBehaviour.WeeklyAskLabel.SetText(string.Format(XStringDefineProxy.GetString("WeeklyAsk"), XGuildWeeklyBountyDocument.Doc.WeeklyAskedHelpNum, @int));
				base.uiBehaviour.HelpBtn.SetEnable(!taskInfoByIndex.hasAsked && (ulong)XGuildWeeklyBountyDocument.Doc.WeeklyAskedHelpNum < (ulong)((long)@int) && !taskInfoByIndex.isRewarded, false);
				base.uiBehaviour.HelpBtn.gameObject.SetActive(flag2);
				base.uiBehaviour.WeeklyAskLabel.gameObject.SetActive(flag2);
				base.uiBehaviour.HelpBtn.ID = (ulong)dailyTaskTableInfoByID.taskID;
				base.uiBehaviour.HelpBtnLabel.SetText(taskInfoByIndex.hasAsked ? XStringDefineProxy.GetString("DailyTaskGetted") : XStringDefineProxy.GetString("DailyTaskGet"));
				int refreshedCount = (int)taskInfoByIndex.refreshedCount;
				int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("WeeklyTaskRefreshCount");
				base.uiBehaviour.RefreshBtn.SetEnable(refreshedCount < int2 && !taskInfoByIndex.isRewarded, false);
				base.uiBehaviour.RefreshBtn.ID = (ulong)dailyTaskTableInfoByID.taskID;
				int num = 0;
				int int3 = XSingleton<XGlobalConfig>.singleton.GetInt("WeekyFreeRefreshNum");
				bool flag3 = XGuildWeeklyBountyDocument.Doc.RemainedFreshTimes == 0U;
				if (flag3)
				{
					List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("WeeklyTaskRefreshCost");
					num = intList[Mathf.Min(new int[]
					{
						refreshedCount,
						int2,
						intList.Count - 1
					})];
				}
				string @string = XStringDefineProxy.GetString("WeeklyFreeRefresh");
				IXUILabel ixuilabel = base.uiBehaviour.FreeLabelObj.GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(string.Concat(new object[]
				{
					@string,
					XGuildWeeklyBountyDocument.Doc.RemainedFreshTimes,
					"/",
					int3
				}));
				base.uiBehaviour.FreeLabelObj.SetActive(num == 0);
				base.uiBehaviour.DragonCoinCostLabel.SetText(string.Format(XStringDefineProxy.GetString("WeelyDragonCoinCost"), num));
				base.uiBehaviour.DragonCoinCostLabel.gameObject.SetActive(num > 0);
				List<GuildTaskReward> singleTaskRewardInfoByID = XGuildWeeklyBountyDocument.Doc.GetSingleTaskRewardInfoByID(GuildTaskType.WeeklyTask, taskInfoByIndex.taskID);
				int num2 = (singleTaskRewardInfoByID == null) ? 0 : singleTaskRewardInfoByID.Count;
				int num3 = Mathf.Min(num2, base.uiBehaviour.RewardsParentTrans.childCount);
				int i = 0;
				bool flag4 = XActivityDocument.Doc.IsInnerDropTime(904U);
				while (i < num3)
				{
					GameObject gameObject = base.uiBehaviour.RewardsParentTrans.GetChild(i).gameObject;
					gameObject.SetActive(true);
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					bool flag5 = singleTaskRewardInfoByID[i].itemID == 4U && specificDocument.IsInLevelSeal();
					int itemCount;
					if (flag5)
					{
						itemCount = (int)(singleTaskRewardInfoByID[i].count * 0.5);
					}
					else
					{
						itemCount = (int)singleTaskRewardInfoByID[i].count;
					}
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)singleTaskRewardInfoByID[i].itemID, itemCount, true);
					IXUISprite ixuisprite3 = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite3.ID = (ulong)singleTaskRewardInfoByID[i].itemID;
					ixuisprite3.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					Transform transform = gameObject.transform.FindChild("Double");
					bool flag6 = transform != null;
					if (flag6)
					{
						transform.gameObject.SetActive(flag4 && singleTaskRewardInfoByID[i].itemID != 4U);
					}
					i++;
				}
				while (i < base.uiBehaviour.RewardsParentTrans.childCount)
				{
					base.uiBehaviour.RewardsParentTrans.GetChild(i++).gameObject.SetActive(false);
				}
				base.uiBehaviour.ProgressLabel.SetText(taskInfoByIndex.step + "/" + dailyTaskTableInfoByID.conditionNum);
				base.uiBehaviour.SingleTaskBountyLabel.SetText(XStringDefineProxy.GetString("CurrentTaskScoreText") + dailyTaskTableInfoByID.score);
			}
		}

		// Token: 0x0600A10A RID: 41226 RVA: 0x001B16FC File Offset: 0x001AF8FC
		public void PlayRefreshEffect()
		{
			bool flag = this._refreshTaskEffect != null;
			if (flag)
			{
				this._refreshTaskEffect.SetActive(true);
				this._refreshTaskEffect.Play(base.uiBehaviour.effectRoot, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x0600A10B RID: 41227 RVA: 0x001B1750 File Offset: 0x001AF950
		public void PlayCompleteEffect()
		{
			bool flag = this._completedTaskEffect != null;
			if (flag)
			{
				this._completedTaskEffect.SetActive(true);
				this._completedTaskEffect.Play(base.uiBehaviour.effectRoot, Vector3.zero, Vector3.one, 1f, true, false);
			}
		}

		// Token: 0x0600A10C RID: 41228 RVA: 0x001B17A4 File Offset: 0x001AF9A4
		public void RefreshTaskItemALL()
		{
			bool flag = this._selectCheck != null;
			if (flag)
			{
				GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID((taskInfoByIndex == null) ? 0U : taskInfoByIndex.taskID);
				bool flag2 = dailyTaskTableInfoByID != null;
				if (flag2)
				{
					IXUILabel ixuilabel = this._selectCheck.gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(taskInfoByIndex.step + "/" + dailyTaskTableInfoByID.conditionNum);
					GameObject gameObject = this._selectCheck.gameObject.transform.Find("RedPoint").gameObject;
					gameObject.SetActive(taskInfoByIndex.step >= dailyTaskTableInfoByID.conditionNum && !taskInfoByIndex.isRewarded);
				}
			}
			this.RefreshTaskItem();
		}

		// Token: 0x0600A10D RID: 41229 RVA: 0x001B1898 File Offset: 0x001AFA98
		public void RefreshChestList()
		{
			List<uint> chestValueList = XGuildWeeklyBountyDocument.Doc.ChestValueList;
			uint weeklyScore = XGuildWeeklyBountyDocument.Doc.WeeklyScore;
			int i = 0;
			bool flag = chestValueList != null && chestValueList.Count > 0;
			if (flag)
			{
				while (i < chestValueList.Count - 1)
				{
					bool flag2 = weeklyScore >= chestValueList[i] && !XGuildWeeklyBountyDocument.Doc.RewardedBoxList.Contains(chestValueList[i]);
					if (flag2)
					{
						break;
					}
					bool flag3 = weeklyScore < chestValueList[i];
					if (flag3)
					{
						break;
					}
					i++;
				}
			}
			bool flag4 = i >= chestValueList.Count;
			if (flag4)
			{
				i = chestValueList.Count - 1;
			}
			this.UpdateChestItem(base.uiBehaviour.ChestX.gameObject, i);
			base.uiBehaviour.CurrentValueLabel.SetText(XStringDefineProxy.GetString("WeeklyTaskTotalScore") + XGuildWeeklyBountyDocument.Doc.WeeklyScore);
		}

		// Token: 0x0600A10E RID: 41230 RVA: 0x001B1990 File Offset: 0x001AFB90
		private void InitProperties()
		{
			base.uiBehaviour.RefreshBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshTasks));
			base.uiBehaviour.GetBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetTaskItem));
			base.uiBehaviour.HelpBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAskWeeklyHelp));
			base.uiBehaviour.CommitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSummitTaskItem));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseView));
			base.uiBehaviour.MailRoot.gameObject.SetActive(true);
			base.uiBehaviour.MailWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnMailWrapContentInit));
			base.uiBehaviour.MailWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnMailWrapContentUpdate));
			base.uiBehaviour.MailCloseSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseMailView));
			base.uiBehaviour.SendGrateFulBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickSendGrateFulBtn));
			base.uiBehaviour.AboutBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowCommonHelpView));
			this._refreshTaskEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_xuanshang_Clip01", null, true);
			this._refreshTaskEffect.SetActive(false);
			this._completedTaskEffect = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/UIfx/UI_wanchengxuanshang_Clip01", null, true);
			this._completedTaskEffect.SetActive(false);
			base.uiBehaviour.GetBtn.gameObject.SetActive(false);
		}

		// Token: 0x0600A10F RID: 41231 RVA: 0x001B1B38 File Offset: 0x001AFD38
		private bool OnShowCommonHelpView(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildWeeklyBountyTask);
			return true;
		}

		// Token: 0x0600A110 RID: 41232 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void OnMailWrapContentInit(Transform itemTransform, int index)
		{
		}

		// Token: 0x0600A111 RID: 41233 RVA: 0x001B1B5C File Offset: 0x001AFD5C
		private bool OnSelectMailInfoItem(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this._curSelectMailIndex = (int)iXUICheckBox.ID;
				base.uiBehaviour.SendGrateFulBtn.SetEnable(!this._hasSendedIndex.Contains(this._curSelectMailIndex), false);
			}
			return true;
		}

		// Token: 0x0600A112 RID: 41234 RVA: 0x001B1BB0 File Offset: 0x001AFDB0
		private bool OnClickSendGrateFulBtn(IXUIButton button)
		{
			List<TaskHelpInfo> taskHelpInfoList = XGuildWeeklyBountyDocument.Doc.TaskHelpInfoList;
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = !specificDocument.CheckInGuild();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XInvitationDocument specificDocument2 = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
				NoticeTable.RowData noticeData = specificDocument2.GetNoticeData(NoticeType.NT_GUILD_Weekly_Help_Thanks_REQ);
				bool flag2 = noticeData == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					List<ChatParam> list = new List<ChatParam>();
					ChatParam chatParam = new ChatParam();
					chatParam.link = new ChatParamLink();
					ChatParam chatParam2 = new ChatParam();
					chatParam2.role = new ChatParamRole();
					chatParam2.role.uniqueid = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					chatParam2.role.name = XSingleton<XAttributeMgr>.singleton.XPlayerData.Name;
					chatParam2.role.profession = XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID;
					string text = "";
					List<string> list2 = new List<string>();
					for (int i = 0; i < taskHelpInfoList.Count; i++)
					{
						bool flag3 = !list2.Contains(taskHelpInfoList[i].rolename);
						if (flag3)
						{
							list2.Add(taskHelpInfoList[i].rolename);
							text = text + taskHelpInfoList[i].rolename + " ";
						}
					}
					ChatParam chatParam3 = new ChatParam();
					chatParam3.role = new ChatParamRole();
					chatParam3.role.uniqueid = 0UL;
					chatParam3.role.name = text;
					chatParam3.role.profession = 0U;
					list.Add(chatParam2);
					list.Add(chatParam3);
					list.Add(chatParam);
					DlgBase<XChatView, XChatBehaviour>.singleton.SendChatContent(noticeData.info, (ChatChannelType)noticeData.channel, true, list, true, 0UL, 0f, false, false);
					this._hasSendedIndex.Add(this._curSelectMailIndex);
					this.OnCloseMailView(null);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600A113 RID: 41235 RVA: 0x001B1DB4 File Offset: 0x001AFFB4
		private void OnCloseMailView(IXUISprite uiSprite)
		{
			base.uiBehaviour.MailRoot.gameObject.SetActive(false);
			List<TaskHelpInfo> taskHelpInfoList = XGuildWeeklyBountyDocument.Doc.TaskHelpInfoList;
			taskHelpInfoList.Clear();
			this._hasSendedIndex.Clear();
		}

		// Token: 0x0600A114 RID: 41236 RVA: 0x001B1DF8 File Offset: 0x001AFFF8
		private bool OnCloseView(IXUIButton button)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600A115 RID: 41237 RVA: 0x001B1E14 File Offset: 0x001B0014
		private void SetOpBtnState(GuildWeeklyTaskInfo selectTaskinfo, DailyTask.RowData taskInfo)
		{
			bool flag = taskInfo.tasktype == 1U || taskInfo.tasktype == 4U;
			base.uiBehaviour.CommitBtn.SetEnable(!selectTaskinfo.isRewarded, false);
			bool isRewarded = selectTaskinfo.isRewarded;
			string @string;
			if (isRewarded)
			{
				@string = XStringDefineProxy.GetString("WeeklyAreadyCommitted");
			}
			else
			{
				bool flag2 = selectTaskinfo.step >= taskInfo.conditionNum;
				if (flag2)
				{
					@string = XStringDefineProxy.GetString("WeeklyToCommit");
				}
				else
				{
					bool flag3 = flag;
					if (flag3)
					{
						bool flag4 = taskInfo.tasktype == 1U;
						ulong num;
						if (flag4)
						{
							num = XBagDocument.BagDoc.GetItemCount((int)taskInfo.conditionId[0]);
						}
						else
						{
							ItemType itemType = (ItemType)(taskInfo.conditionId[0] / 100U);
							ItemQuality quality = (ItemQuality)(taskInfo.conditionId[0] % 100U);
							num = (ulong)((long)XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)itemType, quality).Count);
						}
						bool flag5 = num <= 0UL;
						if (flag5)
						{
							@string = XSingleton<XStringTable>.singleton.GetString("GotoObtain");
						}
						else
						{
							@string = XStringDefineProxy.GetString("WeeklyCommitItem");
						}
					}
					else
					{
						@string = XSingleton<XStringTable>.singleton.GetString("PVPActivity_Go");
					}
				}
			}
			base.uiBehaviour.CommitLabel.SetText(@string);
			base.uiBehaviour.CommitBtnRedpoint.SetActive(!selectTaskinfo.isRewarded && selectTaskinfo.step >= taskInfo.conditionNum);
		}

		// Token: 0x0600A116 RID: 41238 RVA: 0x001B1F94 File Offset: 0x001B0194
		private bool OnSummitTaskItem(IXUIButton button)
		{
			bool flag = this._curSelectIndex >= 0U;
			if (flag)
			{
				GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID((taskInfoByIndex == null) ? 0U : taskInfoByIndex.taskID);
				bool flag2 = dailyTaskTableInfoByID != null;
				if (flag2)
				{
					bool flag3 = taskInfoByIndex.step >= dailyTaskTableInfoByID.conditionNum;
					if (flag3)
					{
						XGuildWeeklyBountyDocument.Doc.SendToGetWeeklyTaskReward(1U, this._curSelectIndex);
					}
					else
					{
						bool flag4 = dailyTaskTableInfoByID.tasktype == 1U || dailyTaskTableInfoByID.tasktype == 4U;
						bool flag5 = flag4;
						if (flag5)
						{
							bool flag6 = dailyTaskTableInfoByID.tasktype == 1U;
							ulong num;
							if (flag6)
							{
								num = XBagDocument.BagDoc.GetItemCount((int)dailyTaskTableInfoByID.conditionId[0]);
							}
							else
							{
								ItemType itemType = (ItemType)(dailyTaskTableInfoByID.conditionId[0] / 100U);
								ItemQuality quality = (ItemQuality)(dailyTaskTableInfoByID.conditionId[0] % 100U);
								num = (ulong)((long)XBagDocument.BagDoc.GetItemsByTypeAndQuality(1UL << (int)itemType, quality).Count);
							}
							bool flag7 = num == 0UL;
							if (flag7)
							{
								this.OnGetTaskItem(null);
							}
							else
							{
								bool flag8 = dailyTaskTableInfoByID.tasktype == 4U;
								if (flag8)
								{
									ItemType type = (ItemType)(dailyTaskTableInfoByID.conditionId[0] / 100U);
									ItemQuality quality2 = (ItemQuality)(dailyTaskTableInfoByID.conditionId[0] % 100U);
									DlgBase<XShowSameQualityItemsView, XShowSameQualityItemsBehavior>.singleton.ShowView(new XShowSameQualityItemsView.SelectItemsHandler(this.OnSelectQualityItem), type, quality2, XStringDefineProxy.GetString("WeelyCommitTip"), (int)dailyTaskTableInfoByID.conditionNum, (int)taskInfoByIndex.step);
								}
								else
								{
									ItemList.RowData itemConf = XBagDocument.GetItemConf((int)dailyTaskTableInfoByID.conditionId[0]);
									bool flag9 = itemConf != null;
									if (flag9)
									{
										bool flag10 = itemConf.OverCnt == 1;
										if (flag10)
										{
											List<XItem> itemList;
											XBagDocument.BagDoc.GetItemByItemId((int)dailyTaskTableInfoByID.conditionId[0], out itemList);
											DlgBase<XShowSameQualityItemsView, XShowSameQualityItemsBehavior>.singleton.ShowView(new XShowSameQualityItemsView.SelectItemsHandler(this.OnSelectQualityItem), itemList, XStringDefineProxy.GetString("WeelyCommitTip"), (int)dailyTaskTableInfoByID.conditionNum, (int)taskInfoByIndex.step);
										}
										else
										{
											int num2 = (int)XBagDocument.BagDoc.GetItemCount((int)dailyTaskTableInfoByID.conditionId[0]);
											XSingleton<UiUtility>.singleton.ShowSettingNumberDialog(dailyTaskTableInfoByID.conditionId[0], XSingleton<XStringTable>.singleton.GetString("WeeklyCommitItem"), 1U, (uint)Mathf.Min((float)num2, dailyTaskTableInfoByID.conditionNum - taskInfoByIndex.step), 1U, new ModalSettingNumberDlg.GetInputNumber(this.onSummitItemID), 50);
										}
									}
								}
							}
						}
						else
						{
							this.OnGetTaskItem(null);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600A117 RID: 41239 RVA: 0x001B2210 File Offset: 0x001B0410
		private void onSummitItemID(uint number)
		{
			bool flag = this._curSelectIndex >= 0U;
			if (flag)
			{
				GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID((taskInfoByIndex == null) ? 0U : taskInfoByIndex.taskID);
				bool flag2 = dailyTaskTableInfoByID != null;
				if (flag2)
				{
					List<ulong> list = new List<ulong>();
					List<XItem> list2 = new List<XItem>();
					bool itemByItemId = XBagDocument.BagDoc.GetItemByItemId((int)dailyTaskTableInfoByID.conditionId[0], out list2);
					if (itemByItemId)
					{
						int num = Mathf.Min((int)number, list2.Count);
						for (int i = 0; i < num; i++)
						{
							list.Add(list2[i].uid);
						}
						XGuildWeeklyBountyDocument.Doc.SendCommitWeeklyItem(this._curSelectIndex, list);
					}
				}
			}
		}

		// Token: 0x0600A118 RID: 41240 RVA: 0x001B22E0 File Offset: 0x001B04E0
		private void OnSelectQualityItem(List<ulong> itemList)
		{
			bool flag = itemList.Count > 0;
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.SendCommitWeeklyItem(this._curSelectIndex, itemList);
			}
		}

		// Token: 0x0600A119 RID: 41241 RVA: 0x001B2310 File Offset: 0x001B0510
		private bool OnAskWeeklyHelp(IXUIButton button)
		{
			uint taskID = (uint)button.ID;
			XGuildDailyTaskDocument.Doc.SendDailyTaskAskHelp(PeriodTaskType.PeriodTaskType_Weekly, taskID);
			return true;
		}

		// Token: 0x0600A11A RID: 41242 RVA: 0x001B2338 File Offset: 0x001B0538
		private bool OnGetTaskItem(IXUIButton button)
		{
			GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
			DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID((taskInfoByIndex == null) ? 0U : taskInfoByIndex.taskID);
			bool flag = dailyTaskTableInfoByID == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = dailyTaskTableInfoByID.tasktype == 1U;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowItemAccess((int)dailyTaskTableInfoByID.conditionId[0], null);
				}
				else
				{
					bool flag3 = dailyTaskTableInfoByID.tasktype == 4U;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowItemAccess((int)dailyTaskTableInfoByID.BQ[0, 0], null);
					}
					else
					{
						bool flag4 = dailyTaskTableInfoByID.tasktype == 3U;
						if (flag4)
						{
							List<int> list = new List<int>();
							List<int> list2 = new List<int>();
							for (int i = 0; i < dailyTaskTableInfoByID.BQ.Count; i++)
							{
								list.Add((int)dailyTaskTableInfoByID.BQ[i, 0]);
								list2.Add((int)dailyTaskTableInfoByID.BQ[i, 1]);
							}
							DlgBase<ItemAccessDlg, ItemAccessDlgBehaviour>.singleton.ShowMonsterAccess(dailyTaskTableInfoByID.NPCID, list, list2, null);
						}
						else
						{
							XSingleton<XGameSysMgr>.singleton.OpenSystem((int)dailyTaskTableInfoByID.BQ[0, 0]);
						}
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A11B RID: 41243 RVA: 0x001B247C File Offset: 0x001B067C
		private bool OnRefreshTasks(IXUIButton button)
		{
			uint num = (uint)button.ID;
			GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
			bool flag = taskInfoByIndex != null;
			if (flag)
			{
				bool flag2 = taskInfoByIndex.step > 0U;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("DailyTaskStepProgressing"), new ButtonClickEventHandler(this.ConfirmToRefresh));
				}
				else
				{
					this.ToRefreshTask();
				}
			}
			return true;
		}

		// Token: 0x0600A11C RID: 41244 RVA: 0x001B24F0 File Offset: 0x001B06F0
		private bool ConfirmToRefresh(IXUIButton button)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this.ToRefreshTask();
			return true;
		}

		// Token: 0x0600A11D RID: 41245 RVA: 0x001B2518 File Offset: 0x001B0718
		private void ToRefreshTask()
		{
			GuildWeeklyTaskInfo taskInfoByIndex = XGuildWeeklyBountyDocument.Doc.GetTaskInfoByIndex(this._curSelectIndex);
			bool flag = taskInfoByIndex == null;
			if (!flag)
			{
				int num = 0;
				bool flag2 = XGuildWeeklyBountyDocument.Doc.RemainedFreshTimes == 0U;
				if (flag2)
				{
					int refreshedCount = (int)taskInfoByIndex.refreshedCount;
					List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("WeeklyTaskRefreshCost");
					num = intList[Mathf.Min(refreshedCount, intList.Count - 1)];
				}
				ulong virtualItemCount = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
				bool flag3 = (ulong)num <= virtualItemCount;
				if (flag3)
				{
					XGuildWeeklyBountyDocument.Doc.SendToRefreshTaskList(this._curSelectIndex);
				}
				else
				{
					DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ShowBorad(7);
				}
			}
		}

		// Token: 0x0600A11E RID: 41246 RVA: 0x001B25CC File Offset: 0x001B07CC
		private void UpdateChestItem(GameObject chestItem, int index)
		{
			List<uint> chestValueList = XGuildWeeklyBountyDocument.Doc.ChestValueList;
			bool flag = index >= 0 && index < chestValueList.Count;
			if (flag)
			{
				uint num = chestValueList[index];
				IXUILabel ixuilabel = chestItem.transform.Find("Exp").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = chestItem.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)num;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickedChestBox));
				Transform transform = chestItem.transform.Find("RedPoint");
				bool flag2 = num <= XGuildWeeklyBountyDocument.Doc.WeeklyScore;
				ixuisprite.SetEnabled(true);
				SeqList<string> stringSeqList = XSingleton<XGlobalConfig>.singleton.GetStringSeqList("RewardBoxArr");
				bool flag3 = XGuildWeeklyBountyDocument.Doc.RewardedBoxList.Contains(num);
				if (flag3)
				{
					bool flag4 = index == chestValueList.Count - 1;
					if (flag4)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("CompleteBounty"));
					}
					transform.gameObject.SetActive(false);
					ixuisprite.SetSprite(stringSeqList[Mathf.Min(index, (int)(stringSeqList.Count - 1)), 1]);
				}
				else
				{
					bool flag5 = flag2;
					if (flag5)
					{
						ixuilabel.SetText(XStringDefineProxy.GetString("ClickToGetBounty"));
					}
					else
					{
						ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("BountyValueToGet"), num.ToString()));
					}
					string sprite = stringSeqList[Mathf.Min(index, (int)(stringSeqList.Count - 1)), 0];
					ixuisprite.SetSprite(sprite);
					transform.gameObject.SetActive(flag2);
				}
			}
		}

		// Token: 0x0600A11F RID: 41247 RVA: 0x001B276C File Offset: 0x001B096C
		private void OnClickedChestBox(IXUISprite uiSprite)
		{
			uint num = (uint)uiSprite.ID;
			bool flag = XGuildWeeklyBountyDocument.Doc.WeeklyScore >= num && !XGuildWeeklyBountyDocument.Doc.RewardedBoxList.Contains(num);
			if (flag)
			{
				XGuildWeeklyBountyDocument.Doc.SendToGetWeeklyTaskReward(2U, num);
			}
			else
			{
				List<GuildTaskReward> totalTaskRewardInfo = XGuildWeeklyBountyDocument.Doc.GetTotalTaskRewardInfo(GuildTaskType.WeeklyTask, num);
				List<uint> list = new List<uint>();
				List<uint> list2 = new List<uint>();
				for (int i = 0; i < totalTaskRewardInfo.Count; i++)
				{
					list.Add(totalTaskRewardInfo[i].itemID);
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					bool flag2 = totalTaskRewardInfo[i].itemID == 4U && specificDocument.IsInLevelSeal();
					uint item;
					if (flag2)
					{
						item = (uint)(totalTaskRewardInfo[i].count * 0.5);
					}
					else
					{
						item = totalTaskRewardInfo[i].count;
					}
					list2.Add(item);
				}
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.Show(list, list2, false);
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.SetGlobalPosition(uiSprite.gameObject.transform.position);
			}
		}

		// Token: 0x0600A120 RID: 41248 RVA: 0x001B28A0 File Offset: 0x001B0AA0
		public void RefreshTaskList(bool init = true)
		{
			List<GuildWeeklyTaskInfo> curGuildWeeklyTaskList = XGuildWeeklyBountyDocument.Doc.CurGuildWeeklyTaskList;
			base.uiBehaviour.BountyItemPool.ReturnAll(false);
			this._selectCheck = null;
			for (int i = 0; i < curGuildWeeklyTaskList.Count; i++)
			{
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(curGuildWeeklyTaskList[i].taskID);
				bool flag = dailyTaskTableInfoByID != null;
				if (flag)
				{
					GameObject gameObject = base.uiBehaviour.BountyItemPool.FetchGameObject(false);
					int num = i;
					int num2 = 0;
					gameObject.transform.localPosition = base.uiBehaviour.BountyItemPool.TplPos + (float)(num * base.uiBehaviour.BountyItemPool.TplWidth) * Vector3.right + (float)(num2 * (base.uiBehaviour.BountyItemPool.TplHeight + 10)) * Vector3.down;
					IXUICheckBox ixuicheckBox = gameObject.GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.ID = (ulong)curGuildWeeklyTaskList[i].originIndex;
					ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSelectBountyItem));
					bool flag2 = this._curSelectIndex == curGuildWeeklyTaskList[i].originIndex;
					ixuicheckBox.ForceSetFlag(false);
					if (init)
					{
						bool flag3 = i == 0;
						if (flag3)
						{
							this._selectCheck = ixuicheckBox;
						}
					}
					else
					{
						bool flag4 = flag2;
						if (flag4)
						{
							this._selectCheck = ixuicheckBox;
						}
					}
					IXUILabel ixuilabel = gameObject.transform.Find("Num").GetComponent("XUILabel") as IXUILabel;
					string text = curGuildWeeklyTaskList[i].step + "/" + dailyTaskTableInfoByID.conditionNum;
					ixuilabel.SetText(text);
					IXUISprite ixuisprite = gameObject.transform.Find("Quality").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite2 = gameObject.transform.Find("Icon/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + dailyTaskTableInfoByID.taskquality);
					ixuisprite2.SetSprite(dailyTaskTableInfoByID.TaskIcon, dailyTaskTableInfoByID.AtlasName, false);
					GameObject gameObject2 = gameObject.transform.Find("RedPoint").gameObject;
					gameObject2.SetActive(curGuildWeeklyTaskList[i].step >= dailyTaskTableInfoByID.conditionNum && !curGuildWeeklyTaskList[i].isRewarded);
					Transform transform = gameObject.transform.Find("Complete");
					transform.gameObject.SetActive(curGuildWeeklyTaskList[i].isRewarded);
					IXUIProgress ixuiprogress = gameObject.transform.Find("TaskProgress").GetComponent("XUIProgress") as IXUIProgress;
					ixuiprogress.value = curGuildWeeklyTaskList[i].step / dailyTaskTableInfoByID.conditionNum;
				}
			}
			bool flag5 = this._selectCheck != null;
			if (flag5)
			{
				bool bChecked = this._selectCheck.bChecked;
				if (bChecked)
				{
					this.OnSelectBountyItem(this._selectCheck);
				}
				else
				{
					this._selectCheck.bChecked = true;
				}
			}
			if (init)
			{
				base.uiBehaviour.BountyListScrollView.ResetPosition();
			}
		}

		// Token: 0x0600A121 RID: 41249 RVA: 0x001B2C08 File Offset: 0x001B0E08
		private bool OnSelectBountyItem(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				uint curSelectIndex = (uint)iXUICheckBox.ID;
				this._curSelectIndex = curSelectIndex;
				this.RefreshTaskItem();
			}
			return true;
		}

		// Token: 0x0600A122 RID: 41250 RVA: 0x001B2C40 File Offset: 0x001B0E40
		private void RefreshMailInfo()
		{
			List<TaskHelpInfo> taskHelpInfoList = XGuildWeeklyBountyDocument.Doc.TaskHelpInfoList;
			bool flag = taskHelpInfoList.Count > 0;
			if (flag)
			{
				base.uiBehaviour.MailRoot.gameObject.SetActive(true);
				base.uiBehaviour.MailWrapContent.SetContentCount(taskHelpInfoList.Count, false);
				base.uiBehaviour.MailScrollView.ResetPosition();
			}
			else
			{
				base.uiBehaviour.MailRoot.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600A123 RID: 41251 RVA: 0x001B2CC4 File Offset: 0x001B0EC4
		private void OnMailWrapContentUpdate(Transform itemTransform, int index)
		{
			List<TaskHelpInfo> taskHelpInfoList = XGuildWeeklyBountyDocument.Doc.TaskHelpInfoList;
			bool flag = index < taskHelpInfoList.Count;
			if (flag)
			{
				TaskHelpInfo taskHelpInfo = taskHelpInfoList[index];
				IXUILabel ixuilabel = itemTransform.Find("Tip").GetComponent("XUILabel") as IXUILabel;
				string rolename = taskHelpInfo.rolename;
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)taskHelpInfo.itemid);
				string text = "   ";
				bool flag2 = itemConf != null;
				if (flag2)
				{
					text += itemConf.ItemName[0];
				}
				ixuilabel.SetText(string.Format(XStringDefineProxy.GetString("weelyHelpItemTip"), rolename, taskHelpInfo.itemcount, text));
				IXUILabel ixuilabel2 = itemTransform.Find("Time").GetComponent("XUILabel") as IXUILabel;
				string text2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(taskHelpInfo.time).ToLocalTime().ToString("yyyy-MM-dd H:mm");
				ixuilabel2.SetText(text2);
			}
		}

		// Token: 0x040039E8 RID: 14824
		private const int colNum = 4;

		// Token: 0x040039E9 RID: 14825
		private uint _curSelectIndex = 0U;

		// Token: 0x040039EA RID: 14826
		private IXUICheckBox _selectCheck;

		// Token: 0x040039EB RID: 14827
		private List<int> _hasSendedIndex = new List<int>();

		// Token: 0x040039EC RID: 14828
		private int _curSelectMailIndex = 0;

		// Token: 0x040039ED RID: 14829
		private XFx _refreshTaskEffect;

		// Token: 0x040039EE RID: 14830
		private XFx _completedTaskEffect;
	}
}
