using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CombineMeshTask
	{

		public CombineMeshTask(MountLoadCallback mountLoadFinish)
		{
			this.mpb = new MaterialPropertyBlock();
			this.m_PartLoaded = new PartLoadCallback(this.PartLoadFinish);
			for (EPartType epartType = EPartType.ECombinePartStart; epartType < EPartType.ECombinePartEnd; epartType++)
			{
				this.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType)] = new PartLoadTask(epartType, this.m_PartLoaded);
			}
			for (EPartType epartType2 = EPartType.ECombinePartEnd; epartType2 < EPartType.EWeaponEnd; epartType2++)
			{
				this.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType2)] = new WeaponLoadTask(epartType2, mountLoadFinish);
			}
			for (EPartType epartType3 = EPartType.EWeaponEnd; epartType3 < EPartType.EMountEnd; epartType3++)
			{
				this.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType3)] = new MountLoadTask(epartType3, mountLoadFinish);
			}
			for (EPartType epartType4 = EPartType.EMountEnd; epartType4 < EPartType.ENum; epartType4++)
			{
				this.parts[XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType4)] = new DecalLoadTask(epartType4, this.m_PartLoaded, this.parts[0] as PartLoadTask);
			}
			bool flag = CombineMeshTask.m_FinalLoadStatus == 0;
			if (flag)
			{
				for (EPartType epartType5 = EPartType.ECombinePartStart; epartType5 < EPartType.ECombinePartEnd; epartType5++)
				{
					CombineMeshTask.m_FinalLoadStatus |= 1 << XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType5);
				}
				for (EPartType epartType6 = EPartType.EMountEnd; epartType6 < EPartType.ENum; epartType6++)
				{
					CombineMeshTask.m_FinalLoadStatus |= 1 << XFastEnumIntEqualityComparer<EPartType>.ToInt(epartType6);
				}
			}
		}

		public void Reset(XEntity e)
		{
			for (int i = 0; i < this.parts.Length; i++)
			{
				EquipLoadTask equipLoadTask = this.parts[i];
				equipLoadTask.Reset(e);
			}
			this.combineStatus = ECombineStatus.ENotCombine;
			this.isOnepart = false;
			this.m_LoadStatus = 0;
			this.m_PartLoaded = null;
			this.needCombine = false;
			this.noCombine = false;
			this.roleType = 0;
			bool flag = this.skin != null;
			if (flag)
			{
				bool flag2 = this.skin.sharedMaterial != null;
				if (flag2)
				{
					XEquipDocument.ReturnMaterial(this.skin.sharedMaterial);
					this.skin.sharedMaterial = null;
				}
				this.skin.enabled = false;
				this.skin = null;
			}
			bool flag3 = this.mpb != null;
			if (flag3)
			{
				this.mpb.Clear();
			}
		}

		public void BeginCombine()
		{
			this.m_LoadStatus = 0;
			this.needCombine = false;
			this.combineStatus = ECombineStatus.ENotCombine;
			bool flag = this.skin != null;
			if (flag)
			{
				this.skin.enabled = false;
			}
		}

		public bool EndCombine()
		{
			this.combineStatus = ECombineStatus.ECombineing;
			return CombineMeshTask.m_FinalLoadStatus == this.m_LoadStatus;
		}

		public void AddLoadPart(EPartType part)
		{
			int num = 1 << XFastEnumIntEqualityComparer<EPartType>.ToInt(part);
			this.m_LoadStatus |= num;
		}

		public void PartLoadFinish(EquipLoadTask part, bool combinePart)
		{
			this.needCombine = (this.needCombine || combinePart);
			this.AddLoadPart(part.part);
		}

		public bool Process()
		{
			bool result;
			switch (this.combineStatus)
			{
			case ECombineStatus.ENotCombine:
			case ECombineStatus.ECombined:
				result = false;
				break;
			case ECombineStatus.ECombineing:
				result = (CombineMeshTask.m_FinalLoadStatus == this.m_LoadStatus);
				break;
			default:
				result = false;
				break;
			}
			return result;
		}

		public static int ConvertPart(FashionPosition fp)
		{
			int result;
			switch (fp)
			{
			case FashionPosition.FASHION_START:
				result = 7;
				break;
			case FashionPosition.FashionUpperBody:
				result = 2;
				break;
			case FashionPosition.FashionLowerBody:
				result = 3;
				break;
			case FashionPosition.FashionGloves:
				result = 4;
				break;
			case FashionPosition.FashionBoots:
				result = 5;
				break;
			case FashionPosition.FashionMainWeapon:
				result = 8;
				break;
			case FashionPosition.FashionSecondaryWeapon:
				result = 6;
				break;
			case FashionPosition.FashionWings:
				result = 9;
				break;
			case FashionPosition.FashionTail:
				result = 10;
				break;
			case FashionPosition.FashionDecal:
				result = 12;
				break;
			case FashionPosition.FASHION_END:
				result = 0;
				break;
			case FashionPosition.Hair:
				result = 1;
				break;
			default:
				result = -1;
				break;
			}
			return result;
		}

		public EquipLoadTask[] parts = new EquipLoadTask[XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ENum)];

		public ECombineStatus combineStatus = ECombineStatus.ENotCombine;

		private static int m_FinalLoadStatus = 0;

		private int m_LoadStatus = 0;

		private PartLoadCallback m_PartLoaded = null;

		public bool needCombine = false;

		public int roleType;

		public SkinnedMeshRenderer skin = null;

		public bool noCombine = false;

		public MaterialPropertyBlock mpb = null;

		public bool isOnepart = false;

		public static ECombineMatType s_CombineMatType = ECombineMatType.ECombined;
	}
}
