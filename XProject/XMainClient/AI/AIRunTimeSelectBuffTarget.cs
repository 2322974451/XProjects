using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeSelectBuffTarget : AIRunTimeNodeAction
	{

		public AIRunTimeSelectBuffTarget(XmlElement node) : base(node)
		{
			this._buff_target = node.GetAttribute("Shared_BuffTargetName");
		}

		public override bool Update(XEntity entity)
		{
			Transform transform = XSingleton<XAITarget>.singleton.SelectDoodaTarget(entity, XDoodadType.Buff);
			bool flag = transform == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				entity.AI.AIData.SetTransformByName(this._buff_target, transform);
				result = true;
			}
			return result;
		}

		private string _buff_target;
	}
}
