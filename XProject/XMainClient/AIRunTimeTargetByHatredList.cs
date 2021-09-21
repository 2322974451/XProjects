using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AEE RID: 2798
	internal class AIRunTimeTargetByHatredList : AIRunTimeNodeAction
	{
		// Token: 0x0600A5D7 RID: 42455 RVA: 0x001CEF00 File Offset: 0x001CD100
		public AIRunTimeTargetByHatredList(XmlElement node) : base(node)
		{
			string attribute = node.GetAttribute("FilterImmortal");
			bool.TryParse(attribute, out this._filter_immortal);
		}

		// Token: 0x0600A5D8 RID: 42456 RVA: 0x001CEF30 File Offset: 0x001CD130
		public override bool Update(XEntity entity)
		{
			return XSingleton<XAITarget>.singleton.FindTargetByHartedList(entity, this._filter_immortal);
		}

		// Token: 0x04003CF7 RID: 15607
		private bool _filter_immortal;
	}
}
