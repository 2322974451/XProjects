using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeCallScript : AIRunTimeNodeAction
	{

		public AIRuntimeCallScript(XmlElement node) : base(node)
		{
			this.mAIArgDelayTime = float.Parse(node.GetAttribute("DelayTime"));
			this.mAIArgScriptName = node.GetAttribute("FuncName");
		}

		public override bool Update(XEntity entity)
		{
			XSingleton<XAIOtherActions>.singleton.CallScript(this.mAIArgScriptName, this.mAIArgDelayTime);
			return true;
		}

		public float mAIArgDelayTime;

		public string mAIArgScriptName;
	}
}
