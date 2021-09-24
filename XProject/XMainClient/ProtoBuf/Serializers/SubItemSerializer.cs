using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class SubItemSerializer : IProtoTypeSerializer, IProtoSerializer
	{

		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).HasCallbacks(callbackType);
		}

		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).CanCreateInstance();
		}

		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			((IProtoTypeSerializer)this.proxy.Serializer).Callback(value, callbackType, context);
		}

		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).CreateInstance(source);
		}

		public SubItemSerializer(Type type, int key, ISerializerProxy proxy, bool recursionCheck)
		{
			bool flag = type == null;
			if (flag)
			{
				throw new ArgumentNullException("type");
			}
			bool flag2 = proxy == null;
			if (flag2)
			{
				throw new ArgumentNullException("proxy");
			}
			this.type = type;
			this.proxy = proxy;
			this.key = key;
			this.recursionCheck = recursionCheck;
		}

		Type IProtoSerializer.ExpectedType
		{
			get
			{
				return this.type;
			}
		}

		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		void IProtoSerializer.Write(object value, ProtoWriter dest)
		{
			bool flag = this.recursionCheck;
			if (flag)
			{
				ProtoWriter.WriteObject(value, this.key, dest);
			}
			else
			{
				ProtoWriter.WriteRecursionSafeObject(value, this.key, dest);
			}
		}

		object IProtoSerializer.Read(object value, ProtoReader source)
		{
			return ProtoReader.ReadObject(value, this.key, source);
		}

		private readonly int key;

		private readonly Type type;

		private readonly ISerializerProxy proxy;

		private readonly bool recursionCheck;
	}
}
