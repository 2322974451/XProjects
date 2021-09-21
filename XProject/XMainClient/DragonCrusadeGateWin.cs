using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BE5 RID: 3045
	internal class DragonCrusadeGateWin : DlgBase<DragonCrusadeGateWin, DragonCrusadeGateWinBehavior>
	{
		// Token: 0x170030A2 RID: 12450
		// (get) Token: 0x0600AD82 RID: 44418 RVA: 0x002034C4 File Offset: 0x002016C4
		public override string fileName
		{
			get
			{
				return "Battle/DragonCrusadeWin";
			}
		}

		// Token: 0x170030A3 RID: 12451
		// (get) Token: 0x0600AD83 RID: 44419 RVA: 0x002034DC File Offset: 0x002016DC
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030A4 RID: 12452
		// (get) Token: 0x0600AD84 RID: 44420 RVA: 0x002034F0 File Offset: 0x002016F0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AD85 RID: 44421 RVA: 0x00203503 File Offset: 0x00201703
		public override void OnXNGUIClick(GameObject obj, string path)
		{
			base.OnXNGUIClick(obj, path);
		}

		// Token: 0x0600AD86 RID: 44422 RVA: 0x00203510 File Offset: 0x00201710
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

		// Token: 0x0600AD87 RID: 44423 RVA: 0x0020358E File Offset: 0x0020178E
		protected override void OnLoad()
		{
			base.OnLoad();
			this._LevelRewardDoc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
		}

		// Token: 0x0600AD88 RID: 44424 RVA: 0x002035A8 File Offset: 0x002017A8
		protected override void OnShow()
		{
			base.OnShow();
			this.UpdateHint(XDragonCrusadeDocument.mDERankChangePara);
		}

		// Token: 0x0600AD89 RID: 44425 RVA: 0x002035C0 File Offset: 0x002017C0
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

		// Token: 0x0600AD8A RID: 44426 RVA: 0x00203644 File Offset: 0x00201844
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

		// Token: 0x0600AD8B RID: 44427 RVA: 0x0020386C File Offset: 0x00201A6C
		protected bool OnReturn(IXUIButton btn)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
			return true;
		}

		// Token: 0x0600AD8C RID: 44428 RVA: 0x00160161 File Offset: 0x0015E361
		protected void OnReturn(IXUISprite spr)
		{
			XSingleton<XScene>.singleton.ReqLeaveScene();
		}

		// Token: 0x0600AD8D RID: 44429 RVA: 0x0020388C File Offset: 0x00201A8C
		protected bool OnShare(IXUIButton btn)
		{
			return true;
		}

		// Token: 0x0600AD8E RID: 44430 RVA: 0x002038A0 File Offset: 0x00201AA0
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

		// Token: 0x0600AD8F RID: 44431 RVA: 0x00203AFC File Offset: 0x00201CFC
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

		// Token: 0x0600AD90 RID: 44432 RVA: 0x00203B8C File Offset: 0x00201D8C
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

		// Token: 0x04004166 RID: 16742
		private XLevelRewardDocument _LevelRewardDoc;
	}
}
