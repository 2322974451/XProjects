using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008C3 RID: 2243
	internal class ArtifactDocument : XDocComponent
	{
		// Token: 0x17002A7B RID: 10875
		// (get) Token: 0x060087B3 RID: 34739 RVA: 0x00117404 File Offset: 0x00115604
		public override uint ID
		{
			get
			{
				return ArtifactDocument.uuID;
			}
		}

		// Token: 0x17002A7C RID: 10876
		// (get) Token: 0x060087B4 RID: 34740 RVA: 0x0011741C File Offset: 0x0011561C
		public static ArtifactDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactDocument.uuID) as ArtifactDocument;
			}
		}

		// Token: 0x17002A7D RID: 10877
		// (get) Token: 0x060087B5 RID: 34741 RVA: 0x00117448 File Offset: 0x00115648
		public static ArtifactSuitMgr SuitMgr
		{
			get
			{
				return ArtifactDocument.m_suitMgr;
			}
		}

		// Token: 0x17002A7E RID: 10878
		// (get) Token: 0x060087B6 RID: 34742 RVA: 0x00117460 File Offset: 0x00115660
		public static List<uint> SuitLevelList
		{
			get
			{
				return ArtifactDocument.m_suitLevelList;
			}
		}

		// Token: 0x17002A7F RID: 10879
		// (get) Token: 0x060087B7 RID: 34743 RVA: 0x00117478 File Offset: 0x00115678
		public static ArtifactListTable ArtifactTab
		{
			get
			{
				return ArtifactDocument.m_artifactTab;
			}
		}

		// Token: 0x17002A80 RID: 10880
		// (get) Token: 0x060087B8 RID: 34744 RVA: 0x00117490 File Offset: 0x00115690
		public static EffectDesTable EffectDesTab
		{
			get
			{
				return ArtifactDocument.m_effectDesTab;
			}
		}

		// Token: 0x060087B9 RID: 34745 RVA: 0x001174A8 File Offset: 0x001156A8
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactDocument.AsyncLoader.AddTask("Table/ArtifactList", ArtifactDocument.m_artifactTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/ArtifactSuit", ArtifactDocument.m_artifactSuitTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/EffectTable", ArtifactDocument.m_effectTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/EffectDesTable", ArtifactDocument.m_effectDesTab, false);
			ArtifactDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x060087BA RID: 34746 RVA: 0x0011751C File Offset: 0x0011571C
		public static void OnTableLoaded()
		{
			ArtifactDocument.m_suitMgr = new ArtifactSuitMgr(ArtifactDocument.m_artifactSuitTab.Table);
			ArtifactDocument.m_suitLevelList.Clear();
			for (int i = 0; i < ArtifactDocument.m_artifactSuitTab.Table.Length; i++)
			{
				ArtifactSuitTable.RowData rowData = ArtifactDocument.m_artifactSuitTab.Table[i];
				bool flag = rowData != null && !ArtifactDocument.m_suitLevelList.Contains(rowData.Level);
				if (flag)
				{
					ArtifactDocument.m_suitLevelList.Add(rowData.Level);
				}
			}
			ArtifactDocument.m_artifactSuitTab = null;
			ArtifactDocument.m_suitLevelList.Sort();
			HashSet<ulong> hashSet = HashPool<ulong>.Get();
			for (int j = 0; j < ArtifactDocument.m_effectTab.Table.Length; j++)
			{
				EffectTable.RowData rowData2 = ArtifactDocument.m_effectTab.Table[j];
				bool flag2 = rowData2.BuffID > 0U;
				ulong item;
				if (flag2)
				{
					item = ((ulong)rowData2.EffectID << 32 | (ulong)rowData2.BuffID);
				}
				else
				{
					item = ((ulong)rowData2.EffectID << 32 | (ulong)rowData2.SkillScript);
				}
				bool flag3 = hashSet.Contains(item);
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog2("Duplicated effect id {0} line: {1}", new object[]
					{
						rowData2.EffectID,
						j
					});
				}
				else
				{
					hashSet.Add(item);
				}
			}
			HashPool<ulong>.Release(hashSet);
		}

		// Token: 0x060087BB RID: 34747 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x060087BC RID: 34748 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x060087BD RID: 34749 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x060087BE RID: 34750 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x060087BF RID: 34751 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x060087C0 RID: 34752 RVA: 0x0011768C File Offset: 0x0011588C
		public static string GetArtifactEffectDes(uint effectId, List<string> values)
		{
			bool flag = ArtifactDocument.m_effectTab == null;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				EffectDesTable.RowData byEffectID = ArtifactDocument.m_effectDesTab.GetByEffectID(effectId);
				bool flag2 = byEffectID == null;
				if (flag2)
				{
					result = string.Empty;
				}
				else
				{
					bool flag3 = values.Count > 0;
					string text;
					if (flag3)
					{
						string effectDes = byEffectID.EffectDes;
						object[] args = values.ToArray();
						text = string.Format(effectDes, args);
					}
					else
					{
						text = byEffectID.EffectDes;
					}
					result = text;
				}
			}
			return result;
		}

		// Token: 0x060087C1 RID: 34753 RVA: 0x00117708 File Offset: 0x00115908
		public static ArtifactListTable.RowData GetArtifactListRowData(uint artifactId)
		{
			return ArtifactDocument.m_artifactTab.GetByArtifactID(artifactId);
		}

		// Token: 0x060087C2 RID: 34754 RVA: 0x00117728 File Offset: 0x00115928
		public static ArtifactAttrRange GetArtifactAttrRange(uint artifactId, int slot, uint attrId, uint attrValue)
		{
			ArtifactAttrRange artifactAttrRange = new ArtifactAttrRange();
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData(artifactId);
			bool flag = artifactListRowData == null;
			ArtifactAttrRange result;
			if (flag)
			{
				result = artifactAttrRange;
			}
			else
			{
				SeqListRef<uint> seqListRef = default(SeqListRef<uint>);
				switch (slot)
				{
				case 0:
					seqListRef = artifactListRowData.Attributes1;
					break;
				case 1:
					seqListRef = artifactListRowData.Attributes2;
					break;
				case 2:
					seqListRef = artifactListRowData.Attributes3;
					break;
				}
				for (int i = 0; i < (int)seqListRef.count; i++)
				{
					bool flag2 = seqListRef[i, 0] == 0U;
					if (!flag2)
					{
						bool flag3 = seqListRef[i, 0] == attrId;
						if (flag3)
						{
							bool flag4 = artifactAttrRange.Min == 0U;
							if (flag4)
							{
								artifactAttrRange.Min = seqListRef[i, 1];
							}
							else
							{
								bool flag5 = artifactAttrRange.Min > seqListRef[i, 1];
								if (flag5)
								{
									artifactAttrRange.Min = seqListRef[i, 1];
								}
							}
							bool flag6 = artifactAttrRange.Max == 0U;
							if (flag6)
							{
								artifactAttrRange.Max = seqListRef[i, 2];
							}
							else
							{
								bool flag7 = artifactAttrRange.Max < seqListRef[i, 2];
								if (flag7)
								{
									artifactAttrRange.Max = seqListRef[i, 2];
								}
							}
						}
					}
				}
				result = artifactAttrRange;
			}
			return result;
		}

		// Token: 0x060087C3 RID: 34755 RVA: 0x0011787C File Offset: 0x00115A7C
		public void GetArtifactSkillEffectRowData(uint effectId, List<EffectTable.RowData> outList)
		{
			for (int i = 0; i < ArtifactDocument.m_effectTab.Table.Length; i++)
			{
				bool flag = ArtifactDocument.m_effectTab.Table[i].EffectID == effectId;
				if (flag)
				{
					outList.Add(ArtifactDocument.m_effectTab.Table[i]);
				}
			}
		}

		// Token: 0x060087C4 RID: 34756 RVA: 0x001178D4 File Offset: 0x00115AD4
		public EffectTable.RowData GetArtifactSkillEffect(uint effectID, uint id)
		{
			ulong num = (ulong)effectID << 32 | (ulong)id;
			for (int i = 0; i < ArtifactDocument.m_effectTab.Table.Length; i++)
			{
				EffectTable.RowData rowData = ArtifactDocument.m_effectTab.Table[i];
				bool flag = rowData.BuffID > 0U;
				ulong num2;
				if (flag)
				{
					num2 = ((ulong)rowData.EffectID << 32 | (ulong)rowData.BuffID);
				}
				else
				{
					num2 = ((ulong)rowData.EffectID << 32 | (ulong)rowData.SkillScript);
				}
				bool flag2 = num2 == num;
				if (flag2)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x060087C5 RID: 34757 RVA: 0x0011796C File Offset: 0x00115B6C
		public static uint GetArtifactMinPPt(uint artifactId, XAttributes attributes)
		{
			uint num = 0U;
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData(artifactId);
			bool flag = artifactListRowData == null;
			uint result;
			if (flag)
			{
				result = num;
			}
			else
			{
				bool flag2 = artifactListRowData.Attributes1.Count > 0;
				if (flag2)
				{
					double num2 = double.MaxValue;
					for (int i = 0; i < artifactListRowData.Attributes1.Count; i++)
					{
						double ppt = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes1[i, 0], artifactListRowData.Attributes1[i, 1], attributes, -1);
						bool flag3 = ppt < num2;
						if (flag3)
						{
							num2 = ppt;
						}
					}
					num += (uint)num2;
				}
				bool flag4 = artifactListRowData.Attributes2.Count > 0;
				if (flag4)
				{
					double num2 = double.MaxValue;
					for (int j = 0; j < artifactListRowData.Attributes2.Count; j++)
					{
						double ppt2 = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes2[j, 0], artifactListRowData.Attributes2[j, 1], attributes, -1);
						bool flag5 = ppt2 < num2;
						if (flag5)
						{
							num2 = ppt2;
						}
					}
					num += (uint)num2;
				}
				bool flag6 = artifactListRowData.Attributes3.Count > 0;
				if (flag6)
				{
					double num2 = double.MaxValue;
					for (int k = 0; k < artifactListRowData.Attributes3.Count; k++)
					{
						double ppt3 = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes3[k, 0], artifactListRowData.Attributes3[k, 1], attributes, -1);
						bool flag7 = ppt3 < num2;
						if (flag7)
						{
							num2 = ppt3;
						}
					}
					num += (uint)num2;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x060087C6 RID: 34758 RVA: 0x00117B24 File Offset: 0x00115D24
		public static uint GetArtifactMaxPPt(uint artifactId, XAttributes attributes)
		{
			uint num = 0U;
			ArtifactListTable.RowData artifactListRowData = ArtifactDocument.GetArtifactListRowData(artifactId);
			bool flag = artifactListRowData == null;
			uint result;
			if (flag)
			{
				result = num;
			}
			else
			{
				bool flag2 = artifactListRowData.Attributes1.Count > 0;
				if (flag2)
				{
					double num2 = 0.0;
					for (int i = 0; i < artifactListRowData.Attributes1.Count; i++)
					{
						double ppt = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes1[i, 0], artifactListRowData.Attributes1[i, 2], attributes, -1);
						bool flag3 = ppt > num2;
						if (flag3)
						{
							num2 = ppt;
						}
					}
					num += (uint)num2;
				}
				bool flag4 = artifactListRowData.Attributes2.Count > 0;
				if (flag4)
				{
					double num2 = 0.0;
					for (int j = 0; j < artifactListRowData.Attributes2.Count; j++)
					{
						double ppt2 = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes2[j, 0], artifactListRowData.Attributes2[j, 2], attributes, -1);
						bool flag5 = ppt2 > num2;
						if (flag5)
						{
							num2 = ppt2;
						}
					}
					num += (uint)num2;
				}
				bool flag6 = artifactListRowData.Attributes3.Count > 0;
				if (flag6)
				{
					double num2 = 0.0;
					for (int k = 0; k < artifactListRowData.Attributes3.Count; k++)
					{
						double ppt3 = XSingleton<XPowerPointCalculator>.singleton.GetPPT(artifactListRowData.Attributes3[k, 0], artifactListRowData.Attributes3[k, 2], attributes, -1);
						bool flag7 = ppt3 > num2;
						if (flag7)
						{
							num2 = ppt3;
						}
					}
					num += (uint)num2;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x04002ACB RID: 10955
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactDocument");

		// Token: 0x04002ACC RID: 10956
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002ACD RID: 10957
		private static ArtifactListTable m_artifactTab = new ArtifactListTable();

		// Token: 0x04002ACE RID: 10958
		private static ArtifactSuitTable m_artifactSuitTab = new ArtifactSuitTable();

		// Token: 0x04002ACF RID: 10959
		private static EffectTable m_effectTab = new EffectTable();

		// Token: 0x04002AD0 RID: 10960
		private static EffectDesTable m_effectDesTab = new EffectDesTable();

		// Token: 0x04002AD1 RID: 10961
		private static ArtifactSuitMgr m_suitMgr = null;

		// Token: 0x04002AD2 RID: 10962
		private static List<uint> m_suitLevelList = new List<uint>();
	}
}
