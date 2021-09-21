using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC4 RID: 2756
	internal class AIRunTimeRandomSelectorNode : AIRunTimeLogicNode
	{
		// Token: 0x0600A586 RID: 42374 RVA: 0x001CC970 File Offset: 0x001CAB70
		public AIRunTimeRandomSelectorNode(XmlElement node) : base(node)
		{
			this._random_index = new AIRunTimeRandomIndex();
		}

		// Token: 0x0600A587 RID: 42375 RVA: 0x001CC98D File Offset: 0x001CAB8D
		public override void AddChild(AIRunTimeNodeBase child)
		{
			base.AddChild(child);
			this._random_index.AppendIndex();
		}

		// Token: 0x0600A588 RID: 42376 RVA: 0x001CC9A4 File Offset: 0x001CABA4
		public override bool Update(XEntity entity)
		{
			this._random_index.Rand();
			for (int i = 0; i < this._list_node.Count; i++)
			{
				bool flag = this._list_node[this._random_index[i]].Update(entity);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04003C7F RID: 15487
		protected AIRunTimeRandomIndex _random_index = null;
	}
}
