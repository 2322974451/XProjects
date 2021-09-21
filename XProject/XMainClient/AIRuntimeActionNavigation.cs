using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AD2 RID: 2770
	internal class AIRuntimeActionNavigation : AIRunTimeNodeAction
	{
		// Token: 0x0600A5A2 RID: 42402 RVA: 0x001CD4ED File Offset: 0x001CB6ED
		public AIRuntimeActionNavigation(XmlElement node) : base(node)
		{
			this._move_dir_name = node.GetAttribute("Shared_MoveDirName");
		}

		// Token: 0x0600A5A3 RID: 42403 RVA: 0x001CD510 File Offset: 0x001CB710
		public override bool Update(XEntity entity)
		{
			int old_move_dir = this._old_move_dir;
			this._old_move_dir = entity.AI.AIData.GetIntByName(this._move_dir_name, 1);
			return XSingleton<XAIMove>.singleton.UpdateNavigation(entity, this._old_move_dir, old_move_dir);
		}

		// Token: 0x04003CA2 RID: 15522
		public string _move_dir_name;

		// Token: 0x04003CA3 RID: 15523
		private int _old_move_dir = 1;
	}
}
