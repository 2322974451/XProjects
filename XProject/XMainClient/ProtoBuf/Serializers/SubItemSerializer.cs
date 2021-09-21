using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x02000878 RID: 2168
	internal sealed class SubItemSerializer : IProtoTypeSerializer, IProtoSerializer
	{
		// Token: 0x0600841D RID: 33821 RVA: 0x001017B8 File Offset: 0x000FF9B8
		bool IProtoTypeSerializer.HasCallbacks(TypeModel.CallbackType callbackType)
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).HasCallbacks(callbackType);
		}

		// Token: 0x0600841E RID: 33822 RVA: 0x001017E0 File Offset: 0x000FF9E0
		bool IProtoTypeSerializer.CanCreateInstance()
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).CanCreateInstance();
		}

		// Token: 0x0600841F RID: 33823 RVA: 0x00101807 File Offset: 0x000FFA07
		void IProtoTypeSerializer.Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			((IProtoTypeSerializer)this.proxy.Serializer).Callback(value, callbackType, context);
		}

		// Token: 0x06008420 RID: 33824 RVA: 0x00101824 File Offset: 0x000FFA24
		object IProtoTypeSerializer.CreateInstance(ProtoReader source)
		{
			return ((IProtoTypeSerializer)this.proxy.Serializer).CreateInstance(source);
		}

		// Token: 0x06008421 RID: 33825 RVA: 0x0010184C File Offset: 0x000FFA4C
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

		// Token: 0x170029C2 RID: 10690
		// (get) Token: 0x06008422 RID: 33826 RVA: 0x001018A4 File Offset: 0x000FFAA4
		Type IProtoSerializer.ExpectedType
		{
			get
			{
				return this.type;
			}
		}

		// Token: 0x170029C3 RID: 10691
		// (get) Token: 0x06008423 RID: 33827 RVA: 0x001018BC File Offset: 0x000FFABC
		bool IProtoSerializer.RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170029C4 RID: 10692
		// (get) Token: 0x06008424 RID: 33828 RVA: 0x001018D0 File Offset: 0x000FFAD0
		bool IProtoSerializer.ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06008425 RID: 33829 RVA: 0x001018E4 File Offset: 0x000FFAE4
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

		// Token: 0x06008426 RID: 33830 RVA: 0x00101920 File Offset: 0x000FFB20
		object IProtoSerializer.Read(object value, ProtoReader source)
		{
			return ProtoReader.ReadObject(value, this.key, source);
		}

		// Token: 0x04002910 RID: 10512
		private readonly int key;

		// Token: 0x04002911 RID: 10513
		private readonly Type type;

		// Token: 0x04002912 RID: 10514
		private readonly ISerializerProxy proxy;

		// Token: 0x04002913 RID: 10515
		private readonly bool recursionCheck;
	}
}
