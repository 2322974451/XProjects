using System;
using System.Collections.Generic;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200096F RID: 2415
	internal class XSkyArenaEntranceDocument : XDocComponent
	{
		// Token: 0x17002C6C RID: 11372
		// (get) Token: 0x06009186 RID: 37254 RVA: 0x0014DD5C File Offset: 0x0014BF5C
		public override uint ID
		{
			get
			{
				return XSkyArenaEntranceDocument.uuID;
			}
		}

		// Token: 0x17002C6D RID: 11373
		// (get) Token: 0x06009187 RID: 37255 RVA: 0x0014DD74 File Offset: 0x0014BF74
		public static XSkyArenaEntranceDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XSkyArenaEntranceDocument.uuID) as XSkyArenaEntranceDocument;
			}
		}

		// Token: 0x06009188 RID: 37256 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009189 RID: 37257 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void OnEnterSceneFinally()
		{
		}

		// Token: 0x0600918A RID: 37258 RVA: 0x0013A712 File Offset: 0x00138912
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
		}

		// Token: 0x0600918B RID: 37259 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600918C RID: 37260 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600918D RID: 37261 RVA: 0x0014DD9F File Offset: 0x0014BF9F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XSkyArenaEntranceDocument.AsyncLoader.AddTask("Table/SkyArenaReward", XSkyArenaEntranceDocument._SkyArenaRewardTable, false);
			XSkyArenaEntranceDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600918E RID: 37262 RVA: 0x0014DDC4 File Offset: 0x0014BFC4
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

		// Token: 0x0600918F RID: 37263 RVA: 0x0014DE74 File Offset: 0x0014C074
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

		// Token: 0x06009190 RID: 37264 RVA: 0x0014DF4C File Offset: 0x0014C14C
		public void ReqSingleJoin()
		{
			RpcC2M_SkyCityEnter rpc = new RpcC2M_SkyCityEnter();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06009191 RID: 37265 RVA: 0x0014DF6C File Offset: 0x0014C16C
		public void SetTime(uint time)
		{
			bool flag = this.WaitHandler != null;
			if (flag)
			{
				this.WaitHandler.StartTime(time);
			}
		}

		// Token: 0x06009192 RID: 37266 RVA: 0x0014DF96 File Offset: 0x0014C196
		public void SetMainInterfaceBtnState(bool state)
		{
			this.MainInterfaceState = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_SkyArena, true);
		}

		// Token: 0x06009193 RID: 37267 RVA: 0x0014DFB1 File Offset: 0x0014C1B1
		public void SetMainInterfaceBtnStateEnd(bool state)
		{
			this.MainInterfaceStateEnd = state;
			DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_MulActivity_SkyArenaEnd, true);
		}

		// Token: 0x04003065 RID: 12389
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XSkyArenaEntranceDocument");

		// Token: 0x04003066 RID: 12390
		public SkyArenaEntranceView View = null;

		// Token: 0x04003067 RID: 12391
		public SkyArenaWaitHandler WaitHandler = null;

		// Token: 0x04003068 RID: 12392
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003069 RID: 12393
		private static SkyArenaReward _SkyArenaRewardTable = new SkyArenaReward();

		// Token: 0x0400306A RID: 12394
		public bool MainInterfaceState = false;

		// Token: 0x0400306B RID: 12395
		public bool MainInterfaceStateEnd = false;
	}
}
