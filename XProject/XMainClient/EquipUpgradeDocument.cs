using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class EquipUpgradeDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return EquipUpgradeDocument.uuID;
			}
		}

		public static EquipUpgradeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(EquipUpgradeDocument.uuID) as EquipUpgradeDocument;
			}
		}

		public EquipUpgradeHandler Handler { get; set; }

		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			EquipUpgradeDocument.AsyncLoader.Execute(callback);
		}

		public static void OnTableLoaded()
		{
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		public void SelectEquip(ulong uid)
		{
			XItem itemByUID = XBagDocument.BagDoc.GetItemByUID(uid);
			bool flag = itemByUID == null;
			if (!flag)
			{
				this.m_selectUid = uid;
				bool flag2 = !DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
				if (!flag2)
				{
					bool flag3 = this.Handler != null && this.Handler.IsVisible();
					if (flag3)
					{
						this.Handler.ShowUI();
					}
					else
					{
						DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowRightPopView(DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipUpgradeHandler);
					}
					bool flag4 = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler != null;
					if (flag4)
					{
						DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._equipHandler.SelectEquip(uid);
					}
				}
			}
		}

		public void ReqUpgrade()
		{
			RpcC2G_UpgradeEquip rpcC2G_UpgradeEquip = new RpcC2G_UpgradeEquip();
			rpcC2G_UpgradeEquip.oArg.uid = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UpgradeEquip);
		}

		public void OnUpgradeBack(UpgradeEquipRes oRes)
		{
			bool flag = oRes == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_FAILED, "fece00");
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
					bool flag3 = this.Handler != null && this.Handler.IsVisible();
					if (flag3)
					{
						this.Handler.SetVisible(false);
					}
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EquipUpgradeDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private ulong m_selectUid = 0UL;
	}
}
