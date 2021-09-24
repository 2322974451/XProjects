using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XArtifactCreateDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XArtifactCreateDocument.uuID;
			}
		}

		public static XArtifactCreateDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(XArtifactCreateDocument.uuID) as XArtifactCreateDocument;
			}
		}

		public ArtifactSetHandler Handler { get; set; }

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XArtifactCreateDocument.AsyncLoader.Execute(callback);
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
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.CheckLevelUp(arg.PlayerInfo.Brief.level);
		}

		public override void OnEnterSceneFinally()
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
			base.OnEnterSceneFinally();
		}

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

		private void RefreshRedPointUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshRedPoint();
			}
		}

		public void CheckLevelUp(uint curLevel)
		{
			this.SetShowStatue(this.OnlyShowCurFit);
			this.CheckRedPointByLevel(curLevel);
		}

		private bool OnFinishItemChange(XEventArgs e)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
			if (flag)
			{
				this.CheckRedPointByLevel(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			}
			return true;
		}

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

		private bool OnPlayerLevelChange(XEventArgs arg)
		{
			XPlayerLevelChangedEventArgs xplayerLevelChangedEventArgs = arg as XPlayerLevelChangedEventArgs;
			this.CheckLevelUp(xplayerLevelChangedEventArgs.level);
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XArtifactCreateDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private bool m_onlyShowCurFit = false;

		private List<ArtifactElementData> m_artifactElementDataList = null;

		private Dictionary<uint, List<uint>> m_elementLevelDic = null;

		private Dictionary<uint, uint> m_elementCurLevelDic = new Dictionary<uint, uint>();

		private bool m_redPointArtifact = false;
	}
}
