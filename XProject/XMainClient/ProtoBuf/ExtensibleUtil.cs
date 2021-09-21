using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000843 RID: 2115
	internal static class ExtensibleUtil
	{
		// Token: 0x06008245 RID: 33349 RVA: 0x000F9E26 File Offset: 0x000F8026
		internal static IEnumerable<TValue> GetExtendedValues<TValue>(IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			foreach (object obj in ExtensibleUtil.GetExtendedValues(RuntimeTypeModel.Default, typeof(TValue), instance, tag, format, singleton, allowDefinedTag))
			{
				TValue value = (TValue)((object)obj);
				yield return value;
				value = default(TValue);
			}
			IEnumerator enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06008246 RID: 33350 RVA: 0x000F9E53 File Offset: 0x000F8053
		internal static IEnumerable GetExtendedValues(TypeModel model, Type type, IExtensible instance, int tag, DataFormat format, bool singleton, bool allowDefinedTag)
		{
			bool flag = instance == null;
			if (flag)
			{
				throw new ArgumentNullException("instance");
			}
			bool flag2 = tag <= 0;
			if (flag2)
			{
				throw new ArgumentOutOfRangeException("tag");
			}
			IExtension extn = instance.GetExtensionObject(false);
			bool flag3 = extn == null;
			if (flag3)
			{
				yield break;
			}
			Stream stream = extn.BeginQuery();
			object value = null;
			ProtoReader reader = null;
			try
			{
				SerializationContext ctx = new SerializationContext();
				reader = ProtoReader.Create(stream, model, ctx, -1);
				while (model.TryDeserializeAuxiliaryType(reader, format, tag, type, ref value, true, false, false, false) && value != null)
				{
					bool flag4 = !singleton;
					if (flag4)
					{
						yield return value;
						value = null;
					}
				}
				bool flag5 = singleton && value != null;
				if (flag5)
				{
					yield return value;
				}
				ctx = null;
			}
			finally
			{
				ProtoReader.Recycle(reader);
				extn.EndQuery(stream);
			}
			yield break;
			yield break;
		}

		// Token: 0x06008247 RID: 33351 RVA: 0x000F9E90 File Offset: 0x000F8090
		internal static void AppendExtendValue(TypeModel model, IExtensible instance, int tag, DataFormat format, object value)
		{
			bool flag = instance == null;
			if (flag)
			{
				throw new ArgumentNullException("instance");
			}
			bool flag2 = value == null;
			if (flag2)
			{
				throw new ArgumentNullException("value");
			}
			IExtension extensionObject = instance.GetExtensionObject(true);
			bool flag3 = extensionObject == null;
			if (flag3)
			{
				throw new InvalidOperationException("No extension object available; appended data would be lost.");
			}
			bool commit = false;
			Stream stream = extensionObject.BeginAppend();
			try
			{
				using (ProtoWriter protoWriter = new ProtoWriter(stream, model, null))
				{
					model.TrySerializeAuxiliaryType(protoWriter, null, format, tag, value, false);
					protoWriter.Close();
				}
				commit = true;
			}
			finally
			{
				extensionObject.EndAppend(stream, commit);
			}
		}
	}
}
