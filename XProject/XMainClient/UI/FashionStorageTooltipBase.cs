using System;
using UILib;
using UnityEngine;

namespace XMainClient.UI
{

	internal class FashionStorageTooltipBase<TDlgClass, TUIBehaviour> : TooltipDlg<TDlgClass, TUIBehaviour>, ITooltipDlg where TDlgClass : IXUIDlg, new() where TUIBehaviour : TooltipDlgBehaviour
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/FashionStorageToolTip";
			}
		}

		public override bool HideToolTip(bool forceHide = false)
		{
			return base.HideToolTip(forceHide);
		}

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

		protected XFashionStorageDocument m_doc;

		protected XFashionDocument m_fashionDoc;

		protected int itemID;
	}
}
