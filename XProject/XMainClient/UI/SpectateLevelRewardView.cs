using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001855 RID: 6229
	internal class SpectateLevelRewardView : DlgBase<SpectateLevelRewardView, SpectateLevelRewardBehaviour>
	{
		// Token: 0x17003973 RID: 14707
		// (get) Token: 0x0601031D RID: 66333 RVA: 0x003E43F4 File Offset: 0x003E25F4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003974 RID: 14708
		// (get) Token: 0x0601031E RID: 66334 RVA: 0x003E4408 File Offset: 0x003E2608
		public override string fileName
		{
			get
			{
				return "Battle/SpectateLevelReward";
			}
		}

		// Token: 0x0601031F RID: 66335 RVA: 0x003E441F File Offset: 0x003E261F
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XSpectateLevelRewardDocument>(XSpectateLevelRewardDocument.uuID);
			base.uiBehaviour.m_GoOnBtnText.SetText(XStringDefineProxy.GetString("Spectate_Goon"));
		}

		// Token: 0x06010320 RID: 66336 RVA: 0x003E444D File Offset: 0x003E264D
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BackToMainCityBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.BackToMainCityBtnClick));
			base.uiBehaviour.m_GoOnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGoOnBtnClick));
		}

		// Token: 0x06010321 RID: 66337 RVA: 0x003E448A File Offset: 0x003E268A
		public void BackToMainCityBtnClick(IXUISprite btn)
		{
			this._doc.LevelScene();
		}

		// Token: 0x06010322 RID: 66338 RVA: 0x003E4499 File Offset: 0x003E2699
		public void OnGoOnBtnClick(IXUISprite iSp)
		{
			this.SetVisible(false, true);
			DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisible(true, true);
		}

		// Token: 0x06010323 RID: 66339 RVA: 0x001EA11D File Offset: 0x001E831D
		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		// Token: 0x06010324 RID: 66340 RVA: 0x003E44B4 File Offset: 0x003E26B4
		protected override void OnShow()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(false, true);
			}
		}

		// Token: 0x06010325 RID: 66341 RVA: 0x003E44E0 File Offset: 0x003E26E0
		public void ShowData()
		{
			bool flag = DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded() && DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.m_XOptionBattleHandler != null && DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.m_XOptionBattleHandler.IsVisible();
				if (flag2)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.m_XOptionBattleHandler.OnCloseClicked(null);
				}
				this.SetVisibleWithAnimation(true, null);
				base.uiBehaviour.m_MVP.SetActive(false);
				this.MemberAndSplitHeight = base.uiBehaviour.MemberHeight;
				base.uiBehaviour.m_WatchNum.SetText(this._doc.WatchNum.ToString());
				base.uiBehaviour.m_CommendNum.SetText(this._doc.CommendNum.ToString());
				this.InitPool();
				this.SetTitle();
				this.SetMember();
			}
		}

		// Token: 0x06010326 RID: 66342 RVA: 0x003E45C4 File Offset: 0x003E27C4
		public void InitPool()
		{
			base.uiBehaviour.m_TitlePool.ReturnAll(true);
			base.uiBehaviour.m_MemberPool.ReturnAll(true);
			base.uiBehaviour.m_DetailPool.ReturnAll(true);
			base.uiBehaviour.m_SplitPool.ReturnAll(true);
			base.uiBehaviour.m_LabelPool.ReturnAll(true);
			base.uiBehaviour.m_StarPool.ReturnAll(true);
			base.uiBehaviour.m_WinLosePool.ReturnAll(true);
		}

		// Token: 0x06010327 RID: 66343 RVA: 0x003E4650 File Offset: 0x003E2850
		public void SetTitle()
		{
			int num = -this._doc.WidthTotal / 2;
			bool flag = this._doc.DataType != null;
			if (flag)
			{
				for (int i = 0; i < this._doc.DataType.Length; i++)
				{
					bool flag2 = this._doc.WidthList[i] == 0;
					if (!flag2)
					{
						GameObject gameObject = base.uiBehaviour.m_TitlePool.FetchGameObject(false);
						gameObject.transform.parent = base.uiBehaviour.m_TitleParent;
						Vector3 localPosition = gameObject.transform.localPosition;
						localPosition.x = (float)(num + this._doc.WidthList[i] / 2);
						gameObject.transform.localPosition = localPosition;
						IXUILabel ixuilabel = gameObject.GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(XSingleton<XStringTable>.singleton.GetString(string.Format("SpectateLevelRewardTitle{0}", this._doc.DataType[i])));
						IXUISprite ixuisprite = gameObject.transform.Find("Button").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.spriteWidth = this._doc.WidthList[i] - 4;
						num += this._doc.WidthList[i];
					}
				}
			}
		}

		// Token: 0x06010328 RID: 66344 RVA: 0x003E47BC File Offset: 0x003E29BC
		public void SetMember()
		{
			int num = -this._doc.WidthTotal / 2;
			int num2 = base.uiBehaviour.MemberStartY;
			for (int i = 0; i < this._doc.DataList.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_MemberPool.FetchGameObject(true);
				gameObject.transform.parent = base.uiBehaviour.m_MemberParent;
				gameObject.transform.localPosition = new Vector3(0f, (float)num2, 0f);
				IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.spriteWidth = this._doc.WidthTotal;
				bool flag = this._doc.DataType != null;
				if (flag)
				{
					for (int j = 0; j < this._doc.DataType.Length; j++)
					{
						switch (this._doc.DataType[j])
						{
						case 3:
							this.SetHeadIcon(num, i, this._doc.WidthList[j], gameObject);
							break;
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
							this.SetJustText(num, i, this._doc.DataType[j], this._doc.WidthList[j], gameObject);
							break;
						case 11:
							this.SetStar(num, i, this._doc.WidthList[j], gameObject);
							break;
						case 12:
							this.SetWinLose(num, i, this._doc.WidthList[j], gameObject);
							break;
						case 13:
							this.SetMvp(num, i, this._doc.WidthList[j], gameObject);
							break;
						}
						num += this._doc.WidthList[j];
						bool flag2 = j != this._doc.DataType.Length - 1;
						if (flag2)
						{
							GameObject gameObject2 = base.uiBehaviour.m_SplitPool.FetchGameObject(false);
							gameObject2.transform.parent = gameObject.transform;
							gameObject2.transform.localPosition = new Vector3((float)(num - 1), 0f, 0f);
						}
					}
				}
				num = -this._doc.WidthTotal / 2;
				num2 -= this.MemberAndSplitHeight;
				XSingleton<XGameUI>.singleton.m_uiTool.MarkParentAsChanged(gameObject);
			}
		}

		// Token: 0x06010329 RID: 66345 RVA: 0x003E4A50 File Offset: 0x003E2C50
		public void SetHeadIcon(int x, int index, int width, GameObject parentGo)
		{
			GameObject gameObject = base.uiBehaviour.m_DetailPool.FetchGameObject(false);
			gameObject.transform.parent = parentGo.transform;
			gameObject.transform.localPosition = new Vector3((float)(x + width / 2), 0f, 0f);
			XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
			bool flag = true;
			bool flag2 = !specificDocument.IsBlueTeamDict.TryGetValue(this._doc.DataList[index].roleid, out flag);
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("spectate level reward can't find this player's team, player name = ", this._doc.DataList[index].name, null, null, null, null);
			}
			string text = string.Format("{0}{1}", flag ? "[00bdff]" : "[ff0000]", this._doc.DataList[index].name);
			IXUILabel ixuilabel = gameObject.transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(text);
			IXUISprite ixuisprite = gameObject.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteName = XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon((int)this._doc.DataList[index].profession);
			GameObject gameObject2 = gameObject.transform.Find("Avatar/Leader").gameObject;
			gameObject2.SetActive(this._doc.DataList[index].type == 1U);
			IXUISprite ixuisprite2 = gameObject.transform.Find("AddFriend/Add").GetComponent("XUISprite") as IXUISprite;
			ixuisprite2.ID = this._doc.DataList[index].roleid;
			ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnAddFriendClick));
		}

		// Token: 0x0601032A RID: 66346 RVA: 0x003E4C38 File Offset: 0x003E2E38
		private void SetJustText(int x, int index, int type, int width, GameObject parentGo)
		{
			GameObject gameObject = base.uiBehaviour.m_LabelPool.FetchGameObject(false);
			gameObject.transform.parent = parentGo.transform;
			gameObject.transform.localPosition = new Vector3((float)(x + width / 2), 0f, 0f);
			IXUILabel ixuilabel = gameObject.GetComponent("XUILabel") as IXUILabel;
			switch (type)
			{
			case 5:
				ixuilabel.SetText(this._doc.DataList[index].killcount.ToString());
				break;
			case 6:
				ixuilabel.SetText(this._doc.DataList[index].damageall.ToString("0.0"));
				break;
			case 7:
				ixuilabel.SetText(string.Format("{0}%", ((this._doc.DamageSum < 1.0) ? 0.0 : (this._doc.DataList[index].damageall * 100.0 / this._doc.DamageSum)).ToString("0.0")));
				break;
			case 8:
				ixuilabel.SetText(this._doc.DataList[index].treatcount.ToString());
				break;
			case 9:
				ixuilabel.SetText(this._doc.DataList[index].deadcount.ToString());
				break;
			case 10:
				ixuilabel.SetText(this._doc.DataList[index].combomax.ToString());
				break;
			}
		}

		// Token: 0x0601032B RID: 66347 RVA: 0x003E4E08 File Offset: 0x003E3008
		private void SetStar(int x, int index, int width, GameObject parentGo)
		{
			uint num = 0U;
			bool flag = !this._doc.StarDict.TryGetValue(this._doc.DataList[index].roleid, out num);
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog("spectate level reward can't find this player' star, player name = ", this._doc.DataList[index].name, " maybe nest fail.", null, null, null, XDebugColor.XDebug_None);
			}
			int num2 = this.CalStarNum((int)num);
			int num3 = x + width / 2 - base.uiBehaviour.m_StarPool.TplWidth;
			for (int i = 0; i < 3; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_StarPool.FetchGameObject(false);
				gameObject.transform.parent = parentGo.transform;
				gameObject.transform.localPosition = new Vector3((float)(num3 + i * base.uiBehaviour.m_StarPool.TplWidth), 0f, 0f);
				GameObject gameObject2 = gameObject.transform.Find("Fg").gameObject;
				gameObject2.SetActive(i < num2);
			}
		}

		// Token: 0x0601032C RID: 66348 RVA: 0x003E4F34 File Offset: 0x003E3134
		private void SetWinLose(int x, int index, int width, GameObject parentGo)
		{
			GameObject gameObject = base.uiBehaviour.m_WinLosePool.FetchGameObject(false);
			gameObject.transform.parent = parentGo.transform;
			gameObject.transform.localPosition = new Vector3((float)(x + width / 2), 0f, 0f);
			IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
			bool flag = this._doc.WinTag == 0;
			if (flag)
			{
				ixuisprite.spriteName = "bhdz_p";
			}
			else
			{
				XSpectateSceneDocument specificDocument = XDocuments.GetSpecificDocument<XSpectateSceneDocument>(XSpectateSceneDocument.uuID);
				bool flag2 = true;
				bool flag3 = !specificDocument.IsBlueTeamDict.TryGetValue(this._doc.DataList[index].roleid, out flag2);
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("spectate level reward can't find this player's team, player name = ", this._doc.DataList[index].name, null, null, null, null);
				}
				ixuisprite.spriteName = (((flag2 && this._doc.WinTag == 1) || (!flag2 && this._doc.WinTag == -1)) ? "bhdz_win" : "bhdz_lose");
			}
		}

		// Token: 0x0601032D RID: 66349 RVA: 0x003E5058 File Offset: 0x003E3258
		private void SetMvp(int x, int index, int width, GameObject parentGo)
		{
			bool flag = this._doc.DataList[index].roleid == this._doc.MvpUid;
			if (flag)
			{
				base.uiBehaviour.m_MVP.SetActive(true);
				base.uiBehaviour.m_MVP.transform.parent = parentGo.transform;
				base.uiBehaviour.m_MVP.transform.localPosition = new Vector3((float)(x + width / 2), 0f, 0f);
			}
		}

		// Token: 0x0601032E RID: 66350 RVA: 0x003E50EC File Offset: 0x003E32EC
		private int CalStarNum(int num)
		{
			int num2 = 0;
			while (num != 0)
			{
				num2++;
				num -= (num & -num);
			}
			return num2;
		}

		// Token: 0x0400740C RID: 29708
		private XSpectateLevelRewardDocument _doc;

		// Token: 0x0400740D RID: 29709
		public int MemberAndSplitHeight;
	}
}
