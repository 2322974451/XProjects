using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D5 RID: 2261
	internal class XDragonNestDocument : XDocComponent
	{
		// Token: 0x17002AC4 RID: 10948
		// (get) Token: 0x0600890D RID: 35085 RVA: 0x0011E590 File Offset: 0x0011C790
		public override uint ID
		{
			get
			{
				return XDragonNestDocument.uuID;
			}
		}

		// Token: 0x17002AC5 RID: 10949
		// (get) Token: 0x0600890E RID: 35086 RVA: 0x0011E5A8 File Offset: 0x0011C7A8
		// (set) Token: 0x0600890F RID: 35087 RVA: 0x0011E5C0 File Offset: 0x0011C7C0
		public uint CurrentType
		{
			get
			{
				return this._current_type;
			}
			set
			{
				this._current_type = value;
			}
		}

		// Token: 0x17002AC6 RID: 10950
		// (get) Token: 0x06008910 RID: 35088 RVA: 0x0011E5CC File Offset: 0x0011C7CC
		// (set) Token: 0x06008911 RID: 35089 RVA: 0x0011E5E4 File Offset: 0x0011C7E4
		public uint CurrentDiff
		{
			get
			{
				return this._current_diff;
			}
			set
			{
				this._current_diff = value;
			}
		}

		// Token: 0x17002AC7 RID: 10951
		// (get) Token: 0x06008912 RID: 35090 RVA: 0x0011E5F0 File Offset: 0x0011C7F0
		// (set) Token: 0x06008913 RID: 35091 RVA: 0x0011E608 File Offset: 0x0011C808
		public uint CurrentExpID
		{
			get
			{
				return this._current_expid;
			}
			set
			{
				this._current_expid = value;
			}
		}

		// Token: 0x17002AC8 RID: 10952
		// (get) Token: 0x06008914 RID: 35092 RVA: 0x0011E614 File Offset: 0x0011C814
		// (set) Token: 0x06008915 RID: 35093 RVA: 0x0011E62C File Offset: 0x0011C82C
		public DragonWeakType CurrentWeakType
		{
			get
			{
				return this._current_weak_type;
			}
			set
			{
				this._current_weak_type = value;
			}
		}

		// Token: 0x17002AC9 RID: 10953
		// (get) Token: 0x06008916 RID: 35094 RVA: 0x0011E638 File Offset: 0x0011C838
		// (set) Token: 0x06008917 RID: 35095 RVA: 0x0011E650 File Offset: 0x0011C850
		public int CurrentWeakState
		{
			get
			{
				return this._current_weak_state;
			}
			set
			{
				this._current_weak_state = value;
			}
		}

		// Token: 0x17002ACA RID: 10954
		// (get) Token: 0x06008918 RID: 35096 RVA: 0x0011E65C File Offset: 0x0011C85C
		public int DragonNestBOSSWave
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("DragonNestBOSSWave");
			}
		}

		// Token: 0x06008919 RID: 35097 RVA: 0x0011E67D File Offset: 0x0011C87D
		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonNestDocument.AsyncLoader.AddTask("Table/DragonNestList", XDragonNestDocument.m_DragonNestTable, false);
			XDragonNestDocument.AsyncLoader.AddTask("Table/DragonNestType", XDragonNestDocument.m_DragonNestTypeTable, false);
			XDragonNestDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600891A RID: 35098 RVA: 0x0011E6B8 File Offset: 0x0011C8B8
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SetDragonNestInfo(null);
			}
		}

		// Token: 0x0600891B RID: 35099 RVA: 0x0011E6F0 File Offset: 0x0011C8F0
		public DragonNestType.RowData[] GetDragonNestTypeList()
		{
			return XDragonNestDocument.m_DragonNestTypeTable.Table;
		}

		// Token: 0x0600891C RID: 35100 RVA: 0x0011E70C File Offset: 0x0011C90C
		public DragonNestType.RowData GetDragonNestTypeDataByID(uint id)
		{
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTypeTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTypeTable.Table[i].DragonNestType == id;
				if (flag)
				{
					return XDragonNestDocument.m_DragonNestTypeTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600891D RID: 35101 RVA: 0x0011E764 File Offset: 0x0011C964
		public int GetDragonNestRewardlessLevel(uint id)
		{
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestID == id;
				if (flag)
				{
					return (XDragonNestDocument.m_DragonNestTable.Table[i].MaxDragonDropLevel == 0) ? 1000000000 : XDragonNestDocument.m_DragonNestTable.Table[i].MaxDragonDropLevel;
				}
			}
			return 1000000000;
		}

		// Token: 0x0600891E RID: 35102 RVA: 0x0011E7E0 File Offset: 0x0011C9E0
		public List<DragonNestTable.RowData> GetDragonNestListByTypeAndDiff(uint type, uint diff)
		{
			List<DragonNestTable.RowData> list = new List<DragonNestTable.RowData>();
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestType == type && XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestDifficulty == diff;
				if (flag)
				{
					list.Add(XDragonNestDocument.m_DragonNestTable.Table[i]);
				}
			}
			return list;
		}

		// Token: 0x0600891F RID: 35103 RVA: 0x0011E85C File Offset: 0x0011CA5C
		public DragonNestTable.RowData GetDragonNestByTypeAndDiffAndWave(uint type, uint diff, uint wave)
		{
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestType == type && XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestDifficulty == diff && XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestWave == wave;
				if (flag)
				{
					return XDragonNestDocument.m_DragonNestTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06008920 RID: 35104 RVA: 0x0011E8E0 File Offset: 0x0011CAE0
		public DragonNestTable.RowData GetDragonNestByID(uint id)
		{
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestID == id;
				if (flag)
				{
					return XDragonNestDocument.m_DragonNestTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x06008921 RID: 35105 RVA: 0x0011E938 File Offset: 0x0011CB38
		public bool CheckLock(uint type, uint diff)
		{
			for (int i = 0; i < this.DragonNestDataList.Count; i++)
			{
				bool flag = this.DragonNestDataList[i].Type == type && this.DragonNestDataList[i].Diff == diff;
				if (flag)
				{
					return this.DragonNestDataList[i].IsLocked;
				}
			}
			return true;
		}

		// Token: 0x06008922 RID: 35106 RVA: 0x0011E9AC File Offset: 0x0011CBAC
		public uint CheckWave(uint type, uint diff)
		{
			for (int i = 0; i < this.DragonNestDataList.Count; i++)
			{
				bool flag = this.DragonNestDataList[i].Type == type && this.DragonNestDataList[i].Diff == diff;
				if (flag)
				{
					return this.DragonNestDataList[i].Wave;
				}
			}
			return 0U;
		}

		// Token: 0x06008923 RID: 35107 RVA: 0x0011EA20 File Offset: 0x0011CC20
		public int GetWeakState(uint type, uint diff)
		{
			for (int i = 0; i < this.DragonNestDataList.Count; i++)
			{
				bool flag = this.DragonNestDataList[i].Type == type && this.DragonNestDataList[i].Diff == diff;
				if (flag)
				{
					return this.DragonNestDataList[i].WeakState;
				}
			}
			return -1;
		}

		// Token: 0x06008924 RID: 35108 RVA: 0x0011EA94 File Offset: 0x0011CC94
		public DragonWeakType GetWeakType(uint type, uint diff)
		{
			for (int i = 0; i < this.DragonNestDataList.Count; i++)
			{
				bool flag = this.DragonNestDataList[i].Type == type && this.DragonNestDataList[i].Diff == diff;
				if (flag)
				{
					return this.DragonNestDataList[i].WeakType;
				}
			}
			return DragonWeakType.DragonWeakType_Null;
		}

		// Token: 0x06008925 RID: 35109 RVA: 0x0011EB08 File Offset: 0x0011CD08
		public bool CheckCanFightByExpID(uint expid)
		{
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestID == expid;
				if (flag)
				{
					num = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestType;
					num2 = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestDifficulty;
					num3 = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestWave;
					break;
				}
			}
			for (int j = 0; j < this.DragonNestDataList.Count; j++)
			{
				bool flag2 = this.DragonNestDataList[j].Type == num && this.DragonNestDataList[j].Diff == num2;
				if (flag2)
				{
					return num3 == this.DragonNestDataList[j].Wave;
				}
			}
			return false;
		}

		// Token: 0x06008926 RID: 35110 RVA: 0x0011EC04 File Offset: 0x0011CE04
		public bool CheckIsOpenByExpID(uint expid)
		{
			uint num = 0U;
			uint num2 = 0U;
			uint num3 = 0U;
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTable.Table.Length; i++)
			{
				bool flag = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestID == expid;
				if (flag)
				{
					num = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestType;
					num2 = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestDifficulty;
					num3 = XDragonNestDocument.m_DragonNestTable.Table[i].DragonNestWave;
					break;
				}
			}
			for (int j = 0; j < this.DragonNestDataList.Count; j++)
			{
				bool flag2 = this.DragonNestDataList[j].Type == num && this.DragonNestDataList[j].Diff == num2;
				if (flag2)
				{
					return num3 <= this.DragonNestDataList[j].Wave;
				}
			}
			return false;
		}

		// Token: 0x06008927 RID: 35111 RVA: 0x0011ED04 File Offset: 0x0011CF04
		public XDragonNestDocument.DragonNestData GetDragonNestData(uint type, uint diff)
		{
			for (int i = 0; i < this.DragonNestDataList.Count; i++)
			{
				bool flag = this.DragonNestDataList[i].Type == type && this.DragonNestDataList[i].Diff == diff;
				if (flag)
				{
					return this.DragonNestDataList[i];
				}
			}
			return null;
		}

		// Token: 0x06008928 RID: 35112 RVA: 0x0011ED72 File Offset: 0x0011CF72
		public void ResetData()
		{
			this._current_type = 1U;
			this._current_diff = 0U;
			this._current_expid = this.GetDragonNestByTypeAndDiffAndWave(1U, 0U, 1U).DragonNestID;
		}

		// Token: 0x06008929 RID: 35113 RVA: 0x0011ED98 File Offset: 0x0011CF98
		public void SendReqDragonNestInfo()
		{
			RpcC2G_GetDragonTopInfo rpc = new RpcC2G_GetDragonTopInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600892A RID: 35114 RVA: 0x0011EDB8 File Offset: 0x0011CFB8
		public void SetDragonNestInfo(List<DragonInfo2Client> data)
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			this.DragonNestDataList.Clear();
			for (int i = 0; i < XDragonNestDocument.m_DragonNestTypeTable.Table.Length; i++)
			{
				XDragonNestDocument.DragonNestData item = this.CreateDragonNestData(i, 0U);
				this.DragonNestDataList.Add(item);
				item = this.CreateDragonNestData(i, 1U);
				this.DragonNestDataList.Add(item);
				item = this.CreateDragonNestData(i, 2U);
				this.DragonNestDataList.Add(item);
			}
			bool flag = data == null;
			if (!flag)
			{
				for (int j = 0; j < data.Count; j++)
				{
					for (int k = 0; k < this.DragonNestDataList.Count; k++)
					{
						bool flag2 = (long)data[j].dragonType == (long)((ulong)this.DragonNestDataList[k].Type) && (long)data[j].hardLevel == (long)((ulong)this.DragonNestDataList[k].Diff);
						if (flag2)
						{
							bool flag3 = data[j].curFloor == -1;
							if (flag3)
							{
								this.DragonNestDataList[k].IsFinished = true;
								this.DragonNestDataList[k].Wave = 7U;
							}
							else
							{
								this.DragonNestDataList[k].IsFinished = false;
								this.DragonNestDataList[k].Wave = (uint)data[j].curFloor;
							}
							this.DragonNestDataList[k].IsLocked = ((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)specificDocument.GetExpeditionDataByID((int)this.GetDragonNestByTypeAndDiffAndWave(this.DragonNestDataList[k].Type, this.DragonNestDataList[k].Diff, 1U).DragonNestID).RequiredLevel));
							this.DragonNestDataList[k].WeakState = data[j].refreshTimes;
							this.DragonNestDataList[k].WeakType = data[j].weakType;
						}
					}
				}
				bool flag4 = !DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.IsVisible();
				if (!flag4)
				{
					DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.RefreshUI();
				}
			}
		}

		// Token: 0x0600892B RID: 35115 RVA: 0x0011F01C File Offset: 0x0011D21C
		private XDragonNestDocument.DragonNestData CreateDragonNestData(int i, uint diff)
		{
			XDragonNestDocument.DragonNestData dragonNestData = new XDragonNestDocument.DragonNestData();
			dragonNestData.Type = XDragonNestDocument.m_DragonNestTypeTable.Table[i].DragonNestType;
			dragonNestData.Diff = diff;
			dragonNestData.Wave = 1U;
			dragonNestData.IsFinished = false;
			dragonNestData.WeakState = -1;
			dragonNestData.WeakType = DragonWeakType.DragonWeakType_Null;
			dragonNestData.IsLocked = true;
			dragonNestData.Wave = (dragonNestData.IsLocked ? 0U : dragonNestData.Wave);
			return dragonNestData;
		}

		// Token: 0x0600892C RID: 35116 RVA: 0x0011F090 File Offset: 0x0011D290
		public ExpeditionTable.RowData GetLastExpeditionRowData()
		{
			bool flag = this.DragonNestDataList.Count == 0;
			ExpeditionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				XDragonNestDocument.DragonNestData dragonNestData = null;
				for (int i = 0; i < this.DragonNestDataList.Count; i++)
				{
					bool flag2 = this.DragonNestDataList[i].Diff == 2U;
					if (!flag2)
					{
						bool isLocked = this.DragonNestDataList[i].IsLocked;
						if (isLocked)
						{
							break;
						}
						dragonNestData = this.DragonNestDataList[i];
					}
				}
				bool flag3 = dragonNestData == null;
				if (flag3)
				{
					result = null;
				}
				else
				{
					DragonNestTable.RowData rowData = null;
					List<DragonNestTable.RowData> dragonNestListByTypeAndDiff = this.GetDragonNestListByTypeAndDiff(dragonNestData.Type, dragonNestData.Diff);
					uint num = (dragonNestData.Wave == 7U) ? 6U : dragonNestData.Wave;
					for (int j = 0; j < dragonNestListByTypeAndDiff.Count; j++)
					{
						bool flag4 = num == dragonNestListByTypeAndDiff[j].DragonNestWave;
						if (flag4)
						{
							rowData = dragonNestListByTypeAndDiff[j];
							break;
						}
					}
					bool flag5 = rowData == null;
					if (flag5)
					{
						result = null;
					}
					else
					{
						XExpeditionDocument xexpeditionDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XExpeditionDocument.uuID) as XExpeditionDocument;
						ExpeditionTable.RowData expeditionDataByID = xexpeditionDocument.GetExpeditionDataByID((int)rowData.DragonNestID);
						result = expeditionDataByID;
					}
				}
			}
			return result;
		}

		// Token: 0x0600892D RID: 35117 RVA: 0x0011F1E0 File Offset: 0x0011D3E0
		public string GetPreName(int DNExpID)
		{
			DragonNestTable.RowData dragonNestByID = this.GetDragonNestByID((uint)DNExpID);
			return XStringDefineProxy.GetString(string.Format("DragonNestPreName{0}", dragonNestByID.DragonNestType));
		}

		// Token: 0x0600892E RID: 35118 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002B64 RID: 11108
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonNestDocument");

		// Token: 0x04002B65 RID: 11109
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002B66 RID: 11110
		private static DragonNestTable m_DragonNestTable = new DragonNestTable();

		// Token: 0x04002B67 RID: 11111
		private static DragonNestType m_DragonNestTypeTable = new DragonNestType();

		// Token: 0x04002B68 RID: 11112
		private uint _current_type = 1U;

		// Token: 0x04002B69 RID: 11113
		private uint _current_diff = 0U;

		// Token: 0x04002B6A RID: 11114
		private uint _current_expid;

		// Token: 0x04002B6B RID: 11115
		private DragonWeakType _current_weak_type;

		// Token: 0x04002B6C RID: 11116
		private int _current_weak_state;

		// Token: 0x04002B6D RID: 11117
		public List<XDragonNestDocument.DragonNestData> DragonNestDataList = new List<XDragonNestDocument.DragonNestData>();

		// Token: 0x02001956 RID: 6486
		public class DragonNestData
		{
			// Token: 0x04007DC2 RID: 32194
			public uint Type;

			// Token: 0x04007DC3 RID: 32195
			public uint Diff;

			// Token: 0x04007DC4 RID: 32196
			public uint Wave;

			// Token: 0x04007DC5 RID: 32197
			public bool IsLocked;

			// Token: 0x04007DC6 RID: 32198
			public bool IsFinished;

			// Token: 0x04007DC7 RID: 32199
			public int WeakState;

			// Token: 0x04007DC8 RID: 32200
			public DragonWeakType WeakType;
		}
	}
}
