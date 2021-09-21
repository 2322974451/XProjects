using System;

namespace XMainClient
{
	// Token: 0x02000DEF RID: 3567
	internal class XNormalItem : XItem
	{
		// Token: 0x0600C111 RID: 49425 RVA: 0x0028E4D1 File Offset: 0x0028C6D1
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XNormalItem>.Recycle(this);
		}
	}
}
