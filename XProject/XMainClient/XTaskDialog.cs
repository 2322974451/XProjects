using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000A8C RID: 2700
	internal class XTaskDialog
	{
		// Token: 0x17002FBE RID: 12222
		// (get) Token: 0x0600A435 RID: 42037 RVA: 0x001C54C4 File Offset: 0x001C36C4
		public List<XDialogSentence> Dialog
		{
			get
			{
				return this.m_Dialog;
			}
		}

		// Token: 0x0600A436 RID: 42038 RVA: 0x001C54DC File Offset: 0x001C36DC
		public void Reset()
		{
			this.m_Dialog.Clear();
		}

		// Token: 0x0600A437 RID: 42039 RVA: 0x001C54EB File Offset: 0x001C36EB
		public void Append(XDialogSentence sentence)
		{
			this.m_Dialog.Add(sentence);
		}

		// Token: 0x0600A438 RID: 42040 RVA: 0x001C54FB File Offset: 0x001C36FB
		public void Append(int talker, string content, string voice = null)
		{
			this.m_Dialog.Add(new XDialogSentence(talker, content, voice, false));
		}

		// Token: 0x0600A439 RID: 42041 RVA: 0x001C5514 File Offset: 0x001C3714
		public void TryAppend(XDialogSentence sentence)
		{
			bool inited = sentence.Inited;
			if (inited)
			{
				this.Append(sentence);
			}
		}

		// Token: 0x04003BA8 RID: 15272
		private List<XDialogSentence> m_Dialog = new List<XDialogSentence>();
	}
}
