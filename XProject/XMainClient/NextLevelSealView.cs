using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C48 RID: 3144
	internal class NextLevelSealView : DlgBase<NextLevelSealView, NextLevelSealBehaviour>
	{
		// Token: 0x17003189 RID: 12681
		// (get) Token: 0x0600B257 RID: 45655 RVA: 0x0022675C File Offset: 0x0022495C
		public override string fileName
		{
			get
			{
				return "OperatingActivity/NextSeal";
			}
		}

		// Token: 0x1700318A RID: 12682
		// (get) Token: 0x0600B258 RID: 45656 RVA: 0x00226774 File Offset: 0x00224974
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700318B RID: 12683
		// (get) Token: 0x0600B259 RID: 45657 RVA: 0x00226788 File Offset: 0x00224988
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700318C RID: 12684
		// (get) Token: 0x0600B25A RID: 45658 RVA: 0x0022679C File Offset: 0x0022499C
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B25B RID: 45659 RVA: 0x002267AF File Offset: 0x002249AF
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
		}

		// Token: 0x0600B25C RID: 45660 RVA: 0x002267C2 File Offset: 0x002249C2
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B25D RID: 45661 RVA: 0x002267E4 File Offset: 0x002249E4
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B25E RID: 45662 RVA: 0x00226800 File Offset: 0x00224A00
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshPage();
		}

		// Token: 0x0600B25F RID: 45663 RVA: 0x00226814 File Offset: 0x00224A14
		protected override void OnHide()
		{
			base.uiBehaviour.m_NextSealTexL.SetTexturePath("");
			base.uiBehaviour.m_NextSealTexR.SetTexturePath("");
			base.uiBehaviour.m_NextSealTexM.SetTexturePath("");
			base.OnHide();
		}

		// Token: 0x0600B260 RID: 45664 RVA: 0x0022686B File Offset: 0x00224A6B
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B261 RID: 45665 RVA: 0x00226878 File Offset: 0x00224A78
		public void RefreshPage()
		{
			uint removeSealType = this.doc.GetRemoveSealType(XSingleton<XAttributeMgr>.singleton.XPlayerData.Level);
			Queue<LevelSealNewFunctionTable.RowData> levelSealNewFunction = this.doc.GetLevelSealNewFunction(removeSealType);
			base.uiBehaviour.m_NewFunctionPool.ReturnAll(false);
			int count = levelSealNewFunction.Count;
			for (int i = 0; i < count; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_NewFunctionPool.FetchGameObject(false);
				LevelSealNewFunctionTable.RowData rowData = levelSealNewFunction.Dequeue();
				(gameObject.transform.Find("Function/Level").GetComponent("XUILabel") as IXUILabel).SetText(rowData.OpenLevel.ToString() + XStringDefineProxy.GetString("SEAL_OPEN_FUNCTION"));
				(gameObject.transform.Find("Function/Name").GetComponent("XUILabel") as IXUILabel).SetText(rowData.Tag);
				(gameObject.transform.Find("Function/P").GetComponent("XUISprite") as IXUISprite).SetSprite(rowData.IconName);
				gameObject.transform.localPosition = new Vector3((float)(base.uiBehaviour.m_NewFunctionPool.TplWidth * i), 0f, 0f);
			}
			bool flag = count == 0;
			if (flag)
			{
				base.uiBehaviour.m_NewFunction.gameObject.SetActive(false);
			}
			else
			{
				base.uiBehaviour.m_NewFunction.gameObject.SetActive(true);
				base.uiBehaviour.m_NewFunctionBg.spriteWidth = base.uiBehaviour.m_NewFunctionBgWidth + (count - 1) * base.uiBehaviour.m_NewFunctionPool.TplWidth;
			}
			LevelSealTypeTable.RowData levelSealType = XLevelSealDocument.GetLevelSealType(removeSealType);
			bool flag2 = !string.IsNullOrEmpty(levelSealType.NextSealImageL);
			if (flag2)
			{
				base.uiBehaviour.m_NextSealTexL.SetTexturePath(levelSealType.NextSealImageL);
			}
			bool flag3 = !string.IsNullOrEmpty(levelSealType.NextSealImageR);
			if (flag3)
			{
				base.uiBehaviour.m_NextSealTexR.SetTexturePath(levelSealType.NextSealImageR);
			}
			bool flag4 = levelSealType.NextSealImageBig != null && levelSealType.NextSealImageBig != "";
			if (flag4)
			{
				base.uiBehaviour.m_NextSealTexM.SetAlpha(1f);
				base.uiBehaviour.m_NextSealTexM.SetTexturePath(levelSealType.NextSealImageBig);
			}
			else
			{
				base.uiBehaviour.m_NextSealTexM.SetAlpha(0f);
			}
		}

		// Token: 0x0600B262 RID: 45666 RVA: 0x00226B05 File Offset: 0x00224D05
		public void SetNextSealLabel(string str)
		{
			base.uiBehaviour.m_NextSealLabel.SetText(str);
		}

		// Token: 0x0600B263 RID: 45667 RVA: 0x00226B1A File Offset: 0x00224D1A
		public void SetPosition(Vector3 pos)
		{
			base.uiBehaviour.transform.position = pos;
		}

		// Token: 0x040044BD RID: 17597
		private XLevelSealDocument doc = null;
	}
}
