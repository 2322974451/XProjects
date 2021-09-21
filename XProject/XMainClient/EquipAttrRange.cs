using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E7 RID: 2279
	internal class EquipAttrRange
	{
		// Token: 0x060089DB RID: 35291 RVA: 0x0012257C File Offset: 0x0012077C
		public EquipAttrRange(SeqRef<uint> seq)
		{
			this.m_min = seq[0];
			this.m_max = seq[1];
		}

		// Token: 0x17002AF1 RID: 10993
		// (get) Token: 0x060089DC RID: 35292 RVA: 0x001225D0 File Offset: 0x001207D0
		public float Min
		{
			get
			{
				return this.m_min;
			}
		}

		// Token: 0x17002AF2 RID: 10994
		// (get) Token: 0x060089DD RID: 35293 RVA: 0x001225E8 File Offset: 0x001207E8
		public float Max
		{
			get
			{
				return this.m_max;
			}
		}

		// Token: 0x17002AF3 RID: 10995
		// (get) Token: 0x060089DE RID: 35294 RVA: 0x00122600 File Offset: 0x00120800
		public float D_value
		{
			get
			{
				return this.m_max - this.m_min;
			}
		}

		// Token: 0x17002AF4 RID: 10996
		// (get) Token: 0x060089DF RID: 35295 RVA: 0x00122620 File Offset: 0x00120820
		public uint Prob
		{
			get
			{
				return this.m_prob;
			}
		}

		// Token: 0x04002BC2 RID: 11202
		private float m_min = 0f;

		// Token: 0x04002BC3 RID: 11203
		private float m_max = 0f;

		// Token: 0x04002BC4 RID: 11204
		private uint m_prob = 0U;
	}
}
