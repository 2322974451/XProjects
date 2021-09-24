using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactRefinedDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactRefinedDocument.uuID;
			}
		}

		public static ArtifactRefinedDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactRefinedDocument.uuID) as ArtifactRefinedDocument;
			}
		}

		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		public List<XItemChangeAttr> BeforeAttrList
		{
			get
			{
				return this.m_beforeAttrList;
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
			ArtifactRefinedDocument.AsyncLoader.Execute(callback);
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

		public void ReqRefined(ArtifactDeityStoveOpType type)
		{
			this.m_lastSelectUid = this.m_selectUid;
			this.SetBeforeAttr();
			RpcC2G_ArtifactDeityStoveOp rpcC2G_ArtifactDeityStoveOp = new RpcC2G_ArtifactDeityStoveOp();
			rpcC2G_ArtifactDeityStoveOp.oArg.type = type;
			rpcC2G_ArtifactDeityStoveOp.oArg.uid1 = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ArtifactDeityStoveOp);
		}

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

		public void ResetSetting()
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.ForceSetTipsValue(XTempTipDefine.OD_REFINED_CONFIRM, false);
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			specificDocument.SetValue(XOptionsDefine.OD_NO_REFINED_CONFIRM, 0, true);
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactRefinedDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private ulong m_selectUid = 0UL;

		private List<XItemChangeAttr> m_beforeAttrList = new List<XItemChangeAttr>();

		private ulong m_lastSelectUid = 0UL;

		public ArtifactRefinedHandler Handler;
	}
}
