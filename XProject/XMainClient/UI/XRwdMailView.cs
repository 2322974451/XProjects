using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001848 RID: 6216
	internal class XRwdMailView : DlgHandlerBase
	{
		// Token: 0x06010252 RID: 66130 RVA: 0x003DDD88 File Offset: 0x003DBF88
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

		// Token: 0x06010253 RID: 66131 RVA: 0x003DDE61 File Offset: 0x003DC061
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_btnok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClick));
		}

		// Token: 0x06010254 RID: 66132 RVA: 0x003DDE84 File Offset: 0x003DC084
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

		// Token: 0x06010255 RID: 66133 RVA: 0x003DE0A8 File Offset: 0x003DC2A8
		private void OnTweenEnd(IXUITweenTool tween)
		{
			this.ani_time = Time.realtimeSinceStartup;
			this.ani_duration = 1f;
			this.ani_start = true;
			this.ani_sped = 6;
		}

		// Token: 0x06010256 RID: 66134 RVA: 0x003DE0D0 File Offset: 0x003DC2D0
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

		// Token: 0x06010257 RID: 66135 RVA: 0x003DE18C File Offset: 0x003DC38C
		private bool OnOKClick(IXUIButton btn)
		{
			this._doc.ReqMailOP(MailOP.Claim, this.m_item.id);
			base.SetVisible(false);
			return true;
		}

		// Token: 0x04007351 RID: 29521
		private XMailDocument _doc = null;

		// Token: 0x04007352 RID: 29522
		public GameObject[] m_objitems = new GameObject[5];

		// Token: 0x04007353 RID: 29523
		public IXUIButton m_btnok;

		// Token: 0x04007354 RID: 29524
		public IXUITweenTool m_tweenbg;

		// Token: 0x04007355 RID: 29525
		public IXUITweenTool m_tweentitle;

		// Token: 0x04007356 RID: 29526
		private MailItem m_item;

		// Token: 0x04007357 RID: 29527
		private int[] m_to_x = new int[5];

		// Token: 0x04007358 RID: 29528
		private int[] m_from_x = new int[5];

		// Token: 0x04007359 RID: 29529
		private bool ani_start = false;

		// Token: 0x0400735A RID: 29530
		private float ani_duration = 1f;

		// Token: 0x0400735B RID: 29531
		private float ani_time = 0f;

		// Token: 0x0400735C RID: 29532
		private int items_cnt = 1;

		// Token: 0x0400735D RID: 29533
		private int ani_sped = 1;

		// Token: 0x0400735E RID: 29534
		private Vector3 items_pos;
	}
}
