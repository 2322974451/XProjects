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

	internal class XTransformDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XTransformDocument.uuID;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XTransformDocument.AsyncLoader.AddTask("Table/ItemTransform", XTransformDocument.m_ItemTransformTable, false);
			XTransformDocument.AsyncLoader.Execute(null);
		}

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

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

		public static void TryReqLeftTime()
		{
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				XTransformDocument specificDocument = XDocuments.GetSpecificDocument<XTransformDocument>(XTransformDocument.uuID);
				specificDocument.ReqLeftTime();
			}
		}

		private void _Recycle()
		{
			for (int i = 0; i < this.m_ItemList.Count; i++)
			{
				this.m_ItemList[i].Recycle();
			}
			this.m_ItemList.Clear();
		}

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

		public void ReqLeftTime()
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 2;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

		public void ReqSwitch()
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 0;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

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

		private bool _OnTransformConfirmClicked(IXUIButton btn)
		{
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			this._ReqTranformOther(this.m_TempRoleID, this.m_TempItemID);
			return true;
		}

		private void _ReqTranformOther(ulong roleID, int itemid)
		{
			RpcC2G_TransformOp rpcC2G_TransformOp = new RpcC2G_TransformOp();
			rpcC2G_TransformOp.oArg.op = 1;
			rpcC2G_TransformOp.oArg.roleid = roleID.ToString();
			rpcC2G_TransformOp.oArg.itemid = (uint)itemid;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_TransformOp);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XTransformDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ItemTransform m_ItemTransformTable = new ItemTransform();

		private List<XItem> m_ItemList = new List<XItem>();

		private uint m_ItemType = 1U;

		private ulong m_TempRoleID;

		private int m_TempItemID;
	}
}
