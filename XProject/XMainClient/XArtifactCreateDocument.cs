using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008F0 RID: 2288
	internal class XArtifactCreateDocument : XDocComponent
	{
		// Token: 0x17002B09 RID: 11017
		// (get) Token: 0x06008A51 RID: 35409 RVA: 0x00124F9C File Offset: 0x0012319C
		public override uint ID
		{
			get
			{
				return XArtifactCreateDocument.uuID;
			}
		}

		// Token: 0x17002B0A RID: 11018
		// (get) Token: 0x06008A52 RID: 35410 RVA: 0x00124FB4 File Offset: 0x001231B4
		public static XArtifactCreateDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XArtifactCreateDocument.uuID) as XArtifactCreateDocument;
			}
		}

		// Token: 0x17002B0B RID: 11019
		// (get) Token: 0x06008A53 RID: 35411 RVA: 0x00124FDF File Offset: 0x001231DF
		// (set) Token: 0x06008A54 RID: 35412 RVA: 0x00124FE7 File Offset: 0x001231E7
		public ArtifactSetHandler Handler { get; set; }

		// Token: 0x17002B0C RID: 11020
		// (get) Token: 0x06008A55 RID: 35413 RVA: 0x00124FF0 File Offset: 0x001231F0
		// (set) Token: 0x06008A56 RID: 35414 RVA: 0x00125008 File Offset: 0x00123208
		public bool OnlyShowCurFit
		{
			get
			{
				return this.m_onlyShowCurFit;
			}
			set
			{
				bool flag = this.m_onlyShowCurFit != value;
				if (flag)
				{
					this.m_onlyShowCurFit = value;
					this.SetShowStatue(value);
				}
			}
		}

		// Token: 0x17002B0D RID: 11021
		// (get) Token: 0x06008A57 RID: 35415 RVA: 0x00125038 File Offset: 0x00123238
		private Dictionary<uint, uint> ElementCurLevelDic
		{
			get
			{
				this.m_elementCurLevelDic.Clear();
				uint num = 0U;
				bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag)
				{
					num = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
				foreach (KeyValuePair<uint, List<uint>> keyValuePair in this.ElementLevelDic)
				{
					uint num2 = 0U;
					for (int i = 0; i < keyValuePair.Value.Count; i++)
					{
						bool flag2 = num >= keyValuePair.Value[i];
						if (flag2)
						{
							num2 = keyValuePair.Value[i];
						}
					}
					bool flag3 = num2 > 0U;
					if (flag3)
					{
						bool flag4 = this.m_elementCurLevelDic.ContainsKey(keyValuePair.Key);
						if (flag4)
						{
							this.m_elementCurLevelDic[keyValuePair.Key] = num2;
						}
						else
						{
							this.m_elementCurLevelDic.Add(keyValuePair.Key, num2);
						}
					}
				}
				return this.m_elementCurLevelDic;
			}
		}

		// Token: 0x17002B0E RID: 11022
		// (get) Token: 0x06008A58 RID: 35416 RVA: 0x0012516C File Offset: 0x0012336C
		public List<ArtifactElementData> ArtifactElementDataList
		{
			get
			{
				bool flag = this.m_artifactElementDataList == null;
				if (flag)
				{
					this.InitData();
				}
				return this.m_artifactElementDataList;
			}
		}

		// Token: 0x17002B0F RID: 11023
		// (get) Token: 0x06008A59 RID: 35417 RVA: 0x00125198 File Offset: 0x00123398
		public Dictionary<uint, List<uint>> ElementLevelDic
		{
			get
			{
				bool flag = this.m_elementLevelDic == null;
				if (flag)
				{
					this.InitData();
				}
				return this.m_elementLevelDic;
			}
		}

		// Token: 0x17002B10 RID: 11024
		// (get) Token: 0x06008A5A RID: 35418 RVA: 0x001251C4 File Offset: 0x001233C4
		// (set) Token: 0x06008A5B RID: 35419 RVA: 0x001251EC File Offset: 0x001233EC
		public bool RedPointArtifact
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_EquipCreate_ArtifactSet) & this.m_redPointArtifact;
			}
			set
			{
				this.m_redPointArtifact = value;
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_EquipCreate_ArtifactSet, true);
			}
		}

		// Token: 0x06008A5C RID: 35420 RVA: 0x00125207 File Offset: 0x00123407
		public static void Execute(OnLoadedCallback callback = null)
		{
			XArtifactCreateDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008A5D RID: 35421 RVA: 0x00125218 File Offset: 0x00123418
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_ItemChangeFinished, new XComponent.XEventHandler(this.OnFinishItemChange));
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.OnVirtualItemChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
		}

		// Token: 0x06008A5E RID: 35422 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTableLoaded()
		{
		}

		// Token: 0x06008A5F RID: 35423 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008A60 RID: 35424 RVA: 0x00125270 File Offset: 0x00123470
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
			this.m_onlyShowCurFit = false;
			bool flag = this.m_artifactElementDataList != null;
			if (flag)
			{
				this.m_artifactElementDataList.Clear();
				this.m_artifactElementDataList = null;
			}
		}

		// Token: 0x06008A61 RID: 35425 RVA: 0x001252AE File Offset: 0x001234AE
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.CheckLevelUp(arg.PlayerInfo.Brief.level);
		}

		// Token: 0x06008A62 RID: 35426 RVA: 0x001252C8 File Offset: 0x001234C8
		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008A63 RID: 35427 RVA: 0x00125304 File Offset: 0x00123504
		private void InitData()
		{
			this.m_artifactElementDataList = new List<ArtifactElementData>();
			Dictionary<uint, List<ArtifactSuitData>> dictionary = new Dictionary<uint, List<ArtifactSuitData>>();
			for (int i = 0; i < ArtifactDocument.SuitMgr.Suits.Count; i++)
			{
				ArtifactSuit artifactSuit = ArtifactDocument.SuitMgr.Suits[i];
				bool flag = artifactSuit == null;
				if (!flag)
				{
					bool isCreateShow = artifactSuit.IsCreateShow;
					if (isCreateShow)
					{
						List<ArtifactSuitData> list = null;
						bool flag2 = !dictionary.TryGetValue(artifactSuit.ElementType, out list);
						if (flag2)
						{
							list = new List<ArtifactSuitData>();
							dictionary.Add(artifactSuit.ElementType, list);
						}
						ArtifactSuitData artifactSuitData = new ArtifactSuitData();
						artifactSuitData.SuitData = artifactSuit;
						artifactSuitData.Level = artifactSuit.Level;
						artifactSuitData.Show = true;
						artifactSuitData.SuitItemList = new List<ArtifactSingleData>();
						this.GetArtifactSuitList(artifactSuit, ref artifactSuitData.SuitItemList);
						bool flag3 = false;
						for (int j = 0; j < list.Count; j++)
						{
							bool flag4 = list[j].Level == artifactSuitData.Level;
							if (flag4)
							{
								flag3 = true;
								break;
							}
						}
						bool flag5 = !flag3;
						if (flag5)
						{
							list.Add(artifactSuitData);
						}
					}
				}
			}
			foreach (KeyValuePair<uint, List<ArtifactSuitData>> keyValuePair in dictionary)
			{
				bool flag6 = keyValuePair.Value.Count > 0;
				if (flag6)
				{
					ArtifactElementData artifactElementData = new ArtifactElementData();
					artifactElementData.ElementType = keyValuePair.Key;
					artifactElementData.List = keyValuePair.Value;
					this.m_artifactElementDataList.Add(artifactElementData);
				}
			}
			this.m_artifactElementDataList.Sort();
			this.InitQuanlityLevelDic();
		}

		// Token: 0x06008A64 RID: 35428 RVA: 0x001254E0 File Offset: 0x001236E0
		private void InitQuanlityLevelDic()
		{
			this.m_elementLevelDic = new Dictionary<uint, List<uint>>();
			for (int i = 0; i < this.m_artifactElementDataList.Count; i++)
			{
				ArtifactElementData artifactElementData = this.m_artifactElementDataList[i];
				bool flag = !this.m_elementLevelDic.ContainsKey(artifactElementData.ElementType);
				if (flag)
				{
					List<uint> value = new List<uint>();
					this.m_elementLevelDic[artifactElementData.ElementType] = value;
				}
				for (int j = 0; j < artifactElementData.List.Count; j++)
				{
					this.m_elementLevelDic[artifactElementData.ElementType].Add(artifactElementData.List[j].Level);
				}
			}
		}

		// Token: 0x06008A65 RID: 35429 RVA: 0x001255A8 File Offset: 0x001237A8
		private void GetArtifactSuitList(ArtifactSuit suit, ref List<ArtifactSingleData> list)
		{
			list.Clear();
			bool flag = suit.Artifacts == null;
			if (!flag)
			{
				foreach (uint key in suit.Artifacts)
				{
					ItemComposeTable.RowData byID = XEquipCreateDocument.ItemComposeReader.GetByID((int)key);
					bool flag2 = byID == null;
					if (flag2)
					{
						break;
					}
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)byID.ItemID);
					bool flag3 = artifactListRowData == null;
					if (flag3)
					{
						break;
					}
					ArtifactSingleData artifactSingleData = new ArtifactSingleData();
					artifactSingleData.Redpoint = false;
					artifactSingleData.ItemData = artifactListRowData;
					artifactSingleData.ItemComposeData = byID;
					list.Add(artifactSingleData);
				}
			}
		}

		// Token: 0x06008A66 RID: 35430 RVA: 0x00125670 File Offset: 0x00123870
		public List<ArtifactSingleData> GetEquipSuitList(uint suitID)
		{
			List<ArtifactSingleData> list = new List<ArtifactSingleData>();
			for (int i = 0; i < this.m_artifactElementDataList.Count; i++)
			{
				ArtifactElementData artifactElementData = this.m_artifactElementDataList[i];
				for (int j = 0; j < artifactElementData.List.Count; j++)
				{
					bool flag = artifactElementData.List[j].SuitData.SuitId == suitID;
					if (flag)
					{
						list = artifactElementData.List[j].SuitItemList;
						list.Sort();
						return list;
					}
				}
			}
			return list;
		}

		// Token: 0x06008A67 RID: 35431 RVA: 0x00125718 File Offset: 0x00123918
		private void SetShowStatue(bool onlyShowCurFit = false)
		{
			Dictionary<uint, uint> elementCurLevelDic = this.ElementCurLevelDic;
			for (int i = 0; i < this.ArtifactElementDataList.Count; i++)
			{
				ArtifactElementData artifactElementData = this.ArtifactElementDataList[i];
				bool flag = artifactElementData == null;
				if (!flag)
				{
					bool flag2 = !elementCurLevelDic.ContainsKey(artifactElementData.ElementType);
					if (flag2)
					{
						artifactElementData.Show = false;
					}
					else
					{
						uint num = elementCurLevelDic[artifactElementData.ElementType];
						for (int j = 0; j < artifactElementData.List.Count; j++)
						{
							ArtifactSuitData artifactSuitData = artifactElementData.List[j];
							bool flag3 = artifactSuitData == null;
							if (!flag3)
							{
								if (onlyShowCurFit)
								{
									bool flag4 = num == artifactSuitData.Level;
									if (flag4)
									{
										artifactSuitData.Show = true;
									}
									else
									{
										artifactSuitData.Show = false;
									}
								}
								else
								{
									bool flag5 = num >= artifactSuitData.Level;
									if (flag5)
									{
										artifactSuitData.Show = true;
									}
									else
									{
										artifactSuitData.Show = false;
									}
								}
								artifactElementData.Show |= artifactSuitData.Show;
							}
						}
					}
				}
			}
		}

		// Token: 0x06008A68 RID: 35432 RVA: 0x00125848 File Offset: 0x00123A48
		private void CheckRedPointByLevel(uint curLevel)
		{
			bool flag = SceneType.SCENE_HALL != XSingleton<XSceneMgr>.singleton.GetSceneType(XSingleton<XScene>.singleton.SceneID);
			if (!flag)
			{
				bool flag2 = false;
				Dictionary<uint, uint> elementCurLevelDic = this.ElementCurLevelDic;
				for (int i = 0; i < this.ArtifactElementDataList.Count; i++)
				{
					ArtifactElementData artifactElementData = this.ArtifactElementDataList[i];
					bool flag3 = artifactElementData == null;
					if (!flag3)
					{
						bool flag4 = !elementCurLevelDic.ContainsKey(artifactElementData.ElementType);
						if (!flag4)
						{
							uint num = elementCurLevelDic[artifactElementData.ElementType];
							artifactElementData.Redpoint = false;
							for (int j = 0; j < artifactElementData.List.Count; j++)
							{
								ArtifactSuitData artifactSuitData = artifactElementData.List[j];
								bool flag5 = artifactSuitData == null;
								if (!flag5)
								{
									artifactSuitData.Redpoint = false;
									bool flag6 = artifactSuitData.Level != num;
									if (!flag6)
									{
										bool flag7 = artifactSuitData.SuitItemList == null;
										if (!flag7)
										{
											for (int k = 0; k < artifactSuitData.SuitItemList.Count; k++)
											{
												ArtifactSingleData artifactSingleData = artifactSuitData.SuitItemList[k];
												bool flag8 = artifactSingleData == null;
												if (!flag8)
												{
													artifactSingleData.Redpoint = false;
													bool flag9 = artifactSingleData.CompareValue < 0;
													if (!flag9)
													{
														bool flag10 = false;
														for (int l = 0; l < XBagDocument.BagDoc.ArtifactBag.Length; l++)
														{
															flag10 = this.IsOwn(XBagDocument.BagDoc.ArtifactBag[l], artifactSingleData.ItemData);
															bool flag11 = flag10;
															if (flag11)
															{
																break;
															}
														}
														bool flag12 = !flag10;
														if (flag12)
														{
															ulong typeFilter = 1UL << XFastEnumIntEqualityComparer<ItemType>.ToInt(ItemType.ARTIFACT);
															List<XItem> list = new List<XItem>();
															XBagDocument.BagDoc.GetItemsByType(typeFilter, ref list);
															for (int m = 0; m < list.Count; m++)
															{
																flag10 = this.IsOwn(list[m], artifactSingleData.ItemData);
																bool flag13 = flag10;
																if (flag13)
																{
																	break;
																}
															}
														}
														artifactSingleData.Redpoint = !flag10;
														artifactSuitData.Redpoint |= artifactSingleData.Redpoint;
													}
												}
											}
											artifactElementData.Redpoint |= artifactSuitData.Redpoint;
										}
									}
								}
							}
							flag2 |= artifactElementData.Redpoint;
						}
					}
				}
				this.RedPointArtifact = flag2;
				this.RefreshRedPointUi();
			}
		}

		// Token: 0x06008A69 RID: 35433 RVA: 0x00125AF0 File Offset: 0x00123CF0
		private bool IsOwn(XItem xItem, ArtifactListTable.RowData artifactListRow2)
		{
			bool flag = xItem == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = (long)xItem.itemID == (long)((ulong)artifactListRow2.ArtifactID);
				if (flag2)
				{
					result = true;
				}
				else
				{
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)xItem.itemID);
					bool flag3 = artifactListRowData == null;
					if (flag3)
					{
						result = false;
					}
					else
					{
						bool flag4 = artifactListRowData.ArtifactPos != artifactListRow2.ArtifactPos;
						if (flag4)
						{
							result = false;
						}
						else
						{
							ItemList.RowData itemConf = XBagDocument.GetItemConf(xItem.itemID);
							ItemList.RowData itemConf2 = XBagDocument.GetItemConf((int)artifactListRow2.ArtifactID);
							bool flag5 = itemConf == null || itemConf2 == null;
							if (flag5)
							{
								result = false;
							}
							else
							{
								bool flag6 = itemConf.ReqLevel >= itemConf2.ReqLevel;
								result = flag6;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06008A6A RID: 35434 RVA: 0x00125BB0 File Offset: 0x00123DB0
		private void RefreshRedPointUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshRedPoint();
			}
		}

		// Token: 0x06008A6B RID: 35435 RVA: 0x00125BE4 File Offset: 0x00123DE4
		public void CheckLevelUp(uint curLevel)
		{
			this.SetShowStatue(this.OnlyShowCurFit);
			this.CheckRedPointByLevel(curLevel);
		}

		// Token: 0x06008A6C RID: 35436 RVA: 0x00125BFC File Offset: 0x00123DFC
		private bool OnFinishItemChange(XEventArgs e)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
			return true;
		}

		// Token: 0x06008A6D RID: 35437 RVA: 0x00125C38 File Offset: 0x00123E38
		private bool OnVirtualItemChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			bool flag = xvirtualItemChangedEventArgs.itemID == 1 && XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
			return true;
		}

		// Token: 0x06008A6E RID: 35438 RVA: 0x00125C88 File Offset: 0x00123E88
		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.CheckLevelUp(xplayerLevelChangedEventArgs.level);
			return true;
		}

		// Token: 0x04002C08 RID: 11272
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XArtifactCreateDocument");

		// Token: 0x04002C09 RID: 11273
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002C0B RID: 11275
		private bool m_onlyShowCurFit = false;

		// Token: 0x04002C0C RID: 11276
		private List<ArtifactElementData> m_artifactElementDataList = null;

		// Token: 0x04002C0D RID: 11277
		private Dictionary<uint, List<uint>> m_elementLevelDic = null;

		// Token: 0x04002C0E RID: 11278
		private Dictionary<uint, uint> m_elementCurLevelDic = new Dictionary<uint, uint>();

		// Token: 0x04002C0F RID: 11279
		private bool m_redPointArtifact = false;
	}
}
