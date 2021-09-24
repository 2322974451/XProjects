using System;
using UILib;
using UnityEngine;
using XMainClient;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

public class TitleItemDisplay
{

	public Transform transform { get; private set; }

	public GameObject gameObject
	{
		get
		{
			return this.transform.gameObject;
		}
	}

	public void Init(Transform go)
	{
		this.transform = go;
		this.m_ItemGo = this.transform.FindChild("Item");
		this.m_ItemIcon = this.transform.FindChild("Item/Icon");
		this.m_itemNum = (this.transform.FindChild("Item/Num").GetComponent("XUILabel") as IXUILabel);
		this.m_itemName = (this.transform.FindChild("Item/ItemName").GetComponent("XUILabel") as IXUILabel);
		this.m_PPTLabel = (this.transform.FindChild("PPT").GetComponent("XUILabel") as IXUILabel);
		this.m_RunLabel = (this.transform.FindChild("Leave").GetComponent("XUILabel") as IXUILabel);
		this.m_RunLabel.RegisterLabelClickEventHandler(new LabelClickEventHandler(this.OnClickLableHandler));
	}

	private void OnClickLableHandler(IXUILabel label)
	{
		bool flag = label.ID == 0UL;
		if (flag)
		{
			DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.ShowContent(FunctionDef.ZHANLI);
		}
		else
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)label.ID, null);
		}
		DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(false, null);
	}

	public void SetVisible(bool visible)
	{
		this.gameObject.SetActive(visible);
	}

	public void Set(uint data0, uint data1, string desc)
	{
		this.m_RunLabel.ID = (ulong)data0;
		bool flag = data0 == 0U;
		if (flag)
		{
			this.SetFightValue(data1);
		}
		else
		{
			this.SetItemValue(data0, data1, desc);
		}
	}

	private void SetFightValue(uint value)
	{
		this.m_ItemGo.gameObject.SetActive(false);
		this.m_PPTLabel.gameObject.SetActive(true);
		double attr = XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
		int num = (int)(value - (uint)((int)attr));
		bool flag = value <= attr;
		if (flag)
		{
			this.m_RunLabel.Alpha = 0f;
			this.m_PPTLabel.SetText(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_FMT", new object[]
			{
				(int)attr,
				value
			}));
		}
		else
		{
			this.m_RunLabel.Alpha = 1f;
			this.m_RunLabel.SetText(XStringDefineProxy.GetString("TITLE_RUN_LABEL_1"));
			this.m_PPTLabel.SetText(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT", new object[]
			{
				(int)attr,
				value
			}));
		}
	}

	private void ShowTooltipDialog(IXUISprite sprite)
	{
		bool flag = sprite.ID > 0UL;
		if (flag)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)sprite.ID, null, 0U);
		}
	}

	private void SetItemValue(uint itemID, uint value, string desc)
	{
		this.m_ItemGo.gameObject.SetActive(true);
		this.m_PPTLabel.gameObject.SetActive(false);
		ItemList.RowData itemConf = XBagDocument.GetItemConf((int)itemID);
		int num = (int)XBagDocument.BagDoc.GetItemCount((int)itemID);
		this.m_itemName.SetText(desc);
		XItemDrawerMgr.Param.IconType = 1U;
		XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_ItemIcon.gameObject, itemConf, 0, false);
		IXUISprite ixuisprite = this.m_ItemIcon.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
		ixuisprite.ID = (ulong)((long)itemConf.ItemID);
		ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowTooltipDialog));
		bool flag = (long)num < (long)((ulong)value);
		if (flag)
		{
			this.m_RunLabel.Alpha = 1f;
			this.m_RunLabel.SetText(XStringDefineProxy.GetString("TITLE_RUN_LABEL_1"));
			this.m_itemNum.SetText(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_NOTENOUGH_FMT", new object[]
			{
				num,
				value
			}));
		}
		else
		{
			this.m_RunLabel.Alpha = 0f;
			this.m_itemNum.SetText(XStringDefineProxy.GetString("COMMON_COUNT_TOTAL_FMT", new object[]
			{
				num,
				value
			}));
		}
	}

	private Transform m_ItemGo;

	private IXUILabel m_PPTLabel;

	private IXUILabel m_RunLabel;

	private IXUILabel m_itemNum;

	private IXUILabel m_itemName;

	private Transform m_ItemIcon;
}
