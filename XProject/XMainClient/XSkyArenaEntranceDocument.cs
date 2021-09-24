using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkyArenaEntranceDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XSkyArenaEntranceDocument.uuID;
			}
		}

		public static XSkyArenaEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSkyArenaEntranceDocument.uuID) as XSkyArenaEntranceDocument;
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		public override void OnEnterSceneFinally()
		{
		}

		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XSkyArenaEntranceDocument.AsyncLoader.AddTask("Table/SkyArenaReward", XSkyArenaEntranceDocument._SkyArenaRewardTable, false);
			XSkyArenaEntranceDocument.AsyncLoader.Execute(callback);
		}

		public SkyArenaReward.RowData GetSkyArenaRewardShow()
		{
			SkyArenaReward.RowData rowData = null;
			for (int i = 0; i < XSkyArenaEntranceDocument._SkyArenaRewardTable.Table.Length; i++)
			{
				bool flag = (long)XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].LevelSegment <= (long)((ulong)XLevelSealDocument.Doc.SealType) && XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].Floor == 0;
				if (flag)
				{
					rowData = XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i];
				}
			}
			bool flag2 = rowData == null;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("SkyArenaReward.RowData is null! SealType:" + XLevelSealDocument.Doc.SealType, null, null, null, null, null);
			}
			return rowData;
		}

		public List<SkyArenaReward.RowData> GetSkyArenaRewardList()
		{
			int num = 1;
			List<SkyArenaReward.RowData> list = new List<SkyArenaReward.RowData>();
			for (int i = 0; i < XSkyArenaEntranceDocument._SkyArenaRewardTable.Table.Length; i++)
			{
				bool flag = XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].LevelSegment != num;
				if (flag)
				{
					bool flag2 = (long)XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].LevelSegment <= (long)((ulong)XLevelSealDocument.Doc.SealType);
					if (!flag2)
					{
						return list;
					}
					num = XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].LevelSegment;
					list.Clear();
				}
				bool flag3 = XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i].Floor != 0;
				if (flag3)
				{
					list.Add(XSkyArenaEntranceDocument._SkyArenaRewardTable.Table[i]);
				}
			}
			return list;
		}

		public void ReqSingleJoin()
		{
			RpcC2M_SkyCityEnter rpc = new RpcC2M_SkyCityEnter();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void SetTime(uint time)
		{
			bool flag = this.WaitHandler != null;
			if (flag)
			{
				this.WaitHandler.StartTime(time);
			}
		}

		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_SkyArena, true);
		}

		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_SkyArenaEnd, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSkyArenaEntranceDocument");

		public SkyArenaEntranceView View = null;

		public SkyArenaWaitHandler WaitHandler = null;

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static SkyArenaReward _SkyArenaRewardTable = new SkyArenaReward();

		public bool MainInterfaceState = false;

		public bool MainInterfaceStateEnd = false;
	}
}
