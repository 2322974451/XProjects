using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCombatHUDMgr : XSingleton<XCombatHUDMgr>
	{

		public bool Initialize()
		{
			return true;
		}

		public GameObject GetHUDTemplateByDamageResult(ProjectDamageResult config, bool isPlayer)
		{
			bool flag = config.Result == ProjectResultType.PJRES_IMMORTAL;
			GameObject result;
			if (flag)
			{
				GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCombatHUDMgr.HUD_IMMORTAL, Vector3.zero, Quaternion.identity, true, false);
				result = gameObject;
			}
			else
			{
				bool flag2 = config.Result == ProjectResultType.PJRES_MISS;
				if (flag2)
				{
					GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCombatHUDMgr.HUD_MISS, Vector3.zero, Quaternion.identity, true, false);
					result = gameObject;
				}
				else if (isPlayer)
				{
					GameObject gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCombatHUDMgr.HUD_PLAYER, Vector3.zero, Quaternion.identity, true, false);
					result = gameObject;
				}
				else
				{
					bool flag3 = config.IsCritical();
					GameObject gameObject;
					if (flag3)
					{
						gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCombatHUDMgr.HUD_CRITICAL, Vector3.zero, Quaternion.identity, true, false);
					}
					else
					{
						gameObject = XSingleton<XResourceLoaderMgr>.singleton.CreateFromPrefab(XCombatHUDMgr.HUD_NORMAL, Vector3.zero, Quaternion.identity, true, false);
					}
					result = gameObject;
				}
			}
			return result;
		}

		public string GetHUDText(ProjectDamageResult config, bool isDigitalText)
		{
			string text = "";
			bool flag = config.Result == ProjectResultType.PJRES_IMMORTAL;
			string result;
			if (flag)
			{
				result = XStringDefineProxy.GetString("BATTLE_IMMORTAL");
			}
			else
			{
				bool accept = config.Accept;
				if (accept)
				{
					string elementSprite = this.GetElementSprite(config.ElementType);
					text = elementSprite;
					float num = (float)config.Value;
					text += ((num > 0f) ? Mathf.RoundToInt(num).ToString() : Mathf.RoundToInt(-num).ToString());
				}
				result = text;
			}
			return result;
		}

		public string GetElementSprite(DamageElement element)
		{
			string result;
			switch (element)
			{
			case DamageElement.DE_FIRE:
				result = "c";
				break;
			case DamageElement.DE_WATER:
				result = "b";
				break;
			case DamageElement.DE_LIGHT:
				result = "a";
				break;
			case DamageElement.DE_DARK:
				result = "d";
				break;
			default:
				result = "";
				break;
			}
			return result;
		}

		public void GetElementColor(DamageElement element, ref bool applyGradient, ref Color top, ref Color bottom)
		{
			switch (element)
			{
			case DamageElement.DE_FIRE:
				applyGradient = true;
				top = new Color32(173, 60, 58, byte.MaxValue);
				bottom = new Color32(121, 33, 32, byte.MaxValue);
				break;
			case DamageElement.DE_WATER:
				top = new Color32(103, 209, 228, byte.MaxValue);
				bottom = new Color32(54, 121, 131, byte.MaxValue);
				applyGradient = true;
				break;
			case DamageElement.DE_LIGHT:
				top = new Color32(234, 226, 156, byte.MaxValue);
				bottom = new Color32(178, 182, 117, byte.MaxValue);
				applyGradient = true;
				break;
			case DamageElement.DE_DARK:
				top = new Color32(149, 140, 237, byte.MaxValue);
				bottom = new Color32(104, 95, 169, byte.MaxValue);
				applyGradient = true;
				break;
			default:
				applyGradient = false;
				break;
			}
		}

		public static string HUD_NORMAL = "UI/Billboard/HUDNormal2";

		public static string HUD_CRITICAL = "UI/Billboard/HUDCritical";

		public static string HUD_POFANG = "UI/Billboard/HUDPofang";

		public static string HUD_PLAYER = "UI/Billboard/HUDPlayer";

		public static string HUD_IMMORTAL = "UI/Billboard/HUDImmortal";

		public static string HUD_MISS = "UI/Billboard/HUDMiss";
	}
}
