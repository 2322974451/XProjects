using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000944 RID: 2372
	internal class XAbyssPartyDocument : XDocComponent
	{
		// Token: 0x17002C25 RID: 11301
		// (get) Token: 0x06008F66 RID: 36710 RVA: 0x00141AE4 File Offset: 0x0013FCE4
		public override uint ID
		{
			get
			{
				return XAbyssPartyDocument.uuID;
			}
		}

		// Token: 0x17002C26 RID: 11302
		// (get) Token: 0x06008F67 RID: 36711 RVA: 0x00141AFC File Offset: 0x0013FCFC
		public static XAbyssPartyDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XAbyssPartyDocument.uuID) as XAbyssPartyDocument;
			}
		}

		// Token: 0x17002C27 RID: 11303
		// (get) Token: 0x06008F68 RID: 36712 RVA: 0x00141B28 File Offset: 0x0013FD28
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

		// Token: 0x17002C28 RID: 11304
		// (get) Token: 0x06008F69 RID: 36713 RVA: 0x00141B58 File Offset: 0x0013FD58
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

		// Token: 0x06008F6A RID: 36714 RVA: 0x00141B87 File Offset: 0x0013FD87
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.ResetAbyssIndex();
		}

		// Token: 0x06008F6B RID: 36715 RVA: 0x00141B9C File Offset: 0x0013FD9C
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_ABYSS_PARTY;
			if (flag)
			{
				XSingleton<XUICacheMgr>.singleton.CacheUI(XSysDefine.XSys_AbyssParty, EXStage.Hall);
			}
		}

		// Token: 0x06008F6C RID: 36716 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008F6D RID: 36717 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x06008F6E RID: 36718 RVA: 0x00141BD0 File Offset: 0x0013FDD0
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

		// Token: 0x06008F6F RID: 36719 RVA: 0x00141C2A File Offset: 0x0013FE2A
		public static void Execute(OnLoadedCallback callback = null)
		{
			XAbyssPartyDocument.AsyncLoader.AddTask("Table/AbyssPartyList", XAbyssPartyDocument._AbyssPartyListTable, false);
			XAbyssPartyDocument.AsyncLoader.AddTask("Table/AbyssPartyType", XAbyssPartyDocument._AbyssPartyTypeTable, false);
			XAbyssPartyDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008F70 RID: 36720 RVA: 0x00141C68 File Offset: 0x0013FE68
		public static int GetAbyssPartyTypeCount()
		{
			return XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length;
		}

		// Token: 0x06008F71 RID: 36721 RVA: 0x00141C88 File Offset: 0x0013FE88
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

		// Token: 0x06008F72 RID: 36722 RVA: 0x00141CE4 File Offset: 0x0013FEE4
		public AbyssPartyTypeTable.RowData GetAbyssPartyType()
		{
			return XAbyssPartyDocument.GetAbyssPartyType(this.CurSelectedType);
		}

		// Token: 0x06008F73 RID: 36723 RVA: 0x00141D04 File Offset: 0x0013FF04
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

		// Token: 0x06008F74 RID: 36724 RVA: 0x00141D4C File Offset: 0x0013FF4C
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

		// Token: 0x06008F75 RID: 36725 RVA: 0x00141DBC File Offset: 0x0013FFBC
		public AbyssPartyListTable.RowData GetAbyssPartyList()
		{
			return XAbyssPartyDocument.GetAbyssPartyList(this.CurSelectedID);
		}

		// Token: 0x06008F76 RID: 36726 RVA: 0x00141DDC File Offset: 0x0013FFDC
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

		// Token: 0x06008F77 RID: 36727 RVA: 0x00141E24 File Offset: 0x00140024
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

		// Token: 0x06008F78 RID: 36728 RVA: 0x00141E98 File Offset: 0x00140098
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

		// Token: 0x06008F79 RID: 36729 RVA: 0x00141EC8 File Offset: 0x001400C8
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

		// Token: 0x06008F7A RID: 36730 RVA: 0x00141FA8 File Offset: 0x001401A8
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

		// Token: 0x06008F7B RID: 36731 RVA: 0x00141FD0 File Offset: 0x001401D0
		public void SetAbyssIndex(List<AbsPartyBase> data)
		{
			for (int i = 0; i < data.Count; i++)
			{
				this.SetAbyssIndex(data[i].type, data[i].diff);
			}
		}

		// Token: 0x06008F7C RID: 36732 RVA: 0x00142014 File Offset: 0x00140214
		private void ResetAbyssIndex()
		{
			this.m_AbyssIndex.Clear();
			for (int i = 0; i < XAbyssPartyDocument._AbyssPartyTypeTable.Table.Length + 1; i++)
			{
				this.m_AbyssIndex.Add(0U);
			}
		}

		// Token: 0x06008F7D RID: 36733 RVA: 0x0014205C File Offset: 0x0014025C
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

		// Token: 0x06008F7E RID: 36734 RVA: 0x001420D0 File Offset: 0x001402D0
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

		// Token: 0x06008F7F RID: 36735 RVA: 0x00142108 File Offset: 0x00140308
		public void AbyssPartyEnter(int apID)
		{
			RpcC2G_AbsEnterScene rpcC2G_AbsEnterScene = new RpcC2G_AbsEnterScene();
			rpcC2G_AbsEnterScene.oArg.id = (uint)apID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_AbsEnterScene);
			XSingleton<XDebug>.singleton.AddGreenLog("AbyssParty Enter ID:" + apID, null, null, null, null, null);
		}

		// Token: 0x06008F80 RID: 36736 RVA: 0x00142158 File Offset: 0x00140358
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

		// Token: 0x04002F1C RID: 12060
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("AbyssPartyDocument");

		// Token: 0x04002F1D RID: 12061
		public AbyssPartyEntranceView View = null;

		// Token: 0x04002F1E RID: 12062
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002F1F RID: 12063
		private static AbyssPartyListTable _AbyssPartyListTable = new AbyssPartyListTable();

		// Token: 0x04002F20 RID: 12064
		private static AbyssPartyTypeTable _AbyssPartyTypeTable = new AbyssPartyTypeTable();

		// Token: 0x04002F21 RID: 12065
		private List<uint> m_AbyssIndex = new List<uint>();

		// Token: 0x04002F22 RID: 12066
		private int m_CurID = -1;

		// Token: 0x04002F23 RID: 12067
		private int m_CurType = -1;

		// Token: 0x04002F24 RID: 12068
		private static List<AbyssPartyListTable.RowData> CurAbyssPartyList = new List<AbyssPartyListTable.RowData>();
	}
}
