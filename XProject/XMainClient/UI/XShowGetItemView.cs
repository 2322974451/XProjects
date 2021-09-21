using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B6 RID: 6326
	internal class XShowGetItemView : DlgBase<XShowGetItemView, XShowGetItemBehaviour>
	{
		// Token: 0x17003A3B RID: 14907
		// (get) Token: 0x060107D1 RID: 67537 RVA: 0x00409930 File Offset: 0x00407B30
		public override string fileName
		{
			get
			{
				return "GameSystem/ShowGetItemTip";
			}
		}

		// Token: 0x17003A3C RID: 14908
		// (get) Token: 0x060107D2 RID: 67538 RVA: 0x00409948 File Offset: 0x00407B48
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A3D RID: 14909
		// (get) Token: 0x060107D3 RID: 67539 RVA: 0x0040995C File Offset: 0x00407B5C
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A3E RID: 14910
		// (get) Token: 0x060107D4 RID: 67540 RVA: 0x00409970 File Offset: 0x00407B70
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060107D5 RID: 67541 RVA: 0x00409983 File Offset: 0x00407B83
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
		}

		// Token: 0x060107D6 RID: 67542 RVA: 0x0040999D File Offset: 0x00407B9D
		protected override void OnShow()
		{
			this._showCount = 0;
			base.uiBehaviour.m_ShowItemPool.ReturnAll(false);
		}

		// Token: 0x060107D7 RID: 67543 RVA: 0x004099BC File Offset: 0x00407BBC
		public void ShowItem(XItem item)
		{
			bool flag = this._doc.IsForbidGetItemUI || this._doc.IsForbidByLua;
			if (flag)
			{
				this._doc.ItemQueue.Clear();
				this.SetVisible(false, true);
			}
			else
			{
				bool flag2 = !base.IsVisible();
				if (flag2)
				{
					this.SetVisible(true, true);
				}
				this._showCount++;
				GameObject gameObject = base.uiBehaviour.m_ShowItemPool.FetchGameObject(false);
				gameObject.transform.localPosition = base.uiBehaviour.m_ShowItemPool.TplPos;
				bool flag3 = this._preShowItem != null;
				if (flag3)
				{
					bool activeSelf = this._preShowItem.activeSelf;
					if (activeSelf)
					{
						this._preShowItem.transform.parent = gameObject.transform;
					}
				}
				this._preShowItem = gameObject;
				IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				string text = string.Format("[{0}]{1}", XSingleton<UiUtility>.singleton.GetItemQualityRGB((int)XBagDocument.GetItemConf(item.itemID).ItemQuality).ToString(), XSingleton<UiUtility>.singleton.ChooseProfString(XBagDocument.GetItemConf(item.itemID).ItemName, 0U));
				ixuilabel.SetText(string.Format("{0}[ffffff]x{1}", XStringDefineProxy.GetString("GET_ITEM", new object[]
				{
					text
				}), item.itemCount.ToString()));
				IXUITweenTool ixuitweenTool = gameObject.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
				ixuitweenTool.SetTargetGameObject(gameObject);
				ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
				ixuitweenTool.PlayTween(true, -1f);
			}
		}

		// Token: 0x060107D8 RID: 67544 RVA: 0x00409B7C File Offset: 0x00407D7C
		public void ShowTip(string tip)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			this._showCount++;
			GameObject gameObject = base.uiBehaviour.m_ShowItemPool.FetchGameObject(false);
			gameObject.transform.localPosition = base.uiBehaviour.m_ShowItemPool.TplPos;
			bool flag2 = this._preShowItem != null;
			if (flag2)
			{
				bool activeSelf = this._preShowItem.activeSelf;
				if (activeSelf)
				{
					this._preShowItem.transform.parent = gameObject.transform;
				}
			}
			this._preShowItem = gameObject;
			IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(tip);
			IXUITweenTool ixuitweenTool = gameObject.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.SetTargetGameObject(gameObject);
			ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			ixuitweenTool.PlayTween(true, -1f);
		}

		// Token: 0x060107D9 RID: 67545 RVA: 0x00409C8C File Offset: 0x00407E8C
		public void ShowFullTip(int Count)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			this._showCount++;
			GameObject gameObject = base.uiBehaviour.m_ShowItemPool.FetchGameObject(false);
			gameObject.transform.localPosition = base.uiBehaviour.m_ShowItemPool.TplPos;
			bool flag2 = this._preShowItem != null;
			if (flag2)
			{
				bool activeSelf = this._preShowItem.activeSelf;
				if (activeSelf)
				{
					this._preShowItem.transform.parent = gameObject.transform;
				}
			}
			this._preShowItem = gameObject;
			IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("EXCEED_ITEM", new object[]
			{
				Count
			}));
			IXUITweenTool ixuitweenTool = gameObject.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.SetTargetGameObject(gameObject);
			ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			ixuitweenTool.PlayTween(true, -1f);
		}

		// Token: 0x060107DA RID: 67546 RVA: 0x00409DB4 File Offset: 0x00407FB4
		public void ShowString(string str, uint id)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			this._showCount++;
			GameObject gameObject = base.uiBehaviour.m_ShowItemPool.FetchGameObject(false);
			gameObject.transform.localPosition = base.uiBehaviour.m_ShowItemPool.TplPos;
			bool flag2 = this._preShowItem != null;
			if (flag2)
			{
				bool activeSelf = this._preShowItem.activeSelf;
				if (activeSelf)
				{
					this._preShowItem.transform.parent = gameObject.transform;
				}
			}
			this._preShowItem = gameObject;
			IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(str);
			ixuilabel.ID = (ulong)id;
			IXUITweenTool ixuitweenTool = gameObject.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.SetTargetGameObject(gameObject);
			ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			ixuitweenTool.PlayTween(true, -1f);
		}

		// Token: 0x060107DB RID: 67547 RVA: 0x00409ECC File Offset: 0x004080CC
		public void EditString(string str, uint id)
		{
			List<GameObject> list = ListPool<GameObject>.Get();
			base.uiBehaviour.m_ShowItemPool.GetActiveList(list);
			for (int i = 0; i < list.Count; i++)
			{
				IXUILabel ixuilabel = list[i].transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
				bool flag = ixuilabel.ID != (ulong)id;
				if (!flag)
				{
					ixuilabel.SetText(str);
					break;
				}
			}
			ListPool<GameObject>.Release(list);
		}

		// Token: 0x060107DC RID: 67548 RVA: 0x00409F54 File Offset: 0x00408154
		public void OnPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_ShowItemPool.ReturnInstance(iPlayTween.gameObject, true);
				this._showCount--;
				bool flag2 = this._showCount == 0;
				if (flag2)
				{
					this.SetVisible(false, true);
				}
			}
		}

		// Token: 0x04007733 RID: 30515
		private XShowGetItemDocument _doc = null;

		// Token: 0x04007734 RID: 30516
		private GameObject _preShowItem = null;

		// Token: 0x04007735 RID: 30517
		private int _showCount;
	}
}
