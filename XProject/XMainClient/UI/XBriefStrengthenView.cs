using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200189A RID: 6298
	internal class XBriefStrengthenView : DlgBase<XBriefStrengthenView, XBriefStrengthenBehaviour>
	{
		// Token: 0x170039E9 RID: 14825
		// (get) Token: 0x0601064F RID: 67151 RVA: 0x003FFAD0 File Offset: 0x003FDCD0
		public override string fileName
		{
			get
			{
				return "GameSystem/BriefStrengthenDlg";
			}
		}

		// Token: 0x170039EA RID: 14826
		// (get) Token: 0x06010650 RID: 67152 RVA: 0x003FFAE8 File Offset: 0x003FDCE8
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039EB RID: 14827
		// (get) Token: 0x06010651 RID: 67153 RVA: 0x003FFAFC File Offset: 0x003FDCFC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039EC RID: 14828
		// (get) Token: 0x06010652 RID: 67154 RVA: 0x003FFB10 File Offset: 0x003FDD10
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010653 RID: 67155 RVA: 0x003FFB23 File Offset: 0x003FDD23
		protected override void Init()
		{
			this._doc = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
		}

		// Token: 0x06010654 RID: 67156 RVA: 0x003FFB38 File Offset: 0x003FDD38
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_Close2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			base.uiBehaviour.m_More.RegisterLabelClickEventHandler(new LabelClickEventHandler(this._OnMoreClicked));
		}

		// Token: 0x06010655 RID: 67157 RVA: 0x003FFBA0 File Offset: 0x003FDDA0
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

		// Token: 0x06010656 RID: 67158 RVA: 0x003FFD28 File Offset: 0x003FDF28
		public bool OnCloseClicked(IXUIButton sp)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x06010657 RID: 67159 RVA: 0x003FFD44 File Offset: 0x003FDF44
		public void OnCloseClicked(IXUISprite sp)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x06010658 RID: 67160 RVA: 0x003FFD50 File Offset: 0x003FDF50
		private void _OnMoreClicked(IXUILabel iLabel)
		{
			this.SetVisible(false, true);
			DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x06010659 RID: 67161 RVA: 0x003FFD6C File Offset: 0x003FDF6C
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

		// Token: 0x0400765B RID: 30299
		public static readonly int FUNCTION_NUM = 3;

		// Token: 0x0400765C RID: 30300
		private XFPStrengthenDocument _doc = null;

		// Token: 0x0400765D RID: 30301
		public XUIPool m_FpStrengthenPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400765E RID: 30302
		public XUIPool m_FpButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400765F RID: 30303
		private List<FpStrengthenTable.RowData> m_BQList = null;
	}
}
