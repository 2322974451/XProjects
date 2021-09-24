using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class SingleSerializer : IProtoSerializer
	{

		public Type ExpectedType
		{
			get
			{
				return SingleSerializer.expectedType;
			}
		}

		public SingleSerializer(TypeModel model)
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

		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return source.ReadSingle();
		}

		public void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteSingle((float)value, dest);
		}

		private static readonly Type expectedType = typeof(float);
	}
}
