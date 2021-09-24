using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWeddingLitterGirlDramaOperate : XDramaOperate
	{

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

		private XDramaOperateParam _param;
	}
}
