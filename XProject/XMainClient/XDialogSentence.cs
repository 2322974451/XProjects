using System;

namespace XMainClient
{
	// Token: 0x02000A8B RID: 2699
	internal struct XDialogSentence
	{
		// Token: 0x17002FB9 RID: 12217
		// (get) Token: 0x0600A42A RID: 42026 RVA: 0x001C53BC File Offset: 0x001C35BC
		// (set) Token: 0x0600A42B RID: 42027 RVA: 0x001C53D4 File Offset: 0x001C35D4
		public int Talker
		{
			get
			{
				return this.m_Talker;
			}
			set
			{
				this.m_Talker = value;
				this.m_Inited = true;
			}
		}

		// Token: 0x17002FBA RID: 12218
		// (get) Token: 0x0600A42C RID: 42028 RVA: 0x001C53E8 File Offset: 0x001C35E8
		// (set) Token: 0x0600A42D RID: 42029 RVA: 0x001C5400 File Offset: 0x001C3600
		public string Content
		{
			get
			{
				return this.m_Content;
			}
			set
			{
				this.m_Content = value;
			}
		}

		// Token: 0x17002FBB RID: 12219
		// (get) Token: 0x0600A42E RID: 42030 RVA: 0x001C540C File Offset: 0x001C360C
		// (set) Token: 0x0600A42F RID: 42031 RVA: 0x001C5424 File Offset: 0x001C3624
		public string Voice
		{
			get
			{
				return this.m_Voice;
			}
			set
			{
				this.m_Voice = value;
			}
		}

		// Token: 0x17002FBC RID: 12220
		// (get) Token: 0x0600A430 RID: 42032 RVA: 0x001C5430 File Offset: 0x001C3630
		// (set) Token: 0x0600A431 RID: 42033 RVA: 0x001C5448 File Offset: 0x001C3648
		public bool bCanReject
		{
			get
			{
				return this.m_bCanReject;
			}
			set
			{
				this.m_bCanReject = value;
			}
		}

		// Token: 0x17002FBD RID: 12221
		// (get) Token: 0x0600A432 RID: 42034 RVA: 0x001C5454 File Offset: 0x001C3654
		public bool Inited
		{
			get
			{
				return this.m_Inited;
			}
		}

		// Token: 0x0600A433 RID: 42035 RVA: 0x001C546C File Offset: 0x001C366C
		public XDialogSentence(int _talker, string _content, string _voice = null, bool _bCanReject = false)
		{
			this.m_Talker = _talker;
			this.m_Inited = false;
			this.m_Content = _content;
			this.m_Voice = _voice;
			this.m_bCanReject = _bCanReject;
		}

		// Token: 0x0600A434 RID: 42036 RVA: 0x001C5493 File Offset: 0x001C3693
		public void Reset()
		{
			this.m_Talker = -1;
			this.Content = string.Empty;
			this.Voice = string.Empty;
			this.m_bCanReject = false;
			this.m_Inited = false;
		}

		// Token: 0x04003BA3 RID: 15267
		private int m_Talker;

		// Token: 0x04003BA4 RID: 15268
		private string m_Content;

		// Token: 0x04003BA5 RID: 15269
		private string m_Voice;

		// Token: 0x04003BA6 RID: 15270
		private bool m_bCanReject;

		// Token: 0x04003BA7 RID: 15271
		private bool m_Inited;
	}
}
