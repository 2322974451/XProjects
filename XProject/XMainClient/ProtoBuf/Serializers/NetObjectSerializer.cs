using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class NetObjectSerializer : IProtoSerializer
	{

		public NetObjectSerializer(TypeModel model, Type type, int key, BclHelpers.NetObjectOptions options)
		{
			bool flag = (options & BclHelpers.NetObjectOptions.DynamicType) > BclHelpers.NetObjectOptions.None;
			this.key = (flag ? -1 : key);
			this.type = (flag ? model.MapType(typeof(object)) : type);
			this.options = options;
		}

		public Type ExpectedType
		{
			get
			{
				return this.type;
			}
		}

		public bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public object Read(object value, ProtoReader source)
		{
			return BclHelpers.ReadNetObject(value, source, this.key, (this.type == typeof(object)) ? null : this.type, this.options);
		}

		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteNetObject(value, dest, this.key, this.options);
		}

		private readonly int key;

		private readonly Type type;

		private readonly BclHelpers.NetObjectOptions options;
	}
}
