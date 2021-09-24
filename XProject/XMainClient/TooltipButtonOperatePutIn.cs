using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperatePutIn : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TAKEIN");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<TooltipParam>.singleton.bShowPutInBtn;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			ArtifactDeityStoveDocument.Doc.Additem(mainUID);
		}
	}
}
