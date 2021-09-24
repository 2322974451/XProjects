using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class AncientBox : DlgBase<AncientBox, AnicientBoxBahaviour>
	{

		public override string fileName
		{
			get
			{
				return "OperatingActivity/AncientBox";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return false;
			}
		}

		public override bool pushstack
		{
			get
			{
				return false;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_sprRed.SetVisible(false);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClaim.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClick));
			base.uiBehaviour.m_black.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClose));
		}

		public void Show(AncientTimesTable.RowData r)
		{
			this.row = r;
			this.SetVisible(true, true);
			this.RefreshPoint();
			this.RefreshRwd();
		}

		private void RefreshPoint()
		{
			base.uiBehaviour.m_title.SetText(this.row.Title);
			base.uiBehaviour.m_point.SetText(XStringDefineProxy.GetString("AncientPoint", new object[]
			{
				this.row.nPoints[1]
			}));
		}

		private void RefreshRwd()
		{
			base.uiBehaviour.m_rwdpool.ReturnAll(false);
			int tplWidth = base.uiBehaviour.m_rwdpool.TplWidth;
			int i = 0;
			int count = (int)this.row.Items.count;
			while (i < count)
			{
				GameObject gameObject = base.uiBehaviour.m_rwdpool.FetchGameObject(false);
				XSingleton<UiUtility>.singleton.AddChild(base.uiBehaviour.itemTpl.transform.parent.gameObject, gameObject);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)this.row.Items[i, 0], (int)this.row.Items[i, 1], false);
				Vector3 localPosition = base.uiBehaviour.itemTpl.transform.localPosition;
				localPosition.x = (float)((count % 2 == 0) ? ((int)((float)i - (float)count / 2f) * tplWidth + tplWidth / 2) : ((int)((float)i - (float)(count - 1) / 2f) * tplWidth));
				gameObject.transform.localPosition = localPosition;
				IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this.row.Items[i, 0];
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				i++;
			}
		}

		private bool OnClick(IXUIButton btn)
		{
			XAncientDocument specificDocument = XDocuments.GetSpecificDocument<XAncientDocument>(XAncientDocument.uuID);
			specificDocument.ReqPoint(this.row.ID);
			return true;
		}

		private void OnClose(IXUISprite spr)
		{
			this.SetVisible(false, true);
		}

		private AncientTimesTable.RowData row;
	}
}
