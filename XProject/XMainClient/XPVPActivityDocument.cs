using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000979 RID: 2425
	internal class XPVPActivityDocument : XDocComponent
	{
		// Token: 0x17002C88 RID: 11400
		// (get) Token: 0x0600920E RID: 37390 RVA: 0x001507B8 File Offset: 0x0014E9B8
		public override uint ID
		{
			get
			{
				return XPVPActivityDocument.uuID;
			}
		}

		// Token: 0x17002C89 RID: 11401
		// (get) Token: 0x0600920F RID: 37391 RVA: 0x001507D0 File Offset: 0x0014E9D0
		public PVPActivityList PVPActivityTable
		{
			get
			{
				return XPVPActivityDocument._pvpActivityTable;
			}
		}

		// Token: 0x06009210 RID: 37392 RVA: 0x001507E7 File Offset: 0x0014E9E7
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPVPActivityDocument.AsyncLoader.AddTask("Table/PVPActivityList", XPVPActivityDocument._pvpActivityTable, false);
			XPVPActivityDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009211 RID: 37393 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040030B7 RID: 12471
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PVPActivityDocument");

		// Token: 0x040030B8 RID: 12472
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040030B9 RID: 12473
		private static PVPActivityList _pvpActivityTable = new PVPActivityList();
	}
}
