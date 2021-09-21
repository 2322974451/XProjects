using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EDC RID: 3804
	internal class geraint_get_wings
	{
		// Token: 0x0600C97E RID: 51582 RVA: 0x002D3710 File Offset: 0x002D1910
		private static void _ActiveWing(XGameObject gameObject, object o, int commandID)
		{
			Transform transform = gameObject.Find("Object001_wing");
			bool flag = transform != null;
			if (flag)
			{
				bool flag2 = !transform.gameObject.activeSelf;
				if (flag2)
				{
					transform.gameObject.SetActive(true);
				}
			}
		}

		// Token: 0x0600C97F RID: 51583 RVA: 0x002D3758 File Offset: 0x002D1958
		public static bool Do(List<XActor> actors)
		{
			bool flag = actors == null;
			bool result;
			if (flag)
			{
				geraint_get_wings._once = false;
				result = true;
			}
			else
			{
				bool once = geraint_get_wings._once;
				if (once)
				{
					result = false;
				}
				else
				{
					geraint_get_wings._once = true;
					List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
					for (int i = 0; i < ally.Count; i++)
					{
						XEntity xentity = ally[i];
						bool flag2 = xentity.Attributes.TypeID == 3002U;
						if (flag2)
						{
							bool flag3 = xentity.EngineObject != null;
							if (flag3)
							{
								xentity.EngineObject.CallCommand(geraint_get_wings._activeWingCb, null, -1, false);
							}
						}
					}
					bool flag4 = actors[0].EngineObject != null;
					if (flag4)
					{
						actors[0].EngineObject.CallCommand(geraint_get_wings._activeWingCb, null, -1, false);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0400590F RID: 22799
		private static bool _once = false;

		// Token: 0x04005910 RID: 22800
		private static CommandCallback _activeWingCb = new CommandCallback(geraint_get_wings._ActiveWing);
	}
}
