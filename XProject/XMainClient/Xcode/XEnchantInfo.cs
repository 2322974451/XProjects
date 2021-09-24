using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal struct XEnchantInfo
	{

		public bool bHasEnchant
		{
			get
			{
				return this.AttrList != null && this.AttrList.Count != 0;
			}
		}

		public void Init()
		{
			bool flag = this.AttrList == null;
			if (flag)
			{
				this.AttrList = new List<XItemChangeAttr>();
			}
			else
			{
				this.AttrList.Clear();
			}
			bool flag2 = this.EnchantIDList == null;
			if (flag2)
			{
				this.EnchantIDList = new List<uint>();
			}
			else
			{
				this.EnchantIDList.Clear();
			}
			this.EnchantItemID = 0;
		}

		public List<XItemChangeAttr> AttrList;

		public int EnchantItemID;

		public uint ChooseAttr;

		public List<uint> EnchantIDList;
	}
}
