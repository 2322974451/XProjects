using System;
using System.Xml;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000AAC RID: 2732
	internal class AIRunTimeEntryTaskNode : AIRunTimeRootNode
	{
		// Token: 0x0600A53F RID: 42303 RVA: 0x001CBC6C File Offset: 0x001C9E6C
		public AIRunTimeEntryTaskNode(XmlElement node) : base(node)
		{
			for (int i = 0; i < node.Attributes.Count; i++)
			{
				bool flag = node.Attributes[i].Name.Length >= 3;
				if (flag)
				{
					string name = node.Attributes[i].Name.Substring(2);
					bool flag2 = node.Attributes[i].Name.StartsWith("F_");
					if (flag2)
					{
						base.Data.SetFloatByName(name, float.Parse(node.Attributes[i].Value));
					}
					else
					{
						bool flag3 = node.Attributes[i].Name.StartsWith("S_");
						if (flag3)
						{
							base.Data.SetStringByName(name, node.Attributes[i].Value);
						}
						else
						{
							bool flag4 = node.Attributes[i].Name.StartsWith("I_");
							if (flag4)
							{
								base.Data.SetIntByName(name, int.Parse(node.Attributes[i].Value));
							}
							else
							{
								bool flag5 = node.Attributes[i].Name.StartsWith("B_");
								if (flag5)
								{
									base.Data.SetBoolByName(name, node.Attributes[i].Value != "0");
								}
								else
								{
									bool flag6 = node.Attributes[i].Name.StartsWith("V_");
									if (flag6)
									{
										string[] array = node.Attributes[i].Value.Split(new char[]
										{
											':'
										});
										base.Data.SetVector3ByName(name, new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2])));
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
