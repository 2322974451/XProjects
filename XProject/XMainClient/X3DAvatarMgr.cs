using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class X3DAvatarMgr : XSingleton<X3DAvatarMgr>, IX3DAvatarMgr, IXInterface
	{

		public bool Deprecated { get; set; }

		private void SetDummy(X3DAvatarMgr.DummyPool dp, XDummy dummy, int slot)
		{
			bool flag = slot >= 0 && slot < dp.pool.Count;
			if (flag)
			{
				dp.pool[slot] = dummy;
			}
		}

		private XDummy FindDummy(XEntity reference)
		{
			bool flag = this.mainPlayerDummy != null && this.mainPlayerDummy.RefID == reference.ID;
			XDummy result;
			if (flag)
			{
				result = this.mainPlayerDummy;
			}
			else
			{
				result = null;
			}
			return result;
		}

		private void ResetDummy(XDummy dummy, bool destroy)
		{
			bool flag = !dummy.Deprecated;
			if (flag)
			{
				dummy.IsEnableUIRim = false;
				dummy.EngineObject.SetParent(null);
				dummy.EngineObject.Position = XResourceLoaderMgr.Far_Far_Away;
				if (destroy)
				{
					dummy.SetupUIDummy(false);
					XSingleton<XEntityMgr>.singleton.DestroyEntity(dummy);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddWarningLog("dummy already destroyed!", null, null, null, null, null);
			}
		}

		private void EnableDummy(XDummy dummy, bool enable, IUIDummy snapShot)
		{
			bool flag = dummy != null && !dummy.Deprecated;
			if (flag)
			{
				if (enable)
				{
					dummy.IsEnableUIRim = true;
					dummy.SetupRenderQueue(snapShot);
					bool flag2 = snapShot != null;
					if (flag2)
					{
						dummy.ResetAnimation();
						dummy.EngineObject.SetParentTrans(snapShot.transform);
						dummy.EngineObject.SetLocalPRS(Vector3.zero, true, Quaternion.AngleAxis(180f + dummy.DefaultRotation, Vector3.up), true, Vector3.one * dummy.Scale, true);
					}
					bool flag3 = dummy.Equipment != null;
					if (flag3)
					{
						dummy.Equipment.RefreashSprite();
					}
				}
				else
				{
					this.ResetDummy(dummy, false);
					dummy.IsEnableUIRim = false;
				}
			}
		}

		private void CreateMainDummy()
		{
			bool flag = this.mainPlayerDummy == null;
			if (flag)
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				bool flag2 = player == null || player.Deprecated;
				if (!flag2)
				{
					bool flag3 = player.Attributes == null;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("CreateMainDummy  Not Found Attributes!", null, null, null, null, null);
					}
					else
					{
						XOutlookData outlook = player.Attributes.Outlook;
						outlook.uiAvatar = true;
						outlook.isMainDummy = true;
						this.mainPlayerDummy = XSingleton<XEntityMgr>.singleton.CreateDummy(player.PresentID, player.TypeID, outlook, false, false, true);
						this.mainPlayerDummy.RefID = player.ID;
						outlook.isMainDummy = false;
						outlook.uiAvatar = false;
					}
				}
			}
		}

		private bool MakeOutlookData(ulong uid, uint unitType, OutLook outlook, out uint present_id, out uint type_id)
		{
			this.outlookDataCache.uiAvatar = true;
			present_id = 0U;
			type_id = 0U;
			EntityCategory category = XAttributes.GetCategory(uid);
			bool flag = category != EntityCategory.Category_Role && category != EntityCategory.Category_DummyRole;
			if (flag)
			{
				XEntityStatistics.RowData byID = XSingleton<XEntityMgr>.singleton.EntityStatistics.GetByID(unitType);
				bool flag2 = byID == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("fake role monster must have fashion template , data == null , uid = ", uid.ToString(), null, null, null, null);
					return false;
				}
				present_id = byID.PresentID;
				bool flag3 = byID.FashionTemplate > 0;
				if (!flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("fake role monster must have fashion template", null, null, null, null, null);
					return false;
				}
				this.outlookDataCache.SetDefaultFashion(byID.FashionTemplate);
			}
			else
			{
				ProfessionTable.RowData byProfID = XSingleton<XEntityMgr>.singleton.RoleInfo.GetByProfID(unitType % 10U);
				bool flag4 = byProfID == null;
				if (flag4)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("ProfessionTable config not found: unitType = ", unitType.ToString(), null, null, null, null);
					return false;
				}
				present_id = byProfID.PresentID;
				type_id = unitType;
				this.outlookDataCache.SetData(outlook, type_id);
				this.outlookDataCache.SetSpriteData(outlook);
			}
			return true;
		}

		private X3DAvatarMgr.DummyPool GetDummyPool(int index)
		{
			bool flag = index >= 0 && index < this.dummyPool.Count;
			X3DAvatarMgr.DummyPool result;
			if (flag)
			{
				result = this.dummyPool[index];
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Invalid DummyPool Index: ", index.ToString(), null, null, null, null);
				result = null;
			}
			return result;
		}

		public int AllocDummyPool(string user, int maxCount = 1)
		{
			int i = 0;
			int count = this.dummyPool.Count;
			while (i < count)
			{
				X3DAvatarMgr.DummyPool dummyPool = this.dummyPool[i];
				bool flag = dummyPool.user == "";
				if (flag)
				{
					dummyPool.user = user;
					dummyPool.maxCount = maxCount;
					return i;
				}
				i++;
			}
			X3DAvatarMgr.DummyPool dummyPool2 = new X3DAvatarMgr.DummyPool();
			dummyPool2.user = user;
			dummyPool2.maxCount = maxCount;
			this.dummyPool.Add(dummyPool2);
			return this.dummyPool.Count - 1;
		}

		public void ReturnDummyPool(int index)
		{
			bool flag = index >= 0 && index < this.dummyPool.Count;
			if (flag)
			{
				X3DAvatarMgr.DummyPool dummyPool = this.dummyPool[index];
				dummyPool.user = "";
				int i = 0;
				int count = dummyPool.pool.Count;
				while (i < count)
				{
					bool flag2 = dummyPool.pool[i] != null;
					if (flag2)
					{
						this.ResetDummy(dummyPool.pool[i], true);
					}
					i++;
				}
				dummyPool.pool.Clear();
			}
		}

		public XDummy CreateCommonRoleDummy(int dummyPool, UnitAppearance unit, IUIDummy snapShot, XDummy orig)
		{
			bool flag = unit == null || unit.uID == 0UL;
			XDummy result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.CreateCommonRoleDummy(dummyPool, unit.uID, unit.unitType, unit.outlook, snapShot, orig);
			}
			return result;
		}

		public XDummy CreateCommonRoleDummy(int dummyPool, ulong uid, uint unitType, OutLook outlook, IUIDummy snapShot, XDummy orig)
		{
			bool flag = uid == 0UL;
			XDummy result;
			if (flag)
			{
				result = null;
			}
			else
			{
				X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
				bool flag2 = dummyPool2 == null;
				if (flag2)
				{
					result = null;
				}
				else
				{
					int num = -1;
					int i = 0;
					int count = dummyPool2.pool.Count;
					while (i < count)
					{
						XDummy xdummy = dummyPool2.pool[i];
						bool flag3 = xdummy != null && xdummy == orig;
						if (flag3)
						{
							bool flag4 = uid == xdummy.RefID;
							if (flag4)
							{
								this.EnableDummy(orig, true, snapShot);
								this.SetOutlook(xdummy, unitType, outlook);
								return orig;
							}
							num = i;
							this.ResetDummy(orig, true);
							break;
						}
						else
						{
							bool flag5 = xdummy == null && num == -1;
							if (flag5)
							{
								num = i;
							}
							i++;
						}
					}
					bool flag6 = num == -1;
					if (flag6)
					{
						dummyPool2.pool.Add(null);
						num = dummyPool2.pool.Count - 1;
					}
					uint present_id = 0U;
					uint type_id = 0U;
					bool flag7 = this.MakeOutlookData(uid, unitType, outlook, out present_id, out type_id);
					if (flag7)
					{
						this.outlookDataCache.isMainDummy = (XSingleton<XEntityMgr>.singleton.Player != null && XSingleton<XEntityMgr>.singleton.Player.ID == uid);
						XDummy xdummy2 = XSingleton<XEntityMgr>.singleton.CreateDummy(present_id, type_id, this.outlookDataCache, false, false, true);
						this.SetDummy(dummyPool2, xdummy2, num);
						xdummy2.RefID = uid;
						this.outlookDataCache.isMainDummy = false;
						this.EnableDummy(xdummy2, true, snapShot);
						result = xdummy2;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		public void SetOutlook(XDummy dummy, uint unitType, OutLook outlook)
		{
			this.outlookDataCache.uiAvatar = true;
			this.outlookDataCache.SetData(outlook, unitType);
			this.outlookDataCache.SetSpriteData(outlook);
			dummy.SetOutlook(this.outlookDataCache);
		}

		public void SetDummyAnim(int dummyPool, string idStr, string anim)
		{
			X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
			bool flag = dummyPool2 == null;
			if (!flag)
			{
				bool flag2 = !string.IsNullOrEmpty(idStr);
				if (flag2)
				{
					ulong num = 0UL;
					ulong.TryParse(idStr, out num);
					bool flag3 = num != 0UL && num == this.mainPlayerDummy.ID;
					if (flag3)
					{
						this.mainPlayerDummy.SetAnimation(anim);
					}
					int i = 0;
					int count = dummyPool2.pool.Count;
					while (i < count)
					{
						XDummy xdummy = dummyPool2.pool[i];
						bool flag4 = xdummy != null && num == xdummy.ID;
						if (flag4)
						{
							xdummy.SetAnimation(anim);
							break;
						}
						i++;
					}
				}
			}
		}

		public void SetMainDummyAnim(string anim)
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.SetAnimation(anim);
			}
		}

		public string CreateCommonDummy(int dummyPool, uint presentID, IUIDummy snapShot, IXDummy orig, float scale = 1f)
		{
			XDummy xdummy = this.CreateCommonEntityDummy(dummyPool, presentID, snapShot, orig as XDummy, scale);
			return (xdummy == null) ? string.Empty : xdummy.ID.ToString();
		}

		public XDummy CreateCommonEntityDummy(int dummyPool, uint presentID, IUIDummy snapShot, XDummy orig, float scale = 1f)
		{
			X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
			bool flag = dummyPool2 == null;
			XDummy result;
			if (flag)
			{
				result = null;
			}
			else
			{
				int num = -1;
				int i = 0;
				int count = dummyPool2.pool.Count;
				while (i < count)
				{
					XDummy xdummy = dummyPool2.pool[i];
					bool flag2 = xdummy != null && (xdummy == orig || presentID == xdummy.PresentID);
					if (flag2)
					{
						bool flag3 = presentID == xdummy.PresentID;
						if (flag3)
						{
							this.EnableDummy(orig, true, snapShot);
							return orig;
						}
						num = i;
						this.ResetDummy(orig, true);
						break;
					}
					else
					{
						bool flag4 = xdummy == null && num == -1;
						if (flag4)
						{
							num = i;
						}
						i++;
					}
				}
				bool flag5 = num == -1;
				if (flag5)
				{
					dummyPool2.pool.Add(null);
					num = dummyPool2.pool.Count - 1;
				}
				XEntityPresentation.RowData byPresentID = XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(presentID);
				bool flag6 = byPresentID != null;
				if (flag6)
				{
					XDummy xdummy2 = XSingleton<XEntityMgr>.singleton.CreateDummy(presentID, 0U, null, false, false, true);
					xdummy2.SetupUIDummy(true);
					xdummy2.Scale = scale * byPresentID.UIAvatarScale;
					this.SetDummy(dummyPool2, xdummy2, num);
					this.EnableDummy(xdummy2, true, snapShot);
					result = xdummy2;
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		public XDummy FindCreateCommonRoleDummy(int dummyPool, ulong referenceID, uint unitType, OutLook outlook, IUIDummy snapShot, int index)
		{
			X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
			bool flag = dummyPool2 == null;
			XDummy result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = index < 0;
				if (flag2)
				{
					result = null;
				}
				else
				{
					for (int i = dummyPool2.pool.Count - 1; i < index; i++)
					{
						dummyPool2.pool.Add(null);
					}
					int num = -1;
					int j = 0;
					int count = dummyPool2.pool.Count;
					while (j < count)
					{
						XDummy xdummy = dummyPool2.pool[j];
						bool flag3 = xdummy != null && xdummy.RefID == referenceID;
						if (flag3)
						{
							num = j;
							break;
						}
						j++;
					}
					XDummy xdummy2 = null;
					bool flag4 = num >= 0;
					if (flag4)
					{
						xdummy2 = dummyPool2.pool[num];
						bool flag5 = num != index;
						if (flag5)
						{
							dummyPool2.pool[num] = dummyPool2.pool[index];
							dummyPool2.pool[index] = xdummy2;
						}
					}
					else
					{
						uint present_id = 0U;
						uint type_id = 0U;
						bool flag6 = this.MakeOutlookData(referenceID, unitType, outlook, out present_id, out type_id);
						if (flag6)
						{
							xdummy2 = XSingleton<XEntityMgr>.singleton.CreateDummy(present_id, type_id, this.outlookDataCache, false, false, true);
							bool flag7 = dummyPool2.pool[index] != null;
							if (flag7)
							{
								this.ResetDummy(dummyPool2.pool[index], true);
							}
							dummyPool2.pool[index] = xdummy2;
							bool flag8 = referenceID > 0UL;
							if (flag8)
							{
								xdummy2.RefID = referenceID;
							}
						}
					}
					this.EnableDummy(xdummy2, true, snapShot);
					result = xdummy2;
				}
			}
			return result;
		}

		public void DestroyDummy(int dummyPool, string idStr)
		{
			X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
			bool flag = dummyPool2 == null;
			if (!flag)
			{
				bool flag2 = !string.IsNullOrEmpty(idStr);
				if (flag2)
				{
					ulong num = 0UL;
					ulong.TryParse(idStr, out num);
					bool flag3 = num != 0UL && num == this.mainPlayerDummy.ID;
					if (flag3)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Cant destroy Main Dummy, just use EnableMainDummy", null, null, null, null, null);
					}
					else
					{
						int i = 0;
						int count = dummyPool2.pool.Count;
						while (i < count)
						{
							XDummy xdummy = dummyPool2.pool[i];
							bool flag4 = num == xdummy.ID;
							if (flag4)
							{
								this.ResetDummy(xdummy, true);
								dummyPool2.pool[i] = null;
								break;
							}
							i++;
						}
					}
				}
			}
		}

		public void DestroyDummy(int dummyPool, XDummy dummy)
		{
			bool flag = dummy != null;
			if (flag)
			{
				bool flag2 = dummy == this.mainPlayerDummy;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant destroy Main Dummy, just use EnableMainDummy", null, null, null, null, null);
				}
				else
				{
					X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
					bool flag3 = dummyPool2 == null;
					if (!flag3)
					{
						int i = 0;
						int count = dummyPool2.pool.Count;
						while (i < count)
						{
							XDummy xdummy = dummyPool2.pool[i];
							bool flag4 = xdummy == dummy;
							if (flag4)
							{
								this.ResetDummy(dummy, true);
								dummyPool2.pool[i] = null;
								return;
							}
							i++;
						}
						this.ResetDummy(dummy, true);
					}
				}
			}
		}

		public void ClearDummy(int dummyPool)
		{
			X3DAvatarMgr.DummyPool dummyPool2 = this.GetDummyPool(dummyPool);
			bool flag = dummyPool2 == null;
			if (!flag)
			{
				int i = 0;
				int count = dummyPool2.pool.Count;
				while (i < count)
				{
					XDummy xdummy = dummyPool2.pool[i];
					bool flag2 = xdummy != null;
					if (flag2)
					{
						this.ResetDummy(xdummy, true);
						dummyPool2.pool[i] = null;
					}
					i++;
				}
			}
		}

		public void EnableCommonDummy(XDummy origDummy, IUIDummy snapShot, bool enable)
		{
			this.EnableDummy(origDummy, enable, snapShot);
		}

		public void EnableMainDummy(bool enable, IUIDummy snapShot)
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.SetupUIDummy(true);
			}
			if (enable)
			{
				this.CreateMainDummy();
			}
			this.EnableDummy(this.mainPlayerDummy, enable, snapShot);
		}

		public void OnUIUnloadMainDummy(IUIDummy snapShot)
		{
			bool flag = snapShot != null && this.mainPlayerDummy != null && this.mainPlayerDummy.EngineObject != null;
			if (flag)
			{
				this.ResetDummy(this.mainPlayerDummy, false);
			}
		}

		public void SetMainDummy(bool ui)
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.SetupUIDummy(ui);
			}
		}

		public void Clean(bool transfer)
		{
			bool flag = !transfer;
			if (flag)
			{
				bool flag2 = this.mainPlayerDummy != null;
				if (flag2)
				{
					this.ResetDummy(this.mainPlayerDummy, true);
				}
				this.mainPlayerDummy = null;
				int i = 0;
				int count = this.dummyPool.Count;
				while (i < count)
				{
					X3DAvatarMgr.DummyPool dummyPool = this.dummyPool[i];
					int j = 0;
					int count2 = dummyPool.pool.Count;
					while (j < count2)
					{
						bool flag3 = dummyPool.pool[j] != null;
						if (flag3)
						{
							this.ResetDummy(dummyPool.pool[j], true);
						}
						j++;
					}
					dummyPool.pool.Clear();
					dummyPool.user = "";
					i++;
				}
				this.dummyPool.Clear();
			}
		}

		public void RotateMain(float degree)
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.EngineObject.Rotate(Vector3.up, degree);
			}
		}

		public void RotateDummy(XDummy dummy, float degree)
		{
			bool flag = dummy != null;
			if (flag)
			{
				dummy.EngineObject.Rotate(Vector3.up, degree);
			}
		}

		public void OnFashionChanged(XEntity reference)
		{
			XDummy xdummy = this.FindDummy(reference);
			bool flag = xdummy != null && xdummy.Equipment != null;
			if (flag)
			{
				XOutlookData outlook = reference.Attributes.Outlook;
				xdummy.Equipment.EquipFromVisibleList(outlook.OutlookList, outlook.hairColorID, outlook.suitEffectID);
			}
		}

		public void OnEnhanceMasterChanged(XEntity reference)
		{
			XDummy xdummy = this.FindDummy(reference);
			bool flag = xdummy != null && !xdummy.Deprecated;
			if (flag)
			{
				bool flag2 = xdummy == this.mainPlayerDummy;
				if (flag2)
				{
					xdummy.Equipment.SetEnhanceMaster(reference.Attributes.Outlook.enhanceMasterLevel);
					xdummy.Equipment.SetSuitFx(reference.Attributes.Outlook.suitEffectID);
				}
				xdummy.Equipment.RefreshSuitFx();
				xdummy.Equipment.RefreshEquipFx();
				xdummy.Equipment.RefreshSecondWeaponFx();
			}
		}

		public void OnFashionSuitChanged(XEntity reference, FashionSuitTable.RowData suitData)
		{
			XDummy xdummy = this.FindDummy(reference);
			bool flag = xdummy != null;
			if (flag)
			{
				this.outlookDataCache.SetProfType(xdummy.TypeID);
				this.outlookDataCache.SetFashion(XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_ALL_END), 0);
				this.outlookDataCache.SetFashionData(suitData.FashionID, true);
				xdummy.Equipment.EquipFromVisibleList(this.outlookDataCache.OutlookList, this.outlookDataCache.hairColorID, this.outlookDataCache.suitEffectID);
				xdummy.Equipment.AttachSprite(false, 0U);
			}
		}

		public void OnSpriteChanged(XEntity reference, uint presentID)
		{
			XDummy xdummy = this.FindDummy(reference);
			bool flag = xdummy != null;
			if (flag)
			{
				xdummy.Equipment.AttachSprite(presentID > 0U, presentID);
			}
		}

		public void SetMainAnimation(string anim)
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.SetAnimation(anim);
			}
		}

		public float SetMainAnimationGetLength(string anim)
		{
			bool flag = this.mainPlayerDummy != null;
			float result;
			if (flag)
			{
				result = this.mainPlayerDummy.SetAnimationGetLength(anim);
			}
			else
			{
				result = -1f;
			}
			return result;
		}

		public void ResetMainAnimation()
		{
			bool flag = this.mainPlayerDummy != null;
			if (flag)
			{
				this.mainPlayerDummy.ResetAnimation();
			}
		}

		private List<X3DAvatarMgr.DummyPool> dummyPool = new List<X3DAvatarMgr.DummyPool>();

		private XDummy mainPlayerDummy = null;

		private XOutlookData outlookDataCache = new XOutlookData();

		public class DummyPool
		{

			public List<XDummy> pool = new List<XDummy>();

			public string user = "";

			public int maxCount = 1;
		}
	}
}
