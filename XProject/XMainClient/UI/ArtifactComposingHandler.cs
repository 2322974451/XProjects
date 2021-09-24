using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class ArtifactComposingHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "ItemNew/ArtifactComposeFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.FillContent();
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

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

		private void FillContent()
		{
			bool flag = this.m_itemView.goItem != null;
			if (flag)
			{
				this.m_itemView.goItem.SetActive(false);
			}
		}

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

		private void HideEffect()
		{
			bool flag = this.m_creatFx != null;
			if (flag)
			{
				this.m_creatFx.SetActive(false);
				this.m_creatFx.Stop();
			}
		}

		public void SetBar(int f)
		{
			f = Mathf.Clamp(f, 1, 100);
			this.m_sprBar.spriteWidth = this.m_barFullWidth * f / 100;
		}

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

		private ArtifactComposeDocument m_doc;

		private ArtifactBagDocument m_artifactBagdoc;

		private IXUILabel m_textLab;

		private IXUIButton m_doBtn;

		private IXUILabel m_doLab;

		private IXUISprite m_sprBar;

		private GameObject m_barView;

		private XFx m_creatFx = null;

		private XFx m_successFx = null;

		private Transform m_successEffectTra;

		private EquipSetItemBaseView m_itemView;

		private ArtifactQuanlityFx m_quanlityFx = new ArtifactQuanlityFx();

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private int m_barFullWidth;

		private string m_createPath = string.Empty;
	}
}
