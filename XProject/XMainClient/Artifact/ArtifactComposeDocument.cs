using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactComposeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactComposeDocument.uuID;
			}
		}

		public static ArtifactComposeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactComposeDocument.uuID) as ArtifactComposeDocument;
			}
		}

		public List<ulong> SelectedItems
		{
			get
			{
				return this.m_SelectedItems;
			}
		}

		public int CurSelectTabLevel
		{
			get
			{
				return ArtifactDeityStoveDocument.Doc.CurSelectTabLevel;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactComposeDocument.AsyncLoader.AddTask("Table/ArtifactCompose", ArtifactComposeDocument.m_artifactComposeTab, false);
			ArtifactComposeDocument.AsyncLoader.Execute(callback);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

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

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public void RefreshUi()
		{
			bool flag = this.ComposeHandler != null && this.ComposeHandler.IsVisible();
			if (flag)
			{
				this.ComposeHandler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		public void ToggleItemSelect(ulong uid)
		{
			this.ToggleItemSelect(!this.m_SelectedItems.Contains(uid), uid, true);
		}

		public bool IsSelected(ulong uid)
		{
			return this.m_SelectedItems.Contains(uid);
		}

		public void ResetSelection(bool isRefreshUi)
		{
			this.m_SelectedItems.Clear();
			if (isRefreshUi)
			{
				this.RefreshUi();
			}
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactComposeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static readonly uint MAX_RECYCLE_COUNT = 2U;

		private static ArtifactComposeTable m_artifactComposeTab = new ArtifactComposeTable();

		private List<ulong> m_SelectedItems = new List<ulong>();

		public bool IsComposing = false;

		public ArtifactComposeHandler ComposeHandler;
	}
}
