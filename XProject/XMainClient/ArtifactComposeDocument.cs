using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C1 RID: 2241
	internal class ArtifactComposeDocument : XDocComponent
	{
		// Token: 0x17002A6E RID: 10862
		// (get) Token: 0x06008773 RID: 34675 RVA: 0x00115B2C File Offset: 0x00113D2C
		public override uint ID
		{
			get
			{
				return ArtifactComposeDocument.uuID;
			}
		}

		// Token: 0x17002A6F RID: 10863
		// (get) Token: 0x06008775 RID: 34677 RVA: 0x00115B60 File Offset: 0x00113D60
		public static ArtifactComposeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactComposeDocument.uuID) as ArtifactComposeDocument;
			}
		}

		// Token: 0x17002A70 RID: 10864
		// (get) Token: 0x06008776 RID: 34678 RVA: 0x00115B8C File Offset: 0x00113D8C
		public List<ulong> SelectedItems
		{
			get
			{
				return this.m_SelectedItems;
			}
		}

		// Token: 0x17002A71 RID: 10865
		// (get) Token: 0x06008777 RID: 34679 RVA: 0x00115BA4 File Offset: 0x00113DA4
		public int CurSelectTabLevel
		{
			get
			{
				return ArtifactDeityStoveDocument.Doc.CurSelectTabLevel;
			}
		}

		// Token: 0x06008778 RID: 34680 RVA: 0x00115BC0 File Offset: 0x00113DC0
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactComposeDocument.AsyncLoader.AddTask("Table/ArtifactCompose", ArtifactComposeDocument.m_artifactComposeTab, false);
			ArtifactComposeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06008779 RID: 34681 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600877A RID: 34682 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600877B RID: 34683 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600877C RID: 34684 RVA: 0x00115BE8 File Offset: 0x00113DE8
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.IsComposing = false;
			for (int i = this.SelectedItems.Count - 1; i >= 0; i--)
			{
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.SelectedItems[i]);
				bool flag = bagItemByUID == null;
				if (flag)
				{
					this.SelectedItems.RemoveAt(i);
				}
				else
				{
					ArtifactComposeTable.RowData composeRowData = this.GetComposeRowData(this.CurSelectTabLevel, (int)bagItemByUID.itemConf.ItemQuality);
					bool flag2 = composeRowData == null;
					if (flag2)
					{
						this.SelectedItems.RemoveAt(i);
					}
				}
			}
			this.RefreshUi();
		}

		// Token: 0x0600877D RID: 34685 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x0600877E RID: 34686 RVA: 0x00115C88 File Offset: 0x00113E88
		public void ReqCoposeArtifact()
		{
			RpcC2G_ArtifactCompose rpcC2G_ArtifactCompose = new RpcC2G_ArtifactCompose();
			for (int i = 0; i < this.m_SelectedItems.Count; i++)
			{
				rpcC2G_ArtifactCompose.oArg.uids.Add(this.m_SelectedItems[i]);
			}
			rpcC2G_ArtifactCompose.oArg.type = ArtifactComposeType.ArtifactCompose_Single;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactCompose);
		}

		// Token: 0x0600877F RID: 34687 RVA: 0x00115CF0 File Offset: 0x00113EF0
		public void ReqOneKeyCompose(List<uint> lst)
		{
			RpcC2G_ArtifactCompose rpcC2G_ArtifactCompose = new RpcC2G_ArtifactCompose();
			rpcC2G_ArtifactCompose.oArg.type = ArtifactComposeType.ArtifactCompose_Multi;
			rpcC2G_ArtifactCompose.oArg.level = (uint)this.CurSelectTabLevel;
			for (int i = 0; i < lst.Count; i++)
			{
				rpcC2G_ArtifactCompose.oArg.qualitys.Add(lst[i]);
			}
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactCompose);
		}

		// Token: 0x06008780 RID: 34688 RVA: 0x00115D5C File Offset: 0x00113F5C
		public void OnReqCoposeArtifactBack(ArtifactComposeType type, ArtifactComposeRes oRes)
		{
			this.IsComposing = false;
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					bool flag3 = type == ArtifactComposeType.ArtifactCompose_Single;
					if (flag3)
					{
						XItem itemByUID = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oRes.newuid);
						bool flag4 = itemByUID != null && itemByUID.itemConf != null;
						if (flag4)
						{
							UiUtility singleton = XSingleton<UiUtility>.singleton;
							string @string = XSingleton<XStringTable>.singleton.GetString("ArtifactComposeSucTips");
							object[] itemName = itemByUID.itemConf.ItemName;
							singleton.ShowSystemTip(string.Format(@string, itemName), "fece00");
						}
					}
					else
					{
						bool flag5 = type == ArtifactComposeType.ArtifactCompose_Multi;
						if (flag5)
						{
							Dictionary<int, int> dictionary = new Dictionary<int, int>();
							for (int i = 0; i < oRes.newuids.Count; i++)
							{
								XItem itemByUID2 = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemByUID(oRes.newuids[i]);
								bool flag6 = itemByUID2 != null && itemByUID2.itemConf != null;
								if (flag6)
								{
									bool flag7 = !dictionary.ContainsKey((int)itemByUID2.itemConf.ItemQuality);
									if (flag7)
									{
										dictionary.Add((int)itemByUID2.itemConf.ItemQuality, 1);
									}
									else
									{
										Dictionary<int, int> dictionary2 = dictionary;
										int itemQuality = (int)itemByUID2.itemConf.ItemQuality;
										int num = dictionary2[itemQuality];
										dictionary2[itemQuality] = num + 1;
									}
								}
							}
							foreach (KeyValuePair<int, int> keyValuePair in dictionary)
							{
								XSingleton<XDebug>.singleton.AddGreenLog(keyValuePair.Value.ToString(), null, null, null, null, null);
								bool flag8 = keyValuePair.Value > 0;
								if (flag8)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("ArtifactOneKeyComposeSucTips"), keyValuePair.Value, this.GetQuanlityDes(keyValuePair.Key)), "fece00");
								}
							}
						}
					}
					this.ResetSelection(true);
				}
			}
		}

		// Token: 0x06008781 RID: 34689 RVA: 0x00115FD4 File Offset: 0x001141D4
		private string GetQuanlityDes(int quanlity)
		{
			string result;
			switch (quanlity)
			{
			case 2:
				result = "B";
				break;
			case 3:
				result = "A";
				break;
			case 4:
				result = "S";
				break;
			case 5:
				result = "L";
				break;
			default:
				result = "B";
				break;
			}
			return result;
		}

		// Token: 0x17002A72 RID: 10866
		// (get) Token: 0x06008782 RID: 34690 RVA: 0x00116028 File Offset: 0x00114228
		public bool IsSelectionFull
		{
			get
			{
				bool flag = this.SelectedItems.Count == 0;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.SelectedItems[0]);
					bool flag2 = bagItemByUID == null;
					if (flag2)
					{
						this.SelectedItems.RemoveAt(0);
						result = false;
					}
					else
					{
						ArtifactComposeTable.RowData composeRowData = this.GetComposeRowData(this.CurSelectTabLevel, (int)bagItemByUID.itemConf.ItemQuality);
						bool flag3 = composeRowData == null;
						if (flag3)
						{
							this.SelectedItems.RemoveAt(0);
							result = false;
						}
						else
						{
							uint num = 0U;
							for (int i = 0; i < (int)composeRowData.ArtifactNum2DropID.count; i++)
							{
								bool flag4 = composeRowData.ArtifactNum2DropID[i, 0] > num;
								if (flag4)
								{
									num = composeRowData.ArtifactNum2DropID[i, 0];
								}
							}
							result = ((long)this.m_SelectedItems.Count >= (long)((ulong)num));
						}
					}
				}
				return result;
			}
		}

		// Token: 0x06008783 RID: 34691 RVA: 0x00116120 File Offset: 0x00114320
		public void Additem(ulong uid)
		{
			bool flag = this.SelectedItems.Count > 0;
			if (flag)
			{
				XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.SelectedItems[0]);
				XItem bagItemByUID2 = XBagDocument.BagDoc.GetBagItemByUID(uid);
				bool flag2 = bagItemByUID != null && bagItemByUID2 != null && bagItemByUID.itemConf != null && bagItemByUID2.itemConf != null;
				if (flag2)
				{
					bool flag3 = bagItemByUID.itemConf.ItemQuality != bagItemByUID2.itemConf.ItemQuality;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactComposeTips2"), "fece00");
						return;
					}
				}
			}
			bool isSelectionFull = this.IsSelectionFull;
			if (isSelectionFull)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("ArtifactComposeNeedItemFull"), "fece00");
			}
			else
			{
				this.ToggleItemSelect(uid);
			}
		}

		// Token: 0x06008784 RID: 34692 RVA: 0x001161F8 File Offset: 0x001143F8
		public void RefreshUi()
		{
			bool flag = this.ComposeHandler != null && this.ComposeHandler.IsVisible();
			if (flag)
			{
				this.ComposeHandler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		// Token: 0x06008785 RID: 34693 RVA: 0x00116237 File Offset: 0x00114437
		public void ToggleItemSelect(ulong uid)
		{
			this.ToggleItemSelect(!this.m_SelectedItems.Contains(uid), uid, true);
		}

		// Token: 0x06008786 RID: 34694 RVA: 0x00116254 File Offset: 0x00114454
		public bool IsSelected(ulong uid)
		{
			return this.m_SelectedItems.Contains(uid);
		}

		// Token: 0x06008787 RID: 34695 RVA: 0x00116274 File Offset: 0x00114474
		public void ResetSelection(bool isRefreshUi)
		{
			this.m_SelectedItems.Clear();
			if (isRefreshUi)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x06008788 RID: 34696 RVA: 0x0011629C File Offset: 0x0011449C
		private void ToggleItemSelect(bool select, ulong uid, bool bRefreshUI)
		{
			bool flag = select && !this.IsSelectionFull;
			bool flag2;
			if (flag)
			{
				flag2 = !this.m_SelectedItems.Contains(uid);
				bool flag3 = flag2;
				if (flag3)
				{
					XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(uid);
					bool flag4 = bagItemByUID != null;
					if (flag4)
					{
						ArtifactComposeTable.RowData composeRowData = this.GetComposeRowData(this.CurSelectTabLevel, (int)bagItemByUID.itemConf.ItemQuality);
						bool flag5 = composeRowData != null;
						if (flag5)
						{
							this.m_SelectedItems.Add(uid);
						}
					}
				}
			}
			else
			{
				flag2 = this.m_SelectedItems.Remove(uid);
			}
			bool flag6 = flag2 && bRefreshUI;
			if (flag6)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x17002A73 RID: 10867
		// (get) Token: 0x06008789 RID: 34697 RVA: 0x00116344 File Offset: 0x00114544
		public bool IsNumFit
		{
			get
			{
				bool flag = this.SelectedItems.Count == 0;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					XItem bagItemByUID = XBagDocument.BagDoc.GetBagItemByUID(this.SelectedItems[0]);
					bool flag2 = bagItemByUID == null;
					if (flag2)
					{
						result = false;
					}
					else
					{
						ArtifactComposeTable.RowData composeRowData = this.GetComposeRowData(this.CurSelectTabLevel, (int)bagItemByUID.itemConf.ItemQuality);
						bool flag3 = composeRowData == null;
						if (flag3)
						{
							result = false;
						}
						else
						{
							for (int i = 0; i < (int)composeRowData.ArtifactNum2DropID.count; i++)
							{
								bool flag4 = (ulong)composeRowData.ArtifactNum2DropID[i, 0] == (ulong)((long)this.m_SelectedItems.Count);
								if (flag4)
								{
									return true;
								}
							}
							result = false;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x0600878A RID: 34698 RVA: 0x00116408 File Offset: 0x00114608
		public ArtifactComposeTable.RowData GetComposeRowData(int level, int quanlity)
		{
			for (int i = 0; i < ArtifactComposeDocument.m_artifactComposeTab.Table.Length; i++)
			{
				ArtifactComposeTable.RowData rowData = ArtifactComposeDocument.m_artifactComposeTab.Table[i];
				bool flag = (ulong)rowData.ArtifactLevel == (ulong)((long)level) && (ulong)rowData.ArtifactQuality == (ulong)((long)quanlity);
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x04002AB9 RID: 10937
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactComposeDocument");

		// Token: 0x04002ABA RID: 10938
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002ABB RID: 10939
		public static readonly uint MAX_RECYCLE_COUNT = 2U;

		// Token: 0x04002ABC RID: 10940
		private static ArtifactComposeTable m_artifactComposeTab = new ArtifactComposeTable();

		// Token: 0x04002ABD RID: 10941
		private List<ulong> m_SelectedItems = new List<ulong>();

		// Token: 0x04002ABE RID: 10942
		public bool IsComposing = false;

		// Token: 0x04002ABF RID: 10943
		public ArtifactComposeHandler ComposeHandler;
	}
}
