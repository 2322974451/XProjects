using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000215 RID: 533
	[Serializable]
	public class XMobUnitData : XBaseData
	{
		// Token: 0x0400073B RID: 1851
		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		// Token: 0x0400073C RID: 1852
		[SerializeField]
		[DefaultValue(0)]
		public int TemplateID;

		// Token: 0x0400073D RID: 1853
		[SerializeField]
		[DefaultValue(false)]
		public bool LifewithinSkill;

		// Token: 0x0400073E RID: 1854
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_X;

		// Token: 0x0400073F RID: 1855
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_Y;

		// Token: 0x04000740 RID: 1856
		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_At_Z;

		// Token: 0x04000741 RID: 1857
		[SerializeField]
		[DefaultValue(false)]
		public bool Shield;
	}
}
