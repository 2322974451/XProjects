using System;
using System.Text;

namespace XMainClient.UI
{
	// Token: 0x02001919 RID: 6425
	internal struct AttrParam
	{
		// Token: 0x06010CD6 RID: 68822 RVA: 0x00438FA3 File Offset: 0x004371A3
		public static void ResetSb()
		{
			AttrParam.TextSb.Length = 0;
			AttrParam.ValueSb.Length = 0;
		}

		// Token: 0x06010CD7 RID: 68823 RVA: 0x00438FC0 File Offset: 0x004371C0
		public static void Append(StringBuilder sb, string s, string color = "")
		{
			bool flag = !string.IsNullOrEmpty(color);
			if (flag)
			{
				sb.Append("[").Append(color).Append("]");
			}
			sb.Append(s);
			bool flag2 = !string.IsNullOrEmpty(color);
			if (flag2)
			{
				sb.Append("[-]");
			}
		}

		// Token: 0x06010CD8 RID: 68824 RVA: 0x0043901C File Offset: 0x0043721C
		public static void Append(XItemChangeAttr attr, string textColor = "", string valueColor = "")
		{
			AttrParam.Append(AttrParam.TextSb, XAttributeCommon.GetAttrStr((int)attr.AttrID), textColor);
			AttrParam.Append(AttrParam.ValueSb, XAttributeCommon.GetAttrValueStr((int)attr.AttrID, attr.AttrValue), valueColor);
		}

		// Token: 0x06010CD9 RID: 68825 RVA: 0x00439055 File Offset: 0x00437255
		public void SetTextFromSb()
		{
			this.strText = AttrParam.TextSb.ToString();
		}

		// Token: 0x06010CDA RID: 68826 RVA: 0x00439068 File Offset: 0x00437268
		public void SetValueFromSb()
		{
			this.strValue = AttrParam.ValueSb.ToString();
		}

		// Token: 0x04007B46 RID: 31558
		public static StringBuilder TextSb = new StringBuilder();

		// Token: 0x04007B47 RID: 31559
		public static StringBuilder ValueSb = new StringBuilder();

		// Token: 0x04007B48 RID: 31560
		public string strText;

		// Token: 0x04007B49 RID: 31561
		public string strValue;

		// Token: 0x04007B4A RID: 31562
		public bool IsShowTipsIcon;

		// Token: 0x04007B4B RID: 31563
		public string IconName;
	}
}
