using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBriefLevelupView : DlgBase<XBriefLevelupView, XBriefLevelupBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/BriefLevelupDlg";
			}
		}

		public override int group
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

		protected override void OnShow()
		{
			base.OnShow();
			this._activityDoc.QueryDailyActivityData();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Close2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

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

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

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

		private XFPStrengthenDocument _doc = null;

		private XDailyActivitiesDocument _activityDoc = null;

		public XUIPool m_FpStrengthenPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_FpButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XSysDefine[] _Funcs = new XSysDefine[]
		{
			XSysDefine.XSys_GuildDailyTask,
			XSysDefine.XSys_Reward_Activity,
			XSysDefine.XSys_Level_Elite,
			XSysDefine.XSys_Activity_Nest
		};

		private XBriefLevelupView.DataItem[] DataArray;

		private class DataItem
		{

			public DataItem(int index)
			{
				this.m_index = index;
			}

			public int Index
			{
				get
				{
					return this.m_index;
				}
			}

			private int m_index = 0;

			public XSysDefine SysId = XSysDefine.XSys_None;

			public bool IsOpen = false;

			public bool IsRecommend = false;

			public string RecommendTxt = "";

			public string NameTxt = "";

			public string TipsTxt = "";

			public string IconTxt = "";
		}
	}
}
