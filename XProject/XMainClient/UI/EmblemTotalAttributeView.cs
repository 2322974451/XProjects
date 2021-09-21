using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200181E RID: 6174
	internal class EmblemTotalAttributeView : DlgHandlerBase
	{
		// Token: 0x17003918 RID: 14616
		// (get) Token: 0x0601006B RID: 65643 RVA: 0x003CF098 File Offset: 0x003CD298
		protected override string FileName
		{
			get
			{
				return "ItemNew/TotalAttribute";
			}
		}

		// Token: 0x0601006C RID: 65644 RVA: 0x003CF0B0 File Offset: 0x003CD2B0
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

		// Token: 0x0601006D RID: 65645 RVA: 0x003CF1F7 File Offset: 0x003CD3F7
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0601006E RID: 65646 RVA: 0x0019EF07 File Offset: 0x0019D107
		public override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0601006F RID: 65647 RVA: 0x003CF208 File Offset: 0x003CD408
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

		// Token: 0x06010070 RID: 65648 RVA: 0x003CF250 File Offset: 0x003CD450
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

		// Token: 0x06010071 RID: 65649 RVA: 0x003CF618 File Offset: 0x003CD818
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

		// Token: 0x06010072 RID: 65650 RVA: 0x003CF6BC File Offset: 0x003CD8BC
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

		// Token: 0x06010073 RID: 65651 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnClickClosedBtn(IXUISprite spr)
		{
			base.SetVisible(false);
		}

		// Token: 0x040071EE RID: 29166
		private XEmblemDocument m_doc;

		// Token: 0x040071EF RID: 29167
		private GameObject _HadGo;

		// Token: 0x040071F0 RID: 29168
		private GameObject _NoGo;

		// Token: 0x040071F1 RID: 29169
		public IXUISprite m_closedBtn;

		// Token: 0x040071F2 RID: 29170
		public XUIPool m_AttriPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071F3 RID: 29171
		public XUIPool m_SkillPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040071F4 RID: 29172
		public XUIPool m_TittlePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
