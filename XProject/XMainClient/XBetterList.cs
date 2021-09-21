using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

// Token: 0x02000008 RID: 8
public class XBetterList<T>
{
	// Token: 0x0600001F RID: 31 RVA: 0x00002B9F File Offset: 0x00000D9F
	public XBetterList(int maxSize = 0)
	{
		this.maxbuffersize = maxSize;
		this.AllocateMore();
	}

	// Token: 0x17000006 RID: 6
	public T this[int i]
	{
		get
		{
			return this.buffer[i];
		}
		set
		{
			this.buffer[i] = value;
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002BF8 File Offset: 0x00000DF8
	public int IndexOf(T value)
	{
		for (int i = 0; i < this.size; i++)
		{
			bool flag = this.buffer[i].Equals(value);
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002C4C File Offset: 0x00000E4C
	protected bool AllocateMore()
	{
		bool flag = this.maxbuffersize > 0;
		if (flag)
		{
			bool flag2 = this.buffer == null;
			if (flag2)
			{
				this.buffer = new T[this.maxbuffersize];
			}
			else
			{
				bool flag3 = this.maxbuffersize == this.size;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("buffer is max size!", null, null, null, null, null);
					return false;
				}
			}
		}
		else
		{
			T[] array = (this.buffer != null) ? new T[Mathf.Max(this.buffer.Length << 1, 32)] : new T[32];
			bool flag4 = this.buffer != null && this.size > 0;
			if (flag4)
			{
				this.buffer.CopyTo(array, 0);
			}
			this.buffer = array;
		}
		return true;
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002D1C File Offset: 0x00000F1C
	public virtual void Trim()
	{
		bool flag = this.size > 0;
		if (flag)
		{
			bool flag2 = this.size < this.buffer.Length;
			if (flag2)
			{
				T[] array = new T[this.size];
				for (int i = 0; i < this.size; i++)
				{
					array[i] = this.buffer[i];
				}
				this.buffer = array;
			}
			bool flag3 = this.size > this.maxbuffersize;
			if (flag3)
			{
				this.maxbuffersize = this.size;
			}
		}
		else
		{
			this.buffer = null;
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000025 RID: 37 RVA: 0x00002DB8 File Offset: 0x00000FB8
	public virtual int Count
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002DD0 File Offset: 0x00000FD0
	public virtual void Clear()
	{
		this.size = 0;
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002DDA File Offset: 0x00000FDA
	public virtual void Release()
	{
		this.size = 0;
		this.buffer = null;
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002DEC File Offset: 0x00000FEC
	public virtual void Add(T item)
	{
		bool flag = this.buffer == null || this.size == this.buffer.Length;
		if (flag)
		{
			this.AllocateMore();
		}
		T[] array = this.buffer;
		int num = this.size;
		this.size = num + 1;
		array[num] = item;
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002E40 File Offset: 0x00001040
	public void Insert(int index, T item)
	{
		bool flag = this.buffer == null || this.size == this.buffer.Length;
		if (flag)
		{
			this.AllocateMore();
		}
		bool flag2 = index < this.size;
		if (flag2)
		{
			for (int i = this.size; i > index; i--)
			{
				this.buffer[i] = this.buffer[i - 1];
			}
			this.buffer[index] = item;
			this.size++;
		}
		else
		{
			this.Add(item);
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002ED8 File Offset: 0x000010D8
	public bool Contains(T item)
	{
		bool flag = this.buffer == null;
		bool result;
		if (flag)
		{
			result = false;
		}
		else
		{
			for (int i = 0; i < this.size; i++)
			{
				bool flag2 = this.buffer[i].Equals(item);
				if (flag2)
				{
					return true;
				}
			}
			result = false;
		}
		return result;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002F3C File Offset: 0x0000113C
	public bool Remove(T item)
	{
		bool flag = this.buffer != null;
		if (flag)
		{
			EqualityComparer<T> @default = EqualityComparer<T>.Default;
			T t = default(T);
			for (int i = 0; i < this.size; i++)
			{
				bool flag2 = @default.Equals(this.buffer[i], item);
				if (flag2)
				{
					this.size--;
					this.buffer[i] = t;
					for (int j = i; j < this.size; j++)
					{
						this.buffer[j] = this.buffer[j + 1];
					}
					this.buffer[this.size] = t;
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003014 File Offset: 0x00001214
	public void RemoveAt(int index)
	{
		bool flag = this.buffer != null && index < this.size;
		if (flag)
		{
			this.size--;
			this.buffer[index] = default(T);
			for (int i = index; i < this.size; i++)
			{
				this.buffer[i] = this.buffer[i + 1];
			}
			this.buffer[this.size] = default(T);
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000030A8 File Offset: 0x000012A8
	public T Pop()
	{
		bool flag = this.buffer != null && this.size != 0;
		T result;
		if (flag)
		{
			T[] array = this.buffer;
			int num = this.size - 1;
			this.size = num;
			T t = array[num];
			this.buffer[this.size] = default(T);
			result = t;
		}
		else
		{
			result = default(T);
		}
		return result;
	}

	// Token: 0x04000016 RID: 22
	private int maxbuffersize = 0;

	// Token: 0x04000017 RID: 23
	public T[] buffer;

	// Token: 0x04000018 RID: 24
	public int size = 0;
}
