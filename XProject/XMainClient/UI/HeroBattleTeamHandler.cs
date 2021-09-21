using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001799 RID: 6041
	internal class HeroBattleTeamHandler : DlgHandlerBase
	{
		// Token: 0x17003850 RID: 14416
		// (get) Token: 0x0600F976 RID: 63862 RVA: 0x00395A00 File Offset: 0x00393C00
		protected override string FileName
		{
			get
			{
				return "Battle/HeroBattleTeam";
			}
		}

		// Token: 0x0600F977 RID: 63863 RVA: 0x00395A18 File Offset: 0x00393C18
		protected override void Init()
		{
			base.Init();
			this._heroDoc = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
			this._skillDoc = XDocuments.GetSpecificDocument<XHeroBattleSkillDocument>(XHeroBattleSkillDocument.uuID);
			this._mobaDoc = XDocuments.GetSpecificDocument<XMobaBattleDocument>(XMobaBattleDocument.uuID);
			this._skillDoc._HeroBattleTeamHandler = this;
			Transform transform = base.PanelObject.transform.Find("ScrollView/Tpl");
			this.m_MemberPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID(18);
			this._playerNum = expeditionDataByID.PlayerNumber;
			Vector3 tplPos = this.m_MemberPool.TplPos;
			for (int i = 0; i < this._playerNum; i++)
			{
				GameObject gameObject = this.m_MemberPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(tplPos.x, tplPos.y - (float)(i * this.m_MemberPool.TplHeight));
				this._teamList.Add(gameObject);
			}
		}

		// Token: 0x0600F978 RID: 63864 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600F979 RID: 63865 RVA: 0x00395B31 File Offset: 0x00393D31
		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

		// Token: 0x0600F97A RID: 63866 RVA: 0x00395B44 File Offset: 0x00393D44
		public void Refresh()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA;
				if (flag2)
				{
					bool flag3 = this._mobaDoc.MyData == null;
					if (!flag3)
					{
						int num = 0;
						for (int i = 0; i < this._mobaDoc.MobaData.BufferValues.Count; i++)
						{
							bool flag4 = !this._mobaDoc.MobaData.BufferValues[i].isMy && this._mobaDoc.MobaData.BufferValues[i].teamID == this._mobaDoc.MyData.teamID;
							if (flag4)
							{
								this._teamList[num].SetActive(true);
								this.SetMemberSelect(this._teamList[num++], this._mobaDoc.MobaData.BufferValues[i].heroID, this._mobaDoc.MobaData.BufferValues[i].name);
							}
						}
						for (int j = num; j < this._playerNum; j++)
						{
							this._teamList[j].SetActive(false);
						}
					}
				}
				else
				{
					for (int k = 0; k < this._playerNum; k++)
					{
						bool flag5 = k >= this._heroDoc.TeamBlood.Count;
						if (flag5)
						{
							this._teamList[k].SetActive(false);
						}
						else
						{
							this._teamList[k].SetActive(true);
							uint heroID = 0U;
							this._heroDoc.heroIDIndex.TryGetValue(this._heroDoc.TeamBlood[k].uid, out heroID);
							this.SetMemberSelect(this._teamList[k], heroID, this._heroDoc.TeamBlood[k].name);
						}
					}
				}
			}
		}

		// Token: 0x0600F97B RID: 63867 RVA: 0x00395D80 File Offset: 0x00393F80
		public void SetMemberSelect(GameObject go, uint heroID, string name)
		{
			GameObject gameObject = go.transform.Find("Bg/UnSelect").gameObject;
			IXUISprite ixuisprite = go.transform.Find("Bg/Icon").GetComponent("XUISprite") as IXUISprite;
			IXUILabel ixuilabel = go.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(name);
			bool flag = heroID == 0U;
			if (flag)
			{
				gameObject.SetActive(true);
				ixuisprite.SetVisible(false);
			}
			else
			{
				gameObject.SetActive(false);
				ixuisprite.SetVisible(true);
				OverWatchTable.RowData byHeroID = this._heroDoc.OverWatchReader.GetByHeroID(heroID);
				ixuisprite.SetSprite(byHeroID.Icon, byHeroID.IconAtlas, false);
			}
		}

		// Token: 0x0600F97C RID: 63868 RVA: 0x0019EEFD File Offset: 0x0019D0FD
		protected override void OnHide()
		{
			base.OnHide();
		}

		// Token: 0x0600F97D RID: 63869 RVA: 0x00395E43 File Offset: 0x00394043
		public override void OnUnload()
		{
			this._skillDoc._HeroBattleTeamHandler = null;
			base.OnUnload();
		}

		// Token: 0x04006D0B RID: 27915
		private XHeroBattleDocument _heroDoc = null;

		// Token: 0x04006D0C RID: 27916
		private XHeroBattleSkillDocument _skillDoc = null;

		// Token: 0x04006D0D RID: 27917
		private XMobaBattleDocument _mobaDoc = null;

		// Token: 0x04006D0E RID: 27918
		private XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006D0F RID: 27919
		private List<GameObject> _teamList = new List<GameObject>();

		// Token: 0x04006D10 RID: 27920
		private int _playerNum;
	}
}
