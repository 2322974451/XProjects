using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class EmblemTotalAttributeView : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/TotalAttribute";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.m_doc = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
			this.m_closedBtn = (base.PanelObject.transform.FindChild("ClisedSpr").GetComponent("XUISprite") as IXUISprite);
			this.m_closedBtn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickClosedBtn));
			this._HadGo = base.PanelObject.transform.FindChild("HadEmblem").gameObject;
			this._NoGo = base.PanelObject.transform.FindChild("NoEmblem").gameObject;
			Transform transform = this._HadGo.transform.FindChild("Grid");
			this.m_AttriPool.SetupPool(transform.gameObject, this._HadGo.transform.FindChild("AttriItem").gameObject, 2U, false);
			this.m_SkillPool.SetupPool(transform.gameObject, this._HadGo.transform.FindChild("SkillItem").gameObject, 2U, false);
			this.m_TittlePool.SetupPool(transform.gameObject, this._HadGo.transform.FindChild("TittleItem").gameObject, 2U, false);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		private void FillContent()
		{
			this._HadGo.SetActive(false);
			this._NoGo.SetActive(false);
			bool isEquipEmblem = this.m_doc.IsEquipEmblem;
			if (isEquipEmblem)
			{
				this.FillHadContent();
			}
			else
			{
				this.FillNoContent();
			}
		}

		private void FillHadContent()
		{
			this._HadGo.SetActive(true);
			this.m_AttriPool.ReturnAll(false);
			this.m_TittlePool.ReturnAll(false);
			this.m_SkillPool.ReturnAll(false);
			List<ShowAttriData> list = new List<ShowAttriData>();
			List<ShowAttriData> list2 = new List<ShowAttriData>();
			List<ShowAttriData> list3 = new List<ShowAttriData>();
			this.GetData(ref list, ref list2, ref list3);
			int num = 0;
			GameObject gameObject = this.m_TittlePool.FetchGameObject(false);
			gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f);
			IXUILabel ixuilabel = gameObject.transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("EmblemAttriTittle"));
			num += this.m_TittlePool.TplHeight;
			for (int i = 0; i < list.Count; i++)
			{
				gameObject = this.m_AttriPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f);
				ixuilabel = (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(list[i].Name);
				ixuilabel = (gameObject.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(list[i].NumStr);
				num += this.m_AttriPool.TplHeight;
			}
			num += 20;
			for (int j = 0; j < list2.Count; j++)
			{
				gameObject = this.m_AttriPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f);
				ixuilabel = (gameObject.transform.FindChild("Name").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(list2[j].Name);
				ixuilabel = (gameObject.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(list2[j].NumStr);
				num += this.m_AttriPool.TplHeight;
			}
			bool flag = list3.Count <= 0;
			if (!flag)
			{
				num += 30;
				gameObject = this.m_TittlePool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f);
				ixuilabel = (gameObject.transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(XStringDefineProxy.GetString("EmblemSkillTittle"));
				num += this.m_TittlePool.TplHeight;
				for (int k = 0; k < list3.Count; k++)
				{
					gameObject = this.m_SkillPool.FetchGameObject(false);
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)num), 0f);
					ixuilabel = (gameObject.transform.FindChild("Level").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(list3[k].NeedLevelStr);
					ixuilabel = (gameObject.transform.FindChild("SkillName").GetComponent("XUILabel") as IXUILabel);
					ixuilabel.SetText(list3[k].SkillDes);
					num += this.m_SkillPool.TplHeight;
				}
			}
		}

		private void GetData(ref List<ShowAttriData> lst1, ref List<ShowAttriData> lst2, ref List<ShowAttriData> lst3)
		{
			List<ShowAttriData> list = this.m_doc.AttriDataList();
			for (int i = 0; i < list.Count; i++)
			{
				bool flag = list[i].TypeID == 1U;
				if (flag)
				{
					lst1.Add(list[i]);
				}
				else
				{
					bool flag2 = list[i].TypeID == 2U;
					if (flag2)
					{
						lst2.Add(list[i]);
					}
					else
					{
						bool flag3 = list[i].TypeID == 3U;
						if (flag3)
						{
							lst3.Add(list[i]);
						}
					}
				}
			}
		}

		private void FillNoContent()
		{
			this._NoGo.SetActive(true);
			IXUILabel ixuilabel = this._NoGo.transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel;
			ixuilabel.SetText(XStringDefineProxy.GetString("EmblemAttriTittle"));
			ixuilabel = (this._NoGo.transform.FindChild("Content1").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(XStringDefineProxy.GetString("EmblemAttriDes"));
			ixuilabel = (this._NoGo.transform.FindChild("Tittle2").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(XStringDefineProxy.GetString("EmblemSkillTittle"));
			ixuilabel = (this._NoGo.transform.FindChild("Content2").GetComponent("XUILabel") as IXUILabel);
			ixuilabel.SetText(XStringDefineProxy.GetString("EmblemSkillDes"));
		}

		private void OnClickClosedBtn(IXUISprite spr)
		{
			base.SetVisible(false);
		}

		private XEmblemDocument m_doc;

		private GameObject _HadGo;

		private GameObject _NoGo;

		public IXUISprite m_closedBtn;

		public XUIPool m_AttriPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool m_TittlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
