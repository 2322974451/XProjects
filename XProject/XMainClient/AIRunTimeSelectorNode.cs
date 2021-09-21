using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC2 RID: 2754
	internal class AIRunTimeSelectorNode : AIRunTimeLogicNode
	{
		// Token: 0x0600A582 RID: 42370 RVA: 0x001CC8CD File Offset: 0x001CAACD
		public AIRunTimeSelectorNode(XmlElement node) : base(node)
		{
		}

		// Token: 0x0600A583 RID: 42371 RVA: 0x001CC8D8 File Offset: 0x001CAAD8
		public override bool Update(XEntity entity)
		{
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = this._list_node[i].Update(entity);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}
	}
}
