using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeIsQTEState : AIRunTimeNodeCondition
	{

		public AIRunTimeIsQTEState(XmlElement node) : base(node)
		{
			bool flag = node.GetAttribute("QTEState") != "";
			if (flag)
			{
				this._qte_state = int.Parse(node.GetAttribute("QTEState"));
			}
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIGeneralMgr>.singleton.HasQTE(entity.ID, this._qte_state);
		}

		private int _qte_state = 0;
	}
}
