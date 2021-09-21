using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001CF RID: 463
	public class XElapseTimer
	{
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x00039424 File Offset: 0x00037624
		// (set) Token: 0x06000AB1 RID: 2737 RVA: 0x0003943C File Offset: 0x0003763C
		public float LeftTime
		{
			get
			{
				return this.m_LeftTime;
			}
			set
			{
				this.m_LeftTime = value;
				this.m_OriLeftTime = this.m_LeftTime;
				this.m_LastTime = -1f;
				this.m_PassTime = 0f;
			}
		}

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000AB2 RID: 2738 RVA: 0x00039468 File Offset: 0x00037668
		public float PassTime
		{
			get
			{
				return this.m_PassTime;
			}
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00039480 File Offset: 0x00037680
		public void Update()
		{
			this.m_PassTime = 0f;
			bool flag = this.m_LastTime < 0f;
			if (flag)
			{
				this.m_LastTime = Time.time;
			}
			else
			{
				this.m_PassTime = Time.time - this.m_LastTime;
			}
			this.m_LeftTime = this.m_OriLeftTime - this.m_PassTime;
			bool flag2 = this.m_LeftTime < 0f;
			if (flag2)
			{
				this.m_LeftTime = 0f;
			}
		}

		// Token: 0x04000514 RID: 1300
		private float m_OriLeftTime = 0f;

		// Token: 0x04000515 RID: 1301
		private float m_LeftTime = 0f;

		// Token: 0x04000516 RID: 1302
		private float m_LastTime = -1f;

		// Token: 0x04000517 RID: 1303
		private float m_PassTime = 0f;
	}
}
