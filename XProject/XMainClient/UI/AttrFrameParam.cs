using System;
using System.Collections.Generic;

namespace XMainClient.UI
{
	// Token: 0x02001918 RID: 6424
	internal class AttrFrameParam
	{
		// Token: 0x17003AE4 RID: 15076
		// (get) Token: 0x06010CD1 RID: 68817 RVA: 0x00438F4B File Offset: 0x0043714B
		// (set) Token: 0x06010CD2 RID: 68818 RVA: 0x00438F53 File Offset: 0x00437153
		public string Title { get; set; }

		// Token: 0x17003AE5 RID: 15077
		// (get) Token: 0x06010CD3 RID: 68819 RVA: 0x00438F5C File Offset: 0x0043715C
		public List<AttrParam> AttrList
		{
			get
			{
				return this.m_AttrList;
			}
		}

		// Token: 0x06010CD4 RID: 68820 RVA: 0x00438F74 File Offset: 0x00437174
		public void Clear()
		{
			this.m_AttrList.Clear();
			this.Title = string.Empty;
		}

		// Token: 0x04007B45 RID: 31557
		private List<AttrParam> m_AttrList = new List<AttrParam>();
	}
}
