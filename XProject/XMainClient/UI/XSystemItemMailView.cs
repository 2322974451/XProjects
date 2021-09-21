using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001849 RID: 6217
	internal class XSystemItemMailView : MonoBehaviour
	{
		// Token: 0x06010259 RID: 66137 RVA: 0x003DE22C File Offset: 0x003DC42C
		private void Awake()
		{
			this.m_sprsign = (base.transform.Find("sign").GetComponent("XUISprite") as IXUISprite);
			this.m_spricon = (base.transform.Find("Icon1").GetComponent("XUISprite") as IXUISprite);
			this.m_lbltitle = (base.transform.Find("titleLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_sprattach = (base.transform.Find("Icon2").GetComponent("XUISprite") as IXUISprite);
			this.m_sprhighlight = (base.transform.Find("highlight").GetComponent("XUISprite") as IXUISprite);
			this.m_lblday = (base.transform.Find("dayLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_sprsign.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSignClick));
			this.m_lbltitle.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnItemClick));
			this.ShowSel(false);
			this.ShowHighLight(false);
		}

		// Token: 0x0601025A RID: 66138 RVA: 0x003DE358 File Offset: 0x003DC558
		public void OnDisable()
		{
			bool flag = this.timeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.timeToken);
			}
		}

		// Token: 0x0601025B RID: 66139 RVA: 0x003DE388 File Offset: 0x003DC588
		public void Update()
		{
			bool flag = this._doc != null && this._doc.select_mail == this.mailItem.id;
			if (flag)
			{
				bool flag2 = this.leftTime <= 86400;
				if (flag2)
				{
					float num = (float)this.leftTime - (Time.time - this.refreshTime);
					bool flag3 = num >= 3600f;
					if (flag3)
					{
						this.timer_show = (int)(num / 3600f) + XStringDefineProxy.GetString("Mail_HOUR");
					}
					else
					{
						bool flag4 = num >= 60f;
						if (flag4)
						{
							this.timer_show = (int)(num / 60f) + XStringDefineProxy.GetString("Mail_MIN");
						}
						else
						{
							this.timer_show = "1" + XStringDefineProxy.GetString("Mail_MIN");
						}
					}
					this._doc.valit = this.timer_show;
					this.m_lblday.SetText(this.timer_show);
				}
			}
		}

		// Token: 0x0601025C RID: 66140 RVA: 0x003DE498 File Offset: 0x003DC698
		public void Refresh(ulong id)
		{
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			this.mailItem = this._doc.GetMailItem(id);
			this.m_lbltitle.SetText(this.mailItem.title);
			this.m_lbltitle.SetColor(this.mailItem.isRead ? Color.gray : new Color(0.94f, 0.82f, 0.34f));
			this.m_sprattach.SetAlpha((float)((this.mailItem.state == MailState.NONE) ? 0 : 1));
			this.m_sprattach.spriteName = ((this.mailItem.state == MailState.RWD) ? "mail_0" : "mail_1");
			bool flag = this.mailItem.valit >= 86400;
			if (flag)
			{
				this.timer_show = this.mailItem.valit / 86400 + XStringDefineProxy.GetString("Mail_DAY");
			}
			else
			{
				bool flag2 = this.mailItem.valit >= 3600;
				if (flag2)
				{
					this.timer_show = this.mailItem.valit / 3600 + XStringDefineProxy.GetString("Mail_HOUR");
				}
				else
				{
					bool flag3 = this.mailItem.valit > 60;
					if (flag3)
					{
						this.timer_show = this.mailItem.valit / 60 + XStringDefineProxy.GetString("Mail_MIN");
					}
					else
					{
						this.timer_show = "1" + XStringDefineProxy.GetString("Mail_MIN");
					}
				}
			}
			this.m_lblday.SetText(this.timer_show);
			this.leftTime = this.mailItem.valit;
			this.refreshTime = Time.time;
			bool flag4 = this.leftTime < 240;
			if (flag4)
			{
				this.timeToken = XSingleton<XTimerMgr>.singleton.SetTimer((float)(this.leftTime + 4), new XTimerMgr.ElapsedEventHandler(this.OnTimeOut), null);
			}
			switch (this.mailItem.type)
			{
			case MailType.System:
				this.m_spricon.spriteName = "mail_2";
				break;
			case MailType.Good:
				this.m_spricon.spriteName = "mail_3";
				break;
			case MailType.Bad:
				this.m_spricon.spriteName = "mail_4";
				break;
			case MailType.Cost:
				this.m_spricon.spriteName = "mail_5";
				break;
			}
		}

		// Token: 0x0601025D RID: 66141 RVA: 0x003DE723 File Offset: 0x003DC923
		public void ShowHighLight(bool show)
		{
			this.m_sprhighlight.SetAlpha(show ? 1f : 0.01f);
		}

		// Token: 0x0601025E RID: 66142 RVA: 0x003DE744 File Offset: 0x003DC944
		private void OnItemClick(IXUILabel lbl)
		{
			bool flag = this.mailItem == null || DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				this._doc.SetSelect(this.mailItem.id);
				bool flag2 = XSystemMailView.doItemSelect != null;
				if (flag2)
				{
					XSystemMailView.doItemSelect();
				}
				bool flag3 = !this.mailItem.isRead;
				if (flag3)
				{
					this._doc.ReqMailOP(MailOP.Read, this.mailItem.id);
				}
				this.ShowHighLight(true);
			}
		}

		// Token: 0x0601025F RID: 66143 RVA: 0x003DE7CD File Offset: 0x003DC9CD
		private void OnTimeOut(object handler)
		{
			this._doc.ReqMailInfo();
		}

		// Token: 0x06010260 RID: 66144 RVA: 0x003DE7DC File Offset: 0x003DC9DC
		private void OnSignClick(IXUISprite spr)
		{
			bool flag = !DlgBase<RewdAnimDlg, RewdAnimBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.ShowSel(!this.showSign);
				bool flag2 = XSystemMailView.doSelSelect != null;
				if (flag2)
				{
					XSystemMailView.doSelSelect();
				}
			}
		}

		// Token: 0x06010261 RID: 66145 RVA: 0x003DE824 File Offset: 0x003DCA24
		public void ShowSel(bool show)
		{
			this.showSign = show;
			this.m_sprsign.SetAlpha(show ? 1f : 0.01f);
		}

		// Token: 0x17003956 RID: 14678
		// (get) Token: 0x06010262 RID: 66146 RVA: 0x003DE84C File Offset: 0x003DCA4C
		public bool Select
		{
			get
			{
				return base.gameObject != null && base.gameObject.activeSelf && this.showSign;
			}
		}

		// Token: 0x17003957 RID: 14679
		// (get) Token: 0x06010263 RID: 66147 RVA: 0x003DE884 File Offset: 0x003DCA84
		public ulong uid
		{
			get
			{
				return this.mailItem.id;
			}
		}

		// Token: 0x17003958 RID: 14680
		// (get) Token: 0x06010264 RID: 66148 RVA: 0x003DE8A4 File Offset: 0x003DCAA4
		public bool isRwd
		{
			get
			{
				return this.mailItem != null && this.mailItem.state == MailState.RWD;
			}
		}

		// Token: 0x0400735F RID: 29535
		private XMailDocument _doc = null;

		// Token: 0x04007360 RID: 29536
		public IXUISprite m_sprsign;

		// Token: 0x04007361 RID: 29537
		public IXUISprite m_spricon;

		// Token: 0x04007362 RID: 29538
		public IXUILabel m_lbltitle;

		// Token: 0x04007363 RID: 29539
		public IXUISprite m_sprattach;

		// Token: 0x04007364 RID: 29540
		public IXUISprite m_sprhighlight;

		// Token: 0x04007365 RID: 29541
		public IXUILabel m_lblday;

		// Token: 0x04007366 RID: 29542
		private bool showSign = false;

		// Token: 0x04007367 RID: 29543
		private MailItem mailItem;

		// Token: 0x04007368 RID: 29544
		private int leftTime = int.MaxValue;

		// Token: 0x04007369 RID: 29545
		private uint timeToken = 0U;

		// Token: 0x0400736A RID: 29546
		private float refreshTime;

		// Token: 0x0400736B RID: 29547
		private string timer_show;
	}
}
