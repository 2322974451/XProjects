using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000914 RID: 2324
	internal class PandoraDocument : XDocComponent
	{
		// Token: 0x17002B70 RID: 11120
		// (get) Token: 0x06008C33 RID: 35891 RVA: 0x0012F21C File Offset: 0x0012D41C
		public override uint ID
		{
			get
			{
				return PandoraDocument.uuID;
			}
		}

		// Token: 0x17002B71 RID: 11121
		// (get) Token: 0x06008C34 RID: 35892 RVA: 0x0012F234 File Offset: 0x0012D434
		public uint PandoraID
		{
			get
			{
				return this._pandora_id;
			}
		}

		// Token: 0x17002B72 RID: 11122
		// (get) Token: 0x06008C35 RID: 35893 RVA: 0x0012F24C File Offset: 0x0012D44C
		public PandoraHeart.RowData PandoraData
		{
			get
			{
				return this._pandora_data;
			}
		}

		// Token: 0x17002B73 RID: 11123
		// (get) Token: 0x06008C36 RID: 35894 RVA: 0x0012F264 File Offset: 0x0012D464
		public List<ItemBrief> ItemCache
		{
			get
			{
				return this._items_cache;
			}
		}

		// Token: 0x06008C37 RID: 35895 RVA: 0x0012F27C File Offset: 0x0012D47C
		public static void Execute(OnLoadedCallback callback = null)
		{
			PandoraDocument.AsyncLoader.AddTask("Table/PandoraHeartReward", PandoraDocument._table, false);
			PandoraDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008C38 RID: 35896 RVA: 0x0012F2A4 File Offset: 0x0012D4A4
		private void GetShowItemList()
		{
			PandoraDocument.ItemList.Clear();
			for (int i = 0; i < PandoraDocument._table.Table.Length; i++)
			{
				bool flag = this._pandora_id == PandoraDocument._table.Table[i].pandoraid;
				if (flag)
				{
					bool flag2 = (PandoraDocument._table.Table[i].showlevel[0] == 0U && PandoraDocument._table.Table[i].showlevel[1] == 0U) || (PandoraDocument._table.Table[i].showlevel[0] <= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level && PandoraDocument._table.Table[i].showlevel[1] >= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					if (flag2)
					{
						bool flag3 = !PandoraDocument.ItemList.Contains(PandoraDocument._table.Table[i].itemid);
						if (flag3)
						{
							PandoraDocument.ItemList.Add(PandoraDocument._table.Table[i].itemid);
						}
					}
				}
			}
		}

		// Token: 0x06008C39 RID: 35897 RVA: 0x0012F3D8 File Offset: 0x0012D5D8
		public void GetShowItemList(uint pandoraid)
		{
			PandoraDocument.ItemList.Clear();
			for (int i = 0; i < PandoraDocument._table.Table.Length; i++)
			{
				bool flag = pandoraid == PandoraDocument._table.Table[i].pandoraid;
				if (flag)
				{
					bool flag2 = (PandoraDocument._table.Table[i].showlevel[0] == 0U && PandoraDocument._table.Table[i].showlevel[1] == 0U) || (PandoraDocument._table.Table[i].showlevel[0] <= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level && PandoraDocument._table.Table[i].showlevel[1] >= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					if (flag2)
					{
						bool flag3 = !PandoraDocument.ItemList.Contains(PandoraDocument._table.Table[i].itemid);
						if (flag3)
						{
							PandoraDocument.ItemList.Add(PandoraDocument._table.Table[i].itemid);
						}
					}
				}
			}
		}

		// Token: 0x06008C3A RID: 35898 RVA: 0x0012F504 File Offset: 0x0012D704
		public void SendPandoraLottery(bool isOneLottery)
		{
			bool flag = Time.time - this._last_lottery_time < 2f;
			if (!flag)
			{
				this._last_lottery_time = Time.time;
				RpcC2G_PandoraLottery rpcC2G_PandoraLottery = new RpcC2G_PandoraLottery();
				rpcC2G_PandoraLottery.oArg.pandoraid = this._pandora_id;
				rpcC2G_PandoraLottery.oArg.isOneLottery = isOneLottery;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PandoraLottery);
			}
		}

		// Token: 0x06008C3B RID: 35899 RVA: 0x0012F568 File Offset: 0x0012D768
		public void GetPandoraLotteryResult(List<ItemBrief> items)
		{
			this._items_cache.Clear();
			for (int i = 0; i < items.Count; i++)
			{
				this._items_cache.Add(items[i]);
			}
			bool flag = DlgBase<PandoraView, PandoraBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<PandoraView, PandoraBehaviour>.singleton.PlayOpenFx();
			}
		}

		// Token: 0x06008C3C RID: 35900 RVA: 0x0012F5C8 File Offset: 0x0012D7C8
		public void ShowPandoraLotteryView(uint itemID, PandoraHeart.RowData data)
		{
			bool flag = data == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Pandora Data is Null!!!", null, null, null, null, null);
			}
			else
			{
				this._pandora_id = itemID;
				this._pandora_data = data;
				this.GetShowItemList();
				DlgBase<PandoraView, PandoraBehaviour>.singleton.SetVisible(true, true);
			}
		}

		// Token: 0x06008C3D RID: 35901 RVA: 0x0012F618 File Offset: 0x0012D818
		public XFx CreateAndPlayFx(string path, Transform parent)
		{
			XFx xfx = XSingleton<XFxMgr>.singleton.CreateFx(path, null, true);
			bool flag = xfx == null;
			XFx result;
			if (flag)
			{
				result = null;
			}
			else
			{
				xfx.Play(parent, Vector3.zero, Vector3.one, 1f, true, false);
				result = xfx;
			}
			return result;
		}

		// Token: 0x06008C3E RID: 35902 RVA: 0x0012F660 File Offset: 0x0012D860
		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		// Token: 0x06008C3F RID: 35903 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04002D31 RID: 11569
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PandoraDocument");

		// Token: 0x04002D32 RID: 11570
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002D33 RID: 11571
		private uint _pandora_id = 0U;

		// Token: 0x04002D34 RID: 11572
		private PandoraHeart.RowData _pandora_data = null;

		// Token: 0x04002D35 RID: 11573
		private List<ItemBrief> _items_cache = new List<ItemBrief>();

		// Token: 0x04002D36 RID: 11574
		private float _last_lottery_time = 0f;

		// Token: 0x04002D37 RID: 11575
		private static PandoraHeartReward _table = new PandoraHeartReward();

		// Token: 0x04002D38 RID: 11576
		public static List<uint> ItemList = new List<uint>();
	}
}
