using System;

namespace XMainClient
{
	// Token: 0x02000C95 RID: 3221
	internal class TooltipButtonOperateEmblemPutOn : TooltipButtonOperatePutOn
	{
		// Token: 0x0600B5F3 RID: 46579 RVA: 0x002407A8 File Offset: 0x0023E9A8
		public override bool IsButtonVisible(XItem item)
		{
			XEmblemItem xemblemItem = item as XEmblemItem;
			return xemblemItem.emblemInfo.thirdslot != 1U;
		}
	}
}
