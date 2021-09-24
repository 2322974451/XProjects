using System;
using System.Collections.Generic;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSyncDebug
	{

		public static void OnLeaveScene()
		{
			bool flag = XSyncDebug._map != null;
			if (flag)
			{
				XSyncDebug._map.Clear();
			}
		}

		public static void DrawDebug(ulong id, Vector3 pos, Quaternion face)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
			bool flag = entity != null;
			if (flag)
			{
				bool flag2 = XSyncDebug._map == null;
				if (flag2)
				{
					XSyncDebug._map = new Dictionary<ulong, XFx>();
				}
				XFx xfx = null;
				bool flag3 = XSyncDebug._map.TryGetValue(id, out xfx);
				if (flag3)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(xfx, true);
				}
				bool flag4 = xfx == null;
				if (flag4)
				{
					XSyncDebug._map.Add(id, null);
				}
				xfx = XSingleton<XFxMgr>.singleton.CreateFx("Effects/FX_Particle/Roles/Lzg_Ty/sync_debug_fx", null, false);
				pos.y += entity.Height * 0.5f;
				xfx.Play(pos, face, entity.Radius * 2f * Vector3.one, 1f);
				XSyncDebug._map[id] = xfx;
			}
		}

		private static Dictionary<ulong, XFx> _map = null;
	}
}
