using System;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class TooltipButtonOperateTakeOut : TooltipButtonOperateBase
	{

		public override string GetButtonText()
		{
			return XStringDefineProxy.GetString("TakeOut");
		}

		public override bool HasRedPoint(XItem item)
		{
			return false;
		}

		public override bool IsButtonVisible(XItem item)
		{
			return XSingleton<TooltipParam>.singleton.bShowTakeOutBtn;
		}

		public override void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			base.OnButtonClick(mainUID, compareUID);
			ArtifactDeityStoveDocument.Doc.TakeOut(mainUID);
		}
	}
}
