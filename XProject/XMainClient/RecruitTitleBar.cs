using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitTitleBar : DlgHandlerBase
	{

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

		public uint filter
		{
			get
			{
				return this.m_selectIndex;
			}
		}

		public int direction
		{
			get
			{
				return this.m_dir;
			}
		}

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

		private void Excute()
		{
		}

		private void OnCloseDrop(IXUISprite sprite = null)
		{
			this.m_DropList.gameObject.SetActive(false);
		}

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

		public void RegisterTitleChange(RecruitTitleChange eventHandler)
		{
			this.m_titleChange = eventHandler;
		}

		public void RegisterTitleReSelect(RecruitTitleReSelect selectHandle)
		{
			this.m_reselect = selectHandle;
		}

		public void SetState(TitleSelector select)
		{
			this.selector = select;
			this.SetState(this.m_titles[XFastEnumIntEqualityComparer<TitleSelector>.ToInt(select)]);
		}

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

		private IXUILabel[] m_titles;

		private Transform m_SortArrow;

		private Transform m_UpArrow;

		private Transform m_DownArrow;

		private uint m_selectIndex = 0U;

		private int m_dir = -1;

		private TitleSelector m_selector = TitleSelector.Name;

		private Transform m_DropList;

		private IXUISprite m_DropClose;

		private RecruitTitleChange m_titleChange;

		private RecruitTitleReSelect m_reselect;
	}
}
