using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAchievementDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XAchievementDocument.uuID;
			}
		}

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

		public bool Monday { get; private set; }

		public static void Execute(OnLoadedCallback callback = null)
		{
			XAchievementDocument.AsyncLoader.AddTask("Table/AchivementList", XAchievementDocument._reader, false);
			XAchievementDocument.AsyncLoader.Execute(callback);
		}

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

		public AchivementTable.RowData GetAchivementData(uint aid)
		{
			return XAchievementDocument._reader.GetByAchievementID((int)aid);
		}

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

		public void FetchAchivement(uint achivementID)
		{
			RpcC2G_FetchAchivementReward rpcC2G_FetchAchivementReward = new RpcC2G_FetchAchivementReward();
			rpcC2G_FetchAchivementReward.oArg.AchivementID = achivementID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_FetchAchivementReward);
		}

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

		public void SendWeekShareSuccess(uint sceneID)
		{
			XSingleton<XDebug>.singleton.AddLog("SendWeekShareSuccess", null, null, null, null, null, XDebugColor.XDebug_None);
			PtcC2G_NotifyPlatShareResult ptcC2G_NotifyPlatShareResult = new PtcC2G_NotifyPlatShareResult();
			ptcC2G_NotifyPlatShareResult.Data.scene_id = sceneID;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_NotifyPlatShareResult);
		}

		public void DisappearMonday()
		{
			this.Monday = true;
			PtcC2G_NotifyPlatShareResult ptcC2G_NotifyPlatShareResult = new PtcC2G_NotifyPlatShareResult();
			ptcC2G_NotifyPlatShareResult.Data.scene_id = 1U;
			ptcC2G_NotifyPlatShareResult.Data.redpoint_disappear = true;
			XSingleton<XClientNetwork>.singleton.Send(ptcC2G_NotifyPlatShareResult);
		}

		public void SendToGetWeekShareReward()
		{
			RpcC2G_GetPlatShareAward rpc = new RpcC2G_GetPlatShareAward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AchievementDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static AchivementTable _reader = new AchivementTable();

		public Dictionary<uint, uint> achivement = new Dictionary<uint, uint>();

		private XAchievementView _AchievementView = null;

		private XLifeTargetView _LifeTargetView = null;

		private XMainInterface _HallMainView = null;

		private XServerActivityView _serverActivityView = null;

		private XRewardLevelView _rewardLevelView = null;

		private WeekShareRewardHandler _shareHandler = null;

		private uint _firstPassSceneID = 0U;

		public static int ServerActivityCatergoryBound = 500;

		public Dictionary<int, List<int>> _ServerActivitys = new Dictionary<int, List<int>>();

		public Dictionary<int, string> _CatergoryStrings = new Dictionary<int, string>();

		private int _levelRewardPacksCatergory = 0;

		private bool _hasWeekReward = false;
	}
}
