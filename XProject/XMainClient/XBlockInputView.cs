using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D1C RID: 3356
	internal class XBlockInputView : DlgBase<XBlockInputView, XBlockInputBehaviour>
	{
		// Token: 0x170032EB RID: 13035
		// (get) Token: 0x0600BB16 RID: 47894 RVA: 0x002669FC File Offset: 0x00264BFC
		public override string fileName
		{
			get
			{
				return "Common/BlockInputPanel";
			}
		}

		// Token: 0x170032EC RID: 13036
		// (get) Token: 0x0600BB17 RID: 47895 RVA: 0x00266A14 File Offset: 0x00264C14
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600BB18 RID: 47896 RVA: 0x00266A27 File Offset: 0x00264C27
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XDebug>.singleton.AddLog("XBlockInputView OnShow", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600BB19 RID: 47897 RVA: 0x00266A47 File Offset: 0x00264C47
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XDebug>.singleton.AddLog("XBlockInputView OnHide", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
