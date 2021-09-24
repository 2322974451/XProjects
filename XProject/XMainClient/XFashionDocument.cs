using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFashionDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFashionDocument.uuID;
			}
		}

		public List<ClientFashionData> FashionBag { get; set; }

		public List<ClientFashionData> FashionOnBody { get; set; }

		public List<uint> Collections { get; set; }

		public List<uint> NewFashionList { get; set; }

		public bool RedPoint
		{
			get
			{
				return this.CalRedPoint();
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFashionDocument.AsyncLoader.AddTask("Table/FashionSuit", XFashionDocument._fashionSuitTable, false);
			XFashionDocument.AsyncLoader.AddTask("Table/FashionCompose", XFashionDocument._fashionComposeTable, false);
			XFashionDocument.AsyncLoader.AddTask("Table/FashionEffect", XFashionDocument._fashionEffectTable, false);
			XFashionDocument.AsyncLoader.AddTask("Table/FashionFx", XFashionDocument._fashionEnhanceFx, false);
			XFashionDocument.AsyncLoader.Execute(callback);
		}

		public static bool IsFashionBySuitID(int suitID)
		{
			return XFashionDocument._fashionSuitTable.GetBySuitID(suitID) != null;
		}

		public static bool IsTargetPart(int itemid, FashionPosition pos)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(itemid);
			bool flag = fashionConf == null;
			return !flag && XFastEnumIntEqualityComparer<FashionPosition>.ToInt(pos) == (int)fashionConf.EquipPos;
		}

		public static bool TryGetFashionEnhanceFx(int itemid, uint prof, out string[] strFx)
		{
			strFx = null;
			prof %= 10U;
			bool flag = itemid == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				FashionEnhanceFx.RowData byItemID = XFashionDocument._fashionEnhanceFx.GetByItemID(itemid);
				bool flag2 = byItemID == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					switch (prof)
					{
					case 1U:
						strFx = byItemID.Fx1;
						break;
					case 2U:
						strFx = byItemID.Fx2;
						break;
					case 3U:
						strFx = byItemID.Fx3;
						break;
					case 4U:
						strFx = byItemID.Fx4;
						break;
					case 5U:
						strFx = byItemID.Fx5;
						break;
					case 6U:
						strFx = byItemID.Fx6;
						break;
					case 7U:
						strFx = byItemID.Fx7;
						break;
					case 8U:
						strFx = byItemID.Fx8;
						break;
					}
					result = true;
				}
			}
			return result;
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public void UpdateRedPoints()
		{
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_Fashion, true);
		}

		protected ClientFashionData ConvertClientFashionData(FashionData d)
		{
			return new ClientFashionData
			{
				itemID = d.itemID,
				level = d.level,
				timeleft = (double)((d.timeleft == uint.MaxValue) ? -1f : ((float)d.timeleft)),
				uid = d.uid
			};
		}

		public void Init(List<FashionData> fashions, List<FashionData> fashiononbody, List<uint> collectionList)
		{
			this.FashionBag = new List<ClientFashionData>();
			this.FashionOnBody = new List<ClientFashionData>();
			this.Collections = new List<uint>();
			this.NewFashionList = new List<uint>();
			this.FashionSuitInfo.Clear();
			for (int i = 0; i < XFashionDocument._fashionSuitTable.Table.Length; i++)
			{
				FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				bool flag = bySuitID.FashionID != null;
				if (flag)
				{
					for (int j = 0; j < bySuitID.FashionID.Length; j++)
					{
						this.FashionSuitInfo.Add(bySuitID.FashionID[j], bySuitID.SuitID);
					}
				}
			}
			bool flag2 = fashions == null || fashiononbody == null;
			if (!flag2)
			{
				for (int k = 0; k < fashions.Count; k++)
				{
					this.FashionBag.Add(this.ConvertClientFashionData(fashions[k]));
				}
				for (int l = 0; l < fashiononbody.Count; l++)
				{
					this.FashionOnBody.Add(this.ConvertClientFashionData(fashiononbody[l]));
				}
				for (int m = 0; m < collectionList.Count; m++)
				{
					this.Collections.Add(collectionList[m]);
				}
			}
		}

		public void UpdateFashionData(FashionChangedData data)
		{
			switch (data.changeType)
			{
			case FashionNTFType.ADD_FASHION:
			{
				XAddItemEventArgs @event = XEventPool<XAddItemEventArgs>.GetEvent();
				@event.Firer = XSingleton<XGame>.singleton.Doc;
				for (int i = 0; i < data.fashion.Count; i++)
				{
					this.FashionBag.Add(this.ConvertClientFashionData(data.fashion[i]));
					bool flag = !this.Collections.Contains(data.fashion[i].itemID);
					if (flag)
					{
						this.Collections.Add(data.fashion[i].itemID);
					}
					XItem item = XBagDocument.MakeFasionItemById(data.fashion[i].itemID);
					@event.items.Add(item);
				}
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				XSingleton<XGame>.singleton.Doc.XBagDoc.FinishItemChange();
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_Fashion, true);
				break;
			}
			case FashionNTFType.UPGRADE_FASHION:
				for (int j = 0; j < data.fashion.Count; j++)
				{
					ClientFashionData clientFashionData = this.FindFashion(data.fashion[j].uid);
					bool flag2 = clientFashionData != null;
					if (flag2)
					{
						clientFashionData.timeleft = data.fashion[0].timeleft;
					}
				}
				break;
			case FashionNTFType.WEAR_FASHION:
			{
				for (int k = 0; k < data.fashion.Count; k++)
				{
					int pos = (int)data.fashion[k].pos;
					ClientFashionData clientFashionData2 = this.FashionOnBody[pos];
					this.FashionOnBody[pos] = this.ConvertClientFashionData(data.fashion[k]);
					bool flag3 = this.IsValidFashionData(clientFashionData2);
					if (flag3)
					{
						this.FashionBag.Add(clientFashionData2);
					}
					for (int l = 0; l < this.FashionBag.Count; l++)
					{
						bool flag4 = this.FashionBag[l].uid == data.fashion[k].uid;
						if (flag4)
						{
							this.FashionBag.RemoveAt(l);
							break;
						}
					}
				}
				bool flag5 = this.FashionDlg != null && this.FashionDlg.IsVisible();
				if (flag5)
				{
					this.FashionDlg.ShowFashions();
					this.FashionDlg.UpdateBag();
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_Fashion, true);
				break;
			}
			case FashionNTFType.DELBODY_FASHION:
				for (int m = 0; m < data.fashion.Count; m++)
				{
					ulong uid = data.fashion[m].uid;
					ClientFashionData clientFashionData3 = this.FindFashion(uid);
					FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)clientFashionData3.itemID);
					bool flag6 = fashionConf != null;
					if (flag6)
					{
						this.FashionOnBody[(int)fashionConf.EquipPos] = new ClientFashionData();
						bool flag7 = this.FashionDlg != null && this.FashionDlg.IsVisible();
						if (flag7)
						{
							this.FashionDlg.OnBodyFashionDisappear((int)fashionConf.EquipPos);
						}
						ItemList.RowData itemConf = XBagDocument.GetItemConf((int)clientFashionData3.itemID);
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("FASHION_DISAPPEAR"), XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U)), "fece00");
					}
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_Fashion, true);
				break;
			case FashionNTFType.DELBAG_FASHION:
				for (int n = 0; n < data.fashion.Count; n++)
				{
					ulong uid2 = data.fashion[n].uid;
					ClientFashionData clientFashionData4 = this.FindFashion(uid2);
					bool flag8 = clientFashionData4 != null;
					if (flag8)
					{
						this.FashionBag.Remove(clientFashionData4);
						bool flag9 = this.FashionDlg != null && this.FashionDlg.IsVisible();
						if (flag9)
						{
							this.FashionDlg.OnBagFashionDisappear(clientFashionData4.uid);
						}
					}
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_Fashion, true);
				break;
			}
		}

		public bool IsValidFashionData(ClientFashionData d)
		{
			return d.itemID > 0U && d.uid > 0UL;
		}

		public FashionSuitTable.RowData GetSuitData(int suitID)
		{
			return XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
		}

		public uint GetFashionFragment(int fashionID)
		{
			return 0U;
		}

		public SeqListRef<uint> GetFashionAttr(int fashionID, int level)
		{
			for (int i = 0; i < XFashionDocument._fashionComposeTable.Table.Length; i++)
			{
				bool flag = XFashionDocument._fashionComposeTable.Table[i].FashionID == fashionID && XFashionDocument._fashionComposeTable.Table[i].FashionLevel == level;
				if (flag)
				{
					return XFashionDocument._fashionComposeTable.Table[i].Attributes;
				}
			}
			return default(SeqListRef<uint>);
		}

		public bool OwnFashion(int fashionID)
		{
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				bool flag = (ulong)this.FashionOnBody[i].itemID == (ulong)((long)fashionID);
				if (flag)
				{
					return true;
				}
			}
			for (int j = 0; j < this.FashionBag.Count; j++)
			{
				bool flag2 = (ulong)this.FashionBag[j].itemID == (ulong)((long)fashionID);
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		public ClientFashionData FindFashionInBag(int fashionID)
		{
			bool flag = this.FashionBag == null || this.FashionOnBody == null;
			ClientFashionData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.FashionBag.Count; i++)
				{
					bool flag2 = (ulong)this.FashionBag[i].itemID == (ulong)((long)fashionID);
					if (flag2)
					{
						return this.FashionBag[i];
					}
				}
				result = null;
			}
			return result;
		}

		public ClientFashionData FindFashionLimitTimeFirst(int fashionID)
		{
			bool flag = this.FashionBag == null || this.FashionOnBody == null;
			ClientFashionData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				ClientFashionData clientFashionData = null;
				for (int i = 0; i < this.FashionOnBody.Count; i++)
				{
					bool flag2 = (ulong)this.FashionOnBody[i].itemID == (ulong)((long)fashionID);
					if (flag2)
					{
						clientFashionData = this.FashionOnBody[i];
					}
				}
				bool flag3 = clientFashionData == null;
				if (flag3)
				{
					for (int j = 0; j < this.FashionBag.Count; j++)
					{
						bool flag4 = (ulong)this.FashionBag[j].itemID == (ulong)((long)fashionID) && this.FashionBag[j].timeleft > 0.0;
						if (flag4)
						{
							return this.FashionBag[j];
						}
						bool flag5 = (ulong)this.FashionBag[j].itemID == (ulong)((long)fashionID) && this.FashionBag[j].timeleft == -1.0;
						if (flag5)
						{
							clientFashionData = this.FashionBag[j];
						}
					}
				}
				result = clientFashionData;
			}
			return result;
		}

		public ClientFashionData FindFashionByPosInBody(int pos)
		{
			bool flag = this.FashionBag == null || this.FashionOnBody == null;
			ClientFashionData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.FashionOnBody.Count; i++)
				{
					FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)this.FashionOnBody[i].itemID);
					bool flag2 = fashionConf != null && (int)fashionConf.EquipPos == pos;
					if (flag2)
					{
						return this.FashionOnBody[i];
					}
				}
				result = null;
			}
			return result;
		}

		public bool TryFindFashionUidInBody(int fashionID, out ulong uid)
		{
			uid = 0UL;
			ClientFashionData clientFashionData = this.FindFashionInBody(fashionID);
			bool flag = clientFashionData != null;
			bool result;
			if (flag)
			{
				uid = clientFashionData.uid;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public ClientFashionData FindFashionInBody(int fashionID)
		{
			bool flag = this.FashionBag == null || this.FashionOnBody == null;
			ClientFashionData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.FashionOnBody.Count; i++)
				{
					bool flag2 = (ulong)this.FashionOnBody[i].itemID == (ulong)((long)fashionID);
					if (flag2)
					{
						return this.FashionOnBody[i];
					}
				}
				result = null;
			}
			return result;
		}

		public bool TryFindFashion(ulong uid, out ClientFashionData fishionData)
		{
			fishionData = this.FindFashion(uid);
			return fishionData != null;
		}

		public ClientFashionData FindFashion(ulong uid)
		{
			bool flag = this.FashionBag == null || this.FashionOnBody == null;
			ClientFashionData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				for (int i = 0; i < this.FashionOnBody.Count; i++)
				{
					bool flag2 = this.FashionOnBody[i].uid == uid;
					if (flag2)
					{
						return this.FashionOnBody[i];
					}
				}
				for (int j = 0; j < this.FashionBag.Count; j++)
				{
					bool flag3 = this.FashionBag[j].uid == uid;
					if (flag3)
					{
						return this.FashionBag[j];
					}
				}
				result = null;
			}
			return result;
		}

		public ClientFashionData GetPartFashion(int part)
		{
			return this.FashionOnBody[part];
		}

		public int GetFashionSuit(int fashionID)
		{
			int num = 0;
			bool flag = this.FashionSuitInfo.TryGetValue((uint)fashionID, out num);
			int result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public bool IsOverAll(int fashionID)
		{
			int fashionSuit = this.GetFashionSuit(fashionID);
			bool flag = fashionSuit == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(fashionSuit);
				result = (bySuitID != null && bySuitID.OverAll == 1);
			}
			return result;
		}

		public SeqListRef<uint> GetSuitPartCountEffect(int suitID, int count)
		{
			FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
			bool flag = bySuitID == null;
			SeqListRef<uint> result;
			if (flag)
			{
				result = default(SeqListRef<uint>);
			}
			else
			{
				switch (count)
				{
				case 2:
					result = bySuitID.Effect2;
					break;
				case 3:
					result = bySuitID.Effect3;
					break;
				case 4:
					result = bySuitID.Effect4;
					break;
				case 5:
					result = bySuitID.Effect5;
					break;
				case 6:
					result = bySuitID.Effect6;
					break;
				case 7:
					result = bySuitID.Effect7;
					break;
				default:
					result = default(SeqListRef<uint>);
					break;
				}
			}
			return result;
		}

		protected FashionEffectTable.RowData GetFashionEffectData(uint quality, bool IsThreeSuit)
		{
			for (int i = 0; i < XFashionDocument._fashionEffectTable.Table.Length; i++)
			{
				bool flag = XFashionDocument._fashionEffectTable.Table[i].Quality == quality && XFashionDocument._fashionEffectTable.Table[i].IsThreeSuit == IsThreeSuit;
				if (flag)
				{
					return XFashionDocument._fashionEffectTable.Table[i];
				}
			}
			return null;
		}

		public SeqListRef<uint> GetQualityEffect(int quality, int count, bool IsThreeSuit)
		{
			FashionEffectTable.RowData fashionEffectData = this.GetFashionEffectData((uint)quality, IsThreeSuit);
			bool flag = fashionEffectData == null;
			SeqListRef<uint> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fashion Quality config not found : " + (uint)quality, null, null, null, null, null);
				result = default(SeqListRef<uint>);
			}
			else
			{
				switch (count)
				{
				case 2:
					result = fashionEffectData.Effect2;
					break;
				case 3:
					result = fashionEffectData.Effect3;
					break;
				case 4:
					result = fashionEffectData.Effect4;
					break;
				case 5:
					result = fashionEffectData.Effect5;
					break;
				case 6:
					result = fashionEffectData.Effect6;
					break;
				case 7:
					result = fashionEffectData.Effect7;
					break;
				default:
					result = default(SeqListRef<uint>);
					break;
				}
			}
			return result;
		}

		public Dictionary<int, uint> GetTotalQualityCountOnBody(bool IsThreeSuit)
		{
			Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.FashionOnBody[i].itemID);
				bool flag = itemConf == null;
				if (!flag)
				{
					bool flag2 = IsThreeSuit ^ this.IsFashionThreeSpecial((int)this.FashionOnBody[i].itemID);
					if (!flag2)
					{
						bool flag3 = IsThreeSuit && this.GetFashionSuit((int)this.FashionOnBody[i].itemID) == 0;
						if (!flag3)
						{
							bool flag4 = dictionary.ContainsKey((int)itemConf.ItemQuality);
							if (flag4)
							{
								Dictionary<int, uint> dictionary2 = dictionary;
								int itemQuality = (int)itemConf.ItemQuality;
								dictionary2[itemQuality] += 1U;
							}
							else
							{
								dictionary.Add((int)itemConf.ItemQuality, 1U);
							}
						}
					}
				}
			}
			return dictionary;
		}

		public Dictionary<int, uint> GetTotalQualityCount(List<uint> fashionList, bool IsThreeSuit)
		{
			Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
			bool flag = fashionList == null;
			Dictionary<int, uint> result;
			if (flag)
			{
				result = dictionary;
			}
			else
			{
				for (int i = 0; i < fashionList.Count; i++)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)fashionList[i]);
					bool flag2 = itemConf == null;
					if (!flag2)
					{
						FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)fashionList[i]);
						bool flag3 = fashionConf == null;
						if (!flag3)
						{
							bool flag4 = IsThreeSuit ^ this.IsFashionThreeSpecial((int)fashionList[i]);
							if (!flag4)
							{
								bool flag5 = IsThreeSuit && this.GetFashionSuit((int)fashionList[i]) == 0;
								if (!flag5)
								{
									bool flag6 = dictionary.ContainsKey((int)itemConf.ItemQuality);
									if (flag6)
									{
										Dictionary<int, uint> dictionary2 = dictionary;
										int itemQuality = (int)itemConf.ItemQuality;
										dictionary2[itemQuality] += 1U;
									}
									else
									{
										dictionary.Add((int)itemConf.ItemQuality, 1U);
									}
								}
							}
						}
					}
				}
				result = dictionary;
			}
			return result;
		}

		public bool IsFashionThreeSpecial(int itemID)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(itemID);
			bool flag = fashionConf == null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Fashion ID not exists:" + itemID, null, null, null, null, null);
				result = false;
			}
			else
			{
				bool flag2 = (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionWings) || (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionTail) || (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionDecal);
				result = flag2;
			}
			return result;
		}

		public string GetQualityName(int quality)
		{
			bool flag = quality < this.QUALITY_NAME.Length;
			string result;
			if (flag)
			{
				result = this.QUALITY_NAME[quality];
			}
			else
			{
				result = "";
			}
			return result;
		}

		public int GetQualityCountOnBody(int quality, bool IsThreeSuit)
		{
			int num = 0;
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.FashionOnBody[i].itemID);
				bool flag = itemConf == null;
				if (!flag)
				{
					bool flag2 = IsThreeSuit ^ this.IsFashionThreeSpecial((int)this.FashionOnBody[i].itemID);
					if (!flag2)
					{
						bool flag3 = IsThreeSuit && this.GetFashionSuit((int)this.FashionOnBody[i].itemID) == 0;
						if (!flag3)
						{
							bool flag4 = quality == (int)itemConf.ItemQuality;
							if (flag4)
							{
								num++;
							}
						}
					}
				}
			}
			return num;
		}

		public int GetSuitPartCount(int suitID)
		{
			FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
			int num = 0;
			bool flag = bySuitID.FashionID != null;
			if (flag)
			{
				for (int i = 0; i < bySuitID.FashionID.Length; i++)
				{
					bool flag2 = this.OwnFashion((int)bySuitID.FashionID[i]);
					if (flag2)
					{
						num++;
					}
				}
			}
			return num;
		}

		public int GetSuitCollectCount(int suitID)
		{
			FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
			int num = 0;
			bool flag = bySuitID.FashionID != null;
			if (flag)
			{
				for (int i = 0; i < bySuitID.FashionID.Length; i++)
				{
					bool flag2 = this.HasCollected(bySuitID.FashionID[i]);
					if (flag2)
					{
						num++;
					}
				}
			}
			return num;
		}

		public SeqListRef<uint> GetSuitLevelEffect(int suitID, int level)
		{
			FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
			switch (level)
			{
			case 1:
			{
				bool flag = bySuitID.All1.Count > 0;
				if (flag)
				{
					return bySuitID.All1;
				}
				break;
			}
			case 2:
			{
				bool flag2 = bySuitID.All2.Count > 0;
				if (flag2)
				{
					return bySuitID.All2;
				}
				break;
			}
			case 3:
			{
				bool flag3 = bySuitID.All3.Count > 0;
				if (flag3)
				{
					return bySuitID.All3;
				}
				break;
			}
			case 4:
			{
				bool flag4 = bySuitID.All4.Count > 0;
				if (flag4)
				{
					return bySuitID.All4;
				}
				break;
			}
			}
			return default(SeqListRef<uint>);
		}

		public bool IsFashionEquipOn(ulong uid)
		{
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				bool flag = this.FashionOnBody[i].uid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.FashionBag.Clear();
			this.FashionOnBody.Clear();
			this.NewFashionList.Clear();
			this.Collections.Clear();
			bool flag = arg.PlayerInfo.fashionrecord != null;
			if (flag)
			{
				for (int i = 0; i < arg.PlayerInfo.fashionrecord.bagfashion.Count; i++)
				{
					this.FashionBag.Add(this.ConvertClientFashionData(arg.PlayerInfo.fashionrecord.bagfashion[i]));
				}
				for (int j = 0; j < arg.PlayerInfo.fashionrecord.bodyfashion.Count; j++)
				{
					this.FashionOnBody.Add(this.ConvertClientFashionData(arg.PlayerInfo.fashionrecord.bodyfashion[j]));
				}
				for (int k = 0; k < arg.PlayerInfo.fashionrecord.collected.Count; k++)
				{
					this.Collections.Add(arg.PlayerInfo.fashionrecord.collected[k]);
				}
			}
		}

		public void EquipSuit(int suitID)
		{
			FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(suitID);
			bool flag = bySuitID != null && bySuitID.FashionID != null;
			if (flag)
			{
				for (int i = 0; i < bySuitID.FashionID.Length; i++)
				{
					RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
					rpcC2G_UseItem.oArg.uid = (ulong)bySuitID.FashionID[i];
					rpcC2G_UseItem.oArg.count = 1U;
					rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionWear);
					XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
				}
			}
		}

		public int GetEquipCount(int suitID)
		{
			int num = 0;
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				int fashionSuit = this.GetFashionSuit((int)this.FashionOnBody[i].itemID);
				bool flag = fashionSuit == suitID;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		public int GetSuitTotalCount(int suitID)
		{
			FashionSuitTable.RowData suitData = this.GetSuitData(suitID);
			bool flag = suitData != null && suitData.FashionID != null;
			int result;
			if (flag)
			{
				result = suitData.FashionID.Length;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		public XItem MakeXItem(ClientFashionData d)
		{
			XItem xitem = XBagDocument.MakeXItem((int)d.itemID, false);
			bool flag = xitem != null;
			if (flag)
			{
				xitem.uid = d.uid;
			}
			return xitem;
		}

		public List<XItem> GetItem()
		{
			List<XItem> list = new List<XItem>();
			int i = 0;
			while (i < this.FashionBag.Count)
			{
				bool flag = this.fashion_filter >= 0;
				if (!flag)
				{
					goto IL_5A;
				}
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)this.FashionBag[i].itemID);
				bool flag2 = fashionConf == null || (int)fashionConf.EquipPos != this.fashion_filter;
				if (!flag2)
				{
					goto IL_5A;
				}
				IL_95:
				i++;
				continue;
				IL_5A:
				bool flag3 = this.IsFashionEquipOn(this.FashionBag[i].uid);
				if (flag3)
				{
					goto IL_95;
				}
				XItem item = this.MakeXItem(this.FashionBag[i]);
				list.Add(item);
				goto IL_95;
			}
			list.Sort(new Comparison<XItem>(this.FashionCompare));
			return list;
		}

		public void GetItem(ref List<XItem> ret, int filter = -1)
		{
			bool flag = ret == null;
			if (flag)
			{
				ret = new List<XItem>();
			}
			int i = 0;
			int count = this.FashionBag.Count;
			while (i < count)
			{
				int itemID = (int)this.FashionBag[i].itemID;
				bool flag2 = filter >= 0;
				if (!flag2)
				{
					goto IL_6E;
				}
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf(itemID);
				bool flag3 = fashionConf == null || (int)fashionConf.EquipPos != filter;
				if (!flag3)
				{
					goto IL_6E;
				}
				IL_AC:
				i++;
				continue;
				IL_6E:
				bool flag4 = this.IsFashionEquipOn(this.FashionBag[i].uid);
				if (flag4)
				{
					goto IL_AC;
				}
				XItem item = this.MakeXItem(this.FashionBag[i]);
				ret.Add(item);
				goto IL_AC;
			}
			i = 0;
			count = this.FashionOnBody.Count;
			while (i < count)
			{
				int itemID2 = (int)this.FashionOnBody[i].itemID;
				bool flag5 = filter >= 0;
				if (!flag5)
				{
					goto IL_115;
				}
				FashionList.RowData fashionConf2 = XBagDocument.GetFashionConf(itemID2);
				bool flag6 = fashionConf2 == null || (int)fashionConf2.EquipPos != filter;
				if (!flag6)
				{
					goto IL_115;
				}
				IL_134:
				i++;
				continue;
				IL_115:
				XItem item2 = this.MakeXItem(this.FashionOnBody[i]);
				ret.Add(item2);
				goto IL_134;
			}
		}

		public List<ClientFashionData> GetFashionInBag(int filter, bool justpersistent)
		{
			List<ClientFashionData> list = new List<ClientFashionData>();
			for (int i = 0; i < this.FashionBag.Count; i++)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.FashionBag[i].itemID);
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)this.FashionBag[i].itemID);
				bool flag = fashionConf == null;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("eData = null:" + this.FashionBag[i].itemID, null, null, null, null, null);
				}
				else
				{
					bool flag2 = (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionWings) || (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionTail) || (int)fashionConf.EquipPos == XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FashionDecal);
					if (!flag2)
					{
						bool flag3 = filter >= 0;
						if (flag3)
						{
							bool flag4 = fashionConf == null || (int)fashionConf.EquipPos != filter;
							if (flag4)
							{
								goto IL_107;
							}
						}
						bool flag5 = justpersistent && itemConf.TimeLimit > 0U;
						if (!flag5)
						{
							list.Add(this.FashionBag[i]);
						}
					}
				}
				IL_107:;
			}
			return list;
		}

		private int FashionCompare(XItem data1, XItem data2)
		{
			bool flag = data1 == null;
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				bool flag2 = data2 == null;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf(data1.itemID);
					ItemList.RowData itemConf2 = XBagDocument.GetItemConf(data2.itemID);
					bool flag3 = itemConf.ItemQuality > itemConf2.ItemQuality;
					if (flag3)
					{
						result = -1;
					}
					else
					{
						bool flag4 = itemConf.ItemQuality < itemConf2.ItemQuality;
						if (flag4)
						{
							result = 1;
						}
						else
						{
							int num;
							this.FashionSuitInfo.TryGetValue((uint)data1.itemID, out num);
							int num2;
							this.FashionSuitInfo.TryGetValue((uint)data2.itemID, out num2);
							bool flag5 = num > num2;
							if (flag5)
							{
								result = -1;
							}
							else
							{
								bool flag6 = num < num2;
								if (flag6)
								{
									result = 1;
								}
								else
								{
									result = data1.itemID.CompareTo(data2.itemID);
								}
							}
						}
					}
				}
			}
			return result;
		}

		public void ActivateFashion(ulong uid)
		{
			RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
			rpcC2G_UseItem.oArg.uid = uid;
			rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.ActivationFashion);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
		}

		public void EquipFashion(bool On, ulong uid, int fashionID)
		{
			if (On)
			{
				RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
				rpcC2G_UseItem.oArg.uid = uid;
				rpcC2G_UseItem.oArg.count = 1U;
				rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionWear);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
			}
			else
			{
				RpcC2G_UseItem rpcC2G_UseItem2 = new RpcC2G_UseItem();
				rpcC2G_UseItem2.oArg.uid = uid;
				rpcC2G_UseItem2.oArg.count = 1U;
				rpcC2G_UseItem2.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.FashionOff);
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem2);
			}
		}

		public void EquipFashionSuit(bool On, int fashionID)
		{
			if (On)
			{
				int fashionSuit = this.GetFashionSuit(fashionID);
				FashionSuitTable.RowData suitData = this.GetSuitData(fashionSuit);
				bool flag = suitData == null;
				if (!flag)
				{
					this.sendUids.Clear();
					bool flag2 = suitData.FashionID != null;
					if (flag2)
					{
						for (int i = 0; i < suitData.FashionID.Length; i++)
						{
							ClientFashionData clientFashionData = this.FindFashionLimitTimeFirst((int)suitData.FashionID[i]);
							bool flag3 = clientFashionData != null;
							if (flag3)
							{
								this.sendUids.Add(clientFashionData.uid);
							}
						}
					}
					this.SendEquipFashionSuit(this.sendUids, ItemUseMgr.GetItemUseValue(ItemUse.FashionSuitWear));
				}
			}
			else
			{
				bool flag4 = this.TryFindOverAllFashionSuit(fashionID, ref this.sendUids);
				if (flag4)
				{
					this.SendEquipFashionSuit(this.sendUids, ItemUseMgr.GetItemUseValue(ItemUse.FashionSuitOff));
				}
			}
		}

		private void SendEquipFashionSuit(List<ulong> uids, uint type)
		{
			RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
			rpcC2G_UseItem.oArg.uid = 0UL;
			rpcC2G_UseItem.oArg.count = 1U;
			rpcC2G_UseItem.oArg.OpType = type;
			rpcC2G_UseItem.oArg.uids.AddRange(uids);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
		}

		public bool TryFindOverAllFashionSuit(int fashionID, ref List<ulong> uids)
		{
			uids.Clear();
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(fashionID);
			bool flag = fashionConf == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ClientFashionData clientFashionData = this.FindFashionByPosInBody((int)fashionConf.EquipPos);
				bool flag2 = clientFashionData == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					int fashionSuit = this.GetFashionSuit((int)clientFashionData.itemID);
					FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(fashionSuit);
					bool flag3 = bySuitID == null || bySuitID.FashionID == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						int i = 0;
						int num = bySuitID.FashionID.Length;
						while (i < num)
						{
							ulong item;
							bool flag4 = this.TryFindFashionUidInBody((int)bySuitID.FashionID[i], out item);
							if (flag4)
							{
								uids.Add(item);
							}
							i++;
						}
						result = (uids.Count > 0);
					}
				}
			}
			return result;
		}

		public Dictionary<uint, uint> GetFashonListAttr(List<uint> fashions)
		{
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			for (int i = 0; i < fashions.Count; i++)
			{
				SeqListRef<uint> fashionAttr = this.GetFashionAttr((int)fashions[i], 0);
				for (int j = 0; j < fashionAttr.Count; j++)
				{
					bool flag = dictionary.ContainsKey(fashionAttr[j, 0]);
					if (flag)
					{
						Dictionary<uint, uint> dictionary2 = dictionary;
						uint key = fashionAttr[j, 0];
						dictionary2[key] += fashionAttr[j, 1];
					}
					else
					{
						dictionary.Add(fashionAttr[j, 0], fashionAttr[j, 1]);
					}
				}
			}
			return dictionary;
		}

		public Dictionary<uint, uint> GetOnBodyAttr()
		{
			Dictionary<uint, uint> dictionary = new Dictionary<uint, uint>();
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				SeqListRef<uint> fashionAttr = this.GetFashionAttr((int)this.FashionOnBody[i].itemID, 0);
				for (int j = 0; j < fashionAttr.Count; j++)
				{
					bool flag = dictionary.ContainsKey(fashionAttr[j, 0]);
					if (flag)
					{
						Dictionary<uint, uint> dictionary2 = dictionary;
						uint key = fashionAttr[j, 0];
						dictionary2[key] += fashionAttr[j, 1];
					}
					else
					{
						dictionary.Add(fashionAttr[j, 0], fashionAttr[j, 1]);
					}
				}
			}
			return dictionary;
		}

		public Dictionary<int, uint> GetFashonSuitAttr(List<uint> fashions)
		{
			Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
			for (int i = 0; i < fashions.Count; i++)
			{
				bool flag = fashions[i] == 0U;
				if (!flag)
				{
					int fashionSuit = this.GetFashionSuit((int)fashions[i]);
					bool flag2 = dictionary.ContainsKey(fashionSuit);
					if (flag2)
					{
						Dictionary<int, uint> dictionary2 = dictionary;
						int key = fashionSuit;
						dictionary2[key] += 1U;
					}
					else
					{
						dictionary.Add(fashionSuit, 1U);
					}
				}
			}
			return dictionary;
		}

		public Dictionary<int, uint> GetOnBodySuitAttr()
		{
			Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				bool flag = this.FashionOnBody[i].itemID == 0U;
				if (!flag)
				{
					bool flag2 = !this.IsFashionThreeSpecial((int)this.FashionOnBody[i].itemID);
					if (!flag2)
					{
						int fashionSuit = this.GetFashionSuit((int)this.FashionOnBody[i].itemID);
						bool flag3 = dictionary.ContainsKey(fashionSuit);
						if (flag3)
						{
							Dictionary<int, uint> dictionary2 = dictionary;
							int key = fashionSuit;
							dictionary2[key] += 1U;
						}
						else
						{
							dictionary.Add(fashionSuit, 1U);
						}
					}
				}
			}
			return dictionary;
		}

		public Dictionary<int, uint> GetFashionListSuitAttr(List<uint> fashionList)
		{
			Dictionary<int, uint> dictionary = new Dictionary<int, uint>();
			for (int i = 0; i < fashionList.Count; i++)
			{
				bool flag = fashionList[i] == 0U;
				if (!flag)
				{
					FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)fashionList[i]);
					bool flag2 = fashionConf == null;
					if (!flag2)
					{
						bool flag3 = !this.IsFashionThreeSpecial((int)fashionList[i]);
						if (!flag3)
						{
							int fashionSuit = this.GetFashionSuit((int)fashionList[i]);
							bool flag4 = fashionSuit == 0;
							if (!flag4)
							{
								bool flag5 = dictionary.ContainsKey(fashionSuit);
								if (flag5)
								{
									Dictionary<int, uint> dictionary2 = dictionary;
									int key = fashionSuit;
									dictionary2[key] += 1U;
								}
								else
								{
									dictionary.Add(fashionSuit, 1U);
								}
							}
						}
					}
				}
			}
			return dictionary;
		}

		public List<int> GetSuitCollectionList()
		{
			List<int> list = new List<int>();
			uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			for (int i = 0; i < XFashionDocument._fashionSuitTable.Table.Length; i++)
			{
				FashionSuitTable.RowData suitData = this.GetSuitData(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				bool flag = (ulong)level >= (ulong)((long)suitData.ShowLevel);
				if (flag)
				{
					list.Add(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				}
			}
			list.Sort(new Comparison<int>(this.SuitCollectionCompare));
			return list;
		}

		private int SuitCollectionCompare(int suitID1, int suitID2)
		{
			FashionSuitTable.RowData suitData = this.GetSuitData(suitID1);
			FashionSuitTable.RowData suitData2 = this.GetSuitData(suitID2);
			bool flag = suitData.FashionID != null && suitData2.FashionID != null;
			if (flag)
			{
				bool flag2 = suitData.FashionID == null || suitData.FashionID.Length < suitData2.FashionID.Length;
				if (flag2)
				{
					return -1;
				}
				bool flag3 = suitData2.FashionID == null || suitData.FashionID.Length > suitData2.FashionID.Length;
				if (flag3)
				{
					return 1;
				}
				bool flag4 = suitData.SuitQuality > suitData2.SuitQuality;
				if (flag4)
				{
					return -1;
				}
				bool flag5 = suitData.SuitQuality < suitData2.SuitQuality;
				if (flag5)
				{
					return 1;
				}
			}
			return suitID1.CompareTo(suitID2);
		}

		public bool HasCollected(uint fashionID)
		{
			return this.Collections.Contains(fashionID);
		}

		public override void Update(float fDeltaT)
		{
			bool flag = this.FashionOnBody == null || this.FashionBag == null;
			if (!flag)
			{
				for (int i = 0; i < this.FashionOnBody.Count; i++)
				{
					bool flag2 = this.FashionOnBody[i].timeleft > 0.0;
					if (flag2)
					{
						this.FashionOnBody[i].timeleft -= (double)Time.deltaTime;
					}
				}
				for (int j = 0; j < this.FashionBag.Count; j++)
				{
					bool flag3 = this.FashionBag[j].timeleft > 0.0;
					if (flag3)
					{
						this.FashionBag[j].timeleft -= (double)fDeltaT;
					}
				}
			}
		}

		public bool IsSuitNoSale(int suitID)
		{
			FashionSuitTable.RowData suitData = this.GetSuitData(suitID);
			return suitData.NoSale;
		}

		public bool FashionInBag(ulong uid)
		{
			for (int i = 0; i < this.FashionBag.Count; i++)
			{
				bool flag = this.FashionBag[i].uid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public bool FashionInBody(ulong uid)
		{
			for (int i = 0; i < this.FashionOnBody.Count; i++)
			{
				bool flag = this.FashionOnBody[i].uid == uid;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public bool TryGetFashionInBag(ulong uid, out ClientFashionData fashionData)
		{
			fashionData = null;
			for (int i = 0; i < this.FashionBag.Count; i++)
			{
				bool flag = this.FashionBag[i].uid == uid;
				if (flag)
				{
					fashionData = this.FashionBag[i];
					return true;
				}
			}
			return false;
		}

		public int GetFashionCount(int itemid)
		{
			int num = 0;
			for (int i = 0; i < this.FashionBag.Count; i++)
			{
				bool flag = (ulong)this.FashionBag[i].itemID == (ulong)((long)itemid);
				if (flag)
				{
					num++;
				}
			}
			for (int j = 0; j < this.FashionOnBody.Count; j++)
			{
				bool flag2 = (ulong)this.FashionOnBody[j].itemID == (ulong)((long)itemid);
				if (flag2)
				{
					num++;
				}
			}
			return num;
		}

		public bool ValidPart(int fashionID)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(fashionID);
			return fashionConf != null && (int)fashionConf.EquipPos <= XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_END);
		}

		public bool ShowSuitAllButton(ulong uid)
		{
			bool flag = this.FashionInBag(uid);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.FashionInBody(uid);
				result = flag2;
			}
			return result;
		}

		public bool IsOverAll(ulong uid)
		{
			ClientFashionData clientFashionData;
			bool flag = this.TryFindFashion(uid, out clientFashionData);
			if (flag)
			{
				int fashionSuit = this.GetFashionSuit((int)clientFashionData.itemID);
				FashionSuitTable.RowData bySuitID = XFashionDocument._fashionSuitTable.GetBySuitID(fashionSuit);
				bool flag2 = bySuitID != null;
				if (flag2)
				{
					return bySuitID.OverAll == 1;
				}
			}
			return false;
		}

		public int GetFullCollectionSuitCount()
		{
			int num = 0;
			for (int i = 0; i < XFashionDocument._fashionSuitTable.Table.Length; i++)
			{
				int suitCollectCount = this.GetSuitCollectCount(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				int suitTotalCount = this.GetSuitTotalCount(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				bool flag = suitCollectCount == suitTotalCount;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		public void GetSuitIcon(FashionSuitTable.RowData suitData, ref string atlas, ref string sprite)
		{
			uint itemID = 0U;
			bool flag = suitData.FashionID != null && suitData.FashionID.Length == 3;
			if (flag)
			{
				itemID = suitData.FashionID[0];
			}
			else
			{
				bool flag2 = suitData.FashionID != null && suitData.FashionID.Length == 7;
				if (flag2)
				{
					itemID = suitData.FashionID[1];
				}
			}
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
			atlas = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemAtlas, 0U);
			sprite = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon, 0U);
		}

		public bool CalRedPoint()
		{
			for (int i = 0; i < this.FashionBag.Count; i++)
			{
				bool flag = this.HasFashionRedPoint(this.FashionBag[i]);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public bool HasFashionRedPoint(ClientFashionData d)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)d.itemID);
			return fashionConf != null && (int)fashionConf.EquipPos < XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_END) && !this.IsValidFashionData(this.FashionOnBody[(int)fashionConf.EquipPos]);
		}

		public bool HasOneFashionSuit()
		{
			for (int i = 0; i < XFashionDocument._fashionSuitTable.Table.Length; i++)
			{
				int suitCollectCount = this.GetSuitCollectCount(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				int suitTotalCount = this.GetSuitTotalCount(XFashionDocument._fashionSuitTable.Table[i].SuitID);
				bool flag = suitCollectCount == suitTotalCount;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FashionDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public FashionBagHandler FashionDlg;

		private static FashionSuitTable _fashionSuitTable = new FashionSuitTable();

		private static FashionComposeTable _fashionComposeTable = new FashionComposeTable();

		private static FashionEffectTable _fashionEffectTable = new FashionEffectTable();

		private static FashionEnhanceFx _fashionEnhanceFx = new FashionEnhanceFx();

		protected Dictionary<uint, int> FashionSuitInfo = new Dictionary<uint, int>();

		protected Dictionary<int, bool> CachedFashionRedpoint = new Dictionary<int, bool>();

		private List<ulong> sendUids = new List<ulong>();

		private List<int> m_suitTemps = new List<int>();

		public int MAX_QUALITY = 6;

		public int fashion_filter = -1;

		private string[] QUALITY_NAME = new string[]
		{
			"D",
			"C",
			"B",
			"A",
			"S",
			"L"
		};

		protected bool _bShouldUpdateRedPoints = false;
	}
}
