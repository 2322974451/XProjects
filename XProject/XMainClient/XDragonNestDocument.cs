using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonNestDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonNestDocument.uuID;
			}
		}

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

		public int DragonNestBOSSWave
		{
			get
			{
				return XSingleton<XGlobalConfig>.singleton.GetInt("DragonNestBOSSWave");
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XDragonNestDocument.AsyncLoader.AddTask("Table/DragonNestList", XDragonNestDocument.m_DragonNestTable, false);
			XDragonNestDocument.AsyncLoader.AddTask("Table/DragonNestType", XDragonNestDocument.m_DragonNestTypeTable, false);
			XDragonNestDocument.AsyncLoader.Execute(callback);
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				this.SetDragonNestInfo(null);
			}
		}

		public DragonNestType.RowData[] GetDragonNestTypeList()
		{
			return XDragonNestDocument.m_DragonNestTypeTable.Table;
		}

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

		public void ResetData()
		{
			this._current_type = 1U;
			this._current_diff = 0U;
			this._current_expid = this.GetDragonNestByTypeAndDiffAndWave(1U, 0U, 1U).DragonNestID;
		}

		public void SendReqDragonNestInfo()
		{
			RpcC2G_GetDragonTopInfo rpc = new RpcC2G_GetDragonTopInfo();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public string GetPreName(int DNExpID)
		{
			DragonNestTable.RowData dragonNestByID = this.GetDragonNestByID((uint)DNExpID);
			return XStringDefineProxy.GetString(string.Format("DragonNestPreName{0}", dragonNestByID.DragonNestType));
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonNestDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static DragonNestTable m_DragonNestTable = new DragonNestTable();

		private static DragonNestType m_DragonNestTypeTable = new DragonNestType();

		private uint _current_type = 1U;

		private uint _current_diff = 0U;

		private uint _current_expid;

		private DragonWeakType _current_weak_type;

		private int _current_weak_state;

		public List<XDragonNestDocument.DragonNestData> DragonNestDataList = new List<XDragonNestDocument.DragonNestData>();

		public class DragonNestData
		{

			public uint Type;

			public uint Diff;

			public uint Wave;

			public bool IsLocked;

			public bool IsFinished;

			public int WeakState;

			public DragonWeakType WeakType;
		}
	}
}
