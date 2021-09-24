using System;

namespace XMainClient
{

	internal class ArtifactTotalAttrData
	{

		public ArtifactTotalAttrData(XItemChangeAttr attr)
		{
			this._nameId = attr.AttrID;
			this._num = attr.AttrValue;
		}

		public ArtifactTotalAttrData(string leftStr, string rightStr)
		{
			this.m_leftStr = leftStr;
			this.m_rightStr = rightStr;
		}

		public void Add(uint num)
		{
			this._num += num;
		}

		public uint NameId
		{
			get
			{
				return this._nameId;
			}
		}

		public string Name
		{
			get
			{
				return XAttributeCommon.GetAttrStr((int)this._nameId);
			}
		}

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

		public string RightStr
		{
			get
			{
				return this.m_rightStr;
			}
		}

		public string LeftStr
		{
			get
			{
				return this.m_leftStr;
			}
		}

		private uint _nameId;

		private uint _num;

		private string m_leftStr;

		private string m_rightStr;

		public string SuitName = string.Empty;
	}
}
