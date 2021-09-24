using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLabelSymbolHelper
	{

		public static string FormatCostWithIcon(int cost, ItemEnum moneyType)
		{
			return string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)), cost);
		}

		public static string FormatCostWithIconLast(int cost, ItemEnum moneyType)
		{
			return string.Format("{0}{1}", cost, XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)));
		}

		public static string FormatCostWithIcon(string s, int cost, ItemEnum moneyType)
		{
			return string.Format(s, XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)), cost);
		}

		public static string FormatItemSmallIcon(string s, int itemId, int cost)
		{
			return string.Format(s, XLabelSymbolHelper.FormatSmallIcon(itemId), cost);
		}

		public static string FormatSmallIcon(int itemID)
		{
			string sprite;
			string atlas;
			XBagDocument.GetItemSmallIconAndAtlas(itemID, out sprite, out atlas, 0U);
			return XStringFormatHelper.FormatImage(atlas, sprite);
		}

		public static string FormatImage(int itemID)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(itemID);
			bool flag = itemConf == null;
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				result = XStringFormatHelper.FormatImage(XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemAtlas, 0U), XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemIcon, 0U));
			}
			return result;
		}

		public static string FormatImage(string atlas, string sprite)
		{
			return XStringFormatHelper.FormatImage(atlas, sprite);
		}

		public static string FormatAnimation(string atlas, string sprite, int frameRate)
		{
			return XStringFormatHelper.FormatAnimation(atlas, sprite, frameRate);
		}

		public static string FormatDesignation(string atlas, string sprite, int frameRate = 16)
		{
			return XStringFormatHelper.FormatAnimation(atlas, sprite, frameRate);
		}

		public static string FormatGuild(string name, ulong uid)
		{
			return XStringFormatHelper.FormatGuild(name, uid);
		}

		public static string FormatDragonGuild(string name, string dragonguildname)
		{
			return XStringFormatHelper.FormatDragonGuild(name, dragonguildname);
		}

		public static string FormatTeam(string name, int teamid, uint expid)
		{
			return XStringFormatHelper.FormatTeam(name, teamid, expid);
		}

		public static string FormatItem(string name, XItem item)
		{
			return XStringFormatHelper.FormatItem(name, XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)XBagDocument.GetItemConf(item.itemID).ItemQuality), item.uid);
		}

		public static string FormatName(string name, ulong uid, string color = "00ffff")
		{
			return XStringFormatHelper.FormatName(name, uid, color);
		}

		public static string FormatPk(string name, ulong uid)
		{
			return XStringFormatHelper.FormatPk(name, uid);
		}

		public static string FormatSpectate(string name, int liveid, int type)
		{
			return XStringFormatHelper.FormatSpeactate(name, liveid, type);
		}

		public static string FormatUI(string name, ulong uid, List<ulong> paramList)
		{
			return XStringFormatHelper.FormatUI(name, uid, paramList);
		}

		public static bool ParseGuildParam(string param, ref ulong guildid)
		{
			guildid = ulong.Parse(param);
			return true;
		}

		public static bool ParseDragonGuildParam(string param, ref string dragonguildname)
		{
			dragonguildname = param;
			return true;
		}

		public static bool ParseSpectateParam(string param, ref int liveid, ref int type)
		{
			string[] array = param.Split(XStringFormatHelper.Separator);
			bool flag = array.Length != 2;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				liveid = int.Parse(array[0]);
				type = int.Parse(array[1]);
				result = true;
			}
			return result;
		}

		public static bool ParsePkParam(string param, ref ulong roleid)
		{
			roleid = ulong.Parse(param);
			return true;
		}

		public static bool ParseUIParam(string param, ref ulong sysid, ref List<ulong> sysParamList)
		{
			string[] array = param.Split(XStringFormatHelper.Separator);
			bool flag = array.Length == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				sysid = ulong.Parse(array[0]);
				bool flag2 = array.Length > 1;
				if (flag2)
				{
					bool flag3 = sysParamList == null;
					if (flag3)
					{
						sysParamList = new List<ulong>();
					}
					sysParamList.Clear();
					for (int i = 1; i < array.Length; i++)
					{
						sysParamList.Add(ulong.Parse(array[i]));
					}
				}
				else
				{
					bool flag4 = sysParamList != null;
					if (flag4)
					{
						sysParamList.Clear();
					}
				}
				result = true;
			}
			return result;
		}

		public static bool ParseNameParam(string param, ref string name, ref ulong uid)
		{
			string[] array = param.Split(XStringFormatHelper.Separator);
			bool flag = array.Length != 2;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				uid = ulong.Parse(array[0]);
				name = XStringFormatHelper.UnEscape(array[1]);
				result = true;
			}
			return result;
		}

		public static bool ParseTeamParam(string param, ref int teamid, ref uint expid)
		{
			string[] array = param.Split(XStringFormatHelper.Separator);
			bool flag = array.Length != 2;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				teamid = int.Parse(array[0]);
				expid = uint.Parse(array[1]);
				result = true;
			}
			return result;
		}

		public static void RegisterHyperLinkClicks(IXUILabelSymbol labelSymbol)
		{
			labelSymbol.RegisterTeamEventHandler(new HyperLinkClickEventHandler(XTeamDocument.OnTeamHyperLinkClick));
			labelSymbol.RegisterPkEventHandler(new HyperLinkClickEventHandler(XQualifyingDocument.OnPkHyperLinkClick));
			labelSymbol.RegisterGuildEventHandler(new HyperLinkClickEventHandler(XGuildDocument.OnGuildHyperLinkClick));
			labelSymbol.RegisterDragonGuildEventHandler(new HyperLinkClickEventHandler(XDragonGuildDocument.OnDragonGuildHyperLinkClick));
			labelSymbol.RegisterUIEventHandler(new HyperLinkClickEventHandler(XInvitationDocument.OnUIHyperLinkClick));
			labelSymbol.RegisterSpectateEventHandler(new HyperLinkClickEventHandler(XInvitationDocument.OnSpectateClick));
		}

		public static string RemoveFormatInfo(string input)
		{
			bool flag = input.Contains("ui=");
			string result;
			if (flag)
			{
				result = input.Substring(0, input.IndexOf("ui="));
			}
			else
			{
				result = input;
			}
			return result;
		}
	}
}
