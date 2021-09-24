using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XDragonPartnerDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XDragonPartnerDocument.uuID;
			}
		}

		public List<DragonGroupRoleInfo> DragonGroupRoleInfoLsit { get; private set; }

		public List<DragonGroupRecordInfoList> RecordList { get; private set; }

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void ReqDragonGroupRoleInfo()
		{
			XSingleton<XDebug>.singleton.AddLog("DragonPartner ReqDragonGroupRoleInfo.", null, null, null, null, null, XDebugColor.XDebug_None);
			RpcC2G_DragonGroupRoleList rpc = new RpcC2G_DragonGroupRoleList();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void SendDragonGroupRecord()
		{
			XSingleton<XDebug>.singleton.AddGreenLog("SendDragonGroupRecord", null, null, null, null, null);
			RpcC2G_DragonGroupRecord rpc = new RpcC2G_DragonGroupRecord();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("DragonPartnerDocument");

		public XDragonPartnerHandler View;
	}
}
