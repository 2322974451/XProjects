using System;

namespace XMainClient
{
	// Token: 0x02000BBA RID: 3002
	internal class ArtifactTotalAttrData
	{
		// Token: 0x0600ABCE RID: 43982 RVA: 0x001F8515 File Offset: 0x001F6715
		public ArtifactTotalAttrData(XItemChangeAttr attr)
		{
			this._nameId = attr.AttrID;
			this._num = attr.AttrValue;
		}

		// Token: 0x0600ABCF RID: 43983 RVA: 0x001F8542 File Offset: 0x001F6742
		public ArtifactTotalAttrData(string leftStr, string rightStr)
		{
			this.m_leftStr = leftStr;
			this.m_rightStr = rightStr;
		}

		// Token: 0x0600ABD0 RID: 43984 RVA: 0x001F8565 File Offset: 0x001F6765
		public void Add(uint num)
		{
			this._num += num;
		}

		// Token: 0x1700305B RID: 12379
		// (get) Token: 0x0600ABD1 RID: 43985 RVA: 0x001F8578 File Offset: 0x001F6778
		public uint NameId
		{
			get
			{
				return this._nameId;
			}
		}

		// Token: 0x1700305C RID: 12380
		// (get) Token: 0x0600ABD2 RID: 43986 RVA: 0x001F8590 File Offset: 0x001F6790
		public string Name
		{
			get
			{
				return XAttributeCommon.GetAttrStr((int)this._nameId);
			}
		}

		// Token: 0x1700305D RID: 12381
		// (get) Token: 0x0600ABD3 RID: 43987 RVA: 0x001F85B0 File Offset: 0x001F67B0
		public string NumStr
		{
			get
			{
				bool flag = XAttributeCommon.IsPercentRange((int)this._nameId);
				string result;
				if (flag)
				{
					result = string.Format((this._num >= 0U) ? "+{0}%" : "{0}%", this._num.ToString("0.#"));
				}
				else
				{
					result = string.Format((this._num >= 0U) ? "+{0}" : "{0}", this._num).ToString();
				}
				return result;
			}
		}

		// Token: 0x1700305E RID: 12382
		// (get) Token: 0x0600ABD4 RID: 43988 RVA: 0x001F862C File Offset: 0x001F682C
		public string RightStr
		{
			get
			{
				return this.m_rightStr;
			}
		}

		// Token: 0x1700305F RID: 12383
		// (get) Token: 0x0600ABD5 RID: 43989 RVA: 0x001F8644 File Offset: 0x001F6844
		public string LeftStr
		{
			get
			{
				return this.m_leftStr;
			}
		}

		// Token: 0x04004086 RID: 16518
		private uint _nameId;

		// Token: 0x04004087 RID: 16519
		private uint _num;

		// Token: 0x04004088 RID: 16520
		private string m_leftStr;

		// Token: 0x04004089 RID: 16521
		private string m_rightStr;

		// Token: 0x0400408A RID: 16522
		public string SuitName = string.Empty;
	}
}
