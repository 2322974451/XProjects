using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEquipCreateDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XEquipCreateDocument.uuID;
			}
		}

		public static XEquipCreateDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XEquipCreateDocument.uuID) as XEquipCreateDocument;
			}
		}

		public XEquipCreateDocument()
		{
			this._onTimeCb = new XTimerMgr.AccurateElapsedEventHandler(this.OnTimer);
		}

		public static ItemComposeTable ItemComposeReader
		{
			get
			{
				return XEquipCreateDocument.sItemComposeReader;
			}
		}

		public string DefaultEmblemAttrString
		{
			get
			{
				return XEquipCreateDocument.sDefaultEmblemAttrString;
			}
		}

		public string EmblemAttrEndString
		{
			get
			{
				return XEquipCreateDocument.sEmblemAttrEndString;
			}
		}

		public bool RedPointEquip
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_EquipCreate_EquipSet) & this.mRedPointEquip;
			}
			set
			{
				this.mRedPointEquip = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_EquipCreate_EquipSet, true);
			}
		}

		public bool RedPointEmblem
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_EquipCreate_EmblemSet) & this.mRedPointEmblem;
			}
			set
			{
				this.mRedPointEmblem = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_EquipCreate_EmblemSet, true);
			}
		}

		public bool IsForbidGetItemUI
		{
			get
			{
				bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.IsVisible();
				bool result;
				if (flag)
				{
					result = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.IsVisible();
				}
				else
				{
					bool flag2 = XSuperRiskDocument.Doc.GameViewHandler != null && XSuperRiskDocument.Doc.GameViewHandler.IsVisible();
					if (flag2)
					{
						result = true;
					}
					else
					{
						bool flag3 = DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.IsVisible();
						result = flag3;
					}
				}
				return result;
			}
		}

		public int CurRoleProf
		{
			get
			{
				bool flag = -1 == this.mCurRoleProf;
				if (flag)
				{
					this.mCurRoleProf = this._GetCurrentPlayerProf();
				}
				return this.mCurRoleProf;
			}
		}

		public int NextShowLevel
		{
			get
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ShowStageMoreThanCurStage");
				int num = 0;
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				for (int i = XEquipCreateDocument.sEquipSuitLevelList.Count - 1; i > 0; i--)
				{
					bool flag = XEquipCreateDocument.sEquipSuitLevelList[i] > level;
					if (flag)
					{
						num = i;
						num -= @int - 1;
						break;
					}
				}
				bool flag2 = num < 1;
				if (flag2)
				{
					num = 1;
				}
				return XEquipCreateDocument.sEquipSuitLevelList[num];
			}
		}

		public int LastShowLevel
		{
			get
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("ShowStageLessThanCurStage");
				int num = 1;
				int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				for (int i = XEquipCreateDocument.sEquipSuitLevelList.Count - 1; i > 0; i--)
				{
					bool flag = XEquipCreateDocument.sEquipSuitLevelList[i] > level;
					if (flag)
					{
						num = i;
						num += @int + 1;
						break;
					}
				}
				bool flag2 = num == 1;
				if (flag2)
				{
					num += @int;
				}
				bool flag3 = num >= XEquipCreateDocument.sEquipSuitLevelList.Count;
				if (flag3)
				{
					num = XEquipCreateDocument.sEquipSuitLevelList.Count - 1;
				}
				return XEquipCreateDocument.sEquipSuitLevelList[num];
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XEquipCreateDocument.AsyncLoader.AddTask("Table/ItemCompose", XEquipCreateDocument.sItemComposeReader, false);
			XEquipCreateDocument.AsyncLoader.AddTask("Table/EquipSuit", XEquipCreateDocument.sEquipSuitTable, false);
			XEquipCreateDocument.AsyncLoader.AddTask("Table/AttributeEmblem", XEquipCreateDocument.sAttributeEmblemTable, false);
			XEquipCreateDocument.AsyncLoader.Execute(callback);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		public static void OnTableLoaded()
		{
			XEquipCreateDocument.sEmblemAttrEndString = XStringDefineProxy.GetString("EQUIPCREATE_EMBLEMSET_ATTR_END_FMT").Replace("{n}", "\n");
			XEquipCreateDocument.sDefaultEmblemAttrString = XStringDefineProxy.GetString("EQUIPCREATE_EMBLEMSET_ATTR_DEFAULT").Replace("{n}", "\n");
			XEquipCreateDocument.CoinId = XSingleton<XGlobalConfig>.singleton.GetInt("CoinItemID");
			XEquipCreateDocument.sEquipSuitQualityGroupList.Clear();
			Dictionary<int, List<EquipSuitMenuDataItem>> dictionary = new Dictionary<int, List<EquipSuitMenuDataItem>>();
			XCharacterEquipDocument.CreateSuitManager(XEquipCreateDocument.sEquipSuitTable);
			for (int i = 0; i < XEquipCreateDocument.sEquipSuitTable.Table.Length; i++)
			{
				EquipSuitTable.RowData rowData = XEquipCreateDocument.sEquipSuitTable.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					bool isCreateShow = rowData.IsCreateShow;
					if (isCreateShow)
					{
						List<EquipSuitMenuDataItem> list = null;
						bool flag2 = !dictionary.TryGetValue(rowData.SuitQuality, out list);
						if (flag2)
						{
							list = new List<EquipSuitMenuDataItem>();
							dictionary.Add(rowData.SuitQuality, list);
						}
						EquipSuitMenuDataItem equipSuitMenuDataItem = new EquipSuitMenuDataItem();
						equipSuitMenuDataItem.suitData = rowData;
						equipSuitMenuDataItem.show = true;
						equipSuitMenuDataItem.suitItemList = new List<EquipSuitItemData>();
						XEquipCreateDocument._GetEquipSuitList(rowData.SuitID, ref equipSuitMenuDataItem.suitItemList);
						XEquipCreateDocument.sEquipSuitIDMenuDataDic[rowData.SuitID] = equipSuitMenuDataItem;
						list.Add(equipSuitMenuDataItem);
					}
				}
			}
			foreach (KeyValuePair<int, List<EquipSuitMenuDataItem>> keyValuePair in dictionary)
			{
				bool flag3 = keyValuePair.Value.Count > 0;
				if (flag3)
				{
					EquipSuitMenuData equipSuitMenuData = new EquipSuitMenuData();
					equipSuitMenuData.quality = keyValuePair.Key;
					equipSuitMenuData.list = keyValuePair.Value;
					XEquipCreateDocument.sEquipSuitQualityGroupList.Add(equipSuitMenuData);
				}
			}
			XEquipCreateDocument.sEquipSuitQualityGroupList.Sort();
			XEquipCreateDocument.InitQuanlityLevelDic();
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.mRedPointEquip = false;
			this.mRedPointEmblem = false;
			this.mItemTypeListDirty = false;
			this.mLastItemTypeListLevel = -1;
			this.mCurSelectLevel = 0;
			this.mCurSelectProf = 0;
			this.mCurRoleProf = -1;
			this.mTimerID = 0U;
			this.mTimerCount = 0;
			this.mCurComposeID = 0;
			this.CurUid = 0UL;
			this.mMainProfDataList = XSingleton<XProfessionSkillMgr>.singleton.GetMainProfList();
			XSingleton<XEquipCreateStaticData>.singleton.Init();
		}

		public override void OnDetachFromHost()
		{
			this.mDataUIList = null;
			this.mMainProfDataList = null;
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.CheckLevelUp(arg.PlayerInfo.Brief.level);
			this.IsCreating = false;
			bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.IsVisible();
				if (flag2)
				{
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetVisible(false);
				}
			}
		}

		private static void InitQuanlityLevelDic()
		{
			XEquipCreateDocument.m_quanlityLevelDic.Clear();
			XEquipCreateDocument.sEquipSuitLevelList.Clear();
			XEquipCreateDocument.InitItemQuanlityTypeDic();
			for (int i = 0; i < XEquipCreateDocument.sEquipSuitQualityGroupList.Count; i++)
			{
				EquipSuitMenuData equipSuitMenuData = XEquipCreateDocument.sEquipSuitQualityGroupList[i];
				bool flag = equipSuitMenuData == null;
				if (!flag)
				{
					for (int j = 0; j < equipSuitMenuData.list.Count; j++)
					{
						EquipSuitMenuDataItem equipSuitMenuDataItem = equipSuitMenuData.list[j];
						bool flag2 = equipSuitMenuDataItem == null || equipSuitMenuDataItem.suitData == null;
						if (!flag2)
						{
							int level = equipSuitMenuDataItem.suitData.Level;
							bool flag3 = level != 0 && !XEquipCreateDocument.sEquipSuitLevelList.Contains(level);
							if (flag3)
							{
								XEquipCreateDocument.sEquipSuitLevelList.Add(level);
							}
							int key = 0;
							bool flag4 = XEquipCreateDocument.m_itemQuanlityTypeDic.TryGetValue(equipSuitMenuData.quality, out key);
							if (flag4)
							{
								bool flag5 = XEquipCreateDocument.m_quanlityLevelDic.ContainsKey(key);
								if (flag5)
								{
									bool flag6 = !XEquipCreateDocument.m_quanlityLevelDic[key].Contains(level);
									if (flag6)
									{
										XEquipCreateDocument.m_quanlityLevelDic[key].Add(level);
									}
								}
								else
								{
									List<int> list = new List<int>();
									list.Add(level);
									XEquipCreateDocument.m_quanlityLevelDic.Add(key, list);
								}
							}
							else
							{
								XSingleton<XDebug>.singleton.AddErrorLog(string.Format("m_itemQuanlityTypeDic not include suitMenuData.quality = {0}", equipSuitMenuData.quality), null, null, null, null, null);
							}
						}
					}
				}
			}
			foreach (KeyValuePair<int, List<int>> keyValuePair in XEquipCreateDocument.m_quanlityLevelDic)
			{
				keyValuePair.Value.Sort();
			}
			XEquipCreateDocument.sEquipSuitLevelList.Sort();
			XEquipCreateDocument.sEquipSuitLevelList.Add(0);
			XEquipCreateDocument.sEquipSuitLevelList.Reverse();
		}

		private static void InitItemQuanlityTypeDic()
		{
			XEquipCreateDocument.m_itemQuanlityTypeDic.Clear();
			string[] array = XSingleton<XGlobalConfig>.singleton.GetValue("RedDotByQuanlityClass").Split(XGlobalConfig.ListSeparator);
			bool flag = array != null;
			if (flag)
			{
				for (int i = 0; i < array.Length; i++)
				{
					bool flag2 = array[i] == null;
					if (!flag2)
					{
						string[] array2 = array[i].Split(XGlobalConfig.SequenceSeparator);
						bool flag3 = array2 != null;
						if (flag3)
						{
							for (int j = 0; j < array2.Length; j++)
							{
								XEquipCreateDocument.m_itemQuanlityTypeDic.Add(int.Parse(array2[j]), i);
							}
						}
					}
				}
			}
		}

		public static bool InEquipSuit(int suitID, bool prof = true)
		{
			EquipSuitTable.RowData suitBySuitId = XCharacterEquipDocument.SuitManager.GetSuitBySuitId(suitID);
			bool flag = suitBySuitId == null;
			return !flag && (!prof || (long)suitBySuitId.ProfID == (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID));
		}

		public int CurShowLevel(uint curLevel, int quanlity = -1)
		{
			List<int> list = null;
			int num = -1;
			bool flag = quanlity == -1;
			if (flag)
			{
				list = XEquipCreateDocument.sEquipSuitLevelList;
			}
			else
			{
				int num2 = 0;
				bool flag2 = XEquipCreateDocument.m_itemQuanlityTypeDic.TryGetValue(quanlity, out num2);
				if (!flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("not find this key in m_itemQuanlityTypeDic quanlity = {0}", quanlity), null, null, null, null, null);
					return num;
				}
				bool flag3 = !XEquipCreateDocument.m_quanlityLevelDic.TryGetValue(num2, out list);
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("not find this key in m_quanlityLevelDic key = {0}", num2), null, null, null, null, null);
					return num;
				}
			}
			bool flag4 = list != null;
			if (flag4)
			{
				for (int i = 0; i < list.Count; i++)
				{
					bool flag5 = list[i] <= (int)curLevel && list[i] > num;
					if (flag5)
					{
						num = list[i];
					}
				}
			}
			return num;
		}

		private bool IsMaterialEnough(ItemComposeTable.RowData composeData)
		{
			bool flag = composeData != null;
			bool result;
			if (flag)
			{
				bool flag2 = true;
				bool flag3 = flag2 && composeData.SrcItem4[0] > 0;
				if (flag3)
				{
					ulong itemCount = XBagDocument.BagDoc.GetItemCount(composeData.SrcItem4[0]);
					ulong num = (ulong)((long)composeData.SrcItem4[1]);
					flag2 = (itemCount >= num);
				}
				bool flag4 = flag2 && composeData.SrcItem1[0] > 0;
				if (flag4)
				{
					ulong itemCount2 = XBagDocument.BagDoc.GetItemCount(composeData.SrcItem1[0]);
					ulong num2 = (ulong)((long)composeData.SrcItem1[1]);
					flag2 = (itemCount2 >= num2);
				}
				bool flag5 = flag2 && composeData.SrcItem2[0] > 0;
				if (flag5)
				{
					ulong itemCount3 = XBagDocument.BagDoc.GetItemCount(composeData.SrcItem2[0]);
					ulong num3 = (ulong)((long)composeData.SrcItem2[1]);
					flag2 = (itemCount3 >= num3);
				}
				bool flag6 = flag2 && composeData.SrcItem3[0] > 0;
				if (flag6)
				{
					ulong itemCount4 = XBagDocument.BagDoc.GetItemCount(composeData.SrcItem3[0]);
					ulong num4 = (ulong)((long)composeData.SrcItem3[1]);
					flag2 = (itemCount4 >= num4);
				}
				result = flag2;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = SceneType.SCENE_HALL != XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			if (!flag)
			{
				this.mItemTypeListDirty = true;
				this._CheckUpdateItemTypeList();
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					this._CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				}
				this._CheckUpdateEmblemList();
				this.UpdatePlateMetalsRedDot();
			}
		}

		public void CheckLevelUp(uint curLevel)
		{
			bool flag = SceneType.SCENE_HALL != XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			if (!flag)
			{
				this._CheckUpdateItemTypeList();
				this._CheckRedPointByLevel(curLevel);
			}
		}

		private bool OnFinishItemChange(XEventArgs e)
		{
			bool flag = SceneType.SCENE_HALL != XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				this._CheckUpdateItemTypeList();
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					this._CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
				}
				this._CheckUpdateEmblemList();
				this.UpdatePlateMetalsRedDot();
				result = true;
			}
			return result;
		}

		public ItemComposeTable.RowData GetItemCoomposeRow(int itemId)
		{
			for (int i = 0; i < XEquipCreateDocument.sItemComposeReader.Table.Length; i++)
			{
				ItemComposeTable.RowData rowData = XEquipCreateDocument.sItemComposeReader.Table[i];
				bool flag = rowData.Type == 4 && rowData.SrcItem1[0] == itemId;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		private void _CheckRedPointByLevel(uint curLevel)
		{
			bool flag = SceneType.SCENE_HALL != XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			if (!flag)
			{
				this.SetRedDotOnlyByLevel(curLevel);
				bool redPointEquip = false;
				for (int i = 0; i < XEquipCreateDocument.sEquipSuitQualityGroupList.Count; i++)
				{
					bool flag2 = !XEquipCreateDocument.sEquipSuitQualityGroupList[i].redpoint;
					if (!flag2)
					{
						XEquipCreateDocument.sEquipSuitQualityGroupList[i].redpoint = false;
						EquipSuitMenuData equipSuitMenuData = XEquipCreateDocument.sEquipSuitQualityGroupList[i];
						for (int j = 0; j < equipSuitMenuData.list.Count; j++)
						{
							bool flag3 = !equipSuitMenuData.list[j].redpoint;
							if (!flag3)
							{
								equipSuitMenuData.list[j].redpoint = false;
								int profID = equipSuitMenuData.list[j].suitData.ProfID;
								bool flag4 = profID != 0 && this.CurRoleProf != profID;
								if (!flag4)
								{
									List<EquipSuitItemData> suitItemList = equipSuitMenuData.list[j].suitItemList;
									int suitQuality = equipSuitMenuData.list[j].suitData.SuitQuality;
									EquipSuitItemData[][] itemPosGroupList = XSingleton<XEquipCreateStaticData>.singleton.ItemPosGroupList;
									int[][] redPointPosGroupList = XSingleton<XEquipCreateStaticData>.singleton.RedPointPosGroupList;
									for (int k = 0; k < itemPosGroupList.Length; k++)
									{
										for (int l = 0; l < itemPosGroupList[k].Length; l++)
										{
											itemPosGroupList[k][l] = null;
										}
									}
									bool flag5 = false;
									int level = equipSuitMenuData.list[j].suitData.Level;
									for (int m = 0; m < suitItemList.Count; m++)
									{
										suitItemList[m].redpoint = false;
										bool flag6 = XBagDocument.BagDoc.GetItemCount(suitItemList[m].itemData.ItemID) > 0UL;
										if (!flag6)
										{
											bool flag7 = suitItemList[m].CompareValue < 0;
											if (!flag7)
											{
												bool flag8 = false;
												for (int k = 0; k < XBagDocument.BagDoc.EquipBag.Length; k++)
												{
													flag8 = this.IsOwn(XBagDocument.BagDoc.EquipBag[k], suitItemList[m].itemData, suitQuality, level);
													bool flag9 = flag8;
													if (flag9)
													{
														break;
													}
												}
												bool flag10 = !flag8;
												if (flag10)
												{
													ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EQUIP);
													List<XItem> list = new List<XItem>();
													XBagDocument.BagDoc.GetItemsByType(typeFilter, ref list);
													for (int k = 0; k < list.Count; k++)
													{
														flag8 = this.IsOwn(list[k], suitItemList[m].itemData, suitQuality, level);
														bool flag11 = flag8;
														if (flag11)
														{
															break;
														}
													}
												}
												bool flag12 = !flag8;
												if (flag12)
												{
													for (int k = 0; k < itemPosGroupList.Length; k++)
													{
														for (int l = 0; l < itemPosGroupList[k].Length; l++)
														{
															bool flag13 = (int)suitItemList[m].itemData.EquipPos == redPointPosGroupList[k][l];
															if (flag13)
															{
																itemPosGroupList[k][l] = suitItemList[m];
																flag5 = true;
															}
														}
													}
												}
												bool flag14 = flag5;
												if (flag14)
												{
													redPointEquip = true;
													for (int k = 0; k < itemPosGroupList.Length; k++)
													{
														for (int l = 0; l < itemPosGroupList[k].Length; l++)
														{
															bool flag15 = itemPosGroupList[k][l] != null;
															if (flag15)
															{
																itemPosGroupList[k][l].redpoint = true;
																break;
															}
														}
													}
													equipSuitMenuData.list[j].redpoint = true;
													equipSuitMenuData.redpoint = true;
												}
											}
										}
									}
								}
							}
						}
					}
				}
				this.RedPointEquip = redPointEquip;
				this.RefreshRedPointEquipUI();
			}
		}

		private void SetRedDotOnlyByLevel(uint checkLevel)
		{
			this.RedPointEquip = false;
			int num = 0;
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			int nextShowLevel = this.NextShowLevel;
			int lastShowLevel = this.LastShowLevel;
			for (int i = 0; i < XEquipCreateDocument.sEquipSuitQualityGroupList.Count; i++)
			{
				EquipSuitMenuData equipSuitMenuData = XEquipCreateDocument.sEquipSuitQualityGroupList[i];
				bool flag = equipSuitMenuData == null;
				if (!flag)
				{
					bool flag2 = false;
					for (int j = 0; j < equipSuitMenuData.list.Count; j++)
					{
						EquipSuitMenuDataItem equipSuitMenuDataItem = equipSuitMenuData.list[j];
						bool flag3 = equipSuitMenuDataItem == null;
						if (!flag3)
						{
							bool flag4 = false;
							bool flag5 = equipSuitMenuDataItem.suitData != null;
							if (flag5)
							{
								bool flag6 = equipSuitMenuDataItem.suitData.Level >= lastShowLevel && equipSuitMenuDataItem.suitData.Level <= nextShowLevel;
								if (flag6)
								{
									bool flag7 = !dictionary.TryGetValue(equipSuitMenuDataItem.suitData.SuitQuality, out num);
									if (flag7)
									{
										num = this.CurShowLevel(checkLevel, equipSuitMenuDataItem.suitData.SuitQuality);
										dictionary.Add(equipSuitMenuDataItem.suitData.SuitQuality, num);
									}
									flag4 = (equipSuitMenuDataItem.suitData.Level == num);
								}
							}
							equipSuitMenuDataItem.redpoint = flag4;
							bool flag8 = !flag4;
							if (flag8)
							{
								for (int k = 0; k < equipSuitMenuDataItem.suitItemList.Count; k++)
								{
									equipSuitMenuDataItem.suitItemList[k].redpoint = false;
								}
							}
							flag2 = (flag2 || flag4);
						}
					}
					XEquipCreateDocument.sEquipSuitQualityGroupList[i].redpoint = flag2;
					this.RedPointEquip = (this.RedPointEquip || flag2);
					dictionary.Clear();
				}
			}
		}

		private bool IsOwn(XItem _xItem, EquipList.RowData equipListData2, int quanlity, int suitLevel)
		{
			bool result = false;
			bool flag = _xItem != null;
			if (flag)
			{
				bool flag2 = _xItem.itemID == equipListData2.ItemID;
				if (flag2)
				{
					result = true;
				}
				else
				{
					int num = 0;
					EquipList.RowData equipConf = XBagDocument.GetEquipConf(_xItem.itemID);
					ItemList.RowData itemConf = XBagDocument.GetItemConf(_xItem.itemID);
					EquipSuitTable.RowData suit = XCharacterEquipDocument.SuitManager.GetSuit(_xItem.itemID, false);
					bool flag3 = suit != null;
					if (flag3)
					{
						num = suit.Level;
					}
					bool flag4 = equipConf != null && (equipConf.EquipPos == equipListData2.EquipPos && (int)itemConf.ItemQuality > quanlity) && num > suitLevel;
					if (flag4)
					{
						result = true;
					}
				}
			}
			return result;
		}

		private void RefreshRedPointEquipUI()
		{
			bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler.IsVisible();
			if (flag)
			{
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler.RefreshRedPoint();
			}
		}

		private int _GetCurrentPlayerProf()
		{
			return (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
		}

		public List<EquipSuitMenuData> GetUpdateItemTypeList(bool forceGet)
		{
			bool flag = this._CheckUpdateItemTypeList();
			List<EquipSuitMenuData> result;
			if (flag)
			{
				result = XEquipCreateDocument.sEquipSuitQualityGroupList;
			}
			else if (forceGet)
			{
				result = XEquipCreateDocument.sEquipSuitQualityGroupList;
			}
			else
			{
				result = null;
			}
			return result;
		}

		private bool _CheckUpdateItemTypeList()
		{
			int level = (int)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
			int nextShowLevel = this.NextShowLevel;
			int lastShowLevel = this.LastShowLevel;
			int num = this.CurShowLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level, -1);
			bool flag = level != this.mLastItemTypeListLevel || this.mItemTypeListDirty;
			bool result;
			if (flag)
			{
				this.mLastItemTypeListLevel = level;
				this.mItemTypeListDirty = false;
				bool flag2 = XEquipCreateDocument.sEquipSuitQualityGroupList == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					for (int i = 0; i < XEquipCreateDocument.sEquipSuitQualityGroupList.Count; i++)
					{
						bool flag3 = XEquipCreateDocument.sEquipSuitQualityGroupList[i] == null;
						if (!flag3)
						{
							XEquipCreateDocument.sEquipSuitQualityGroupList[i].show = false;
							for (int j = 0; j < XEquipCreateDocument.sEquipSuitQualityGroupList[i].list.Count; j++)
							{
								bool flag4 = XEquipCreateDocument.sEquipSuitQualityGroupList[i].list[j] == null;
								if (!flag4)
								{
									EquipSuitTable.RowData suitData = XEquipCreateDocument.sEquipSuitQualityGroupList[i].list[j].suitData;
									bool flag5 = suitData == null;
									if (flag5)
									{
										XSingleton<XDebug>.singleton.AddGreenLog("data is null i=" + i.ToString() + "j=" + j.ToString(), null, null, null, null, null);
									}
									else
									{
										XEquipCreateDocument.sEquipSuitQualityGroupList[i].list[j].show = false;
										bool flag6 = true;
										bool flag7 = this.mCurSelectLevel == 0;
										if (flag7)
										{
											bool flag8 = suitData.Level > this.mLastItemTypeListLevel && suitData.Level > nextShowLevel;
											if (flag8)
											{
												flag6 = false;
											}
										}
										else
										{
											bool flag9 = suitData.Level > num || suitData.Level < lastShowLevel;
											if (flag9)
											{
												flag6 = false;
											}
										}
										bool flag10 = !flag6;
										if (!flag10)
										{
											bool flag11 = this.mCurSelectProf != 0;
											if (flag11)
											{
												bool flag12 = suitData.ProfID != this.mCurSelectProf && suitData.ProfID != 0;
												if (flag12)
												{
													flag6 = false;
												}
											}
											XEquipCreateDocument.sEquipSuitQualityGroupList[i].list[j].show = flag6;
											bool flag13 = flag6;
											if (flag13)
											{
												XEquipCreateDocument.sEquipSuitQualityGroupList[i].list[j].suitItemList.Sort();
												XEquipCreateDocument.sEquipSuitQualityGroupList[i].show = true;
											}
										}
									}
								}
							}
						}
					}
					result = true;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		private void _CheckUpdateEmblemList()
		{
			this.mEmblemBagItems.Clear();
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM_MATERIAL);
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.mEmblemBagItems);
			bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.emblemSetHandler != null;
			if (flag)
			{
				bool flag2 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.emblemSetHandler.IsVisible();
				if (flag2)
				{
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.emblemSetHandler.RefreshItemList();
				}
			}
		}

		private bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = xvirtualItemChangedEventArgs.itemID == 1;
			if (flag)
			{
				this.UpdatePlateMetalsRedDot();
			}
			return true;
		}

		public bool IsHadRedDot(int itemId)
		{
			bool result = false;
			this.EmblemRedDotDic.TryGetValue(itemId, out result);
			return result;
		}

		private void UpdatePlateMetalsRedDot()
		{
			this.EmblemRedDotDic.Clear();
			Dictionary<short, List<XEquipCreateDocument.MaterialPointClass>> dictionary = new Dictionary<short, List<XEquipCreateDocument.MaterialPointClass>>();
			List<XEquipCreateDocument.MaterialPointClass> list = null;
			for (int i = 0; i < this.mEmblemBagItems.Count; i++)
			{
				list = null;
				XItem xitem = this.mEmblemBagItems[i];
				ItemComposeTable.RowData emblemComposeDataByMetalID = this.GetEmblemComposeDataByMetalID(xitem.itemID);
				bool flag = emblemComposeDataByMetalID == null;
				if (!flag)
				{
					EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(emblemComposeDataByMetalID.ItemID);
					bool flag2 = emblemConf == null;
					if (flag2)
					{
						this.EmblemRedDotDic.Add(xitem.itemID, false);
					}
					else
					{
						bool flag3 = dictionary.TryGetValue(emblemConf.EmblemType, out list);
						if (flag3)
						{
							uint unGetEmblemPPT = this.GetUnGetEmblemPPT(emblemComposeDataByMetalID.ItemID, emblemConf.EmblemType > 1000);
							for (int j = 0; j < list.Count; j++)
							{
								bool flag4 = unGetEmblemPPT > list[j].Ppt;
								if (flag4)
								{
									XEquipCreateDocument.MaterialPointClass item = new XEquipCreateDocument.MaterialPointClass(xitem, unGetEmblemPPT);
									list.Insert(j, item);
									break;
								}
							}
						}
						else
						{
							list = new List<XEquipCreateDocument.MaterialPointClass>();
							uint unGetEmblemPPT = this.GetUnGetEmblemPPT(emblemComposeDataByMetalID.ItemID, emblemConf.EmblemType > 1000);
							XEquipCreateDocument.MaterialPointClass item2 = new XEquipCreateDocument.MaterialPointClass(xitem, unGetEmblemPPT);
							list.Add(item2);
							dictionary.Add(emblemConf.EmblemType, list);
						}
					}
				}
			}
			this.RedPointEmblem = false;
			foreach (KeyValuePair<short, List<XEquipCreateDocument.MaterialPointClass>> keyValuePair in dictionary)
			{
				bool flag5 = false;
				for (int k = 0; k < keyValuePair.Value.Count; k++)
				{
					XItem xitem = keyValuePair.Value[k].Item;
					bool flag6 = !flag5;
					if (flag6)
					{
						bool flag7 = this.IsHadPlateMetalsRedDot(xitem, keyValuePair.Value[k].Ppt);
						if (flag7)
						{
							bool flag8 = !this.EmblemRedDotDic.ContainsKey(xitem.itemID);
							if (flag8)
							{
								this.EmblemRedDotDic.Add(xitem.itemID, true);
							}
							else
							{
								this.EmblemRedDotDic[xitem.itemID] = true;
							}
							flag5 = true;
							this.RedPointEmblem = true;
						}
					}
					else
					{
						bool flag9 = !this.EmblemRedDotDic.ContainsKey(xitem.itemID);
						if (flag9)
						{
							this.EmblemRedDotDic.Add(xitem.itemID, false);
						}
						else
						{
							this.EmblemRedDotDic[xitem.itemID] = false;
						}
					}
				}
			}
		}

		private bool IsHadPlateMetalsRedDot(XItem metelItem, uint ppt)
		{
			bool flag = metelItem.Prof != 0U && (ulong)metelItem.Prof != (ulong)((long)XEquipCreateDocument.Doc.CurRoleProf);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(metelItem.itemID);
				bool flag2 = itemConf == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = (long)itemConf.ReqLevel > (long)((ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
					if (flag3)
					{
						result = false;
					}
					else
					{
						ItemComposeTable.RowData emblemComposeDataByMetalID = this.GetEmblemComposeDataByMetalID(metelItem.itemID);
						bool flag4 = emblemComposeDataByMetalID == null;
						if (flag4)
						{
							result = false;
						}
						else
						{
							EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(emblemComposeDataByMetalID.ItemID);
							bool flag5 = emblemConf == null;
							if (flag5)
							{
								result = false;
							}
							else
							{
								bool flag6 = !this.IsMaterialEnough(emblemComposeDataByMetalID);
								if (flag6)
								{
									result = false;
								}
								else
								{
									bool flag7 = (long)emblemComposeDataByMetalID.Coin > (long)XBagDocument.BagDoc.GetItemCount(1);
									if (flag7)
									{
										result = false;
									}
									else
									{
										XEmblemItem xemblemItem = this.CheckEquipedEmblemsAttrs(emblemComposeDataByMetalID);
										bool flag8 = xemblemItem == null;
										if (flag8)
										{
											bool flag9 = this.IsHadEmptyPos(emblemConf.EmblemType > 1000);
											if (flag9)
											{
												bool flag10 = this.BagIsHadBetterEmblem(ppt, (uint)emblemConf.EmblemType);
												result = !flag10;
											}
											else
											{
												result = false;
											}
										}
										else
										{
											uint emblemPPT = this.GetEmblemPPT(xemblemItem, emblemConf.EmblemType > 1000);
											bool flag11 = ppt > emblemPPT;
											if (flag11)
											{
												bool flag12 = this.BagIsHadBetterEmblem(ppt, (uint)emblemConf.EmblemType);
												result = !flag12;
											}
											else
											{
												result = false;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		public XEmblemItem CheckEquipedEmblemsAttrs(ItemComposeTable.RowData composeData)
		{
			bool flag = composeData == null;
			XEmblemItem result;
			if (flag)
			{
				result = null;
			}
			else
			{
				XBodyBag emblemBag = XSingleton<XGame>.singleton.Doc.XBagDoc.EmblemBag;
				int num;
				int num2;
				XEquipCreateDocument.GetEmblemAttrDataByID((uint)composeData.ItemID, out num, out num2);
				bool flag2 = num >= 0;
				if (flag2)
				{
					uint num3 = 0U;
					for (int i = num; i < num2; i++)
					{
						AttributeEmblem.RowData rowData = XEquipCreateDocument.sAttributeEmblemTable.Table[i];
						bool flag3 = rowData.Position == 1;
						if (flag3)
						{
							num3 = (uint)rowData.AttrID;
							break;
						}
					}
					int j = XEmblemDocument.Position_TotalStart;
					while (j < XEmblemDocument.Position_TotalEnd)
					{
						bool flag4 = emblemBag[j] != null && emblemBag[j].uid > 0UL;
						if (flag4)
						{
							XEmblemItem xemblemItem = emblemBag[j] as XEmblemItem;
							bool flag5 = xemblemItem == null || xemblemItem.changeAttr.Count == 0;
							if (!flag5)
							{
								XItemChangeAttr xitemChangeAttr = xemblemItem.changeAttr[0];
								bool flag6 = xitemChangeAttr.AttrID == num3;
								if (flag6)
								{
									return xemblemItem;
								}
							}
						}
						IL_117:
						j++;
						continue;
						goto IL_117;
					}
				}
				else
				{
					SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)composeData.ItemID);
					bool flag7 = emblemSkillConf != null;
					if (flag7)
					{
						for (int k = XEmblemDocument.Position_TotalStart; k < XEmblemDocument.Position_TotalEnd; k++)
						{
							bool flag8 = emblemBag[k] == null || emblemBag[k].uid == 0UL;
							if (!flag8)
							{
								XEmblemItem xemblemItem2 = emblemBag[k] as XEmblemItem;
								bool flag9 = xemblemItem2 == null;
								if (!flag9)
								{
									SkillEmblem.RowData emblemSkillConf2 = XEmblemDocument.GetEmblemSkillConf((uint)xemblemItem2.itemID);
									bool flag10 = emblemSkillConf2 == null;
									if (!flag10)
									{
										bool flag11 = emblemSkillConf2.SkillScript == emblemSkillConf.SkillScript;
										if (flag11)
										{
											return xemblemItem2;
										}
									}
								}
							}
						}
					}
				}
				result = null;
			}
			return result;
		}

		private bool IsHadEmptyPos(bool isSkillEmblem)
		{
			int num;
			int num2;
			if (isSkillEmblem)
			{
				num = XEmblemDocument.Position_SkillStart;
				num2 = XEmblemDocument.Position_SkillEnd;
			}
			else
			{
				num = XEmblemDocument.Position_AttrStart;
				num2 = XEmblemDocument.Position_AttrEnd;
			}
			int position_TotalStart = XEmblemDocument.Position_TotalStart;
			XEmblemDocument specificDocument = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			EmblemSlotStatus[] equipLock = specificDocument.EquipLock;
			for (int i = num; i < num2; i++)
			{
				bool flag = XBagDocument.BagDoc.EmblemBag[i] == null && !equipLock[i - position_TotalStart].IsLock;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		private bool BagIsHadBetterEmblem(uint ppt, uint type)
		{
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM);
			List<XItem> list = new List<XItem>();
			XBagDocument.BagDoc.GetItemsByType(typeFilter, ref list);
			for (int i = 0; i < list.Count; i++)
			{
				EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(list[i].itemID);
				bool flag = emblemConf != null && (ulong)type == (ulong)((long)emblemConf.EmblemType);
				if (flag)
				{
					uint emblemPPT = this.GetEmblemPPT(list[i] as XEmblemItem, emblemConf.EmblemType > 1000);
					bool flag2 = emblemPPT > ppt;
					if (flag2)
					{
						return true;
					}
				}
			}
			return false;
		}

		private uint GetUnGetEmblemPPT(int emblemItemId, bool isSkillEmblem)
		{
			uint result;
			if (isSkillEmblem)
			{
				SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)emblemItemId);
				result = emblemSkillConf.SkillPPT;
			}
			else
			{
				int num;
				int endIndex;
				XEquipCreateDocument.GetEmblemAttrDataByID((uint)emblemItemId, out num, out endIndex);
				bool flag = num >= 0;
				if (flag)
				{
					uint num2;
					uint num3;
					XEquipCreateDocument.GetPPT(num, endIndex, false, false, out num2, out num3);
					result = num2;
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog2("AttributeEmblem not find this Id:{0}" + emblemItemId, new object[0]);
					result = 0U;
				}
			}
			return result;
		}

		private uint GetEmblemPPT(XEmblemItem item, bool isSkillEmblem)
		{
			uint result;
			if (isSkillEmblem)
			{
				SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)item.itemID);
				result = emblemSkillConf.SkillPPT;
			}
			else
			{
				result = item.GetPPT(null);
			}
			return result;
		}

		public List<int> GetUpdateItemLevelList()
		{
			return XEquipCreateDocument.sEquipSuitLevelList;
		}

		public ProfSkillTable.RowData GetMainProfByID(int id)
		{
			for (int i = 0; i < this.mMainProfDataList.Count; i++)
			{
				bool flag = id == this.mMainProfDataList[i].ProfID;
				if (flag)
				{
					return this.mMainProfDataList[i];
				}
			}
			return this.mMainProfDataList[0];
		}

		public List<ProfSkillTable.RowData> GetMainProfList()
		{
			return this.mMainProfDataList;
		}

		public List<XItem> GetEmblemList()
		{
			this.mEmblemBagItems.Clear();
			ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.EMBLEM_MATERIAL);
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(typeFilter, ref this.mEmblemBagItems);
			return this.mEmblemBagItems;
		}

		public ItemComposeTable.RowData GetEmblemComposeDataByMetalID(int id)
		{
			for (int i = 0; i < XEquipCreateDocument.sItemComposeReader.Table.Length; i++)
			{
				ItemComposeTable.RowData rowData = XEquipCreateDocument.sItemComposeReader.Table[i];
				bool flag = rowData.Type == 3 && rowData.SrcItem1[0] == id;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		public int GetEmblemComposeAttrByEmblemID(int id, out string name)
		{
			name = XEquipCreateDocument.sDefaultEmblemAttrString;
			int num;
			int num2;
			XEquipCreateDocument.GetEmblemAttrDataByID((uint)id, out num, out num2);
			bool flag = num >= 0;
			int result;
			if (flag)
			{
				string format = XStringDefineProxy.GetString("EQUIPCREATE_EMBLEMSET_ATTR_FMT").Replace("{n}", "\n");
				string format2 = XStringDefineProxy.GetString("EQUIPCREATE_EMBLEMSET_ATTR_FMT2").Replace("{n}", "\n");
				string @string = XStringDefineProxy.GetString("EMBLEM_Attr_1stTittle");
				string string2 = XStringDefineProxy.GetString("EMBLEM_Attr_2edTittle");
				string string3 = XStringDefineProxy.GetString("EMBLEM_Attr_3rdTittle");
				int num3 = 0;
				for (int i = num; i < num2; i++)
				{
					AttributeEmblem.RowData rowData = XEquipCreateDocument.sAttributeEmblemTable.Table[i];
					bool flag2 = rowData.Position == 1 || rowData.Position == 2;
					if (flag2)
					{
						bool flag3 = XAttributeCommon.IsPercentRange((int)rowData.AttrID);
						string format3;
						if (flag3)
						{
							format3 = "{0}%";
						}
						else
						{
							format3 = "{0}";
						}
						bool flag4 = rowData.Range[0] != rowData.Range[1];
						string text;
						if (flag4)
						{
							text = string.Format(format, XAttributeCommon.GetAttrStr((int)rowData.AttrID), string.Format(format3, rowData.Range[0]), string.Format(format3, rowData.Range[1]));
						}
						else
						{
							text = string.Format(format2, XAttributeCommon.GetAttrStr((int)rowData.AttrID), string.Format(format3, rowData.Range[1]));
						}
						num3++;
						bool flag5 = num3 == 1;
						if (flag5)
						{
							name = string.Format("{0}{1}", @string, text);
						}
						else
						{
							bool flag6 = num3 == 2;
							if (flag6)
							{
								name = string.Format("{0}{1}{2}", name, string2, text);
							}
							else
							{
								bool flag7 = num3 == 3;
								if (flag7)
								{
									name = string.Format("{0}{1}{2}", name, string3, text);
								}
							}
						}
					}
				}
				result = num3;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public void StartCreateEquip(int ID)
		{
			this.mCurComposeID = ID;
			bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetVisible(true);
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetEquipInfo(ID);
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetFinishState(false);
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetBar(0);
				this.mTimerCount = 0;
				this._OpenTimer();
			}
		}

		public void CancelCreateEquip()
		{
			this.mCurComposeID = 0;
			this.CurUid = 0UL;
			this._CloseTimer();
		}

		public void ReqCreateEquipSet(int ID, ulong uid = 0UL)
		{
			RpcC2G_UseItem rpcC2G_UseItem = new RpcC2G_UseItem();
			rpcC2G_UseItem.oArg.uid = (ulong)((long)ID);
			rpcC2G_UseItem.oArg.count = 1U;
			rpcC2G_UseItem.oArg.uids.Add(uid);
			rpcC2G_UseItem.oArg.OpType = ItemUseMgr.GetItemUseValue(ItemUse.Composite);
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UseItem);
		}

		public void OnReqCreateEquipSet(UseItemArg oArg, UseItemRes oRes)
		{
			this.IsCreating = false;
			bool flag = (long)this.mCurComposeID == (long)oArg.uid;
			if (flag)
			{
				bool flag2 = oRes.ErrorCode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.ErrorCode, "fece00");
				}
				else
				{
					bool flag3 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.IsVisible();
					if (flag3)
					{
						bool flag4 = oRes.uid > 0UL;
						if (flag4)
						{
							DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetFinishEquipInfo(XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oRes.uid));
						}
						DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetFinishState(true);
					}
					ItemComposeTable.RowData itemConposeDataByID = XEquipCreateDocument.GetItemConposeDataByID(this.mCurComposeID);
					bool flag5 = itemConposeDataByID != null;
					if (flag5)
					{
						switch (itemConposeDataByID.Type)
						{
						case 1:
						{
							bool flag6 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler.IsVisible();
							if (flag6)
							{
								DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler.RefreshItemList();
							}
							break;
						}
						case 3:
							this._CheckUpdateEmblemList();
							this.UpdatePlateMetalsRedDot();
							break;
						case 5:
						{
							bool flag7 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.m_artifactSetHandler != null && DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.m_artifactSetHandler.IsVisible();
							if (flag7)
							{
								DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.m_artifactSetHandler.RefreshItemList();
							}
							break;
						}
						}
					}
				}
			}
		}

		public void ReqEnhanceTransform(ulong src, ulong dst)
		{
			RpcC2G_EnhanceTranster rpcC2G_EnhanceTranster = new RpcC2G_EnhanceTranster();
			rpcC2G_EnhanceTranster.oArg.originuid = src;
			rpcC2G_EnhanceTranster.oArg.destuid = dst;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_EnhanceTranster);
		}

		public void OnReplyEnhanceTransform(EnhanceTransterArg oArg, EnhanceTransterRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
		}

		public void RefreshEquipSuitListUIByProf(int prof, bool refreshUI)
		{
			bool flag = prof != this.mCurSelectProf;
			if (flag)
			{
				this.mCurSelectProf = prof;
				this.mItemTypeListDirty = true;
				if (refreshUI)
				{
					this._RefreshEquipSuitListUI();
				}
			}
		}

		public void RefreshEquipSuitListUIByLevel(int level, bool refreshUI)
		{
			bool flag = level != this.mCurSelectLevel;
			if (flag)
			{
				this.mCurSelectLevel = level;
				this.mItemTypeListDirty = true;
				if (refreshUI)
				{
					this._RefreshEquipSuitListUI();
				}
			}
		}

		public void RefreshEquipSuitListByProf(int prof)
		{
			bool flag = prof != this.mCurSelectProf;
			if (flag)
			{
				this.mCurSelectProf = prof;
				this._RefreshEquipSuitListUI();
			}
		}

		public static ItemComposeTable.RowData GetItemConposeDataByID(int id)
		{
			bool flag = XEquipCreateDocument.sItemComposeReader != null;
			ItemComposeTable.RowData result;
			if (flag)
			{
				result = XEquipCreateDocument.sItemComposeReader.GetByID(id);
			}
			else
			{
				result = null;
			}
			return result;
		}

		private static int EmblemAttrDataCompare(AttributeEmblem.RowData rowData, uint emblemID)
		{
			return emblemID.CompareTo(rowData.EmblemID);
		}

		public static void GetEmblemAttrDataByID(uint emblemID, out int startIndex, out int endIndex)
		{
			CVSReader.GetRowDataListByField<AttributeEmblem.RowData, uint>(XEquipCreateDocument.sAttributeEmblemTable.Table, emblemID, out startIndex, out endIndex, XEquipCreateDocument.comp);
		}

		public static AttributeEmblem.RowData GetAttributeEmblem(int index)
		{
			return XEquipCreateDocument.sAttributeEmblemTable.Table[index];
		}

		public static void GetRandomPPT(int starIndex, int endIndex, out uint minRandomPPT, out uint maxRandomPPT)
		{
			minRandomPPT = 0U;
			maxRandomPPT = 0U;
			bool flag = starIndex >= 0 && starIndex <= endIndex && endIndex < XEquipCreateDocument.sAttributeEmblemTable.Table.Length;
			if (flag)
			{
				uint num = uint.MaxValue;
				uint num2 = 0U;
				for (int i = starIndex; i <= endIndex; i++)
				{
					AttributeEmblem.RowData rowData = XEquipCreateDocument.sAttributeEmblemTable.Table[i];
					bool flag2 = rowData.Position == 3;
					if (flag2)
					{
						num = Math.Min(num, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[0], null, -1));
						num2 = Math.Max(num2, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[1], null, -1));
					}
				}
				bool flag3 = num != uint.MaxValue;
				if (flag3)
				{
					minRandomPPT = num;
				}
				bool flag4 = num2 > 0U;
				if (flag4)
				{
					maxRandomPPT = num2;
				}
			}
		}

		public static void GetPPT(int starIndex, int endIndex, bool bIncludeMinRandom, bool bIncludeMaxRandom, out uint minPPT, out uint maxPPT)
		{
			minPPT = 0U;
			maxPPT = 0U;
			bool flag = starIndex >= 0 && starIndex <= endIndex && endIndex < XEquipCreateDocument.sAttributeEmblemTable.Table.Length;
			if (flag)
			{
				uint num = uint.MaxValue;
				uint num2 = 0U;
				double num3 = 0.0;
				double num4 = 0.0;
				for (int i = starIndex; i <= endIndex; i++)
				{
					AttributeEmblem.RowData rowData = XEquipCreateDocument.sAttributeEmblemTable.Table[i];
					bool flag2 = rowData.Position == 1 || rowData.Position == 2;
					if (flag2)
					{
						num3 += XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[0], null, -1);
						num4 += XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[1], null, -1);
					}
					else
					{
						bool flag3 = rowData.Position == 3;
						if (flag3)
						{
							if (bIncludeMinRandom)
							{
								num = Math.Min(num, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[0], null, -1));
							}
							if (bIncludeMaxRandom)
							{
								num2 = Math.Max(num2, (uint)XSingleton<XPowerPointCalculator>.singleton.GetPPT((uint)rowData.AttrID, rowData.Range[1], null, -1));
							}
						}
					}
				}
				minPPT = (uint)num3;
				maxPPT = (uint)num4;
				bool flag4 = num != uint.MaxValue;
				if (flag4)
				{
					minPPT += num;
				}
				bool flag5 = num2 > 0U;
				if (flag5)
				{
					maxPPT += num2;
				}
			}
		}

		public static AttributeEmblem.RowData FindAttr(int starIndex, int endIndex, int slotIndex, uint attrid)
		{
			bool flag = starIndex >= 0 && starIndex <= endIndex && endIndex < XEquipCreateDocument.sAttributeEmblemTable.Table.Length;
			if (flag)
			{
				for (int i = starIndex; i <= endIndex; i++)
				{
					AttributeEmblem.RowData rowData = XEquipCreateDocument.sAttributeEmblemTable.Table[i];
					bool flag2 = (int)rowData.Position == slotIndex + 1 && attrid == (uint)rowData.AttrID;
					if (flag2)
					{
						return rowData;
					}
				}
			}
			return null;
		}

		private static List<int> MarkList
		{
			get
			{
				bool flag = XEquipCreateDocument.m_markList == null;
				if (flag)
				{
					XEquipCreateDocument.m_markList = XSingleton<XGlobalConfig>.singleton.GetIntList("SmeltCorlorRange");
				}
				return XEquipCreateDocument.m_markList;
			}
		}

		public static string GetPrefixColor(int starIndex, int endIndex, int slotIndex, uint attrid, uint attrValue)
		{
			AttributeEmblem.RowData data = XEquipCreateDocument.FindAttr(starIndex, endIndex, slotIndex, attrid);
			return XEquipCreateDocument.GetPrefixColor(data, attrValue);
		}

		public static string GetPrefixColor(AttributeEmblem.RowData data, uint attrValue)
		{
			bool flag = data == null;
			string itemQualityRGB;
			if (flag)
			{
				itemQualityRGB = XSingleton<UiUtility>.singleton.GetItemQualityRGB(0);
			}
			else
			{
				float num = data.Range[1] - data.Range[0];
				bool flag2 = num <= 0f;
				if (flag2)
				{
					num = 0f;
				}
				bool flag3 = attrValue != data.Range[1];
				float num2;
				if (flag3)
				{
					num2 = (attrValue - data.Range[0]) * 100U / num;
				}
				else
				{
					num2 = 100f;
				}
				int quality = XEquipCreateDocument.MarkList.Count - 1;
				for (int i = 0; i < XEquipCreateDocument.MarkList.Count; i++)
				{
					bool flag4 = num2 < (float)XEquipCreateDocument.MarkList[i];
					if (flag4)
					{
						quality = i;
						break;
					}
				}
				itemQualityRGB = XSingleton<UiUtility>.singleton.GetItemQualityRGB(quality);
			}
			return itemQualityRGB;
		}

		public List<EquipSuitItemData> GetUpdateRefreshEquipSuitList(int suitID)
		{
			EquipSuitMenuDataItem equipSuitMenuDataItem = null;
			this.mDataUIList = null;
			bool flag = XEquipCreateDocument.sEquipSuitIDMenuDataDic.TryGetValue(suitID, out equipSuitMenuDataItem);
			if (flag)
			{
				this.mDataUIList = equipSuitMenuDataItem.suitItemList;
			}
			bool flag2 = this.mDataUIList != null;
			if (flag2)
			{
				this.mDataUIList.Sort();
			}
			return this.mDataUIList;
		}

		public EquipSuitItemData GetEquipSuitListItem(int index)
		{
			bool flag = this.mDataUIList != null && this.mDataUIList.Count > index && index >= 0;
			EquipSuitItemData result;
			if (flag)
			{
				result = this.mDataUIList[index];
			}
			else
			{
				result = null;
			}
			return result;
		}

		private static void _GetEquipSuitList(int suitID, ref List<EquipSuitItemData> _list)
		{
			EquipSuitTable.RowData bySuitID = XEquipCreateDocument.sEquipSuitTable.GetBySuitID(suitID);
			bool flag = bySuitID != null;
			if (flag)
			{
				_list.Clear();
				bool flag2 = bySuitID.EquipID != null;
				if (flag2)
				{
					for (int i = 0; i < bySuitID.EquipID.Length; i++)
					{
						ItemComposeTable.RowData byID = XEquipCreateDocument.sItemComposeReader.GetByID(bySuitID.EquipID[i]);
						bool flag3 = byID != null;
						if (flag3)
						{
							EquipList.RowData equipConf = XBagDocument.GetEquipConf(byID.ItemID);
							bool flag4 = equipConf != null;
							if (flag4)
							{
								EquipSuitItemData equipSuitItemData = new EquipSuitItemData();
								equipSuitItemData.redpoint = false;
								equipSuitItemData.itemData = equipConf;
								equipSuitItemData.itemComposeData = byID;
								_list.Add(equipSuitItemData);
							}
						}
					}
				}
			}
		}

		private void _RefreshEquipSuitListUI()
		{
			this.mItemTypeListDirty = true;
			DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetHandler.RefreshItemType();
		}

		private void _OpenTimer()
		{
			this._CloseTimer();
			this.mTimerID = XSingleton<XTimerMgr>.singleton.SetTimerAccurate(1f / (float)XSingleton<XEquipCreateStaticData>.singleton.TimerPerSecondCount, this._onTimeCb, null);
		}

		private void _CloseTimer()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.mTimerID);
			this.mTimerID = 0U;
		}

		protected void OnTimer(object param, float delay)
		{
			this.mTimerCount++;
			int timerPerSecondCount = XSingleton<XEquipCreateStaticData>.singleton.TimerPerSecondCount;
			float timerTotalSecond = XSingleton<XEquipCreateStaticData>.singleton.TimerTotalSecond;
			bool flag = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler != null;
			if (flag)
			{
				DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetBar((int)((float)(this.mTimerCount * 100) / (timerTotalSecond * (float)timerPerSecondCount)));
			}
			this.mTimerPassSecond = (float)(this.mTimerCount / timerPerSecondCount);
			bool flag2 = this.mTimerPassSecond < timerTotalSecond;
			if (flag2)
			{
				this._OpenTimer();
			}
			else
			{
				bool flag3 = DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler != null;
				if (flag3)
				{
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.equipSetCreateHandler.SetBar(100);
				}
				this.IsCreating = true;
				this.ReqCreateEquipSet(this.mCurComposeID, this.CurUid);
			}
		}

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.CheckLevelUp(xplayerLevelChangedEventArgs.level);
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EquipCreateDocument");

		private static EquipSuitTable sEquipSuitTable = new EquipSuitTable();

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ItemComposeTable sItemComposeReader = new ItemComposeTable();

		private static AttributeEmblem sAttributeEmblemTable = new AttributeEmblem();

		private static List<EquipSuitMenuData> sEquipSuitQualityGroupList = new List<EquipSuitMenuData>();

		private static Dictionary<int, EquipSuitMenuDataItem> sEquipSuitIDMenuDataDic = new Dictionary<int, EquipSuitMenuDataItem>();

		private static List<int> sEquipSuitLevelList = new List<int>();

		private static Dictionary<int, int> m_itemQuanlityTypeDic = new Dictionary<int, int>();

		private static Dictionary<int, List<int>> m_quanlityLevelDic = new Dictionary<int, List<int>>();

		private List<EquipSuitItemData> mDataUIList;

		private List<ProfSkillTable.RowData> mMainProfDataList;

		private List<XItem> mEmblemBagItems = new List<XItem>();

		private static string sDefaultEmblemAttrString;

		private static string sEmblemAttrEndString;

		private bool mRedPointEquip;

		private bool mRedPointEmblem;

		private int mLastItemTypeListLevel;

		private int mCurSelectLevel;

		private int mCurSelectProf;

		private int mCurRoleProf;

		private bool mItemTypeListDirty;

		private uint mTimerID;

		private int mTimerCount;

		private float mTimerPassSecond;

		private int mCurComposeID;

		public static int CoinId = 1;

		private XTimerMgr.AccurateElapsedEventHandler _onTimeCb = null;

		public bool IsBind = false;

		public ulong CurUid = 0UL;

		private Dictionary<int, bool> EmblemRedDotDic = new Dictionary<int, bool>();

		private static CVSReader.RowDataCompare<AttributeEmblem.RowData, uint> comp = new CVSReader.RowDataCompare<AttributeEmblem.RowData, uint>(XEquipCreateDocument.EmblemAttrDataCompare);

		private static List<int> m_markList;

		public bool IsCreating = false;

		private class MaterialPointClass
		{

			public MaterialPointClass(XItem item, uint ppt)
			{
				this.item = item;
				this.ppt = ppt;
			}

			public XItem Item
			{
				get
				{
					return this.item;
				}
			}

			public uint Ppt
			{
				get
				{
					return this.ppt;
				}
			}

			private XItem item;

			private uint ppt;
		}
	}
}
