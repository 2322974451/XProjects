using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AA2 RID: 2722
	internal class AIRuntimeCallScript : AIRunTimeNodeAction
	{
		// Token: 0x0600A509 RID: 42249 RVA: 0x001CB446 File Offset: 0x001C9646
		public AIRuntimeCallScript(XmlElement node) : base(node)
		{
			this.mAIArgDelayTime = float.Parse(node.GetAttribute("DelayTime"));
			this.mAIArgScriptName = node.GetAttribute("FuncName");
		}

		// Token: 0x0600A50A RID: 42250 RVA: 0x001CB478 File Offset: 0x001C9678
		public override bool Update(XEntity entity)
		{
			XSingleton<XAIOtherActions>.singleton.CallScript(this.mAIArgScriptName, this.mAIArgDelayTime);
			return true;
		}

		// Token: 0x04003C52 RID: 15442
		public float mAIArgDelayTime;

		// Token: 0x04003C53 RID: 15443
		public string mAIArgScriptName;
	}
}
