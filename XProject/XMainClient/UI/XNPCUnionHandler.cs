using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XNPCUnionHandler : DlgHandlerBase
	{

		public uint SelectedUnionID
		{
			get
			{
				return this._selectedUnionID;
			}
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/NPCBlessing/NpcGroupHandler";
			}
		}

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

		protected override void OnShow()
		{
			this.RefreshData();
			this.m_MemberHandler.SetVisible(true);
		}

		public override void RefreshData()
		{
			this.SetupUnionList();
			bool flag = this.m_MemberHandler.IsVisible();
			if (flag)
			{
				this.m_MemberHandler.RefreshData();
			}
		}

		public override void RegisterEvent()
		{
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.UnionWrapListUpdate));
		}

		public override void OnUnload()
		{
			this.m_doc = null;
			DlgHandlerBase.EnsureUnload<XNPCUnionMemSubHandler>(ref this.m_MemberHandler);
			base.OnUnload();
		}

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

		private void OnNotifyRefreshSubHandler()
		{
			bool flag = this.m_MemberHandler.IsVisible();
			if (flag)
			{
				this.m_MemberHandler.RefreshData();
			}
		}

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

		private XNPCFavorDocument m_doc;

		private IXUIScrollView m_ScrollView;

		private IXUIWrapContent m_WrapContent;

		private GameObject m_MemberFrame;

		private XNPCUnionMemSubHandler m_MemberHandler = null;

		private List<uint> m_UnionIds;

		private uint _selectedUnionID = 0U;

		private GameObject SelectedItem = null;
	}
}
