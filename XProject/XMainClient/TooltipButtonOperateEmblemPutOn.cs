using System;

namespace XMainClient
{

	internal class TooltipButtonOperateEmblemPutOn : TooltipButtonOperatePutOn
	{

		public override bool IsButtonVisible(XItem item)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			return xemblemItem.emblemInfo.thirdslot != 1U;
		}
	}
}
