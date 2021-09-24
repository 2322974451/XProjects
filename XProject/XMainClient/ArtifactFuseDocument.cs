using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactFuseDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactFuseDocument.uuID;
			}
		}

		public static ArtifactFuseDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactFuseDocument.uuID) as ArtifactFuseDocument;
			}
		}

		public ulong FuseUid
		{
			get
			{
				return this.m_fuseUid;
			}
		}

		public ulong FusedUid
		{
			get
			{
				return this.m_fusedUid;
			}
		}

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

		public ulong LastSelectUid
		{
			get
			{
				return this.m_lastSelectUid;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactFuseDocument.AsyncLoader.Execute(callback);
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

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void RefreshUi(FuseEffectType type = FuseEffectType.None)
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi(type);
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		public bool IsSelectUid(ulong uid)
		{
			return this.m_fusedUid == uid || this.m_fuseUid == uid;
		}

		public void ResetSelectUid(bool isRefeshUi, FuseEffectType type = FuseEffectType.None)
		{
			this.m_fuseUid = 0UL;
			this.m_fusedUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi(type);
			}
		}

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

		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_FUSE_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_FUSE_CONFIRM, 0, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactFuseDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private ulong m_fuseUid = 0UL;

		private ulong m_fusedUid = 0UL;

		private int m_fuseStoneItemId = -1;

		private ulong m_lastSelectUid = 0UL;

		public bool UseFuseStone = true;

		public ArtifactFuseHandler Handler;
	}
}
