using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000207 RID: 519
	[Serializable]
	public class XCombinedData : XBaseData
	{
		// Token: 0x040006C4 RID: 1732
		[SerializeField]
		public string Name = null;

		// Token: 0x040006C5 RID: 1733
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x040006C6 RID: 1734
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x040006C7 RID: 1735
		[SerializeField]
		[DefaultValue(false)]
		public bool Override_Presentation;
	}
}
