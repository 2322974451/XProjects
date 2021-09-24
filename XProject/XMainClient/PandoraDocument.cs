using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PandoraDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return PandoraDocument.uuID;
			}
		}

		public uint PandoraID
		{
			get
			{
				return this._pandora_id;
			}
		}

		public PandoraHeart.RowData PandoraData
		{
			get
			{
				return this._pandora_data;
			}
		}

		public List<ItemBrief> ItemCache
		{
			get
			{
				return this._items_cache;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			PandoraDocument.AsyncLoader.AddTask("Table/PandoraHeartReward", PandoraDocument._table, false);
			PandoraDocument.AsyncLoader.Execute(callback);
		}

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

		public void DestroyFx(XFx fx)
		{
			bool flag = fx == null;
			if (!flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PandoraDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private uint _pandora_id = 0U;

		private PandoraHeart.RowData _pandora_data = null;

		private List<ItemBrief> _items_cache = new List<ItemBrief>();

		private float _last_lottery_time = 0f;

		private static PandoraHeartReward _table = new PandoraHeartReward();

		public static List<uint> ItemList = new List<uint>();
	}
}
