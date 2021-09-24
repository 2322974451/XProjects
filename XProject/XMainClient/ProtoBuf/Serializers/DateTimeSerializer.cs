﻿using System;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{

	internal sealed class DateTimeSerializer : IProtoSerializer
	{

		public Type ExpectedType
		{
			get
			{
				return DateTimeSerializer.expectedType;
			}
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

		public DateTimeSerializer(TypeModel model)
		{
		}

		public object Read(object value, ProtoReader source)
		{
			Helpers.DebugAssert(value == null);
			return BclHelpers.ReadDateTime(source);
		}

		public void Write(object value, ProtoWriter dest)
		{
			BclHelpers.WriteDateTime((DateTime)value, dest);
		}

		private static readonly Type expectedType = typeof(DateTime);
	}
}
