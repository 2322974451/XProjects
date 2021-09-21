using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AAA RID: 2730
	internal class AIRunTimeNodeBase
	{
		// Token: 0x0600A536 RID: 42294 RVA: 0x001CBBC4 File Offset: 0x001C9DC4
		public AIRunTimeNodeBase(XmlElement node)
		{
			this._type = NodeType.NODE_TYPE_BASE;
		}

		// Token: 0x0600A537 RID: 42295 RVA: 0x001CBBD8 File Offset: 0x001C9DD8
		public virtual bool Update(XEntity entity)
		{
			return true;
		}

		// Token: 0x0600A538 RID: 42296 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void AddChild(AIRunTimeNodeBase child)
		{
		}

		// Token: 0x0600A539 RID: 42297 RVA: 0x001CBBEC File Offset: 0x001C9DEC
		public NodeType GetNodeType()
		{
			return this._type;
		}

		// Token: 0x0600A53A RID: 42298 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void Print()
		{
		}

		// Token: 0x04003C63 RID: 15459
		protected NodeType _type;
	}
}
