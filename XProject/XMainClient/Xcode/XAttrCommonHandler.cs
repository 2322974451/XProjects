using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XAttrCommonHandler<T> : DlgHandlerBase where T : XAttrCommonFile, new()
	{

		public List<XAttrData> AttrDataList
		{
			get
			{
				return this.m_AttrDataList;
			}
		}

		public XAttrCommonHandler()
		{
			this.m_File = Activator.CreateInstance<T>();
		}

		protected override string FileName
		{
			get
			{
				return this.m_File.FileName;
			}
		}

		protected override void Init()
		{
			base.Init();
			Transform transform = base.PanelObject.transform.Find("AttrFrame/Panel/TitleTpl");
			this.m_TitlePool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("AttrFrame/Panel/AttrTpl");
			this.m_AttrPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("AttrFrame/Panel/EmptyTpl");
			this.m_EmptyPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = base.PanelObject.transform.Find("AttrFrame/Panel/SkillItem");
			this.m_SkillPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			transform = base.PanelObject.transform.Find("AttrFrame/Panel/SingleItem");
			this.m_SinglePool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_ScrollView = (base.PanelObject.transform.Find("AttrFrame/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.PanelObject.transform.Find("AttrFrame/Close");
			bool flag = transform != null;
			if (flag)
			{
				this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			bool flag = this.m_Close != null;
			if (flag)
			{
				this.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnCloseClicked));
			}
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		protected override void OnHide()
		{
			base.OnHide();
			this.m_TitlePool.ReturnAll(false);
			this.m_AttrPool.ReturnAll(false);
			this.m_EmptyPool.ReturnAll(false);
			this.m_SkillPool.ReturnAll(false);
			this.m_SinglePool.ReturnAll(false);
		}

		private void _OnCloseClicked(IXUISprite iSp)
		{
			base.SetVisible(false);
		}

		public void EnableClose(bool bEnable)
		{
			bool flag = this.m_Close != null;
			if (flag)
			{
				this.m_Close.SetVisible(bEnable);
			}
		}

		protected void _ResetData()
		{
			for (int i = 0; i < this.m_AttrDataList.Count; i++)
			{
				this.m_AttrDataList[i].Recycle();
			}
			this.m_AttrDataList.Clear();
		}

		protected XAttrData _FetchAttrData()
		{
			XAttrData data = XDataPool<XAttrData>.GetData();
			this.m_AttrDataList.Add(data);
			return data;
		}

		public virtual void SetData()
		{
			this._ResetData();
		}

		public override void RefreshData()
		{
			base.RefreshData();
			this.SetData();
			this.RefreshPage();
			this.m_ScrollView.ResetPosition();
		}

		public void RefreshPage()
		{
			this.m_TitlePool.FakeReturnAll();
			this.m_AttrPool.FakeReturnAll();
			this.m_EmptyPool.FakeReturnAll();
			this.m_SkillPool.FakeReturnAll();
			this.m_SinglePool.FakeReturnAll();
			int num = 0;
			int i = 0;
			while (i < this.m_AttrDataList.Count)
			{
				XAttrData xattrData = this.m_AttrDataList[i];
				GameObject gameObject = this.m_TitlePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(this.m_TitlePool.TplPos.x, (float)num, this.m_TitlePool.TplPos.z);
				IXUILabel ixuilabel = gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(xattrData.Title);
				num -= this.m_TitlePool.TplHeight;
				GameObject gameObject2 = null;
				bool flag = string.IsNullOrEmpty(xattrData.StrEmpty);
				if (flag)
				{
					bool flag2 = xattrData.Left.Count != xattrData.Right.Count;
					if (flag2)
					{
						XSingleton<XDebug>.singleton.AddErrorLog(string.Format("data.Left.Count != data.Right.Count, {0} != {1}", xattrData.Left.Count, xattrData.Right.Count), null, null, null, null, null);
					}
					else
					{
						IXUILabel ixuilabel2 = this.m_SinglePool._tpl.transform.FindChild("Text").GetComponent("XUILabel") as IXUILabel;
						int num2 = this.m_SinglePool.TplHeight - ixuilabel2.fontSize;
						int num3 = ixuilabel2.spriteHeight / 2;
						for (int j = 0; j < xattrData.Left.Count; j++)
						{
							switch (xattrData.Type)
							{
							case AttriDataType.Attri:
								gameObject2 = this.m_AttrPool.FetchGameObject(false);
								break;
							case AttriDataType.Skill:
								gameObject2 = this.m_SkillPool.FetchGameObject(false);
								break;
							case AttriDataType.SingleLine:
							{
								gameObject2 = this.m_SinglePool.FetchGameObject(false);
								bool flag3 = j == 0;
								if (flag3)
								{
									num += num3;
								}
								break;
							}
							}
							gameObject2.transform.localPosition = new Vector3(this.m_AttrPool.TplPos.x, (float)num, this.m_AttrPool.TplPos.z);
							AttriDataType type = xattrData.Type;
							if (type - AttriDataType.Attri > 1)
							{
								if (type == AttriDataType.SingleLine)
								{
									ixuilabel2 = (gameObject2.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
									ixuilabel2.SetText(xattrData.Left[j]);
								}
							}
							else
							{
								IXUILabel ixuilabel3 = gameObject2.transform.Find("Left").GetComponent("XUILabel") as IXUILabel;
								IXUILabel ixuilabel4 = gameObject2.transform.Find("Right").GetComponent("XUILabel") as IXUILabel;
								ixuilabel3.SetText(xattrData.Left[j]);
								ixuilabel4.SetText(xattrData.Right[j]);
							}
							switch (xattrData.Type)
							{
							case AttriDataType.Attri:
								num -= this.m_AttrPool.TplHeight;
								break;
							case AttriDataType.Skill:
								num -= this.m_SkillPool.TplHeight;
								break;
							case AttriDataType.SingleLine:
							{
								num -= ixuilabel2.spriteHeight + num2;
								bool flag4 = j == xattrData.Left.Count - 1;
								if (flag4)
								{
									num -= num3;
								}
								break;
							}
							}
						}
					}
				}
				else
				{
					GameObject gameObject3 = this.m_EmptyPool.FetchGameObject(false);
					gameObject3.transform.localPosition = new Vector3(this.m_EmptyPool.TplPos.x, (float)num, this.m_EmptyPool.TplPos.z);
					IXUILabel ixuilabel5 = gameObject3.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
					ixuilabel5.SetText(xattrData.StrEmpty);
					num -= this.m_EmptyPool.TplHeight;
				}
				IL_40B:
				i++;
				continue;
				goto IL_40B;
			}
			this.m_TitlePool.ActualReturnAll(false);
			this.m_AttrPool.ActualReturnAll(false);
			this.m_EmptyPool.ActualReturnAll(false);
			this.m_SkillPool.ActualReturnAll(false);
			this.m_SinglePool.ActualReturnAll(false);
		}

		private XUIPool m_AttrPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_TitlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_EmptyPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_SinglePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUISprite m_Close;

		private IXUIScrollView m_ScrollView;

		private List<uint> m_AttrList = new List<uint>();

		private List<IXUILabel> m_UILabelList = new List<IXUILabel>();

		private List<XAttrData> m_AttrDataList = new List<XAttrData>();

		private T m_File;
	}
}
