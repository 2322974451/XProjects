using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HeroBattleTeamHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/HeroBattleTeam";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.Refresh();
		}

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

		protected override void OnHide()
		{
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._skillDoc._HeroBattleTeamHandler = null;
			base.OnUnload();
		}

		private XHeroBattleDocument _heroDoc = null;

		private XHeroBattleSkillDocument _skillDoc = null;

		private XMobaBattleDocument _mobaDoc = null;

		private XUIPool m_MemberPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<GameObject> _teamList = new List<GameObject>();

		private int _playerNum;
	}
}
