using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ActivityHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/DailyActivity/ActivityHandler";
			}
		}

		protected override void Init()
		{
			this.m_doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XActivityDocument.uuID) as XActivityDocument);
			this.m_doc.View = this;
			this.m_noDailyItemTips = base.PanelObject.transform.FindChild("Bg/NoDailyActivity").gameObject;
			this.m_noMulItemTips = base.PanelObject.transform.FindChild("Bg/NoMulActivity").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("Bg/ActivityPanel");
			this.m_dailyScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.PanelObject.transform.FindChild("Bg/DailyTpl");
			this.m_dailyItemPool.SetupPool(base.PanelObject, transform.gameObject, 2U, false);
			transform = base.PanelObject.transform.FindChild("Bg/MulActivityPanel");
			this.m_mulItem = base.PanelObject.transform.FindChild("Bg/MulTpl").gameObject;
			this.m_mulItemPool.SetupPool(base.PanelObject, this.m_mulItem, 2U, false);
			this.m_mulScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.PanelObject.transform.FindChild("Bg/Bottom");
			this.m_describeContentLab = (transform.FindChild("DescribeContentLab").GetComponent("XUILabel") as IXUILabel);
			this.m_shopBtn = (transform.FindChild("BtnShop").GetComponent("XUIButton") as IXUIButton);
			this.m_viewBtn = (transform.FindChild("ActivityView").GetComponent("XUIButton") as IXUIButton);
			transform = transform.FindChild("Rewards");
			this.m_dropItemPool.SetupPool(transform.gameObject, transform.FindChild("Item").gameObject, 4U, false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_noDailyItemTips.SetActive(false);
			this.m_noMulItemTips.SetActive(false);
			this.m_bIsInit = true;
			XSingleton<XTutorialHelper>.singleton.ActivityOpen = false;
			this.m_doc.ReqDayCount();
			this.m_doc.SendQueryGetMulActInfo();
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTutorialHelper>.singleton.ActivityOpen = false;
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			this.RefreshLeftTime();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool flag = XSingleton<XGame>.singleton.CurrentStage == null || !XSingleton<XGame>.singleton.CurrentStage.IsEntered;
			if (!flag)
			{
				this.OnShow();
			}
		}

		public void RefreshDailyActivity()
		{
			this.FillDailyActivity();
		}

		public void RefreshMulActivity()
		{
			this.FillMulActivity();
		}

		private void FillDailyActivity()
		{
			this.m_dailyItemPool.ReturnAll(false);
			int num = this.m_doc._ActivityListTable.Table.Length;
			bool flag = num == 0;
			if (flag)
			{
				this.m_noDailyItemTips.SetActive(true);
				this.m_dailyScrollView.gameObject.SetActive(false);
			}
			else
			{
				this.SetDailyData(num);
				this.m_noDailyItemTips.SetActive(false);
				this.m_dailyScrollView.gameObject.SetActive(true);
				this.FillDailyActivityItems();
				this.m_dailyScrollView.ResetPosition();
			}
		}

		private void FillDailyActivityItems()
		{
			for (int i = 0; i < this.m_dailyDataList.Count; i++)
			{
				GameObject gameObject = this.m_dailyItemPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_dailyScrollView.gameObject.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = this.m_dailyItemPool.TplPos + new Vector3((float)(this.m_dailyItemPool.TplWidth * (i % 2)), (float)(-(float)this.m_dailyItemPool.TplHeight * (i / 2)), 0f);
				this.FillDailyActivityItem(gameObject.transform, i, this.m_dailyDataList[i]);
			}
			this.m_dailyScrollView.gameObject.SetActive(false);
			this.m_dailyScrollView.gameObject.SetActive(true);
		}

		private void FillDailyActivityItem(Transform t, int index, ActivityHandler.DailyData daily)
		{
			bool flag = daily == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("info is nil", null, null, null, null, null);
			}
			else
			{
				t.gameObject.name = string.Format("Item{0}", daily.Row.SysID);
				t.FindChild("SelectIcon").transform.gameObject.SetActive(false);
				IXUILabel ixuilabel = t.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(daily.Row.Tittle);
				IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(daily.Row.Icon, daily.Row.AtlasPath, false);
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickDailyIconSpr));
				bool bIsInit = this.m_bIsInit;
				if (bIsInit)
				{
					this.m_bIsInit = false;
					this.m_selectItemTra = t;
					this.OnClickDailyIconSpr(ixuisprite);
				}
				ixuisprite = (t.FindChild("GongPing").GetComponent("XUISprite") as IXUISprite);
				ixuisprite.gameObject.SetActive(true);
				bool flag2 = daily.Row.SysID == 520U;
				if (flag2)
				{
					bool flag3 = this.NestNeedTransform();
					bool flag4 = daily.Row.TagName != null;
					if (flag4)
					{
						bool flag5 = flag3;
						if (flag5)
						{
							bool flag6 = daily.Row.TagName.Length >= 1;
							if (flag6)
							{
								ixuisprite.spriteName = daily.Row.TagName[0];
							}
							else
							{
								ixuisprite.gameObject.SetActive(false);
							}
						}
						else
						{
							bool flag7 = daily.Row.TagName.Length >= 2;
							if (flag7)
							{
								ixuisprite.spriteName = daily.Row.TagName[1];
							}
							else
							{
								ixuisprite.gameObject.SetActive(false);
							}
						}
					}
					else
					{
						ixuisprite.gameObject.SetActive(false);
					}
				}
				else
				{
					bool flag8 = daily.Row.TagName == null || daily.Row.TagName.Length == 0;
					if (flag8)
					{
						ixuisprite.gameObject.SetActive(false);
					}
					else
					{
						ixuisprite.spriteName = daily.Row.TagName[0];
					}
				}
				this.SetTags(t.FindChild("Tags"), daily.Row.TagNames);
				IXUIButton ixuibutton = t.FindChild("JoinBtn").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)daily.Row.SysID;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDailyJoinBtn));
				ixuibutton.gameObject.SetActive(daily.IsOpen && !daily.IsFinished);
				GameObject gameObject = t.FindChild("LeftCount").gameObject;
				GameObject gameObject2 = t.FindChild("Finished").gameObject;
				IXUILabel ixuilabel2 = t.FindChild("UnReceive").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("ConditionLab").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("Buy").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.FindChild("resetting").GetComponent("XUILabel") as IXUILabel;
				ixuisprite = (t.FindChild("Double").GetComponent("XUISprite") as IXUISprite);
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
				ixuilabel4.gameObject.SetActive(false);
				ixuilabel5.gameObject.SetActive(false);
				ixuilabel2.gameObject.SetActive(false);
				ixuilabel3.gameObject.SetActive(false);
				ixuisprite.gameObject.SetActive(false);
				bool isOpen = daily.IsOpen;
				if (isOpen)
				{
					ixuisprite.gameObject.SetActive(this.m_doc.IsInnerDropTime(daily.Row.SysID));
					gameObject2.SetActive(daily.IsFinished);
					bool flag9 = daily.CanBuyCount != 0;
					if (flag9)
					{
						ixuilabel4.gameObject.SetActive(true);
						ixuilabel4.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("CanBuyCount"), daily.CanBuyCount));
					}
					bool flag10 = daily.LeftDay != 0;
					if (flag10)
					{
						ixuilabel5.gameObject.SetActive(true);
						ixuilabel5.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("ResetTime"), daily.LeftDay));
					}
					XSysDefine sysID = (XSysDefine)daily.Row.SysID;
					if (sysID <= XSysDefine.XSys_GuildDailyTask)
					{
						if (sysID != XSysDefine.XSys_AbyssParty && sysID != XSysDefine.XSys_Activity_DragonNest)
						{
							if (sysID != XSysDefine.XSys_GuildDailyTask)
							{
								goto IL_5E1;
							}
							XGuildDailyTaskDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDailyTaskDocument>(XGuildDailyTaskDocument.uuID);
							bool flag11 = specificDocument.GoToTakeTask();
							if (flag11)
							{
								ixuilabel2.gameObject.SetActive(true);
								ixuilabel2.SetText(daily.CountStr);
							}
							else
							{
								gameObject.SetActive(true);
								ixuilabel = (t.FindChild("LeftCount/Num").GetComponent("XUILabel") as IXUILabel);
								ixuilabel.SetText(daily.CountStr);
							}
						}
					}
					else if (sysID != XSysDefine.XSys_GuildInherit)
					{
						if (sysID != XSysDefine.XSys_GuildWeeklyBountyTask)
						{
							if (sysID != XSysDefine.xSys_Mysterious)
							{
								goto IL_5E1;
							}
						}
						else
						{
							XGuildWeeklyBountyDocument doc = XGuildWeeklyBountyDocument.Doc;
							bool flag12 = doc.GoToTakeTask();
							if (flag12)
							{
								ixuilabel2.gameObject.SetActive(true);
								ixuilabel2.SetText(daily.CountStr);
							}
							else
							{
								gameObject.SetActive(true);
								ixuilabel = (t.FindChild("LeftCount/Num").GetComponent("XUILabel") as IXUILabel);
								ixuilabel.SetText(daily.CountStr);
							}
						}
					}
					goto IL_613;
					IL_5E1:
					gameObject.SetActive(true);
					ixuilabel = (t.FindChild("LeftCount/Num").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(daily.CountStr);
					IL_613:;
				}
				else
				{
					ixuilabel3.gameObject.SetActive(true);
					ixuilabel3.SetText(daily.NotOpenReason);
				}
			}
		}

		private bool NestNeedTransform()
		{
			XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
			bool flag = specificDocument.SealType < 3U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("NestTransform");
				DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0);
				dateTime = dateTime.AddSeconds(this.m_doc.ServerTimeSince1970);
				dateTime = dateTime.ToLocalTime();
				for (int i = 0; i < intList.Count; i++)
				{
					int num = (intList[i] != 7) ? intList[i] : 0;
					bool flag2 = num < 0 || num > 6;
					if (!flag2)
					{
						bool flag3 = num == XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek);
						if (flag3)
						{
							bool flag4 = dateTime.Hour >= 5;
							if (flag4)
							{
								return true;
							}
						}
						num = ((num + 1 > 6) ? 0 : (num + 1));
						bool flag5 = num == XFastEnumIntEqualityComparer<DayOfWeek>.ToInt(dateTime.DayOfWeek);
						if (flag5)
						{
							bool flag6 = dateTime.Hour < 5;
							if (flag6)
							{
								return true;
							}
						}
					}
				}
				result = false;
			}
			return result;
		}

		private void SetTags(Transform tra, string[] names)
		{
			int num = 0;
			bool flag = names != null;
			if (flag)
			{
				num = names.Length;
			}
			bool flag2 = num == 0;
			if (flag2)
			{
				tra.gameObject.SetActive(false);
			}
			else
			{
				tra.gameObject.SetActive(true);
				IXUISprite ixuisprite = tra.FindChild("Tag1").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite2 = tra.FindChild("Tag2").GetComponent("XUISprite") as IXUISprite;
				bool flag3 = num == 1;
				if (flag3)
				{
					ixuisprite.SetSprite(names[0]);
					ixuisprite2.gameObject.SetActive(false);
				}
				else
				{
					ixuisprite.SetSprite(names[0]);
					ixuisprite2.gameObject.SetActive(true);
					ixuisprite2.SetSprite(names[1]);
				}
			}
		}

		private void SetDailyData(int count)
		{
			this.m_dailyDataList.Clear();
			int leftCount = 0;
			int totalCount = 0;
			int canBuyCount = 0;
			int leftDay = 0;
			uint num = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level + (uint)XSingleton<XGlobalConfig>.singleton.GetInt("DailyActivityLimitLevel");
			for (int i = 0; i < count; i++)
			{
				bool flag = this.m_doc._ActivityListTable.Table[i] == null;
				if (!flag)
				{
					ActivityHandler.DailyData dailyData = new ActivityHandler.DailyData(this.m_doc._ActivityListTable.Table[i], this.m_doc.ServerOpenDay);
					this.m_doc.GetCount((int)dailyData.Row.SysID, ref leftCount, ref totalCount, ref canBuyCount);
					this.m_doc.GetLeftDay((int)dailyData.Row.SysID, ref leftDay);
					dailyData.SetCount(leftCount, totalCount, canBuyCount, leftDay);
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((XSysDefine)dailyData.Row.SysID);
					bool flag2 = !dailyData.IsOpen && ((long)sysOpenLevel > (long)((ulong)num) || (long)sysOpenLevel <= (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level));
					if (!flag2)
					{
						this.m_dailyDataList.Add(dailyData);
					}
				}
			}
			this.m_dailyDataList.Sort(new Comparison<ActivityHandler.DailyData>(this.DailyDataCompare));
		}

		private int DailyDataCompare(ActivityHandler.DailyData left, ActivityHandler.DailyData right)
		{
			bool flag = left.IsFinished != right.IsFinished;
			int result;
			if (flag)
			{
				bool isFinished = left.IsFinished;
				if (isFinished)
				{
					result = 1;
				}
				else
				{
					result = -1;
				}
			}
			else
			{
				bool isFinished2 = left.IsFinished;
				if (isFinished2)
				{
					result = (int)(left.Row.SortIndex - right.Row.SortIndex);
				}
				else
				{
					bool flag2 = left.IsOpen != right.IsOpen;
					if (flag2)
					{
						bool isOpen = left.IsOpen;
						if (isOpen)
						{
							result = -1;
						}
						else
						{
							result = 1;
						}
					}
					else
					{
						result = (int)(left.Row.SortIndex - right.Row.SortIndex);
					}
				}
			}
			return result;
		}

		public void SetScrollView(int sysId)
		{
			float position = 0f;
			int num = 0;
			bool flag = this.m_dailyDataList != null && this.m_dailyDataList.Count > 0;
			if (flag)
			{
				for (int i = 0; i < this.m_dailyDataList.Count; i++)
				{
					bool flag2 = (long)sysId == (long)((ulong)this.m_dailyDataList[i].Row.SysID);
					if (flag2)
					{
						num = i + 1;
						break;
					}
				}
				bool flag3 = num > XSingleton<XGlobalConfig>.singleton.GetInt("UiShowNum");
				if (flag3)
				{
					int num2 = (this.m_dailyDataList.Count % 2 == 0) ? (this.m_dailyDataList.Count / 2) : (this.m_dailyDataList.Count / 2 + 1);
					int num3 = (num % 2 == 0) ? (num / 2) : (num / 2 + 1);
					position = (float)num3 / (float)num2;
				}
			}
			this.m_dailyScrollView.SetPosition(position);
		}

		private void FillMulActivity()
		{
			this.m_mulItemPool.ReturnAll(false);
			int count = this.m_doc.MulActivityList.Count;
			bool flag = count == 0;
			if (flag)
			{
				this.m_noMulItemTips.SetActive(true);
				this.m_mulScrollView.gameObject.SetActive(false);
			}
			else
			{
				this.m_noMulItemTips.SetActive(false);
				this.m_mulScrollView.gameObject.SetActive(true);
				this.FillMulActivityItems(count);
				this.m_mulScrollView.ResetPosition();
			}
		}

		private void FillMulActivityItems(int count)
		{
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = this.m_mulItemPool.FetchGameObject(false);
				gameObject.transform.parent = this.m_mulScrollView.gameObject.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = this.m_mulItemPool.TplPos + new Vector3(0f, (float)(-(float)this.m_mulItemPool.TplHeight * i), 0f);
				this.FillMulActivityItem(gameObject.transform, i, this.m_doc.MulActivityList[i]);
			}
			this.m_mulScrollView.gameObject.SetActive(false);
			this.m_mulScrollView.gameObject.SetActive(true);
		}

		private void FillMulActivityItem(Transform t, int index, MulActivityInfo info)
		{
			bool flag = info == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("info is nil", null, null, null, null, null);
			}
			else
			{
				t.gameObject.name = string.Format("Item{0}", info.Row.SystemID);
				t.FindChild("SelectIcon").transform.gameObject.SetActive(false);
				IXUILabel ixuilabel = t.FindChild("Title").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(info.Row.Name);
				t.FindChild("Bg").gameObject.SetActive(info.state == MulActivityState.Open);
				t.FindChild("Opening").gameObject.SetActive(info.tagType == MulActivityTagType.Opening);
				t.FindChild("WillOpen").gameObject.SetActive(info.tagType == MulActivityTagType.WillOpen);
				IXUIButton ixuibutton = t.FindChild("JoinBtn").GetComponent("XUIButton") as IXUIButton;
				IXUISprite ixuisprite = t.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = t.FindChild("LeftCountOpening").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("LeftCountUnOpen").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("OpenCondition").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.FindChild("NoLimit").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel6 = t.FindChild("WillOpening").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.FindChild("Double").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(info.Row.Icon, info.Row.AtlasPath, false);
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickMulIconSpr));
				ixuisprite.SetGrey(info.state != MulActivityState.Grey && info.state > MulActivityState.Lock);
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickMulJoinBtn));
				ixuibutton.gameObject.SetActive(false);
				ixuilabel2.gameObject.SetActive(false);
				ixuilabel3.gameObject.SetActive(false);
				ixuilabel4.gameObject.SetActive(false);
				ixuilabel5.gameObject.SetActive(false);
				ixuilabel6.gameObject.SetActive(false);
				ixuisprite2.gameObject.SetActive(false);
				switch (info.state)
				{
				case MulActivityState.Lock:
					ixuilabel4.gameObject.SetActive(true);
					ixuilabel4.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(this.GetMissConditionString(info)));
					break;
				case MulActivityState.Grey:
				{
					ixuilabel4.gameObject.SetActive(true);
					bool flag2 = info.timeState == MulActivityTimeState.MULACTIVITY_END;
					if (flag2)
					{
						ixuilabel4.SetText(XStringDefineProxy.GetString("MulActivity_Tips1"));
					}
					else
					{
						bool flag3 = info.timeState == MulActivityTimeState.MULACTIVITY_UNOPEN_TODAY;
						if (flag3)
						{
							ixuilabel4.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(info.Row.OpenDayTips));
						}
						else
						{
							ixuilabel4.SetText(XStringDefineProxy.GetString("MulActivity_Tips5"));
						}
					}
					break;
				}
				case MulActivityState.WillOpen:
				{
					ixuilabel4.gameObject.SetActive(true);
					ixuisprite2.gameObject.SetActive(this.m_doc.IsInnerDropTime((uint)info.Row.SystemID));
					bool flag4 = info.timeState == MulActivityTimeState.MULACTIVITY_BEfOREOPEN;
					if (flag4)
					{
						string arg = XSingleton<UiUtility>.singleton.TimeFormatString(info.startTime * 60, 3, 3, 3, false, true);
						string arg2 = XSingleton<UiUtility>.singleton.TimeFormatString(info.endTime * 60, 3, 3, 3, false, true);
						ixuilabel4.SetText(string.Format("{0}-{1}", arg, arg2));
					}
					else
					{
						ixuilabel4.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(info.Row.OpenDayTips));
					}
					break;
				}
				case MulActivityState.Open:
				{
					ixuisprite2.gameObject.SetActive(this.m_doc.IsInnerDropTime((uint)info.Row.SystemID));
					bool flag5 = !info.openState;
					if (flag5)
					{
						ixuilabel6.gameObject.SetActive(true);
						ixuilabel6.SetText(XStringDefineProxy.GetString("PVPActivity_Wait"));
					}
					else
					{
						bool flag6 = info.Row.SystemID == 992;
						if (flag6)
						{
							ixuibutton.gameObject.SetActive(false);
						}
						else
						{
							ixuibutton.gameObject.SetActive(true);
						}
						bool flag7 = info.Row.DayCountMax == -1;
						if (flag7)
						{
							ixuilabel5.gameObject.SetActive(true);
							ixuilabel5.SetText(XSingleton<XStringTable>.singleton.GetString("No_TimesLimit"));
						}
						else
						{
							ixuilabel2.gameObject.SetActive(true);
							bool flag8 = info.Row.SystemID == 230;
							if (flag8)
							{
								uint num = WeekEndNestDocument.Doc.MaxCount();
								ixuilabel2.SetText(string.Format("{0}/{1}", (long)((ulong)num - (ulong)((long)info.dayjoincount)), num));
							}
							else
							{
								ixuilabel2.SetText(string.Format("{0}/{1}", info.Row.DayCountMax - info.dayjoincount, info.Row.DayCountMax));
							}
						}
					}
					break;
				}
				}
			}
		}

		private string GetMissConditionString(MulActivityInfo info)
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			bool flag = info.serverOpenDayLeft > 0;
			string result;
			if (flag)
			{
				result = string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenDay"), info.serverOpenDayLeft);
			}
			else
			{
				bool flag2 = info.serverOpenWeekLeft > 0;
				if (flag2)
				{
					result = string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenWeek"), info.serverOpenWeekLeft);
				}
				else
				{
					bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < info.roleLevel;
					if (flag3)
					{
						result = string.Format(XStringDefineProxy.GetString("MulActivity_ShowTips9"), info.roleLevel);
					}
					else
					{
						bool flag4 = !specificDocument.bInGuild && info.Row.GuildLevel > 0U;
						if (flag4)
						{
							result = XStringDefineProxy.GetString("MulActivity_ShowTips8");
						}
						else
						{
							result = string.Format(XStringDefineProxy.GetString("MulActivity_ShowTips10"), info.Row.GuildLevel);
						}
					}
				}
			}
			return result;
		}

		public void RefreshLeftTime()
		{
			bool flag = this.m_selectSysId == XSysDefine.XSys_GuildInherit;
			if (flag)
			{
				XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
				string teacherLeftTimeString = specificDocument.GetTeacherLeftTimeString();
				bool flag2 = !string.IsNullOrEmpty(teacherLeftTimeString);
				if (flag2)
				{
					this.m_describeContentLab.SetText(string.Format("{0}({1})", this.m_describeTxt, teacherLeftTimeString));
				}
			}
		}

		private void FillBottom(bool isDaily, int index)
		{
			this.m_bIsDaily = isDaily;
			if (isDaily)
			{
				bool flag = index >= this.m_dailyDataList.Count;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("FillBottom out of range: count = {0},index = {1}", this.m_dailyDataList.Count, index), null, null, null, null, null);
					return;
				}
				ActivityHandler.DailyData dailyData = this.m_dailyDataList[index];
				bool flag2 = dailyData == null;
				if (flag2)
				{
					return;
				}
				this.m_selectSysId = (XSysDefine)dailyData.Row.SysID;
				this.SetDropsItems(dailyData.Row);
				bool flag3 = dailyData.Row.SysID == 890U;
				if (flag3)
				{
					XGuildInheritDocument specificDocument = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
					string text = "";
					bool flag4 = dailyData.IsOpen && specificDocument.TryGetInheritCountString(out text);
					if (flag4)
					{
						this.m_describeContentLab.SetText(text);
					}
					else
					{
						this.m_describeContentLab.SetText(dailyData.Row.Describe);
					}
				}
				else
				{
					this.m_describeContentLab.SetText(dailyData.Row.Describe);
				}
				bool flag5 = dailyData.IsOpen && dailyData.IsFinished;
				if (flag5)
				{
					this.m_viewBtn.gameObject.SetActive(true);
					this.m_viewBtn.ID = (ulong)dailyData.Row.SysID;
				}
				else
				{
					this.m_viewBtn.gameObject.SetActive(false);
				}
				bool flag6 = dailyData.IsOpen && dailyData.Row.HadShop;
				if (flag6)
				{
					this.m_shopBtn.gameObject.SetActive(true);
					this.m_shopBtn.ID = (ulong)dailyData.Row.SysID;
				}
				else
				{
					this.m_shopBtn.gameObject.SetActive(false);
				}
			}
			else
			{
				MulActivityInfo mulActivityInfo = this.m_doc.MulActivityList[index];
				bool flag7 = mulActivityInfo == null;
				if (flag7)
				{
					return;
				}
				this.m_selectSysId = (XSysDefine)mulActivityInfo.Row.SystemID;
				List<uint> list = new List<uint>();
				bool flag8 = mulActivityInfo.Row != null;
				if (flag8)
				{
					for (int i = 0; i < mulActivityInfo.Row.DropItems.Count; i++)
					{
						list.Add(mulActivityInfo.Row.DropItems[i, 0]);
					}
				}
				this.FillBottomItems(list);
				this.m_describeContentLab.SetText(mulActivityInfo.Row.RewardTips);
				bool flag9 = mulActivityInfo.state != MulActivityState.Open;
				if (flag9)
				{
					this.m_viewBtn.ID = (ulong)((long)index);
					XSysDefine selectSysId = this.m_selectSysId;
					if (selectSysId <= XSysDefine.XSys_GuildRelax_JokerMatch)
					{
						if (selectSysId != XSysDefine.XSys_MulActivity_MulVoiceQA && selectSysId - XSysDefine.XSys_GuildRelax_VoiceQA > 1)
						{
							goto IL_2FD;
						}
					}
					else if (selectSysId != XSysDefine.XSys_JockerKing && selectSysId != XSysDefine.XSys_GuildCollect)
					{
						goto IL_2FD;
					}
					this.m_viewBtn.gameObject.SetActive(false);
					goto IL_311;
					IL_2FD:
					this.m_viewBtn.gameObject.SetActive(true);
					IL_311:;
				}
				else
				{
					this.m_viewBtn.gameObject.SetActive(false);
				}
				bool flag10 = mulActivityInfo.state != MulActivityState.Lock && mulActivityInfo.Row.HadShop;
				if (flag10)
				{
					this.m_shopBtn.gameObject.SetActive(true);
					this.m_shopBtn.ID = (ulong)((long)mulActivityInfo.Row.SystemID);
				}
				else
				{
					this.m_shopBtn.gameObject.SetActive(false);
				}
			}
			this.m_describeTxt = this.m_describeContentLab.GetText();
			this.m_shopBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickShop));
			this.m_viewBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickView));
		}

		private void SetDropsItems(ActivityListTable.RowData data)
		{
			bool flag = data == null;
			if (!flag)
			{
				List<uint> list = new List<uint>();
				XSysDefine sysID = (XSysDefine)data.SysID;
				if (sysID != XSysDefine.XSys_Activity_Nest)
				{
					if (sysID != XSysDefine.XSys_Activity_DragonNest)
					{
						for (int i = 0; i < data.DropItems.Count; i++)
						{
							list.Add(data.DropItems[i, 0]);
						}
					}
					else
					{
						XDragonNestDocument specificDocument = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
						ExpeditionTable.RowData lastExpeditionRowData = specificDocument.GetLastExpeditionRowData();
						bool flag2 = lastExpeditionRowData == null;
						if (flag2)
						{
							XSingleton<XDebug>.singleton.AddGreenLog("XSys_Activity_DragonNest,ExpeditionTable row is null", null, null, null, null, null);
						}
						else
						{
							bool flag3 = lastExpeditionRowData.ViewableDropList != null;
							if (flag3)
							{
								for (int j = 0; j < lastExpeditionRowData.ViewableDropList.Length; j++)
								{
									list.Add(lastExpeditionRowData.ViewableDropList[j]);
								}
							}
						}
					}
				}
				else
				{
					XNestDocument specificDocument2 = XDocuments.GetSpecificDocument<XNestDocument>(XNestDocument.uuID);
					ExpeditionTable.RowData lastExpeditionRowData2 = specificDocument2.GetLastExpeditionRowData();
					bool flag4 = lastExpeditionRowData2 == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddGreenLog("XSys_Activity_Nest,ExpeditionTable row is null", null, null, null, null, null);
					}
					else
					{
						bool flag5 = lastExpeditionRowData2.ViewableDropList != null;
						if (flag5)
						{
							for (int k = 0; k < lastExpeditionRowData2.ViewableDropList.Length; k++)
							{
								list.Add(lastExpeditionRowData2.ViewableDropList[k]);
							}
						}
					}
				}
				this.FillBottomItems(list);
			}
		}

		private void FillBottomItems(List<uint> lst)
		{
			this.m_dropItemPool.ReturnAll(false);
			for (int i = 0; i < lst.Count; i++)
			{
				GameObject gameObject = this.m_dropItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = this.m_dropItemPool.TplPos + new Vector3((float)(this.m_dropItemPool.TplWidth * i), 0f, 0f);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)lst[i], 0, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)lst[i];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickItemIcon));
			}
		}

		private bool OnClickShop(IXUIButton btn)
		{
			XSysDefine xsysDefine = (XSysDefine)btn.ID;
			XSysDefine xsysDefine2 = xsysDefine;
			if (xsysDefine2 != XSysDefine.XSys_Level_Elite)
			{
				if (xsysDefine2 != XSysDefine.XSys_Activity_GoddessTrial)
				{
					if (xsysDefine2 == XSysDefine.XSys_EndlessAbyss)
					{
						xsysDefine = ActivityHandler.GetShopSystem();
					}
				}
				else
				{
					xsysDefine = XSysDefine.XSys_Mall_Tear;
				}
			}
			else
			{
				SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("AbyssTeamShopLevel", true);
				List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("AbyssTeamShopType");
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				bool flag = false;
				for (int i = 0; i < (int)sequenceList.Count; i++)
				{
					bool flag2 = level >= sequenceList[i, 0] && level <= sequenceList[i, 1];
					if (flag2)
					{
						flag = true;
						xsysDefine = (XSysDefine)(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Mall_MystShop) + intList[i]);
						break;
					}
				}
				bool flag3 = !flag;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Can't find player level state from golbalconfig by AbyssTeamShop. level = ", level.ToString(), null, null, null, null);
				}
			}
			bool flag4 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(xsysDefine);
			bool result;
			if (flag4)
			{
				DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(xsysDefine, 0UL);
				result = true;
			}
			else
			{
				int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine));
				XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("SHOP_OPEN_LEVEL"), sysOpenLevel), "fece00");
				result = false;
			}
			return result;
		}

		public static XSysDefine GetShopSystem()
		{
			SeqList<int> sequenceList = XSingleton<XGlobalConfig>.singleton.GetSequenceList("EndlessabyssLevelInterval", true);
			List<int> intList = XSingleton<XGlobalConfig>.singleton.GetIntList("EndlessabyssShopType");
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < (int)sequenceList.Count; i++)
			{
				bool flag = level >= sequenceList[i, 0] && level <= sequenceList[i, 1];
				if (flag)
				{
					return (XSysDefine)(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Mall_MystShop) + intList[i]);
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("Can't find player level state from golbalconfig EndlessabyssLevelInterval. level = ", level.ToString(), null, null, null, null);
			return XSysDefine.XSys_Mall_32A;
		}

		private bool OnClickView(IXUIButton btn)
		{
			bool bIsDaily = this.m_bIsDaily;
			if (bIsDaily)
			{
				this.OnClickDailyJoinBtn(btn);
			}
			else
			{
				this.OnClickMulJoinBtn(btn);
			}
			return true;
		}

		private bool OnClickDailyJoinBtn(IXUIButton btn)
		{
			XSysDefine xsysDefine = (XSysDefine)btn.ID;
			XSysDefine xsysDefine2 = xsysDefine;
			if (xsysDefine2 != XSysDefine.XSys_GuildDailyTask && xsysDefine2 != XSysDefine.XSys_GuildWeeklyBountyTask)
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
			}
			else
			{
				XSingleton<UIManager>.singleton.CloseAllUI();
				XSingleton<XGameSysMgr>.singleton.OpenSystem(xsysDefine, 0UL);
			}
			return true;
		}

		private void OnClickDailyIconSpr(IXUISprite spr)
		{
			this.m_selectItemTra.FindChild("SelectIcon").gameObject.SetActive(false);
			this.m_selectItemTra = spr.transform.parent;
			this.m_selectItemTra.FindChild("SelectIcon").gameObject.SetActive(true);
			this.FillBottom(true, (int)spr.ID);
		}

		private bool OnClickMulJoinBtn(IXUIButton btn)
		{
			int index = (int)btn.ID;
			MulActivityInfo mulActivityInfo = this.m_doc.MulActivityList[index];
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			switch (mulActivityInfo.state)
			{
			case MulActivityState.Lock:
			{
				bool flag = mulActivityInfo.serverOpenDayLeft > 0;
				if (flag)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenDay"), mulActivityInfo.serverOpenDayLeft), "fece00");
				}
				else
				{
					bool flag2 = mulActivityInfo.serverOpenWeekLeft > 0;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenWeek"), mulActivityInfo.serverOpenWeekLeft), "fece00");
					}
					else
					{
						bool flag3 = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < mulActivityInfo.roleLevel;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ShowTips1"), mulActivityInfo.roleLevel), "fece00");
						}
						else
						{
							bool flag4 = !specificDocument.bInGuild && mulActivityInfo.Row.GuildLevel > 0U;
							if (flag4)
							{
								XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("MulActivity_ShowTips3"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.JoinGuild));
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ShowTips2"), mulActivityInfo.Row.GuildLevel), "fece00");
							}
						}
					}
				}
				break;
			}
			case MulActivityState.Grey:
			{
				bool flag5 = mulActivityInfo.timeState == MulActivityTimeState.MULACTIVITY_UNOPEN_TODAY;
				string @string;
				if (flag5)
				{
					@string = XStringDefineProxy.GetString("MulActivity_ShowTips5");
				}
				else
				{
					bool flag6 = mulActivityInfo.timeState == MulActivityTimeState.MULACTIVITY_END;
					if (flag6)
					{
						@string = XStringDefineProxy.GetString("MulActivity_ShowTips4");
					}
					else
					{
						@string = XStringDefineProxy.GetString("MulActivity_ShowTips7");
					}
				}
				XSingleton<UiUtility>.singleton.ShowSystemTip(@string, "fece00");
				break;
			}
			case MulActivityState.WillOpen:
			{
				XSysDefine systemID = (XSysDefine)mulActivityInfo.Row.SystemID;
				if (systemID != XSysDefine.XSys_MulActivity_MulVoiceQA && systemID != XSysDefine.XSys_GuildQualifier)
				{
					bool flag7 = mulActivityInfo.Row.GuildLevel == 0U;
					if (flag7)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(mulActivityInfo.Row.SystemID);
					}
					else
					{
						XSingleton<XGameSysMgr>.singleton.OpenGuildSystem((XSysDefine)mulActivityInfo.Row.SystemID);
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("MulActivity_ShowTips6"), "fece00");
				}
				break;
			}
			case MulActivityState.Open:
			{
				XSysDefine systemID2 = (XSysDefine)mulActivityInfo.Row.SystemID;
				if (systemID2 != XSysDefine.XSys_MulActivity_MulVoiceQA)
				{
					bool flag8 = mulActivityInfo.Row.GuildLevel == 0U;
					if (flag8)
					{
						XSingleton<XGameSysMgr>.singleton.OpenSystem(mulActivityInfo.Row.SystemID);
					}
					else
					{
						XSingleton<XGameSysMgr>.singleton.OpenGuildSystem((XSysDefine)mulActivityInfo.Row.SystemID);
					}
				}
				else
				{
					XVoiceQADocument specificDocument2 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
					specificDocument2.TempType = 2U;
					XVoiceQADocument specificDocument3 = XDocuments.GetSpecificDocument<XVoiceQADocument>(XVoiceQADocument.uuID);
					bool isVoiceQAIng = specificDocument3.IsVoiceQAIng;
					if (isVoiceQAIng)
					{
						DlgBase<XVoiceQAView, XVoiceQABehaviour>.singleton.SetVisible(true, true);
					}
					else
					{
						string label = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("VoiceQA_Enter_Description_" + specificDocument3.TempType.ToString()));
						string string2 = XStringDefineProxy.GetString("VoiceQA_Enter_btn1");
						string string3 = XStringDefineProxy.GetString("VoiceQA_Enter_btn2");
						XSingleton<UiUtility>.singleton.ShowModalDialog(label, string2, string3, new ButtonClickEventHandler(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceQAJoin), new ButtonClickEventHandler(DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnVoiceQARefuse), false, XTempTipDefine.OD_START, 50);
					}
				}
				break;
			}
			}
			return true;
		}

		private bool JoinGuild(IXUIButton btn)
		{
			bool flag = DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.SetVisible(false, true);
			}
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private void OnClickMulIconSpr(IXUISprite spr)
		{
			bool flag = this.m_selectItemTra != null;
			Transform transform;
			if (flag)
			{
				transform = this.m_selectItemTra.FindChild("SelectIcon");
				bool flag2 = transform != null;
				if (flag2)
				{
					transform.gameObject.SetActive(false);
				}
			}
			this.m_selectItemTra = spr.transform.parent;
			transform = this.m_selectItemTra.FindChild("SelectIcon");
			bool flag3 = transform != null;
			if (flag3)
			{
				transform.gameObject.SetActive(true);
			}
			this.FillBottom(false, (int)spr.ID);
		}

		private void OnClickItemIcon(IXUISprite spr)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
		}

		private XActivityDocument m_doc;

		private Transform m_selectItemTra;

		private GameObject m_noDailyItemTips;

		private GameObject m_noMulItemTips;

		private GameObject m_mulItem;

		public IXUIScrollView m_dailyScrollView;

		private IXUIScrollView m_mulScrollView;

		private IXUIButton m_shopBtn;

		private IXUIButton m_viewBtn;

		private IXUILabel m_describeContentLab;

		private XUIPool m_dropItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_mulItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_dailyItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private bool m_bIsInit = false;

		private bool m_bIsDaily = true;

		private string m_describeTxt = "";

		private XSysDefine m_selectSysId = XSysDefine.XSys_None;

		private List<ActivityHandler.DailyData> m_dailyDataList = new List<ActivityHandler.DailyData>();

		private class DailyData
		{

			public DailyData(ActivityListTable.RowData row, int serverOpenDay)
			{
				this.SetData(row, serverOpenDay);
			}

			public void SetCount(int leftCount, int totalCount, int canBuyCount, int leftDay)
			{
				this.m_leftCount = leftCount;
				this.m_totalCount = totalCount;
				this.m_canBuyCount = canBuyCount;
				this.m_leftDay = leftDay;
				XSysDefine sysID = (XSysDefine)this.m_row.SysID;
				if (sysID <= XSysDefine.XSys_Activity_DragonNest)
				{
					if (sysID != XSysDefine.XSys_SuperRisk && sysID != XSysDefine.XSys_AbyssParty && sysID != XSysDefine.XSys_Activity_DragonNest)
					{
						goto IL_207;
					}
				}
				else if (sysID <= XSysDefine.XSys_GuildDailyTask)
				{
					if (sysID != XSysDefine.XSys_Activity_TeamTowerSingle)
					{
						if (sysID != XSysDefine.XSys_GuildDailyTask)
						{
							goto IL_207;
						}
						XGuildDailyTaskDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDailyTaskDocument>(XGuildDailyTaskDocument.uuID);
						bool flag = specificDocument.GoToTakeTask();
						if (flag)
						{
							this.m_isFinished = false;
							this.m_countStr = XSingleton<XStringTable>.singleton.GetString("NoReceive");
						}
						else
						{
							bool flag2 = leftCount == 0 || specificDocument.IsRewarded;
							if (flag2)
							{
								this.m_isFinished = true;
								this.m_countStr = string.Format("{0}/{1}", 0, this.m_totalCount);
							}
							else
							{
								this.m_isFinished = false;
								this.m_countStr = string.Format("{0}/{1}", this.m_leftCount, this.m_totalCount);
							}
						}
						return;
					}
				}
				else
				{
					if (sysID == XSysDefine.XSys_GuildWeeklyBountyTask)
					{
						XGuildWeeklyBountyDocument doc = XGuildWeeklyBountyDocument.Doc;
						bool flag3 = doc.GoToTakeTask();
						if (flag3)
						{
							this.m_isFinished = false;
							this.m_countStr = XSingleton<XStringTable>.singleton.GetString("NoReceive");
						}
						else
						{
							bool flag4 = leftCount == 0 || doc.HasFinishWeeklyTasks();
							if (flag4)
							{
								this.m_isFinished = true;
								this.m_countStr = string.Format("{0}/{1}", 0, this.m_totalCount);
							}
							else
							{
								this.m_isFinished = false;
								this.m_countStr = string.Format("{0}/{1}", this.m_leftCount, this.m_totalCount);
							}
						}
						return;
					}
					if (sysID != XSysDefine.xSys_Mysterious)
					{
						goto IL_207;
					}
				}
				this.m_isFinished = false;
				this.m_countStr = string.Format("{0}/{1}", this.m_leftCount, this.m_totalCount);
				return;
				IL_207:
				bool flag5 = leftCount == 0;
				if (flag5)
				{
					this.m_isFinished = true;
					this.m_countStr = string.Format("{0}/{1}", this.m_leftCount, this.m_totalCount);
				}
				else
				{
					this.m_isFinished = false;
					this.m_countStr = string.Format("{0}/{1}", this.m_leftCount, this.m_totalCount);
				}
			}

			public bool IsOpen
			{
				get
				{
					return this.m_isOpen;
				}
			}

			public bool IsFinished
			{
				get
				{
					return this.m_isFinished & this.m_isOpen;
				}
			}

			public string CountStr
			{
				get
				{
					return this.m_countStr;
				}
			}

			public string NotOpenReason
			{
				get
				{
					return this.m_notOpenReason;
				}
			}

			public ActivityListTable.RowData Row
			{
				get
				{
					return this.m_row;
				}
			}

			public int CanBuyCount
			{
				get
				{
					return this.m_canBuyCount;
				}
			}

			public int LeftDay
			{
				get
				{
					return this.m_leftDay;
				}
			}

			private void SetData(ActivityListTable.RowData row, int serverOpenDay)
			{
				this.m_row = row;
				int sysOpenServerDay = XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay((int)row.SysID);
				bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpen((int)row.SysID);
				if (flag)
				{
					this.m_isOpen = false;
					int sysOpenLevel = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)row.SysID);
					bool flag2 = (long)sysOpenLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					if (flag2)
					{
						int sysOpenLevel2 = XSingleton<XGameSysMgr>.singleton.GetSysOpenLevel((int)row.SysID);
						this.m_notOpenReason = string.Format(XSingleton<XStringTable>.singleton.GetString("LEVEL_REQUIRE_LEVEL"), sysOpenLevel2);
					}
					else
					{
						bool flag3 = serverOpenDay < sysOpenServerDay;
						if (flag3)
						{
							this.m_notOpenReason = XStringDefineProxy.GetString("MulActivity_ServerOpenDay", new object[]
							{
								(sysOpenServerDay - serverOpenDay).ToString()
							});
						}
					}
				}
				else
				{
					this.m_isOpen = true;
				}
			}

			private bool m_isOpen = false;

			private bool m_isFinished = false;

			private int m_leftCount = 0;

			private int m_totalCount = 0;

			private int m_canBuyCount = 0;

			private int m_leftDay = 0;

			private string m_countStr;

			private string m_notOpenReason;

			private ActivityListTable.RowData m_row;
		}
	}
}
