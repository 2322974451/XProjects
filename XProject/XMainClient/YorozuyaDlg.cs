using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class YorozuyaDlg : DlgBase<YorozuyaDlg, YorozuyaBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/YorozuyaDlg";
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		protected override void OnLoad()
		{
			base.OnLoad();
		}

		public override int sysid
		{
			get
			{
				return 440;
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_closedBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickClosedBtn));
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XYorozuyaDocument.Doc;
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XInput>.singleton.Freezed = false;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		private void FillContent()
		{
			base.uiBehaviour.m_itemPool.ReturnAll(true);
			for (int i = 0; i < this.m_doc.YorozuyaTab.Table.Length; i++)
			{
				YorozuyaTable.RowData rowData = this.m_doc.YorozuyaTab.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_itemPool.FetchGameObject(false);
					gameObject.transform.parent = base.uiBehaviour.m_parentTra;
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = base.uiBehaviour.m_itemPool.TplPos + new Vector3((float)(i % 3 * base.uiBehaviour.m_itemPool.TplWidth), (float)(-(float)(i / 3) * base.uiBehaviour.m_itemPool.TplHeight), 0f);
					IXUISprite ixuisprite = gameObject.transform.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)rowData.ID;
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickIcon));
					IXUILabel ixuilabel = gameObject.transform.FindChild("shopname").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(rowData.Name);
					IXUITexture ixuitexture = gameObject.transform.FindChild("Icon").GetComponent("XUITexture") as IXUITexture;
					ixuitexture.SetTexturePath(rowData.IconName);
					ixuitexture.SetEnabled(rowData.IsOpen == 0);
				}
			}
		}

		private bool OnClickClosedBtn(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private void OnClickIcon(IXUISprite spr)
		{
			YorozuyaTable.RowData rowData = this.m_doc.GetRowData((byte)spr.ID);
			bool flag = rowData == null;
			if (!flag)
			{
				bool flag2 = rowData.IsOpen == 1;
				if (flag2)
				{
					XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("ERR_CUSTOM_NOTOPEN"), "fece00");
				}
				else
				{
					this.m_doc.ReqEnterScene((int)spr.ID);
				}
			}
		}

		private XYorozuyaDocument m_doc;
	}
}
