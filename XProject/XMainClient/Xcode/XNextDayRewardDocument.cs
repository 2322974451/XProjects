using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XNextDayRewardDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XNextDayRewardDocument.uuID;
			}
		}

		public int Status { get; set; }

		public int LeftTime { get; set; }

		public bool HallShow { get; set; }

		public void SendGetReward()
		{
			RpcC2G_GetNextDayReward rpc = new RpcC2G_GetNextDayReward();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		public void QueryStatus()
		{
			PtcC2G_NextDayRewardReport proto = new PtcC2G_NextDayRewardReport();
			XSingleton<XClientNetwork>.singleton.Send(proto);
		}

		public void RefreshStatus(uint status, uint leftTime)
		{
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void LuaShow(bool show)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("NextDayRewardDocument");
	}
}
