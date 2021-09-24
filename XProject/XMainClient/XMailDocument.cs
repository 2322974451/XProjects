using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMailDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XMailDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ReqMailInfo();
			}
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.mails.Clear();
		}

		public void ReqMailInfo()
		{
			RpcC2M_FetchMail rpcC2M_FetchMail = new RpcC2M_FetchMail();
			rpcC2M_FetchMail.oArg.page = (uint)this.currPage;
			rpcC2M_FetchMail.oArg.count = 7U;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_FetchMail);
		}

		public void ResMailInfo(FetchMailRes res)
		{
			this.currPage = (int)res.page;
			this.pagesCnt = (int)res.pagecount;
			this.mails.Clear();
			for (int i = 0; i < res.mails.Count; i++)
			{
				SMail smail = res.mails[i];
				MailItem mailItem = new MailItem();
				mailItem.id = smail.uid;
				mailItem.isRead = smail.isread;
				mailItem.state = (MailState)smail.state;
				mailItem.type = (MailType)smail.type;
				mailItem.isTemp = smail.istemplate;
				mailItem.title = this.FormatStringLength(smail.title, 28);
				mailItem.date = this.UnixDate(smail.timestamp);
				mailItem.content = smail.content;
				bool flag = mailItem.items == null;
				if (flag)
				{
					mailItem.items = new List<ItemBrief>();
				}
				bool flag2 = mailItem.xitems == null;
				if (flag2)
				{
					mailItem.xitems = new List<Item>();
				}
				mailItem.items.Clear();
				for (int j = 0; j < smail.items.Count; j++)
				{
					mailItem.items.Add(smail.items[j]);
				}
				for (int k = 0; k < smail.xitems.Count; k++)
				{
					mailItem.xitems.Add(smail.xitems[k]);
				}
				mailItem.valit = smail.timeleft;
				this.mails.Add(mailItem);
			}
			bool flag3 = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView != null && DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.IsVisible();
			if (flag3)
			{
				DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.Refresh();
			}
		}

		public void ReqMailOP(MailOP type, ulong uid)
		{
			this.ReqMailOP(type, new List<ulong>
			{
				uid
			});
		}

		public void ReqMailOP(MailOP type, List<ulong> uid)
		{
			RpcC2M_MailOp rpcC2M_MailOp = new RpcC2M_MailOp();
			rpcC2M_MailOp.oArg.uid.Clear();
			foreach (ulong num in uid)
			{
				MailItem mailItem = this.Find(num);
				rpcC2M_MailOp.oArg.uid.Add(num);
			}
			rpcC2M_MailOp.oArg.optype = (uint)type;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_MailOp);
		}

		private MailItem Find(ulong id)
		{
			for (int i = 0; i < this.mails.Count; i++)
			{
				bool flag = this.mails[i].id == id;
				if (flag)
				{
					return this.mails[i];
				}
			}
			return null;
		}

		public void ResMailOP(MailOpArg req, MailOpRes res)
		{
			bool flag = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool flag2 = req.optype == 0U;
				if (flag2)
				{
					ulong id = req.uid[0];
					MailItem mailItem = this.Find(id);
					bool flag3 = mailItem != null;
					if (flag3)
					{
						mailItem.isRead = true;
						bool flag4 = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.IsVisible();
						if (flag4)
						{
							DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.RefreshItems();
						}
					}
				}
				else
				{
					bool flag5 = req.optype == 2U;
					if (flag5)
					{
						ulong id2 = req.uid[0];
						MailItem mailItem2 = this.Find(id2);
						bool flag6 = mailItem2 != null;
						if (flag6)
						{
							mailItem2.state = MailState.CLAIMED;
							bool flag7 = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._contMailView.IsVisible();
							if (flag7)
							{
								DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._contMailView.Refresh();
							}
							bool flag8 = DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.IsVisible();
							if (flag8)
							{
								DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._systemFrameView.RefreshItems();
							}
						}
					}
					else
					{
						this.ReqMailInfo();
					}
				}
			}
		}

		private DateTime UnixDate(uint sp)
		{
			DateTime minValue = DateTime.MinValue;
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(sp);
		}

		private void Sort()
		{
			this.mails.Sort(new Comparison<MailItem>(this.SortMethod));
		}

		private int SortMethod(ulong _x, ulong _y)
		{
			MailItem x = this.Find(_x);
			MailItem y = this.Find(_y);
			return this.SortMethod(x, y);
		}

		private int SortMethod(MailItem x, MailItem y)
		{
			bool flag = x == null || y == null;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				TimeSpan timeSpan = x.date - y.date;
				bool flag2 = timeSpan.TotalSeconds < 0.0;
				if (flag2)
				{
					result = -1;
				}
				else
				{
					bool flag3 = timeSpan.TotalSeconds == 0.0;
					if (flag3)
					{
						result = 0;
					}
					else
					{
						result = 1;
					}
				}
			}
			return result;
		}

		public void SetSelect(ulong id)
		{
			this.select_mail = id;
		}

		public void RefreshContentNil()
		{
			this.select_mail = 0UL;
			DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton._contMailView.Refresh();
		}

		public bool CtlPage(bool add)
		{
			bool flag = !add;
			bool result;
			if (flag)
			{
				bool flag2 = this.currPage > 0;
				if (flag2)
				{
					this.currPage--;
					this.ReqMailInfo();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			else
			{
				bool flag3 = this.currPage < this.pagesCnt - 1;
				if (flag3)
				{
					this.currPage++;
					this.ReqMailInfo();
					result = true;
				}
				else
				{
					result = false;
				}
			}
			return result;
		}

		public string GetPageFormat()
		{
			return string.Format("{0}/{1}", this.currPage + 1, Math.Max(1, this.pagesCnt));
		}

		public bool ShowMailContent()
		{
			return this.select_mail != 0UL && this.Find(this.select_mail) != null;
		}

		public MailItem GetMailItem()
		{
			return this.Find(this.select_mail);
		}

		public MailItem GetMailItem(ulong id)
		{
			return this.Find(id);
		}

		public string FormatStringLength(string str, int displayLength)
		{
			string result = string.Empty;
			int byteCount = Encoding.Default.GetByteCount(str);
			bool flag = byteCount > displayLength;
			if (flag)
			{
				displayLength -= 3;
				int num = 0;
				int num2 = 0;
				byte[] bytes = Encoding.Unicode.GetBytes(str);
				while (num2 < bytes.GetLength(0) && num < displayLength)
				{
					bool flag2 = num2 % 2 == 0;
					if (flag2)
					{
						num++;
					}
					else
					{
						bool flag3 = bytes[num2] > 0;
						if (flag3)
						{
							num++;
						}
					}
					num2++;
				}
				bool flag4 = num2 % 2 == 1;
				if (flag4)
				{
					bool flag5 = bytes[num2] > 0;
					if (flag5)
					{
						num2--;
					}
					else
					{
						num2++;
					}
				}
				result = Encoding.Unicode.GetString(bytes, 0, num2) + "...";
			}
			else
			{
				result = str;
			}
			return result;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("MailDocument");

		public List<MailItem> mails = new List<MailItem>();

		private int currPage = 0;

		private int pagesCnt = 1;

		public ulong select_mail = 0UL;

		public const int PERCNT = 7;

		public string valit;
	}
}
