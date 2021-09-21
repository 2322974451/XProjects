using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200087B RID: 2171
	internal sealed class TagDecorator : ProtoDecoratorBase, IProtoTypeSerializer, IProtoSerializer
	{
		// Token: 0x0600843A RID: 33850 RVA: 0x00101D54 File Offset: 0x000FFF54
		public bool HasCallbacks(TypeModel.CallbackType callbackType)
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			return protoTypeSerializer != null && protoTypeSerializer.HasCallbacks(callbackType);
		}

		// Token: 0x0600843B RID: 33851 RVA: 0x00101D80 File Offset: 0x000FFF80
		public bool CanCreateInstance()
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			return protoTypeSerializer != null && protoTypeSerializer.CanCreateInstance();
		}

		// Token: 0x0600843C RID: 33852 RVA: 0x00101DAC File Offset: 0x000FFFAC
		public object CreateInstance(ProtoReader source)
		{
			return ((IProtoTypeSerializer)this.Tail).CreateInstance(source);
		}

		// Token: 0x0600843D RID: 33853 RVA: 0x00101DD0 File Offset: 0x000FFFD0
		public void Callback(object value, TypeModel.CallbackType callbackType, SerializationContext context)
		{
			IProtoTypeSerializer protoTypeSerializer = this.Tail as IProtoTypeSerializer;
			bool flag = protoTypeSerializer != null;
			if (flag)
			{
				protoTypeSerializer.Callback(value, callbackType, context);
			}
		}

		// Token: 0x170029CB RID: 10699
		// (get) Token: 0x0600843E RID: 33854 RVA: 0x00101DFC File Offset: 0x000FFFFC
		public override Type ExpectedType
		{
			get
			{
				return this.Tail.ExpectedType;
			}
		}

		// Token: 0x0600843F RID: 33855 RVA: 0x00101E19 File Offset: 0x00100019
		public TagDecorator(int fieldNumber, WireType wireType, bool strict, IProtoSerializer tail) : base(tail)
		{
			this.fieldNumber = fieldNumber;
			this.wireType = wireType;
			this.strict = strict;
		}

		// Token: 0x170029CC RID: 10700
		// (get) Token: 0x06008440 RID: 33856 RVA: 0x00101E3C File Offset: 0x0010003C
		public override bool RequiresOldValue
		{
			get
			{
				return this.Tail.RequiresOldValue;
			}
		}

		// Token: 0x170029CD RID: 10701
		// (get) Token: 0x06008441 RID: 33857 RVA: 0x00101E5C File Offset: 0x0010005C
		public override bool ReturnsValue
		{
			get
			{
				return this.Tail.ReturnsValue;
			}
		}

		// Token: 0x170029CE RID: 10702
		// (get) Token: 0x06008442 RID: 33858 RVA: 0x00101E7C File Offset: 0x0010007C
		private bool NeedsHint
		{
			get
			{
				return (this.wireType & (WireType)(-8)) > WireType.Variant;
			}
		}

		// Token: 0x06008443 RID: 33859 RVA: 0x00101E9C File Offset: 0x0010009C
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

		// Token: 0x06008444 RID: 33860 RVA: 0x00101F03 File Offset: 0x00100103
		public override void Write(object value, ProtoWriter dest)
		{
			ProtoWriter.WriteFieldHeader(this.fieldNumber, this.wireType, dest);
			this.Tail.Write(value, dest);
		}

		// Token: 0x0400291A RID: 10522
		private readonly bool strict;

		// Token: 0x0400291B RID: 10523
		private readonly int fieldNumber;

		// Token: 0x0400291C RID: 10524
		private readonly WireType wireType;
	}
}
