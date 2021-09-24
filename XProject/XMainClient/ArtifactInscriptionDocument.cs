using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactInscriptionDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactInscriptionDocument.uuID;
			}
		}

		public static ArtifactInscriptionDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactInscriptionDocument.uuID) as ArtifactInscriptionDocument;
			}
		}

		public ulong ArtifactUid
		{
			get
			{
				return this.m_artifactUid;
			}
		}

		public ulong InscriptionUid
		{
			get
			{
				return this.m_inscriptionUid;
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
			ArtifactInscriptionDocument.AsyncLoader.Execute(callback);
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
			bool flag = this.m_artifactUid > 0UL;
			if (flag)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_artifactUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					this.m_artifactUid = 0UL;
				}
			}
			bool flag3 = this.m_inscriptionUid > 0UL;
			if (flag3)
			{
				XItem itemByUID2 = XBagDocument.BagDoc.GetItemByUID(this.m_inscriptionUid);
				bool flag4 = itemByUID2 == null;
				if (flag4)
				{
					this.m_inscriptionUid = 0UL;
				}
			}
			this.RefreshUi();
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		public void RefreshUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		public bool IsSelectUid(ulong uid)
		{
			return this.m_artifactUid == uid || this.m_inscriptionUid == uid;
		}

		public void ResetSelectUid(bool isRefeshUi)
		{
			this.m_artifactUid = 0UL;
			this.m_inscriptionUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi();
			}
		}

		public void AddItem(ulong uid)
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				ulong num = 0UL;
				bool flag2 = itemByUID.Type == ItemType.ARTIFACT;
				if (flag2)
				{
					num = this.m_artifactUid;
					this.m_artifactUid = uid;
				}
				else
				{
					bool flag3 = itemByUID.Type == ItemType.Inscription;
					if (flag3)
					{
						num = this.m_inscriptionUid;
						this.m_inscriptionUid = uid;
					}
					else
					{
						XSingleton<XDebug>.singleton.AddGreenLog("type error!", null, null, null, null, null);
					}
				}
				bool flag4 = num > 0UL;
				if (flag4)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseRepleaseSuc"), "fece00");
				}
				this.RefreshUi();
			}
		}

		public void TakeOut(ulong uid)
		{
			bool flag = uid == this.m_artifactUid;
			if (flag)
			{
				this.m_artifactUid = 0UL;
			}
			else
			{
				bool flag2 = uid == this.m_inscriptionUid;
				if (!flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("this item not put in uid = " + uid.ToString(), null, null, null, null, null);
					return;
				}
				this.m_inscriptionUid = 0UL;
			}
			this.RefreshUi();
		}

		public void ReqInscription()
		{
			this.m_lastSelectUid = this.m_artifactUid;
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = ArtifactDeityStoveOpType.ArtifactDeityStove_Inscription;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_artifactUid;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid2 = this.m_inscriptionUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

		public void OnReqInscriptionBack(ArtifactDeityStoveOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("Inscription"), "fece00");
				this.ResetSelectUid(true);
			}
		}

		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_INSCRIPTION_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM, 0, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactInscriptionDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private ulong m_artifactUid = 0UL;

		private ulong m_inscriptionUid = 0UL;

		public ArtifactInscriptionHandler Handler;

		private ulong m_lastSelectUid = 0UL;
	}
}
