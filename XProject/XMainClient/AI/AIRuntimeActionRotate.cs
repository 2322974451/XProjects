using System;
using System.Xml;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRuntimeActionRotate : AIRunTimeNodeAction
	{

		public AIRuntimeActionRotate(XmlElement node) : base(node)
		{
			this._rot_degree = float.Parse(node.GetAttribute("RotDegree"));
			this._rot_speed = float.Parse(node.GetAttribute("RotSpeed"));
			this._rot_type = int.Parse(node.GetAttribute("RotType"));
		}

		public override bool Update(XEntity entity)
		{
			return XSingleton<XAIMove>.singleton.ActionRotate(entity, this._rot_degree, this._rot_speed, this._rot_type);
		}

		public float _rot_degree;

		public float _rot_speed;

		public int _rot_type;
	}
}
