using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C6 RID: 2246
	internal class ArtifactFuseDocument : XDocComponent
	{
		// Token: 0x17002A81 RID: 10881
		// (get) Token: 0x060087CA RID: 34762 RVA: 0x00117D60 File Offset: 0x00115F60
		public override uint ID
		{
			get
			{
				return ArtifactFuseDocument.uuID;
			}
		}

		// Token: 0x17002A82 RID: 10882
		// (get) Token: 0x060087CB RID: 34763 RVA: 0x00117D78 File Offset: 0x00115F78
		public static ArtifactFuseDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactFuseDocument.uuID) as ArtifactFuseDocument;
			}
		}

		// Token: 0x17002A83 RID: 10883
		// (get) Token: 0x060087CC RID: 34764 RVA: 0x00117DA4 File Offset: 0x00115FA4
		public ulong FuseUid
		{
			get
			{
				return this.m_fuseUid;
			}
		}

		// Token: 0x17002A84 RID: 10884
		// (get) Token: 0x060087CD RID: 34765 RVA: 0x00117DBC File Offset: 0x00115FBC
		public ulong FusedUid
		{
			get
			{
				return this.m_fusedUid;
			}
		}

		// Token: 0x17002A85 RID: 10885
		// (get) Token: 0x060087CE RID: 34766 RVA: 0x00117DD4 File Offset: 0x00115FD4
		public int FuseStoneItemId
		{
			get
			{
				bool flag = this.m_fuseStoneItemId == -1;
				if (flag)
				{
					this.m_fuseStoneItemId = XSingleton<XGlobalConfig>.singleton.GetInt("FuseStoneItemId");
				}
				return this.m_fuseStoneItemId;
			}
		}

		// Token: 0x17002A86 RID: 10886
		// (get) Token: 0x060087CF RID: 34767 RVA: 0x00117E10 File Offset: 0x00116010
		public ulong LastSelectUid
		{
			get
			{
				return this.m_lastSelectUid;
			}
		}

		// Token: 0x060087D0 RID: 34768 RVA: 0x00117E28 File Offset: 0x00116028
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactFuseDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060087D1 RID: 34769 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060087D2 RID: 34770 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x060087D3 RID: 34771 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x060087D4 RID: 34772 RVA: 0x00117E38 File Offset: 0x00116038
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.m_fuseUid > 0UL;
			if (flag)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_fuseUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					this.m_fuseUid = 0UL;
				}
			}
			bool flag3 = this.m_fusedUid > 0UL;
			if (flag3)
			{
				XItem itemByUID2 = XBagDocument.BagDoc.GetItemByUID(this.m_fusedUid);
				bool flag4 = itemByUID2 == null;
				if (flag4)
				{
					this.m_fusedUid = 0UL;
				}
			}
			this.RefreshUi(FuseEffectType.None);
		}

		// Token: 0x060087D5 RID: 34773 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x060087D6 RID: 34774 RVA: 0x00117EB4 File Offset: 0x001160B4
		public void RefreshUi(FuseEffectType type = FuseEffectType.None)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi(type);
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		// Token: 0x060087D7 RID: 34775 RVA: 0x00117EF4 File Offset: 0x001160F4
		public bool IsSelectUid(ulong uid)
		{
			return this.m_fusedUid == uid || this.m_fuseUid == uid;
		}

		// Token: 0x060087D8 RID: 34776 RVA: 0x00117F1C File Offset: 0x0011611C
		public void ResetSelectUid(bool isRefeshUi, FuseEffectType type = FuseEffectType.None)
		{
			this.m_fuseUid = 0UL;
			this.m_fusedUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi(type);
			}
		}

		// Token: 0x060087D9 RID: 34777 RVA: 0x00117F48 File Offset: 0x00116148
		public void AddItem(ulong uid)
		{
			bool flag = this.m_fuseUid == 0UL;
			if (flag)
			{
				this.m_fuseUid = uid;
			}
			else
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_fuseUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					this.m_fuseUid = uid;
				}
				else
				{
					bool flag3 = XBagDocument.BagDoc.ArtifactBag.HasItem(uid);
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("EquipedArtifactCannotFuse"), "fece00");
						return;
					}
					XItem itemByUID2 = XBagDocument.BagDoc.GetItemByUID(uid);
					bool flag4 = itemByUID2 == null;
					if (flag4)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("not find this uid = {0}", uid), null, null, null, null, null);
						return;
					}
					bool flag5 = itemByUID.itemConf == null || itemByUID2.itemConf == null;
					if (flag5)
					{
						return;
					}
					bool flag6 = itemByUID.itemConf.ItemQuality != itemByUID2.itemConf.ItemQuality;
					if (flag6)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseNotTips"), "fece00");
						return;
					}
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemByUID.itemID);
					bool flag7 = artifactListRowData == null;
					if (flag7)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("artifactlist not find this itemId = {0}", itemByUID.itemID), null, null, null, null, null);
						return;
					}
					ArtifactListTable.RowData artifactListRowData2 = ArtifactDocument.GetArtifactListRowData((uint)itemByUID2.itemID);
					bool flag8 = artifactListRowData2 == null;
					if (flag8)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("artifactlist not find this itemId = {0}", itemByUID2.itemID), null, null, null, null, null);
						return;
					}
					bool flag9 = artifactListRowData.ArtifactPos != artifactListRowData2.ArtifactPos;
					if (flag9)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseNotTips"), "fece00");
						return;
					}
					bool flag10 = this.m_fusedUid > 0UL;
					if (flag10)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseRepleaseSuc"), "fece00");
					}
					this.m_fusedUid = uid;
				}
			}
			this.RefreshUi(FuseEffectType.None);
		}

		// Token: 0x060087DA RID: 34778 RVA: 0x00118160 File Offset: 0x00116360
		public void TakeOut(ulong uid)
		{
			bool flag = uid == this.m_fuseUid;
			if (flag)
			{
				this.m_fuseUid = 0UL;
			}
			else
			{
				bool flag2 = uid == this.m_fusedUid;
				if (!flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("this item not put in uid = " + uid.ToString(), null, null, null, null, null);
					return;
				}
				this.m_fusedUid = 0UL;
			}
			this.RefreshUi(FuseEffectType.None);
		}

		// Token: 0x060087DB RID: 34779 RVA: 0x001181C8 File Offset: 0x001163C8
		public void ReqFuse()
		{
			this.m_lastSelectUid = this.m_fuseUid;
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = ArtifactDeityStoveOpType.ArtifactDeityStove_Fuse;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_fuseUid;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid2 = this.m_fusedUid;
			rpcC2G_ArtifactDeityStoveOp.oArg.isUsedStone = this.UseFuseStone;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

		// Token: 0x060087DC RID: 34780 RVA: 0x00118238 File Offset: 0x00116438
		public void OnReqFuseBack(ArtifactDeityStoveOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				bool flag2 = oRes.errorcode == ErrorCode.ERR_ARTIFACT_FUSEFAILED;
				if (flag2)
				{
					this.m_fusedUid = 0UL;
					this.RefreshUi(FuseEffectType.Fail);
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
			}
			else
			{
				this.ResetSelectUid(true, FuseEffectType.Sucess);
			}
		}

		// Token: 0x060087DD RID: 34781 RVA: 0x0011829C File Offset: 0x0011649C
		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_FUSE_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_FUSE_CONFIRM, 0, true);
		}

		// Token: 0x04002AD9 RID: 10969
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactFuseDocument");

		// Token: 0x04002ADA RID: 10970
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002ADB RID: 10971
		private ulong m_fuseUid = 0UL;

		// Token: 0x04002ADC RID: 10972
		private ulong m_fusedUid = 0UL;

		// Token: 0x04002ADD RID: 10973
		private int m_fuseStoneItemId = -1;

		// Token: 0x04002ADE RID: 10974
		private ulong m_lastSelectUid = 0UL;

		// Token: 0x04002ADF RID: 10975
		public bool UseFuseStone = true;

		// Token: 0x04002AE0 RID: 10976
		public ArtifactFuseHandler Handler;
	}
}
