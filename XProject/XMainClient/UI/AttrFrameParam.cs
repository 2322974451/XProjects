using System;
using System.Collections.Generic;

namespace XMainClient.UI
{

	internal class AttrFrameParam
	{

		public string Title { get; set; }

		public List<AttrParam> AttrList
		{
			get
			{
				return this.m_AttrList;
			}
		}

		public void Clear()
		{
			this.m_AttrList.Clear();
			this.Title = string.Empty;
		}

		private List<AttrParam> m_AttrList = new List<AttrParam>();
	}
}
