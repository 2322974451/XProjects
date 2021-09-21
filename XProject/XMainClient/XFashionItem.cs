using System;

namespace XMainClient
{
	// Token: 0x02000DE9 RID: 3561
	internal class XFashionItem : XAttrItem
	{
		// Token: 0x0600C0F2 RID: 49394 RVA: 0x0028DD99 File Offset: 0x0028BF99
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XFashionItem>.Recycle(this);
		}

		// Token: 0x04005119 RID: 20761
		public uint fashionLevel;
	}
}
