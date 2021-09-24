using System;

namespace XMainClient
{

	internal class XFashionItem : XAttrItem
	{

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XFashionItem>.Recycle(this);
		}

		public uint fashionLevel;
	}
}
