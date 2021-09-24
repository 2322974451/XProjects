using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

public class XBetterList<T>
{

	public XBetterList(int maxSize = 0)
	{
		this.maxbuffersize = maxSize;
		this.AllocateMore();
	}

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

	public virtual int Count
	{
		get
		{
			return this.size;
		}
	}

	public virtual void Clear()
	{
		this.size = 0;
	}

	public virtual void Release()
	{
		this.size = 0;
		this.buffer = null;
	}

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

	private int maxbuffersize = 0;

	public T[] buffer;

	public int size = 0;
}
