using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoBuf.Meta;

namespace ProtoBuf
{

	internal sealed class NetObjectCache
	{

		private MutableList List
		{
			get
			{
				bool flag = this.underlyingList == null;
				if (flag)
				{
					this.underlyingList = new MutableList();
				}
				return this.underlyingList;
			}
		}

		internal object GetKeyedObject(int key)
		{
			bool flag = key-- == 0;
			object result;
			if (flag)
			{
				bool flag2 = this.rootObject == null;
				if (flag2)
				{
					throw new ProtoException("No root object assigned");
				}
				result = this.rootObject;
			}
			else
			{
				BasicList list = this.List;
				bool flag3 = key < 0 || key >= list.Count;
				if (flag3)
				{
					Helpers.DebugWriteLine("Missing key: " + key);
					throw new ProtoException("Internal error; a missing key occurred");
				}
				object obj = list[key];
				bool flag4 = obj == null;
				if (flag4)
				{
					throw new ProtoException("A deferred key does not have a value yet");
				}
				result = obj;
			}
			return result;
		}

		internal void SetKeyedObject(int key, object value)
		{
			bool flag = key-- == 0;
			if (flag)
			{
				bool flag2 = value == null;
				if (flag2)
				{
					throw new ArgumentNullException("value");
				}
				bool flag3 = this.rootObject != null && this.rootObject != value;
				if (flag3)
				{
					throw new ProtoException("The root object cannot be reassigned");
				}
				this.rootObject = value;
			}
			else
			{
				MutableList list = this.List;
				bool flag4 = key < list.Count;
				if (flag4)
				{
					object obj = list[key];
					bool flag5 = obj == null;
					if (flag5)
					{
						list[key] = value;
					}
					else
					{
						bool flag6 = obj != value;
						if (flag6)
						{
							throw new ProtoException("Reference-tracked objects cannot change reference");
						}
					}
				}
				else
				{
					bool flag7 = key != list.Add(value);
					if (flag7)
					{
						throw new ProtoException("Internal error; a key mismatch occurred");
					}
				}
			}
		}

		internal int AddObjectKey(object value, out bool existing)
		{
			bool flag = value == null;
			if (flag)
			{
				throw new ArgumentNullException("value");
			}
			bool flag2 = value == this.rootObject;
			int result;
			if (flag2)
			{
				existing = true;
				result = 0;
			}
			else
			{
				string text = value as string;
				BasicList list = this.List;
				bool flag3 = text == null;
				int num;
				if (flag3)
				{
					bool flag4 = this.objectKeys == null;
					if (flag4)
					{
						this.objectKeys = new Dictionary<object, int>(NetObjectCache.ReferenceComparer.Default);
						num = -1;
					}
					else
					{
						bool flag5 = !this.objectKeys.TryGetValue(value, out num);
						if (flag5)
						{
							num = -1;
						}
					}
				}
				else
				{
					bool flag6 = this.stringKeys == null;
					if (flag6)
					{
						this.stringKeys = new Dictionary<string, int>();
						num = -1;
					}
					else
					{
						bool flag7 = !this.stringKeys.TryGetValue(text, out num);
						if (flag7)
						{
							num = -1;
						}
					}
				}
				bool flag8 = !(existing = (num >= 0));
				if (flag8)
				{
					num = list.Add(value);
					bool flag9 = text == null;
					if (flag9)
					{
						this.objectKeys.Add(value, num);
					}
					else
					{
						this.stringKeys.Add(text, num);
					}
				}
				result = num + 1;
			}
			return result;
		}

		internal void RegisterTrappedObject(object value)
		{
			bool flag = this.rootObject == null;
			if (flag)
			{
				this.rootObject = value;
			}
			else
			{
				bool flag2 = this.underlyingList != null;
				if (flag2)
				{
					for (int i = this.trapStartIndex; i < this.underlyingList.Count; i++)
					{
						this.trapStartIndex = i + 1;
						bool flag3 = this.underlyingList[i] == null;
						if (flag3)
						{
							this.underlyingList[i] = value;
							break;
						}
					}
				}
			}
		}

		internal void Clear()
		{
			this.trapStartIndex = 0;
			this.rootObject = null;
			bool flag = this.underlyingList != null;
			if (flag)
			{
				this.underlyingList.Clear();
			}
			bool flag2 = this.stringKeys != null;
			if (flag2)
			{
				this.stringKeys.Clear();
			}
			bool flag3 = this.objectKeys != null;
			if (flag3)
			{
				this.objectKeys.Clear();
			}
		}

		internal const int Root = 0;

		private MutableList underlyingList;

		private object rootObject;

		private int trapStartIndex;

		private Dictionary<string, int> stringKeys;

		private Dictionary<object, int> objectKeys;

		private sealed class ReferenceComparer : IEqualityComparer<object>
		{

			private ReferenceComparer()
			{
			}

			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return x == y;
			}

			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}

			public static readonly NetObjectCache.ReferenceComparer Default = new NetObjectCache.ReferenceComparer();
		}
	}
}
