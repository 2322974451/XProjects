using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A3C RID: 2620
	internal class RecruitSelectGroupHandler : DlgHandlerBase
	{
		// Token: 0x06009F63 RID: 40803 RVA: 0x001A6784 File Offset: 0x001A4984
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

		// Token: 0x06009F64 RID: 40804 RVA: 0x001A6857 File Offset: 0x001A4A57
		protected override void OnShow()
		{
			base.OnShow();
			this.SetupMineGroups();
		}

		// Token: 0x06009F65 RID: 40805 RVA: 0x001A6868 File Offset: 0x001A4A68
		public override void RefreshData()
		{
			base.RefreshData();
			this.SetupMineGroups();
		}

		// Token: 0x17002EDA RID: 11994
		// (get) Token: 0x06009F67 RID: 40807 RVA: 0x001A6884 File Offset: 0x001A4A84
		// (set) Token: 0x06009F66 RID: 40806 RVA: 0x001A6879 File Offset: 0x001A4A79
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

		// Token: 0x06009F68 RID: 40808 RVA: 0x001A689C File Offset: 0x001A4A9C
		private void Excute()
		{
			bool flag = this.m_selectUpdate != null;
			if (flag)
			{
				this.m_selectUpdate();
			}
		}

		// Token: 0x06009F69 RID: 40809 RVA: 0x001A68C3 File Offset: 0x001A4AC3
		public void Setup(RecruitSelectGroupUpdate selectUpdate = null)
		{
			this.m_selectUpdate = selectUpdate;
		}

		// Token: 0x06009F6A RID: 40810 RVA: 0x001A68D0 File Offset: 0x001A4AD0
		public void SetupSelectGroup(ulong groupID)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this._NormalSelectGroupID = groupID;
				this.SetupMineGroups();
			}
		}

		// Token: 0x06009F6B RID: 40811 RVA: 0x001A68FC File Offset: 0x001A4AFC
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

		// Token: 0x06009F6C RID: 40812 RVA: 0x001A69F4 File Offset: 0x001A4BF4
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

		// Token: 0x06009F6D RID: 40813 RVA: 0x001A6A38 File Offset: 0x001A4C38
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

		// Token: 0x06009F6E RID: 40814 RVA: 0x001A6BA0 File Offset: 0x001A4DA0
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

		// Token: 0x06009F6F RID: 40815 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClick(IXUISprite sprite)
		{
			base.SetVisible(false);
		}

		// Token: 0x06009F70 RID: 40816 RVA: 0x001A6C2C File Offset: 0x001A4E2C
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

		// Token: 0x040038DE RID: 14558
		private IXUIScrollView m_GroupScrollView;

		// Token: 0x040038DF RID: 14559
		private IXUIWrapContent m_GroupWrapContent;

		// Token: 0x040038E0 RID: 14560
		private IXUISprite m_Close;

		// Token: 0x040038E1 RID: 14561
		private List<CBrifGroupInfo> _mineGroups;

		// Token: 0x040038E2 RID: 14562
		private CBrifGroupInfo _NewGroupInfo;

		// Token: 0x040038E3 RID: 14563
		private CBrifGroupInfo _SelectGroupInfo;

		// Token: 0x040038E4 RID: 14564
		private ulong _NormalSelectGroupID = 0UL;

		// Token: 0x040038E5 RID: 14565
		private GroupChatDocument _doc;

		// Token: 0x040038E6 RID: 14566
		private RecruitSelectGroupUpdate m_selectUpdate;
	}
}
