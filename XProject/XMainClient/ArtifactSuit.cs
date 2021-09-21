using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008CB RID: 2251
	internal class ArtifactSuit
	{
		// Token: 0x17002A96 RID: 10902
		// (get) Token: 0x06008824 RID: 34852 RVA: 0x00119070 File Offset: 0x00117270
		public HashSet<uint> Artifacts
		{
			get
			{
				bool flag = this.m_artifacts == null;
				if (flag)
				{
					bool flag2 = ArtifactDocument.ArtifactTab != null;
					if (flag2)
					{
						this.m_artifacts = new HashSet<uint>();
						this.GetSuitArtifacts(ref this.m_artifacts);
					}
				}
				return this.m_artifacts;
			}
		}

		// Token: 0x06008825 RID: 34853 RVA: 0x001190C0 File Offset: 0x001172C0
		private void GetSuitArtifacts(ref HashSet<uint> sets)
		{
			sets.Clear();
			for (int i = 0; i < ArtifactDocument.ArtifactTab.Table.Length; i++)
			{
				ArtifactListTable.RowData rowData = ArtifactDocument.ArtifactTab.Table[i];
				bool flag = rowData == null;
				if (!flag)
				{
					bool flag2 = rowData.ArtifactSuit == this.Id;
					if (flag2)
					{
						sets.Add(rowData.ArtifactID);
					}
				}
			}
		}

		// Token: 0x06008826 RID: 34854 RVA: 0x00119130 File Offset: 0x00117330
		public int GetEquipedSuitCount(XBodyBag artifactsOnBody)
		{
			int num = 0;
			bool flag = artifactsOnBody.Length != XBagDocument.ArtifactMax;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				for (int i = 0; i < XBagDocument.ArtifactMax; i++)
				{
					XItem xitem = artifactsOnBody[i];
					bool flag2 = xitem != null && this.Artifacts != null && this.Artifacts.Contains((uint)xitem.itemID);
					if (flag2)
					{
						num++;
					}
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06008827 RID: 34855 RVA: 0x001191AC File Offset: 0x001173AC
		public List<int> GetArtifactSuitPos(XBodyBag artifactsOnBody)
		{
			bool flag = artifactsOnBody.Length != XBagDocument.ArtifactMax;
			List<int> result;
			if (flag)
			{
				result = null;
			}
			else
			{
				List<int> list = new List<int>();
				for (int i = 0; i < XBagDocument.ArtifactMax; i++)
				{
					XItem xitem = artifactsOnBody[i];
					bool flag2 = xitem != null && this.Artifacts != null && this.Artifacts.Contains((uint)xitem.itemID);
					if (flag2)
					{
						list.Add(i);
					}
				}
				result = list;
			}
			return result;
		}

		// Token: 0x06008828 RID: 34856 RVA: 0x00119230 File Offset: 0x00117430
		public bool WillChangeEquipedCount(int newItemID, int oldItemID)
		{
			bool flag = this.Artifacts.Contains((uint)newItemID);
			bool flag2 = this.Artifacts.Contains((uint)oldItemID);
			return flag ^ flag2;
		}

		// Token: 0x06008829 RID: 34857 RVA: 0x00119260 File Offset: 0x00117460
		public bool WillChangeEquipedCount(int itemid, XBodyBag equipsOnBody)
		{
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData((uint)itemid);
			bool flag = artifactListRowData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				XItem xitem = equipsOnBody[(int)artifactListRowData.ArtifactPos];
				bool flag2 = xitem == null;
				result = (flag2 || this.WillChangeEquipedCount(itemid, xitem.itemID));
			}
			return result;
		}

		// Token: 0x0600882A RID: 34858 RVA: 0x001192B0 File Offset: 0x001174B0
		public bool IsEffectJustActivated(int equipCount)
		{
			return this.activeCount.Contains(equipCount);
		}

		// Token: 0x17002A97 RID: 10903
		// (get) Token: 0x0600882B RID: 34859 RVA: 0x001192D0 File Offset: 0x001174D0
		public int EffectsNum
		{
			get
			{
				bool flag = this.m_effectsNum == -1;
				if (flag)
				{
					this.m_effectsNum = 0;
					for (int i = 0; i < this.effects.Length; i++)
					{
						bool flag2 = this.effects[i].count > 0;
						if (flag2)
						{
							this.m_effectsNum++;
						}
					}
				}
				return this.m_effectsNum;
			}
		}

		// Token: 0x04002AF3 RID: 10995
		private HashSet<uint> m_artifacts = null;

		// Token: 0x04002AF4 RID: 10996
		public uint Id = 0U;

		// Token: 0x04002AF5 RID: 10997
		public uint Level = 0U;

		// Token: 0x04002AF6 RID: 10998
		public uint SuitId = 0U;

		// Token: 0x04002AF7 RID: 10999
		public uint ElementType = 0U;

		// Token: 0x04002AF8 RID: 11000
		public byte SuitQuality = 0;

		// Token: 0x04002AF9 RID: 11001
		public bool IsCreateShow = false;

		// Token: 0x04002AFA RID: 11002
		public uint MaxSuitEffectCount = 0U;

		// Token: 0x04002AFB RID: 11003
		public string Name = string.Empty;

		// Token: 0x04002AFC RID: 11004
		public SeqListRef<uint>[] effects = new SeqListRef<uint>[XBagDocument.ArtifactMax + 3];

		// Token: 0x04002AFD RID: 11005
		public HashSet<int> activeCount = new HashSet<int>();

		// Token: 0x04002AFE RID: 11006
		private int m_effectsNum = -1;
	}
}
