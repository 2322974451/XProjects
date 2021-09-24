using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XShowGetItemView : DlgBase<XShowGetItemView, XShowGetItemBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/ShowGetItemTip";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
		}

		protected override void OnShow()
		{
			this._showCount = 0;
			base.uiBehaviour.m_ShowItemPool.ReturnAll(false);
		}

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

		private XShowGetItemDocument _doc = null;

		private GameObject _preShowItem = null;

		private int _showCount;
	}
}
