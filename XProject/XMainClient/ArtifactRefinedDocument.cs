using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C9 RID: 2249
	internal class ArtifactRefinedDocument : XDocComponent
	{
		// Token: 0x17002A90 RID: 10896
		// (get) Token: 0x06008809 RID: 34825 RVA: 0x001189D4 File Offset: 0x00116BD4
		public override uint ID
		{
			get
			{
				return ArtifactRefinedDocument.uuID;
			}
		}

		// Token: 0x17002A91 RID: 10897
		// (get) Token: 0x0600880A RID: 34826 RVA: 0x001189EC File Offset: 0x00116BEC
		public static ArtifactRefinedDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactRefinedDocument.uuID) as ArtifactRefinedDocument;
			}
		}

		// Token: 0x17002A92 RID: 10898
		// (get) Token: 0x0600880B RID: 34827 RVA: 0x00118A18 File Offset: 0x00116C18
		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		// Token: 0x17002A93 RID: 10899
		// (get) Token: 0x0600880C RID: 34828 RVA: 0x00118A30 File Offset: 0x00116C30
		public List<XItemChangeAttr> BeforeAttrList
		{
			get
			{
				return this.m_beforeAttrList;
			}
		}

		// Token: 0x17002A94 RID: 10900
		// (get) Token: 0x0600880D RID: 34829 RVA: 0x00118A48 File Offset: 0x00116C48
		public ulong LastSelectUid
		{
			get
			{
				return this.m_lastSelectUid;
			}
		}

		// Token: 0x0600880E RID: 34830 RVA: 0x00118A60 File Offset: 0x00116C60
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactRefinedDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600880F RID: 34831 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008810 RID: 34832 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008811 RID: 34833 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008812 RID: 34834 RVA: 0x00118A70 File Offset: 0x00116C70
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

		// Token: 0x06008813 RID: 34835 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008814 RID: 34836 RVA: 0x00118AB8 File Offset: 0x00116CB8
		public void RefreshUi()
		{
			bool flag = this.Handler != null && this.Handler.IsVisible();
			if (flag)
			{
				this.Handler.RefreshUi();
			}
			ArtifactDeityStoveDocument.Doc.RefreshUi();
		}

		// Token: 0x06008815 RID: 34837 RVA: 0x00118AF8 File Offset: 0x00116CF8
		public bool IsSelectUid(ulong uid)
		{
			return this.m_selectUid == uid;
		}

		// Token: 0x06008816 RID: 34838 RVA: 0x00118B14 File Offset: 0x00116D14
		public void ResetSelectUid(bool isRefeshUi)
		{
			this.m_selectUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi();
			}
		}

		// Token: 0x06008817 RID: 34839 RVA: 0x00118B38 File Offset: 0x00116D38
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

		// Token: 0x06008818 RID: 34840 RVA: 0x00118B7C File Offset: 0x00116D7C
		public void TakeOut(ulong uid)
		{
			this.m_selectUid = 0UL;
			this.RefreshUi();
		}

		// Token: 0x06008819 RID: 34841 RVA: 0x00118B90 File Offset: 0x00116D90
		public void ReqRefined(ArtifactDeityStoveOpType type)
		{
			this.m_lastSelectUid = this.m_selectUid;
			this.SetBeforeAttr();
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = type;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

		// Token: 0x0600881A RID: 34842 RVA: 0x00118BE4 File Offset: 0x00116DE4
		public void OnReqRefinedBack(ArtifactDeityStoveOpType type, ArtifactDeityStoveOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				switch (type)
				{
				case ArtifactDeityStoveOpType.ArtifactDeityStove_Refine:
				{
					bool flag2 = this.Handler != null && this.Handler.IsVisible();
					if (flag2)
					{
						this.Handler.ShowReplaceHandler();
					}
					break;
				}
				case ArtifactDeityStoveOpType.ArtifactDeityStove_RefineRetain:
					this.RefreshUi();
					break;
				case ArtifactDeityStoveOpType.ArtifactDeityStove_RefineReplace:
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("FuseRepleaseSuc"), "fece00");
					this.RefreshUi();
					break;
				}
			}
		}

		// Token: 0x0600881B RID: 34843 RVA: 0x00118C8C File Offset: 0x00116E8C
		private void SetBeforeAttr()
		{
			this.m_beforeAttrList.Clear();
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(this.m_selectUid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				XArtifactItem xartifactItem = itemByUID as XArtifactItem;
				for (int i = 0; i < xartifactItem.RandAttrInfo.RandAttr.Count; i++)
				{
					XItemChangeAttr item = xartifactItem.RandAttrInfo.RandAttr[i];
					this.m_beforeAttrList.Add(item);
				}
			}
		}

		// Token: 0x0600881C RID: 34844 RVA: 0x00118D0C File Offset: 0x00116F0C
		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_REFINED_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM, 0, true);
		}

		// Token: 0x04002AEC RID: 10988
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactRefinedDocument");

		// Token: 0x04002AED RID: 10989
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AEE RID: 10990
		private ulong m_selectUid = 0UL;

		// Token: 0x04002AEF RID: 10991
		private List<XItemChangeAttr> m_beforeAttrList = new List<XItemChangeAttr>();

		// Token: 0x04002AF0 RID: 10992
		private ulong m_lastSelectUid = 0UL;

		// Token: 0x04002AF1 RID: 10993
		public ArtifactRefinedHandler Handler;
	}
}
