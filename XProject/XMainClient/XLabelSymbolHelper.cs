using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E73 RID: 3699
	internal class XLabelSymbolHelper
	{
		// Token: 0x0600C612 RID: 50706 RVA: 0x002BD90C File Offset: 0x002BBB0C
		public static string FormatCostWithIcon(int cost, ItemEnum moneyType)
		{
			return string.Format("{0}{1}", XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)), cost);
		}

		// Token: 0x0600C613 RID: 50707 RVA: 0x002BD93C File Offset: 0x002BBB3C
		public static string FormatCostWithIconLast(int cost, ItemEnum moneyType)
		{
			return string.Format("{0}{1}", cost, XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)));
		}

		// Token: 0x0600C614 RID: 50708 RVA: 0x002BD96C File Offset: 0x002BBB6C
		public static string FormatCostWithIcon(string s, int cost, ItemEnum moneyType)
		{
			return string.Format(s, XLabelSymbolHelper.FormatSmallIcon(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(moneyType)), cost);
		}

		// Token: 0x0600C615 RID: 50709 RVA: 0x002BD998 File Offset: 0x002BBB98
		public static string FormatItemSmallIcon(string s, int itemId, int cost)
		{
			return string.Format(s, XLabelSymbolHelper.FormatSmallIcon(itemId), cost);
		}

		// Token: 0x0600C616 RID: 50710 RVA: 0x002BD9BC File Offset: 0x002BBBBC
		public static string FormatSmallIcon(int itemID)
		{
			string sprite;
			string atlas;
			XBagDocument.GetItemSmallIconAndAtlas(itemID, out sprite, out atlas, 0U);
			return XStringFormatHelper.FormatImage(atlas, sprite);
		}

		// Token: 0x0600C617 RID: 50711 RVA: 0x002BD9E4 File Offset: 0x002BBBE4
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

		// Token: 0x0600C618 RID: 50712 RVA: 0x002BDA34 File Offset: 0x002BBC34
		public static string FormatImage(string atlas, string sprite)
		{
			return XStringFormatHelper.FormatImage(atlas, sprite);
		}

		// Token: 0x0600C619 RID: 50713 RVA: 0x002BDA50 File Offset: 0x002BBC50
		public static string FormatAnimation(string atlas, string sprite, int frameRate)
		{
			return XStringFormatHelper.FormatAnimation(atlas, sprite, frameRate);
		}

		// Token: 0x0600C61A RID: 50714 RVA: 0x002BDA6C File Offset: 0x002BBC6C
		public static string FormatDesignation(string atlas, string sprite, int frameRate = 16)
		{
			return XStringFormatHelper.FormatAnimation(atlas, sprite, frameRate);
		}

		// Token: 0x0600C61B RID: 50715 RVA: 0x002BDA88 File Offset: 0x002BBC88
		public static string FormatGuild(string name, ulong uid)
		{
			return XStringFormatHelper.FormatGuild(name, uid);
		}

		// Token: 0x0600C61C RID: 50716 RVA: 0x002BDAA4 File Offset: 0x002BBCA4
		public static string FormatDragonGuild(string name, string dragonguildname)
		{
			return XStringFormatHelper.FormatDragonGuild(name, dragonguildname);
		}

		// Token: 0x0600C61D RID: 50717 RVA: 0x002BDAC0 File Offset: 0x002BBCC0
		public static string FormatTeam(string name, int teamid, uint expid)
		{
			return XStringFormatHelper.FormatTeam(name, teamid, expid);
		}

		// Token: 0x0600C61E RID: 50718 RVA: 0x002BDADC File Offset: 0x002BBCDC
		public static string FormatItem(string name, XItem item)
		{
			return XStringFormatHelper.FormatItem(name, XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)XBagDocument.GetItemConf(item.itemID).ItemQuality), item.uid);
		}

		// Token: 0x0600C61F RID: 50719 RVA: 0x002BDB14 File Offset: 0x002BBD14
		public static string FormatName(string name, ulong uid, string color = "00ffff")
		{
			return XStringFormatHelper.FormatName(name, uid, color);
		}

		// Token: 0x0600C620 RID: 50720 RVA: 0x002BDB30 File Offset: 0x002BBD30
		public static string FormatPk(string name, ulong uid)
		{
			return XStringFormatHelper.FormatPk(name, uid);
		}

		// Token: 0x0600C621 RID: 50721 RVA: 0x002BDB4C File Offset: 0x002BBD4C
		public static string FormatSpectate(string name, int liveid, int type)
		{
			return XStringFormatHelper.FormatSpeactate(name, liveid, type);
		}

		// Token: 0x0600C622 RID: 50722 RVA: 0x002BDB68 File Offset: 0x002BBD68
		public static string FormatUI(string name, ulong uid, List<ulong> paramList)
		{
			return XStringFormatHelper.FormatUI(name, uid, paramList);
		}

		// Token: 0x0600C623 RID: 50723 RVA: 0x002BDB84 File Offset: 0x002BBD84
		public static bool ParseGuildParam(string param, ref ulong guildid)
		{
			guildid = ulong.Parse(param);
			return true;
		}

		// Token: 0x0600C624 RID: 50724 RVA: 0x002BDBA0 File Offset: 0x002BBDA0
		public static bool ParseDragonGuildParam(string param, ref string dragonguildname)
		{
			dragonguildname = param;
			return true;
		}

		// Token: 0x0600C625 RID: 50725 RVA: 0x002BDBB8 File Offset: 0x002BBDB8
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

		// Token: 0x0600C626 RID: 50726 RVA: 0x002BDBFC File Offset: 0x002BBDFC
		public static bool ParsePkParam(string param, ref ulong roleid)
		{
			roleid = ulong.Parse(param);
			return true;
		}

		// Token: 0x0600C627 RID: 50727 RVA: 0x002BDC18 File Offset: 0x002BBE18
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

		// Token: 0x0600C628 RID: 50728 RVA: 0x002BDCB4 File Offset: 0x002BBEB4
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

		// Token: 0x0600C629 RID: 50729 RVA: 0x002BDCF8 File Offset: 0x002BBEF8
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

		// Token: 0x0600C62A RID: 50730 RVA: 0x002BDD3C File Offset: 0x002BBF3C
		public static void RegisterHyperLinkClicks(IXUILabelSymbol labelSymbol)
		{
			labelSymbol.RegisterTeamEventHandler(new HyperLinkClickEventHandler(XTeamDocument.OnTeamHyperLinkClick));
			labelSymbol.RegisterPkEventHandler(new HyperLinkClickEventHandler(XQualifyingDocument.OnPkHyperLinkClick));
			labelSymbol.RegisterGuildEventHandler(new HyperLinkClickEventHandler(XGuildDocument.OnGuildHyperLinkClick));
			labelSymbol.RegisterDragonGuildEventHandler(new HyperLinkClickEventHandler(XDragonGuildDocument.OnDragonGuildHyperLinkClick));
			labelSymbol.RegisterUIEventHandler(new HyperLinkClickEventHandler(XInvitationDocument.OnUIHyperLinkClick));
			labelSymbol.RegisterSpectateEventHandler(new HyperLinkClickEventHandler(XInvitationDocument.OnSpectateClick));
		}

		// Token: 0x0600C62B RID: 50731 RVA: 0x002BDDBC File Offset: 0x002BBFBC
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
