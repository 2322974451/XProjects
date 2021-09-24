using System;
using UILib;

namespace XMainClient.UI
{

	internal class XDramaOperateList : XDataBase
	{

		public override void Init()
		{
			base.Init();
			this.Name = null;
			this.ClickEvent = null;
			this.TargetTime = 0f;
			this.TimeNote = null;
			this.RID = 0UL;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XDramaOperateList>.Recycle(this);
		}

		public string Name;

		public SpriteClickEventHandler ClickEvent;

		public float TargetTime;

		public string TimeNote;

		public ulong RID;
	}
}
