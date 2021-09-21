// Decompiled with JetBrains decompiler
// Type: ProtoBuf.Serializers.ListDecorator
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using ProtoBuf.Meta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ProtoBuf.Serializers
{
    internal class ListDecorator : ProtoDecoratorBase
    {
        private readonly byte options;
        private const byte OPTIONS_IsList = 1;
        private const byte OPTIONS_SuppressIList = 2;
        private const byte OPTIONS_WritePacked = 4;
        private const byte OPTIONS_ReturnList = 8;
        private const byte OPTIONS_OverwriteList = 16;
        private const byte OPTIONS_SupportNull = 32;
        private readonly Type declaredType;
        private readonly Type concreteType;
        private readonly MethodInfo add;
        private readonly int fieldNumber;
        protected readonly WireType packedWireType;
        private static readonly Type ienumeratorType = typeof(IEnumerator);
        private static readonly Type ienumerableType = typeof(IEnumerable);

        internal static bool CanPack(WireType wireType)
        {
            switch (wireType)
            {
                case WireType.Variant:
                case WireType.Fixed64:
                case WireType.Fixed32:
                case WireType.SignedVariant:
                    return true;
                default:
                    return false;
            }
        }

        private bool IsList => ((uint)this.options & 1U) > 0U;

        private bool SuppressIList => ((uint)this.options & 2U) > 0U;

        private bool WritePacked => ((uint)this.options & 4U) > 0U;

        private bool SupportNull => ((uint)this.options & 32U) > 0U;

        private bool ReturnList => ((uint)this.options & 8U) > 0U;

        internal static ListDecorator Create(
          TypeModel model,
          Type declaredType,
          Type concreteType,
          IProtoSerializer tail,
          int fieldNumber,
          bool writePacked,
          WireType packedWireType,
          bool returnList,
          bool overwriteList,
          bool supportNull)
        {
            MethodInfo builderFactory;
            MethodInfo add;
            MethodInfo addRange;
            MethodInfo finish;
            return returnList && ImmutableCollectionDecorator.IdentifyImmutable(model, declaredType, out builderFactory, out add, out addRange, out finish) ? (ListDecorator)new ImmutableCollectionDecorator(model, declaredType, concreteType, tail, fieldNumber, writePacked, packedWireType, returnList, overwriteList, supportNull, builderFactory, add, addRange, finish) : new ListDecorator(model, declaredType, concreteType, tail, fieldNumber, writePacked, packedWireType, returnList, overwriteList, supportNull);
        }

        protected ListDecorator(
          TypeModel model,
          Type declaredType,
          Type concreteType,
          IProtoSerializer tail,
          int fieldNumber,
          bool writePacked,
          WireType packedWireType,
          bool returnList,
          bool overwriteList,
          bool supportNull)
          : base(tail)
        {
            if (returnList)
                this.options |= (byte)8;
            if (overwriteList)
                this.options |= (byte)16;
            if (supportNull)
                this.options |= (byte)32;
            if ((writePacked || packedWireType != WireType.None) && fieldNumber <= 0)
                throw new ArgumentOutOfRangeException(nameof(fieldNumber));
            if (!ListDecorator.CanPack(packedWireType))
            {
                if (writePacked)
                    throw new InvalidOperationException("Only simple data-types can use packed encoding");
                packedWireType = WireType.None;
            }
            this.fieldNumber = fieldNumber;
            if (writePacked)
                this.options |= (byte)4;
            this.packedWireType = packedWireType;
            if (declaredType == null)
                throw new ArgumentNullException(nameof(declaredType));
            this.declaredType = !declaredType.IsArray ? declaredType : throw new ArgumentException("Cannot treat arrays as lists", nameof(declaredType));
            this.concreteType = concreteType;
            if (!this.RequireAdd)
                return;
            bool isList;
            this.add = TypeModel.ResolveListAdd(model, declaredType, tail.ExpectedType, out isList);
            if (isList)
            {
                this.options |= (byte)1;
                string fullName = declaredType.FullName;
                if (fullName != null && fullName.StartsWith("System.Data.Linq.EntitySet`1[["))
                    this.options |= (byte)2;
            }
            if (this.add == null)
                throw new InvalidOperationException("Unable to resolve a suitable Add method for " + declaredType.FullName);
        }

        protected virtual bool RequireAdd => true;

        public override Type ExpectedType => this.declaredType;

        public override bool RequiresOldValue => this.AppendToCollection;

        public override bool ReturnsValue => this.ReturnList;

        protected bool AppendToCollection => ((int)this.options & 16) == 0;

        protected MethodInfo GetEnumeratorInfo(
          TypeModel model,
          out MethodInfo moveNext,
          out MethodInfo current)
        {
            Type declaringType = (Type)null;
            Type expectedType1 = this.ExpectedType;
            MethodInfo instanceMethod1 = Helpers.GetInstanceMethod(expectedType1, "GetEnumerator", (Type[])null);
            Type expectedType2 = this.Tail.ExpectedType;
            if (instanceMethod1 != null)
            {
                Type returnType = instanceMethod1.ReturnType;
                moveNext = Helpers.GetInstanceMethod(returnType, "MoveNext", (Type[])null);
                PropertyInfo property = Helpers.GetProperty(returnType, "Current", false);
                current = property == null ? (MethodInfo)null : Helpers.GetGetMethod(property, false, false);
                if (moveNext == null && model.MapType(ListDecorator.ienumeratorType).IsAssignableFrom(returnType))
                    moveNext = Helpers.GetInstanceMethod(model.MapType(ListDecorator.ienumeratorType), "MoveNext", (Type[])null);
                if (moveNext != null && moveNext.ReturnType == model.MapType(typeof(bool)) && current != null && current.ReturnType == expectedType2)
                    return instanceMethod1;
                ref MethodInfo local1 = ref moveNext;
                ref MethodInfo local2 = ref current;
                // ISSUE: variable of the null type
                object local3;
                MethodInfo methodInfo1 = (MethodInfo)(local3 = null);
                MethodInfo methodInfo2 = (MethodInfo)local3;
                local2 = (MethodInfo)local3;
                MethodInfo methodInfo3 = methodInfo2;
                local1 = methodInfo3;
            }
            Type type = model.MapType(typeof(IEnumerable<>), false);
            if (type != null)
                declaringType = type.MakeGenericType(expectedType2);
            if (declaringType != null && declaringType.IsAssignableFrom(expectedType1))
            {
                MethodInfo instanceMethod2 = Helpers.GetInstanceMethod(declaringType, "GetEnumerator");
                Type returnType = instanceMethod2.ReturnType;
                moveNext = Helpers.GetInstanceMethod(model.MapType(ListDecorator.ienumeratorType), "MoveNext");
                current = Helpers.GetGetMethod(Helpers.GetProperty(returnType, "Current", false), false, false);
                return instanceMethod2;
            }
            MethodInfo instanceMethod3 = Helpers.GetInstanceMethod(model.MapType(ListDecorator.ienumerableType), "GetEnumerator");
            Type returnType1 = instanceMethod3.ReturnType;
            moveNext = Helpers.GetInstanceMethod(returnType1, "MoveNext");
            current = Helpers.GetGetMethod(Helpers.GetProperty(returnType1, "Current", false), false, false);
            return instanceMethod3;
        }

        public override void Write(object value, ProtoWriter dest)
        {
            bool writePacked = this.WritePacked;
            SubItemToken token;
            if (writePacked)
            {
                ProtoWriter.WriteFieldHeader(this.fieldNumber, WireType.String, dest);
                token = ProtoWriter.StartSubItem(value, dest);
                ProtoWriter.SetPackedField(this.fieldNumber, dest);
            }
            else
                token = new SubItemToken();
            bool flag = !this.SupportNull;
            foreach (object obj in (IEnumerable)value)
            {
                if (flag && obj == null)
                    throw new NullReferenceException();
                this.Tail.Write(obj, dest);
            }
            if (!writePacked)
                return;
            ProtoWriter.EndSubItem(token, dest);
        }

        public override object Read(object value, ProtoReader source)
        {
            int fieldNumber = source.FieldNumber;
            object obj = value;
            if (value == null)
                value = Activator.CreateInstance(this.concreteType);
            bool flag = this.IsList && !this.SuppressIList;
            if (this.packedWireType != WireType.None && source.WireType == WireType.String)
            {
                SubItemToken token = ProtoReader.StartSubItem(source);
                if (flag)
                {
                    IList list = (IList)value;
                    while (ProtoReader.HasSubValue(this.packedWireType, source))
                        list.Add(this.Tail.Read((object)null, source));
                }
                else
                {
                    while (ProtoReader.HasSubValue(this.packedWireType, source))
                    {
                        ProtoDecoratorBase.s_argsRead[0] = this.Tail.Read((object)null, source);
                        this.add.Invoke(value, ProtoDecoratorBase.s_argsRead);
                    }
                }
                ProtoReader.EndSubItem(token, source);
            }
            else if (flag)
            {
                IList list = (IList)value;
                do
                {
                    list.Add(this.Tail.Read((object)null, source));
                }
                while (source.TryReadFieldHeader(fieldNumber));
            }
            else
            {
                do
                {
                    ProtoDecoratorBase.s_argsRead[0] = this.Tail.Read((object)null, source);
                    this.add.Invoke(value, ProtoDecoratorBase.s_argsRead);
                }
                while (source.TryReadFieldHeader(fieldNumber));
            }
            return obj == value ? (object)null : value;
        }
    }
}
