using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBlockInputView : DlgBase<XBlockInputView, XBlockInputBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/BlockInputPanel";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XDebug>.singleton.AddLog("XBlockInputView OnShow", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XDebug>.singleton.AddLog("XBlockInputView OnHide", null, null, null, null, null, XDebugColor.XDebug_None);
		}
	}
}
