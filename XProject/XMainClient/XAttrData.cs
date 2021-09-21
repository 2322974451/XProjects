using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000BBC RID: 3004
	internal class XAttrData : XDataBase
	{
		// Token: 0x17003060 RID: 12384
		// (get) Token: 0x0600ABD6 RID: 43990 RVA: 0x001F865C File Offset: 0x001F685C
		// (set) Token: 0x0600ABD7 RID: 43991 RVA: 0x001F8664 File Offset: 0x001F6864
		public string Title { get; set; }

		// Token: 0x17003061 RID: 12385
		// (get) Token: 0x0600ABD8 RID: 43992 RVA: 0x001F866D File Offset: 0x001F686D
		// (set) Token: 0x0600ABD9 RID: 43993 RVA: 0x001F8675 File Offset: 0x001F6875
		public string StrEmpty { get; set; }

		// Token: 0x17003062 RID: 12386
		// (get) Token: 0x0600ABDA RID: 43994 RVA: 0x001F8680 File Offset: 0x001F6880
		public List<string> Left
		{
			get
			{
				return this.m_Left;
			}
		}

		// Token: 0x17003063 RID: 12387
		// (get) Token: 0x0600ABDB RID: 43995 RVA: 0x001F8698 File Offset: 0x001F6898
		public List<string> Right
		{
			get
			{
				return this.m_Right;
			}
		}

		// Token: 0x17003064 RID: 12388
		// (get) Token: 0x0600ABDC RID: 43996 RVA: 0x001F86B0 File Offset: 0x001F68B0
		// (set) Token: 0x0600ABDD RID: 43997 RVA: 0x001F86B8 File Offset: 0x001F68B8
		public AttriDataType Type { get; set; }

		// Token: 0x0600ABDE RID: 43998 RVA: 0x001F86C1 File Offset: 0x001F68C1
		public void Reset()
		{
			this.m_Left.Clear();
			this.m_Right.Clear();
			this.Title = string.Empty;
			this.StrEmpty = string.Empty;
		}

		// Token: 0x0600ABDF RID: 43999 RVA: 0x001F86F4 File Offset: 0x001F68F4
		public override void Init()
		{
			base.Init();
			this.Reset();
		}

		// Token: 0x0600ABE0 RID: 44000 RVA: 0x001F8705 File Offset: 0x001F6905
		public override void Recycle()
		{
			XDataPool<XAttrData>.Recycle(this);
			this.Reset();
		}

		// Token: 0x04004091 RID: 16529
		private List<string> m_Left = new List<string>();

		// Token: 0x04004092 RID: 16530
		private List<string> m_Right = new List<string>();
	}
}
