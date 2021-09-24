using System;
using UILib;
using UnityEngine;
using XMainClient;
using XUtliPoolLib;

public class TitleDisplay
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
		this.m_FightValue = (this.transform.FindChild("Fight/FightValue").GetComponent("XUILabel") as IXUILabel);
		this.m_TitleName = (this.transform.FindChild("TitleName").GetComponent("XUISpriteAnimation") as IXUISpriteAnimation);
		this.m_TitleSprite = (this.transform.FindChild("TitleName").GetComponent("XUISprite") as IXUISprite);
		this.m_TitleTexture = (this.transform.FindChild("TitleIcon").GetComponent("XUITexture") as IXUITexture);
		Transform transform = this.transform.FindChild("Att/AttTmpl");
		this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, true);
	}

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

	public void Reset()
	{
		bool flag = this.m_titleEffect != null;
		if (flag)
		{
			XSingleton<XFxMgr>.singleton.DestroyFx(this.m_titleEffect, true);
		}
		this.m_TitleTexture.SetTexturePath("");
	}

	private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

	private IXUILabel m_FightValue;

	private IXUISpriteAnimation m_TitleName;

	private IXUISprite m_TitleSprite;

	private IXUITexture m_TitleTexture;

	private XFx m_titleEffect;

	private int m_selectTitle = -1;
}
