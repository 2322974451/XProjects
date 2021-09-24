using System;

namespace XMainClient
{

	internal class XBetterDictionary<KK, VV>
	{

		public XBetterDictionary(int maxSize = 0)
		{
			this.maxbuffersize = maxSize;
			this.m_bufferKeys = new XBetterList<KK>(this.maxbuffersize);
			this.m_bufferValues = new XBetterList<VV>(this.maxbuffersize);
		}

		public XBetterList<KK> BufferKeys
		{
			get
			{
				return this.m_bufferKeys;
			}
		}

		public XBetterList<VV> BufferValues
		{
			get
			{
				return this.m_bufferValues;
			}
		}

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

		public bool ContainsKey(KK key)
		{
			return this.m_bufferKeys.Contains(key);
		}

		public bool ContainsValue(VV value)
		{
			return this.m_bufferValues.Contains(value);
		}

		public bool RemoveValue(VV value)
		{
			int index = this.m_bufferValues.IndexOf(value);
			return this.RemoveAt(index);
		}

		public bool RemoveKey(KK key)
		{
			int index = this.m_bufferKeys.IndexOf(key);
			return this.RemoveAt(index);
		}

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

		public virtual void Trim()
		{
			this.m_bufferKeys.Trim();
			this.m_bufferValues.Trim();
		}

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

		private XBetterList<KK> m_bufferKeys;

		private XBetterList<VV> m_bufferValues;

		private int maxbuffersize = 0;

		public int size = 0;
	}
}
