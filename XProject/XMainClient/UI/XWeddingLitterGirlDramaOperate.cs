using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001788 RID: 6024
	internal class XWeddingLitterGirlDramaOperate : XDramaOperate
	{
		// Token: 0x0600F895 RID: 63637 RVA: 0x0038D3F8 File Offset: 0x0038B5F8
		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			string[] andSeparateValue = XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("WeddingFlowerCost", XGlobalConfig.SequenceSeparator);
			uint num = uint.Parse(andSeparateValue[1]) * XWeddingDocument.Doc.AllAttendPlayerCount;
			string text = "";
			ItemList.RowData itemConf = XBagDocument.GetItemConf(int.Parse(andSeparateValue[0]));
			bool flag = itemConf != null;
			if (flag)
			{
				text = XSingleton<UiUtility>.singleton.ChooseProfString(itemConf.ItemName, 0U);
			}
			this._param.Text = string.Format(XStringDefineProxy.GetString("WeddingFlowerTip", new object[]
			{
				num,
				text
			}), new object[0]);
			this._param.AppendButton(XStringDefineProxy.GetString(XStringDefine.COMMON_OK), new ButtonClickEventHandler(this.ToDoSomething), 0UL);
			base._FireEvent(this._param);
		}

		// Token: 0x0600F896 RID: 63638 RVA: 0x0038D4E0 File Offset: 0x0038B6E0
		private bool ToDoSomething(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			XWeddingDocument.Doc.WeddingSceneOperator(WeddingOperType.WeddingOper_Flower);
			return true;
		}

		// Token: 0x04006C79 RID: 27769
		private XDramaOperateParam _param;
	}
}
