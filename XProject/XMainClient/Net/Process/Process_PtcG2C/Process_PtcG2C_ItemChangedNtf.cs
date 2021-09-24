using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_ItemChangedNtf
	{

		public static void Process(PtcG2C_ItemChangedNtf roPtc)
		{
			XSingleton<XGame>.singleton.Doc.XBagDoc.AddNewItem(roPtc.Data.NewItems, !roPtc.Data.IsRearrange);
			XSingleton<XGame>.singleton.Doc.XBagDoc.AddNewItem(roPtc.Data.recyleadditems, false);
			XSingleton<XGame>.singleton.Doc.XBagDoc.RemoveItem(roPtc.Data.RemoveItems);
			for (int i = 0; i < roPtc.Data.ChangeItems.Count; i += 2)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.ChangeItemCount(roPtc.Data.ChangeItems[i], (int)roPtc.Data.ChangeItems[i + 1], !roPtc.Data.IsRearrange);
			}
			for (int i = 0; i < roPtc.Data.recylechangeitems.Count; i += 2)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.ChangeItemCount(roPtc.Data.recylechangeitems[i], (int)roPtc.Data.recylechangeitems[i + 1], false);
			}
			for (int i = 0; i < roPtc.Data.SwapItems.Count; i += 2)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.SwapItem(roPtc.Data.SwapItems[i], roPtc.Data.SwapItems[i + 1]);
			}
			for (int i = 0; i < roPtc.Data.AttrChangeItems.Count; i++)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.UpdateItem(roPtc.Data.AttrChangeItems[i]);
			}
			for (int i = 0; i < roPtc.Data.VirtualItemID.Count; i++)
			{
				XSingleton<XGame>.singleton.Doc.XBagDoc.SetVirtualItemCount(roPtc.Data.VirtualItemID[i], (ulong)roPtc.Data.VirtualItemCount[i]);
			}
			XSingleton<XGame>.singleton.Doc.XBagDoc.FinishItemChange();
		}
	}
}
