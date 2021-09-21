using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000ABF RID: 2751
	internal class AIRunTimeConditionPlayerNum : AIRunTimeNodeCondition
	{
		// Token: 0x0600A57A RID: 42362 RVA: 0x001CC4B8 File Offset: 0x001CA6B8
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

		// Token: 0x0600A57B RID: 42363 RVA: 0x001CC5EC File Offset: 0x001CA7EC
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

		// Token: 0x04003C76 RID: 15478
		private int _base_prof;

		// Token: 0x04003C77 RID: 15479
		private int _detail_prof;

		// Token: 0x04003C78 RID: 15480
		private string _num_name;

		// Token: 0x04003C79 RID: 15481
		private int _num;

		// Token: 0x04003C7A RID: 15482
		private int _way;

		// Token: 0x04003C7B RID: 15483
		private Vector3 _center;

		// Token: 0x04003C7C RID: 15484
		private float _sqrRadius;
	}
}
