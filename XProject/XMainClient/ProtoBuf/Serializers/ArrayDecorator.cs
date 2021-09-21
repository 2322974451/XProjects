using System;
using System.Collections;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	// Token: 0x0200085B RID: 2139
	internal sealed class ArrayDecorator : ProtoDecoratorBase
	{
		// Token: 0x06008356 RID: 33622 RVA: 0x000FF07C File Offset: 0x000FD27C
		public ArrayDecorator(TypeModel model, IProtoSerializer tail, int fieldNumber, bool writePacked, WireType packedWireType, Type arrayType, bool overwriteList, bool supportNull) : base(tail)
		{
			Helpers.DebugAssert(arrayType != null, "arrayType should be non-null");
			Helpers.DebugAssert(arrayType.IsArray && arrayType.GetArrayRank() == 1, "should be single-dimension array; " + arrayType.FullName);
			this.itemType = arrayType.GetElementType();
			Type type = supportNull ? this.itemType : (Helpers.GetUnderlyingType(this.itemType) ?? this.itemType);
			Helpers.DebugAssert(type == this.Tail.ExpectedType, "invalid tail");
			Helpers.DebugAssert(this.Tail.ExpectedType != model.MapType(typeof(byte)), "Should have used BlobSerializer");
			bool flag = (writePacked || packedWireType != WireType.None) && fieldNumber <= 0;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("fieldNumber");
			}
			bool flag2 = !ListDecorator.CanPack(packedWireType);
			if (flag2)
			{
				if (writePacked)
				{
					throw new InvalidOperationException("Only simple data-types can use packed encoding");
				}
				packedWireType = WireType.None;
			}
			this.fieldNumber = fieldNumber;
			this.packedWireType = packedWireType;
			if (writePacked)
			{
				this.options |= 1;
			}
			if (overwriteList)
			{
				this.options |= 2;
			}
			if (supportNull)
			{
				this.options |= 4;
			}
			this.arrayType = arrayType;
		}

		// Token: 0x1700296B RID: 10603
		// (get) Token: 0x06008357 RID: 33623 RVA: 0x000FF1E4 File Offset: 0x000FD3E4
		public override Type ExpectedType
		{
			get
			{
				return this.arrayType;
			}
		}

		// Token: 0x1700296C RID: 10604
		// (get) Token: 0x06008358 RID: 33624 RVA: 0x000FF1FC File Offset: 0x000FD3FC
		public override bool RequiresOldValue
		{
			get
			{
				return this.AppendToCollection;
			}
		}

		// Token: 0x1700296D RID: 10605
		// (get) Token: 0x06008359 RID: 33625 RVA: 0x000FF214 File Offset: 0x000FD414
		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700296E RID: 10606
		// (get) Token: 0x0600835A RID: 33626 RVA: 0x000FF228 File Offset: 0x000FD428
		private bool AppendToCollection
		{
			get
			{
				return (this.options & 2) == 0;
			}
		}

		// Token: 0x1700296F RID: 10607
		// (get) Token: 0x0600835B RID: 33627 RVA: 0x000FF248 File Offset: 0x000FD448
		private bool SupportNull
		{
			get
			{
				return (this.options & 4) > 0;
			}
		}

		// Token: 0x0600835C RID: 33628 RVA: 0x000FF268 File Offset: 0x000FD468
		public override void Write(object value, ProtoWriter dest)
		{
			IList list = (IList)value;
			int count = list.Count;
			bool flag = (this.options & 1) > 0;
			bool flag2 = flag;
			SubItemToken token;
			if (flag2)
			{
				ProtoWriter.WriteFieldHeader(this.fieldNumber, WireType.String, dest);
				token = ProtoWriter.StartSubItem(value, dest);
				ProtoWriter.SetPackedField(this.fieldNumber, dest);
			}
			else
			{
				token = default(SubItemToken);
			}
			bool flag3 = !this.SupportNull;
			for (int i = 0; i < count; i++)
			{
				object obj = list[i];
				bool flag4 = flag3 && obj == null;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				this.Tail.Write(obj, dest);
			}
			bool flag5 = flag;
			if (flag5)
			{
				ProtoWriter.EndSubItem(token, dest);
			}
		}

		// Token: 0x0600835D RID: 33629 RVA: 0x000FF330 File Offset: 0x000FD530
		public override object Read(object value, ProtoReader source)
		{
			int field = source.FieldNumber;
			BasicList basicList = new BasicList();
			bool flag = this.packedWireType != WireType.None && source.WireType == WireType.String;
			if (flag)
			{
				SubItemToken token = ProtoReader.StartSubItem(source);
				while (ProtoReader.HasSubValue(this.packedWireType, source))
				{
					basicList.Add(this.Tail.Read(null, source));
				}
				ProtoReader.EndSubItem(token, source);
			}
			else
			{
				do
				{
					basicList.Add(this.Tail.Read(null, source));
				}
				while (source.TryReadFieldHeader(field));
			}
			int num = this.AppendToCollection ? ((value == null) ? 0 : ((Array)value).Length) : 0;
			Array array = Array.CreateInstance(this.itemType, num + basicList.Count);
			bool flag2 = num != 0;
			if (flag2)
			{
				((Array)value).CopyTo(array, 0);
			}
			basicList.CopyTo(array, num);
			return array;
		}

		// Token: 0x040028D2 RID: 10450
		private readonly int fieldNumber;

		// Token: 0x040028D3 RID: 10451
		private const byte OPTIONS_WritePacked = 1;

		// Token: 0x040028D4 RID: 10452
		private const byte OPTIONS_OverwriteList = 2;

		// Token: 0x040028D5 RID: 10453
		private const byte OPTIONS_SupportNull = 4;

		// Token: 0x040028D6 RID: 10454
		private readonly byte options;

		// Token: 0x040028D7 RID: 10455
		private readonly WireType packedWireType;

		// Token: 0x040028D8 RID: 10456
		private readonly Type arrayType;

		// Token: 0x040028D9 RID: 10457
		private readonly Type itemType;
	}
}
