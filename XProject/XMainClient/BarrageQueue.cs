using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000BC7 RID: 3015
	internal class BarrageQueue
	{
		// Token: 0x17003074 RID: 12404
		// (get) Token: 0x0600AC21 RID: 44065 RVA: 0x001FA15C File Offset: 0x001F835C
		public int queueCnt
		{
			get
			{
				return this.mItems.Count;
			}
		}

		// Token: 0x0600AC22 RID: 44066 RVA: 0x001FA179 File Offset: 0x001F8379
		public void Fire(BarrageItem item, string txt, bool outline)
		{
			this.mItems.Add(item);
			item.Make(txt, this, outline);
			this.depth++;
		}

		// Token: 0x0600AC23 RID: 44067 RVA: 0x001FA1A4 File Offset: 0x001F83A4
		public bool FadeOut(BarrageItem item)
		{
			bool flag = this.mItems.Contains(item);
			bool result;
			if (flag)
			{
				this.mItems.Remove(item);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600AC24 RID: 44068 RVA: 0x001FA1DC File Offset: 0x001F83DC
		public void ForceClear()
		{
			for (int i = 0; i < this.mItems.Count; i++)
			{
				bool flag = this.mItems[i] != null && this.mItems[i].gameObject != null;
				if (flag)
				{
					this.mItems[i].Drop();
				}
			}
			this.mItems.Clear();
			this.depth = 1;
		}

		// Token: 0x040040C1 RID: 16577
		public int depth = 1;

		// Token: 0x040040C2 RID: 16578
		private List<BarrageItem> mItems = new List<BarrageItem>();
	}
}
