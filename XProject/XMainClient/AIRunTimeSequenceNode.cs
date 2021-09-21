using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC3 RID: 2755
	internal class AIRunTimeSequenceNode : AIRunTimeLogicNode
	{
		// Token: 0x0600A584 RID: 42372 RVA: 0x001CC8CD File Offset: 0x001CAACD
		public AIRunTimeSequenceNode(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A585 RID: 42373 RVA: 0x001CC924 File Offset: 0x001CAB24
		public override bool Update(XEntity entity)
		{
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = !this._list_node[i].Update(entity);
				if (flag)
				{
					return false;
				}
			}
			return true;
		}
	}
}
