using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016DD RID: 5853
	internal class XDragonHistoryHandler : DlgHandlerBase
	{
		// Token: 0x0600F16E RID: 61806 RVA: 0x00354904 File Offset: 0x00352B04
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XDragonPartnerDocument>(XDragonPartnerDocument.uuID);
			this._dnDoc = XDocuments.GetSpecificDocument<XDragonNestDocument>(XDragonNestDocument.uuID);
			this._expDoc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			Transform transform = base.transform.Find("Member/Member/List");
			int childCount = transform.childCount;
			this._avatarList = new Transform[childCount];
			for (int i = 0; i < childCount; i++)
			{
				this._avatarList[i] = transform.Find(XSingleton<XCommon>.singleton.StringCombine("Avatar", i.ToString()));
			}
			this._EmptyDetail = base.transform.Find("Member/EmptyDetail");
			this._EmptyMember = base.transform.Find("Member/EmptyMember");
			this._DetailScrollView = (base.transform.Find("Detail").GetComponent("XUIScrollView") as IXUIScrollView);
			this._DetailWrapContent = (base.transform.Find("Detail/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this._DetailWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnDetailWrapContentUpdate));
		}

		// Token: 0x0600F16F RID: 61807 RVA: 0x00354A31 File Offset: 0x00352C31
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
			this._doc.SendDragonGroupRecord();
		}

		// Token: 0x0600F170 RID: 61808 RVA: 0x00354A4E File Offset: 0x00352C4E
		public override void OnUnload()
		{
			this._avatarList = null;
			base.OnUnload();
		}

		// Token: 0x0600F171 RID: 61809 RVA: 0x00354A5F File Offset: 0x00352C5F
		public override void RefreshData()
		{
			this.SetupDetailList();
			this.SetupSelectMember(0);
		}

		// Token: 0x0600F172 RID: 61810 RVA: 0x00354A74 File Offset: 0x00352C74
		private void SetupSelectMember(int index = 0)
		{
			bool flag = this._avatarList == null;
			if (!flag)
			{
				bool flag2 = this._RoleInfoList == null;
				if (flag2)
				{
					this._RoleInfoList = new List<DragonGroupRoleInfo>();
				}
				this._RoleInfoList.Clear();
				bool active = false;
				bool flag3 = this._RecordList != null && index >= 0 && index < this._RecordList.Count;
				if (flag3)
				{
					int i = 0;
					int count = this._RecordList[index].roleinfo.Count;
					while (i < count)
					{
						bool flag4 = this._RecordList[index].roleinfo[i].roleid == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (!flag4)
						{
							this._RoleInfoList.Add(this._RecordList[index].roleinfo[i]);
						}
						i++;
					}
					active = (this._RecordList[index].iswin && this._RoleInfoList.Count == 0);
				}
				int count2 = this._RoleInfoList.Count;
				this._EmptyMember.gameObject.SetActive(active);
				int j = 0;
				int num = this._avatarList.Length;
				while (j < num)
				{
					bool flag5 = j < count2;
					if (flag5)
					{
						this._avatarList[j].gameObject.SetActive(true);
						this.OnMemberWrapContentUpdate(this._avatarList[j], j);
					}
					else
					{
						this._avatarList[j].gameObject.SetActive(false);
					}
					j++;
				}
			}
		}

		// Token: 0x0600F173 RID: 61811 RVA: 0x00354C20 File Offset: 0x00352E20
		private void OnSelectDetail(IXUISprite sprite)
		{
			bool flag = this._SelectItemGB != sprite.gameObject && this._SelectItemGB != null && !this._SelectItemGB.activeSelf;
			if (flag)
			{
				this.ForceSetToggleFlag(this._SelectItemGB, false);
			}
			bool flag2 = null == this._SelectItemGB;
			this._SelectItemGB = sprite.gameObject;
			bool flag3 = flag2;
			if (flag3)
			{
				this.ForceSetToggleFlag(this._SelectItemGB, true);
			}
			int num = (int)sprite.ID;
			this.SetupSelectMember(num);
			this._selectedIndex = num;
		}

		// Token: 0x0600F174 RID: 61812 RVA: 0x00354CB8 File Offset: 0x00352EB8
		private void ForceSetToggleFlag(GameObject obj, bool flag)
		{
			bool flag2 = obj == null;
			if (!flag2)
			{
				IXUICheckBox ixuicheckBox = obj.GetComponent("XUICheckBox") as IXUICheckBox;
				bool flag3 = ixuicheckBox != null;
				if (flag3)
				{
					ixuicheckBox.ForceSetFlag(flag);
				}
			}
		}

		// Token: 0x0600F175 RID: 61813 RVA: 0x00354CF4 File Offset: 0x00352EF4
		private void OnMemberWrapContentUpdate(Transform t, int index)
		{
			bool flag = this._RoleInfoList == null || this._RoleInfoList.Count < index;
			if (!flag)
			{
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Name").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
				IXUISprite ixuisprite3 = t.Find("Profession").GetComponent("XUISprite") as IXUISprite;
				DragonGroupRoleInfo dragonGroupRoleInfo = this._RoleInfoList[index];
				ixuisprite.ID = dragonGroupRoleInfo.roleid;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickAvatar));
				ixuilabel.SetText(dragonGroupRoleInfo.rolename);
				ixuisprite2.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2((int)dragonGroupRoleInfo.profession));
				ixuisprite3.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)dragonGroupRoleInfo.profession));
			}
		}

		// Token: 0x0600F176 RID: 61814 RVA: 0x00354DF8 File Offset: 0x00352FF8
		private void SetupDetailList()
		{
			this._RecordList = this._doc.RecordList;
			bool flag = this._RecordList == null || this._RecordList.Count == 0;
			if (flag)
			{
				this._DetailWrapContent.SetContentCount(0, false);
			}
			else
			{
				this._DetailWrapContent.SetContentCount(this._RecordList.Count, false);
			}
			this._EmptyDetail.gameObject.SetActive(this._RecordList == null || this._RecordList.Count == 0);
			this._DetailScrollView.ResetPosition();
		}

		// Token: 0x0600F177 RID: 61815 RVA: 0x00354E98 File Offset: 0x00353098
		private void OnDetailWrapContentUpdate(Transform t, int index)
		{
			bool flag = this._RecordList == null || index >= this._RecordList.Count;
			if (!flag)
			{
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				IXUILabel ixuilabel = t.Find("Info/Date").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Info/Year").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.Find("Info/Period").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.Find("Info/StageName").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite2 = t.Find("Info/AvatarBG/NestTpl/Bg/Icon").GetComponent("XUISprite") as IXUISprite;
				IXUITexture ixuitexture = t.Find("Info/AvatarBG/NestTpl/Boss").GetComponent("XUITexture") as IXUITexture;
				Transform transform = t.Find("Info/AvatarBG/NestTpl/Bg");
				DragonGroupRecordInfoList dragonGroupRecordInfoList = this._RecordList[index];
				IXUILabel ixuilabel5 = t.Find("Info/AvatarBG/NestTpl/Succeed").GetComponent("XUILabel") as IXUILabel;
				ixuilabel5.gameObject.SetActive(dragonGroupRecordInfoList.iswin);
				IXUILabel ixuilabel6 = t.Find("Desc/Watch/Text").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel7 = t.Find("Desc/Commend/Text").GetComponent("XUILabel") as IXUILabel;
				Transform transform2 = t.Find("Medal/FirstDown");
				Transform transform3 = t.Find("Medal/FirstPass");
				IXUIList ixuilist = t.Find("Grid").GetComponent("XUIList") as IXUIList;
				Transform transform4 = t.Find("Grid/Text1");
				Transform transform5 = t.Find("Grid/Text2");
				ixuilabel3.SetText(XSingleton<UiUtility>.singleton.TimeDuarationFormatString((int)dragonGroupRecordInfoList.costtime, 5));
				DateTime dateTime = XSingleton<UiUtility>.singleton.TimeNow(dragonGroupRecordInfoList.time, true);
				ixuilabel2.SetText(dateTime.ToString("yyyy"));
				ixuilabel.SetText(dateTime.ToString("MM.dd"));
				ExpeditionTable.RowData expeditionDataByID = this._expDoc.GetExpeditionDataByID((int)dragonGroupRecordInfoList.stageid);
				DragonNestTable.RowData dragonNestByID = this._dnDoc.GetDragonNestByID(dragonGroupRecordInfoList.stageid);
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnSelectDetail));
				bool flag2 = this._SelectItemGB == null && index == 0;
				if (flag2)
				{
					this.OnSelectDetail(ixuisprite);
				}
				this.ForceSetToggleFlag(ixuisprite.gameObject, this._selectedIndex == index);
				bool flag3 = expeditionDataByID != null && dragonNestByID != null;
				if (flag3)
				{
					ixuilabel4.SetText(XExpeditionDocument.GetFullName(expeditionDataByID));
					bool flag4 = (ulong)dragonNestByID.DragonNestWave == (ulong)((long)this._dnDoc.DragonNestBOSSWave);
					if (flag4)
					{
						ixuitexture.gameObject.SetActive(true);
						transform.gameObject.SetActive(false);
						ixuitexture.SetTexturePath(dragonNestByID.DragonNestIcon);
						ixuisprite2.SetSprite("");
					}
					else
					{
						ixuitexture.gameObject.SetActive(false);
						transform.gameObject.SetActive(true);
						ixuitexture.SetTexturePath("");
						ixuisprite2.SetSprite(dragonNestByID.DragonNestIcon, dragonNestByID.DragonNestAtlas, false);
					}
				}
				else
				{
					ixuitexture.SetTexturePath("");
					ixuilabel4.SetText("");
					ixuisprite2.SetSprite("");
				}
				ixuilabel6.SetText(XSingleton<XCommon>.singleton.StringCombine(dragonGroupRecordInfoList.watchnum.ToString(), XStringDefineProxy.GetString("Spectate_times")));
				ixuilabel7.SetText(XSingleton<XCommon>.singleton.StringCombine(dragonGroupRecordInfoList.commendnum.ToString(), XStringDefineProxy.GetString("Spectate_times")));
				transform4.gameObject.SetActive(dragonGroupRecordInfoList.ismostwatchnum);
				transform5.gameObject.SetActive(dragonGroupRecordInfoList.ismostcommendnum);
				ixuilist.Refresh();
				transform2.gameObject.SetActive(dragonGroupRecordInfoList.iswin && dragonGroupRecordInfoList.isFirstPass && !dragonGroupRecordInfoList.isServerFirstPass);
				transform3.gameObject.SetActive(dragonGroupRecordInfoList.iswin && dragonGroupRecordInfoList.isServerFirstPass);
			}
		}

		// Token: 0x0600F178 RID: 61816 RVA: 0x003552EC File Offset: 0x003534EC
		private void OnClickAvatar(IXUISprite sp)
		{
			ulong id = sp.ID;
			XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
		}

		// Token: 0x04006725 RID: 26405
		private IXUIWrapContent _DetailWrapContent;

		// Token: 0x04006726 RID: 26406
		private IXUIScrollView _DetailScrollView;

		// Token: 0x04006727 RID: 26407
		private List<DragonGroupRecordInfoList> _RecordList;

		// Token: 0x04006728 RID: 26408
		private List<DragonGroupRoleInfo> _RoleInfoList;

		// Token: 0x04006729 RID: 26409
		private XExpeditionDocument _expDoc = null;

		// Token: 0x0400672A RID: 26410
		private XDragonNestDocument _dnDoc = null;

		// Token: 0x0400672B RID: 26411
		private XDragonPartnerDocument _doc = null;

		// Token: 0x0400672C RID: 26412
		private Transform[] _avatarList;

		// Token: 0x0400672D RID: 26413
		private Transform _EmptyDetail;

		// Token: 0x0400672E RID: 26414
		private Transform _EmptyMember;

		// Token: 0x0400672F RID: 26415
		private GameObject _SelectItemGB;

		// Token: 0x04006730 RID: 26416
		private int _selectedIndex = -1;
	}
}
