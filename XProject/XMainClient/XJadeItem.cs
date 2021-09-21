using System;

namespace XMainClient
{
	// Token: 0x02000DE6 RID: 3558
	internal class XJadeItem : XAttrItem
	{
		// Token: 0x0600C0E0 RID: 49376 RVA: 0x0028DB2D File Offset: 0x0028BD2D
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XJadeItem>.Recycle(this);
		}
	}
}
