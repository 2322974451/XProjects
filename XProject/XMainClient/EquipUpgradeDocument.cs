using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A53 RID: 2643
	internal class EquipUpgradeDocument : XDocComponent
	{
		// Token: 0x17002EFD RID: 12029
		// (get) Token: 0x0600A06F RID: 41071 RVA: 0x001AD478 File Offset: 0x001AB678
		public override uint ID
		{
			get
			{
				return EquipUpgradeDocument.uuID;
			}
		}

		// Token: 0x17002EFE RID: 12030
		// (get) Token: 0x0600A070 RID: 41072 RVA: 0x001AD490 File Offset: 0x001AB690
		public static EquipUpgradeDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(EquipUpgradeDocument.uuID) as EquipUpgradeDocument;
			}
		}

		// Token: 0x17002EFF RID: 12031
		// (get) Token: 0x0600A071 RID: 41073 RVA: 0x001AD4BB File Offset: 0x001AB6BB
		// (set) Token: 0x0600A072 RID: 41074 RVA: 0x001AD4C3 File Offset: 0x001AB6C3
		public EquipUpgradeHandler Handler { get; set; }

		// Token: 0x17002F00 RID: 12032
		// (get) Token: 0x0600A073 RID: 41075 RVA: 0x001AD4CC File Offset: 0x001AB6CC
		public ulong SelectUid
		{
			get
			{
				return this.m_selectUid;
			}
		}

		// Token: 0x0600A074 RID: 41076 RVA: 0x001AD4E4 File Offset: 0x001AB6E4
		public static void Execute(OnLoadedCallback callback = null)
		{
			EquipUpgradeDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600A075 RID: 41077 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void OnTableLoaded()
		{
		}

		// Token: 0x0600A076 RID: 41078 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x0600A077 RID: 41079 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x0600A078 RID: 41080 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x0600A079 RID: 41081 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x0600A07A RID: 41082 RVA: 0x001AD4F4 File Offset: 0x001AB6F4
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

		// Token: 0x0600A07B RID: 41083 RVA: 0x001AD594 File Offset: 0x001AB794
		public void ReqUpgrade()
		{
			RpcC2G_UpgradeEquip rpcC2G_UpgradeEquip = new RpcC2G_UpgradeEquip();
			rpcC2G_UpgradeEquip.oArg.uid = this.m_selectUid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_UpgradeEquip);
		}

		// Token: 0x0600A07C RID: 41084 RVA: 0x001AD5C8 File Offset: 0x001AB7C8
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

		// Token: 0x04003985 RID: 14725
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("EquipUpgradeDocument");

		// Token: 0x04003986 RID: 14726
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003987 RID: 14727
		private ulong m_selectUid = 0UL;
	}
}
