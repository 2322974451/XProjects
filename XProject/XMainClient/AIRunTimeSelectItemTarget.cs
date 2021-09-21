using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF5 RID: 2805
	internal class AIRunTimeSelectItemTarget : AIRunTimeNodeAction
	{
		// Token: 0x0600A5E5 RID: 42469 RVA: 0x001CF0B4 File Offset: 0x001CD2B4
		public AIRunTimeSelectItemTarget(XmlElement node) : base(node)
		{
			this._item_target = node.GetAttribute("Shared_ItemTargetName");
		}

		// Token: 0x0600A5E6 RID: 42470 RVA: 0x001CF0D0 File Offset: 0x001CD2D0
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

		// Token: 0x04003CFB RID: 15611
		private string _item_target;
	}
}
