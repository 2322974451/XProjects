using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XRwdMailView : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_btnok = (base.PanelObject.transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
			this.m_tweenbg = (base.PanelObject.transform.Find("CriticalConfirm").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tweentitle = (base.PanelObject.transform.Find("titleLabel").GetComponent("XUIPlayTween") as IXUITweenTool);
			for (int i = 0; i < this.m_objitems.Length; i++)
			{
				this.m_objitems[i] = base.PanelObject.transform.Find("items/item" + i).gameObject;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XMailDocument.uuID) as XMailDocument);
			this.m_tweenbg.PlayTween(true, -1f);
			this.m_tweentitle.PlayTween(true, -1f);
			this.m_tweenbg.RegisterOnFinishEventHandler(null);
			this.m_tweentitle.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnTweenEnd));
			this.m_item = this._doc.GetMailItem();
			this.items_cnt = this.m_item.items.Count;
			for (int i = 0; i < this.items_cnt; i++)
			{
				this.m_objitems[i].SetActive(true);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_item.items[i].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_objitems[i], (int)this.m_item.items[i].itemID, (int)this.m_item.items[i].itemCount, false);
				int num = (this.items_cnt % 2 == 0) ? ((int)((float)i - (float)this.items_cnt / 2f) * 100 + 50) : ((int)((float)i - (float)(this.items_cnt - 1) / 2f) * 100);
				this.m_to_x[i] = num;
				int num2 = (this.items_cnt % 2 == 0) ? ((int)(-(int)((float)this.items_cnt / 2f)) * 100 + 50) : ((int)((float)(-(float)(this.items_cnt - 1)) / 2f) * 100);
				this.m_from_x[i] = 0;
				this.items_pos = new Vector3(0f, 14f, 0f);
				this.m_objitems[i].transform.localPosition = this.items_pos;
			}
			for (int j = this.m_item.items.Count; j < this.m_objitems.Length; j++)
			{
				this.m_objitems[j].SetActive(false);
			}
		}

		private void OnTweenEnd(IXUITweenTool tween)
		{
			this.ani_time = Time.realtimeSinceStartup;
			this.ani_duration = 1f;
			this.ani_start = true;
			this.ani_sped = 6;
		}

		public override void OnUpdate()
		{
			bool flag = this.ani_start;
			if (flag)
			{
				bool flag2 = Time.realtimeSinceStartup - this.ani_time >= this.ani_duration;
				if (flag2)
				{
					this.ani_start = false;
				}
				else
				{
					for (int i = 0; i < this.items_cnt; i++)
					{
						this.items_pos.x = Mathf.Lerp((float)this.m_from_x[i], (float)this.m_to_x[i], (float)this.ani_sped * (Time.realtimeSinceStartup - this.ani_time / this.ani_duration));
						this.m_objitems[i].transform.localPosition = this.items_pos;
					}
				}
			}
			base.OnUpdate();
		}

		private bool OnOKClick(IXUIButton btn)
		{
			this._doc.ReqMailOP(MailOP.Claim, this.m_item.id);
			base.SetVisible(false);
			return true;
		}

		private XMailDocument _doc = null;

		public GameObject[] m_objitems = new GameObject[5];

		public IXUIButton m_btnok;

		public IXUITweenTool m_tweenbg;

		public IXUITweenTool m_tweentitle;

		private MailItem m_item;

		private int[] m_to_x = new int[5];

		private int[] m_from_x = new int[5];

		private bool ani_start = false;

		private float ani_duration = 1f;

		private float ani_time = 0f;

		private int items_cnt = 1;

		private int ani_sped = 1;

		private Vector3 items_pos;
	}
}
