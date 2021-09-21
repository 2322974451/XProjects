using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C7 RID: 2247
	internal class ArtifactInscriptionDocument : XDocComponent
	{
		// Token: 0x17002A87 RID: 10887
		// (get) Token: 0x060087E0 RID: 34784 RVA: 0x00118320 File Offset: 0x00116520
		public override uint ID
		{
			get
			{
				return ArtifactInscriptionDocument.uuID;
			}
		}

		// Token: 0x17002A88 RID: 10888
		// (get) Token: 0x060087E1 RID: 34785 RVA: 0x00118338 File Offset: 0x00116538
		public static ArtifactInscriptionDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactInscriptionDocument.uuID) as ArtifactInscriptionDocument;
			}
		}

		// Token: 0x17002A89 RID: 10889
		// (get) Token: 0x060087E2 RID: 34786 RVA: 0x00118364 File Offset: 0x00116564
		public ulong ArtifactUid
		{
			get
			{
				return this.m_artifactUid;
			}
		}

		// Token: 0x17002A8A RID: 10890
		// (get) Token: 0x060087E3 RID: 34787 RVA: 0x0011837C File Offset: 0x0011657C
		public ulong InscriptionUid
		{
			get
			{
				return this.m_inscriptionUid;
			}
		}

		// Token: 0x17002A8B RID: 10891
		// (get) Token: 0x060087E4 RID: 34788 RVA: 0x00118394 File Offset: 0x00116594
		public ulong LastSelectUid
		{
			get
			{
				return this.m_lastSelectUid;
			}
		}

		// Token: 0x060087E5 RID: 34789 RVA: 0x001183AC File Offset: 0x001165AC
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactInscriptionDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060087E6 RID: 34790 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060087E7 RID: 34791 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x060087E8 RID: 34792 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x060087E9 RID: 34793 RVA: 0x001183BC File Offset: 0x001165BC
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

		// Token: 0x060087EA RID: 34794 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x060087EB RID: 34795 RVA: 0x00118438 File Offset: 0x00116638
		public void RefreshUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		// Token: 0x060087EC RID: 34796 RVA: 0x00118478 File Offset: 0x00116678
		public bool IsSelectUid(ulong uid)
		{
			return this.m_artifactUid == uid || this.m_inscriptionUid == uid;
		}

		// Token: 0x060087ED RID: 34797 RVA: 0x001184A0 File Offset: 0x001166A0
		public void ResetSelectUid(bool isRefeshUi)
		{
			this.m_artifactUid = 0UL;
			this.m_inscriptionUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x060087EE RID: 34798 RVA: 0x001184CC File Offset: 0x001166CC
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

		// Token: 0x060087EF RID: 34799 RVA: 0x0011857C File Offset: 0x0011677C
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

		// Token: 0x060087F0 RID: 34800 RVA: 0x001185E4 File Offset: 0x001167E4
		public void ReqInscription()
		{
			this.m_lastSelectUid = this.m_artifactUid;
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = ArtifactDeityStoveOpType.ArtifactDeityStove_Inscription;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_artifactUid;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid2 = this.m_inscriptionUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

		// Token: 0x060087F1 RID: 34801 RVA: 0x00118644 File Offset: 0x00116844
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

		// Token: 0x060087F2 RID: 34802 RVA: 0x001186A0 File Offset: 0x001168A0
		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_INSCRIPTION_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_INSCRIPTION_CONFIRM, 0, true);
		}

		// Token: 0x04002AE1 RID: 10977
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactInscriptionDocument");

		// Token: 0x04002AE2 RID: 10978
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AE3 RID: 10979
		private ulong m_artifactUid = 0UL;

		// Token: 0x04002AE4 RID: 10980
		private ulong m_inscriptionUid = 0UL;

		// Token: 0x04002AE5 RID: 10981
		public ArtifactInscriptionHandler Handler;

		// Token: 0x04002AE6 RID: 10982
		private ulong m_lastSelectUid = 0UL;
	}
}
