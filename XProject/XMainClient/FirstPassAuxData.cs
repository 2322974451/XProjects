using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CFF RID: 3327
	internal class FirstPassAuxData
	{
		// Token: 0x0600BA37 RID: 47671 RVA: 0x0025F234 File Offset: 0x0025D434
		public FirstPassAuxData(FirstPassTable.RowData data)
		{
			this.m_firstPass = data;
		}

		// Token: 0x170032C2 RID: 12994
		// (get) Token: 0x0600BA38 RID: 47672 RVA: 0x0025F2A0 File Offset: 0x0025D4A0
		public bool IsCanPrise
		{
			get
			{
				return !this.IsGivedPrise && this.PassTeamCount != 0;
			}
		}

		// Token: 0x170032C3 RID: 12995
		// (get) Token: 0x0600BA39 RID: 47673 RVA: 0x0025F2C6 File Offset: 0x0025D4C6
		// (set) Token: 0x0600BA3A RID: 47674 RVA: 0x0025F2CE File Offset: 0x0025D4CE
		public uint PriseTotalNum { get; set; }

		// Token: 0x170032C4 RID: 12996
		// (get) Token: 0x0600BA3B RID: 47675 RVA: 0x0025F2D8 File Offset: 0x0025D4D8
		public bool IsHadReward
		{
			get
			{
				return !this.IsGetedReward && this.CurRank > 0 && this.CurRank <= FirstPassDocument.Doc.NeedPassTeamCount;
			}
		}

		// Token: 0x170032C5 RID: 12997
		// (get) Token: 0x0600BA3C RID: 47676 RVA: 0x0025F314 File Offset: 0x0025D514
		public int Id
		{
			get
			{
				return this.m_firstPass.ID;
			}
		}

		// Token: 0x170032C6 RID: 12998
		// (get) Token: 0x0600BA3D RID: 47677 RVA: 0x0025F334 File Offset: 0x0025D534
		public int Star
		{
			get
			{
				return this.m_Star;
			}
		}

		// Token: 0x170032C7 RID: 12999
		// (get) Token: 0x0600BA3E RID: 47678 RVA: 0x0025F34C File Offset: 0x0025D54C
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

		// Token: 0x170032C8 RID: 13000
		// (get) Token: 0x0600BA3F RID: 47679 RVA: 0x0025F398 File Offset: 0x0025D598
		public string PassTimeStr
		{
			get
			{
				return this.m_passTimeStr;
			}
		}

		// Token: 0x0600BA40 RID: 47680 RVA: 0x0025F3B0 File Offset: 0x0025D5B0
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

		// Token: 0x0600BA41 RID: 47681 RVA: 0x0025F3F0 File Offset: 0x0025D5F0
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

		// Token: 0x170032C9 RID: 13001
		// (get) Token: 0x0600BA42 RID: 47682 RVA: 0x0025F488 File Offset: 0x0025D688
		public FirstPassTable.RowData FirstPassRow
		{
			get
			{
				return this.m_firstPass;
			}
		}

		// Token: 0x0600BA43 RID: 47683 RVA: 0x0025F4A0 File Offset: 0x0025D6A0
		public void SetTeamInfoListData(List<UnitAppearance> lst)
		{
			this.m_teamInfoList = lst;
		}

		// Token: 0x170032CA RID: 13002
		// (get) Token: 0x0600BA44 RID: 47684 RVA: 0x0025F4AC File Offset: 0x0025D6AC
		public List<UnitAppearance> TeamInfoList
		{
			get
			{
				return this.m_teamInfoList;
			}
		}

		// Token: 0x0600BA45 RID: 47685 RVA: 0x0025F4C4 File Offset: 0x0025D6C4
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

		// Token: 0x0600BA46 RID: 47686 RVA: 0x0025F54C File Offset: 0x0025D74C
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

		// Token: 0x170032CB RID: 13003
		// (get) Token: 0x0600BA47 RID: 47687 RVA: 0x0025F5A4 File Offset: 0x0025D7A4
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

		// Token: 0x170032CC RID: 13004
		// (get) Token: 0x0600BA48 RID: 47688 RVA: 0x0025F644 File Offset: 0x0025D844
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

		// Token: 0x04004A78 RID: 19064
		private FirstPassTable.RowData m_firstPass;

		// Token: 0x04004A79 RID: 19065
		private string m_passTimeStr = string.Empty;

		// Token: 0x04004A7A RID: 19066
		private List<RewardItemAuxData> m_PriseRewardDataList = null;

		// Token: 0x04004A7B RID: 19067
		private List<RewardAuxData> m_PassRewardList = null;

		// Token: 0x04004A7C RID: 19068
		private List<UnitAppearance> m_teamInfoList = null;

		// Token: 0x04004A7D RID: 19069
		private int m_Star = -1;

		// Token: 0x04004A7E RID: 19070
		private string m_sceneName = "";

		// Token: 0x04004A7F RID: 19071
		public int CurRank = 0;

		// Token: 0x04004A80 RID: 19072
		public int PassTeamCount = 0;

		// Token: 0x04004A81 RID: 19073
		public bool IsGivedPrise = false;

		// Token: 0x04004A82 RID: 19074
		public bool IsGetedReward = false;
	}
}
