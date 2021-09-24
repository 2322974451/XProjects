using System;

namespace XMainClient
{

	internal class XItemRequired : XDataBase
	{

		public bool bEnough
		{
			get
			{
				return this.requiredCount <= this.ownedCount;
			}
		}

		public override void Init()
		{
			base.Init();
			this.itemID = 0;
			this.requiredCount = 0UL;
			this.ownedCount = 0UL;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XItemRequired>.Recycle(this);
		}

		public int itemID;

		public ulong requiredCount;

		public ulong ownedCount;
	}
}
