using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FB7 RID: 4023
	internal class XArenaDocument : XDocComponent
	{
		// Token: 0x170036A3 RID: 13987
		// (get) Token: 0x0600D127 RID: 53543 RVA: 0x00305BF0 File Offset: 0x00303DF0
		public override uint ID
		{
			get
			{
				return XArenaDocument.uuID;
			}
		}

		// Token: 0x170036A4 RID: 13988
		// (get) Token: 0x0600D128 RID: 53544 RVA: 0x00305C07 File Offset: 0x00303E07
		// (set) Token: 0x0600D129 RID: 53545 RVA: 0x00305C0F File Offset: 0x00303E0F
		public bool RedPoint { get; set; }

		// Token: 0x0600D12A RID: 53546 RVA: 0x00305C18 File Offset: 0x00303E18
		public static void Execute(OnLoadedCallback callback = null)
		{
			XArenaDocument.AsyncLoader.AddTask("Table/SkillCombo", XArenaDocument.SkillComboTable, false);
			XArenaDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600D12B RID: 53547 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x04005EA7 RID: 24231
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArenaDocument");

		// Token: 0x04005EA8 RID: 24232
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04005EA9 RID: 24233
		public static SkillCombo SkillComboTable = new SkillCombo();
	}
}
