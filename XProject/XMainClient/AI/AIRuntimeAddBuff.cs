using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeAddBuff : AIRunTimeNodeAction
	{

		public AIRuntimeAddBuff(XmlElement node) : base(node)
		{
			this.BuffId = int.Parse(node.GetAttribute("Shared_BuffIdmValue"));
			this.BuffId2 = int.Parse(node.GetAttribute("Shared_BuffId2mValue"));
			this.BuffIdName = node.GetAttribute("Shared_BuffIdName");
			this.BuffId2Name = node.GetAttribute("Shared_BuffId2Name");
			this.MonsterId = int.Parse(node.GetAttribute("Shared_MonsterIdmValue"));
			this.MonsterIdName = node.GetAttribute("Shared_MonsterIdName");
		}

		public override bool Update(XEntity entity)
		{
			int intByName = entity.AI.AIData.GetIntByName(this.MonsterIdName, this.MonsterId);
			int intByName2 = entity.AI.AIData.GetIntByName(this.BuffIdName, this.BuffId);
			int intByName3 = entity.AI.AIData.GetIntByName(this.BuffId2Name, this.BuffId2);
			return XSingleton<XAIOtherActions>.singleton.AddBuff(intByName, intByName2, intByName3);
		}

		private int BuffId;

		private int BuffId2;

		private string BuffIdName;

		private string BuffId2Name;

		private int MonsterId;

		private string MonsterIdName;
	}
}
