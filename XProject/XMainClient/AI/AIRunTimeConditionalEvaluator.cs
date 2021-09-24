using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeConditionalEvaluator : AIRunTimeDecorationNode
	{

		public string ConditionNodeName
		{
			get
			{
				return this._condition_node_name;
			}
		}

		public AIRunTimeConditionalEvaluator(XmlElement node) : base(node)
		{
			this._condition_node_name = node.GetAttribute("ConditionalTask");
		}

		public bool AddConditionNode(AIRunTimeNodeBase node)
		{
			bool flag = this._condition_node != null;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("ConditionNode already contain condition node", null, null, null, null, null);
				result = false;
			}
			else
			{
				this._condition_node = node;
				result = true;
			}
			return result;
		}

		public override bool Update(XEntity entity)
		{
			bool flag = this._condition_node != null;
			bool result;
			if (flag)
			{
				bool flag2 = !this._condition_node.Update(entity);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this._child_node != null;
					result = (flag3 && this._child_node.Update(entity));
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		private string _condition_node_name;

		private AIRunTimeNodeBase _condition_node;
	}
}
