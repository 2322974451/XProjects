using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x0200090E RID: 2318
	internal class CollectNpcInfo
	{
		// Token: 0x06008BF2 RID: 35826 RVA: 0x0012D270 File Offset: 0x0012B470
		public CollectNpcInfo(uint _npcID, Vector3 _pos, string _name)
		{
			this.id = _npcID;
			this.pos = _pos;
			this.use = false;
			this.name = _name;
		}

		// Token: 0x04002CF3 RID: 11507
		public uint id = 0U;

		// Token: 0x04002CF4 RID: 11508
		public bool use = false;

		// Token: 0x04002CF5 RID: 11509
		public string name;

		// Token: 0x04002CF6 RID: 11510
		public Vector3 pos = Vector3.zero;
	}
}
