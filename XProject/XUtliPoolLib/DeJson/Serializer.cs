// Decompiled with JetBrains decompiler
// Type: DeJson.Serializer
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace DeJson
{
    public class Serializer
    {
        private StringBuilder m_builder;
        private bool m_includeTypeInfoForDerivedTypes;
        private bool m_prettyPrint;
        private string m_prefix;

        public static string Serialize(
          object obj,
          bool includeTypeInfoForDerivedTypes = false,
          bool prettyPrint = false)
        {
            Serializer serializer = new Serializer(includeTypeInfoForDerivedTypes, prettyPrint);
            serializer.SerializeValue(obj);
            return serializer.GetJson();
        }

        private Serializer(bool includeTypeInfoForDerivedTypes, bool prettyPrint)
        {
            this.m_builder = new StringBuilder();
            this.m_includeTypeInfoForDerivedTypes = includeTypeInfoForDerivedTypes;
            this.m_prettyPrint = prettyPrint;
            this.m_prefix = "";
        }

        private string GetJson() => this.m_builder.ToString();

        private void Indent()
        {
            if (!this.m_prettyPrint)
                return;
            this.m_prefix += "  ";
        }

        private void Outdent()
        {
            if (!this.m_prettyPrint)
                return;
            this.m_prefix = this.m_prefix.Substring(2);
        }

        private void AddIndent()
        {
            if (!this.m_prettyPrint)
                return;
            this.m_builder.Append(this.m_prefix);
        }

        private void AddLine()
        {
            if (!this.m_prettyPrint)
                return;
            this.m_builder.Append("\n");
        }

        private void AddSpace()
        {
            if (!this.m_prettyPrint)
                return;
            this.m_builder.Append(" ");
        }

        private void SerializeValue(object obj)
        {
            if (obj == null)
            {
                this.m_builder.Append("undefined");
            }
            else
            {
                Type type = obj.GetType();
                if (type.IsArray)
                    this.SerializeArray(obj);
                else if (type == typeof(string))
                    this.SerializeString(obj as string);
                else if (type == typeof(char))
                    this.SerializeString(obj.ToString());
                else if (type == typeof(bool))
                    this.m_builder.Append((bool)obj ? "true" : "false");
                else if (type == typeof(bool))
                {
                    this.m_builder.Append((bool)obj ? "true" : "false");
                    this.m_builder.Append(Convert.ChangeType(obj, typeof(string)));
                }
                else if (type == typeof(int))
                    this.m_builder.Append(obj);
                else if (type == typeof(byte))
                    this.m_builder.Append(obj);
                else if (type == typeof(sbyte))
                    this.m_builder.Append(obj);
                else if (type == typeof(short))
                    this.m_builder.Append(obj);
                else if (type == typeof(ushort))
                    this.m_builder.Append(obj);
                else if (type == typeof(int))
                    this.m_builder.Append(obj);
                else if (type == typeof(uint))
                    this.m_builder.Append(obj);
                else if (type == typeof(long))
                    this.m_builder.Append(obj);
                else if (type == typeof(ulong))
                    this.m_builder.Append(obj);
                else if (type == typeof(float))
                    this.m_builder.Append(((float)obj).ToString("R", (IFormatProvider)CultureInfo.InvariantCulture));
                else if (type == typeof(double))
                    this.m_builder.Append(((double)obj).ToString("R", (IFormatProvider)CultureInfo.InvariantCulture));
                else if (type == typeof(float))
                    this.m_builder.Append(((float)obj).ToString("R", (IFormatProvider)CultureInfo.InvariantCulture));
                else if (type == typeof(double))
                    this.m_builder.Append(((double)obj).ToString("R", (IFormatProvider)CultureInfo.InvariantCulture));
                else if (type.IsValueType)
                {
                    this.SerializeObject(obj);
                }
                else
                {
                    if (!type.IsClass)
                        throw new InvalidOperationException("unsupport type: " + type.Name);
                    this.SerializeObject(obj);
                }
            }
        }

        private void SerializeArray(object obj)
        {
            this.m_builder.Append("[");
            this.AddLine();
            this.Indent();
            Array array = obj as Array;
            bool flag = true;
            foreach (object obj1 in array)
            {
                if (!flag)
                {
                    this.m_builder.Append(",");
                    this.AddLine();
                }
                this.AddIndent();
                this.SerializeValue(obj1);
                flag = false;
            }
            this.AddLine();
            this.Outdent();
            this.AddIndent();
            this.m_builder.Append("]");
        }

        private void SerializeDictionary(IDictionary obj)
        {
            bool flag = true;
            foreach (object key in (IEnumerable)obj.Keys)
            {
                if (!flag)
                {
                    this.m_builder.Append(',');
                    this.AddLine();
                }
                this.AddIndent();
                this.SerializeString(key.ToString());
                this.m_builder.Append(':');
                this.AddSpace();
                this.SerializeValue(obj[key]);
                flag = false;
            }
        }

        private void SerializeObject(object obj)
        {
            this.m_builder.Append("{");
            this.AddLine();
            this.Indent();
            bool flag = true;
            if (this.m_includeTypeInfoForDerivedTypes)
            {
                Type type = obj.GetType();
                Type baseType = type.BaseType;
                if (baseType != null && baseType != typeof(object))
                {
                    this.AddIndent();
                    this.SerializeString("$dotNetType");
                    this.m_builder.Append(":");
                    this.AddSpace();
                    this.SerializeString(type.FullName);
                }
            }
            if (obj is IDictionary dictionary)
            {
                this.SerializeDictionary(dictionary);
            }
            else
            {
                foreach (FieldInfo field in obj.GetType().GetFields())
                {
                    if (!field.IsStatic)
                    {
                        object obj1 = field.GetValue(obj);
                        if (obj1 != null)
                        {
                            if (!flag)
                            {
                                this.m_builder.Append(",");
                                this.AddLine();
                            }
                            this.AddIndent();
                            this.SerializeString(field.Name);
                            this.m_builder.Append(":");
                            this.AddSpace();
                            this.SerializeValue(obj1);
                            flag = false;
                        }
                    }
                }
            }
            this.AddLine();
            this.Outdent();
            this.AddIndent();
            this.m_builder.Append("}");
        }

        private void SerializeString(string str)
        {
            this.m_builder.Append('"');
            foreach (char ch in str.ToCharArray())
            {
                switch (ch)
                {
                    case '\b':
                        this.m_builder.Append("\\b");
                        break;
                    case '\t':
                        this.m_builder.Append("\\t");
                        break;
                    case '\n':
                        this.m_builder.Append("\\n");
                        break;
                    case '\f':
                        this.m_builder.Append("\\f");
                        break;
                    case '\r':
                        this.m_builder.Append("\\r");
                        break;
                    case '"':
                        this.m_builder.Append("\\\"");
                        break;
                    case '\\':
                        this.m_builder.Append("\\\\");
                        break;
                    default:
                        int int32 = Convert.ToInt32(ch);
                        if (int32 >= 32 && int32 <= 126)
                        {
                            this.m_builder.Append(ch);
                            break;
                        }
                        this.m_builder.Append("\\u");
                        this.m_builder.Append(int32.ToString("x4"));
                        break;
                }
            }
            this.m_builder.Append('"');
        }
    }
}
