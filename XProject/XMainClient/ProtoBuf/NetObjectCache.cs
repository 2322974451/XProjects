using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000849 RID: 2121
	internal sealed class NetObjectCache
	{
		// Token: 0x1700293F RID: 10559
		// (get) Token: 0x0600826D RID: 33389 RVA: 0x000FA4D4 File Offset: 0x000F86D4
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

		// Token: 0x0600826E RID: 33390 RVA: 0x000FA504 File Offset: 0x000F8704
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

		// Token: 0x0600826F RID: 33391 RVA: 0x000FA5AC File Offset: 0x000F87AC
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

		// Token: 0x06008270 RID: 33392 RVA: 0x000FA684 File Offset: 0x000F8884
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

		// Token: 0x06008271 RID: 33393 RVA: 0x000FA7B0 File Offset: 0x000F89B0
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

		// Token: 0x06008272 RID: 33394 RVA: 0x000FA838 File Offset: 0x000F8A38
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

		// Token: 0x0400286D RID: 10349
		internal const int Root = 0;

		// Token: 0x0400286E RID: 10350
		private MutableList underlyingList;

		// Token: 0x0400286F RID: 10351
		private object rootObject;

		// Token: 0x04002870 RID: 10352
		private int trapStartIndex;

		// Token: 0x04002871 RID: 10353
		private Dictionary<string, int> stringKeys;

		// Token: 0x04002872 RID: 10354
		private Dictionary<object, int> objectKeys;

		// Token: 0x0200193D RID: 6461
		private sealed class ReferenceComparer : IEqualityComparer<object>
		{
			// Token: 0x06010F9E RID: 69534 RVA: 0x0000311A File Offset: 0x0000131A
			private ReferenceComparer()
			{
			}

			// Token: 0x06010F9F RID: 69535 RVA: 0x0045219C File Offset: 0x0045039C
			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return x == y;
			}

			// Token: 0x06010FA0 RID: 69536 RVA: 0x004521B4 File Offset: 0x004503B4
			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}

			// Token: 0x04007D61 RID: 32097
			public static readonly NetObjectCache.ReferenceComparer Default = new NetObjectCache.ReferenceComparer();
		}
	}
}
