using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class XTaskDialog
	{

		public List<XDialogSentence> Dialog
		{
			get
			{
				return this.m_Dialog;
			}
		}

		public void Reset()
		{
			this.m_Dialog.Clear();
		}

		public void Append(XDialogSentence sentence)
		{
			this.m_Dialog.Add(sentence);
		}

		public void Append(int talker, string content, string voice = null)
		{
			this.m_Dialog.Add(new XDialogSentence(talker, content, voice, false));
		}

		public void TryAppend(XDialogSentence sentence)
		{
			bool inited = sentence.Inited;
			if (inited)
			{
				this.Append(sentence);
			}
		}

		private List<XDialogSentence> m_Dialog = new List<XDialogSentence>();
	}
}
