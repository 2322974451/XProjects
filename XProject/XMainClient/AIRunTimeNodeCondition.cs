using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AAE RID: 2734
	internal class AIRunTimeNodeCondition : AIRunTimeNodeBase
	{
		// Token: 0x0600A559 RID: 42329 RVA: 0x001CC069 File Offset: 0x001CA269
		public AIRunTimeNodeCondition(XmlElement node) : base(node)
		{
			this._type = NodeType.NODE_TYPE_CONDITION;
		}

		// Token: 0x0600A55A RID: 42330 RVA: 0x001CC07C File Offset: 0x001CA27C
		public override bool Update(XEntity entity)
		{
			return true;
		}
	}
}
