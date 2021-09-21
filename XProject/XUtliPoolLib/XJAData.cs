using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000204 RID: 516
	[Serializable]
	public class XJAData : XBaseData
	{
		// Token: 0x040006B6 RID: 1718
		[SerializeField]
		public string Next_Name = null;

		// Token: 0x040006B7 RID: 1719
		[SerializeField]
		public string Name = null;

		// Token: 0x040006B8 RID: 1720
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x040006B9 RID: 1721
		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		// Token: 0x040006BA RID: 1722
		[SerializeField]
		[DefaultValue(0f)]
		public float Point;
	}
}
