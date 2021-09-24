using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipFusionDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return EquipFusionDocument.uuID;
			}
		}

		public static EquipFusionDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(EquipFusionDocument.uuID) as EquipFusionDocument;
			}
		}

		public EquipFusionHandler Handler { get; set; }

		public int NeedNum
		{
			get
			{
				return this.m_needNum;
			}
		}

		public int MaterialId
		{
			get
			{
				return this.m_materialId;
			}
		}

		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		public List<EquipFuseData> FuseDataList
		{
			get
			{
				return this.m_fuseDataList;
			}
		}

		public bool IsBreak { get; set; }

		public bool IsMax { get; set; }

		public bool GetEffectPath(uint breakLevel, out string path)
		{
			bool flag = this.m_effectPathDic == null;
			if (flag)
			{
				this.m_effectPathDic = new Dictionary<uint, string>();
				string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("EquipfuseLevelEffectPath", XGlobalConfig.AllSeparators);
				for (int i = 0; i < andSeparateValue.Length; i += 2)
				{
					bool flag2 = i + 1 == andSeparateValue.Length;
					if (flag2)
					{
						break;
					}
					uint key;
					bool flag3 = uint.TryParse(andSeparateValue[i], out key);
					if (flag3)
					{
						bool flag4 = !this.m_effectPathDic.ContainsKey(key);
						if (flag4)
						{
							this.m_effectPathDic.Add(key, andSeparateValue[i + 1]);
						}
					}
				}
			}
			int num = 0;
			uint key2 = 0U;
			foreach (KeyValuePair<uint, string> keyValuePair in this.m_effectPathDic)
			{
				bool flag5 = num == 0;
				if (flag5)
				{
					bool flag6 = breakLevel < keyValuePair.Key;
					if (flag6)
					{
						break;
					}
					key2 = keyValuePair.Key;
				}
				else
				{
					bool flag7 = breakLevel >= keyValuePair.Key;
					if (flag7)
					{
						key2 = keyValuePair.Key;
					}
				}
				num++;
			}
			path = string.Empty;
			bool flag8 = this.m_effectPathDic.ContainsKey(key2);
			bool result;
			if (flag8)
			{
				path = this.m_effectPathDic[key2];
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public string GetFuseIconName(uint breakLevel)
		{
			bool flag = this.m_fuseIconNameDic == null;
			if (flag)
			{
				this.m_fuseIconNameDic = new Dictionary<uint, string>();
				string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("EquipFuseIconNames", XGlobalConfig.AllSeparators);
				for (int i = 0; i < andSeparateValue.Length; i += 2)
				{
					bool flag2 = i + 1 == andSeparateValue.Length;
					if (flag2)
					{
						break;
					}
					uint key;
					bool flag3 = uint.TryParse(andSeparateValue[i], out key);
					if (flag3)
					{
						bool flag4 = !this.m_fuseIconNameDic.ContainsKey(key);
						if (flag4)
						{
							this.m_fuseIconNameDic.Add(key, andSeparateValue[i + 1]);
						}
					}
				}
			}
			int num = 0;
			uint key2 = 0U;
			foreach (KeyValuePair<uint, string> keyValuePair in this.m_fuseIconNameDic)
			{
				bool flag5 = num == 0;
				if (flag5)
				{
					bool flag6 = breakLevel < keyValuePair.Key;
					if (flag6)
					{
						break;
					}
					key2 = keyValuePair.Key;
				}
				else
				{
					bool flag7 = breakLevel >= keyValuePair.Key;
					if (flag7)
					{
						key2 = keyValuePair.Key;
					}
				}
				num++;
			}
			bool flag8 = this.m_fuseIconNameDic.ContainsKey(key2);
			string result;
			if (flag8)
			{
				result = this.m_fuseIconNameDic[key2];
			}
			else
			{
				result = "";
			}
			return result;
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			EquipFusionDocument.AsyncLoader.AddTask("Table/EquipFusion", EquipFusionDocument.m_equipfusionTab, false);
			EquipFusionDocument.AsyncLoader.AddTask("Table/EquipFusionExp", EquipFusionDocument.m_equipFusionExpTab, false);
			EquipFusionDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
			for (int i = 0; i < EquipFusionDocument.m_equipfusionTab.Table.Length; i++)
			{
				EquipFusionTable.RowData rowData = EquipFusionDocument.m_equipfusionTab.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					ulong key = EquipFusionDocument.MakeKey(rowData.Profession, (uint)rowData.Slot, (uint)rowData.EquipType, (uint)rowData.BreakNum);
					bool flag2 = !EquipFusionDocument.m_equipFusionDic.ContainsKey(key);
					if (flag2)
					{
						EquipFusionDocument.m_equipFusionDic.Add(key, rowData);
					}
				}
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.EventSubscribe();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			EquipFusionDocument.IsEquipDown = false;
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		public void SelectEquip(ulong uid)
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
				bool flag2 = equipConf == null;
				if (!flag2)
				{
					bool flag3 = equipConf.FuseCanBreakNum == 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CanNotFusion"), "fece00");
					}
					else
					{
						this.m_selectUid = uid;
						this.SetFuseData();
						bool flag4 = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
						if (!flag4)
						{
							bool flag5 = this.Handler != null && this.Handler.IsVisible();
							if (flag5)
							{
								this.ClearSelectMaterial();
								this.Handler.ShowUI(false);
							}
							else
							{
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipFusionHandler);
							}
							bool flag6 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
							if (flag6)
							{
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
							}
						}
					}
				}
			}
		}

		public void AddMaterial(int itemId)
		{
			this.m_materialId = itemId;
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.UpdateItem();
			}
		}

		public void ReqEquipFuseMes()
		{
			RpcC2G_FuseEquip rpcC2G_FuseEquip = new RpcC2G_FuseEquip();
			rpcC2G_FuseEquip.oArg.uid = this.m_selectUid;
			bool flag = !this.IsBreak;
			if (flag)
			{
				rpcC2G_FuseEquip.oArg.type = 0U;
			}
			else
			{
				rpcC2G_FuseEquip.oArg.type = 1U;
			}
			rpcC2G_FuseEquip.oArg.itemID = (uint)this.MaterialId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_FuseEquip);
		}

		public void OnGetEquipFuseInfo(FuseEquipRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
			}
			else
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
				if (flag2)
				{
					string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
					XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
				}
				else
				{
					bool flag3 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
					}
					else
					{
						bool isBreak = this.IsBreak;
						this.SetFuseData();
						bool flag4 = isBreak || this.IsBreak;
						if (flag4)
						{
							this.ClearSelectMaterial();
						}
						bool flag5 = this.Handler != null && this.Handler.IsVisible();
						if (flag5)
						{
							this.Handler.ShowUI(isBreak);
						}
					}
				}
			}
		}

		private void ClearSelectMaterial()
		{
			this.m_materialId = 0;
			this.m_needNum = 0;
		}

		public List<EquipFuseData> GetNowFuseData(XItem item, uint profession)
		{
			List<EquipFuseData> list = new List<EquipFuseData>();
			bool flag = item == null || item.Type != ItemType.EQUIP;
			List<EquipFuseData> result;
			if (flag)
			{
				result = list;
			}
			else
			{
				EquipList.RowData equipConf = XBagDocument.GetEquipConf(item.itemID);
				bool flag2 = equipConf == null;
				if (flag2)
				{
					result = list;
				}
				else
				{
					XEquipItem xequipItem = item as XEquipItem;
					this.GetTotalAddAttr(xequipItem.fuseInfo, equipConf, profession, false);
					for (int i = 0; i < xequipItem.changeAttr.Count; i++)
					{
						EquipFuseData equipFuseData = new EquipFuseData();
						equipFuseData.Init();
						equipFuseData.AttrId = xequipItem.changeAttr[i].AttrID;
						equipFuseData.BeforeBaseAttrNum = xequipItem.changeAttr[i].AttrValue;
						bool flag3 = this.m_addAttrDic.ContainsKey(equipFuseData.AttrId);
						if (flag3)
						{
							equipFuseData.BeforeAddNum = this.m_addAttrDic[equipFuseData.AttrId].Item1;
							this.m_addAttrDic.Remove(equipFuseData.AttrId);
						}
						list.Add(equipFuseData);
					}
					foreach (KeyValuePair<uint, XTuple<uint, uint>> keyValuePair in this.m_addAttrDic)
					{
						EquipFuseData equipFuseData2 = new EquipFuseData();
						equipFuseData2.Init();
						equipFuseData2.AttrId = keyValuePair.Key;
						equipFuseData2.BeforeBaseAttrNum = keyValuePair.Value.Item1;
						equipFuseData2.IsExtra = true;
						list.Add(equipFuseData2);
					}
					result = list;
				}
			}
			return result;
		}

		private void SetFuseData()
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_selectUid);
			bool flag = itemByUID == null || itemByUID.Type != ItemType.EQUIP;
			if (!flag)
			{
				bool flag2 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (!flag2)
				{
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(itemByUID.itemID);
					bool flag3 = equipConf == null;
					if (!flag3)
					{
						this.m_fuseDataList.Clear();
						XEquipItem xequipItem = itemByUID as XEquipItem;
						int breakNum = (int)xequipItem.fuseInfo.BreakNum;
						EquipFusionTable.RowData fuseData = this.GetFuseData(XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, equipConf, (uint)breakNum);
						bool flag4 = fuseData == null;
						if (!flag4)
						{
							this.IsBreak = (xequipItem.fuseInfo.FuseExp >= fuseData.LevelNum * fuseData.NeedExpPerLevel);
							this.IsMax = (this.IsBreak && breakNum >= (int)equipConf.FuseCanBreakNum);
							this.GetTotalAddAttr(xequipItem.fuseInfo, equipConf, XSingleton<XEntityMgr>.singleton.Player.BasicTypeID, true);
							foreach (KeyValuePair<uint, XTuple<uint, uint>> keyValuePair in this.m_addAttrDic)
							{
								EquipFuseData equipFuseData = new EquipFuseData();
								equipFuseData.Init();
								equipFuseData.AttrId = keyValuePair.Key;
								equipFuseData.BeforeAddNum = keyValuePair.Value.Item1;
								equipFuseData.AfterAddNum = keyValuePair.Value.Item2;
								this.m_fuseDataList.Add(equipFuseData);
							}
						}
					}
				}
			}
		}

		private void GetTotalAddAttr(XequipFuseInfo info, EquipList.RowData equipRow, uint profession, bool needNextAttr)
		{
			this.m_addAttrDic.Clear();
			int num = 0;
			while ((long)num < (long)((ulong)(info.BreakNum + 1U)))
			{
				EquipFusionTable.RowData fuseData = this.GetFuseData(profession, equipRow, (uint)num);
				bool flag = fuseData == null;
				if (!flag)
				{
					bool flag2 = (long)num == (long)((ulong)info.BreakNum);
					if (flag2)
					{
						for (int i = 0; i < (int)fuseData.LevelAddAttr.count; i++)
						{
							uint num2 = info.FuseExp / fuseData.NeedExpPerLevel;
							num2 = ((num2 > fuseData.LevelNum) ? fuseData.LevelNum : num2);
							bool flag3 = !this.m_addAttrDic.ContainsKey(fuseData.LevelAddAttr[i, 0]);
							if (flag3)
							{
								XTuple<uint, uint> xtuple = new XTuple<uint, uint>();
								xtuple.Item1 = fuseData.LevelAddAttr[i, 1] * num2;
								this.m_addAttrDic.Add(fuseData.LevelAddAttr[i, 0], xtuple);
							}
							else
							{
								this.m_addAttrDic[fuseData.LevelAddAttr[i, 0]].Item1 += fuseData.LevelAddAttr[i, 1] * num2;
							}
						}
					}
					else
					{
						for (int j = 0; j < (int)fuseData.LevelAddAttr.count; j++)
						{
							bool flag4 = !this.m_addAttrDic.ContainsKey(fuseData.LevelAddAttr[j, 0]);
							if (flag4)
							{
								XTuple<uint, uint> xtuple2 = new XTuple<uint, uint>();
								xtuple2.Item1 = fuseData.LevelAddAttr[j, 1] * fuseData.LevelNum;
								this.m_addAttrDic.Add(fuseData.LevelAddAttr[j, 0], xtuple2);
							}
							else
							{
								this.m_addAttrDic[fuseData.LevelAddAttr[j, 0]].Item1 += fuseData.LevelAddAttr[j, 1] * fuseData.LevelNum;
							}
						}
						for (int k = 0; k < (int)fuseData.BreakAddAttr.count; k++)
						{
							bool flag5 = !this.m_addAttrDic.ContainsKey(fuseData.BreakAddAttr[k, 0]);
							if (flag5)
							{
								XTuple<uint, uint> xtuple3 = new XTuple<uint, uint>();
								xtuple3.Item1 = fuseData.BreakAddAttr[k, 1];
								this.m_addAttrDic.Add(fuseData.BreakAddAttr[k, 0], xtuple3);
							}
							else
							{
								this.m_addAttrDic[fuseData.BreakAddAttr[k, 0]].Item1 += fuseData.BreakAddAttr[k, 1];
							}
						}
					}
				}
				num++;
			}
			foreach (KeyValuePair<uint, XTuple<uint, uint>> keyValuePair in this.m_addAttrDic)
			{
				keyValuePair.Value.Item2 = keyValuePair.Value.Item1;
			}
			bool flag6 = needNextAttr && !this.IsMax;
			if (flag6)
			{
				this.GetNextTotalAddAttr(info, equipRow, profession);
			}
		}

		private void GetNextTotalAddAttr(XequipFuseInfo info, EquipList.RowData equipRow, uint profession)
		{
			EquipFusionTable.RowData fuseData = this.GetFuseData(profession, equipRow, info.BreakNum);
			bool flag = fuseData == null;
			if (!flag)
			{
				bool flag2 = info.FuseExp >= fuseData.LevelNum * fuseData.NeedExpPerLevel;
				if (flag2)
				{
					for (int i = 0; i < (int)fuseData.BreakAddAttr.count; i++)
					{
						bool flag3 = !this.m_addAttrDic.ContainsKey(fuseData.BreakAddAttr[i, 0]);
						if (flag3)
						{
							XTuple<uint, uint> xtuple = new XTuple<uint, uint>();
							xtuple.Item2 = fuseData.BreakAddAttr[i, 1];
							this.m_addAttrDic.Add(fuseData.BreakAddAttr[i, 0], xtuple);
						}
						else
						{
							this.m_addAttrDic[fuseData.BreakAddAttr[i, 0]].Item2 += fuseData.BreakAddAttr[i, 1];
						}
					}
				}
				else
				{
					for (int j = 0; j < (int)fuseData.LevelAddAttr.count; j++)
					{
						bool flag4 = !this.m_addAttrDic.ContainsKey(fuseData.LevelAddAttr[j, 0]);
						if (flag4)
						{
							XTuple<uint, uint> xtuple2 = new XTuple<uint, uint>();
							xtuple2.Item2 = fuseData.LevelAddAttr[j, 1];
							this.m_addAttrDic.Add(fuseData.LevelAddAttr[j, 0], xtuple2);
						}
						else
						{
							this.m_addAttrDic[fuseData.LevelAddAttr[j, 0]].Item2 += fuseData.LevelAddAttr[j, 1];
						}
					}
				}
			}
		}

		private bool IsNewAttr(uint attrId, uint attrNum)
		{
			for (int i = 0; i < this.m_fuseDataList.Count; i++)
			{
				bool flag = this.m_fuseDataList[i].AttrId == attrId;
				if (flag)
				{
					this.m_fuseDataList[i].AfterAddNum += attrNum;
					return false;
				}
			}
			return true;
		}

		private bool OnAddItem(XEventArgs args)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.UpdateButtom();
			}
			return true;
		}

		public uint GetAddExp(uint coreItemId)
		{
			EquipFusionExpTable.RowData byCoreItemId = EquipFusionDocument.m_equipFusionExpTab.GetByCoreItemId(coreItemId);
			bool flag = byCoreItemId != null;
			uint result;
			if (flag)
			{
				result = byCoreItemId.AddExp;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		public SeqListRef<uint> GetAssistItems(uint coreItemId)
		{
			EquipFusionExpTable.RowData byCoreItemId = EquipFusionDocument.m_equipFusionExpTab.GetByCoreItemId(coreItemId);
			bool flag = byCoreItemId != null;
			SeqListRef<uint> result;
			if (flag)
			{
				result = byCoreItemId.AssistItemId;
			}
			else
			{
				result = default(SeqListRef<uint>);
			}
			return result;
		}

		private static ulong MakeKey(uint profession, uint slot, uint equipType, uint breakNum)
		{
			return (ulong)profession << 48 | (ulong)slot << 32 | (ulong)((ulong)equipType << 16) | (ulong)breakNum;
		}

		public EquipFusionTable.RowData GetFuseData(uint profession, uint slot, uint equipType, uint breakNum)
		{
			ulong key = EquipFusionDocument.MakeKey(profession, slot, equipType, breakNum);
			EquipFusionTable.RowData result = null;
			bool flag = !EquipFusionDocument.m_equipFusionDic.TryGetValue(key, out result);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("the data not exit int equipFusion.txt,profession = {0},slot = {1},equipType = {2},breakNum = {3}", new object[]
				{
					profession,
					slot,
					equipType,
					breakNum
				}), null, null, null, null, null);
			}
			return result;
		}

		public EquipFusionTable.RowData GetFuseData(uint profession, EquipList.RowData row, uint breakNum)
		{
			bool flag = row == null;
			EquipFusionTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.GetFuseData(profession, (uint)row.EquipPos, (uint)row.EquipType, breakNum);
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EquipFusionDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static EquipFusionExpTable m_equipFusionExpTab = new EquipFusionExpTable();

		public static EquipFusionTable m_equipfusionTab = new EquipFusionTable();

		private ulong m_selectUid = 0UL;

		private int m_materialId = 0;

		private int m_needNum = 0;

		private List<EquipFuseData> m_fuseDataList = new List<EquipFuseData>();

		private Dictionary<uint, string> m_effectPathDic;

		private Dictionary<uint, string> m_fuseIconNameDic;

		public static bool IsEquipDown = false;

		private Dictionary<uint, XTuple<uint, uint>> m_addAttrDic = new Dictionary<uint, XTuple<uint, uint>>();

		private static Dictionary<ulong, EquipFusionTable.RowData> m_equipFusionDic = new Dictionary<ulong, EquipFusionTable.RowData>();
	}
}
