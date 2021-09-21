using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AB1 RID: 2737
	internal class AIRunTimeValueHP : AIRunTimeNodeCondition
	{
		// Token: 0x0600A55F RID: 42335 RVA: 0x001CC1F1 File Offset: 0x001CA3F1
		public AIRunTimeValueHP(XmlElement node) : base(node)
		{
			this._max_hp = int.Parse(node.GetAttribute("MaxPercent"));
			this._min_hp = int.Parse(node.GetAttribute("MinPercent"));
		}

		// Token: 0x0600A560 RID: 42336 RVA: 0x001CC228 File Offset: 0x001CA428
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIGeneralMgr>.singleton.IsHPValue(entity.ID, this._min_hp, this._max_hp);
		}

		// Token: 0x04003C70 RID: 15472
		private int _max_hp;

		// Token: 0x04003C71 RID: 15473
		private int _min_hp;
	}
}
