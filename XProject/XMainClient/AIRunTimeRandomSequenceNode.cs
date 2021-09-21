using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AC5 RID: 2757
	internal class AIRunTimeRandomSequenceNode : AIRunTimeLogicNode
	{
		// Token: 0x0600A589 RID: 42377 RVA: 0x001CCA04 File Offset: 0x001CAC04
		public AIRunTimeRandomSequenceNode(XmlElement node) : base(node)
		{
			this._random_index = new AIRunTimeRandomIndex();
		}

		// Token: 0x0600A58A RID: 42378 RVA: 0x001CCA21 File Offset: 0x001CAC21
		public override void AddChild(AIRunTimeNodeBase child)
		{
			base.AddChild(child);
			this._random_index.AppendIndex();
		}

		// Token: 0x0600A58B RID: 42379 RVA: 0x001CCA38 File Offset: 0x001CAC38
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

		// Token: 0x04003C80 RID: 15488
		protected AIRunTimeRandomIndex _random_index = null;
	}
}
