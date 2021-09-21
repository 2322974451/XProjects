using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000E0D RID: 3597
	internal class XLevelDynamicInfo
	{
		// Token: 0x0600C1DA RID: 49626 RVA: 0x002984F4 File Offset: 0x002966F4
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

		// Token: 0x0400526D RID: 21101
		public int _id;

		// Token: 0x0400526E RID: 21102
		public bool _pushIntoTask = false;

		// Token: 0x0400526F RID: 21103
		public float _generatetime = 0f;

		// Token: 0x04005270 RID: 21104
		public float _prewaveFinishTime = 0f;

		// Token: 0x04005271 RID: 21105
		public float _exStringFinishTime = 0f;

		// Token: 0x04005272 RID: 21106
		public int _TotalCount = 0;

		// Token: 0x04005273 RID: 21107
		public int _generateCount = 0;

		// Token: 0x04005274 RID: 21108
		public int _dieCount = 0;

		// Token: 0x04005275 RID: 21109
		public List<ulong> _enemyIds = new List<ulong>();
	}
}
