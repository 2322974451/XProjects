using System;
using System.Xml;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000AF4 RID: 2804
	internal class AIRunTimeSelectBuffTarget : AIRunTimeNodeAction
	{
		// Token: 0x0600A5E3 RID: 42467 RVA: 0x001CF04E File Offset: 0x001CD24E
		public AIRunTimeSelectBuffTarget(XmlElement node) : base(node)
		{
			this._buff_target = node.GetAttribute("Shared_BuffTargetName");
		}

		// Token: 0x0600A5E4 RID: 42468 RVA: 0x001CF06C File Offset: 0x001CD26C
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

		// Token: 0x04003CFA RID: 15610
		private string _buff_target;
	}
}
