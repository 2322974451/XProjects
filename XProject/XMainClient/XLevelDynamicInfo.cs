using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XLevelDynamicInfo
	{

		public void Reset()
		{
			this._pushIntoTask = false;
			this._generatetime = 0f;
			this._generateCount = 0;
			this._prewaveFinishTime = 0f;
			this._exStringFinishTime = 0f;
			this._dieCount = 0;
			this._enemyIds.Clear();
		}

		public int _id;

		public bool _pushIntoTask = false;

		public float _generatetime = 0f;

		public float _prewaveFinishTime = 0f;

		public float _exStringFinishTime = 0f;

		public int _TotalCount = 0;

		public int _generateCount = 0;

		public int _dieCount = 0;

		public List<ulong> _enemyIds = new List<ulong>();
	}
}
