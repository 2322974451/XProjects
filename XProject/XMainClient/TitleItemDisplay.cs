using System;
using UILib;
using UnityEngine;
using XMainClient;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

// Token: 0x02000002 RID: 2
public class TitleItemDisplay
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
	public Transform transform { get; private set; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002064 File Offset: 0x00000264
	public GameObject gameObject
	{
		get
		{
			return this.transform.gameObject;
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002084 File Offset: 0x00000284
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

	// Token: 0x06000005 RID: 5 RVA: 0x00002174 File Offset: 0x00000374
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

	// Token: 0x06000006 RID: 6 RVA: 0x000021C2 File Offset: 0x000003C2
	public void SetVisible(bool visible)
	{
		this.gameObject.SetActive(visible);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000021D4 File Offset: 0x000003D4
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

	// Token: 0x06000008 RID: 8 RVA: 0x0000220C File Offset: 0x0000040C
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

	// Token: 0x06000009 RID: 9 RVA: 0x00002304 File Offset: 0x00000504
	private void ShowTooltipDialog(IXUISprite sprite)
	{
		bool flag = sprite.ID > 0UL;
		if (flag)
		{
			XSingleton<UiUtility>.singleton.ShowTooltipDialog((int)sprite.ID, null, 0U);
		}
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002338 File Offset: 0x00000538
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

	// Token: 0x04000002 RID: 2
	private Transform m_ItemGo;

	// Token: 0x04000003 RID: 3
	private IXUILabel m_PPTLabel;

	// Token: 0x04000004 RID: 4
	private IXUILabel m_RunLabel;

	// Token: 0x04000005 RID: 5
	private IXUILabel m_itemNum;

	// Token: 0x04000006 RID: 6
	private IXUILabel m_itemName;

	// Token: 0x04000007 RID: 7
	private Transform m_ItemIcon;
}
