using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class TagDecorator : ProtoDecoratorBase, IProtoTypeSerializer, IProtoSerializer
	{

		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			return protoTypeSerializer != null && protoTypeSerializer.HasCallbacks(callbackType);
		}

		public bool CanCreateInstance()
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			return protoTypeSerializer != null && protoTypeSerializer.CanCreateInstance();
		}

		public object CreateInstance(ProtoReader source)
		{
			return ((IProtoTypeSerializer)this.Tail).CreateInstance(source);
		}

		public void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			bool flag = protoTypeSerializer != null;
			if (flag)
			{
				protoTypeSerializer.Callback(value, callbackType, context);
			}
		}

		public override Type ExpectedType
		{
			get
			{
				return this.Tail.ExpectedType;
			}
		}

		public TagDecorator(int fieldNumber, WireType wireType, bool strict, IProtoSerializer tail) : base(tail)
		{
			this.fieldNumber = fieldNumber;
			this.wireType = wireType;
			this.strict = strict;
		}

		public override bool RequiresOldValue
		{
			get
			{
				return this.Tail.RequiresOldValue;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return this.Tail.ReturnsValue;
			}
		}

		private bool NeedsHint
		{
			get
			{
				return (this.wireType & (WireType)(-8)) > WireType.Variant;
			}
		}

		public override object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(this.fieldNumber == source.FieldNumber);
			bool flag = this.strict;
			if (flag)
			{
				source.Assert(this.wireType);
			}
			else
			{
				bool needsHint = this.NeedsHint;
				if (needsHint)
				{
					source.Hint(this.wireType);
				}
			}
			return this.Tail.Read(value, source);
		}

		public override void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteFieldHeader(this.fieldNumber, this.wireType, dest);
			this.Tail.Write(value, dest);
		}

		private readonly bool strict;

		private readonly int fieldNumber;

		private readonly WireType wireType;
	}
}
