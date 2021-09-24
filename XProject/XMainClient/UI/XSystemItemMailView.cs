using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XSystemItemMailView : MonoBehaviour
	{

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

		public void OnDisable()
		{
			bool flag = this.timeToken > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this.timeToken);
			}
		}

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

		public void ShowHighLight(bool show)
		{
			this.m_sprhighlight.SetAlpha(show ? 1f : 0.01f);
		}

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

		private void OnTimeOut(object handler)
		{
			this._doc.ReqMailInfo();
		}

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

		public void ShowSel(bool show)
		{
			this.showSign = show;
			this.m_sprsign.SetAlpha(show ? 1f : 0.01f);
		}

		public bool Select
		{
			get
			{
				return base.gameObject != null && base.gameObject.activeSelf && this.showSign;
			}
		}

		public ulong uid
		{
			get
			{
				return this.mailItem.id;
			}
		}

		public bool isRwd
		{
			get
			{
				return this.mailItem != null && this.mailItem.state == MailState.RWD;
			}
		}

		private XMailDocument _doc = null;

		public IXUISprite m_sprsign;

		public IXUISprite m_spricon;

		public IXUILabel m_lbltitle;

		public IXUISprite m_sprattach;

		public IXUISprite m_sprhighlight;

		public IXUILabel m_lblday;

		private bool showSign = false;

		private MailItem mailItem;

		private int leftTime = int.MaxValue;

		private uint timeToken = 0U;

		private float refreshTime;

		private string timer_show;
	}
}
