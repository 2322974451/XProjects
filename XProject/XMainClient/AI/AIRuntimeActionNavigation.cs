using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeActionNavigation : AIRunTimeNodeAction
	{

		public AIRuntimeActionNavigation(XmlElement node) : base(node)
		{
			this._move_dir_name = node.GetAttribute("Shared_MoveDirName");
		}

		public override bool Update(XEntity entity)
		{
			int old_move_dir = this._old_move_dir;
			this._old_move_dir = entity.AI.AIData.GetIntByName(this._move_dir_name, 1);
			return XSingleton<XAIMove>.singleton.UpdateNavigation(entity, this._old_move_dir, old_move_dir);
		}

		public string _move_dir_name;

		private int _old_move_dir = 1;
	}
}
