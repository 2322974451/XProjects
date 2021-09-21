using System;
using UILib;
using UnityEngine;
using XMainClient;
using XUtliPoolLib;

// Token: 0x02000003 RID: 3
public class TitleDisplay
{
	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600000C RID: 12 RVA: 0x000024A2 File Offset: 0x000006A2
	// (set) Token: 0x0600000D RID: 13 RVA: 0x000024AA File Offset: 0x000006AA
	public Transform transform { get; private set; }

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600000E RID: 14 RVA: 0x000024B4 File Offset: 0x000006B4
	public GameObject gameObject
	{
		get
		{
			return this.transform.gameObject;
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000024D4 File Offset: 0x000006D4
	public void Init(Transform go)
	{
		this.transform = go;
		this.m_FightValue = (this.transform.FindChild("Fight/FightValue").GetComponent("XUILabel") as IXUILabel);
		this.m_TitleName = (this.transform.FindChild("TitleName").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
		this.m_TitleSprite = (this.transform.FindChild("TitleName").GetComponent("XUISprite") as IXUISprite);
		this.m_TitleTexture = (this.transform.FindChild("TitleIcon").GetComponent("XUITexture") as IXUITexture);
		Transform transform = this.transform.FindChild("Att/AttTmpl");
		this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, true);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000025B0 File Offset: 0x000007B0
	public void Set(TitleTable.RowData rowData)
	{
		bool flag = rowData == null;
		if (flag)
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			bool flag2 = this.m_selectTitle == (int)rowData.RankID;
			if (!flag2)
			{
				this.Reset();
				this.m_selectTitle = (int)rowData.RankID;
				this.gameObject.SetActive(true);
				this.m_ItemPool.FakeReturnAll();
				double num = 0.0;
				int i = 0;
				int count = rowData.Attribute.Count;
				while (i < count)
				{
					GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
					num += XSingleton<XPowerPointCalculator>.singleton.GetPPT(rowData.Attribute[i, 0], rowData.Attribute[i, 1], null, -1);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Value").GetComponent("XUILabel") as IXUILabel;
					IXUILabel ixuilabel2 = gameObject.transform.FindChild("Label").GetComponent("XUILabel") as IXUILabel;
					ixuilabel2.SetText(XStringDefineProxy.GetString((XAttributeDefine)rowData.Attribute[i, 0]));
					ixuilabel.SetText(XSingleton<XCommon>.singleton.StringCombine("+", rowData.Attribute[i, 1].ToString()));
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)i * 30 - 10), 0f);
					i++;
				}
				this.m_ItemPool.ActualReturnAll(false);
				this.m_FightValue.SetText(XSingleton<XCommon>.singleton.StringCombine("+", ((uint)num).ToString()));
				this.m_TitleName.SetNamePrefix(rowData.RankAtlas, rowData.RankIcon);
				this.m_TitleName.SetFrameRate(XTitleDocument.TITLE_FRAME_RATE);
				this.m_TitleName.MakePixelPerfect();
				this.m_TitleTexture.SetTexturePath(rowData.RankPath);
				bool flag3 = string.IsNullOrEmpty(rowData.AffectRoute);
				if (!flag3)
				{
					this.m_titleEffect = XSingleton<XFxMgr>.singleton.CreateUIFx(rowData.AffectRoute, this.m_TitleTexture.gameObject.transform, false);
				}
			}
		}
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000027F0 File Offset: 0x000009F0
	public void Reset()
	{
		bool flag = this.m_titleEffect != null;
		if (flag)
		{
			XSingleton<XFxMgr>.singleton.DestroyFx(this.m_titleEffect, true);
		}
		this.m_TitleTexture.SetTexturePath("");
	}

	// Token: 0x04000009 RID: 9
	private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

	// Token: 0x0400000A RID: 10
	private IXUILabel m_FightValue;

	// Token: 0x0400000B RID: 11
	private IXUISpriteAnimation m_TitleName;

	// Token: 0x0400000C RID: 12
	private IXUISprite m_TitleSprite;

	// Token: 0x0400000D RID: 13
	private IXUITexture m_TitleTexture;

	// Token: 0x0400000E RID: 14
	private XFx m_titleEffect;

	// Token: 0x0400000F RID: 15
	private int m_selectTitle = -1;
}
