using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001787 RID: 6023
	internal class XWeddingLitterBoyDramaOperate : XDramaOperate
	{
		// Token: 0x0600F892 RID: 63634 RVA: 0x0038D2D4 File Offset: 0x0038B4D4
		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WeddingFireworksCost", XGlobalConfig.SequenceSeparator);
			uint num = uint.Parse(andSeparateValue[1]) * XWeddingDocument.Doc.AllAttendPlayerCount;
			string text = "";
			ItemList.RowData itemConf = XBagDocument.GetItemConf(int.Parse(andSeparateValue[0]));
			bool flag = itemConf != null;
			if (flag)
			{
				text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			}
			this._param.Text = string.Format(XStringDefineProxy.GetString("WeddingFireworksTip", new object[]
			{
				num,
				text
			}), new object[0]);
			this._param.AppendButton(XStringDefineProxy.GetString(XStringDefine.COMMON_OK), new ButtonClickEventHandler(this.ToDoSomething), 0UL);
			base._FireEvent(this._param);
		}

		// Token: 0x0600F893 RID: 63635 RVA: 0x0038D3BC File Offset: 0x0038B5BC
		private bool ToDoSomething(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Fireworks);
			return true;
		}

		// Token: 0x04006C78 RID: 27768
		private XDramaOperateParam _param;
	}
}
