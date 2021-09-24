using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf.Meta;

namespace ProtoBuf
{

	public static class Serializer
	{

		public static string GetProto<T>()
		{
			return RuntimeTypeModel.Default.GetSchema(RuntimeTypeModel.Default.MapType(typeof(T)));
		}

		public static void SetMultiThread(bool multiThread)
		{
			Serializer.useMultiThread = multiThread;
		}

		public static void SetSkipProtoIgnore(bool skipProtoIgnore)
		{
			Serializer.isSkipProtoIgnore = skipProtoIgnore;
		}

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

		public static void PrepareSerializer<T>()
		{
		}

		public static IEnumerable<T> DeserializeItems<T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			return RuntimeTypeModel.Default.DeserializeItems<T>(source, style, fieldNumber);
		}

		public static T DeserializeWithLengthPrefix<T>(Stream source, PrefixStyle style)
		{
			return Serializer.DeserializeWithLengthPrefix<T>(source, style, 0);
		}

		public static T DeserializeWithLengthPrefix<T>(Stream source, PrefixStyle style, int fieldNumber)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			return (T)((object)@default.DeserializeWithLengthPrefix(source, null, @default.MapType(typeof(T)), style, fieldNumber));
		}

		public static T MergeWithLengthPrefix<T>(Stream source, T instance, PrefixStyle style)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			return (T)((object)@default.DeserializeWithLengthPrefix(source, instance, @default.MapType(typeof(T)), style, 0));
		}

		public static void SerializeWithLengthPrefix<T>(Stream destination, T instance, PrefixStyle style)
		{
			Serializer.SerializeWithLengthPrefix<T>(destination, instance, style, 0);
		}

		public static void SerializeWithLengthPrefix<T>(Stream destination, T instance, PrefixStyle style, int fieldNumber)
		{
			RuntimeTypeModel @default = RuntimeTypeModel.Default;
			@default.SerializeWithLengthPrefix(destination, instance, @default.MapType(typeof(T)), style, fieldNumber);
		}

		public static bool TryReadLengthPrefix(Stream source, PrefixStyle style, out int length)
		{
			int num;
			int num2;
			length = ProtoReader.ReadLengthPrefix(source, false, style, out num, out num2);
			return num2 > 0;
		}

		public static bool TryReadLengthPrefix(byte[] buffer, int index, int count, PrefixStyle style, out int length)
		{
			bool result;
			using (Stream stream = new MemoryStream(buffer, index, count))
			{
				result = Serializer.TryReadLengthPrefix(stream, style, out length);
			}
			return result;
		}

		public static void FlushPool()
		{
			BufferPool.Flush();
		}

		private static bool useMultiThread = false;

		public static bool isSkipProtoIgnore = false;

		private const string ProtoBinaryField = "proto";

		public const int ListItemTag = 1;

		public static class NonGeneric
		{

			public static object DeepClone(object instance)
			{
				return (instance == null) ? null : RuntimeTypeModel.Default.DeepClone(instance);
			}

			public static void Serialize(Stream dest, object instance)
			{
				bool flag = instance != null;
				if (flag)
				{
					RuntimeTypeModel.Default.Serialize(dest, instance);
				}
			}

			public static object Deserialize(Type type, Stream source)
			{
				return RuntimeTypeModel.Default.Deserialize(source, null, type);
			}

			public static object Merge(Stream source, object instance)
			{
				bool flag = instance == null;
				if (flag)
				{
					throw new ArgumentNullException("instance");
				}
				return RuntimeTypeModel.Default.Deserialize(source, instance, instance.GetType(), null);
			}

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

			public static bool TryDeserializeWithLengthPrefix(Stream source, PrefixStyle style, Serializer.TypeResolver resolver, out object value)
			{
				value = RuntimeTypeModel.Default.DeserializeWithLengthPrefix(source, null, null, style, 0, resolver);
				return value != null;
			}

			public static bool CanSerialize(Type type)
			{
				return RuntimeTypeModel.Default.IsDefined(type);
			}
		}

		public static class GlobalOptions
		{

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

		public delegate Type TypeResolver(int fieldNumber);
	}
}
