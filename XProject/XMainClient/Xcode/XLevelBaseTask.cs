using System;

namespace XMainClient
{

	internal class XLevelBaseTask
	{

		public XLevelBaseTask(XLevelSpawnInfo ls)
		{
			this._spawner = ls;
		}

		public virtual bool Execute(float time)
		{
			return true;
		}

		public int _id;

		protected XLevelSpawnInfo _spawner;
	}
}
