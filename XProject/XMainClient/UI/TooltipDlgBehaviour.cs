using System;
using System.Collections;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TooltipDlgBehaviour : DlgBehaviourBase
	{

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

		public void DelayShow(IXUIDlg dlg)
		{
			base.StartCoroutine(this.InnerShow(dlg));
		}

		private IEnumerator InnerShow(IXUIDlg dlg)
		{
			IXUIPanel panel = base.gameObject.transform.FindChild("Bg").gameObject.GetComponent("XUIPanel") as IXUIPanel;
			panel.SetAlpha(0f);
			yield return null;
			panel.SetAlpha(1f);
			yield break;
		}

		public XUIPool m_PanelPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_AttrFramePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public Vector3 m_OriginPos;

		public Color m_OriginAttrNameColor;

		public Color m_OriginAttrValueColor;

		public GameObject m_Black;

		public IXUISprite m_TotalFrame;

		public IXUISprite m_ToolTipMain;

		public int m_TopFrameHeight;

		public float m_ScrollPanelSoftnessOffset;

		public float m_TooltipBorder;

		public float m_MaxTooltipHeight;

		public float m_MaxTooltipHeightWithJade;

		public Vector3[] m_ButtonsOriginPos = new Vector3[TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		public string[,] m_ButtonsText = new string[TooltipDlgBehaviour.MAX_GROUP_COUNT, TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		public bool[] m_ButtonsVisible = new bool[TooltipDlgBehaviour.MAX_BUTTON_COUNT];

		public static readonly int MAX_BUTTON_COUNT = 7;

		public static readonly int MAX_GROUP_COUNT = 4;
	}
}
