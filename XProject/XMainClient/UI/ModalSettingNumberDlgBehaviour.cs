using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	public class ModalSettingNumberDlgBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton AddBtn;

		public IXUIButton SubBtn;

		public IXUIButton CancelBtn;

		public IXUIButton OkBtn;

		public GameObject itemObject;

		public IXUILabel numLabel;

		public IXUILabel titleLabel;

		public IXUISprite backSprite;
	}
}
