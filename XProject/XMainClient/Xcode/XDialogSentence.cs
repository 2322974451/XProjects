using System;

namespace XMainClient
{

	internal struct XDialogSentence
	{

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

		public bool Inited
		{
			get
			{
				return this.m_Inited;
			}
		}

		public XDialogSentence(int _talker, string _content, string _voice = null, bool _bCanReject = false)
		{
			this.m_Talker = _talker;
			this.m_Inited = false;
			this.m_Content = _content;
			this.m_Voice = _voice;
			this.m_bCanReject = _bCanReject;
		}

		public void Reset()
		{
			this.m_Talker = -1;
			this.Content = string.Empty;
			this.Voice = string.Empty;
			this.m_bCanReject = false;
			this.m_Inited = false;
		}

		private int m_Talker;

		private string m_Content;

		private string m_Voice;

		private bool m_bCanReject;

		private bool m_Inited;
	}
}
