using System;
using System.Xml;

namespace XMainClient
{
	// Token: 0x02000AAB RID: 2731
	internal class AIRunTimeRootNode : AIRunTimeNodeBase
	{
		// Token: 0x0600A53B RID: 42299 RVA: 0x001CBC04 File Offset: 0x001C9E04
		public AIRunTimeRootNode(XmlElement node) : base(node)
		{
			this._child = null;
			this._type = NodeType.NODE_TYPE_ROOT;
			this._shared_data = new SharedData();
		}

		// Token: 0x0600A53C RID: 42300 RVA: 0x001CBC28 File Offset: 0x001C9E28
		public override void AddChild(AIRunTimeNodeBase child)
		{
			this._child = child;
		}

		// Token: 0x0600A53D RID: 42301 RVA: 0x001CBC34 File Offset: 0x001C9E34
		public override bool Update(XEntity entity)
		{
			return this._child.Update(entity);
		}

		// Token: 0x17002FEA RID: 12266
		// (get) Token: 0x0600A53E RID: 42302 RVA: 0x001CBC54 File Offset: 0x001C9E54
		public SharedData Data
		{
			get
			{
				return this._shared_data;
			}
		}

		// Token: 0x04003C64 RID: 15460
		private AIRunTimeNodeBase _child;

		// Token: 0x04003C65 RID: 15461
		private SharedData _shared_data;
	}
}
