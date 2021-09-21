// Decompiled with JetBrains decompiler
// Type: DeJson.Deserializer
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using MiniJSON;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeJson
{
    public class Deserializer
    {
        private Dictionary<Type, Deserializer.CustomCreator> m_creators;

        public Deserializer() => this.m_creators = new Dictionary<Type, Deserializer.CustomCreator>();

        public T Deserialize<T>(string json) => this.Deserialize<T>(Json.Deserialize(json));

        public T Deserialize<T>(object o) => (T)this.ConvertToType(o, typeof(T), (Dictionary<string, object>)null);

        public void RegisterCreator(Deserializer.CustomCreator creator) => this.m_creators[creator.TypeToCreate()] = creator;

        private object DeserializeO(
          Type destType,
          Dictionary<string, object> src,
          Dictionary<string, object> parentSrc)
        {
            object dest = (object)null;
            if (destType == typeof(Dictionary<string, object>))
                return (object)src;
            Deserializer.CustomCreator customCreator;
            if (this.m_creators.TryGetValue(destType, out customCreator))
                dest = customCreator.Create(src, parentSrc);
            if (dest == null)
            {
                object obj;
                if (src.TryGetValue("$dotNetType", out obj))
                    destType = Type.GetType((string)obj);
                dest = Activator.CreateInstance(destType);
            }
            this.DeserializeIt(dest, src);
            return dest;
        }

        private void DeserializeIt(object dest, Dictionary<string, object> src)
        {
            FieldInfo[] fields = dest.GetType().GetFields();
            this.DeserializeClassFields(dest, fields, src);
        }

        private void DeserializeClassFields(
          object dest,
          FieldInfo[] fields,
          Dictionary<string, object> src)
        {
            foreach (FieldInfo field in fields)
            {
                object obj;
                if (!field.IsStatic && src.TryGetValue(field.Name, out obj))
                    this.DeserializeField(dest, field, obj, src);
            }
        }

        private void DeserializeField(
          object dest,
          FieldInfo info,
          object value,
          Dictionary<string, object> src)
        {
            Type fieldType = info.FieldType;
            object type = this.ConvertToType(value, fieldType, src);
            if (!fieldType.IsAssignableFrom(type.GetType()))
                return;
            info.SetValue(dest, type);
        }

        private object ConvertToType(object value, Type type, Dictionary<string, object> src)
        {
            if (type.IsArray)
                return this.ConvertToArray(value, type, src);
            if (type.IsGenericType)
                return this.ConvertToList(value, type, src);
            if (type == typeof(string))
                return (object)Convert.ToString(value);
            if (type == typeof(byte))
                return (object)Convert.ToByte(value);
            if (type == typeof(sbyte))
                return (object)Convert.ToSByte(value);
            if (type == typeof(short))
                return (object)Convert.ToInt16(value);
            if (type == typeof(ushort))
                return (object)Convert.ToUInt16(value);
            if (type == typeof(int))
                return (object)Convert.ToInt32(value);
            if (type == typeof(uint))
                return (object)Convert.ToUInt32(value);
            if (type == typeof(long))
                return (object)Convert.ToInt64(value);
            if (type == typeof(ulong))
                return (object)Convert.ToUInt64(value);
            if (type == typeof(char))
                return (object)Convert.ToChar(value);
            if (type == typeof(double))
                return (object)Convert.ToDouble(value);
            if (type == typeof(float))
                return (object)Convert.ToSingle(value);
            if (type == typeof(int))
                return (object)Convert.ToInt32(value);
            if (type == typeof(float))
                return (object)Convert.ToSingle(value);
            if (type == typeof(double))
                return (object)Convert.ToDouble(value);
            if (type == typeof(bool))
                return (object)Convert.ToBoolean(value);
            if (type == typeof(bool))
                return (object)Convert.ToBoolean(value);
            if (type.IsValueType)
                return this.DeserializeO(type, (Dictionary<string, object>)value, src);
            return type.IsClass ? this.DeserializeO(type, (Dictionary<string, object>)value, src) : value;
        }

        private object ConvertToArray(object value, Type type, Dictionary<string, object> src)
        {
            List<object> objectList = (List<object>)value;
            int count = objectList.Count;
            Type elementType = type.GetElementType();
            Array instance = Array.CreateInstance(elementType, count);
            int index = 0;
            foreach (object obj in objectList)
            {
                object type1 = this.ConvertToType(obj, elementType, src);
                instance.SetValue(type1, index);
                ++index;
            }
            return (object)instance;
        }

        private object ConvertToList(object value, Type type, Dictionary<string, object> src)
        {
            object instance = Activator.CreateInstance(type);
            MethodInfo method = type.GetMethod("Add");
            List<object> objectList = (List<object>)value;
            Type returnType = type.GetMethod("Find").ReturnType;
            foreach (object obj in objectList)
            {
                object type1 = this.ConvertToType(obj, returnType, src);
                method.Invoke(instance, new object[1] { type1 });
            }
            return instance;
        }

        public abstract class CustomCreator
        {
            public abstract object Create(
              Dictionary<string, object> src,
              Dictionary<string, object> parentSrc);

            public abstract Type TypeToCreate();
        }
    }
}
