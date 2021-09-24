using System;

namespace XMainClient
{

	internal class XJadeItem : XAttrItem
	{

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XJadeItem>.Recycle(this);
		}
	}
}
