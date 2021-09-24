using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class RewdAnimDlg : DlgBase<RewdAnimDlg, RewdAnimBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/RewdAnimDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		public override bool isHideTutorial
		{
			get
			{
				return true;
			}
		}

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnok.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOKClick));
		}

		protected override void Init()
		{
			base.Init();
			this.m_pool.SetupPool(this.m_uiBehaviour.m_objTmp.transform.parent.gameObject, this.m_uiBehaviour.m_objTmp, 3U, true);
		}

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

		public void ShowByTitle(List<ItemBrief> items, string title, Action onClose)
		{
			this.Show(items, onClose);
			base.uiBehaviour.m_TitleLabel.SetText(title);
		}

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

		private void OnTweenEnd(IXUITweenTool tween)
		{
			this.ani_time = Time.realtimeSinceStartup;
			this.ani_duration = 1f;
			this.ani_start = true;
			this.ani_sped = 6;
		}

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

		private int[] m_to_x = new int[10];

		private int[] m_from_x = new int[10];

		private bool ani_start = false;

		private float ani_duration = 1f;

		private float ani_time = 0f;

		private int items_cnt = 1;

		private int ani_sped = 1;

		private Vector3 items_pos;

		private List<ItemBrief> m_items;

		private List<Item> m_xitems;

		private List<GameObject> m_objlist = new List<GameObject>();

		private Action m_delClose;

		private XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
