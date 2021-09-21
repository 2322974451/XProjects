using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E5F RID: 3679
	internal class XSystemTipView : DlgBase<XSystemTipView, XSystemTipBehaviour>
	{
		// Token: 0x17003482 RID: 13442
		// (get) Token: 0x0600C517 RID: 50455 RVA: 0x002B59A8 File Offset: 0x002B3BA8
		public override string fileName
		{
			get
			{
				return "GameSystem/SystemTip";
			}
		}

		// Token: 0x17003483 RID: 13443
		// (get) Token: 0x0600C518 RID: 50456 RVA: 0x002B59C0 File Offset: 0x002B3BC0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003484 RID: 13444
		// (get) Token: 0x0600C519 RID: 50457 RVA: 0x002B59D4 File Offset: 0x002B3BD4
		public override bool isHideChat
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17003485 RID: 13445
		// (get) Token: 0x0600C51A RID: 50458 RVA: 0x002B59E8 File Offset: 0x002B3BE8
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C51B RID: 50459 RVA: 0x002B59FB File Offset: 0x002B3BFB
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSystemTipDocument>(XSystemTipDocument.uuID);
		}

		// Token: 0x0600C51C RID: 50460 RVA: 0x002B5A18 File Offset: 0x002B3C18
		protected override void OnShow()
		{
			base.uiBehaviour.m_TipPool.ReturnAll(false);
			this._showCount = 0;
			this._count = 0;
			this.m_Time = 0f;
			this._preTip = null;
			this.m_Interval = this.DEFAULT_INTERVAL;
		}

		// Token: 0x0600C51D RID: 50461 RVA: 0x002B5A64 File Offset: 0x002B3C64
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

		// Token: 0x0600C51E RID: 50462 RVA: 0x002B5B9C File Offset: 0x002B3D9C
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

		// Token: 0x0600C51F RID: 50463 RVA: 0x002B5BF8 File Offset: 0x002B3DF8
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

		// Token: 0x04005621 RID: 22049
		private XSystemTipDocument _doc;

		// Token: 0x04005622 RID: 22050
		private int _showCount;

		// Token: 0x04005623 RID: 22051
		private GameObject _preTip = null;

		// Token: 0x04005624 RID: 22052
		private int _count;

		// Token: 0x04005625 RID: 22053
		private readonly float DEFAULT_INTERVAL = 0.4f;

		// Token: 0x04005626 RID: 22054
		private float m_Time;

		// Token: 0x04005627 RID: 22055
		private float m_Interval;
	}
}
