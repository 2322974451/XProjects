using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class SpectateLevelRewardView : DlgBase<SpectateLevelRewardView, SpectateLevelRewardBehaviour>
	{

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override string fileName
		{
			get
			{
				return "Battle/SpectateLevelReward";
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XSpectateLevelRewardDocument>(XSpectateLevelRewardDocument.uuID);
			base.uiBehaviour.m_GoOnBtnText.SetText(XStringDefineProxy.GetString("Spectate_Goon"));
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_BackToMainCityBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.BackToMainCityBtnClick));
			base.uiBehaviour.m_GoOnBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnGoOnBtnClick));
		}

		public void BackToMainCityBtnClick(IXUISprite btn)
		{
			this._doc.LevelScene();
		}

		public void OnGoOnBtnClick(IXUISprite iSp)
		{
			this.SetVisible(false, true);
			DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisible(true, true);
		}

		private void OnAddFriendClick(IXUISprite sp)
		{
			DlgBase<XFriendsView, XFriendsBehaviour>.singleton.AddFriendById(sp.ID);
		}

		protected override void OnShow()
		{
			bool flag = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SetVisible(false, true);
			}
		}

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

		private XSpectateLevelRewardDocument _doc;

		public int MemberAndSplitHeight;
	}
}
