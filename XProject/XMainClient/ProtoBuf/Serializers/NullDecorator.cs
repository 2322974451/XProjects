using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class NullDecorator : ProtoDecoratorBase
	{

		public NullDecorator(TypeModel model, IProtoSerializer tail) : base(tail)
		{
			bool flag = !tail.ReturnsValue;
			if (flag)
			{
				throw new NotSupportedException("NullDecorator only supports implementations that return values");
			}
			Type type = tail.ExpectedType;
			bool flag2 = Helpers.IsValueType(type);
			if (flag2)
			{
				this.expectedType = model.MapType(typeof(Nullable<>)).MakeGenericType(new Type[]
				{
					type
				});
			}
			else
			{
				this.expectedType = type;
			}
		}

		public override Type ExpectedType
		{
			get
			{
				return this.expectedType;
			}
		}

		public override bool ReturnsValue
		{
			get
			{
				return true;
			}
		}

		public override bool RequiresOldValue
		{
			get
			{
				return true;
			}
		}

		public override object Read(object value, ProtoReader source)
		{
			SubItemToken token = ProtoReader.StartSubItem(source);
			int num;
			while ((num = source.ReadFieldHeader()) > 0)
			{
				bool flag = num == 1;
				if (flag)
				{
					value = this.Tail.Read(value, source);
				}
				else
				{
					source.SkipField();
				}
			}
			ProtoReader.EndSubItem(token, source);
			return value;
		}

		public override void Write(object value, ProtoWriter dest)
		{
			SubItemToken token = ProtoWriter.StartSubItem(null, dest);
			bool flag = value != null;
			if (flag)
			{
				this.Tail.Write(value, dest);
			}
			ProtoWriter.EndSubItem(token, dest);
		}

		private readonly Type expectedType;

		public const int Tag = 1;
	}
}
