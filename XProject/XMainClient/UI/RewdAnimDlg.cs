using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001845 RID: 6213
	internal class RewdAnimDlg : DlgBase<RewdAnimDlg, RewdAnimBehaviour>
	{
		// Token: 0x17003951 RID: 14673
		// (get) Token: 0x06010230 RID: 66096 RVA: 0x003DCC44 File Offset: 0x003DAE44
		public override string fileName
		{
			get
			{
				return "GameSystem/RewdAnimDlg";
			}
		}

		// Token: 0x17003952 RID: 14674
		// (get) Token: 0x06010231 RID: 66097 RVA: 0x003DCC5C File Offset: 0x003DAE5C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003953 RID: 14675
		// (get) Token: 0x06010232 RID: 66098 RVA: 0x003DCC70 File Offset: 0x003DAE70
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003954 RID: 14676
		// (get) Token: 0x06010233 RID: 66099 RVA: 0x003DCC84 File Offset: 0x003DAE84
		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003955 RID: 14677
		// (get) Token: 0x06010234 RID: 66100 RVA: 0x003DCC98 File Offset: 0x003DAE98
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010235 RID: 66101 RVA: 0x003DCCAB File Offset: 0x003DAEAB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClick));
		}

		// Token: 0x06010236 RID: 66102 RVA: 0x003DCCD2 File Offset: 0x003DAED2
		protected override void Init()
		{
			base.Init();
			this.m_pool.SetupPool(this.m_uiBehaviour.m_objTmp.transform.parent.gameObject, this.m_uiBehaviour.m_objTmp, 3U, true);
		}

		// Token: 0x06010237 RID: 66103 RVA: 0x003DCD10 File Offset: 0x003DAF10
		public void Show(List<Item> items, Action onclose)
		{
			List<ItemBrief> list = new List<ItemBrief>();
			for (int i = 0; i < items.Count; i++)
			{
				list.Add(new ItemBrief
				{
					itemID = items[i].ItemID,
					itemCount = items[i].ItemCount
				});
			}
			this.Show(list, onclose);
			this.m_xitems = items;
		}

		// Token: 0x06010238 RID: 66104 RVA: 0x003DCD80 File Offset: 0x003DAF80
		public void Show(List<ItemBrief> items, List<Item> xitems, Action onClose)
		{
			List<ItemBrief> list = new List<ItemBrief>();
			for (int i = 0; i < items.Count; i++)
			{
				list.Add(new ItemBrief
				{
					itemID = items[i].itemID,
					itemCount = items[i].itemCount
				});
			}
			for (int j = 0; j < xitems.Count; j++)
			{
				list.Add(new ItemBrief
				{
					itemID = xitems[j].ItemID,
					itemCount = xitems[j].ItemCount
				});
			}
			this.Show(list, onClose);
			this.m_xitems = xitems;
		}

		// Token: 0x06010239 RID: 66105 RVA: 0x003DCE48 File Offset: 0x003DB048
		public void Show(List<ItemBrief> items, Action onClose)
		{
			int num = 10;
			bool flag = items.Count > num;
			if (flag)
			{
				items.RemoveRange(num, items.Count - num);
			}
			this.m_delClose = onClose;
			bool flag2 = this.m_xitems != null;
			if (flag2)
			{
				this.m_xitems.Clear();
			}
			this.m_items = items;
			this.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0601023A RID: 66106 RVA: 0x003DCEA6 File Offset: 0x003DB0A6
		public void ShowByTitle(List<ItemBrief> items, string title, Action onClose)
		{
			this.Show(items, onClose);
			base.uiBehaviour.m_TitleLabel.SetText(title);
		}

		// Token: 0x0601023B RID: 66107 RVA: 0x003DCEC4 File Offset: 0x003DB0C4
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_tweenbg.ResetTween(true);
			base.uiBehaviour.m_tweentitle.ResetTween(true);
			base.uiBehaviour.m_tweenbg.PlayTween(true, -1f);
			base.uiBehaviour.m_tweentitle.PlayTween(true, -1f);
			this.m_pool.ReturnAll(false);
			this.m_objlist.Clear();
			this.OnTweenEnd(null);
			this.items_cnt = this.m_items.Count;
			for (int i = 0; i < this.items_cnt; i++)
			{
				GameObject gameObject = this.m_pool.FetchGameObject(false);
				this.m_objlist.Add(gameObject);
				ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this.m_items[i].itemID);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this.m_items[i].itemID, (int)this.m_items[i].itemCount, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this.m_items[i].itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTips));
				int num = (this.items_cnt % 2 == 0) ? ((int)((float)i - (float)this.items_cnt / 2f) * 100 + 50) : ((int)((float)i - (float)(this.items_cnt - 1) / 2f) * 100);
				this.m_to_x[i] = num;
				int num2 = (this.items_cnt % 2 == 0) ? ((int)(-(int)((float)this.items_cnt / 2f)) * 100 + 50) : ((int)((float)(-(float)(this.items_cnt - 1)) / 2f) * 100);
				this.m_from_x[i] = 0;
				this.items_pos = new Vector3(0f, 14f, 0f);
				gameObject.transform.localPosition = this.items_pos;
			}
		}

		// Token: 0x0601023C RID: 66108 RVA: 0x003DD0E0 File Offset: 0x003DB2E0
		private void ShowTips(IXUISprite spr)
		{
			bool flag = this.m_xitems != null;
			if (flag)
			{
				for (int i = 0; i < this.m_xitems.Count; i++)
				{
					bool flag2 = (ulong)this.m_xitems[i].ItemID == spr.ID;
					if (flag2)
					{
						XItem mainItem = XBagDocument.MakeXItem(this.m_xitems[i]);
						XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem, spr, false, 0U);
						return;
					}
				}
			}
			bool flag3 = this.m_items != null;
			if (flag3)
			{
				for (int j = 0; j < this.m_items.Count; j++)
				{
					bool flag4 = (ulong)this.m_items[j].itemID == spr.ID;
					if (flag4)
					{
						XItem mainItem2 = XBagDocument.MakeXItem((int)this.m_items[j].itemID, this.m_items[j].isbind);
						XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem2, spr, false, 0U);
						return;
					}
				}
			}
			XItem mainItem3 = XBagDocument.MakeXItem((int)spr.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialogWithSearchingCompare(mainItem3, spr, false, 0U);
		}

		// Token: 0x0601023D RID: 66109 RVA: 0x003DD214 File Offset: 0x003DB414
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
						bool flag3 = this.m_objlist.Count > i && this.m_objlist[i] != null;
						if (flag3)
						{
							this.m_objlist[i].transform.localPosition = this.items_pos;
						}
					}
				}
			}
			base.OnUpdate();
		}

		// Token: 0x0601023E RID: 66110 RVA: 0x003DD303 File Offset: 0x003DB503
		private void OnTweenEnd(IXUITweenTool tween)
		{
			this.ani_time = Time.realtimeSinceStartup;
			this.ani_duration = 1f;
			this.ani_start = true;
			this.ani_sped = 6;
		}

		// Token: 0x0601023F RID: 66111 RVA: 0x003DD32C File Offset: 0x003DB52C
		private bool OnOKClick(IXUIButton btn)
		{
			this.SetVisible(false, true);
			bool flag = this.m_delClose != null;
			if (flag)
			{
				this.m_delClose();
			}
			return true;
		}

		// Token: 0x04007335 RID: 29493
		private int[] m_to_x = new int[10];

		// Token: 0x04007336 RID: 29494
		private int[] m_from_x = new int[10];

		// Token: 0x04007337 RID: 29495
		private bool ani_start = false;

		// Token: 0x04007338 RID: 29496
		private float ani_duration = 1f;

		// Token: 0x04007339 RID: 29497
		private float ani_time = 0f;

		// Token: 0x0400733A RID: 29498
		private int items_cnt = 1;

		// Token: 0x0400733B RID: 29499
		private int ani_sped = 1;

		// Token: 0x0400733C RID: 29500
		private Vector3 items_pos;

		// Token: 0x0400733D RID: 29501
		private List<ItemBrief> m_items;

		// Token: 0x0400733E RID: 29502
		private List<Item> m_xitems;

		// Token: 0x0400733F RID: 29503
		private List<GameObject> m_objlist = new List<GameObject>();

		// Token: 0x04007340 RID: 29504
		private Action m_delClose;

		// Token: 0x04007341 RID: 29505
		private XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
