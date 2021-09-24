using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XCharacterFashionView : DlgHandlerBase
	{

		public void SetFashionData(List<uint> data)
		{
			this.FashionData = data;
			bool flag = base.IsVisible();
			if (flag)
			{
				this.RefreshData();
			}
		}

		private List<uint> FashionData = null;
	}
}
