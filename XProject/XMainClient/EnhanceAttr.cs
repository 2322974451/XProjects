using System;

namespace XMainClient
{
	// Token: 0x020009F0 RID: 2544
	internal class EnhanceAttr
	{
		// Token: 0x06009BCB RID: 39883 RVA: 0x0018F101 File Offset: 0x0018D301
		public EnhanceAttr(uint attrID, uint attrValue, uint afterValue)
		{
			this.m_name = XStringDefineProxy.GetString((XAttributeDefine)attrID);
			this.m_beforeAttrNum = attrValue;
			this.m_afterAttrNum = afterValue;
		}

		// Token: 0x06009BCC RID: 39884 RVA: 0x0018F13E File Offset: 0x0018D33E
		public EnhanceAttr(string name, uint beforeValue, uint afterValue)
		{
			this.m_name = name;
			this.m_beforeAttrNum = beforeValue;
			this.m_afterAttrNum = afterValue;
		}

		// Token: 0x17002E54 RID: 11860
		// (get) Token: 0x06009BCD RID: 39885 RVA: 0x0018F178 File Offset: 0x0018D378
		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		// Token: 0x17002E55 RID: 11861
		// (get) Token: 0x06009BCE RID: 39886 RVA: 0x0018F190 File Offset: 0x0018D390
		public uint BeforeAttrNum
		{
			get
			{
				return this.m_beforeAttrNum;
			}
		}

		// Token: 0x17002E56 RID: 11862
		// (get) Token: 0x06009BCF RID: 39887 RVA: 0x0018F1A8 File Offset: 0x0018D3A8
		public uint AfterAttrNum
		{
			get
			{
				return this.m_afterAttrNum;
			}
		}

		// Token: 0x17002E57 RID: 11863
		// (get) Token: 0x06009BD0 RID: 39888 RVA: 0x0018F1C0 File Offset: 0x0018D3C0
		public int D_value
		{
			get
			{
				return (int)(this.m_afterAttrNum - this.m_beforeAttrNum);
			}
		}

		// Token: 0x040035FB RID: 13819
		private string m_name = "";

		// Token: 0x040035FC RID: 13820
		private uint m_beforeAttrNum = 0U;

		// Token: 0x040035FD RID: 13821
		private uint m_afterAttrNum = 0U;
	}
}
