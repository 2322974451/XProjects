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
	// Token: 0x02000C05 RID: 3077
	internal class XGuildDailyTaskView : DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>
	{
		// Token: 0x170030DA RID: 12506
		// (get) Token: 0x0600AED9 RID: 44761 RVA: 0x0020F540 File Offset: 0x0020D740
		public override string fileName
		{
			get
			{
				return "Guild/GuildDailyTask";
			}
		}

		// Token: 0x170030DB RID: 12507
		// (get) Token: 0x0600AEDA RID: 44762 RVA: 0x0020F558 File Offset: 0x0020D758
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030DC RID: 12508
		// (get) Token: 0x0600AEDB RID: 44763 RVA: 0x0020F56C File Offset: 0x0020D76C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030DD RID: 12509
		// (get) Token: 0x0600AEDC RID: 44764 RVA: 0x0020F580 File Offset: 0x0020D780
		public override int sysid
		{
			get
			{
				return 886;
			}
		}

		// Token: 0x0600AEDD RID: 44765 RVA: 0x0020F597 File Offset: 0x0020D797
		protected override void OnLoad()
		{
			base.OnLoad();
		}

		// Token: 0x0600AEDE RID: 44766 RVA: 0x0020F5A1 File Offset: 0x0020D7A1
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600AEDF RID: 44767 RVA: 0x0020F5AB File Offset: 0x0020D7AB
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600AEE0 RID: 44768 RVA: 0x0020F5B5 File Offset: 0x0020D7B5
		protected override void Init()
		{
			base.Init();
			this.InitProperties();
		}

		// Token: 0x0600AEE1 RID: 44769 RVA: 0x0020F5C6 File Offset: 0x0020D7C6
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600AEE2 RID: 44770 RVA: 0x0020F5D0 File Offset: 0x0020D7D0
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.RefreshRecordRoot.gameObject.SetActive(false);
			this._curTabedTaskID = 0U;
			this.selectedDefault = false;
			XGuildDailyTaskDocument.Doc.SendGetDailyTaskInfo();
			XGuildDailyTaskDocument.Doc.SendToGetRefreshLogInfo();
		}

		// Token: 0x0600AEE3 RID: 44771 RVA: 0x0020F620 File Offset: 0x0020D820
		public override void StackRefresh()
		{
			base.StackRefresh();
			XGuildDailyTaskDocument.Doc.SendGetDailyTaskInfo();
		}

		// Token: 0x0600AEE4 RID: 44772 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void Refresh()
		{
		}

		// Token: 0x0600AEE5 RID: 44773 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public void RefreshGuildDailyContent()
		{
		}

		// Token: 0x0600AEE6 RID: 44774 RVA: 0x0020F638 File Offset: 0x0020D838
		private void InitProperties()
		{
			base.uiBehaviour.RefreshRecordRoot.gameObject.SetActive(true);
			base.uiBehaviour.SubmmitBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickSubmmitBtn));
			base.uiBehaviour.CloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.Onclose));
			this._taskContent = base.uiBehaviour.TaskContent;
			this._taskContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this.InitTaskItem));
			this._taskContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UpdateTaskItem));
			base.uiBehaviour.RefreshTaskBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRefreshBtn));
			base.uiBehaviour.RefreshLogBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickRefreshLogBtn));
			base.uiBehaviour.RefreshCloseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseRefreshLogView));
			base.uiBehaviour.RefreshLogWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnUpdateRefreshLogItem));
			base.uiBehaviour.TipButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowInstruction));
		}

		// Token: 0x0600AEE7 RID: 44775 RVA: 0x0020F76C File Offset: 0x0020D96C
		private bool OnShowInstruction(IXUIButton button)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_GuildDailyTask);
			return true;
		}

		// Token: 0x0600AEE8 RID: 44776 RVA: 0x0020F790 File Offset: 0x0020D990
		private void OnUpdateRefreshLogItem(Transform itemTransform, int index)
		{
			DailyTaskRefreshInfo refreshTaskLogInfo = XGuildDailyTaskDocument.Doc.GetRefreshTaskLogInfo(index);
			bool flag = refreshTaskLogInfo != null;
			if (flag)
			{
				IXUILabel ixuilabel = itemTransform.Find("Content").GetComponent("XUILabel") as IXUILabel;
				string text = (refreshTaskLogInfo.roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) ? XStringDefineProxy.GetString("GuildDailySelfFreshTask") : string.Format(XStringDefineProxy.GetString("GuildDailyFriendFreshTask", new object[]
				{
					refreshTaskLogInfo.name
				}), new object[0]);
				ixuilabel.SetText(text);
				IXUISprite ixuisprite = itemTransform.Find("TaskLevel").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(ixuisprite.spriteName.Substring(0, ixuisprite.spriteName.Length - 1) + refreshTaskLogInfo.score);
				IXUISprite ixuisprite2 = itemTransform.Find("BeforeTaskLevel").GetComponent("XUISprite") as IXUISprite;
				ixuisprite2.SetSprite(ixuisprite2.spriteName.Substring(0, ixuisprite2.spriteName.Length - 1) + refreshTaskLogInfo.old_score);
				IXUISprite ixuisprite3 = itemTransform.Find("New").GetComponent("XUISprite") as IXUISprite;
				ixuisprite3.gameObject.SetActive(refreshTaskLogInfo.isnew);
				string text2 = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(refreshTaskLogInfo.time).ToLocalTime().ToString("yyyy-MM-dd H:mm");
				IXUILabel ixuilabel2 = itemTransform.Find("Time").GetComponent("XUILabel") as IXUILabel;
				ixuilabel2.SetText(text2);
				IXUISprite ixuisprite4 = itemTransform.Find("Bg").GetComponent("XUISprite") as IXUISprite;
				ixuisprite4.ID = refreshTaskLogInfo.roleid;
				ixuisprite4.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickToShowRoleDetail));
			}
		}

		// Token: 0x0600AEE9 RID: 44777 RVA: 0x0020F98C File Offset: 0x0020DB8C
		private void OnClickToShowRoleDetail(IXUISprite uiSprite)
		{
			bool flag = uiSprite.ID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(uiSprite.ID, false);
			}
		}

		// Token: 0x0600AEEA RID: 44778 RVA: 0x0020F9C8 File Offset: 0x0020DBC8
		private bool OnCloseRefreshLogView(IXUIButton button)
		{
			XGuildDailyTaskDocument.Doc.DailyTaskBeenRefreshIcon = false;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildDailyTask, true);
			base.uiBehaviour.RefreshRecordRoot.gameObject.SetActive(false);
			return true;
		}

		// Token: 0x0600AEEB RID: 44779 RVA: 0x0020FA10 File Offset: 0x0020DC10
		private bool OnClickRefreshLogBtn(IXUIButton button)
		{
			this.RefreshLogContent();
			return true;
		}

		// Token: 0x0600AEEC RID: 44780 RVA: 0x0020FA2C File Offset: 0x0020DC2C
		private bool OnClickRefreshBtn(IXUIButton button)
		{
			DlgBase<XGuildDailyRefreshTaskDlg, XGuildDailyRefreshTaskBehavior>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x0600AEED RID: 44781 RVA: 0x0020FA4C File Offset: 0x0020DC4C
		private bool Onclose(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600AEEE RID: 44782 RVA: 0x0020FA68 File Offset: 0x0020DC68
		private bool OnclickSubmmitBtn(IXUIButton button)
		{
			int rewardedTaskCount = XGuildDailyTaskDocument.Doc.GetRewardedTaskCount();
			bool flag = rewardedTaskCount >= XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMinTotalTaskCount");
			if (flag)
			{
				bool flag2 = rewardedTaskCount < XGuildDailyTaskDocument.Doc.GetTaskItemCount();
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowModalDialog(XSingleton<XStringTable>.singleton.GetString("ConfirmToSumbmit"), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this.OnConfirmToSubmit));
				}
				else
				{
					XGuildDailyTaskDocument.Doc.SendToGetMyTaskReward(2U, 0U);
				}
			}
			return true;
		}

		// Token: 0x0600AEEF RID: 44783 RVA: 0x0020FAF8 File Offset: 0x0020DCF8
		private bool OnConfirmToSubmit(IXUIButton button)
		{
			XGuildDailyTaskDocument.Doc.SendToGetMyTaskReward(2U, 0U);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AEF0 RID: 44784 RVA: 0x0020FB28 File Offset: 0x0020DD28
		private bool OnCacelTask(IXUIButton button)
		{
			XGuildDailyTaskDocument.Doc.GiveUpTask();
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AEF1 RID: 44785 RVA: 0x0020FB54 File Offset: 0x0020DD54
		private bool OnclickReqHelpBtn(IXUIButton button)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool bInGuild = specificDocument.bInGuild;
			if (bInGuild)
			{
				XGuildDailyTaskDocument.Doc.SendDailyTaskAskHelp(PeriodTaskType.PeriodTaskType_Daily, (uint)button.ID);
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("NotInGuild"), "fece00");
			}
			return true;
		}

		// Token: 0x0600AEF2 RID: 44786 RVA: 0x0020FBB4 File Offset: 0x0020DDB4
		private bool OnclickCompleteBtn(IXUIButton button)
		{
			GuildDailyTaskInfo taskInfoByID = XGuildDailyTaskDocument.Doc.GetTaskInfoByID((uint)button.ID);
			bool flag = taskInfoByID != null;
			if (flag)
			{
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(taskInfoByID.taskID);
				bool flag2 = dailyTaskTableInfoByID != null;
				if (flag2)
				{
					bool flag3 = taskInfoByID.step >= dailyTaskTableInfoByID.conditionNum;
					if (flag3)
					{
						XGuildDailyTaskDocument.Doc.SendToGetMyTaskReward(1U, (uint)button.ID);
					}
					else
					{
						bool flag4 = dailyTaskTableInfoByID.tasktype == 1U;
						if (flag4)
						{
							XSingleton<UiUtility>.singleton.ShowItemAccess((int)dailyTaskTableInfoByID.conditionId[0], null);
						}
						else
						{
							this.ItemAccessByID(taskInfoByID.taskID);
						}
					}
				}
			}
			return true;
		}

		// Token: 0x0600AEF3 RID: 44787 RVA: 0x0020FC64 File Offset: 0x0020DE64
		private void InitTaskItem(Transform itemTransform, int index)
		{
			IXUICheckBox ixuicheckBox = itemTransform.Find("Normal").GetComponent("XUICheckBox") as IXUICheckBox;
			ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.OnSwitchTaskItem));
			IXUISprite ixuisprite = itemTransform.Find("Item/Icon").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnclickIcon));
			IXUIButton ixuibutton = itemTransform.Find("GetBtn").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickCompleteBtn));
			IXUIButton ixuibutton2 = itemTransform.Find("ReqHelp").GetComponent("XUIButton") as IXUIButton;
			ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnclickReqHelpBtn));
			IXUISprite ixuisprite2 = itemTransform.Find("boss").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnclickBossIcon));
		}

		// Token: 0x0600AEF4 RID: 44788 RVA: 0x0020FD5A File Offset: 0x0020DF5A
		private void OnclickBossIcon(IXUISprite uiSprite)
		{
			this.ItemAccessByID((uint)uiSprite.ID);
		}

		// Token: 0x0600AEF5 RID: 44789 RVA: 0x0020FD6C File Offset: 0x0020DF6C
		private void ItemAccessByID(uint taskID)
		{
			DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(taskID);
			bool flag = dailyTaskTableInfoByID == null;
			if (!flag)
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
		}

		// Token: 0x0600AEF6 RID: 44790 RVA: 0x001AE886 File Offset: 0x001ACA86
		private void OnclickIcon(IXUISprite uiSprite)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)uiSprite.ID, null);
		}

		// Token: 0x0600AEF7 RID: 44791 RVA: 0x0020FDFC File Offset: 0x0020DFFC
		private bool OnSwitchTaskItem(IXUICheckBox iXUICheckBox)
		{
			bool bChecked = iXUICheckBox.bChecked;
			if (bChecked)
			{
				this._curTabedTaskID = (uint)iXUICheckBox.ID;
			}
			return true;
		}

		// Token: 0x0600AEF8 RID: 44792 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void UpdateRightPanel(ulong taskID)
		{
		}

		// Token: 0x0600AEF9 RID: 44793 RVA: 0x0020FE28 File Offset: 0x0020E028
		private void UpdateTotalTaskRewards()
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			base.uiBehaviour.RewardPool.ReturnAll(false);
			int rewardedTaskCount = XGuildDailyTaskDocument.Doc.GetRewardedTaskCount();
			int count = Math.Min(Math.Max(XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMinTotalTaskCount"), rewardedTaskCount + 1), XGuildDailyTaskDocument.Doc.GetTaskItemCount());
			DailyTaskReward.RowData totalTaskRewardInfo = XGuildDailyTaskDocument.Doc.GetTotalTaskRewardInfo(GuildTaskType.DailyTask, (uint)count);
			bool flag = totalTaskRewardInfo != null;
			if (flag)
			{
				SeqListRef<uint>? rewadsByScore = XGuildDailyTaskDocument.Doc.GetRewadsByScore(totalTaskRewardInfo, XGuildDailyTaskDocument.Doc.CurScore);
				bool flag2 = rewadsByScore != null;
				if (flag2)
				{
					for (int i = 0; i < (int)rewadsByScore.Value.count; i++)
					{
						GameObject gameObject = base.uiBehaviour.RewardPool.FetchGameObject(false);
						int num = (int)rewadsByScore.Value[i, 1];
						bool flag3 = rewadsByScore.Value[i, 0] == 4U && specificDocument.IsInLevelSeal();
						if (flag3)
						{
							num = (int)((double)num * 0.5);
						}
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)rewadsByScore.Value[i, 0], num, false);
						IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)rewadsByScore.Value[i, 0];
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject.transform.parent = base.uiBehaviour.CurrentRewardsGrid;
					}
					IXUIList ixuilist = base.uiBehaviour.CurrentRewardsGrid.GetComponent("XUIList") as IXUIList;
					ixuilist.Refresh();
				}
			}
			List<GuildTaskReward> additionalRewards = XGuildDailyTaskDocument.Doc.GetAdditionalRewards();
			bool flag4 = additionalRewards != null;
			if (flag4)
			{
				for (int j = 0; j < additionalRewards.Count; j++)
				{
					GameObject gameObject2 = base.uiBehaviour.RewardPool.FetchGameObject(false);
					int num2 = (int)additionalRewards[j].count;
					bool flag5 = additionalRewards[j].itemID == 4U && specificDocument.IsInLevelSeal();
					if (flag5)
					{
						num2 = (int)((double)num2 * 0.5);
					}
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)additionalRewards[j].itemID, num2, false);
					IXUISprite ixuisprite2 = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)additionalRewards[j].itemID;
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					gameObject2.transform.parent = base.uiBehaviour.AdditionalRewardsGrid;
				}
				IXUIList ixuilist2 = base.uiBehaviour.AdditionalRewardsGrid.GetComponent("XUIList") as IXUIList;
				ixuilist2.Refresh();
			}
			Transform transform = base.uiBehaviour.SubmmitBtn.gameObject.transform.Find("RedPoint");
			bool flag6 = rewardedTaskCount >= XGuildDailyTaskDocument.Doc.GetTaskItemCount();
			if (flag6)
			{
				transform.gameObject.SetActive(true);
			}
			else
			{
				transform.gameObject.SetActive(false);
			}
			Transform transform2 = base.uiBehaviour.SubmmitBtn.gameObject.transform.Find("task");
			IXUILabel ixuilabel = transform2.GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("SubmmitTask"));
			base.uiBehaviour.SubmmitBtn.gameObject.SetActive(true);
			base.uiBehaviour.SubmmitBtn.SetEnable(true, false);
			bool isRewarded = XGuildDailyTaskDocument.Doc.IsRewarded;
			if (isRewarded)
			{
				transform.gameObject.SetActive(false);
				base.uiBehaviour.SubmmitBtn.SetEnable(false, false);
				ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString("dailyTaskFinish"));
			}
			else
			{
				bool flag7 = rewardedTaskCount < XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskMinTotalTaskCount");
				if (flag7)
				{
					base.uiBehaviour.SubmmitBtn.gameObject.SetActive(false);
				}
			}
			base.uiBehaviour.taskTimeLabel.SetText(rewardedTaskCount + "/" + XGuildDailyTaskDocument.Doc.GetTaskItemCount());
			base.uiBehaviour.timeLabel.SetText(XGuildDailyTaskDocument.Doc.AskedNum + "/" + XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskAskHelpNum"));
			base.uiBehaviour.taskNumLabel.SetText(count.ToString());
		}

		// Token: 0x0600AEFA RID: 44794 RVA: 0x0021031C File Offset: 0x0020E51C
		private void UpdateTaskItem(Transform itemTransform, int index)
		{
			GuildDailyTaskInfo taskInfoByIndex = XGuildDailyTaskDocument.Doc.GetTaskInfoByIndex(index);
			bool flag = taskInfoByIndex != null;
			if (flag)
			{
				DailyTask.RowData dailyTaskTableInfoByID = XGuildDailyTaskDocument.Doc.GetDailyTaskTableInfoByID(taskInfoByIndex.taskID);
				bool flag2 = dailyTaskTableInfoByID == null;
				if (!flag2)
				{
					IXUILabel ixuilabel = itemTransform.Find("ResName").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(dailyTaskTableInfoByID.taskdescription);
					IXUILabel ixuilabel2 = itemTransform.Find("Progress").GetComponent("XUILabel") as IXUILabel;
					IXUICheckBox ixuicheckBox = itemTransform.Find("Normal").GetComponent("XUICheckBox") as IXUICheckBox;
					ixuicheckBox.ID = (ulong)taskInfoByIndex.taskID;
					uint step = taskInfoByIndex.step;
					uint conditionNum = dailyTaskTableInfoByID.conditionNum;
					IXUILabel ixuilabel3 = itemTransform.Find("GetBtn/T").GetComponent("XUILabel") as IXUILabel;
					ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("GoToSubmit"));
					Transform transform = itemTransform.Find("boss");
					transform.gameObject.SetActive(true);
					Transform transform2 = itemTransform.Find("Item");
					transform2.gameObject.SetActive(true);
					IXUISprite ixuisprite = itemTransform.Find("Item/Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)dailyTaskTableInfoByID.conditionId[0];
					bool flag3 = dailyTaskTableInfoByID.tasktype == 1U;
					if (flag3)
					{
						transform.gameObject.SetActive(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(transform2.gameObject, (int)dailyTaskTableInfoByID.conditionId[0], 0, false);
						IXUISprite ixuisprite2 = transform2.Find("Quality").GetComponent("XUISprite") as IXUISprite;
						ixuisprite2.SetSprite(ixuisprite2.spriteName.Substring(0, ixuisprite2.spriteName.Length - 1) + dailyTaskTableInfoByID.taskquality);
						bool flag4 = step < conditionNum;
						if (flag4)
						{
							ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("GotoObtain"));
						}
					}
					else
					{
						bool flag5 = step < conditionNum;
						if (flag5)
						{
							ixuilabel3.SetText(XSingleton<XStringTable>.singleton.GetString("GoToFight"));
						}
						transform2.gameObject.SetActive(false);
						XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(dailyTaskTableInfoByID.NPCID);
						IXUISprite ixuisprite3 = transform.GetComponent("XUISprite") as IXUISprite;
						ixuisprite3.ID = (ulong)dailyTaskTableInfoByID.taskID;
						bool flag6 = byID != null;
						if (flag6)
						{
							XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(byID.PresentID);
							ixuisprite3.SetSprite(byPresentID.Avatar, byPresentID.Atlas, false);
						}
						IXUISprite ixuisprite4 = transform.Find("p").GetComponent("XUISprite") as IXUISprite;
						ixuisprite4.SetSprite(ixuisprite4.spriteName.Substring(0, ixuisprite4.spriteName.Length - 1) + dailyTaskTableInfoByID.taskquality);
					}
					IXUIButton ixuibutton = itemTransform.Find("ReqHelp").GetComponent("XUIButton") as IXUIButton;
					ixuibutton.ID = (ulong)taskInfoByIndex.taskID;
					DailyTaskReward.RowData singleTaskRewardInfoByID = XGuildDailyTaskDocument.Doc.GetSingleTaskRewardInfoByID(GuildTaskType.DailyTask, taskInfoByIndex.taskID);
					IXUISprite ixuisprite5 = itemTransform.Find("god").GetComponent("XUISprite") as IXUISprite;
					IXUISprite ixuisprite6 = itemTransform.Find("exp").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel4 = itemTransform.Find("godLabel").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel5 = itemTransform.Find("expLabel").GetComponent("XUILabel") as IXUILabel;
					bool flag7 = singleTaskRewardInfoByID != null;
					if (flag7)
					{
						SeqListRef<uint> taskreward = singleTaskRewardInfoByID.taskreward;
						XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
						uint num = taskreward[0, 1];
						uint num2 = taskreward[1, 1];
						bool flag8 = taskreward[0, 0] == 4U && specificDocument.IsInLevelSeal();
						if (flag8)
						{
							num = (uint)(num * 0.5);
						}
						bool flag9 = taskreward[1, 0] == 4U && specificDocument.IsInLevelSeal();
						if (flag9)
						{
							num2 = (uint)(num2 * 0.5);
						}
						ixuilabel4.SetText(num.ToString());
						ixuilabel5.SetText(num2.ToString());
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)taskreward[0, 0]);
						ixuisprite5.SetSprite(itemConf.ItemIcon1[0]);
						itemConf = XBagDocument.GetItemConf((int)taskreward[1, 0]);
						ixuisprite6.SetSprite(itemConf.ItemIcon1[0]);
					}
					IXUIButton ixuibutton2 = itemTransform.Find("GetBtn").GetComponent("XUIButton") as IXUIButton;
					ixuibutton2.ID = (ulong)taskInfoByIndex.taskID;
					Transform transform3 = itemTransform.Find("RedPoint");
					Transform transform4 = itemTransform.Find("CompleteFlag");
					ixuilabel2.SetText(step + "/" + conditionNum);
					bool flag10 = step >= conditionNum && !taskInfoByIndex.isRewarded;
					if (flag10)
					{
						transform3.gameObject.SetActive(true);
					}
					else
					{
						transform3.gameObject.SetActive(false);
					}
					ixuibutton2.SetEnable(true, false);
					bool isRewarded = taskInfoByIndex.isRewarded;
					if (isRewarded)
					{
						ixuibutton2.gameObject.SetActive(false);
						transform4.gameObject.SetActive(true);
					}
					else
					{
						bool isRewarded2 = XGuildDailyTaskDocument.Doc.IsRewarded;
						if (isRewarded2)
						{
							ixuibutton2.gameObject.SetActive(true);
							ixuibutton2.SetEnable(false, false);
							transform4.gameObject.SetActive(false);
							transform3.gameObject.SetActive(false);
						}
						else
						{
							ixuibutton2.gameObject.SetActive(true);
							transform4.gameObject.SetActive(false);
						}
					}
					ixuibutton.gameObject.SetActive(true);
					bool flag11 = taskInfoByIndex.hasAsked || (ulong)XGuildDailyTaskDocument.Doc.AskedNum >= (ulong)((long)XSingleton<XGlobalConfig>.singleton.GetInt("DailyTaskAskHelpNum"));
					if (flag11)
					{
						ixuibutton.SetEnable(false, false);
					}
					else
					{
						ixuibutton.SetEnable(true, false);
					}
					IXUILabel ixuilabel6 = ixuibutton.gameObject.transform.Find("GetLabel").GetComponent("XUILabel") as IXUILabel;
					bool hasAsked = taskInfoByIndex.hasAsked;
					if (hasAsked)
					{
						ixuilabel6.SetText(XSingleton<XStringTable>.singleton.GetString("DailyTaskGetted"));
					}
					else
					{
						ixuilabel6.SetText(XSingleton<XStringTable>.singleton.GetString("DailyTaskGet"));
					}
					bool flag12 = (step >= conditionNum && !taskInfoByIndex.hasAsked) || dailyTaskTableInfoByID.tasktype != 1U || taskInfoByIndex.isRewarded || XGuildDailyTaskDocument.Doc.IsRewarded;
					if (flag12)
					{
						ixuibutton.gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600AEFB RID: 44795 RVA: 0x00210A04 File Offset: 0x0020EC04
		public void RefreshLogContent()
		{
			base.uiBehaviour.RefreshRecordRoot.gameObject.SetActive(true);
			List<DailyTaskRefreshInfo> dailyTaskRefreshRecordList = XGuildDailyTaskDocument.Doc.DailyTaskRefreshRecordList;
			base.uiBehaviour.RefreshLogWrapContent.SetContentCount(dailyTaskRefreshRecordList.Count, false);
			base.uiBehaviour.RefreshLogScrollView.ResetPosition();
		}

		// Token: 0x0600AEFC RID: 44796 RVA: 0x00210A60 File Offset: 0x0020EC60
		public void RefreshTaskItemByID(uint id)
		{
			this._taskContent.RefreshAllVisibleContents();
			int rewardedTaskCount = XGuildDailyTaskDocument.Doc.GetRewardedTaskCount();
			base.uiBehaviour.RefreshTaskBtn.gameObject.SetActive(rewardedTaskCount == 0);
			base.uiBehaviour.TalkLabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("GuildDailyTaskLeftRefreshTimes"), XGuildDailyTaskDocument.Doc.Refresh_num));
			base.uiBehaviour.TalkLabel.gameObject.SetActive(rewardedTaskCount == 0 && XGuildDailyTaskDocument.Doc.Refresh_num > 0U);
			this.UpdateTotalTaskRewards();
		}

		// Token: 0x0600AEFD RID: 44797 RVA: 0x00210B04 File Offset: 0x0020ED04
		public void RefreshTaskContent()
		{
			base.uiBehaviour.TaskLevelSprite.SetSprite(base.uiBehaviour.TaskLevelSprite.spriteName.Substring(0, base.uiBehaviour.TaskLevelSprite.spriteName.Length - 1) + XGuildDailyTaskDocument.Doc.CurScore);
			int rewardedTaskCount = XGuildDailyTaskDocument.Doc.GetRewardedTaskCount();
			base.uiBehaviour.RefreshTaskBtn.gameObject.SetActive(rewardedTaskCount == 0);
			base.uiBehaviour.TalkLabel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("GuildDailyTaskLeftRefreshTimes"), XGuildDailyTaskDocument.Doc.Refresh_num));
			base.uiBehaviour.TalkLabel.gameObject.SetActive(rewardedTaskCount == 0 && XGuildDailyTaskDocument.Doc.Refresh_num > 0U);
			int taskItemCount = XGuildDailyTaskDocument.Doc.GetTaskItemCount();
			bool flag = taskItemCount > 0;
			if (flag)
			{
				this._taskContent.SetContentCount(taskItemCount, false);
				this.UpdateTotalTaskRewards();
			}
		}

		// Token: 0x0600AEFE RID: 44798 RVA: 0x00210C10 File Offset: 0x0020EE10
		private void InitDefaultSelectedTaskItem()
		{
			bool flag = !this.selectedDefault;
			if (flag)
			{
				Transform transform = this._taskContent.gameObject.transform;
				bool flag2 = transform.childCount > 0;
				if (flag2)
				{
					Transform child = transform.GetChild(0);
					IXUICheckBox ixuicheckBox = child.Find("Normal").GetComponent("XUICheckBox") as IXUICheckBox;
					bool flag3 = ixuicheckBox != null;
					if (flag3)
					{
						ixuicheckBox.ForceSetFlag(true);
					}
				}
			}
		}

		// Token: 0x0400428D RID: 17037
		private IXUIWrapContent _taskContent = null;

		// Token: 0x0400428E RID: 17038
		private uint _curTabedTaskID = 0U;

		// Token: 0x0400428F RID: 17039
		private bool selectedDefault = false;
	}
}
