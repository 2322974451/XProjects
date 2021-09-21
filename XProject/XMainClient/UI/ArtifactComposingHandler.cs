using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017AE RID: 6062
	internal class ArtifactComposingHandler : DlgHandlerBase
	{
		// Token: 0x17003873 RID: 14451
		// (get) Token: 0x0600FAB2 RID: 64178 RVA: 0x003A0410 File Offset: 0x0039E610
		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactComposeFrame";
			}
		}

		// Token: 0x0600FAB3 RID: 64179 RVA: 0x003A0428 File Offset: 0x0039E628
		protected override void Init()
		{
			base.Init();
			this.m_doc = ArtifactComposeDocument.Doc;
			this.m_artifactBagdoc = ArtifactBagDocument.Doc;
			this.m_textLab = (base.PanelObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel);
			this.m_barView = base.PanelObject.transform.Find("Making").gameObject;
			this.m_sprBar = (this.m_barView.transform.FindChild("Bar").GetComponent("XUISprite") as IXUISprite);
			this.m_doBtn = (base.PanelObject.transform.FindChild("Do").GetComponent("XUIButton") as IXUIButton);
			this.m_doLab = (base.PanelObject.transform.Find("Do/T").GetComponent("XUILabel") as IXUILabel);
			this.m_successEffectTra = base.PanelObject.transform.Find("Suc");
			string @string = XSingleton<XStringTable>.singleton.GetString("ArtifactComposeSuccessEffectName");
			this.m_successFx = XSingleton<XFxMgr>.singleton.CreateUIFx(@string, this.m_successEffectTra, false);
			this.m_itemView = new EquipSetItemBaseView();
			this.m_itemView.FindFrom(base.PanelObject.transform);
			this.m_barFullWidth = this.m_sprBar.spriteWidth;
		}

		// Token: 0x0600FAB4 RID: 64180 RVA: 0x0019EEB0 File Offset: 0x0019D0B0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		// Token: 0x0600FAB5 RID: 64181 RVA: 0x003A0591 File Offset: 0x0039E791
		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

		// Token: 0x0600FAB6 RID: 64182 RVA: 0x003A05A4 File Offset: 0x0039E7A4
		protected override void OnHide()
		{
			base.OnHide();
			this.HideEffect();
			bool flag = this.m_successEffectTra != null;
			if (flag)
			{
				this.m_successEffectTra.gameObject.SetActive(false);
			}
			base.PanelObject.SetActive(false);
			this.m_quanlityFx.Reset();
		}

		// Token: 0x0600FAB7 RID: 64183 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x0600FAB8 RID: 64184 RVA: 0x003A05FC File Offset: 0x0039E7FC
		public override void OnUnload()
		{
			base.OnUnload();
			this.m_doc = null;
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_creatFx, true);
				this.m_creatFx = null;
			}
			bool flag2 = this.m_successFx != null;
			if (flag2)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_successFx, true);
				this.m_successFx = null;
			}
			this.m_quanlityFx.Reset();
		}

		// Token: 0x0600FAB9 RID: 64185 RVA: 0x003A0674 File Offset: 0x0039E874
		private void FillContent()
		{
			bool flag = this.m_itemView.goItem != null;
			if (flag)
			{
				this.m_itemView.goItem.SetActive(false);
			}
		}

		// Token: 0x0600FABA RID: 64186 RVA: 0x003A06AC File Offset: 0x0039E8AC
		public void SetFinishState(bool bFinish)
		{
			this.m_barView.SetActive(!bFinish);
			this.m_successEffectTra.gameObject.SetActive(bFinish);
			this.m_doBtn.SetVisible(true);
			if (bFinish)
			{
				this.HideEffect();
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_Upgrade_Gear", true, AudioChannel.Action);
				this.m_textLab.SetText(XStringDefineProxy.GetString("EQUIPCREATE_EQUIPSET_SUCCESS").Replace("{n}", "\n"));
				this.m_doLab.SetText(XStringDefineProxy.GetString(XStringDefine.COMMON_OK));
				this.m_doBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonOK));
			}
			else
			{
				this.ShowEffect();
				this.m_textLab.SetText(XStringDefineProxy.GetString("Artifact_compose_tips"));
				this.m_doLab.SetText(XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL));
				this.m_doBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickButtonCancel));
			}
		}

		// Token: 0x0600FABB RID: 64187 RVA: 0x003A07A4 File Offset: 0x0039E9A4
		public void SetFinishArtifactInfo(XItem item)
		{
			bool flag = this.m_itemView.goItem != null;
			if (flag)
			{
				this.m_itemView.goItem.SetActive(true);
			}
			bool flag2 = item != null && item.uid > 0UL && item.itemID > 0;
			if (flag2)
			{
				bool flag3 = base.IsVisible() && this.m_itemView != null;
				if (flag3)
				{
					EquipSetItemBaseView.stEquipInfoParam param;
					param.isShowTooltip = false;
					param.playerProf = 0;
					this.m_itemView.SetItemInfo(item, param, item.bBinding);
					bool flag4 = item.itemConf != null;
					if (flag4)
					{
						this.SetEffect(this.m_itemView.goItem, item.itemID);
					}
				}
				this.m_itemView.SetFinishItem(item);
			}
		}

		// Token: 0x0600FABC RID: 64188 RVA: 0x003A086C File Offset: 0x0039EA6C
		private void ShowEffect()
		{
			bool flag = this.m_creatFx == null;
			if (flag)
			{
				this.m_creatFx = XSingleton<XFxMgr>.singleton.CreateFx(this.CreatePath, null, true);
			}
			else
			{
				this.m_creatFx.SetActive(true);
			}
			this.m_creatFx.Play(base.PanelObject.transform.FindChild("Bg"), Vector3.zero, Vector3.one, 1f, true, false);
			XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/UI_datie", true, AudioChannel.Action);
		}

		// Token: 0x17003874 RID: 14452
		// (get) Token: 0x0600FABD RID: 64189 RVA: 0x003A08F8 File Offset: 0x0039EAF8
		public string CreatePath
		{
			get
			{
				bool flag = string.IsNullOrEmpty(this.m_createPath);
				if (flag)
				{
					this.m_createPath = XSingleton<XGlobalConfig>.singleton.GetValue("EquipCreatEffectPath");
				}
				return this.m_createPath;
			}
		}

		// Token: 0x0600FABE RID: 64190 RVA: 0x003A0934 File Offset: 0x0039EB34
		private void SetEffect(GameObject go, int itemId)
		{
			bool flag = go == null;
			if (!flag)
			{
				ItemList.RowData itemConf = XBagDocument.GetItemConf(itemId);
				bool flag2 = itemConf == null;
				if (!flag2)
				{
					ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemId);
					bool flag3 = artifactListRowData == null;
					if (!flag3)
					{
						ulong key = this.m_artifactBagdoc.MakeKey((uint)itemConf.ItemQuality, artifactListRowData.AttrType);
						string path;
						bool flag4 = !this.m_artifactBagdoc.GetArtifactEffectPath(key, out path);
						if (flag4)
						{
							this.m_quanlityFx.Reset();
						}
						else
						{
							bool flag5 = !this.m_quanlityFx.IsCanReuse(key);
							if (flag5)
							{
								this.m_quanlityFx.SetData(key, go.transform.FindChild("Icon/Icon/Effects"), path);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600FABF RID: 64191 RVA: 0x003A09F0 File Offset: 0x0039EBF0
		private void HideEffect()
		{
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				this.m_creatFx.SetActive(false);
				this.m_creatFx.Stop();
			}
		}

		// Token: 0x0600FAC0 RID: 64192 RVA: 0x003A0A26 File Offset: 0x0039EC26
		public void SetBar(int f)
		{
			f = Mathf.Clamp(f, 1, 100);
			this.m_sprBar.spriteWidth = this.m_barFullWidth * f / 100;
		}

		// Token: 0x0600FAC1 RID: 64193 RVA: 0x003A0A4C File Offset: 0x0039EC4C
		private bool OnClickButtonOK(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool isComposing = this.m_doc.IsComposing;
				if (isComposing)
				{
					result = true;
				}
				else
				{
					base.SetVisible(false);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FAC2 RID: 64194 RVA: 0x003A0A90 File Offset: 0x0039EC90
		private bool OnClickButtonCancel(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool isComposing = this.m_doc.IsComposing;
				if (isComposing)
				{
					result = true;
				}
				else
				{
					base.SetVisible(false);
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600FAC3 RID: 64195 RVA: 0x003A0AD4 File Offset: 0x0039ECD4
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x04006DE7 RID: 28135
		private ArtifactComposeDocument m_doc;

		// Token: 0x04006DE8 RID: 28136
		private ArtifactBagDocument m_artifactBagdoc;

		// Token: 0x04006DE9 RID: 28137
		private IXUILabel m_textLab;

		// Token: 0x04006DEA RID: 28138
		private IXUIButton m_doBtn;

		// Token: 0x04006DEB RID: 28139
		private IXUILabel m_doLab;

		// Token: 0x04006DEC RID: 28140
		private IXUISprite m_sprBar;

		// Token: 0x04006DED RID: 28141
		private GameObject m_barView;

		// Token: 0x04006DEE RID: 28142
		private XFx m_creatFx = null;

		// Token: 0x04006DEF RID: 28143
		private XFx m_successFx = null;

		// Token: 0x04006DF0 RID: 28144
		private Transform m_successEffectTra;

		// Token: 0x04006DF1 RID: 28145
		private EquipSetItemBaseView m_itemView;

		// Token: 0x04006DF2 RID: 28146
		private ArtifactQuanlityFx m_quanlityFx = new ArtifactQuanlityFx();

		// Token: 0x04006DF3 RID: 28147
		private float m_fCoolTime = 0.5f;

		// Token: 0x04006DF4 RID: 28148
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x04006DF5 RID: 28149
		private int m_barFullWidth;

		// Token: 0x04006DF6 RID: 28150
		private string m_createPath = string.Empty;
	}
}
