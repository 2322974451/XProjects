using System;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000842 RID: 2114
	public abstract class Extensible : IExtensible
	{
		// Token: 0x06008235 RID: 33333 RVA: 0x000F9BE8 File Offset: 0x000F7DE8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return this.GetExtensionObject(createIfMissing);
		}

		// Token: 0x06008236 RID: 33334 RVA: 0x000F9C04 File Offset: 0x000F7E04
		protected virtual IExtension GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x06008237 RID: 33335 RVA: 0x000F9C24 File Offset: 0x000F7E24
		public static IExtension GetExtensionObject(ref IExtension extensionObject, bool createIfMissing)
		{
			bool flag = createIfMissing && extensionObject == null;
			if (flag)
			{
				extensionObject = new BufferExtension();
			}
			return extensionObject;
		}

		// Token: 0x06008238 RID: 33336 RVA: 0x000F9C50 File Offset: 0x000F7E50
		public static void AppendValue<TValue>(IExtensible instance, int tag, TValue value)
		{
			Extensible.AppendValue<TValue>(instance, tag, DataFormat.Default, value);
		}

		// Token: 0x06008239 RID: 33337 RVA: 0x000F9C5D File Offset: 0x000F7E5D
		public static void AppendValue<TValue>(IExtensible instance, int tag, DataFormat format, TValue value)
		{
			ExtensibleUtil.AppendExtendValue(RuntimeTypeModel.Default, instance, tag, format, value);
		}

		// Token: 0x0600823A RID: 33338 RVA: 0x000F9C74 File Offset: 0x000F7E74
		public static TValue GetValue<TValue>(IExtensible instance, int tag)
		{
			return Extensible.GetValue<TValue>(instance, tag, DataFormat.Default);
		}

		// Token: 0x0600823B RID: 33339 RVA: 0x000F9C90 File Offset: 0x000F7E90
		public static TValue GetValue<TValue>(IExtensible instance, int tag, DataFormat format)
		{
			TValue result;
			Extensible.TryGetValue<TValue>(instance, tag, format, out result);
			return result;
		}

		// Token: 0x0600823C RID: 33340 RVA: 0x000F9CB0 File Offset: 0x000F7EB0
		public static bool TryGetValue<TValue>(IExtensible instance, int tag, out TValue value)
		{
			return Extensible.TryGetValue<TValue>(instance, tag, DataFormat.Default, out value);
		}

		// Token: 0x0600823D RID: 33341 RVA: 0x000F9CCC File Offset: 0x000F7ECC
		public static bool TryGetValue<TValue>(IExtensible instance, int tag, DataFormat format, out TValue value)
		{
			return Extensible.TryGetValue<TValue>(instance, tag, format, false, out value);
		}

		// Token: 0x0600823E RID: 33342 RVA: 0x000F9CE8 File Offset: 0x000F7EE8
		public static bool TryGetValue<TValue>(IExtensible instance, int tag, DataFormat format, bool allowDefinedTag, out TValue value)
		{
			value = default(TValue);
			bool result = false;
			foreach (TValue tvalue in ExtensibleUtil.GetExtendedValues<TValue>(instance, tag, format, true, allowDefinedTag))
			{
				value = tvalue;
				result = true;
			}
			return result;
		}

		// Token: 0x0600823F RID: 33343 RVA: 0x000F9D50 File Offset: 0x000F7F50
		public static IEnumerable<TValue> GetValues<TValue>(IExtensible instance, int tag)
		{
			return ExtensibleUtil.GetExtendedValues<TValue>(instance, tag, DataFormat.Default, false, false);
		}

		// Token: 0x06008240 RID: 33344 RVA: 0x000F9D6C File Offset: 0x000F7F6C
		public static IEnumerable<TValue> GetValues<TValue>(IExtensible instance, int tag, DataFormat format)
		{
			return ExtensibleUtil.GetExtendedValues<TValue>(instance, tag, format, false, false);
		}

		// Token: 0x06008241 RID: 33345 RVA: 0x000F9D88 File Offset: 0x000F7F88
		public static bool TryGetValue(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format, bool allowDefinedTag, out object value)
		{
			value = null;
			bool result = false;
			foreach (object obj in ExtensibleUtil.GetExtendedValues(model, type, instance, tag, format, true, allowDefinedTag))
			{
				value = obj;
				result = true;
			}
			return result;
		}

		// Token: 0x06008242 RID: 33346 RVA: 0x000F9DF8 File Offset: 0x000F7FF8
		public static IEnumerable GetValues(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format)
		{
			return ExtensibleUtil.GetExtendedValues(model, type, instance, tag, format, false, false);
		}

		// Token: 0x06008243 RID: 33347 RVA: 0x000F9E17 File Offset: 0x000F8017
		public static void AppendValue(TypeModel model, IExtensible instance, int tag, DataFormat format, object value)
		{
			ExtensibleUtil.AppendExtendValue(model, instance, tag, format, value);
		}

		// Token: 0x04002850 RID: 10320
		private IExtension extensionObject;
	}
}
