using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A51 RID: 2641
	internal class EquipFusionDocument : XDocComponent
	{
		// Token: 0x17002EEE RID: 12014
		// (get) Token: 0x0600A03C RID: 41020 RVA: 0x001AC1A8 File Offset: 0x001AA3A8
		public override uint ID
		{
			get
			{
				return EquipFusionDocument.uuID;
			}
		}

		// Token: 0x17002EEF RID: 12015
		// (get) Token: 0x0600A03D RID: 41021 RVA: 0x001AC1C0 File Offset: 0x001AA3C0
		public static EquipFusionDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(EquipFusionDocument.uuID) as EquipFusionDocument;
			}
		}

		// Token: 0x17002EF0 RID: 12016
		// (get) Token: 0x0600A03E RID: 41022 RVA: 0x001AC1EB File Offset: 0x001AA3EB
		// (set) Token: 0x0600A03F RID: 41023 RVA: 0x001AC1F3 File Offset: 0x001AA3F3
		public EquipFusionHandler Handler { get; set; }

		// Token: 0x17002EF1 RID: 12017
		// (get) Token: 0x0600A040 RID: 41024 RVA: 0x001AC1FC File Offset: 0x001AA3FC
		public int NeedNum
		{
			get
			{
				return this.m_needNum;
			}
		}

		// Token: 0x17002EF2 RID: 12018
		// (get) Token: 0x0600A041 RID: 41025 RVA: 0x001AC214 File Offset: 0x001AA414
		public int MaterialId
		{
			get
			{
				return this.m_materialId;
			}
		}

		// Token: 0x17002EF3 RID: 12019
		// (get) Token: 0x0600A042 RID: 41026 RVA: 0x001AC22C File Offset: 0x001AA42C
		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		// Token: 0x17002EF4 RID: 12020
		// (get) Token: 0x0600A043 RID: 41027 RVA: 0x001AC244 File Offset: 0x001AA444
		public List<EquipFuseData> FuseDataList
		{
			get
			{
				return this.m_fuseDataList;
			}
		}

		// Token: 0x17002EF5 RID: 12021
		// (get) Token: 0x0600A044 RID: 41028 RVA: 0x001AC25C File Offset: 0x001AA45C
		// (set) Token: 0x0600A045 RID: 41029 RVA: 0x001AC264 File Offset: 0x001AA464
		public bool IsBreak { get; set; }

		// Token: 0x17002EF6 RID: 12022
		// (get) Token: 0x0600A046 RID: 41030 RVA: 0x001AC26D File Offset: 0x001AA46D
		// (set) Token: 0x0600A047 RID: 41031 RVA: 0x001AC275 File Offset: 0x001AA475
		public bool IsMax { get; set; }

		// Token: 0x0600A048 RID: 41032 RVA: 0x001AC280 File Offset: 0x001AA480
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

		// Token: 0x0600A049 RID: 41033 RVA: 0x001AC3F4 File Offset: 0x001AA5F4
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

		// Token: 0x0600A04A RID: 41034 RVA: 0x001AC560 File Offset: 0x001AA760
		public static void Execute(OnLoadedCallback callback = null)
		{
			EquipFusionDocument.AsyncLoader.AddTask("Table/EquipFusion", EquipFusionDocument.m_equipfusionTab, false);
			EquipFusionDocument.AsyncLoader.AddTask("Table/EquipFusionExp", EquipFusionDocument.m_equipFusionExpTab, false);
			EquipFusionDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A04B RID: 41035 RVA: 0x001AC59C File Offset: 0x001AA79C
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

		// Token: 0x0600A04C RID: 41036 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A04D RID: 41037 RVA: 0x001AC623 File Offset: 0x001AA823
		protected override void EventSubscribe()
		{
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
			base.EventSubscribe();
		}

		// Token: 0x0600A04E RID: 41038 RVA: 0x001AC642 File Offset: 0x001AA842
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			EquipFusionDocument.IsEquipDown = false;
		}

		// Token: 0x0600A04F RID: 41039 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600A050 RID: 41040 RVA: 0x001AC64C File Offset: 0x001AA84C
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

		// Token: 0x0600A051 RID: 41041 RVA: 0x001AC750 File Offset: 0x001AA950
		public void AddMaterial(int itemId)
		{
			this.m_materialId = itemId;
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.UpdateItem();
			}
		}

		// Token: 0x0600A052 RID: 41042 RVA: 0x001AC78C File Offset: 0x001AA98C
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

		// Token: 0x0600A053 RID: 41043 RVA: 0x001AC7FC File Offset: 0x001AA9FC
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

		// Token: 0x0600A054 RID: 41044 RVA: 0x001AC8D4 File Offset: 0x001AAAD4
		private void ClearSelectMaterial()
		{
			this.m_materialId = 0;
			this.m_needNum = 0;
		}

		// Token: 0x0600A055 RID: 41045 RVA: 0x001AC8E8 File Offset: 0x001AAAE8
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

		// Token: 0x0600A056 RID: 41046 RVA: 0x001ACAA0 File Offset: 0x001AACA0
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

		// Token: 0x0600A057 RID: 41047 RVA: 0x001ACC54 File Offset: 0x001AAE54
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

		// Token: 0x0600A058 RID: 41048 RVA: 0x001ACFA8 File Offset: 0x001AB1A8
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

		// Token: 0x0600A059 RID: 41049 RVA: 0x001AD168 File Offset: 0x001AB368
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

		// Token: 0x0600A05A RID: 41050 RVA: 0x001AD1D0 File Offset: 0x001AB3D0
		private bool OnAddItem(XEventArgs args)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.UpdateButtom();
			}
			return true;
		}

		// Token: 0x0600A05B RID: 41051 RVA: 0x001AD20C File Offset: 0x001AB40C
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

		// Token: 0x0600A05C RID: 41052 RVA: 0x001AD23C File Offset: 0x001AB43C
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

		// Token: 0x0600A05D RID: 41053 RVA: 0x001AD274 File Offset: 0x001AB474
		private static ulong MakeKey(uint profession, uint slot, uint equipType, uint breakNum)
		{
			return (ulong)profession << 48 | (ulong)slot << 32 | (ulong)((ulong)equipType << 16) | (ulong)breakNum;
		}

		// Token: 0x0600A05E RID: 41054 RVA: 0x001AD29C File Offset: 0x001AB49C
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

		// Token: 0x0600A05F RID: 41055 RVA: 0x001AD318 File Offset: 0x001AB518
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

		// Token: 0x04003970 RID: 14704
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EquipFusionDocument");

		// Token: 0x04003971 RID: 14705
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003972 RID: 14706
		public static EquipFusionExpTable m_equipFusionExpTab = new EquipFusionExpTable();

		// Token: 0x04003973 RID: 14707
		public static EquipFusionTable m_equipfusionTab = new EquipFusionTable();

		// Token: 0x04003974 RID: 14708
		private ulong m_selectUid = 0UL;

		// Token: 0x04003975 RID: 14709
		private int m_materialId = 0;

		// Token: 0x04003976 RID: 14710
		private int m_needNum = 0;

		// Token: 0x04003977 RID: 14711
		private List<EquipFuseData> m_fuseDataList = new List<EquipFuseData>();

		// Token: 0x04003978 RID: 14712
		private Dictionary<uint, string> m_effectPathDic;

		// Token: 0x04003979 RID: 14713
		private Dictionary<uint, string> m_fuseIconNameDic;

		// Token: 0x0400397D RID: 14717
		public static bool IsEquipDown = false;

		// Token: 0x0400397E RID: 14718
		private Dictionary<uint, XTuple<uint, uint>> m_addAttrDic = new Dictionary<uint, XTuple<uint, uint>>();

		// Token: 0x0400397F RID: 14719
		private static Dictionary<ulong, EquipFusionTable.RowData> m_equipFusionDic = new Dictionary<ulong, EquipFusionTable.RowData>();
	}
}
