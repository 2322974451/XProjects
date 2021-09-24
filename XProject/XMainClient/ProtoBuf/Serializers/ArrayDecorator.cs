using System;
using System.Collections;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class ArrayDecorator : ProtoDecoratorBase
	{

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

		public override Type ExpectedType
		{
			get
			{
				return this.arrayType;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return this.AppendToCollection;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		private bool AppendToCollection
		{
			get
			{
				return (this.options & 2) == 0;
			}
		}

		private bool SupportNull
		{
			get
			{
				return (this.options & 4) > 0;
			}
		}

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

		private readonly int fieldNumber;

		private const byte OPTIONS_WritePacked = 1;

		private const byte OPTIONS_OverwriteList = 2;

		private const byte OPTIONS_SupportNull = 4;

		private readonly byte options;

		private readonly WireType packedWireType;

		private readonly Type arrayType;

		private readonly Type itemType;
	}
}
