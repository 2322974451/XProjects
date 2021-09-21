using System;
using System.Collections.Generic;
using System.Text;

namespace XUtliPoolLib
{
	// Token: 0x020001B3 RID: 435
	public class XStringFormatHelper
	{
		// Token: 0x060009B8 RID: 2488 RVA: 0x00032E0C File Offset: 0x0003100C
		public static string FormatImage(string atlas, string sprite)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("im=").Append(atlas).Append(XStringFormatHelper.EscapedSeparator).Append(sprite).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x00032E68 File Offset: 0x00031068
		public static string FormatAnimation(string atlas, string sprite, int frameRate)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("an=").Append(atlas).Append(XStringFormatHelper.EscapedSeparator).Append(sprite).Append(XStringFormatHelper.EscapedSeparator).Append(frameRate.ToString()).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x00032EDC File Offset: 0x000310DC
		public static string FormatGuild(string name, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("gd=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x00032F38 File Offset: 0x00031138
		public static string FormatDragonGuild(string name, string dragonguildname)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("dg=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(dragonguildname).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x00032F94 File Offset: 0x00031194
		public static string FormatTeam(string name, int teamid, uint expid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("tm=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(teamid).Append(XStringFormatHelper.EscapedSeparator).Append(expid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x00033000 File Offset: 0x00031200
		public static string FormatItem(string name, string itemquality, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("it=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(itemquality).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0003306C File Offset: 0x0003126C
		public static string FormatName(string name, ulong uid, string color = "00ffff")
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("nm=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(color).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x000330D8 File Offset: 0x000312D8
		public static string FormatPk(string name, ulong uid)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("pk=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x00033134 File Offset: 0x00031334
		public static string FormatSpeactate(string name, int liveid, int type)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("sp=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(liveid).Append(XStringFormatHelper.EscapedSeparator).Append(type).Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x000331A0 File Offset: 0x000313A0
		public static string FormatUI(string name, ulong uid, List<ulong> paramList = null)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedLeftBracket).Append("ui=").Append(name).Append(XStringFormatHelper.EscapedSeparator).Append(uid);
			bool flag = paramList != null;
			if (flag)
			{
				for (int i = 0; i < paramList.Count; i++)
				{
					XStringFormatHelper._SB.Append(XStringFormatHelper.EscapedSeparator).Append(paramList[i]);
				}
			}
			XStringFormatHelper._SB.Append(XStringFormatHelper._EscapedRightBracket);
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0003323D File Offset: 0x0003143D
		private static void _ResetSB()
		{
			XStringFormatHelper._SB.Remove(0, XStringFormatHelper._SB.Length);
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x00033258 File Offset: 0x00031458
		public static string Escape(string s)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(s);
			XStringFormatHelper._Escape();
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0003328C File Offset: 0x0003148C
		private static void _Escape()
		{
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strSeparator, XStringFormatHelper._strEscapedSeparator);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strLeftBracket, XStringFormatHelper._strEscapedLeftBracket);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strRightBracket, XStringFormatHelper._strEscapedRightBracket);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x000332DC File Offset: 0x000314DC
		public static string UnEscape(string s)
		{
			XStringFormatHelper._ResetSB();
			XStringFormatHelper._SB.Append(s);
			XStringFormatHelper._UnEscape();
			return XStringFormatHelper._SB.ToString();
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x00033310 File Offset: 0x00031510
		private static void _UnEscape()
		{
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedSeparator, XStringFormatHelper._strSeparator);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedLeftBracket, XStringFormatHelper._strLeftBracket);
			XStringFormatHelper._SB.Replace(XStringFormatHelper._strEscapedRightBracket, XStringFormatHelper._strRightBracket);
		}

		// Token: 0x04000499 RID: 1177
		public static readonly char EscapedSeparator = '\u001f';

		// Token: 0x0400049A RID: 1178
		public static readonly char[] Separator = new char[]
		{
			XStringFormatHelper.EscapedSeparator
		};

		// Token: 0x0400049B RID: 1179
		private static readonly char _cSeparator = '|';

		// Token: 0x0400049C RID: 1180
		private static readonly char _cLeftBracket = '[';

		// Token: 0x0400049D RID: 1181
		private static readonly char _EscapedLeftBracket = '\u0002';

		// Token: 0x0400049E RID: 1182
		private static readonly char _cRightBracket = ']';

		// Token: 0x0400049F RID: 1183
		private static readonly char _EscapedRightBracket = '\u0003';

		// Token: 0x040004A0 RID: 1184
		private static readonly string _strSeparator = "|" + XStringFormatHelper._cSeparator.ToString();

		// Token: 0x040004A1 RID: 1185
		private static readonly string _strLeftBracket = "|" + XStringFormatHelper._cLeftBracket.ToString();

		// Token: 0x040004A2 RID: 1186
		private static readonly string _strRightBracket = "|" + XStringFormatHelper._cRightBracket.ToString();

		// Token: 0x040004A3 RID: 1187
		private static readonly string _strEscapedSeparator = XStringFormatHelper.EscapedSeparator.ToString() ?? "";

		// Token: 0x040004A4 RID: 1188
		private static readonly string _strEscapedLeftBracket = XStringFormatHelper._EscapedLeftBracket.ToString() ?? "";

		// Token: 0x040004A5 RID: 1189
		private static readonly string _strEscapedRightBracket = XStringFormatHelper._EscapedRightBracket.ToString() ?? "";

		// Token: 0x040004A6 RID: 1190
		private static StringBuilder _SB = new StringBuilder();
	}
}
