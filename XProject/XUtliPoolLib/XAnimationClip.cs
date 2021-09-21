using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000053 RID: 83
	public class XAnimationClip : ScriptableObject
	{
		// Token: 0x060002B8 RID: 696 RVA: 0x0001513C File Offset: 0x0001333C
		public void Reset()
		{
			this.clip = null;
			this.length = 0f;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00015154 File Offset: 0x00013354
		public int GetInstanceID()
		{
			return (this.clip == null) ? 0 : this.clip.GetInstanceID();
		}

		// Token: 0x0400026F RID: 623
		public AnimationClip clip;

		// Token: 0x04000270 RID: 624
		public float length;
	}
}
