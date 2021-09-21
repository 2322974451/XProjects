using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D5 RID: 6101
	internal class XNPCFavorHandler : DlgHandlerBase
	{
		// Token: 0x170038AA RID: 14506
		// (get) Token: 0x0600FCC5 RID: 64709 RVA: 0x003B041C File Offset: 0x003AE61C
		protected override string FileName
		{
			get
			{
				return "GameSystem/NpcBlessing/NpcEquipHandler";
			}
		}

		// Token: 0x0600FCC6 RID: 64710 RVA: 0x003B0434 File Offset: 0x003AE634
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.m_SendFrame = base.PanelObject.transform.Find("NpcInfo").gameObject;
			DlgHandlerBase.EnsureCreate<XNPCSendSubHandler>(ref this.m_SendHandler, this.m_SendFrame, this, false);
			this.m_SendHandler.SetParentHandler(this);
			this.m_ScrollView = (base.PanelObject.transform.Find("Npc/NpcScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.PanelObject.transform.Find("Npc/NpcScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x0600FCC7 RID: 64711 RVA: 0x003B04EE File Offset: 0x003AE6EE
		protected override void OnShow()
		{
			this.RefreshData();
			this.m_SendHandler.SetVisible(true);
		}

		// Token: 0x0600FCC8 RID: 64712 RVA: 0x003B0508 File Offset: 0x003AE708
		public override void RefreshData()
		{
			this.SetupNPCList();
			bool flag = this.m_SendHandler.IsVisible();
			if (flag)
			{
				this.m_SendHandler.RefreshData();
			}
		}

		// Token: 0x0600FCC9 RID: 64713 RVA: 0x003B0538 File Offset: 0x003AE738
		public override void RegisterEvent()
		{
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.NPCWrapListUpdate));
		}

		// Token: 0x0600FCCA RID: 64714 RVA: 0x003B0554 File Offset: 0x003AE754
		protected override void OnHide()
		{
			bool flag = this.m_doc != null;
			if (flag)
			{
				this.m_doc.RemoveAllNewTags();
			}
		}

		// Token: 0x0600FCCB RID: 64715 RVA: 0x003B057B File Offset: 0x003AE77B
		public override void OnUnload()
		{
			this.m_doc = null;
			this.m_NpcBaseDatas = null;
			this._selectedNPCID = 0U;
			this.SelectedItem = null;
			DlgHandlerBase.EnsureUnload<XNPCSendSubHandler>(ref this.m_SendHandler);
			base.OnUnload();
		}

		// Token: 0x0600FCCC RID: 64716 RVA: 0x003B05B0 File Offset: 0x003AE7B0
		private void SetupNPCList()
		{
			this.m_NpcBaseDatas = this.m_doc.NPCIds;
			bool flag = this.m_NpcBaseDatas != null;
			if (flag)
			{
				this.m_WrapContent.SetContentCount(this.m_NpcBaseDatas.Count, false);
				this.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x0600FCCD RID: 64717 RVA: 0x003B0604 File Offset: 0x003AE804
		private void NPCWrapListUpdate(Transform item, int index)
		{
			bool flag = this.m_NpcBaseDatas == null || index >= this.m_NpcBaseDatas.Count;
			if (!flag)
			{
				IXUILabel ixuilabel = item.FindChild("NpcName").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = item.FindChild("NpcHead").GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel2 = item.FindChild("NoActive").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = item.FindChild("JinDu").gameObject;
				IXUIProgress ixuiprogress = item.FindChild("JinDu/Progress Bar").GetComponent("XUIProgress") as IXUIProgress;
				IXUILabel ixuilabel3 = item.FindChild("JinDu/Value").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = item.FindChild("JinDu/ValueMax").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = item.FindChild("GroupIcon").GetComponent("XUISprite") as IXUISprite;
				GameObject gameObject2 = item.FindChild("RedPoint").gameObject;
				uint num = this.m_NpcBaseDatas[index];
				NpcFeeling.RowData npcTableInfoById = XNPCFavorDocument.GetNpcTableInfoById(num);
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(num);
				GameObject gameObject3 = item.FindChild("New").gameObject;
				ixuilabel.SetText(npcTableInfoById.name.ToString());
				bool flag2 = oneNpc != null;
				if (flag2)
				{
					gameObject.SetActive(true);
					ixuilabel2.SetText(string.Empty);
					ixuilabel3.SetText(oneNpc.exp.ToString());
					NpcFeelingAttr.RowData attrDataByLevel = XNPCFavorDocument.GetAttrDataByLevel(oneNpc.npcid, oneNpc.level);
					uint num2 = (attrDataByLevel == null) ? 0U : attrDataByLevel.needExp;
					NpcFeelingAttr.RowData attrDataByLevel2 = XNPCFavorDocument.GetAttrDataByLevel(oneNpc.npcid, oneNpc.level + 1U);
					uint num3 = 0U;
					bool active = false;
					bool flag3 = attrDataByLevel2 != null;
					if (flag3)
					{
						num3 = attrDataByLevel2.needExp - num2;
						active = (oneNpc.exp >= num3 && oneNpc.level < this.m_doc.NpcFlLevTop);
					}
					ixuilabel4.SetText(string.Format("/{0}", num3));
					ixuiprogress.value = ((num3 == 0U) ? 0f : (oneNpc.exp * 1f / num3));
					gameObject3.SetActive(oneNpc.isnew);
					gameObject2.SetActive(active);
					ixuisprite2.SetColor(Color.white);
				}
				else
				{
					gameObject.SetActive(false);
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("NPCUnLock"), npcTableInfoById.openLevel));
					gameObject3.SetActive(false);
					gameObject2.SetActive(false);
					ixuisprite2.SetColor(Color.black);
				}
				ixuisprite.SetColor((oneNpc != null) ? Color.white : Color.black);
				ixuisprite.SetSprite(npcTableInfoById.icon);
				ixuisprite2.SetSprite(string.Format("Group_{0}_0", npcTableInfoById.unionId - 1U));
				IXUIButton ixuibutton = item.GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)num;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelectNPC));
				bool flag4 = this._selectedNPCID == 0U && index == 0;
				if (flag4)
				{
					this.OnSelectNPC(ixuibutton);
				}
				this.ToggleSelection(item.gameObject, num == this._selectedNPCID);
			}
		}

		// Token: 0x0600FCCE RID: 64718 RVA: 0x003B0984 File Offset: 0x003AEB84
		private bool OnSelectNPC(IXUIButton btn)
		{
			uint num = (uint)btn.ID;
			bool flag = this._selectedNPCID == num;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._selectedNPCID = num;
				bool flag2 = this.SelectedItem != null;
				if (flag2)
				{
					this.ToggleSelection(this.SelectedItem, false);
				}
				this.ToggleSelection(btn.gameObject, true);
				this.OnNotifyRefreshSubHandler();
				result = true;
			}
			return result;
		}

		// Token: 0x0600FCCF RID: 64719 RVA: 0x003B09EC File Offset: 0x003AEBEC
		public void SkipToNpc(uint npcId)
		{
			bool flag = this.m_NpcBaseDatas == null;
			if (!flag)
			{
				this._selectedNPCID = npcId;
				bool flag2 = this.m_NpcBaseDatas.Count > 4;
				if (flag2)
				{
					int num = 1;
					for (int i = 0; i < this.m_NpcBaseDatas.Count; i++)
					{
						bool flag3 = this.m_NpcBaseDatas[i] == npcId;
						if (flag3)
						{
							break;
						}
						num++;
					}
					float position = Mathf.Clamp01(((float)num - 2f) * 1f / (float)(this.m_NpcBaseDatas.Count - 4));
					this.m_ScrollView.SetPosition(position);
				}
				this.m_WrapContent.SetContentCount(this.m_NpcBaseDatas.Count, false);
				bool flag4 = this.m_SendHandler.IsVisible();
				if (flag4)
				{
					this.m_SendHandler.RefreshData();
				}
			}
		}

		// Token: 0x0600FCD0 RID: 64720 RVA: 0x003B0AD4 File Offset: 0x003AECD4
		private void OnNotifyRefreshSubHandler()
		{
			bool flag = this.m_SendHandler.IsVisible();
			if (flag)
			{
				this.m_SendHandler.RefreshData();
			}
		}

		// Token: 0x0600FCD1 RID: 64721 RVA: 0x003B0B00 File Offset: 0x003AED00
		private void ToggleSelection(GameObject go, bool bSelect)
		{
			Transform transform = go.transform.FindChild("Select");
			bool flag = transform != null;
			if (flag)
			{
				GameObject gameObject = transform.gameObject;
				bool flag2 = gameObject != null;
				if (flag2)
				{
					gameObject.SetActive(bSelect);
				}
			}
			if (bSelect)
			{
				this.SelectedItem = go;
			}
		}

		// Token: 0x04006F24 RID: 28452
		private XNPCFavorDocument m_doc;

		// Token: 0x04006F25 RID: 28453
		private const int MODIFYNUM = 4;

		// Token: 0x04006F26 RID: 28454
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006F27 RID: 28455
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006F28 RID: 28456
		private GameObject m_SendFrame;

		// Token: 0x04006F29 RID: 28457
		private XNPCSendSubHandler m_SendHandler = null;

		// Token: 0x04006F2A RID: 28458
		public uint _selectedNPCID = 0U;

		// Token: 0x04006F2B RID: 28459
		private GameObject SelectedItem = null;

		// Token: 0x04006F2C RID: 28460
		private List<uint> m_NpcBaseDatas = null;
	}
}
