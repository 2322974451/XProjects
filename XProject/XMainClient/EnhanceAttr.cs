using System;

namespace XMainClient
{

	internal class EnhanceAttr
	{

		public EnhanceAttr(uint attrID, uint attrValue, uint afterValue)
		{
			this.m_name = XStringDefineProxy.GetString((XAttributeDefine)attrID);
			this.m_beforeAttrNum = attrValue;
			this.m_afterAttrNum = afterValue;
		}

		public EnhanceAttr(string name, uint beforeValue, uint afterValue)
		{
			this.m_name = name;
			this.m_beforeAttrNum = beforeValue;
			this.m_afterAttrNum = afterValue;
		}

		public string Name
		{
			get
			{
				return this.m_name;
			}
		}

		public uint BeforeAttrNum
		{
			get
			{
				return this.m_beforeAttrNum;
			}
		}

		public uint AfterAttrNum
		{
			get
			{
				return this.m_afterAttrNum;
			}
		}

		public int D_value
		{
			get
			{
				return (int)(this.m_afterAttrNum - this.m_beforeAttrNum);
			}
		}

		private string m_name = "";

		private uint m_beforeAttrNum = 0U;

		private uint m_afterAttrNum = 0U;
	}
}
