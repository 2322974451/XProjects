using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeSelectItemTarget : AIRunTimeNodeAction
	{

		public AIRunTimeSelectItemTarget(XmlElement node) : base(node)
		{
			this._item_target = node.GetAttribute("Shared_ItemTargetName");
		}

		public override bool Update(XEntity entity)
		{
			Transform transform = XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Item);
			bool flag = transform == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				entity.AI.AIData.SetTransformByName(this._item_target, transform);
				result = true;
			}
			return result;
		}

		private string _item_target;
	}
}
