using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactSuit
	{

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

		public bool WillChangeEquipedCount(int newItemID, int oldItemID)
		{
			bool flag = this.Artifacts.Contains((uint)newItemID);
			bool flag2 = this.Artifacts.Contains((uint)oldItemID);
			return flag ^ flag2;
		}

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

		public bool IsEffectJustActivated(int equipCount)
		{
			return this.activeCount.Contains(equipCount);
		}

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

		private HashSet<uint> m_artifacts = null;

		public uint Id = 0U;

		public uint Level = 0U;

		public uint SuitId = 0U;

		public uint ElementType = 0U;

		public byte SuitQuality = 0;

		public bool IsCreateShow = false;

		public uint MaxSuitEffectCount = 0U;

		public string Name = string.Empty;

		public SeqListRef<uint>[] effects = new SeqListRef<uint>[XBagDocument.ArtifactMax + 3];

		public HashSet<int> activeCount = new HashSet<int>();

		private int m_effectsNum = -1;
	}
}
