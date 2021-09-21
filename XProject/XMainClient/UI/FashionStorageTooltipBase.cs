using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x02001809 RID: 6153
	internal class FashionStorageTooltipBase<TDlgClass, TUIBehaviour> : TooltipDlg<TDlgClass, TUIBehaviour>, ITooltipDlg where TDlgClass : IXUIDlg, new() where TUIBehaviour : TooltipDlgBehaviour
	{
		// Token: 0x170038F1 RID: 14577
		// (get) Token: 0x0600FF16 RID: 65302 RVA: 0x003C1CB0 File Offset: 0x003BFEB0
		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageToolTip";
			}
		}

		// Token: 0x0600FF17 RID: 65303 RVA: 0x003C1CC8 File Offset: 0x003BFEC8
		public override bool HideToolTip(bool forceHide = false)
		{
			return base.HideToolTip(forceHide);
		}

		// Token: 0x0600FF18 RID: 65304 RVA: 0x003C1CEC File Offset: 0x003BFEEC
		protected override void Init()
		{
			base.Init();
			this.m_OperateList[0, 0] = new FashionStorageFashionPutOn();
			this.m_OperateList[0, 1] = new FashionStorageFashionPutOnSuit();
			this.m_OperateList[1, 0] = new FashionStorageFashionTakeOff();
			this.m_OperateList[1, 1] = new FashionStorageFashtionTakeOffSuit();
			this.m_OperateList[1, 2] = new FashionStorageColouring();
			this.m_OperateList[2, 0] = new FashionStorageButtonGoFashion();
			this.m_fashionDoc = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
			this.m_doc = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
		}

		// Token: 0x0600FF19 RID: 65305 RVA: 0x003C1D90 File Offset: 0x003BFF90
		protected override void SetupToolTipButtons(GameObject goToolTip, XItem item, bool bMain)
		{
			base.SetupToolTipButtons(goToolTip, item, bMain);
			this.itemID = item.itemID;
			if (bMain)
			{
				bool flag = this.m_doc.fashionStorageType == FashionStorageType.OutLook;
				if (flag)
				{
					bool flag2 = this.m_doc.FashionInBody(item.itemID);
					if (flag2)
					{
						base._SetupButtonVisiability(goToolTip, 1, item);
					}
					else
					{
						base._SetupButtonVisiability(goToolTip, 0, item);
					}
				}
				else
				{
					base._SetupButtonVisiability(goToolTip, 2, item);
				}
			}
		}

		// Token: 0x0600FF1A RID: 65306 RVA: 0x003C1E08 File Offset: 0x003C0008
		protected override bool OnButton1Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 0] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 0].OnButtonClick((ulong)((long)this.itemID), 0UL);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x0600FF1B RID: 65307 RVA: 0x003C1E6C File Offset: 0x003C006C
		protected override bool OnButton2Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 1] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 1].OnButtonClick((ulong)((long)this.itemID), 0UL);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x0600FF1C RID: 65308 RVA: 0x003C1ECC File Offset: 0x003C00CC
		protected override bool OnButton3Clicked(IXUIButton button)
		{
			this._bButtonClickedThisFrame = true;
			bool flag = this.m_OperateList[(int)button.ID, 2] != null;
			if (flag)
			{
				this.m_OperateList[(int)button.ID, 2].OnButtonClick((ulong)((long)this.itemID), 0UL);
			}
			this.HideToolTip(true);
			return true;
		}

		// Token: 0x040070C4 RID: 28868
		protected XFashionStorageDocument m_doc;

		// Token: 0x040070C5 RID: 28869
		protected XFashionDocument m_fashionDoc;

		// Token: 0x040070C6 RID: 28870
		protected int itemID;
	}
}
