using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPVPActivityDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPVPActivityDocument.uuID;
			}
		}

		public PVPActivityList PVPActivityTable
		{
			get
			{
				return XPVPActivityDocument._pvpActivityTable;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XPVPActivityDocument.AsyncLoader.AddTask("Table/PVPActivityList", XPVPActivityDocument._pvpActivityTable, false);
			XPVPActivityDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PVPActivityDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PVPActivityList _pvpActivityTable = new PVPActivityList();
	}
}
