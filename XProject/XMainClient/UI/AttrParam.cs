using System;
using System.Text;

namespace XMainClient.UI
{

	internal struct AttrParam
	{

		public static void ResetSb()
		{
			AttrParam.TextSb.Length = 0;
			AttrParam.ValueSb.Length = 0;
		}

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

		public static void Append(XItemChangeAttr attr, string textColor = "", string valueColor = "")
		{
			AttrParam.Append(AttrParam.TextSb, XAttributeCommon.GetAttrStr((int)attr.AttrID), textColor);
			AttrParam.Append(AttrParam.ValueSb, XAttributeCommon.GetAttrValueStr((int)attr.AttrID, attr.AttrValue), valueColor);
		}

		public void SetTextFromSb()
		{
			this.strText = AttrParam.TextSb.ToString();
		}

		public void SetValueFromSb()
		{
			this.strValue = AttrParam.ValueSb.ToString();
		}

		public static StringBuilder TextSb = new StringBuilder();

		public static StringBuilder ValueSb = new StringBuilder();

		public string strText;

		public string strValue;

		public bool IsShowTipsIcon;

		public string IconName;
	}
}
