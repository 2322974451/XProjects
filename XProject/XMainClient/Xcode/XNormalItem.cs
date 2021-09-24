using System;

namespace XMainClient
{

	internal class XNormalItem : XItem
	{

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XNormalItem>.Recycle(this);
		}
	}
}
