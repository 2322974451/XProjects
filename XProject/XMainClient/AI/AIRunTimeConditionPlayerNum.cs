using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AIRunTimeConditionPlayerNum : AIRunTimeNodeCondition
	{

		public AIRunTimeConditionPlayerNum(XmlElement node) : base(node)
		{
			this._base_prof = int.Parse(node.GetAttribute("PlayerBaseProf"));
			this._detail_prof = int.Parse(node.GetAttribute("PlayerDetailProf"));
			this._num_name = node.GetAttribute("Shared_NumName");
			this._num = int.Parse(node.GetAttribute("Shared_NummValue"));
			string attribute = node.GetAttribute("Way");
			bool flag = string.IsNullOrEmpty(attribute);
			if (flag)
			{
				this._way = 0;
			}
			else
			{
				this._way = int.Parse(attribute);
			}
			attribute = node.GetAttribute("Center");
			bool flag2 = string.IsNullOrEmpty(attribute);
			if (flag2)
			{
				this._center = Vector3.zero;
			}
			else
			{
				string[] array = attribute.Split(new char[]
				{
					':'
				});
				this._center = new Vector3(float.Parse(array[0]), float.Parse(array[1]), float.Parse(array[2]));
			}
			attribute = node.GetAttribute("Radius");
			bool flag3 = string.IsNullOrEmpty(attribute);
			if (flag3)
			{
				this._sqrRadius = 0f;
			}
			else
			{
				this._sqrRadius = float.Parse(attribute);
				this._sqrRadius *= this._sqrRadius;
			}
		}

		public override bool Update(XEntity entity)
		{
			int playerProf = XSingleton<XAIGeneralMgr>.singleton.GetPlayerProf();
			entity.AI.AIData.SetIntByName(this._num_name, 0);
			bool flag = this._base_prof != 0 || this._detail_prof != 0;
			if (flag)
			{
				bool flag2 = this._base_prof != 0 && playerProf % 10 != this._base_prof;
				if (flag2)
				{
					return true;
				}
				bool flag3 = this._detail_prof != 0 && playerProf != this._detail_prof;
				if (flag3)
				{
					return true;
				}
			}
			bool flag4 = this._way != 0;
			if (flag4)
			{
				bool flag5 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (flag5)
				{
					return true;
				}
				bool flag6 = this._way == 1 && XSingleton<XEntityMgr>.singleton.Player.IsDead;
				if (flag6)
				{
					return true;
				}
				bool flag7 = this._way == 2 && !XSingleton<XEntityMgr>.singleton.Player.IsDead;
				if (flag7)
				{
					return true;
				}
			}
			bool flag8 = this._sqrRadius > 0f;
			if (flag8)
			{
				bool flag9 = XSingleton<XEntityMgr>.singleton.Player == null;
				if (flag9)
				{
					return true;
				}
				float sqrMagnitude = (XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position - this._center).sqrMagnitude;
				bool flag10 = sqrMagnitude > this._sqrRadius;
				if (flag10)
				{
					return true;
				}
			}
			entity.AI.AIData.SetIntByName(this._num_name, 1);
			return true;
		}

		private int _base_prof;

		private int _detail_prof;

		private string _num_name;

		private int _num;

		private int _way;

		private Vector3 _center;

		private float _sqrRadius;
	}
}
