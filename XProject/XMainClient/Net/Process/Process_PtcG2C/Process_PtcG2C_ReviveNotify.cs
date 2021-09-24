using System;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ReviveNotify
	{

		public static void Process(PtcG2C_ReviveNotify roPtc)
		{
			XEntity entityConsiderDeath = XSingleton<XEntityMgr>.singleton.GetEntityConsiderDeath(roPtc.Data.roleID);
			bool flag = entityConsiderDeath == null;
			if (!flag)
			{
				bool isPlayer = entityConsiderDeath.IsPlayer;
				if (isPlayer)
				{
					XPlayer xplayer = entityConsiderDeath as XPlayer;
					xplayer.Revive();
				}
				else
				{
					XRole xrole = entityConsiderDeath as XRole;
					xrole.Revive();
				}
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("Revive type: {0}", roPtc.Data.type.ToString()), null, null, null, null, null);
				bool flag2 = roPtc.Data.type == ReviveType.ReviveSprite;
				if (flag2)
				{
					XAffiliate xaffiliate = null;
					bool flag3 = entityConsiderDeath.Equipment != null;
					if (flag3)
					{
						xaffiliate = entityConsiderDeath.Equipment.Sprite;
					}
					bool flag4 = xaffiliate != null;
					if (flag4)
					{
						string value = XSingleton<XGlobalConfig>.singleton.GetValue("SpriteReviveFx");
						XSingleton<XFxMgr>.singleton.CreateAndPlay(value, xaffiliate.EngineObject, Vector3.zero, Vector3.one, 1f, true, 5f, true);
					}
				}
			}
		}
	}
}
