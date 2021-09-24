using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class DragonCrusadeGateWin : DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>
	{

		public override string fileName
		{
			get
			{
				return "Battle/DragonCrusadeWin";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_ContinueBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturn));
			base.uiBehaviour.m_ReturnSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnReturn));
			bool flag = base.uiBehaviour.m_ShareBtn != null;
			if (flag)
			{
				base.uiBehaviour.m_ShareBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShare));
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
			this._LevelRewardDoc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateHint(XDragonCrusadeDocument.mDERankChangePara);
		}

		public void Refresh()
		{
			bool iswin = this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.iswin;
			if (iswin)
			{
				base.uiBehaviour.goWin.SetActive(true);
				base.uiBehaviour.goFailed.SetActive(false);
				this.UpdateWinFrame();
			}
			else
			{
				base.uiBehaviour.goWin.SetActive(false);
				base.uiBehaviour.goFailed.SetActive(true);
				this.UpdateFailedFrame();
			}
		}

		private void UpdateFailedFrame()
		{
			base.SetXUILable("Win/Title", this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.iswin.ToString());
			base.SetXUILable("Failed/Bg/Result/DamageHP/Tip/HP", this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.bosshurthp.ToString() + "%");
			base.SetXUILable("Failed/Bg/Result/CurrentHP/Tip/HP", this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.bosslefthp.ToString() + "%");
			float num = (float)this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.joinreward.Count * 0.5f - 0.5f;
			Vector3 tplPos = base.uiBehaviour.m_FailedPool.TplPos;
			bool active = XActivityDocument.Doc.IsInnerDropTime(50U);
			for (int i = 0; i < this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.joinreward.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_FailedPool.FetchGameObject(false);
				ItemBrief itemBrief = this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.joinreward[i];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)itemBrief.itemID, (int)itemBrief.itemCount, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)itemBrief.itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				Transform transform = gameObject.transform.FindChild("Double");
				bool flag = transform != null;
				if (flag)
				{
					transform.gameObject.SetActive(active);
				}
				gameObject.transform.localPosition = new Vector3(((float)i - num) * (float)base.uiBehaviour.m_FailedPool.TplWidth, tplPos.y);
			}
			base.uiBehaviour.m_FailedPool.ActualReturnAll(false);
		}

		protected bool OnReturn(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

		protected void OnReturn(IXUISprite spr)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		protected bool OnShare(IXUIButton btn)
		{
			return true;
		}

		private void UpdateWinFrame()
		{
			base.SetXUILable("Failed/Bg/Result/DamageHP/Tip/HP", this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.bosshurthp.ToString() + "%");
			base.SetXUILable("Failed/Bg/Result/CurrentHP/Tip/HP", this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.bosslefthp.ToString() + "%");
			base.uiBehaviour.m_WinPool.ActualReturnAll(false);
			float num = (float)this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.winreward.Count * 0.5f - 0.5f;
			Vector3 tplPos = base.uiBehaviour.m_WinPool.TplPos;
			bool active = XActivityDocument.Doc.IsInnerDropTime(50U);
			for (int i = 0; i < this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.winreward.Count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_WinPool.FetchGameObject(false);
				ItemBrief itemBrief = this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.winreward[i];
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)itemBrief.itemID, (int)itemBrief.itemCount, false);
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)itemBrief.itemID;
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				Transform transform = gameObject.transform.FindChild("Double");
				bool flag = transform != null;
				if (flag)
				{
					transform.gameObject.SetActive(active);
				}
				gameObject.transform.localPosition = new Vector3(((float)i - num) * (float)base.uiBehaviour.m_WinPool.TplWidth, tplPos.y);
			}
			base.uiBehaviour.m_WinPool.ActualReturnAll(false);
			DragonCrusageGateData gate = this.GetGate(this._LevelRewardDoc.DragonCrusadeDataWin.MyResult.sceneid);
			string content = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrusadeWin"), gate.expData.WinHit);
			base.SetXUILable("Win/Title", content);
		}

		public void UpdateHint(DERankChangePara data)
		{
			bool flag = !base.IsLoaded();
			if (!flag)
			{
				bool flag2 = data == null;
				if (flag2)
				{
					base.SetXUILable("Win/Next/Hint", "");
				}
				else
				{
					bool flag3 = data.newrank < data.oldrank;
					if (flag3)
					{
						string content = string.Format(XSingleton<XStringTable>.singleton.GetString("DragonCrudageWinHit"), data.newrank);
						base.SetXUILable("Win/Next/Hint", content);
					}
					else
					{
						base.SetXUILable("Win/Next/Hint", "");
					}
				}
			}
		}

		private DragonCrusageGateData GetGate(uint sceneid)
		{
			for (int i = 0; i < XDragonCrusadeDocument._DragonCrusageGateDataInfo.Count; i++)
			{
				DragonCrusageGateData dragonCrusageGateData = XDragonCrusadeDocument._DragonCrusageGateDataInfo[i];
				bool flag = dragonCrusageGateData.SceneID == sceneid;
				if (flag)
				{
					return dragonCrusageGateData;
				}
			}
			return null;
		}

		private XLevelRewardDocument _LevelRewardDoc;
	}
}
