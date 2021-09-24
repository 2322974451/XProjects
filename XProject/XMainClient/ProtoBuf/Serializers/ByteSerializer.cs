using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class ByteSerializer : IProtoSerializer
	{

		public Type ExpectedType
		{
			get
			{
				return ByteSerializer.expectedType;
			}
		}

		public ByteSerializer(TypeModel model)
		{
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return false;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteByte((byte)value, dest);
		}

		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadByte();
		}

		private static readonly Type expectedType = typeof(byte);
	}
}
