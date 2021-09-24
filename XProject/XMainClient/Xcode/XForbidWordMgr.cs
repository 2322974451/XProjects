using System;
using System.Collections.Generic;
using System.Text;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XForbidWordMgr : XSingleton<XForbidWordMgr>
	{

		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/ForbidWord", this.m_table, false);
				this._async_loader.Execute(new OnLoadedCallback(this.BuildTree));
			}
			return this._async_loader.IsDone;
		}

		public override void Uninit()
		{
			this.DelTree(this.m_root);
			this._async_loader = null;
		}

		private void BuildTree()
		{
			bool flag = this.m_root != null;
			if (!flag)
			{
				this.m_root = new FWnode();
				for (int i = 0; i < this.m_table.Table.Length; i++)
				{
					this.AddWord(this.m_table.Table[i].forbidword);
				}
			}
		}

		private void AddWord(string word)
		{
			bool flag = this.m_root == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("forbid word build tree error root NULL ", word, null, null, null, null, XDebugColor.XDebug_None);
			}
			else
			{
				FWnode fwnode = this.m_root;
				FWchildNode fwchildNode = null;
				int length = word.Length;
				for (int i = 0; i < length; i++)
				{
					bool flag2 = fwnode == null;
					if (flag2)
					{
						bool flag3 = fwchildNode == null;
						if (flag3)
						{
							XSingleton<XDebug>.singleton.AddLog("forbid word build tree error ptrs NULL ", word, null, null, null, null, XDebugColor.XDebug_None);
							return;
						}
						bool flag4 = fwchildNode.m_child == null;
						if (flag4)
						{
							fwchildNode.m_child = new FWnode();
						}
						fwnode = fwchildNode.m_child;
					}
					bool flag5 = fwnode == null;
					if (flag5)
					{
						XSingleton<XDebug>.singleton.AddLog("forbid word build tree error ptr NULL ", word, null, null, null, null, XDebugColor.XDebug_None);
						return;
					}
					char c = word[i];
					fwchildNode = null;
					bool flag6 = fwnode.m_childs != null;
					if (flag6)
					{
						int count = fwnode.m_childs.Count;
						for (int j = 0; j < count; j++)
						{
							bool flag7 = fwnode.m_childs[j].m_c == c;
							if (flag7)
							{
								fwchildNode = fwnode.m_childs[j];
								break;
							}
						}
					}
					bool flag8 = fwchildNode == null;
					if (flag8)
					{
						FWchildNode fwchildNode2 = new FWchildNode();
						fwchildNode2.m_c = c;
						bool flag9 = fwnode.m_childs == null;
						if (flag9)
						{
							fwnode.m_childs = new List<FWchildNode>();
						}
						fwnode.m_childs.Add(fwchildNode2);
						fwchildNode = fwnode.m_childs[fwnode.m_childs.Count - 1];
					}
					fwnode = null;
				}
				bool flag10 = fwchildNode != null;
				if (flag10)
				{
					fwchildNode.m_onewend = true;
				}
			}
		}

		private void DelTree(FWnode cur)
		{
			bool flag = cur != null;
			if (flag)
			{
				int count = cur.m_childs.Count;
				for (int i = 0; i < count; i++)
				{
					this.DelTree(cur.m_childs[i].m_child);
				}
				cur.m_childs.Clear();
				cur = null;
			}
		}

		public bool HaveForbidWord(string word)
		{
			StringBuilder s = new StringBuilder(word);
			int length = word.Length;
			for (int i = 0; i < length; i++)
			{
				bool flag = this.MatchLength(s, i, length) > 0;
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public string FilterForbidWord(string word)
		{
			StringBuilder stringBuilder = new StringBuilder(word);
			int length = word.Length;
			for (int i = 0; i < length; i++)
			{
				int num = this.MatchLength(stringBuilder, i, length);
				bool flag = num > 0;
				if (flag)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					StringBuilder stringBuilder3 = new StringBuilder();
					for (int j = 0; j < num; j++)
					{
						bool flag2 = i + j < length;
						if (flag2)
						{
							stringBuilder2 = stringBuilder2.Append(stringBuilder[i + j]);
							stringBuilder3.Append("*");
						}
						else
						{
							XSingleton<XDebug>.singleton.AddLog("filter forbid word error = ", word, null, null, null, null, XDebugColor.XDebug_None);
						}
					}
					stringBuilder.Replace(stringBuilder2.ToString(), stringBuilder3.ToString(), i, stringBuilder2.Length);
					i += num - 1;
				}
			}
			return stringBuilder.ToString();
		}

		private int MatchLength(StringBuilder s, int start, int size)
		{
			int result = 0;
			FWnode fwnode = this.m_root;
			for (int i = start; i < size; i++)
			{
				char c = s[i];
				bool flag = fwnode == null;
				if (flag)
				{
					break;
				}
				FWchildNode fwchildNode = null;
				int count = fwnode.m_childs.Count;
				for (int j = 0; j < count; j++)
				{
					bool flag2 = fwnode.m_childs[j].m_c == c;
					if (flag2)
					{
						fwchildNode = fwnode.m_childs[j];
					}
				}
				fwnode = null;
				bool flag3 = fwchildNode != null;
				if (flag3)
				{
					bool onewend = fwchildNode.m_onewend;
					if (onewend)
					{
						result = i - start + 1;
						break;
					}
					fwnode = fwchildNode.m_child;
				}
			}
			return result;
		}

		public string FilterIllegalCode(string word)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(word);
			List<byte> list = new List<byte>(bytes);
			int i = 0;
			while (i < list.Count)
			{
				byte c = list[i];
				int num = this.EncodeLength(c);
				bool flag = num == 0;
				if (flag)
				{
					bool flag2 = !this.IsLegalChar(c);
					if (flag2)
					{
						list.RemoveRange(i, 1);
					}
					else
					{
						i++;
					}
				}
				else
				{
					bool flag3 = i + num > list.Count;
					if (flag3)
					{
						return word;
					}
					byte[] array = new byte[num];
					for (int j = 0; j < num; j++)
					{
						array[j] = list[i + j];
					}
					string @string = Encoding.UTF8.GetString(array);
					bool flag4 = !this.IsLegalChinese(@string);
					if (flag4)
					{
						list.RemoveRange(i, num);
					}
					else
					{
						i += num;
					}
				}
			}
			return Encoding.UTF8.GetString(list.ToArray());
		}

		public int EncodeLength(byte c)
		{
			int num = 0;
			for (int i = 7; i > 0; i--)
			{
				bool flag = (1 << i & (int)c) == 0;
				if (flag)
				{
					break;
				}
				num++;
			}
			return num;
		}

		public bool IsLegalChar(byte c)
		{
			return (48 <= c && c <= 57) || (65 <= c && c <= 90) || (97 <= c && c <= 122);
		}

		public bool IsLegalChinese(string word)
		{
			bool flag = word.Length != 3;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				byte[] bytes = new byte[]
				{
					228,
					184,
					128
				};
				string @string = Encoding.UTF8.GetString(bytes);
				byte[] bytes2 = new byte[]
				{
					233,
					190,
					187
				};
				string string2 = Encoding.UTF8.GetString(bytes2);
				bool flag2 = string.Compare(word, @string) >= 0 && string.Compare(word, string2) <= 0;
				result = flag2;
			}
			return result;
		}

		private FWnode m_root = null;

		private XTableAsyncLoader _async_loader = null;

		private ForbidWord m_table = new ForbidWord();
	}
}
