using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000208 RID: 520
	[Serializable]
	public class XQTEData
	{
		// Token: 0x040006C8 RID: 1736
		[SerializeField]
		public int QTE = 0;

		// Token: 0x040006C9 RID: 1737
		[SerializeField]
		[DefaultValue(0f)]
		public float At = 0f;

		// Token: 0x040006CA RID: 1738
		[SerializeField]
		[DefaultValue(0f)]
		public float End = 0f;
	}
}
