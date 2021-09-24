using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class geraint_get_wings
	{

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

		private static bool _once = false;

		private static CommandCallback _activeWingCb = new CommandCallback(geraint_get_wings._ActiveWing);
	}
}
