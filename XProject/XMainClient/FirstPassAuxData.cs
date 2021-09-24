using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FirstPassAuxData
	{

		public FirstPassAuxData(FirstPassTable.RowData data)
		{
			this.m_firstPass = data;
		}

		public bool IsCanPrise
		{
			get
			{
				return !this.IsGivedPrise && this.PassTeamCount != 0;
			}
		}

		public uint PriseTotalNum { get; set; }

		public bool IsHadReward
		{
			get
			{
				return !this.IsGetedReward && this.CurRank > 0 && this.CurRank <= FirstPassDocument.Doc.NeedPassTeamCount;
			}
		}

		public int Id
		{
			get
			{
				return this.m_firstPass.ID;
			}
		}

		public int Star
		{
			get
			{
				return this.m_Star;
			}
		}

		public string SceneName
		{
			get
			{
				bool flag = this.m_Star != -1;
				string result;
				if (flag)
				{
					result = this.m_sceneName;
				}
				else
				{
					bool flag2 = this.m_firstPass != null;
					if (flag2)
					{
						result = this.m_firstPass.Des;
					}
					else
					{
						result = "";
					}
				}
				return result;
			}
		}

		public string PassTimeStr
		{
			get
			{
				return this.m_passTimeStr;
			}
		}

		public void SetPassTime(uint time)
		{
			bool flag = time == 0U;
			if (flag)
			{
				this.m_passTimeStr = string.Empty;
			}
			else
			{
				this.m_passTimeStr = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)time, XStringDefineProxy.GetString("FirstPassTeamTime"), true);
			}
		}

		public void SetStar(int star)
		{
			this.m_Star = star + 1;
			bool flag = this.m_firstPass == null;
			if (!flag)
			{
				bool flag2 = this.m_Star != -1;
				if (flag2)
				{
					bool flag3 = this.m_Star <= this.m_firstPass.SceneID.Length && this.m_Star >= 1;
					if (flag3)
					{
						SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(this.m_firstPass.SceneID[this.m_Star - 1]);
						bool flag4 = sceneData != null;
						if (flag4)
						{
							this.m_sceneName = sceneData.Comment;
						}
					}
				}
			}
		}

		public FirstPassTable.RowData FirstPassRow
		{
			get
			{
				return this.m_firstPass;
			}
		}

		public void SetTeamInfoListData(List<UnitAppearance> lst)
		{
			this.m_teamInfoList = lst;
		}

		public List<UnitAppearance> TeamInfoList
		{
			get
			{
				return this.m_teamInfoList;
			}
		}

		public bool IsOpen()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			bool flag = this.m_firstPass == null || this.m_firstPass.SceneID.Length < 1;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)this.m_firstPass.SceneID[0]);
				bool flag2 = sceneData == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					XLevelSealDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					result = (specificDocument2.SealLevel >= (uint)sceneData.RequiredLevel);
				}
			}
			return result;
		}

		public RewardAuxData GetFirstPassReward(int rank)
		{
			for (int i = 0; i < this.PassRewardList.Count; i++)
			{
				bool flag = this.PassRewardList[i].IsInRang(rank);
				if (flag)
				{
					return this.PassRewardList[i];
				}
			}
			return null;
		}

		public List<RewardItemAuxData> PriseRewardDataList
		{
			get
			{
				bool flag = this.m_PriseRewardDataList == null;
				if (flag)
				{
					this.m_PriseRewardDataList = new List<RewardItemAuxData>();
					for (int i = 0; i < this.m_firstPass.CommendReward.Count; i++)
					{
						RewardItemAuxData rewardItemAuxData = new RewardItemAuxData(this.m_firstPass.CommendReward[i, 0], this.m_firstPass.CommendReward[i, 1]);
						bool flag2 = rewardItemAuxData.Id > 0;
						if (flag2)
						{
							this.m_PriseRewardDataList.Add(rewardItemAuxData);
						}
					}
				}
				return this.m_PriseRewardDataList;
			}
		}

		public List<RewardAuxData> PassRewardList
		{
			get
			{
				bool flag = this.m_PassRewardList == null;
				if (flag)
				{
					this.m_PassRewardList = new List<RewardAuxData>();
					for (int i = 0; i < FirstPassDocument.sFirstPassReward.Table.Length; i++)
					{
						bool flag2 = FirstPassDocument.sFirstPassReward.Table[i].ID == this.m_firstPass.RewardID;
						if (flag2)
						{
							RewardAuxData item = new RewardAuxData(FirstPassDocument.sFirstPassReward.Table[i]);
							this.m_PassRewardList.Add(item);
						}
					}
				}
				return this.m_PassRewardList;
			}
		}

		private FirstPassTable.RowData m_firstPass;

		private string m_passTimeStr = string.Empty;

		private List<RewardItemAuxData> m_PriseRewardDataList = null;

		private List<RewardAuxData> m_PassRewardList = null;

		private List<UnitAppearance> m_teamInfoList = null;

		private int m_Star = -1;

		private string m_sceneName = "";

		public int CurRank = 0;

		public int PassTeamCount = 0;

		public bool IsGivedPrise = false;

		public bool IsGetedReward = false;
	}
}
