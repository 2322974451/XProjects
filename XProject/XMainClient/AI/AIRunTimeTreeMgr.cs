using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeTreeMgr : XSingleton<AIRunTimeTreeMgr>
	{

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

		private Dictionary<string, AIRunTimeRootNode> _behavior_tree = new Dictionary<string, AIRunTimeRootNode>();
	}
}
