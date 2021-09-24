using System;
using UILib;

namespace XMainClient.UI
{

	internal class XDramaOperateButton : XDataBase
	{

		public override void Init()
		{
			base.Init();
			this.Name = null;
			this.ClickEvent = null;
			this.TargetTime = 0f;
			this.TimeNote = null;
			this.StateEnable = true;
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XDramaOperateButton>.Recycle(this);
		}

		public string Name;

		public ButtonClickEventHandler ClickEvent;

		public float TargetTime;

		public string TimeNote;

		public bool StateEnable = true;

		public ulong RID;
	}
}
