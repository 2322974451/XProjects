using System;
using System.Collections;

namespace ProtoBuf.Meta
{
	// Token: 0x02000885 RID: 2181
	internal class BasicList : IEnumerable
	{
		// Token: 0x06008491 RID: 33937 RVA: 0x00103016 File Offset: 0x00101216
		public void CopyTo(Array array, int offset)
		{
			this.head.CopyTo(array, offset);
		}

		// Token: 0x06008492 RID: 33938 RVA: 0x00103028 File Offset: 0x00101228
		public int Add(object value)
		{
			return (this.head = this.head.Append(value)).Length - 1;
		}

		// Token: 0x170029E8 RID: 10728
		public object this[int index]
		{
			get
			{
				return this.head[index];
			}
		}

		// Token: 0x06008494 RID: 33940 RVA: 0x00103076 File Offset: 0x00101276
		public void Trim()
		{
			this.head = this.head.Trim();
		}

		// Token: 0x170029E9 RID: 10729
		// (get) Token: 0x06008495 RID: 33941 RVA: 0x0010308C File Offset: 0x0010128C
		public int Count
		{
			get
			{
				return this.head.Length;
			}
		}

		// Token: 0x06008496 RID: 33942 RVA: 0x001030AC File Offset: 0x001012AC
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new BasicList.NodeEnumerator(this.head);
		}

		// Token: 0x06008497 RID: 33943 RVA: 0x001030D0 File Offset: 0x001012D0
		public BasicList.NodeEnumerator GetEnumerator()
		{
			return new BasicList.NodeEnumerator(this.head);
		}

		// Token: 0x06008498 RID: 33944 RVA: 0x001030ED File Offset: 0x001012ED
		public void Clear()
		{
			this.head = BasicList.nil;
		}

		// Token: 0x06008499 RID: 33945 RVA: 0x001030FC File Offset: 0x001012FC
		internal int IndexOf(BasicList.MatchPredicate predicate, object ctx)
		{
			return this.head.IndexOf(predicate, ctx);
		}

		// Token: 0x0600849A RID: 33946 RVA: 0x0010311C File Offset: 0x0010131C
		internal int IndexOfString(string value)
		{
			return this.head.IndexOfString(value);
		}

		// Token: 0x0600849B RID: 33947 RVA: 0x0010313C File Offset: 0x0010133C
		internal int IndexOfReference(object instance)
		{
			return this.head.IndexOfReference(instance);
		}

		// Token: 0x0600849C RID: 33948 RVA: 0x0010315C File Offset: 0x0010135C
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

		// Token: 0x0600849D RID: 33949 RVA: 0x0010319C File Offset: 0x0010139C
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

		// Token: 0x04002931 RID: 10545
		private static readonly BasicList.Node nil = new BasicList.Node(null, 0);

		// Token: 0x04002932 RID: 10546
		protected BasicList.Node head = BasicList.nil;

		// Token: 0x02001943 RID: 6467
		public struct NodeEnumerator : IEnumerator
		{
			// Token: 0x06010FB4 RID: 69556 RVA: 0x0045245C File Offset: 0x0045065C
			internal NodeEnumerator(BasicList.Node node)
			{
				this.position = -1;
				this.node = node;
			}

			// Token: 0x06010FB5 RID: 69557 RVA: 0x0045246D File Offset: 0x0045066D
			void IEnumerator.Reset()
			{
				this.position = -1;
			}

			// Token: 0x17003B34 RID: 15156
			// (get) Token: 0x06010FB6 RID: 69558 RVA: 0x00452478 File Offset: 0x00450678
			public object Current
			{
				get
				{
					return this.node[this.position];
				}
			}

			// Token: 0x06010FB7 RID: 69559 RVA: 0x0045249C File Offset: 0x0045069C
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

			// Token: 0x04007D66 RID: 32102
			private int position;

			// Token: 0x04007D67 RID: 32103
			private readonly BasicList.Node node;
		}

		// Token: 0x02001944 RID: 6468
		internal sealed class Node
		{
			// Token: 0x17003B35 RID: 15157
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

			// Token: 0x17003B36 RID: 15158
			// (get) Token: 0x06010FBA RID: 69562 RVA: 0x00452554 File Offset: 0x00450754
			public int Length
			{
				get
				{
					return this.length;
				}
			}

			// Token: 0x06010FBB RID: 69563 RVA: 0x0045256C File Offset: 0x0045076C
			internal Node(object[] data, int length)
			{
				Helpers.DebugAssert((data == null && length == 0) || (data != null && length > 0 && length <= data.Length));
				this.data = data;
				this.length = length;
			}

			// Token: 0x06010FBC RID: 69564 RVA: 0x004525A8 File Offset: 0x004507A8
			public void RemoveLastWithMutate()
			{
				bool flag = this.length == 0;
				if (flag)
				{
					throw new InvalidOperationException();
				}
				this.length--;
			}

			// Token: 0x06010FBD RID: 69565 RVA: 0x004525D8 File Offset: 0x004507D8
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

			// Token: 0x06010FBE RID: 69566 RVA: 0x00452664 File Offset: 0x00450864
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

			// Token: 0x06010FBF RID: 69567 RVA: 0x004526C4 File Offset: 0x004508C4
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

			// Token: 0x06010FC0 RID: 69568 RVA: 0x0045270C File Offset: 0x0045090C
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

			// Token: 0x06010FC1 RID: 69569 RVA: 0x0045274C File Offset: 0x0045094C
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

			// Token: 0x06010FC2 RID: 69570 RVA: 0x00452790 File Offset: 0x00450990
			internal void CopyTo(Array array, int offset)
			{
				bool flag = this.length > 0;
				if (flag)
				{
					Array.Copy(this.data, 0, array, offset, this.length);
				}
			}

			// Token: 0x06010FC3 RID: 69571 RVA: 0x004527C4 File Offset: 0x004509C4
			internal void Clear()
			{
				bool flag = this.data != null;
				if (flag)
				{
					Array.Clear(this.data, 0, this.data.Length);
				}
				this.length = 0;
			}

			// Token: 0x04007D68 RID: 32104
			private readonly object[] data;

			// Token: 0x04007D69 RID: 32105
			private int length;
		}

		// Token: 0x02001945 RID: 6469
		// (Invoke) Token: 0x06010FC5 RID: 69573
		internal delegate bool MatchPredicate(object value, object ctx);

		// Token: 0x02001946 RID: 6470
		internal sealed class Group
		{
			// Token: 0x06010FC8 RID: 69576 RVA: 0x004527FD File Offset: 0x004509FD
			public Group(int first)
			{
				this.First = first;
				this.Items = new BasicList();
			}

			// Token: 0x04007D6A RID: 32106
			public readonly int First;

			// Token: 0x04007D6B RID: 32107
			public readonly BasicList Items;
		}
	}
}
