using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000909 RID: 2313
	internal class XDragonPartnerDocument : XDocComponent
	{
		// Token: 0x17002B65 RID: 11109
		// (get) Token: 0x06008BCA RID: 35786 RVA: 0x0012C640 File Offset: 0x0012A840
		public override uint ID
		{
			get
			{
				return XDragonPartnerDocument.uuID;
			}
		}

		// Token: 0x17002B66 RID: 11110
		// (get) Token: 0x06008BCC RID: 35788 RVA: 0x0012C660 File Offset: 0x0012A860
		// (set) Token: 0x06008BCB RID: 35787 RVA: 0x0012C657 File Offset: 0x0012A857
		public List<DragonGroupRoleInfo> DragonGroupRoleInfoLsit { get; private set; }

		// Token: 0x17002B67 RID: 11111
		// (get) Token: 0x06008BCE RID: 35790 RVA: 0x0012C671 File Offset: 0x0012A871
		// (set) Token: 0x06008BCD RID: 35789 RVA: 0x0012C668 File Offset: 0x0012A868
		public List<DragonGroupRecordInfoList> RecordList { get; private set; }

		// Token: 0x06008BCF RID: 35791 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008BD0 RID: 35792 RVA: 0x0012C67C File Offset: 0x0012A87C
		public void ReqDragonGroupRoleInfo()
		{
			XSingleton<XDebug>.singleton.AddLog("DragonPartner ReqDragonGroupRoleInfo.", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_DragonGroupRoleList rpc = new RpcC2G_DragonGroupRoleList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008BD1 RID: 35793 RVA: 0x0012C6B4 File Offset: 0x0012A8B4
		public void OnReqDragonGropRoleInfo(DragonGroupRoleListC2S oArg, DragonGroupRoleListS2C oRes)
		{
			XSingleton<XDebug>.singleton.AddLog("DragonGroupRoleList OnReqDragonGropRoleInfo", null, null, null, null, null, XDebugColor.XDebug_None);
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
			}
			else
			{
				this.DragonGroupRoleInfoLsit = oRes.rolelist;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshData();
				}
			}
		}

		// Token: 0x06008BD2 RID: 35794 RVA: 0x0012C730 File Offset: 0x0012A930
		public void SendDragonGroupRecord()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("SendDragonGroupRecord", null, null, null, null, null);
			RpcC2G_DragonGroupRecord rpc = new RpcC2G_DragonGroupRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x06008BD3 RID: 35795 RVA: 0x0012C768 File Offset: 0x0012A968
		public void ReceiveDragonGroupRecord(DragonGroupRecordC2S arg, DragonGroupRecordS2C res)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("ReceiveDragonGroupRecord", null, null, null, null, null);
			bool flag = res.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.errorcode, "fece00");
			}
			else
			{
				this.RecordList = res.recordlist;
				bool flag2 = this.View != null && this.View.IsVisible();
				if (flag2)
				{
					this.View.RefreshData();
				}
			}
		}

		// Token: 0x04002CD3 RID: 11475
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonPartnerDocument");

		// Token: 0x04002CD4 RID: 11476
		public XDragonPartnerHandler View;
	}
}
