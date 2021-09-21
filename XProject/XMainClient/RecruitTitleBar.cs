using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A3F RID: 2623
	internal class RecruitTitleBar : DlgHandlerBase
	{
		// Token: 0x06009F7A RID: 40826 RVA: 0x001A6C98 File Offset: 0x001A4E98
		public override void OnUnload()
		{
			bool flag = this.m_titles != null;
			if (flag)
			{
				this.m_titles = null;
			}
			this.m_titleChange = null;
			base.OnUnload();
		}

		// Token: 0x17002EDB RID: 11995
		// (get) Token: 0x06009F7B RID: 40827 RVA: 0x001A6CC8 File Offset: 0x001A4EC8
		public uint filter
		{
			get
			{
				return this.m_selectIndex;
			}
		}

		// Token: 0x17002EDC RID: 11996
		// (get) Token: 0x06009F7C RID: 40828 RVA: 0x001A6CE0 File Offset: 0x001A4EE0
		public int direction
		{
			get
			{
				return this.m_dir;
			}
		}

		// Token: 0x17002EDD RID: 11997
		// (get) Token: 0x06009F7E RID: 40830 RVA: 0x001A6D34 File Offset: 0x001A4F34
		// (set) Token: 0x06009F7D RID: 40829 RVA: 0x001A6CF8 File Offset: 0x001A4EF8
		public TitleSelector selector
		{
			get
			{
				return this.m_selector;
			}
			set
			{
				bool flag = this.m_selector != value;
				if (flag)
				{
					this.m_dir = -1;
				}
				else
				{
					this.m_dir = -this.m_dir;
				}
				this.m_selector = value;
			}
		}

		// Token: 0x06009F7F RID: 40831 RVA: 0x001A6D4C File Offset: 0x001A4F4C
		protected override void Init()
		{
			base.Init();
			this.m_SortArrow = base.transform.Find("Sorting");
			this.m_UpArrow = base.transform.Find("Sorting/Up");
			this.m_DownArrow = base.transform.Find("Sorting/Down");
			int num = XFastEnumIntEqualityComparer<TitleSelector>.ToInt(TitleSelector.End);
			this.m_titles = new IXUILabel[num];
			for (int i = 0; i < num; i++)
			{
				this.m_titles[i] = (base.transform.Find(string.Format("Title{0}", i)).GetComponent("XUILabel") as IXUILabel);
				this.m_titles[i].ID = (ulong)((long)i);
				IXUIButton ixuibutton = this.m_titles[i].gameObject.transform.Find("Button").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)i);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTitleClick));
			}
			this.m_DropList = base.transform.Find(string.Format("Title{0}/DropList", XFastEnumIntEqualityComparer<TitleSelector>.ToInt(TitleSelector.Type)));
			this.m_DropClose = (this.m_DropList.Find("Close").GetComponent("XUISprite") as IXUISprite);
			Transform transform = this.m_DropList.Find("Jobs");
			this.m_DropClose.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseDrop));
			int j = 0;
			int childCount = transform.childCount;
			while (j < childCount)
			{
				IXUISprite ixuisprite = transform.Find(XSingleton<XCommon>.singleton.StringCombine("GroupMember_Type", j.ToString())).GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)j);
				IXUILabel ixuilabel = ixuisprite.transform.Find("ItemText").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XStringDefineProxy.GetString(ixuisprite.gameObject.name));
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnDropClick));
				j++;
			}
			this.OnCloseDrop(null);
			this.SetupMemberType(this.m_titles[XFastEnumIntEqualityComparer<TitleSelector>.ToInt(TitleSelector.Type)]);
			this.SetState(this.m_titles[XFastEnumIntEqualityComparer<TitleSelector>.ToInt(this.selector)]);
		}

		// Token: 0x06009F80 RID: 40832 RVA: 0x001A6FB4 File Offset: 0x001A51B4
		private void OnDropClick(IXUISprite sprite)
		{
			uint num = (uint)sprite.ID;
			bool flag = this.m_selectIndex != num;
			if (flag)
			{
				this.m_selectIndex = num;
				this.SetupMemberType(this.m_titles[XFastEnumIntEqualityComparer<TitleSelector>.ToInt(TitleSelector.Type)]);
				bool flag2 = this.m_reselect != null;
				if (flag2)
				{
					this.m_reselect();
				}
			}
			this.OnCloseDrop(null);
		}

		// Token: 0x06009F81 RID: 40833 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		private void Excute()
		{
		}

		// Token: 0x06009F82 RID: 40834 RVA: 0x001A7018 File Offset: 0x001A5218
		private void OnCloseDrop(IXUISprite sprite = null)
		{
			this.m_DropList.gameObject.SetActive(false);
		}

		// Token: 0x06009F83 RID: 40835 RVA: 0x001A7030 File Offset: 0x001A5230
		private bool OnTitleClick(IXUIButton btn)
		{
			TitleSelector titleSelector = (TitleSelector)btn.ID;
			bool flag = titleSelector == TitleSelector.Type;
			if (flag)
			{
				this.m_DropList.gameObject.SetActive(true);
			}
			else
			{
				this.SetState(titleSelector);
				bool flag2 = this.m_titleChange != null;
				if (flag2)
				{
					this.m_titleChange();
				}
			}
			return true;
		}

		// Token: 0x06009F84 RID: 40836 RVA: 0x001A708C File Offset: 0x001A528C
		public void RegisterTitleChange(RecruitTitleChange eventHandler)
		{
			this.m_titleChange = eventHandler;
		}

		// Token: 0x06009F85 RID: 40837 RVA: 0x001A7096 File Offset: 0x001A5296
		public void RegisterTitleReSelect(RecruitTitleReSelect selectHandle)
		{
			this.m_reselect = selectHandle;
		}

		// Token: 0x06009F86 RID: 40838 RVA: 0x001A70A0 File Offset: 0x001A52A0
		public void SetState(TitleSelector select)
		{
			this.selector = select;
			this.SetState(this.m_titles[XFastEnumIntEqualityComparer<TitleSelector>.ToInt(select)]);
		}

		// Token: 0x06009F87 RID: 40839 RVA: 0x001A70C0 File Offset: 0x001A52C0
		private void SetState(IXUILabel selector)
		{
			TitleSelector titleSelector = (TitleSelector)selector.ID;
			bool flag = titleSelector == TitleSelector.Type;
			if (flag)
			{
				this.SetupMemberType(selector);
			}
			else
			{
				this.m_SortArrow.parent = selector.gameObject.transform;
				this.m_SortArrow.localPosition = Vector2.zero;
				this.m_UpArrow.gameObject.SetActive(this.m_dir == 1);
				this.m_DownArrow.gameObject.SetActive(this.m_dir == -1);
			}
		}

		// Token: 0x06009F88 RID: 40840 RVA: 0x001A7150 File Offset: 0x001A5350
		private void SetupMemberType(IXUILabel select)
		{
			Transform transform = select.gameObject.transform.Find("Job");
			bool flag = transform == null;
			if (!flag)
			{
				IXUILabel ixuilabel = transform.GetComponent("XUILabel") as IXUILabel;
				bool flag2 = ixuilabel == null;
				if (!flag2)
				{
					ixuilabel.SetText(XStringDefineProxy.GetString(string.Format("GroupMember_Type{0}", this.m_selectIndex)));
				}
			}
		}

		// Token: 0x040038E7 RID: 14567
		private IXUILabel[] m_titles;

		// Token: 0x040038E8 RID: 14568
		private Transform m_SortArrow;

		// Token: 0x040038E9 RID: 14569
		private Transform m_UpArrow;

		// Token: 0x040038EA RID: 14570
		private Transform m_DownArrow;

		// Token: 0x040038EB RID: 14571
		private uint m_selectIndex = 0U;

		// Token: 0x040038EC RID: 14572
		private int m_dir = -1;

		// Token: 0x040038ED RID: 14573
		private TitleSelector m_selector = TitleSelector.Name;

		// Token: 0x040038EE RID: 14574
		private Transform m_DropList;

		// Token: 0x040038EF RID: 14575
		private IXUISprite m_DropClose;

		// Token: 0x040038F0 RID: 14576
		private RecruitTitleChange m_titleChange;

		// Token: 0x040038F1 RID: 14577
		private RecruitTitleReSelect m_reselect;
	}
}
