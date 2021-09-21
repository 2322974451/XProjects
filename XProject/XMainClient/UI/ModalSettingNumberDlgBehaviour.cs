using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200186F RID: 6255
	public class ModalSettingNumberDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601047F RID: 66687 RVA: 0x003F0A64 File Offset: 0x003EEC64
		private void Awake()
		{
			this.AddBtn = (base.transform.FindChild("Count/Add").GetComponent("XUIButton") as IXUIButton);
			this.SubBtn = (base.transform.FindChild("Count/Sub").GetComponent("XUIButton") as IXUIButton);
			this.numLabel = (base.transform.FindChild("Count/number").GetComponent("XUILabel") as IXUILabel);
			this.titleLabel = (base.transform.Find("findname").GetComponent("XUILabel") as IXUILabel);
			this.CancelBtn = (base.transform.Find("BtnNO").GetComponent("XUIButton") as IXUIButton);
			this.OkBtn = (base.transform.Find("BtnOK").GetComponent("XUIButton") as IXUIButton);
			this.itemObject = base.transform.Find("ItemTemplate").gameObject;
			this.backSprite = (base.transform.Find("back").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04007516 RID: 29974
		public IXUIButton AddBtn;

		// Token: 0x04007517 RID: 29975
		public IXUIButton SubBtn;

		// Token: 0x04007518 RID: 29976
		public IXUIButton CancelBtn;

		// Token: 0x04007519 RID: 29977
		public IXUIButton OkBtn;

		// Token: 0x0400751A RID: 29978
		public GameObject itemObject;

		// Token: 0x0400751B RID: 29979
		public IXUILabel numLabel;

		// Token: 0x0400751C RID: 29980
		public IXUILabel titleLabel;

		// Token: 0x0400751D RID: 29981
		public IXUISprite backSprite;
	}
}
