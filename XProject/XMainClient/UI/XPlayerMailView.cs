using System;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001847 RID: 6215
	internal class XPlayerMailView : DlgHandlerBase
	{
		// Token: 0x0601024E RID: 66126 RVA: 0x00226F6F File Offset: 0x0022516F
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0601024F RID: 66127 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x06010250 RID: 66128 RVA: 0x003DDD4C File Offset: 0x003DBF4C
		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
		}

		// Token: 0x04007350 RID: 29520
		private XMailDocument _doc = null;
	}
}
