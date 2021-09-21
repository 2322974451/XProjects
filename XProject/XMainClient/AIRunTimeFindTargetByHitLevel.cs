using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AED RID: 2797
	internal class AIRunTimeFindTargetByHitLevel : AIRunTimeNodeAction
	{
		// Token: 0x0600A5D5 RID: 42453 RVA: 0x001CEEA4 File Offset: 0x001CD0A4
		public AIRunTimeFindTargetByHitLevel(XmlElement node) : base(node)
		{
			string attribute = node.GetAttribute("FilterImmortal");
			int num = 0;
			int.TryParse(attribute, out num);
			this._filter_immortal = (num != 0);
		}

		// Token: 0x0600A5D6 RID: 42454 RVA: 0x001CEEDC File Offset: 0x001CD0DC
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.FindTargetByHitLevel(entity, this._filter_immortal);
		}

		// Token: 0x04003CF6 RID: 15606
		private bool _filter_immortal;
	}
}
