using System;

namespace XMainClient
{
	// Token: 0x02000E95 RID: 3733
	internal class XBetterDictionary<KK, VV>
	{
		// Token: 0x0600C73E RID: 51006 RVA: 0x002C348C File Offset: 0x002C168C
		public XBetterDictionary(int maxSize = 0)
		{
			this.maxbuffersize = maxSize;
			this.m_bufferKeys = new XBetterList<KK>(this.maxbuffersize);
			this.m_bufferValues = new XBetterList<VV>(this.maxbuffersize);
		}

		// Token: 0x170034B9 RID: 13497
		// (get) Token: 0x0600C73F RID: 51007 RVA: 0x002C34D8 File Offset: 0x002C16D8
		public XBetterList<KK> BufferKeys
		{
			get
			{
				return this.m_bufferKeys;
			}
		}

		// Token: 0x170034BA RID: 13498
		// (get) Token: 0x0600C740 RID: 51008 RVA: 0x002C34F0 File Offset: 0x002C16F0
		public XBetterList<VV> BufferValues
		{
			get
			{
				return this.m_bufferValues;
			}
		}

		// Token: 0x170034BB RID: 13499
		public VV this[KK key]
		{
			get
			{
				VV vv;
				bool flag = this.TryGetValue(key, out vv);
				VV result;
				if (flag)
				{
					result = vv;
				}
				else
				{
					result = default(VV);
				}
				return result;
			}
			set
			{
				bool flag = key == null;
				if (!flag)
				{
					bool flag2 = value == null;
					if (flag2)
					{
						this.RemoveKey(key);
					}
					else
					{
						this.Add(key, value);
					}
				}
			}
		}

		// Token: 0x0600C743 RID: 51011 RVA: 0x002C3578 File Offset: 0x002C1778
		public virtual void Add(KK key, VV value)
		{
			int num = this.m_bufferKeys.IndexOf(key);
			bool flag = num >= 0;
			if (flag)
			{
				this.m_bufferKeys[num] = key;
				this.m_bufferValues[num] = value;
			}
			else
			{
				this.m_bufferKeys.Add(key);
				this.m_bufferValues.Add(value);
				this.size++;
			}
		}

		// Token: 0x0600C744 RID: 51012 RVA: 0x002C35EC File Offset: 0x002C17EC
		public bool TryGetKey(VV value, out KK key)
		{
			int num = this.m_bufferValues.IndexOf(value);
			bool flag = num >= 0;
			bool result;
			if (flag)
			{
				key = this.m_bufferKeys[num];
				result = true;
			}
			else
			{
				key = default(KK);
				result = false;
			}
			return result;
		}

		// Token: 0x0600C745 RID: 51013 RVA: 0x002C3638 File Offset: 0x002C1838
		public bool TryGetValue(KK key, out VV value)
		{
			int num = this.m_bufferKeys.IndexOf(key);
			bool flag = num >= 0;
			bool result;
			if (flag)
			{
				value = this.m_bufferValues[num];
				result = true;
			}
			else
			{
				value = default(VV);
				result = false;
			}
			return result;
		}

		// Token: 0x0600C746 RID: 51014 RVA: 0x002C3684 File Offset: 0x002C1884
		public bool ContainsKey(KK key)
		{
			return this.m_bufferKeys.Contains(key);
		}

		// Token: 0x0600C747 RID: 51015 RVA: 0x002C36A4 File Offset: 0x002C18A4
		public bool ContainsValue(VV value)
		{
			return this.m_bufferValues.Contains(value);
		}

		// Token: 0x0600C748 RID: 51016 RVA: 0x002C36C4 File Offset: 0x002C18C4
		public bool RemoveValue(VV value)
		{
			int index = this.m_bufferValues.IndexOf(value);
			return this.RemoveAt(index);
		}

		// Token: 0x0600C749 RID: 51017 RVA: 0x002C36EC File Offset: 0x002C18EC
		public bool RemoveKey(KK key)
		{
			int index = this.m_bufferKeys.IndexOf(key);
			return this.RemoveAt(index);
		}

		// Token: 0x0600C74A RID: 51018 RVA: 0x002C3714 File Offset: 0x002C1914
		public bool RemoveAt(int index)
		{
			bool flag = index >= 0 && index < this.size;
			bool result;
			if (flag)
			{
				this.m_bufferValues.RemoveAt(index);
				this.m_bufferKeys.RemoveAt(index);
				this.size--;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600C74B RID: 51019 RVA: 0x002C3768 File Offset: 0x002C1968
		public virtual void Trim()
		{
			this.m_bufferKeys.Trim();
			this.m_bufferValues.Trim();
		}

		// Token: 0x0600C74C RID: 51020 RVA: 0x002C3784 File Offset: 0x002C1984
		public void Clear()
		{
			this.size = 0;
			bool flag = this.m_bufferKeys != null;
			if (flag)
			{
				this.m_bufferKeys.Clear();
			}
			bool flag2 = this.m_bufferValues != null;
			if (flag2)
			{
				this.m_bufferValues.Clear();
			}
		}

		// Token: 0x0600C74D RID: 51021 RVA: 0x002C37D0 File Offset: 0x002C19D0
		public void Release()
		{
			this.size = 0;
			bool flag = this.m_bufferKeys != null;
			if (flag)
			{
				this.m_bufferKeys.Release();
				this.m_bufferKeys = null;
			}
			bool flag2 = this.m_bufferValues != null;
			if (flag2)
			{
				this.m_bufferValues.Release();
				this.m_bufferValues = null;
			}
		}

		// Token: 0x04005787 RID: 22407
		private XBetterList<KK> m_bufferKeys;

		// Token: 0x04005788 RID: 22408
		private XBetterList<VV> m_bufferValues;

		// Token: 0x04005789 RID: 22409
		private int maxbuffersize = 0;

		// Token: 0x0400578A RID: 22410
		public int size = 0;
	}
}
