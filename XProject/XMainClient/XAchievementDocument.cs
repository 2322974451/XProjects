using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009D4 RID: 2516
	internal class XAchievementDocument : XDocComponent
	{
		// Token: 0x17002DC2 RID: 11714
		// (get) Token: 0x060098FC RID: 39164 RVA: 0x0017C9F8 File Offset: 0x0017ABF8
		public override uint ID
		{
			get
			{
				return XAchievementDocument.uuID;
			}
		}

		// Token: 0x17002DC3 RID: 11715
		// (get) Token: 0x060098FD RID: 39165 RVA: 0x0017CA10 File Offset: 0x0017AC10
		// (set) Token: 0x060098FE RID: 39166 RVA: 0x0017CA28 File Offset: 0x0017AC28
		public XAchievementView AchievementView
		{
			get
			{
				return this._AchievementView;
			}
			set
			{
				this._AchievementView = value;
			}
		}

		// Token: 0x17002DC4 RID: 11716
		// (get) Token: 0x060098FF RID: 39167 RVA: 0x0017CA34 File Offset: 0x0017AC34
		// (set) Token: 0x06009900 RID: 39168 RVA: 0x0017CA4C File Offset: 0x0017AC4C
		public XLifeTargetView LifeTargetView
		{
			get
			{
				return this._LifeTargetView;
			}
			set
			{
				this._LifeTargetView = value;
			}
		}

		// Token: 0x17002DC5 RID: 11717
		// (get) Token: 0x06009901 RID: 39169 RVA: 0x0017CA58 File Offset: 0x0017AC58
		// (set) Token: 0x06009902 RID: 39170 RVA: 0x0017CA70 File Offset: 0x0017AC70
		public XMainInterface HallMainView
		{
			get
			{
				return this._HallMainView;
			}
			set
			{
				this._HallMainView = value;
			}
		}

		// Token: 0x17002DC6 RID: 11718
		// (get) Token: 0x06009903 RID: 39171 RVA: 0x0017CA7C File Offset: 0x0017AC7C
		// (set) Token: 0x06009904 RID: 39172 RVA: 0x0017CA94 File Offset: 0x0017AC94
		public XServerActivityView ServerActivityView
		{
			get
			{
				return this._serverActivityView;
			}
			set
			{
				this._serverActivityView = value;
			}
		}

		// Token: 0x17002DC7 RID: 11719
		// (get) Token: 0x06009905 RID: 39173 RVA: 0x0017CAA0 File Offset: 0x0017ACA0
		// (set) Token: 0x06009906 RID: 39174 RVA: 0x0017CAB8 File Offset: 0x0017ACB8
		public XRewardLevelView RewardLevelView
		{
			get
			{
				return this._rewardLevelView;
			}
			set
			{
				this._rewardLevelView = value;
			}
		}

		// Token: 0x17002DC8 RID: 11720
		// (get) Token: 0x06009907 RID: 39175 RVA: 0x0017CAC4 File Offset: 0x0017ACC4
		// (set) Token: 0x06009908 RID: 39176 RVA: 0x0017CADC File Offset: 0x0017ACDC
		public WeekShareRewardHandler ShareHandler
		{
			get
			{
				return this._shareHandler;
			}
			set
			{
				this._shareHandler = value;
			}
		}

		// Token: 0x17002DC9 RID: 11721
		// (get) Token: 0x06009909 RID: 39177 RVA: 0x0017CAE8 File Offset: 0x0017ACE8
		// (set) Token: 0x0600990A RID: 39178 RVA: 0x0017CB00 File Offset: 0x0017AD00
		public uint FirstPassSceneID
		{
			get
			{
				return this._firstPassSceneID;
			}
			set
			{
				this._firstPassSceneID = value;
			}
		}

		// Token: 0x17002DCA RID: 11722
		// (get) Token: 0x0600990B RID: 39179 RVA: 0x0017CB0C File Offset: 0x0017AD0C
		// (set) Token: 0x0600990C RID: 39180 RVA: 0x0017CB24 File Offset: 0x0017AD24
		public bool HasWeekReward
		{
			get
			{
				return this._hasWeekReward;
			}
			private set
			{
				this._hasWeekReward = value;
			}
		}

		// Token: 0x17002DCB RID: 11723
		// (get) Token: 0x0600990D RID: 39181 RVA: 0x0017CB2E File Offset: 0x0017AD2E
		// (set) Token: 0x0600990E RID: 39182 RVA: 0x0017CB36 File Offset: 0x0017AD36
		public bool Monday { get; private set; }

		// Token: 0x0600990F RID: 39183 RVA: 0x0017CB3F File Offset: 0x0017AD3F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XAchievementDocument.AsyncLoader.AddTask("Table/AchivementList", XAchievementDocument._reader, false);
			XAchievementDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009910 RID: 39184 RVA: 0x0017CB64 File Offset: 0x0017AD64
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this._levelRewardPacksCatergory = -1;
			for (int i = 0; i < XAchievementDocument._reader.Table.Length; i++)
			{
				AchivementTable.RowData rowData = XAchievementDocument._reader.Table[i];
				bool flag = rowData.AchievementCategory < XAchievementDocument.ServerActivityCatergoryBound;
				if (!flag)
				{
					bool flag2 = !this._ServerActivitys.ContainsKey(rowData.AchievementCategory);
					if (flag2)
					{
						this._ServerActivitys.Add(rowData.AchievementCategory, new List<int>());
						this._ServerActivitys[rowData.AchievementCategory].Add(rowData.AchievementID);
					}
					else
					{
						this._ServerActivitys[rowData.AchievementCategory].Add(rowData.AchievementID);
					}
					bool flag3 = !this._CatergoryStrings.ContainsKey(rowData.AchievementCategory);
					if (flag3)
					{
						this._CatergoryStrings.Add(rowData.AchievementCategory, rowData.AchievementName);
					}
					bool flag4 = this._levelRewardPacksCatergory == -1;
					if (flag4)
					{
						bool flag5 = rowData.AchievementName == "djlb_";
						if (flag5)
						{
							this._levelRewardPacksCatergory = rowData.AchievementCategory;
						}
					}
				}
			}
		}

		// Token: 0x06009911 RID: 39185 RVA: 0x0017CCA4 File Offset: 0x0017AEA4
		public void InitAchivement(List<StcAchieveInfo> list)
		{
			this.achivement.Clear();
			bool flag = list == null;
			if (!flag)
			{
				for (int i = 0; i < list.Count; i++)
				{
					this.achivement.Add(list[i].achieveID, list[i].rewardStatus);
				}
			}
		}

		// Token: 0x06009912 RID: 39186 RVA: 0x0017CD04 File Offset: 0x0017AF04
		public void SetAchivementState(uint aid, uint state)
		{
			this.achivement[aid] = state;
			bool flag = this._AchievementView != null && this._AchievementView.active;
			if (flag)
			{
				this._AchievementView.RefreshAchivementList();
			}
			bool flag2 = this._LifeTargetView != null && this._LifeTargetView.IsVisible();
			if (flag2)
			{
				this._LifeTargetView.RefreshList();
			}
			bool flag3 = this._serverActivityView != null && this._serverActivityView.IsVisible();
			if (flag3)
			{
				this._serverActivityView.RefreshList();
			}
			bool flag4 = this.RewardLevelView != null && this.RewardLevelView.IsVisible();
			if (flag4)
			{
				this.RewardLevelView.RefreshList();
			}
		}

		// Token: 0x06009913 RID: 39187 RVA: 0x0017CDB8 File Offset: 0x0017AFB8
		public AchivementState GetAchivementState(uint aid)
		{
			uint num;
			bool flag = this.achivement.TryGetValue(aid, out num);
			AchivementState result;
			if (flag)
			{
				result = (AchivementState)num;
			}
			else
			{
				result = AchivementState.Not_Achive;
			}
			return result;
		}

		// Token: 0x06009914 RID: 39188 RVA: 0x0017CDE4 File Offset: 0x0017AFE4
		public AchivementTable.RowData GetAchivementData(uint aid)
		{
			return XAchievementDocument._reader.GetByAchievementID((int)aid);
		}

		// Token: 0x06009915 RID: 39189 RVA: 0x0017CE04 File Offset: 0x0017B004
		public int GetAchivementFatigue(uint aid)
		{
			int num = 0;
			AchivementTable.RowData byAchievementID = XAchievementDocument._reader.GetByAchievementID((int)aid);
			bool flag = byAchievementID != null;
			if (flag)
			{
				for (int i = 0; i < (int)byAchievementID.AchievementItem.count; i++)
				{
					bool flag2 = byAchievementID.AchievementItem[i, 0] == XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FATIGUE);
					if (flag2)
					{
						num += byAchievementID.AchievementItem[i, 1];
					}
				}
			}
			return num;
		}

		// Token: 0x06009916 RID: 39190 RVA: 0x0017CE7C File Offset: 0x0017B07C
		public bool HasCompleteAchivement(XSysDefine sys = XSysDefine.XSys_Reward_Achivement)
		{
			bool flag = sys == XSysDefine.XSys_LevelReward;
			bool result;
			if (flag)
			{
				result = this.HasCompleteAchivement(this._levelRewardPacksCatergory);
			}
			else
			{
				foreach (KeyValuePair<uint, uint> keyValuePair in this.achivement)
				{
					AchivementTable.RowData byAchievementID = XAchievementDocument._reader.GetByAchievementID((int)keyValuePair.Key);
					bool flag2 = byAchievementID != null;
					if (flag2)
					{
						bool flag3 = byAchievementID.AchievementCategory != this._levelRewardPacksCatergory;
						if (flag3)
						{
							bool flag4 = sys == XSysDefine.XSys_Reward_Achivement;
							if (flag4)
							{
								bool flag5 = byAchievementID.AchievementCategory < XAchievementDocument.ServerActivityCatergoryBound && keyValuePair.Value == 3U;
								if (flag5)
								{
									return true;
								}
							}
							bool flag6 = sys == XSysDefine.XSys_ServerActivity;
							if (flag6)
							{
								bool flag7 = byAchievementID.AchievementCategory >= XAchievementDocument.ServerActivityCatergoryBound && keyValuePair.Value == 3U;
								if (flag7)
								{
									return true;
								}
							}
						}
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06009917 RID: 39191 RVA: 0x0017CF9C File Offset: 0x0017B19C
		public bool HasCompleteAchivement(int catergory)
		{
			foreach (KeyValuePair<uint, uint> keyValuePair in this.achivement)
			{
				AchivementTable.RowData byAchievementID = XAchievementDocument._reader.GetByAchievementID((int)keyValuePair.Key);
				bool flag = byAchievementID != null && byAchievementID.AchievementCategory == catergory && keyValuePair.Value == 3U;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009918 RID: 39192 RVA: 0x0017D02C File Offset: 0x0017B22C
		public void FetchAchivement(uint achivementID)
		{
			RpcC2G_FetchAchivementReward rpcC2G_FetchAchivementReward = new RpcC2G_FetchAchivementReward();
			rpcC2G_FetchAchivementReward.oArg.AchivementID = achivementID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_FetchAchivementReward);
		}

		// Token: 0x06009919 RID: 39193 RVA: 0x0017D05C File Offset: 0x0017B25C
		public void UpdateShowingAchivementList(ref List<uint> Achived, ref List<uint> NotAchived)
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			foreach (AchivementTable.RowData rowData in XAchievementDocument._reader.Table)
			{
				bool flag = (ulong)level < (ulong)((long)rowData.AchievementLevel);
				if (!flag)
				{
					bool flag2 = rowData.AchievementCategory >= XAchievementDocument.ServerActivityCatergoryBound;
					if (!flag2)
					{
						AchivementState achivementState = this.GetAchivementState((uint)rowData.AchievementID);
						bool flag3 = achivementState != AchivementState.Fetched;
						if (flag3)
						{
							uint num = 0U;
							bool flag4 = dictionary.TryGetValue((uint)rowData.AchievementCategory, out num);
							if (flag4)
							{
								AchivementState achivementState2 = this.GetAchivementState(dictionary[(uint)rowData.AchievementCategory]);
								bool flag5 = achivementState == AchivementState.Achive_NoFetch;
								if (flag5)
								{
									bool flag6 = achivementState2 != AchivementState.Achive_NoFetch || num >= (uint)rowData.AchievementID;
									if (flag6)
									{
										dictionary[(uint)rowData.AchievementCategory] = (uint)rowData.AchievementID;
									}
								}
							}
							else
							{
								dictionary.Add((uint)rowData.AchievementCategory, (uint)rowData.AchievementID);
							}
						}
					}
				}
			}
			foreach (KeyValuePair<uint, uint> keyValuePair in dictionary)
			{
				AchivementState achivementState3 = this.GetAchivementState(keyValuePair.Value);
				bool flag7 = achivementState3 == AchivementState.Achive_NoFetch;
				if (flag7)
				{
					Achived.Add(keyValuePair.Value);
				}
				bool flag8 = achivementState3 == AchivementState.Not_Achive;
				if (flag8)
				{
					NotAchived.Add(keyValuePair.Value);
				}
			}
		}

		// Token: 0x0600991A RID: 39194 RVA: 0x0017D20C File Offset: 0x0017B40C
		public void UpdateShowingAchivementListWithoutMergeType(ref List<uint> Achived, ref List<uint> NotAchived)
		{
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			foreach (AchivementTable.RowData rowData in XAchievementDocument._reader.Table)
			{
				bool flag = (ulong)level < (ulong)((long)rowData.AchievementLevel);
				if (!flag)
				{
					bool flag2 = rowData.AchievementCategory >= XAchievementDocument.ServerActivityCatergoryBound;
					if (!flag2)
					{
						AchivementState achivementState = this.GetAchivementState((uint)rowData.AchievementID);
						bool flag3 = achivementState != AchivementState.Fetched;
						if (flag3)
						{
							bool flag4 = achivementState == AchivementState.Achive_NoFetch;
							if (flag4)
							{
								Achived.Add((uint)rowData.AchievementID);
							}
							bool flag5 = achivementState == AchivementState.Not_Achive;
							if (flag5)
							{
								NotAchived.Add((uint)rowData.AchievementID);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600991B RID: 39195 RVA: 0x0017D2DC File Offset: 0x0017B4DC
		public AchivementTable.RowData GetFirstLifeTarget(out AchivementState ltState)
		{
			AchivementTable.RowData rowData = null;
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			foreach (AchivementTable.RowData rowData2 in XAchievementDocument._reader.Table)
			{
				bool flag = (ulong)level < (ulong)((long)rowData2.AchievementLevel);
				if (!flag)
				{
					bool flag2 = rowData2.AchievementCategory != 1;
					if (!flag2)
					{
						AchivementState achivementState = this.GetAchivementState((uint)rowData2.AchievementID);
						bool flag3 = achivementState != AchivementState.Fetched;
						if (flag3)
						{
							bool flag4 = achivementState == AchivementState.Achive_NoFetch;
							if (flag4)
							{
								rowData = rowData2;
								ltState = achivementState;
								return rowData;
							}
							bool flag5 = achivementState == AchivementState.Not_Achive && rowData == null;
							if (flag5)
							{
								ltState = achivementState;
								rowData = rowData2;
							}
						}
					}
				}
			}
			ltState = AchivementState.Not_Achive;
			return rowData;
		}

		// Token: 0x0600991C RID: 39196 RVA: 0x0017D3B0 File Offset: 0x0017B5B0
		public List<int> GetCatergoryActivity(int catergoryID)
		{
			List<int> list = new List<int>();
			bool flag = this._ServerActivitys.TryGetValue(catergoryID, out list);
			List<int> result;
			if (flag)
			{
				result = list;
			}
			else
			{
				result = list;
			}
			return result;
		}

		// Token: 0x0600991D RID: 39197 RVA: 0x0017D3E0 File Offset: 0x0017B5E0
		public void GetAllCatergory(ref List<int> CatergoryIDs, ref List<string> CatergoryStrings)
		{
			foreach (KeyValuePair<int, List<int>> keyValuePair in this._ServerActivitys)
			{
				bool flag = keyValuePair.Key != this._levelRewardPacksCatergory && keyValuePair.Key != 505;
				if (flag)
				{
					CatergoryIDs.Add(keyValuePair.Key);
					CatergoryStrings.Add(this._CatergoryStrings[keyValuePair.Key]);
				}
			}
		}

		// Token: 0x0600991E RID: 39198 RVA: 0x0017D484 File Offset: 0x0017B684
		public void GetLevelRewardCatergory(ref List<int> CatergoryIDs, ref List<string> CatergoryStrings)
		{
			foreach (KeyValuePair<int, List<int>> keyValuePair in this._ServerActivitys)
			{
				bool flag = keyValuePair.Key == this._levelRewardPacksCatergory;
				if (flag)
				{
					CatergoryIDs.Add(keyValuePair.Key);
					CatergoryStrings.Add(this._CatergoryStrings[keyValuePair.Key]);
					break;
				}
			}
		}

		// Token: 0x0600991F RID: 39199 RVA: 0x0017D514 File Offset: 0x0017B714
		public void SetOpenServerActivityTime(uint second)
		{
			bool flag = this._serverActivityView != null && this._serverActivityView.IsVisible();
			if (flag)
			{
				this._serverActivityView.SetRemainTime(second);
			}
			bool flag2 = this.RewardLevelView != null && this.RewardLevelView.IsVisible();
			if (flag2)
			{
				this.RewardLevelView.SetRemainTime(second);
			}
		}

		// Token: 0x06009920 RID: 39200 RVA: 0x0017D570 File Offset: 0x0017B770
		public void UpdateShareRewardsInfo(PlatformShareAwardPara data)
		{
			bool flag = data != null;
			if (flag)
			{
				this.FirstPassSceneID = data.share_scene_id;
				this.HasWeekReward = data.weekly_award;
				this.Monday = data.disappear_redpoint;
				bool flag2 = this._shareHandler != null && this._shareHandler.IsVisible();
				if (flag2)
				{
					this._shareHandler.RefreshUI();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_WeekShareReward, true);
			}
		}

		// Token: 0x06009921 RID: 39201 RVA: 0x0017D5E4 File Offset: 0x0017B7E4
		public void SendWeekShareSuccess(uint sceneID)
		{
			XSingleton<XDebug>.singleton.AddLog("SendWeekShareSuccess", null, null, null, null, null, XDebugColor.XDebug_None);
			PtcC2G_NotifyPlatShareResult ptcC2G_NotifyPlatShareResult = new PtcC2G_NotifyPlatShareResult();
			ptcC2G_NotifyPlatShareResult.Data.scene_id = sceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_NotifyPlatShareResult);
		}

		// Token: 0x06009922 RID: 39202 RVA: 0x0017D62C File Offset: 0x0017B82C
		public void DisappearMonday()
		{
			this.Monday = true;
			PtcC2G_NotifyPlatShareResult ptcC2G_NotifyPlatShareResult = new PtcC2G_NotifyPlatShareResult();
			ptcC2G_NotifyPlatShareResult.Data.scene_id = 1U;
			ptcC2G_NotifyPlatShareResult.Data.redpoint_disappear = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_NotifyPlatShareResult);
		}

		// Token: 0x06009923 RID: 39203 RVA: 0x0017D670 File Offset: 0x0017B870
		public void SendToGetWeekShareReward()
		{
			RpcC2G_GetPlatShareAward rpc = new RpcC2G_GetPlatShareAward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009924 RID: 39204 RVA: 0x0017D690 File Offset: 0x0017B890
		public void OnGetPlatShareAward()
		{
			this._hasWeekReward = false;
			bool flag = this._shareHandler != null && this._shareHandler.IsVisible();
			if (flag)
			{
				this._shareHandler.RefreshBtnState();
			}
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_WeekShareReward, true);
		}

		// Token: 0x06009925 RID: 39205 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04003470 RID: 13424
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AchievementDocument");

		// Token: 0x04003471 RID: 13425
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003472 RID: 13426
		private static AchivementTable _reader = new AchivementTable();

		// Token: 0x04003473 RID: 13427
		public Dictionary<uint, uint> achivement = new Dictionary<uint, uint>();

		// Token: 0x04003474 RID: 13428
		private XAchievementView _AchievementView = null;

		// Token: 0x04003475 RID: 13429
		private XLifeTargetView _LifeTargetView = null;

		// Token: 0x04003476 RID: 13430
		private XMainInterface _HallMainView = null;

		// Token: 0x04003477 RID: 13431
		private XServerActivityView _serverActivityView = null;

		// Token: 0x04003478 RID: 13432
		private XRewardLevelView _rewardLevelView = null;

		// Token: 0x04003479 RID: 13433
		private WeekShareRewardHandler _shareHandler = null;

		// Token: 0x0400347A RID: 13434
		private uint _firstPassSceneID = 0U;

		// Token: 0x0400347C RID: 13436
		public static int ServerActivityCatergoryBound = 500;

		// Token: 0x0400347D RID: 13437
		public Dictionary<int, List<int>> _ServerActivitys = new Dictionary<int, List<int>>();

		// Token: 0x0400347E RID: 13438
		public Dictionary<int, string> _CatergoryStrings = new Dictionary<int, string>();

		// Token: 0x0400347F RID: 13439
		private int _levelRewardPacksCatergory = 0;

		// Token: 0x04003480 RID: 13440
		private bool _hasWeekReward = false;
	}
}
