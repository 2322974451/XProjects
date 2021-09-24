using System;
using System.Collections;

namespace ProtoBuf.Meta
{

	internal class BasicList : IEnumerable
	{

		public void CopyTo(Array array, int offset)
		{
			this.head.CopyTo(array, offset);
		}

		public int Add(object value)
		{
			return (this.head = this.head.Append(value)).Length - 1;
		}

		public object this[int index]
		{
			get
			{
				return this.head[index];
			}
		}

		public void Trim()
		{
			this.head = this.head.Trim();
		}

		public int Count
		{
			get
			{
				return this.head.Length;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new BasicList.NodeEnumerator(this.head);
		}

		public BasicList.NodeEnumerator GetEnumerator()
		{
			return new BasicList.NodeEnumerator(this.head);
		}

		public void Clear()
		{
			this.head = BasicList.nil;
		}

		internal int IndexOf(BasicList.MatchPredicate predicate, object ctx)
		{
			return this.head.IndexOf(predicate, ctx);
		}

		internal int IndexOfString(string value)
		{
			return this.head.IndexOfString(value);
		}

		internal int IndexOfReference(object instance)
		{
			return this.head.IndexOfReference(instance);
		}

		internal bool Contains(object value)
		{
			foreach (object objA in this)
			{
				bool flag = object.Equals(objA, value);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		internal static BasicList GetContiguousGroups(int[] keys, object[] values)
		{
			bool flag = keys == null;
			if (flag)
			{
				throw new ArgumentNullException("keys");
			}
			bool flag2 = values == null;
			if (flag2)
			{
				throw new ArgumentNullException("values");
			}
			bool flag3 = values.Length < keys.Length;
			if (flag3)
			{
				throw new ArgumentException("Not all keys are covered by values", "values");
			}
			BasicList basicList = new BasicList();
			BasicList.Group group = null;
			for (int i = 0; i < keys.Length; i++)
			{
				bool flag4 = i == 0 || keys[i] != keys[i - 1];
				if (flag4)
				{
					group = null;
				}
				bool flag5 = group == null;
				if (flag5)
				{
					group = new BasicList.Group(keys[i]);
					basicList.Add(group);
				}
				group.Items.Add(values[i]);
			}
			return basicList;
		}

		private static readonly BasicList.Node nil = new BasicList.Node(null, 0);

		protected BasicList.Node head = BasicList.nil;

		public struct NodeEnumerator : IEnumerator
		{

			internal NodeEnumerator(BasicList.Node node)
			{
				this.position = -1;
				this.node = node;
			}

			void IEnumerator.Reset()
			{
				this.position = -1;
			}

			public object Current
			{
				get
				{
					return this.node[this.position];
				}
			}

			public bool MoveNext()
			{
				int length = this.node.Length;
				bool result;
				if (this.position <= length)
				{
					int num = this.position + 1;
					this.position = num;
					result = (num < length);
				}
				else
				{
					result = false;
				}
				return result;
			}

			private int position;

			private readonly BasicList.Node node;
		}

		internal sealed class Node
		{

			public object this[int index]
			{
				get
				{
					bool flag = index >= 0 && index < this.length;
					if (flag)
					{
						return this.data[index];
					}
					throw new ArgumentOutOfRangeException("index");
				}
				set
				{
					bool flag = index >= 0 && index < this.length;
					if (flag)
					{
						this.data[index] = value;
						return;
					}
					throw new ArgumentOutOfRangeException("index");
				}
			}

			public int Length
			{
				get
				{
					return this.length;
				}
			}

			internal Node(object[] data, int length)
			{
				Helpers.DebugAssert((data == null && length == 0) || (data != null && length > 0 && length <= data.Length));
				this.data = data;
				this.length = length;
			}

			public void RemoveLastWithMutate()
			{
				bool flag = this.length == 0;
				if (flag)
				{
					throw new InvalidOperationException();
				}
				this.length--;
			}

			public BasicList.Node Append(object value)
			{
				int num = this.length + 1;
				bool flag = this.data == null;
				object[] array;
				if (flag)
				{
					array = new object[10];
				}
				else
				{
					bool flag2 = this.length == this.data.Length;
					if (flag2)
					{
						array = new object[this.data.Length * 2];
						Array.Copy(this.data, array, this.length);
					}
					else
					{
						array = this.data;
					}
				}
				array[this.length] = value;
				return new BasicList.Node(array, num);
			}

			public BasicList.Node Trim()
			{
				bool flag = this.length == 0 || this.length == this.data.Length;
				BasicList.Node result;
				if (flag)
				{
					result = this;
				}
				else
				{
					object[] destinationArray = new object[this.length];
					Array.Copy(this.data, destinationArray, this.length);
					result = new BasicList.Node(destinationArray, this.length);
				}
				return result;
			}

			internal int IndexOfString(string value)
			{
				for (int i = 0; i < this.length; i++)
				{
					bool flag = value == (string)this.data[i];
					if (flag)
					{
						return i;
					}
				}
				return -1;
			}

			internal int IndexOfReference(object instance)
			{
				for (int i = 0; i < this.length; i++)
				{
					bool flag = instance == this.data[i];
					if (flag)
					{
						return i;
					}
				}
				return -1;
			}

			internal int IndexOf(BasicList.MatchPredicate predicate, object ctx)
			{
				for (int i = 0; i < this.length; i++)
				{
					bool flag = predicate(this.data[i], ctx);
					if (flag)
					{
						return i;
					}
				}
				return -1;
			}

			internal void CopyTo(Array array, int offset)
			{
				bool flag = this.length > 0;
				if (flag)
				{
					Array.Copy(this.data, 0, array, offset, this.length);
				}
			}

			internal void Clear()
			{
				bool flag = this.data != null;
				if (flag)
				{
					Array.Clear(this.data, 0, this.data.Length);
				}
				this.length = 0;
			}

			private readonly object[] data;

			private int length;
		}

		internal delegate bool MatchPredicate(object value, object ctx);

		internal sealed class Group
		{

			public Group(int first)
			{
				this.First = first;
				this.Items = new BasicList();
			}

			public readonly int First;

			public readonly BasicList Items;
		}
	}
}
