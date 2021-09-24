using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XBriefStrengthenView : DlgBase<XBriefStrengthenView, XBriefStrengthenBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/BriefStrengthenDlg";
			}
		}

		public override int group
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Close2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_More.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnMoreClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_FuncPool.FakeReturnAll();
			Vector3 tplPos = base.uiBehaviour.m_FuncPool.TplPos;
			int num = 0;
			this.m_BQList = this._doc.GetBQByType(200);
			int num2 = 0;
			while (num < XBriefStrengthenView.FUNCTION_NUM && num2 < this.m_BQList.Count)
			{
				FpStrengthenTable.RowData rowData = this.m_BQList[num2];
				bool flag = rowData == null;
				if (!flag)
				{
					GameObject gameObject = base.uiBehaviour.m_FuncPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(tplPos.x + (float)(num * base.uiBehaviour.m_FuncPool.TplWidth), tplPos.y);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					IXUILabel ixuilabel = gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
					IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(rowData.BQImageID);
					ixuilabel.SetText(rowData.BQName);
					ixuisprite2.ID = (ulong)((long)num2);
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.GoToStrengthSys));
					num++;
				}
				num2++;
			}
			base.uiBehaviour.m_FuncPool.ActualReturnAll(false);
		}

		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		private void _OnMoreClicked(IXUILabel iLabel)
		{
			this.SetVisible(false, true);
			DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		public void GoToStrengthSys(IXUISprite sp)
		{
			int num = (int)sp.ID;
			this.SetVisible(false, true);
			bool flag = num >= this.m_BQList.Count;
			if (!flag)
			{
				XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)this.m_BQList[num].BQSystem, 0UL);
			}
		}

		public static readonly int FUNCTION_NUM = 3;

		private XFPStrengthenDocument _doc = null;

		public XUIPool m_FpStrengthenPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_FpButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private List<FpStrengthenTable.RowData> m_BQList = null;
	}
}
