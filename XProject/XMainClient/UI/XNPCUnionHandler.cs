using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D7 RID: 6103
	internal class XNPCUnionHandler : DlgHandlerBase
	{
		// Token: 0x170038AB RID: 14507
		// (get) Token: 0x0600FCE1 RID: 64737 RVA: 0x003B15E8 File Offset: 0x003AF7E8
		public uint SelectedUnionID
		{
			get
			{
				return this._selectedUnionID;
			}
		}

		// Token: 0x170038AC RID: 14508
		// (get) Token: 0x0600FCE2 RID: 64738 RVA: 0x003B1600 File Offset: 0x003AF800
		protected override string FileName
		{
			get
			{
				return "GameSystem/NPCBlessing/NpcGroupHandler";
			}
		}

		// Token: 0x0600FCE3 RID: 64739 RVA: 0x003B1618 File Offset: 0x003AF818
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.m_MemberFrame = base.PanelObject.transform.Find("GroupInfo").gameObject;
			DlgHandlerBase.EnsureCreate<XNPCUnionMemSubHandler>(ref this.m_MemberHandler, this.m_MemberFrame, this, false);
			this.m_MemberHandler.SetParentHandler(this);
			this.m_ScrollView = (base.PanelObject.transform.Find("Group/NpcScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.Find("Group/NpcScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x0600FCE4 RID: 64740 RVA: 0x003B16D2 File Offset: 0x003AF8D2
		protected override void OnShow()
		{
			this.RefreshData();
			this.m_MemberHandler.SetVisible(true);
		}

		// Token: 0x0600FCE5 RID: 64741 RVA: 0x003B16EC File Offset: 0x003AF8EC
		public override void RefreshData()
		{
			this.SetupUnionList();
			bool flag = this.m_MemberHandler.IsVisible();
			if (flag)
			{
				this.m_MemberHandler.RefreshData();
			}
		}

		// Token: 0x0600FCE6 RID: 64742 RVA: 0x003B171C File Offset: 0x003AF91C
		public override void RegisterEvent()
		{
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UnionWrapListUpdate));
		}

		// Token: 0x0600FCE7 RID: 64743 RVA: 0x003B1737 File Offset: 0x003AF937
		public override void OnUnload()
		{
			this.m_doc = null;
			DlgHandlerBase.EnsureUnload<XNPCUnionMemSubHandler>(ref this.m_MemberHandler);
			base.OnUnload();
		}

		// Token: 0x0600FCE8 RID: 64744 RVA: 0x003B1754 File Offset: 0x003AF954
		private void SetupUnionList()
		{
			this.m_UnionIds = this.m_doc.UnionIds;
			bool flag = this.m_UnionIds != null;
			if (flag)
			{
				this.m_WrapContent.SetContentCount(this.m_UnionIds.Count, false);
				this.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x0600FCE9 RID: 64745 RVA: 0x003B17A8 File Offset: 0x003AF9A8
		private void UnionWrapListUpdate(Transform item, int index)
		{
			bool flag = this.m_UnionIds == null || index >= this.m_UnionIds.Count;
			if (!flag)
			{
				uint num = this.m_UnionIds[index];
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(num);
				NpcUniteAttr.RowData unionTableInfoByUnionId = XNPCFavorDocument.GetUnionTableInfoByUnionId(num, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
				bool flag2 = unionTableInfoByUnionId == null;
				if (!flag2)
				{
					IXUILabel ixuilabel = item.FindChild("GroupName").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite = item.FindChild("GroupFlag").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel2 = item.FindChild("GroupLevel").GetComponent("XUILabel") as IXUILabel;
					uint unionSumLevel = this.m_doc.GetUnionSumLevel(num);
					ixuilabel.SetText(unionTableInfoByUnionId.Name);
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("NPCUnionLevel"), unionSumLevel));
					ixuisprite.SetSprite(unionTableInfoByUnionId.Icon);
					GameObject gameObject = item.FindChild("RedPoint").gameObject;
					gameObject.SetActive(this.m_doc.IsUnionCanActiveNextLevel(num, unionSumLevel));
					IXUISprite ixuisprite2 = item.FindChild("Btn").GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)num;
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectUnion));
					bool flag3 = this._selectedUnionID == 0U && index == 0;
					if (flag3)
					{
						this.OnSelectUnion(ixuisprite2);
					}
					this.ToggleSelection(item.gameObject, num == this._selectedUnionID);
				}
			}
		}

		// Token: 0x0600FCEA RID: 64746 RVA: 0x003B194C File Offset: 0x003AFB4C
		private void OnSelectUnion(IXUISprite sprite)
		{
			uint num = (uint)sprite.ID;
			bool flag = this._selectedUnionID == num;
			if (!flag)
			{
				this._selectedUnionID = num;
				bool flag2 = this.SelectedItem != null;
				if (flag2)
				{
					this.ToggleSelection(this.SelectedItem, false);
				}
				this.ToggleSelection(sprite.transform.parent.gameObject, true);
				this.OnNotifyRefreshSubHandler();
			}
		}

		// Token: 0x0600FCEB RID: 64747 RVA: 0x003B19B8 File Offset: 0x003AFBB8
		private void OnNotifyRefreshSubHandler()
		{
			bool flag = this.m_MemberHandler.IsVisible();
			if (flag)
			{
				this.m_MemberHandler.RefreshData();
			}
		}

		// Token: 0x0600FCEC RID: 64748 RVA: 0x003B19E4 File Offset: 0x003AFBE4
		private void ToggleSelection(GameObject go, bool bSelect)
		{
			Transform transform = go.transform.FindChild("Select");
			bool flag = transform != null;
			if (flag)
			{
				transform.gameObject.SetActive(bSelect);
			}
			if (bSelect)
			{
				this.SelectedItem = go;
			}
		}

		// Token: 0x04006F3C RID: 28476
		private XNPCFavorDocument m_doc;

		// Token: 0x04006F3D RID: 28477
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006F3E RID: 28478
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006F3F RID: 28479
		private GameObject m_MemberFrame;

		// Token: 0x04006F40 RID: 28480
		private XNPCUnionMemSubHandler m_MemberHandler = null;

		// Token: 0x04006F41 RID: 28481
		private List<uint> m_UnionIds;

		// Token: 0x04006F42 RID: 28482
		private uint _selectedUnionID = 0U;

		// Token: 0x04006F43 RID: 28483
		private GameObject SelectedItem = null;
	}
}
