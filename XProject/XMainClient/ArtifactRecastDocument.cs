using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C8 RID: 2248
	internal class ArtifactRecastDocument : XDocComponent
	{
		// Token: 0x17002A8C RID: 10892
		// (get) Token: 0x060087F5 RID: 34805 RVA: 0x00118718 File Offset: 0x00116918
		public override uint ID
		{
			get
			{
				return ArtifactRecastDocument.uuID;
			}
		}

		// Token: 0x17002A8D RID: 10893
		// (get) Token: 0x060087F6 RID: 34806 RVA: 0x00118730 File Offset: 0x00116930
		public static ArtifactRecastDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactRecastDocument.uuID) as ArtifactRecastDocument;
			}
		}

		// Token: 0x17002A8E RID: 10894
		// (get) Token: 0x060087F7 RID: 34807 RVA: 0x0011875C File Offset: 0x0011695C
		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		// Token: 0x17002A8F RID: 10895
		// (get) Token: 0x060087F8 RID: 34808 RVA: 0x00118774 File Offset: 0x00116974
		public ulong LastSelectUid
		{
			get
			{
				return this.m_lastSelectUid;
			}
		}

		// Token: 0x060087F9 RID: 34809 RVA: 0x0011878C File Offset: 0x0011698C
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactRecastDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060087FA RID: 34810 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060087FB RID: 34811 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x060087FC RID: 34812 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x060087FD RID: 34813 RVA: 0x0011879C File Offset: 0x0011699C
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.m_selectUid > 0UL;
			if (flag)
			{
				XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_selectUid);
				bool flag2 = itemByUID == null;
				if (flag2)
				{
					this.m_selectUid = 0UL;
				}
			}
			this.RefreshUi();
		}

		// Token: 0x060087FE RID: 34814 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x060087FF RID: 34815 RVA: 0x001187E4 File Offset: 0x001169E4
		public void RefreshUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		// Token: 0x06008800 RID: 34816 RVA: 0x00118824 File Offset: 0x00116A24
		public bool IsSelectUid(ulong uid)
		{
			return this.m_selectUid == uid;
		}

		// Token: 0x06008801 RID: 34817 RVA: 0x00118840 File Offset: 0x00116A40
		public void ResetSelectUid(bool isRefeshUi)
		{
			this.m_selectUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x06008802 RID: 34818 RVA: 0x00118864 File Offset: 0x00116A64
		public void AddItem(ulong uid)
		{
			bool flag = this.m_selectUid > 0UL;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FuseRepleaseSuc"), "fece00");
			}
			this.m_selectUid = uid;
			this.RefreshUi();
		}

		// Token: 0x06008803 RID: 34819 RVA: 0x001188A8 File Offset: 0x00116AA8
		public void TakeOut(ulong uid)
		{
			this.m_selectUid = 0UL;
			this.RefreshUi();
		}

		// Token: 0x06008804 RID: 34820 RVA: 0x001188BC File Offset: 0x00116ABC
		public void ReqRecast()
		{
			this.m_lastSelectUid = this.m_selectUid;
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = ArtifactDeityStoveOpType.ArtifactDeityStove_Recast;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

		// Token: 0x06008805 RID: 34821 RVA: 0x00118908 File Offset: 0x00116B08
		public void OnReqRecastBack(ArtifactDeityStoveOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("RecastSuccess"), "fece00");
				this.ResetSelectUid(true);
			}
		}

		// Token: 0x06008806 RID: 34822 RVA: 0x00118964 File Offset: 0x00116B64
		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_RECAST_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM, 0, true);
		}

		// Token: 0x04002AE7 RID: 10983
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactRecastDocument");

		// Token: 0x04002AE8 RID: 10984
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AE9 RID: 10985
		private ulong m_selectUid = 0UL;

		// Token: 0x04002AEA RID: 10986
		private ulong m_lastSelectUid = 0UL;

		// Token: 0x04002AEB RID: 10987
		public ArtifactRecastHandler Handler;
	}
}
