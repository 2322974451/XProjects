using System;

namespace XUtliPoolLib
{

	public class XObjAsyncData : IQueueObject
	{

		public IQueueObject next { get; set; }

		public void Reset()
		{
			this.data = null;
			this.commandCb = null;
			bool flag = this.resetCb != null;
			if (flag)
			{
				this.resetCb();
				this.resetCb = null;
			}
		}

		public object data = null;

		public CommandCallback commandCb = null;

		public ResetCallback resetCb = null;
	}
}
