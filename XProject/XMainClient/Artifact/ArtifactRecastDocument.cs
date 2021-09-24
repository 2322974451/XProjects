using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactRecastDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactRecastDocument.uuID;
			}
		}

		public static ArtifactRecastDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactRecastDocument.uuID) as ArtifactRecastDocument;
			}
		}

		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
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
			ArtifactRecastDocument.AsyncLoader.Execute(callback);
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
			return this.m_selectUid == uid;
		}

		public void ResetSelectUid(bool isRefeshUi)
		{
			this.m_selectUid = 0UL;
			if (isRefeshUi)
			{
				this.RefreshUi();
			}
		}

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

		public void TakeOut(ulong uid)
		{
			this.m_selectUid = 0UL;
			this.RefreshUi();
		}

		public void ReqRecast()
		{
			this.m_lastSelectUid = this.m_selectUid;
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = ArtifactDeityStoveOpType.ArtifactDeityStove_Recast;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

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

		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_RECAST_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_RECAST_CONFIRM, 0, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactRecastDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private ulong m_selectUid = 0UL;

		private ulong m_lastSelectUid = 0UL;

		public ArtifactRecastHandler Handler;
	}
}
