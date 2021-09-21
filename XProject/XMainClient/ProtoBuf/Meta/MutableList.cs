using System;

namespace ProtoBuf.Meta
{
	// Token: 0x02000884 RID: 2180
	internal sealed class MutableList : BasicList
	{
		// Token: 0x170029E7 RID: 10727
		public new object this[int index]
		{
			get
			{
				return this.head[index];
			}
			set
			{
				this.head[index] = value;
			}
		}

		// Token: 0x0600848E RID: 33934 RVA: 0x00102FEF File Offset: 0x001011EF
		public void RemoveLast()
		{
			this.head.RemoveLastWithMutate();
		}

		// Token: 0x0600848F RID: 33935 RVA: 0x00102FFE File Offset: 0x001011FE
		public new void Clear()
		{
			this.head.Clear();
		}
	}
}
