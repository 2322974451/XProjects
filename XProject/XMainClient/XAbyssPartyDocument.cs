using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAbyssPartyDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XAbyssPartyDocument.uuID;
			}
		}

		public static XAbyssPartyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XAbyssPartyDocument.uuID) as XAbyssPartyDocument;
			}
		}

		public int CurSelectedID
		{
			get
			{
				bool flag = this.m_CurID <= 0;
				if (flag)
				{
					this.SetDefaultID();
				}
				return this.m_CurID;
			}
		}

		public int CurSelectedType
		{
			get
			{
				bool flag = this.m_CurType <= 0;
				if (flag)
				{
					this.SetDefaultType();
				}
				return this.m_CurType;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.ResetAbyssIndex();
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ABYSS_PARTY;
			if (flag)
			{
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_AbyssParty, EXStage.Hall);
			}
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = arg.PlayerInfo.Stages.absparty != null;
			if (flag)
			{
				this.SetAbyssIndex(arg.PlayerInfo.Stages.absparty.aby);
			}
			bool flag2 = DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>.singleton.RefreshPage();
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XAbyssPartyDocument.AsyncLoader.AddTask("Table/AbyssPartyList", XAbyssPartyDocument._AbyssPartyListTable, false);
			XAbyssPartyDocument.AsyncLoader.AddTask("Table/AbyssPartyType", XAbyssPartyDocument._AbyssPartyTypeTable, false);
			XAbyssPartyDocument.AsyncLoader.Execute(callback);
		}

		public static int GetAbyssPartyTypeCount()
		{
			return XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length;
		}

		public static AbyssPartyTypeTable.RowData GetAbyssPartyTypeLine(int line)
		{
			bool flag = line >= XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length;
			AbyssPartyTypeTable.RowData result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GetAbyssPartyTypeLine No Find!\nline:" + line, null, null, null, null, null);
				result = null;
			}
			else
			{
				result = XAbyssPartyDocument._AbyssPartyTypeTable.Table[line];
			}
			return result;
		}

		public AbyssPartyTypeTable.RowData GetAbyssPartyType()
		{
			return XAbyssPartyDocument.GetAbyssPartyType(this.CurSelectedType);
		}

		public static AbyssPartyTypeTable.RowData GetAbyssPartyType(int TypeID)
		{
			AbyssPartyTypeTable.RowData byAbyssPartyId = XAbyssPartyDocument._AbyssPartyTypeTable.GetByAbyssPartyId(TypeID);
			bool flag = byAbyssPartyId == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GetAbyssPartyList No Find!\nTypeID:" + TypeID, null, null, null, null, null);
			}
			return byAbyssPartyId;
		}

		public static List<AbyssPartyListTable.RowData> RefreshAbyssPartyListList(int TypeID)
		{
			XAbyssPartyDocument.CurAbyssPartyList.Clear();
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyListTable.Table.Length; i++)
			{
				bool flag = XAbyssPartyDocument._AbyssPartyListTable.Table[i].AbyssPartyId == TypeID;
				if (flag)
				{
					XAbyssPartyDocument.CurAbyssPartyList.Add(XAbyssPartyDocument._AbyssPartyListTable.Table[i]);
				}
			}
			return XAbyssPartyDocument.CurAbyssPartyList;
		}

		public AbyssPartyListTable.RowData GetAbyssPartyList()
		{
			return XAbyssPartyDocument.GetAbyssPartyList(this.CurSelectedID);
		}

		public static AbyssPartyListTable.RowData GetAbyssPartyList(int key)
		{
			AbyssPartyListTable.RowData byID = XAbyssPartyDocument._AbyssPartyListTable.GetByID(key);
			bool flag = byID == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("GetAbyssPartyList No Find!\nkey:" + key, null, null, null, null, null);
			}
			return byID;
		}

		public void SetDefaultType()
		{
			this.m_CurType = 1;
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length; i++)
			{
				bool flag = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)XAbyssPartyDocument._AbyssPartyTypeTable.Table[i].OpenLevel);
				if (flag)
				{
					break;
				}
				this.m_CurType = XAbyssPartyDocument._AbyssPartyTypeTable.Table[i].AbyssPartyId;
			}
		}

		public bool SetSelectedType(int type)
		{
			bool flag = type < 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_CurType = type;
				this.SetDefaultID();
				result = true;
			}
			return result;
		}

		public void SetDefaultID()
		{
			this.m_CurID = 0;
			int abyssIndex = (int)this.GetAbyssIndex(this.CurSelectedType);
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyListTable.Table.Length; i++)
			{
				bool flag = XAbyssPartyDocument._AbyssPartyListTable.Table[i].AbyssPartyId == this.CurSelectedType && XAbyssPartyDocument._AbyssPartyListTable.Table[i].Index <= abyssIndex;
				if (flag)
				{
					this.m_CurID = XAbyssPartyDocument._AbyssPartyListTable.Table[i].ID;
				}
			}
			bool flag2 = this.m_CurID == 0;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"m_CurID No Find!\nCurSelectedType:",
					this.CurSelectedType,
					"m_CurIndex:",
					abyssIndex
				}), null, null, null, null, null);
			}
		}

		public bool SetSelectedID(int id)
		{
			bool flag = id < 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this.m_CurID = id;
				result = true;
			}
			return result;
		}

		public void SetAbyssIndex(List<AbsPartyBase> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				this.SetAbyssIndex(data[i].type, data[i].diff);
			}
		}

		private void ResetAbyssIndex()
		{
			this.m_AbyssIndex.Clear();
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length + 1; i++)
			{
				this.m_AbyssIndex.Add(0U);
			}
		}

		public void SetAbyssIndex(uint type, uint index)
		{
			bool flag = (ulong)type >= (ulong)((long)this.m_AbyssIndex.Count);
			if (!flag)
			{
				this.m_AbyssIndex[(int)type] = index;
				XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
				{
					"[AbyssParty]type:",
					type,
					"  index:",
					index
				}), null, null, null, null, null);
			}
		}

		public uint GetAbyssIndex(int type)
		{
			bool flag = type >= this.m_AbyssIndex.Count;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = this.m_AbyssIndex[type];
			}
			return result;
		}

		public void AbyssPartyEnter(int apID)
		{
			RpcC2G_AbsEnterScene rpcC2G_AbsEnterScene = new RpcC2G_AbsEnterScene();
			rpcC2G_AbsEnterScene.oArg.id = (uint)apID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AbsEnterScene);
			XSingleton<XDebug>.singleton.AddGreenLog("AbyssParty Enter ID:" + apID, null, null, null, null, null);
		}

		public int CanUseCostMAXNum()
		{
			bool flag = false;
			int num = 0;
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length; i++)
			{
				bool flag2 = XAbyssPartyDocument._AbyssPartyTypeTable.Table[i].AbyssPartyId == this.CurSelectedType;
				if (flag2)
				{
					flag = true;
				}
				bool flag3 = flag;
				if (flag3)
				{
					int[] titanItemID = XAbyssPartyDocument._AbyssPartyTypeTable.Table[i].TitanItemID;
					bool flag4 = titanItemID != null && titanItemID.Length != 0;
					if (flag4)
					{
						num += (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(titanItemID[0]);
					}
				}
			}
			XSingleton<XDebug>.singleton.AddGreenLog("CanUseCostMAXNum:" + num, null, null, null, null, null);
			return num;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AbyssPartyDocument");

		public AbyssPartyEntranceView View = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static AbyssPartyListTable _AbyssPartyListTable = new AbyssPartyListTable();

		private static AbyssPartyTypeTable _AbyssPartyTypeTable = new AbyssPartyTypeTable();

		private List<uint> m_AbyssIndex = new List<uint>();

		private int m_CurID = -1;

		private int m_CurType = -1;

		private static List<AbyssPartyListTable.RowData> CurAbyssPartyList = new List<AbyssPartyListTable.RowData>();
	}
}
