using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeDetectEnimyInSight : AIRunTimeNodeAction
	{

		public AIRunTimeDetectEnimyInSight(XmlElement node) : base(node)
		{
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIDataRelated>.singleton.DetectEnimyInSight(entity);
		}
	}
}
