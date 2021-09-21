using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FD5 RID: 4053
	internal class CombineMeshTask
	{
		// Token: 0x0600D25F RID: 53855 RVA: 0x00311624 File Offset: 0x0030F824
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

		// Token: 0x0600D260 RID: 53856 RVA: 0x003117D4 File Offset: 0x0030F9D4
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

		// Token: 0x0600D261 RID: 53857 RVA: 0x003118B8 File Offset: 0x0030FAB8
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

		// Token: 0x0600D262 RID: 53858 RVA: 0x003118FC File Offset: 0x0030FAFC
		public bool EndCombine()
		{
			this.combineStatus = ECombineStatus.ECombineing;
			return CombineMeshTask.m_FinalLoadStatus == this.m_LoadStatus;
		}

		// Token: 0x0600D263 RID: 53859 RVA: 0x00311924 File Offset: 0x0030FB24
		public void AddLoadPart(EPartType part)
		{
			int num = 1 << XFastEnumIntEqualityComparer<EPartType>.ToInt(part);
			this.m_LoadStatus |= num;
		}

		// Token: 0x0600D264 RID: 53860 RVA: 0x0031194C File Offset: 0x0030FB4C
		public void PartLoadFinish(EquipLoadTask part, bool combinePart)
		{
			this.needCombine = (this.needCombine || combinePart);
			this.AddLoadPart(part.part);
		}

		// Token: 0x0600D265 RID: 53861 RVA: 0x0031196C File Offset: 0x0030FB6C
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

		// Token: 0x0600D266 RID: 53862 RVA: 0x003119B0 File Offset: 0x0030FBB0
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

		// Token: 0x04005F8B RID: 24459
		public EquipLoadTask[] parts = new EquipLoadTask[XFastEnumIntEqualityComparer<EPartType>.ToInt(EPartType.ENum)];

		// Token: 0x04005F8C RID: 24460
		public ECombineStatus combineStatus = ECombineStatus.ENotCombine;

		// Token: 0x04005F8D RID: 24461
		private static int m_FinalLoadStatus = 0;

		// Token: 0x04005F8E RID: 24462
		private int m_LoadStatus = 0;

		// Token: 0x04005F8F RID: 24463
		private PartLoadCallback m_PartLoaded = null;

		// Token: 0x04005F90 RID: 24464
		public bool needCombine = false;

		// Token: 0x04005F91 RID: 24465
		public int roleType;

		// Token: 0x04005F92 RID: 24466
		public SkinnedMeshRenderer skin = null;

		// Token: 0x04005F93 RID: 24467
		public bool noCombine = false;

		// Token: 0x04005F94 RID: 24468
		public MaterialPropertyBlock mpb = null;

		// Token: 0x04005F95 RID: 24469
		public bool isOnepart = false;

		// Token: 0x04005F96 RID: 24470
		public static ECombineMatType s_CombineMatType = ECombineMatType.ECombined;
	}
}
