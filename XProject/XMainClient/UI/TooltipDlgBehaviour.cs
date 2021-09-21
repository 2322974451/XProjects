using System;
using System.Collections;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200191C RID: 6428
	internal class TooltipDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010D13 RID: 68883 RVA: 0x0043B07C File Offset: 0x0043927C
		protected virtual void Awake()
		{
			Transform transform = base.transform.FindChild("Black");
			bool flag = transform != null;
			if (flag)
			{
				this.m_Black = transform.gameObject;
			}
			GameObject gameObject = base.transform.FindChild("Bg/Bg").gameObject;
			this.m_TotalFrame = (gameObject.GetComponent("XUISprite") as IXUISprite);
			this.m_OriginPos = this.m_TotalFrame.gameObject.transform.localPosition;
			transform = base.transform.FindChild("Bg/Bg/ToolTip/TopFrame");
			this.m_TooltipBorder = -transform.localPosition.y;
			this.m_TopFrameHeight = (transform.GetComponent("XUISprite") as IXUISprite).spriteHeight;
			transform = base.transform.FindChild("Bg/Bg/ToolTip/ScrollPanel/BasicAttr/Attr1");
			bool flag2 = transform != null;
			if (flag2)
			{
				this.m_AttrPool.SetupPool(gameObject, transform.gameObject, 2U, false);
			}
			transform = base.transform.FindChild("Bg/Bg/ToolTip/ScrollPanel/BasicAttr");
			bool flag3 = transform != null;
			if (flag3)
			{
				this.m_AttrFramePool.SetupPool(gameObject, transform.gameObject, 2U, false);
			}
			transform = base.transform.FindChild("Bg/Bg/ToolTip/ScrollPanel");
			IXUIPanel ixuipanel = transform.GetComponent("XUIPanel") as IXUIPanel;
			IXUISprite ixuisprite = base.transform.Find("Bg/Bg/ToolTip").GetComponent("XUISprite") as IXUISprite;
			this.m_ScrollPanelSoftnessOffset = ixuipanel.softness.y;
			this.m_MaxTooltipHeightWithJade = (float)ixuisprite.spriteHeight - this.m_TooltipBorder;
			this.m_MaxTooltipHeight = (float)(this.m_TopFrameHeight + (int)ixuipanel.GetBaseRect().w) + this.m_ScrollPanelSoftnessOffset + this.m_TooltipBorder;
			transform = base.transform.FindChild("Bg/Bg/ToolTip/ScrollPanel/PlaceHolder");
			bool flag4 = transform != null;
			if (flag4)
			{
				transform.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_TopFrameHeight) - this.m_ScrollPanelSoftnessOffset - this.m_TooltipBorder);
			}
			transform = base.transform.FindChild("Bg/Bg/ToolTip/FuncFrame/ButtonTpl");
			XUIPool xuipool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			xuipool.SetupPool(transform.parent.gameObject, transform.gameObject, (uint)TooltipDlgBehaviour.MAX_BUTTON_COUNT, false);
			for (int i = 0; i < TooltipDlgBehaviour.MAX_BUTTON_COUNT; i++)
			{
				transform = xuipool.FetchGameObject(false).transform;
				transform.name = "Button" + (i + 1);
				transform.localPosition = new Vector3(xuipool.TplPos.x, xuipool.TplPos.y + (float)(xuipool.TplHeight * i));
				bool flag5 = transform != null;
				if (flag5)
				{
					this.m_ButtonsOriginPos[i] = transform.localPosition;
				}
				this.m_ButtonsVisible[i] = false;
			}
			transform = base.transform.FindChild("Bg/Bg/ToolTip");
			this.m_ToolTipMain = (transform.gameObject.GetComponent("XUISprite") as IXUISprite);
			this.m_PanelPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			bool flag6 = this.m_AttrPool._tpl != null;
			if (flag6)
			{
				this.m_OriginAttrNameColor = (this.m_AttrPool._tpl.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel).GetColor();
				this.m_OriginAttrValueColor = (this.m_AttrPool._tpl.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel).GetColor();
			}
		}

		// Token: 0x06010D14 RID: 68884 RVA: 0x0043B429 File Offset: 0x00439629
		public void DelayShow(IXUIDlg dlg)
		{
			base.StartCoroutine(this.InnerShow(dlg));
		}

		// Token: 0x06010D15 RID: 68885 RVA: 0x0043B43A File Offset: 0x0043963A
		private IEnumerator InnerShow(IXUIDlg dlg)
		{
			IXUIPanel panel = base.gameObject.transform.FindChild("Bg").gameObject.GetComponent("XUIPanel") as IXUIPanel;
			panel.SetAlpha(0f);
			yield return null;
			panel.SetAlpha(1f);
			yield break;
		}

		// Token: 0x04007B5C RID: 31580
		public XUIPool m_PanelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B5D RID: 31581
		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B5E RID: 31582
		public XUIPool m_AttrFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007B5F RID: 31583
		public Vector3 m_OriginPos;

		// Token: 0x04007B60 RID: 31584
		public Color m_OriginAttrNameColor;

		// Token: 0x04007B61 RID: 31585
		public Color m_OriginAttrValueColor;

		// Token: 0x04007B62 RID: 31586
		public GameObject m_Black;

		// Token: 0x04007B63 RID: 31587
		public IXUISprite m_TotalFrame;

		// Token: 0x04007B64 RID: 31588
		public IXUISprite m_ToolTipMain;

		// Token: 0x04007B65 RID: 31589
		public int m_TopFrameHeight;

		// Token: 0x04007B66 RID: 31590
		public float m_ScrollPanelSoftnessOffset;

		// Token: 0x04007B67 RID: 31591
		public float m_TooltipBorder;

		// Token: 0x04007B68 RID: 31592
		public float m_MaxTooltipHeight;

		// Token: 0x04007B69 RID: 31593
		public float m_MaxTooltipHeightWithJade;

		// Token: 0x04007B6A RID: 31594
		public Vector3[] m_ButtonsOriginPos = new Vector3[TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		// Token: 0x04007B6B RID: 31595
		public string[,] m_ButtonsText = new string[TooltipDlgBehaviour.MAX_GROUP_COUNT, TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		// Token: 0x04007B6C RID: 31596
		public bool[] m_ButtonsVisible = new bool[TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		// Token: 0x04007B6D RID: 31597
		public static readonly int MAX_BUTTON_COUNT = 7;

		// Token: 0x04007B6E RID: 31598
		public static readonly int MAX_GROUP_COUNT = 4;
	}
}
