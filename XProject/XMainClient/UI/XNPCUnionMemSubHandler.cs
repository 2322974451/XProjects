using System;
using System.Collections.Generic;
using System.Text;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017D8 RID: 6104
	internal class XNPCUnionMemSubHandler : DlgHandlerBase
	{
		// Token: 0x0600FCEE RID: 64750 RVA: 0x003B1A47 File Offset: 0x003AFC47
		public void SetParentHandler(XNPCUnionHandler handler = null)
		{
			this._parentHandler = handler;
		}

		// Token: 0x0600FCEF RID: 64751 RVA: 0x003B1A54 File Offset: 0x003AFC54
		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
			this.m_ScrollView = (base.transform.FindChild("ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("ScrollView/Grid").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_GroupEffectScrollView = (base.transform.FindChild("GroupEffect/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_GroupEffecWrapContent = (base.transform.FindChild("GroupEffect/ScrollView/Grid").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_AttrGrid = (base.transform.FindChild("AttrGrid").GetComponent("XUIList") as IXUIList);
			Transform transform = base.transform.FindChild("AttrGrid/Tpl");
			this.m_AttrPool.SetupPool(this.m_AttrGrid.gameObject, transform.gameObject, 4U, false);
			this.m_NextLevelBtn = (base.transform.FindChild("NextLevelBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ActiveBtn = (base.transform.FindChild("ActiveBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ActiveRedPoint = base.transform.FindChild("ActiveBtn/RedPoint").gameObject;
			this.m_ActiveRedPoint.SetActive(false);
			this.m_ActiveCondition = (base.transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600FCF0 RID: 64752 RVA: 0x001A787A File Offset: 0x001A5A7A
		protected override void OnShow()
		{
			this.RefreshData();
		}

		// Token: 0x0600FCF1 RID: 64753 RVA: 0x003B1BFC File Offset: 0x003AFDFC
		public override void RegisterEvent()
		{
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapListUpdate));
			this.m_GroupEffecWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.GroupEffectUpdate));
			this.m_NextLevelBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickNextLevelBtn));
			this.m_ActiveBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickActiveBtn));
		}

		// Token: 0x0600FCF2 RID: 64754 RVA: 0x003B1C6A File Offset: 0x003AFE6A
		public override void RefreshData()
		{
			this.SetUpItems();
			this.SetUpEffects();
			this.RefreshAttr();
		}

		// Token: 0x0600FCF3 RID: 64755 RVA: 0x003B1C82 File Offset: 0x003AFE82
		public override void OnUnload()
		{
			this._parentHandler = null;
			this.SelectedUnionId = 0U;
		}

		// Token: 0x0600FCF4 RID: 64756 RVA: 0x003B1C94 File Offset: 0x003AFE94
		private void WrapListUpdate(Transform item, int index)
		{
			bool flag = index >= this.m_NpcIds.Count;
			if (flag)
			{
				this.DrawItem(item, 0U, true);
			}
			else
			{
				uint npcid = this.m_NpcIds[index];
				this.DrawItem(item, npcid, false);
			}
		}

		// Token: 0x0600FCF5 RID: 64757 RVA: 0x003B1CDC File Offset: 0x003AFEDC
		private void SetUpItems()
		{
			this.m_NpcIds.Clear();
			this.SelectedUnionId = this._parentHandler.SelectedUnionID;
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
				NpcUniteAttr.RowData unionTableInfoByUnionId = XNPCFavorDocument.GetUnionTableInfoByUnionId(this.SelectedUnionId, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
				bool flag2 = unionTableInfoByUnionId != null;
				if (flag2)
				{
					int i = 0;
					int num = unionTableInfoByUnionId.npcId.Length;
					while (i < num)
					{
						this.m_NpcIds.Add(unionTableInfoByUnionId.npcId[i]);
						i++;
					}
				}
				this.m_WrapContent.SetContentCount(this.m_NpcIds.Count, false);
				this.m_ScrollView.ResetPosition();
			}
		}

		// Token: 0x0600FCF6 RID: 64758 RVA: 0x003B1DAC File Offset: 0x003AFFAC
		private void DrawItem(Transform item, uint npcid, bool isHide = false)
		{
			IXUISprite ixuisprite = item.FindChild("rt/Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = item.FindChild("rt/EquipLevel").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = item.FindChild("rt/wjh").GetComponent("XUILabel") as IXUILabel;
			Transform transform = item.FindChild("rt");
			if (isHide)
			{
				transform.gameObject.SetActive(false);
			}
			else
			{
				transform.gameObject.SetActive(true);
				NpcFeelingOneNpc oneNpc = this.m_doc.GetOneNpc(npcid);
				NpcFeeling.RowData npcTableInfoById = XNPCFavorDocument.GetNpcTableInfoById(npcid);
				bool flag = npcTableInfoById != null;
				if (flag)
				{
					ixuisprite.SetSprite(npcTableInfoById.relicsIcon);
				}
				ixuilabel2.SetText((oneNpc != null) ? string.Empty : XStringDefineProxy.GetString("NPCNotActive2"));
				ixuilabel.SetText((oneNpc != null) ? string.Format("Lv.{0}", oneNpc.level) : string.Empty);
				ixuisprite.ID = (ulong)npcid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickNpc));
			}
		}

		// Token: 0x0600FCF7 RID: 64759 RVA: 0x003B1ED0 File Offset: 0x003B00D0
		private void SetUpEffects()
		{
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
				uint num = (activeUniteInfo == null) ? 0U : XNPCFavorDocument.GetUnionEffectLev(this.SelectedUnionId, activeUniteInfo.level);
				uint num2 = num / 5U;
				this.m_GroupEffecWrapContent.SetContentCount((int)(num2 + 5U), false);
				this.m_GroupEffectScrollView.ResetPosition();
			}
		}

		// Token: 0x0600FCF8 RID: 64760 RVA: 0x003B1F38 File Offset: 0x003B0138
		private void GroupEffectUpdate(Transform item, int index)
		{
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
				uint num = (activeUniteInfo == null) ? 0U : XNPCFavorDocument.GetUnionEffectLev(this.SelectedUnionId, activeUniteInfo.level);
				uint num2 = num / 5U;
				uint num3 = num % 5U;
				uint num4 = 5U - num3;
				bool flag2 = index < (int)(num2 + 5U);
				if (flag2)
				{
					bool flag3 = (long)index < (long)((ulong)num2);
					if (flag3)
					{
						this.DrawEffect(item, 2);
					}
					else
					{
						bool flag4 = index < (int)(num2 + num3);
						if (flag4)
						{
							this.DrawEffect(item, 1);
						}
						else
						{
							bool flag5 = index < (int)(num2 + num3 + num4);
							if (flag5)
							{
								this.DrawEffect(item, 0);
							}
						}
					}
				}
				else
				{
					this.DrawEffect(item, -1);
				}
			}
		}

		// Token: 0x0600FCF9 RID: 64761 RVA: 0x003B1FFC File Offset: 0x003B01FC
		private void DrawEffect(Transform item, int num)
		{
			IXUISprite ixuisprite = item.FindChild("rt/Icon").GetComponent("XUISprite") as IXUISprite;
			Transform transform = item.FindChild("rt");
			switch (num)
			{
			case -1:
				transform.gameObject.SetActive(false);
				break;
			case 0:
				transform.gameObject.SetActive(true);
				ixuisprite.SetAlpha(0f);
				break;
			case 1:
				transform.gameObject.SetActive(true);
				ixuisprite.SetAlpha(1f);
				ixuisprite.SetSprite("Group_0_0");
				break;
			case 2:
				transform.gameObject.SetActive(true);
				ixuisprite.SetAlpha(1f);
				ixuisprite.SetSprite("Group_0_1");
				break;
			}
		}

		// Token: 0x0600FCFA RID: 64762 RVA: 0x003B20C8 File Offset: 0x003B02C8
		private void RefreshAttr()
		{
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				this.m_AttrPool.FakeReturnAll();
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
				NpcUniteAttr.RowData unionTableInfoByUnionId = XNPCFavorDocument.GetUnionTableInfoByUnionId(this.SelectedUnionId, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
				SeqListRef<uint> attr = unionTableInfoByUnionId.Attr;
				for (int i = 0; i < attr.Count; i++)
				{
					GameObject gameObject = this.m_AttrPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_AttrGrid.gameObject.transform;
					gameObject.transform.localScale = Vector3.one;
					uint attrValue = (activeUniteInfo == null) ? 0U : attr[i, 1];
					this.DrawAttr(gameObject.transform, attr[i, 0], attrValue);
				}
				this.m_AttrPool.ActualReturnAll(false);
				this.m_AttrGrid.Refresh();
				NpcUniteAttr.RowData nextUnionDataByUnionId = XNPCFavorDocument.GetNextUnionDataByUnionId(this.SelectedUnionId, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
				bool flag2 = nextUnionDataByUnionId != null;
				if (flag2)
				{
					this.m_ActiveCondition.SetText(string.Format(XStringDefineProxy.GetString("NPCUnionActiveCondition"), nextUnionDataByUnionId.level));
				}
				this.m_ActiveRedPoint.SetActive(this.m_doc.IsUnionCanActiveNextLevel(this.SelectedUnionId));
			}
		}

		// Token: 0x0600FCFB RID: 64763 RVA: 0x003B222C File Offset: 0x003B042C
		private void DrawAttr(Transform item, uint attrId, uint attrValue)
		{
			IXUILabel ixuilabel = item.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = item.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XAttributeCommon.GetAttrStr((int)attrId));
			ixuilabel2.SetText(XAttributeCommon.GetAttrValueStr(attrId, attrValue, true));
		}

		// Token: 0x0600FCFC RID: 64764 RVA: 0x003B228C File Offset: 0x003B048C
		private void OnClickNpc(IXUISprite sp)
		{
			uint npcId = (uint)sp.ID;
			bool flag = this.m_doc.View.IsVisible();
			if (flag)
			{
				this.m_doc.View.SkipToNpc(npcId);
			}
		}

		// Token: 0x0600FCFD RID: 64765 RVA: 0x003B22C8 File Offset: 0x003B04C8
		private bool OnClickNextLevelBtn(IXUIButton btn)
		{
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
				NpcUniteAttr.RowData nextUnionDataByUnionId = XNPCFavorDocument.GetNextUnionDataByUnionId(this.SelectedUnionId, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
				bool flag2 = nextUnionDataByUnionId != null;
				if (flag2)
				{
					string @string = XStringDefineProxy.GetString("NPCNextAddition");
					SeqListRef<uint> attr = nextUnionDataByUnionId.Attr;
					StringBuilder sb = XNPCFavorDocument.sb;
					sb.Length = 0;
					for (int i = 0; i < attr.Count; i++)
					{
						uint attrid = attr[i, 0];
						uint attrValue = attr[i, 1];
						bool flag3 = i != 0;
						if (flag3)
						{
							sb.Append("\n");
						}
						sb.Append(string.Format("{0}{1}", XAttributeCommon.GetAttrStr((int)attrid), XAttributeCommon.GetAttrValueStr(attrid, attrValue, true)));
					}
					string label = sb.ToString();
					XSingleton<UiUtility>.singleton.ShowModalDialogWithTitle(@string, label, XStringDefineProxy.GetString(XStringDefine.COMMON_OK), null, 50);
				}
			}
			return true;
		}

		// Token: 0x0600FCFE RID: 64766 RVA: 0x003B23DC File Offset: 0x003B05DC
		private bool OnClickActiveBtn(IXUIButton btn)
		{
			bool flag = this.SelectedUnionId > 0U;
			if (flag)
			{
				bool flag2 = this.m_doc.IsUnionCanActiveNextLevel(this.SelectedUnionId);
				if (flag2)
				{
					NpcFeelingUnite activeUniteInfo = this.m_doc.GetActiveUniteInfo(this.SelectedUnionId);
					NpcUniteAttr.RowData nextUnionDataByUnionId = XNPCFavorDocument.GetNextUnionDataByUnionId(this.SelectedUnionId, (activeUniteInfo == null) ? 0U : activeUniteInfo.level);
					bool flag3 = nextUnionDataByUnionId != null;
					if (flag3)
					{
						this.m_doc.ReqSrvActiveUnionLevel(this.SelectedUnionId, nextUnionDataByUnionId.level);
					}
				}
				else
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("NPCUnionNotReachActive"), "fece00");
				}
			}
			return true;
		}

		// Token: 0x04006F44 RID: 28484
		private XNPCUnionHandler _parentHandler = null;

		// Token: 0x04006F45 RID: 28485
		private XNPCFavorDocument m_doc;

		// Token: 0x04006F46 RID: 28486
		private IXUIScrollView m_ScrollView;

		// Token: 0x04006F47 RID: 28487
		private IXUIWrapContent m_WrapContent;

		// Token: 0x04006F48 RID: 28488
		private IXUIScrollView m_GroupEffectScrollView;

		// Token: 0x04006F49 RID: 28489
		private IXUIWrapContent m_GroupEffecWrapContent;

		// Token: 0x04006F4A RID: 28490
		private IXUIList m_AttrGrid;

		// Token: 0x04006F4B RID: 28491
		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006F4C RID: 28492
		private IXUIButton m_NextLevelBtn;

		// Token: 0x04006F4D RID: 28493
		private IXUIButton m_ActiveBtn;

		// Token: 0x04006F4E RID: 28494
		private GameObject m_ActiveRedPoint;

		// Token: 0x04006F4F RID: 28495
		private List<uint> m_NpcIds = new List<uint>();

		// Token: 0x04006F50 RID: 28496
		private uint SelectedUnionId = 0U;

		// Token: 0x04006F51 RID: 28497
		private IXUILabel m_ActiveCondition;

		// Token: 0x04006F52 RID: 28498
		private const int GROUP_NUM = 5;
	}
}
