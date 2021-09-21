using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ACA RID: 2762
	internal class AIRunTimeConditionalEvaluator : AIRunTimeDecorationNode
	{
		// Token: 0x17002FF0 RID: 12272
		// (get) Token: 0x0600A594 RID: 42388 RVA: 0x001CCB5C File Offset: 0x001CAD5C
		public string ConditionNodeName
		{
			get
			{
				return this._condition_node_name;
			}
		}

		// Token: 0x0600A595 RID: 42389 RVA: 0x001CCB74 File Offset: 0x001CAD74
		public AIRunTimeConditionalEvaluator(XmlElement node) : base(node)
		{
			this._condition_node_name = node.GetAttribute("ConditionalTask");
		}

		// Token: 0x0600A596 RID: 42390 RVA: 0x001CCB90 File Offset: 0x001CAD90
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

		// Token: 0x0600A597 RID: 42391 RVA: 0x001CCBD4 File Offset: 0x001CADD4
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

		// Token: 0x04003C82 RID: 15490
		private string _condition_node_name;

		// Token: 0x04003C83 RID: 15491
		private AIRunTimeNodeBase _condition_node;
	}
}
