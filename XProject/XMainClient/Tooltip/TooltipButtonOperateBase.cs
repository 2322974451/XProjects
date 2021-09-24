using System;

namespace XMainClient
{

	internal abstract class TooltipButtonOperateBase
	{

		public abstract string GetButtonText();

		public abstract bool HasRedPoint(XItem item);

		public abstract bool IsButtonVisible(XItem item);

		public virtual void OnButtonClick(ulong mainUID, ulong compareUID)
		{
			this.mainItemUID = mainUID;
			this.compareItemUID = compareUID;
		}

		protected ulong compareItemUID;

		protected ulong mainItemUID;
	}
}
