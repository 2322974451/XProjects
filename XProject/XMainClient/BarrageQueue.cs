using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class BarrageQueue
	{

		public int queueCnt
		{
			get
			{
				return this.mItems.Count;
			}
		}

		public void Fire(BarrageItem item, string txt, bool outline)
		{
			this.mItems.Add(item);
			item.Make(txt, this, outline);
			this.depth++;
		}

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

		public int depth = 1;

		private List<BarrageItem> mItems = new List<BarrageItem>();
	}
}
