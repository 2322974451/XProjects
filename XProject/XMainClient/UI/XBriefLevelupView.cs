using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001895 RID: 6293
	internal class XBriefLevelupView : DlgBase<XBriefLevelupView, XBriefLevelupBehaviour>
	{
		// Token: 0x170039E0 RID: 14816
		// (get) Token: 0x06010620 RID: 67104 RVA: 0x003FDFB0 File Offset: 0x003FC1B0
		public override string fileName
		{
			get
			{
				return "GameSystem/BriefLevelupDlg";
			}
		}

		// Token: 0x170039E1 RID: 14817
		// (get) Token: 0x06010621 RID: 67105 RVA: 0x003FDFC8 File Offset: 0x003FC1C8
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039E2 RID: 14818
		// (get) Token: 0x06010622 RID: 67106 RVA: 0x003FDFDC File Offset: 0x003FC1DC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010623 RID: 67107 RVA: 0x003FDFF0 File Offset: 0x003FC1F0
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
			this._activityDoc = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
			this.DataArray = new XBriefLevelupView.DataItem[this._Funcs.Length];
			for (int i = 0; i < this.DataArray.Length; i++)
			{
				XBriefLevelupView.DataItem dataItem = new XBriefLevelupView.DataItem(i);
				dataItem.SysId = this._Funcs[i];
				this.DataArray[i] = dataItem;
				this.SetRecommendInfo(this.DataArray[i].Index, ref this.DataArray[i].IsRecommend, ref this.DataArray[i].RecommendTxt);
				this.SetBaseInfo(this.DataArray[i].SysId, ref this.DataArray[i].IconTxt, ref this.DataArray[i].NameTxt);
			}
		}

		// Token: 0x06010624 RID: 67108 RVA: 0x003FE0CA File Offset: 0x003FC2CA
		protected override void OnShow()
		{
			base.OnShow();
			this._activityDoc.QueryDailyActivityData();
		}

		// Token: 0x06010625 RID: 67109 RVA: 0x003FE0E0 File Offset: 0x003FC2E0
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Close2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x06010626 RID: 67110 RVA: 0x003FE120 File Offset: 0x003FC320
		public void FillContent()
		{
			this.FillData();
			base.uiBehaviour.m_FuncPool.ReturnAll(false);
			Vector3 tplPos = base.uiBehaviour.m_FuncPool.TplPos;
			for (int i = 0; i < this.DataArray.Length; i++)
			{
				XBriefLevelupView.DataItem dataItem = this.DataArray[i];
				GameObject gameObject = base.uiBehaviour.m_FuncPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(i * base.uiBehaviour.m_FuncPool.TplWidth), tplPos.y);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject2 = gameObject.transform.FindChild("Recommend").gameObject;
				GameObject gameObject3 = gameObject.transform.FindChild("Noopen").gameObject;
				IXUILabel ixuilabel2 = gameObject.transform.FindChild("Noopen/T").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = gameObject.transform.FindChild("Recommend/Exp").GetComponent("XUILabel") as IXUILabel;
				gameObject2.SetActive(dataItem.IsRecommend);
				ixuilabel3.SetText(dataItem.RecommendTxt);
				gameObject3.SetActive(!dataItem.IsOpen);
				ixuilabel2.SetText(dataItem.TipsTxt);
				ixuisprite.SetSprite(dataItem.IconTxt);
				ixuilabel.SetText(dataItem.NameTxt);
				ixuisprite2.ID = (ulong)((long)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(dataItem.SysId));
				ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.GoToStrengthSys));
			}
		}

		// Token: 0x06010627 RID: 67111 RVA: 0x003FE30C File Offset: 0x003FC50C
		private void FillData()
		{
			for (int i = 0; i < this.DataArray.Length; i++)
			{
				this.SysIsOpen(this.DataArray[i].SysId, ref this.DataArray[i].IsOpen, ref this.DataArray[i].TipsTxt);
			}
			for (int j = 0; j < this.DataArray.Length; j++)
			{
				for (int k = j + 1; k < this.DataArray.Length; k++)
				{
					bool flag = !this.DataArray[j].IsOpen && this.DataArray[k].IsOpen;
					if (flag)
					{
						XBriefLevelupView.DataItem dataItem = this.DataArray[j];
						this.DataArray[j] = this.DataArray[k];
						this.DataArray[k] = dataItem;
					}
				}
			}
		}

		// Token: 0x06010628 RID: 67112 RVA: 0x003FE3E4 File Offset: 0x003FC5E4
		private void SysIsOpen(XSysDefine define, ref bool isOpen, ref string tips)
		{
			bool flag = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened(define);
			if (flag)
			{
				isOpen = false;
				tips = XSingleton<XStringTable>.singleton.GetString("NotOpen");
			}
			else
			{
				if (define <= XSysDefine.XSys_Reward_Activity)
				{
					if (define != XSysDefine.XSys_Level_Elite)
					{
						if (define == XSysDefine.XSys_Reward_Activity)
						{
							bool flag2 = this._activityDoc.IsFinishedAllActivity();
							if (flag2)
							{
								isOpen = false;
								tips = XSingleton<XStringTable>.singleton.GetString("LEVEL_CHALLENGE_FINISH");
								return;
							}
						}
					}
					else
					{
						XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
						int num = specificDocument.GetDayCount(TeamLevelType.TeamLevelAbyss, null);
						bool flag3 = num <= 0;
						if (flag3)
						{
							isOpen = false;
							tips = XSingleton<XStringTable>.singleton.GetString("ERR_TEAM_TOWER_DAYCOUNT");
							return;
						}
						num = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
						bool flag4 = num < XSingleton<XGlobalConfig>.singleton.GetInt("EliteNeedEnergy");
						if (flag4)
						{
							isOpen = false;
							tips = XSingleton<XStringTable>.singleton.GetString("ERR_SCENE_NOFATIGUE");
							return;
						}
					}
				}
				else if (define != XSysDefine.XSys_Activity_Nest)
				{
					if (define == XSysDefine.XSys_GuildDailyTask)
					{
						XTaskDocument specificDocument2 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
						TaskStatus taskStatue = specificDocument2.GetTaskStatue();
						bool flag5 = taskStatue == TaskStatus.TaskStatus_Over;
						if (flag5)
						{
							isOpen = false;
							tips = XSingleton<XStringTable>.singleton.GetString("LEVEL_CHALLENGE_FINISH");
							return;
						}
					}
				}
				else
				{
					XExpeditionDocument specificDocument3 = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
					int num2 = specificDocument3.GetDayCount(TeamLevelType.TeamLevelNest, null);
					bool flag6 = num2 <= 0;
					if (flag6)
					{
						isOpen = false;
						tips = XSingleton<XStringTable>.singleton.GetString("ERR_TEAM_TOWER_DAYCOUNT");
						return;
					}
					num2 = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
					bool flag7 = num2 < XSingleton<XGlobalConfig>.singleton.GetInt("NestNeedEnergy");
					if (flag7)
					{
						isOpen = false;
						tips = XSingleton<XStringTable>.singleton.GetString("ERR_SCENE_NOFATIGUE");
						return;
					}
				}
				isOpen = true;
			}
		}

		// Token: 0x06010629 RID: 67113 RVA: 0x003FE5E4 File Offset: 0x003FC7E4
		private void SetRecommendInfo(int index, ref bool isRecommon, ref string recommonTxt)
		{
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("LevelUpExpText");
			bool flag = string.IsNullOrEmpty(value);
			if (!flag)
			{
				string[] array = value.Split(XGlobalConfig.ListSeparator);
				bool flag2 = array == null;
				if (!flag2)
				{
					int num = 0;
					while (num < array.Length && num < this.DataArray.Length)
					{
						bool flag3 = num != index;
						if (!flag3)
						{
							string[] array2 = array[num].Split(XGlobalConfig.SequenceSeparator);
							bool flag4 = array2 == null;
							if (!flag4)
							{
								bool flag5 = array2.Length != 0;
								if (flag5)
								{
									isRecommon = (array2[0] == "1");
								}
								bool flag6 = array2.Length > 1;
								if (flag6)
								{
									recommonTxt = array2[1];
								}
								break;
							}
						}
						num++;
					}
				}
			}
		}

		// Token: 0x0601062A RID: 67114 RVA: 0x003FE6B4 File Offset: 0x003FC8B4
		private void SetBaseInfo(XSysDefine define, ref string iconTxt, ref string nameTxt)
		{
			FpStrengthenTable.RowData rowData = this._doc.SearchBySysID(define);
			bool flag = rowData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("error,no this data in BQ", "---->", define.ToString(), null, null, null);
			}
			else
			{
				iconTxt = rowData.BQImageID;
				nameTxt = rowData.BQName;
			}
		}

		// Token: 0x0601062B RID: 67115 RVA: 0x003FE710 File Offset: 0x003FC910
		private XBriefLevelupView.DataItem GetDataBySystemId(XSysDefine systemId)
		{
			for (int i = 0; i < this.DataArray.Length; i++)
			{
				bool flag = this.DataArray[i].SysId == systemId;
				if (flag)
				{
					return this.DataArray[i];
				}
			}
			return null;
		}

		// Token: 0x0601062C RID: 67116 RVA: 0x003FE75C File Offset: 0x003FC95C
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601062D RID: 67117 RVA: 0x003FE778 File Offset: 0x003FC978
		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0601062E RID: 67118 RVA: 0x003FE784 File Offset: 0x003FC984
		public void GoToStrengthSys(IXUISprite sp)
		{
			this.SetVisible(false, true);
			XBriefLevelupView.DataItem dataBySystemId = this.GetDataBySystemId((XSysDefine)sp.ID);
			bool flag = dataBySystemId == null || !dataBySystemId.IsOpen;
			if (!flag)
			{
				XSysDefine sysId = dataBySystemId.SysId;
				if (sysId <= XSysDefine.XSys_Reward_Activity)
				{
					if (sysId != XSysDefine.XSys_Level_Elite)
					{
						if (sysId == XSysDefine.XSys_Reward_Activity)
						{
							DlgBase<RewardSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Reward_Activity);
						}
					}
					else
					{
						DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.AutoShowLastChapter(1U, false);
					}
				}
				else if (sysId != XSysDefine.XSys_Activity_Nest)
				{
					if (sysId == XSysDefine.XSys_GuildDailyTask)
					{
						XSingleton<UIManager>.singleton.CloseAllUI();
						XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GuildDailyTask, 0UL);
					}
				}
				else
				{
					XSingleton<XGameSysMgr>.singleton.OpenSystem(dataBySystemId.SysId, 0UL);
				}
			}
		}

		// Token: 0x04007634 RID: 30260
		private XFPStrengthenDocument _doc = null;

		// Token: 0x04007635 RID: 30261
		private XDailyActivitiesDocument _activityDoc = null;

		// Token: 0x04007636 RID: 30262
		public XUIPool m_FpStrengthenPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007637 RID: 30263
		public XUIPool m_FpButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007638 RID: 30264
		private XSysDefine[] _Funcs = new XSysDefine[]
		{
			XSysDefine.XSys_GuildDailyTask,
			XSysDefine.XSys_Reward_Activity,
			XSysDefine.XSys_Level_Elite,
			XSysDefine.XSys_Activity_Nest
		};

		// Token: 0x04007639 RID: 30265
		private XBriefLevelupView.DataItem[] DataArray;

		// Token: 0x02001A1A RID: 6682
		private class DataItem
		{
			// Token: 0x0601113F RID: 69951 RVA: 0x0045843C File Offset: 0x0045663C
			public DataItem(int index)
			{
				this.m_index = index;
			}

			// Token: 0x17003B79 RID: 15225
			// (get) Token: 0x06011140 RID: 69952 RVA: 0x004584A0 File Offset: 0x004566A0
			public int Index
			{
				get
				{
					return this.m_index;
				}
			}

			// Token: 0x0400825D RID: 33373
			private int m_index = 0;

			// Token: 0x0400825E RID: 33374
			public XSysDefine SysId = XSysDefine.XSys_None;

			// Token: 0x0400825F RID: 33375
			public bool IsOpen = false;

			// Token: 0x04008260 RID: 33376
			public bool IsRecommend = false;

			// Token: 0x04008261 RID: 33377
			public string RecommendTxt = "";

			// Token: 0x04008262 RID: 33378
			public string NameTxt = "";

			// Token: 0x04008263 RID: 33379
			public string TipsTxt = "";

			// Token: 0x04008264 RID: 33380
			public string IconTxt = "";
		}
	}
}
