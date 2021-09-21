using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A0D RID: 2573
	internal class XTransformDocument : XDocComponent
	{
		// Token: 0x17002EAA RID: 11946
		// (get) Token: 0x06009DBE RID: 40382 RVA: 0x0019C648 File Offset: 0x0019A848
		public override uint ID
		{
			get
			{
				return XTransformDocument.uuID;
			}
		}

		// Token: 0x06009DBF RID: 40383 RVA: 0x0019C65F File Offset: 0x0019A85F
		public static void Execute(OnLoadedCallback callback = null)
		{
			XTransformDocument.AsyncLoader.AddTask("Table/ItemTransform", XTransformDocument.m_ItemTransformTable, false);
			XTransformDocument.AsyncLoader.Execute(null);
		}

		// Token: 0x06009DC0 RID: 40384 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06009DC1 RID: 40385 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009DC2 RID: 40386 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06009DC3 RID: 40387 RVA: 0x0019C684 File Offset: 0x0019A884
		public static void OnTransform(bool bTrans, XEntity entity, bool bInit, bool bReplace)
		{
			bool flag = !bInit && entity.EngineObject != null;
			if (flag)
			{
				if (bTrans)
				{
					XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/VehicleFX/Vehicle_shangma", entity.EngineObject, Vector3.zero, Vector3.one, 1f, false, 3f, true);
				}
				else
				{
					bool flag2 = !bReplace;
					if (flag2)
					{
						XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/VehicleFX/Vehicle_xiama", entity.EngineObject, Vector3.zero, Vector3.one, 1f, false, 3f, true);
					}
				}
			}
		}

		// Token: 0x06009DC4 RID: 40388 RVA: 0x0019C710 File Offset: 0x0019A910
		public static void TryReqLeftTime()
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XTransformDocument specificDocument = XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID);
				specificDocument.ReqLeftTime();
			}
		}

		// Token: 0x06009DC5 RID: 40389 RVA: 0x0019C744 File Offset: 0x0019A944
		private void _Recycle()
		{
			for (int i = 0; i < this.m_ItemList.Count; i++)
			{
				this.m_ItemList[i].Recycle();
			}
			this.m_ItemList.Clear();
		}

		// Token: 0x06009DC6 RID: 40390 RVA: 0x0019C78C File Offset: 0x0019A98C
		private int _ShowItemListByType(uint type)
		{
			HashSet<int> hashSet = HashPool<int>.Get();
			for (int i = 0; i < XTransformDocument.m_ItemTransformTable.Table.Length; i++)
			{
				ItemTransform.RowData rowData = XTransformDocument.m_ItemTransformTable.Table[i];
				bool flag = rowData.type == type;
				if (flag)
				{
					hashSet.Add((int)rowData.itemid);
				}
			}
			this._Recycle();
			bool flag2 = hashSet.Count > 0;
			if (flag2)
			{
				Dictionary<int, XNormalItem> dictionary = DictionaryPool<int, XNormalItem>.Get();
				XBag itemBag = XSingleton<XGame>.singleton.Doc.XBagDoc.ItemBag;
				for (int j = 0; j < itemBag.Count; j++)
				{
					XItem xitem = itemBag[j];
					bool flag3 = !hashSet.Contains(xitem.itemID);
					if (!flag3)
					{
						XNormalItem data;
						bool flag4 = !dictionary.TryGetValue(xitem.itemID, out data);
						if (flag4)
						{
							data = XDataPool<XNormalItem>.GetData();
							dictionary.Add(xitem.itemID, data);
							data.itemID = xitem.itemID;
							data.itemConf = xitem.itemConf;
							this.m_ItemList.Add(data);
						}
						data.itemCount += xitem.itemCount;
					}
				}
				DictionaryPool<int, XNormalItem>.Release(dictionary);
			}
			HashPool<int>.Release(hashSet);
			return this.m_ItemList.Count;
		}

		// Token: 0x06009DC7 RID: 40391 RVA: 0x0019C8F8 File Offset: 0x0019AAF8
		private bool _OnItemClicked(IXUIButton btn)
		{
			int num = (int)btn.ID;
			bool flag = num < 0 || num >= this.m_ItemList.Count;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this._ReqTranformOther(this.m_TempRoleID, this.m_ItemList[num].itemID);
				result = true;
			}
			return result;
		}

		// Token: 0x06009DC8 RID: 40392 RVA: 0x0019C954 File Offset: 0x0019AB54
		public void ReqLeftTime()
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 2;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

		// Token: 0x06009DC9 RID: 40393 RVA: 0x0019C984 File Offset: 0x0019AB84
		public void ReqSwitch()
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

		// Token: 0x06009DCA RID: 40394 RVA: 0x0019C9B4 File Offset: 0x0019ABB4
		public void TryTransformOther(string name, ulong roleID)
		{
			this.m_TempRoleID = roleID;
			int num = this._ShowItemListByType(this.m_ItemType);
			int num2 = num;
			if (num2 != 0)
			{
				if (num2 != 1)
				{
					DlgBase<ItemUseListDlg, ItemUseListDlgBehaviour>.singleton.Set(new ButtonClickEventHandler(this._OnItemClicked), this.m_ItemList);
				}
				else
				{
					this.m_TempItemID = this.m_ItemList[0].itemID;
					for (int i = 0; i < XTransformDocument.m_ItemTransformTable.Table.Length; i++)
					{
						ItemTransform.RowData rowData = XTransformDocument.m_ItemTransformTable.Table[i];
						bool flag = rowData.itemid == (uint)this.m_TempItemID;
						if (flag)
						{
							XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("TRANSFORM_CONFIRM", new object[]
							{
								name,
								(this.m_ItemList[0].itemConf != null) ? XSingleton<UiUtility>.singleton.ChooseProfString(this.m_ItemList[0].itemConf.ItemName, 0U) : string.Empty,
								rowData.time
							}), XStringDefineProxy.GetString(XStringDefine.COMMON_OK), XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL), new ButtonClickEventHandler(this._OnTransformConfirmClicked));
							break;
						}
					}
				}
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TRANS_ITEMNOTENOUGH, "fece00");
			}
		}

		// Token: 0x06009DCB RID: 40395 RVA: 0x0019CB04 File Offset: 0x0019AD04
		private bool _OnTransformConfirmClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._ReqTranformOther(this.m_TempRoleID, this.m_TempItemID);
			return true;
		}

		// Token: 0x06009DCC RID: 40396 RVA: 0x0019CB38 File Offset: 0x0019AD38
		private void _ReqTranformOther(ulong roleID, int itemid)
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 1;
			rpcC2G_TransformOp.oArg.roleid = roleID.ToString();
			rpcC2G_TransformOp.oArg.itemid = (uint)itemid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

		// Token: 0x06009DCD RID: 40397 RVA: 0x0019CB88 File Offset: 0x0019AD88
		public void OnGetTransformOp(TransformOpArg oArg, TransformOpRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				int op = oArg.op;
				if (op == 2)
				{
					bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
					if (flag2)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetTransformLeftTime(oRes.timeleft);
					}
				}
			}
		}

		// Token: 0x040037AA RID: 14250
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTransformDocument");

		// Token: 0x040037AB RID: 14251
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040037AC RID: 14252
		private static ItemTransform m_ItemTransformTable = new ItemTransform();

		// Token: 0x040037AD RID: 14253
		private List<XItem> m_ItemList = new List<XItem>();

		// Token: 0x040037AE RID: 14254
		private uint m_ItemType = 1U;

		// Token: 0x040037AF RID: 14255
		private ulong m_TempRoleID;

		// Token: 0x040037B0 RID: 14256
		private int m_TempItemID;
	}
}
