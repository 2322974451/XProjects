using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000BC1 RID: 3009
	internal class XCharacterFashionView : DlgHandlerBase
	{
		// Token: 0x0600ABF6 RID: 44022 RVA: 0x001F8FB4 File Offset: 0x001F71B4
		public void SetFashionData(List<uint> data)
		{
			this.FashionData = data;
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

		// Token: 0x040040A1 RID: 16545
		private List<uint> FashionData = null;
	}
}
