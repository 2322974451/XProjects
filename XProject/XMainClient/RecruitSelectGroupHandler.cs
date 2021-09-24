using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitSelectGroupHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			this.m_GroupScrollView = (base.transform.Find("SelectGroup").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_GroupWrapContent = (base.transform.Find("SelectGroup/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_GroupWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
			Transform transform = base.transform.Find("Close");
			bool flag = transform != null;
			if (flag)
			{
				this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
				this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClick));
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.SetupMineGroups();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.SetupMineGroups();
		}

		public CBrifGroupInfo SelectGroup
		{
			get
			{
				return this._SelectGroupInfo;
			}
			private set
			{
				this._SelectGroupInfo = value;
			}
		}

		private void Excute()
		{
			bool flag = this.m_selectUpdate != null;
			if (flag)
			{
				this.m_selectUpdate();
			}
		}

		public void Setup(RecruitSelectGroupUpdate selectUpdate = null)
		{
			this.m_selectUpdate = selectUpdate;
		}

		public void SetupSelectGroup(ulong groupID)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this._NormalSelectGroupID = groupID;
				this.SetupMineGroups();
			}
		}

		private void SetupMineGroups()
		{
			bool flag = this._mineGroups == null;
			if (flag)
			{
				this._mineGroups = new List<CBrifGroupInfo>();
			}
			bool flag2 = this._NewGroupInfo == null;
			if (flag2)
			{
				this._NewGroupInfo = new CBrifGroupInfo();
				this._NewGroupInfo.id = 0UL;
			}
			this._mineGroups.Clear();
			this._doc.TryGetGroupInMine(ref this._mineGroups);
			this._mineGroups.Sort(new Comparison<CBrifGroupInfo>(this.GroupCompareTo));
			int count = this._mineGroups.Count;
			bool flag3 = count > 0 && this._NormalSelectGroupID == 0UL;
			if (flag3)
			{
				CBrifGroupInfo cbrifGroupInfo = this._mineGroups[0];
				this._NormalSelectGroupID = cbrifGroupInfo.id;
			}
			this._mineGroups.Insert(0, this._NewGroupInfo);
			this.m_GroupWrapContent.SetContentCount(this._mineGroups.Count, false);
			this.m_GroupScrollView.ResetPosition();
		}

		private int GroupCompareTo(CBrifGroupInfo info1, CBrifGroupInfo info2)
		{
			bool flag = info1.id == 0UL;
			int result;
			if (flag)
			{
				result = -1;
			}
			else
			{
				bool flag2 = info2.id == 0UL;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = (int)(info1.createTime - info2.createTime);
				}
			}
			return result;
		}

		private void OnWrapContentUpdate(Transform t, int index)
		{
			Transform transform = t.Find("Info");
			Transform transform2 = t.Find("New");
			CBrifGroupInfo cbrifGroupInfo = this._mineGroups[index];
			bool flag = cbrifGroupInfo.id == 0UL;
			if (flag)
			{
				transform.gameObject.SetActive(false);
				transform2.gameObject.SetActive(true);
			}
			else
			{
				transform.gameObject.SetActive(true);
				transform2.gameObject.SetActive(false);
				IXUILabel ixuilabel = t.Find("Info/Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Info/Time").GetComponent("XUILabel") as IXUILabel;
				IXUICheckBox ixuicheckBox = t.Find("Info").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuilabel.SetText(cbrifGroupInfo.name);
				ixuilabel2.SetText(XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)cbrifGroupInfo.createTime, XStringDefineProxy.GetString("TIME_FORMAT_YYMMDD"), true));
				bool flag2 = cbrifGroupInfo.id == this._NormalSelectGroupID;
				if (flag2)
				{
					ixuicheckBox.bChecked = true;
					this.SelectGroup = cbrifGroupInfo;
				}
				else
				{
					ixuicheckBox.bChecked = false;
				}
			}
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.ID = (ulong)((long)index);
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGroupClick));
		}

		private void OnGroupClick(IXUISprite sprite)
		{
			int num = (int)sprite.ID;
			bool flag = num == 0;
			if (flag)
			{
				this._doc.SelectGroupHandler = this;
				DlgBase<RecruitNameView, RecruitNameBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				IXUICheckBox ixuicheckBox = sprite.transform.Find("Info").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.bChecked = true;
				this.SelectGroup = this._mineGroups[num];
				this.Excute();
			}
		}

		private void OnCloseClick(IXUISprite sprite)
		{
			base.SetVisible(false);
		}

		public override void OnUnload()
		{
			this._NewGroupInfo = null;
			this._SelectGroupInfo = null;
			this.m_selectUpdate = null;
			bool flag = this._mineGroups != null;
			if (flag)
			{
				this._mineGroups.Clear();
				this._mineGroups = null;
			}
			this._doc.SelectGroupHandler = null;
			base.OnUnload();
		}

		private IXUIScrollView m_GroupScrollView;

		private IXUIWrapContent m_GroupWrapContent;

		private IXUISprite m_Close;

		private List<CBrifGroupInfo> _mineGroups;

		private CBrifGroupInfo _NewGroupInfo;

		private CBrifGroupInfo _SelectGroupInfo;

		private ulong _NormalSelectGroupID = 0UL;

		private GroupChatDocument _doc;

		private RecruitSelectGroupUpdate m_selectUpdate;
	}
}
