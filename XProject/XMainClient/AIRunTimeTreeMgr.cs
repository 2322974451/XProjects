using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AFB RID: 2811
	internal class AIRunTimeTreeMgr : XSingleton<AIRunTimeTreeMgr>
	{
		// Token: 0x0600A5F1 RID: 42481 RVA: 0x001CF2E8 File Offset: 0x001CD4E8
		private AIRunTimeRootNode LoadAITree(Stream content, string key)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(content);
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(content);
			XmlElement documentElement = xmlDocument.DocumentElement;
			AIRunTimeRootNode airunTimeRootNode = this.LoadOneNode(documentElement.FirstChild as XmlElement) as AIRunTimeRootNode;
			this._behavior_tree[key] = airunTimeRootNode;
			return airunTimeRootNode;
		}

		// Token: 0x0600A5F2 RID: 42482 RVA: 0x001CF344 File Offset: 0x001CD544
		public AIRunTimeRootNode GetBehavior(string name)
		{
			AIRunTimeRootNode result = null;
			bool flag = !this._behavior_tree.TryGetValue(name, out result);
			if (flag)
			{
				result = this.LoadAITree(XSingleton<XResourceLoaderMgr>.singleton.ReadText("Table/AITree/" + name, ".xml", true), name);
			}
			return result;
		}

		// Token: 0x0600A5F3 RID: 42483 RVA: 0x001CF394 File Offset: 0x001CD594
		private AIRunTimeNodeBase LoadOneNode(XmlElement element)
		{
			bool flag = element == null;
			AIRunTimeNodeBase result;
			if (flag)
			{
				result = null;
			}
			else
			{
				AIRunTimeNodeBase airunTimeNodeBase = AINodeFactory.CreateAINodeByName(element.Name, element);
				bool flag2 = element.Name == "ConditionalEvaluator";
				if (flag2)
				{
					AIRunTimeNodeBase airunTimeNodeBase2 = AINodeFactory.CreateAINodeByName((airunTimeNodeBase as AIRunTimeConditionalEvaluator).ConditionNodeName, element);
					bool flag3 = airunTimeNodeBase2 != null;
					if (flag3)
					{
						(airunTimeNodeBase as AIRunTimeConditionalEvaluator).AddConditionNode(airunTimeNodeBase2);
					}
				}
				for (int i = 0; i < element.ChildNodes.Count; i++)
				{
					AIRunTimeNodeBase airunTimeNodeBase3 = this.LoadOneNode(element.ChildNodes[i] as XmlElement);
					bool flag4 = airunTimeNodeBase3 != null;
					if (flag4)
					{
						airunTimeNodeBase.AddChild(airunTimeNodeBase3);
					}
				}
				result = airunTimeNodeBase;
			}
			return result;
		}

		// Token: 0x04003D01 RID: 15617
		private Dictionary<string, AIRunTimeRootNode> _behavior_tree = new Dictionary<string, AIRunTimeRootNode>();
	}
}
