using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XSystemTipView : DlgBase<XSystemTipView, XSystemTipBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SystemTip";
			}
		}

		public override bool autoload
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

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSystemTipDocument>(XSystemTipDocument.uuID);
		}

		protected override void OnShow()
		{
			base.uiBehaviour.m_TipPool.ReturnAll(false);
			this._showCount = 0;
			this._count = 0;
			this.m_Time = 0f;
			this._preTip = null;
			this.m_Interval = this.DEFAULT_INTERVAL;
		}

		public void ShowTip(string text)
		{
			GameObject gameObject = base.uiBehaviour.m_TipPool.FetchGameObject(false);
			gameObject.transform.localPosition = base.uiBehaviour.m_TipPool.TplPos;
			IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.spriteDepth = this._count;
			IXUILabel ixuilabel = gameObject.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(text);
			ixuilabel.spriteDepth = this._count + 1;
			bool flag = this._preTip != null;
			if (flag)
			{
				bool activeSelf = this._preTip.activeSelf;
				if (activeSelf)
				{
					this._preTip.transform.parent = gameObject.transform;
				}
			}
			this._preTip = gameObject;
			IXUITweenTool ixuitweenTool = gameObject.transform.GetComponent("XUIPlayTween") as IXUITweenTool;
			ixuitweenTool.SetTargetGameObject(gameObject);
			ixuitweenTool.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPlayTweenFinish));
			ixuitweenTool.PlayTween(true, -1f);
			this._showCount++;
			this._count += 2;
		}

		private void OnPlayTweenFinish(IXUITweenTool iPlayTween)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_TipPool.ReturnInstance(iPlayTween.gameObject, true);
				this._showCount--;
				bool flag2 = this._showCount == 0;
				if (flag2)
				{
					this.SetVisible(false, true);
				}
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = Time.time - this.m_Time > this.m_Interval;
			if (flag)
			{
				string empty = string.Empty;
				bool flag2 = this._doc.TryGetTip(ref empty);
				if (flag2)
				{
					this.ShowTip(empty);
					int leftCount = this._doc.LeftCount;
					bool flag3 = leftCount > 3;
					if (flag3)
					{
						this.m_Interval = this.DEFAULT_INTERVAL - 0.1f * (float)(leftCount - 3);
					}
					this.m_Time = Time.time;
				}
			}
		}

		private XSystemTipDocument _doc;

		private int _showCount;

		private GameObject _preTip = null;

		private int _count;

		private readonly float DEFAULT_INTERVAL = 0.4f;

		private float m_Time;

		private float m_Interval;
	}
}
