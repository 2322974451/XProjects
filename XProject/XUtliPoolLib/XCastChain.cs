using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000216 RID: 534
	[Serializable]
	public class XCastChain
	{
		// Token: 0x04000742 RID: 1858
		[SerializeField]
		[DefaultValue(0f)]
		public float At = 0f;

		// Token: 0x04000743 RID: 1859
		[SerializeField]
		[DefaultValue(0)]
		public int TemplateID = 0;

		// Token: 0x04000744 RID: 1860
		[SerializeField]
		public string Name = null;
	}
}
