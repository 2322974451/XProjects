using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	// Token: 0x02000858 RID: 2136
	public static class Serializer
	{
		// Token: 0x06008341 RID: 33601 RVA: 0x000FEC20 File Offset: 0x000FCE20
		public static string GetProto<T>()
		{
			return RuntimeTypeModel.Default.GetSchema(RuntimeTypeModel.Default.MapType(typeof(T)));
		}

		// Token: 0x06008342 RID: 33602 RVA: 0x000FEC50 File Offset: 0x000FCE50
		public static void SetMultiThread(bool multiThread)
		{
			Serializer.useMultiThread = multiThread;
		}

		// Token: 0x06008343 RID: 33603 RVA: 0x000FEC59 File Offset: 0x000FCE59
		public static void SetSkipProtoIgnore(bool skipProtoIgnore)
		{
			Serializer.isSkipProtoIgnore = skipProtoIgnore;
		}

		// Token: 0x06008344 RID: 33604 RVA: 0x000FEC64 File Offset: 0x000FCE64
		public static T DeepClone<T>(T instance)
		{
			bool flag = instance == null;
			T result;
			if (flag)
			{
				result = instance;
			}
			else
			{
				bool flag2 = Serializer.useMultiThread;
				if (flag2)
				{
					RuntimeTypeModel @default = RuntimeTypeModel.Default;
					RuntimeTypeModel obj = @default;
					lock (obj)
					{
						return (T)((object)@default.DeepClone(instance));
					}
				}
				result = (T)((object)RuntimeTypeModel.Default.DeepClone(instance));
			}
			return result;
		}

		// Token: 0x06008345 RID: 33605 RVA: 0x000FECE8 File Offset: 0x000FCEE8
		public static T Merge<T>(Stream source, T instance)
		{
			bool flag = Serializer.useMultiThread;
			if (flag)
			{
				RuntimeTypeModel @default = RuntimeTypeModel.Default;
				RuntimeTypeModel obj = @default;
				lock (obj)
				{
					return (T)((object)@default.Deserialize(source, instance, typeof(T)));
				}
			}
			return (T)((object)RuntimeTypeModel.Default.Deserialize(source, instance, typeof(T)));
		}

		// Token: 0x06008346 RID: 33606 RVA: 0x000FED6C File Offset: 0x000FCF6C
		public static T Deserialize<T>(Stream source)
		{
			bool flag = Serializer.useMultiThread;
			if (flag)
			{
				RuntimeTypeModel @default = RuntimeTypeModel.Default;
				RuntimeTypeModel obj = @default;
				lock (obj)
				{
					return (T)((object)@default.Deserialize(source, null, typeof(T)));
				}
			}
			return (T)((object)RuntimeTypeModel.Default.Deserialize(source, null, typeof(T)));
		}

		// Token: 0x06008347 RID: 33607 RVA: 0x000FEDE8 File Offset: 0x000FCFE8
		public static void Serialize<T>(Stream destination, T instance)
		{
			bool flag = instance != null;
			if (flag)
			{
				bool flag2 = Serializer.useMultiThread;
				if (flag2)
				{
					RuntimeTypeModel @default = RuntimeTypeModel.Default;
					RuntimeTypeModel obj = @default;
					lock (obj)
					{
						@default.Serialize(destination, instance);
					}
				}
				else
				{
					RuntimeTypeModel.Default.Serialize(destination, instance);
				}
			}
		}

		// Token: 0x06008348 RID: 33608 RVA: 0x000FEE60 File Offset: 0x000FD060
		public static void Clear()
		{
			bool flag = Serializer.useMultiThread;
			if (flag)
			{
				RuntimeTypeModel @default = RuntimeTypeModel.Default;
				RuntimeTypeModel obj = @default;
				lock (obj)
				{
					RuntimeTypeModel.Default.Clear();
				}
			}
		}

		// Token: 0x06008349 RID: 33609 RVA: 0x000FEEB0 File Offset: 0x000FD0B0
		public static TTo ChangeType<TFrom, TTo>(TFrom instance)
		{
			TTo result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				Serializer.Serialize<TFrom>(memoryStream, instance);
				memoryStream.Position = 0L;
				result = Serializer.Deserialize<TTo>(memoryStream);
			}
			return result;
		}

		// Token: 0x0600834A RID: 33610 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public static void PrepareSerializer<T>()
		{
		}

		// Token: 0x0600834B RID: 33611 RVA: 0x000FEF00 File Offset: 0x000FD100
		public static IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			return RuntimeTypeModel.Default.DeserializeItems<T>(source, style, fieldNumber);
		}

		// Token: 0x0600834C RID: 33612 RVA: 0x000FEF20 File Offset: 0x000FD120
		public static T DeserializeWithLengthPrefix<T>(Stream source, PrefixStyle style)
		{
			return Serializer.DeserializeWithLengthPrefix<T>(source, style, 0);
		}

		// Token: 0x0600834D RID: 33613 RVA: 0x000FEF3C File Offset: 0x000FD13C
		public static T DeserializeWithLengthPrefix<T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			return (T)((object)@default.DeserializeWithLengthPrefix(source, null, @default.MapType(typeof(T)), style, fieldNumber));
		}

		// Token: 0x0600834E RID: 33614 RVA: 0x000FEF74 File Offset: 0x000FD174
		public static T MergeWithLengthPrefix<T>(Stream source, T instance, PrefixStyle style)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			return (T)((object)@default.DeserializeWithLengthPrefix(source, instance, @default.MapType(typeof(T)), style, 0));
		}

		// Token: 0x0600834F RID: 33615 RVA: 0x000FEFB0 File Offset: 0x000FD1B0
		public static void SerializeWithLengthPrefix<T>(Stream destination, T instance, PrefixStyle style)
		{
			Serializer.SerializeWithLengthPrefix<T>(destination, instance, style, 0);
		}

		// Token: 0x06008350 RID: 33616 RVA: 0x000FEFC0 File Offset: 0x000FD1C0
		public static void SerializeWithLengthPrefix<T>(Stream destination, T instance, PrefixStyle style, int fieldNumber)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			@default.SerializeWithLengthPrefix(destination, instance, @default.MapType(typeof(T)), style, fieldNumber);
		}

		// Token: 0x06008351 RID: 33617 RVA: 0x000FEFF4 File Offset: 0x000FD1F4
		public static bool TryReadLengthPrefix(Stream source, PrefixStyle style, out int length)
		{
			int num;
			int num2;
			length = ProtoReader.ReadLengthPrefix(source, false, style, out num, out num2);
			return num2 > 0;
		}

		// Token: 0x06008352 RID: 33618 RVA: 0x000FF018 File Offset: 0x000FD218
		public static bool TryReadLengthPrefix(byte[] buffer, int index, int count, PrefixStyle style, out int length)
		{
			bool result;
			using (Stream stream = new MemoryStream(buffer, index, count))
			{
				result = Serializer.TryReadLengthPrefix(stream, style, out length);
			}
			return result;
		}

		// Token: 0x06008353 RID: 33619 RVA: 0x000FF058 File Offset: 0x000FD258
		public static void FlushPool()
		{
			BufferPool.Flush();
		}

		// Token: 0x040028C4 RID: 10436
		private static bool useMultiThread = false;

		// Token: 0x040028C5 RID: 10437
		public static bool isSkipProtoIgnore = false;

		// Token: 0x040028C6 RID: 10438
		private const string ProtoBinaryField = "proto";

		// Token: 0x040028C7 RID: 10439
		public const int ListItemTag = 1;

		// Token: 0x0200193E RID: 6462
		public static class NonGeneric
		{
			// Token: 0x06010FA2 RID: 69538 RVA: 0x004521D8 File Offset: 0x004503D8
			public static object DeepClone(object instance)
			{
				return (instance == null) ? null : RuntimeTypeModel.Default.DeepClone(instance);
			}

			// Token: 0x06010FA3 RID: 69539 RVA: 0x004521FC File Offset: 0x004503FC
			public static void Serialize(Stream dest, object instance)
			{
				bool flag = instance != null;
				if (flag)
				{
					RuntimeTypeModel.Default.Serialize(dest, instance);
				}
			}

			// Token: 0x06010FA4 RID: 69540 RVA: 0x00452224 File Offset: 0x00450424
			public static object Deserialize(Type type, Stream source)
			{
				return RuntimeTypeModel.Default.Deserialize(source, null, type);
			}

			// Token: 0x06010FA5 RID: 69541 RVA: 0x00452244 File Offset: 0x00450444
			public static object Merge(Stream source, object instance)
			{
				bool flag = instance == null;
				if (flag)
				{
					throw new ArgumentNullException("instance");
				}
				return RuntimeTypeModel.Default.Deserialize(source, instance, instance.GetType(), null);
			}

			// Token: 0x06010FA6 RID: 69542 RVA: 0x0045227C File Offset: 0x0045047C
			public static void SerializeWithLengthPrefix(Stream destination, object instance, PrefixStyle style, int fieldNumber)
			{
				bool flag = instance == null;
				if (flag)
				{
					throw new ArgumentNullException("instance");
				}
				RuntimeTypeModel @default = RuntimeTypeModel.Default;
				@default.SerializeWithLengthPrefix(destination, instance, @default.MapType(instance.GetType()), style, fieldNumber);
			}

			// Token: 0x06010FA7 RID: 69543 RVA: 0x004522BC File Offset: 0x004504BC
			public static bool TryDeserializeWithLengthPrefix(Stream source, PrefixStyle style, Serializer.TypeResolver resolver, out object value)
			{
				value = RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, null, null, style, 0, resolver);
				return value != null;
			}

			// Token: 0x06010FA8 RID: 69544 RVA: 0x004522E8 File Offset: 0x004504E8
			public static bool CanSerialize(Type type)
			{
				return RuntimeTypeModel.Default.IsDefined(type);
			}
		}

		// Token: 0x0200193F RID: 6463
		public static class GlobalOptions
		{
			// Token: 0x17003B31 RID: 15153
			// (get) Token: 0x06010FA9 RID: 69545 RVA: 0x00452308 File Offset: 0x00450508
			// (set) Token: 0x06010FAA RID: 69546 RVA: 0x00452324 File Offset: 0x00450524
			[Obsolete("Please use RuntimeTypeModel.Default.InferTagFromNameDefault instead (or on a per-model basis)", false)]
			public static bool InferTagFromName
			{
				get
				{
					return RuntimeTypeModel.Default.InferTagFromNameDefault;
				}
				set
				{
					RuntimeTypeModel.Default.InferTagFromNameDefault = value;
				}
			}
		}

		// Token: 0x02001940 RID: 6464
		// (Invoke) Token: 0x06010FAC RID: 69548
		public delegate Type TypeResolver(int fieldNumber);
	}
}
