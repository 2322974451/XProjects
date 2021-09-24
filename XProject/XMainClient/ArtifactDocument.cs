using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactDocument.uuID;
			}
		}

		public static ArtifactDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactDocument.uuID) as ArtifactDocument;
			}
		}

		public static ArtifactSuitMgr SuitMgr
		{
			get
			{
				return ArtifactDocument.m_suitMgr;
			}
		}

		public static List<uint> SuitLevelList
		{
			get
			{
				return ArtifactDocument.m_suitLevelList;
			}
		}

		public static ArtifactListTable ArtifactTab
		{
			get
			{
				return ArtifactDocument.m_artifactTab;
			}
		}

		public static EffectDesTable EffectDesTab
		{
			get
			{
				return ArtifactDocument.m_effectDesTab;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactDocument.AsyncLoader.AddTask("Table/ArtifactList", ArtifactDocument.m_artifactTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/ArtifactSuit", ArtifactDocument.m_artifactSuitTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/EffectTable", ArtifactDocument.m_effectTab, false);
			ArtifactDocument.AsyncLoader.AddTask("Table/EffectDesTable", ArtifactDocument.m_effectDesTab, false);
			ArtifactDocument.AsyncLoader.Execute(callback);
		}

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

		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

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

		public static ArtifactListTable.RowData GetArtifactListRowData(uint artifactId)
		{
			return ArtifactDocument.m_artifactTab.GetByArtifactID(artifactId);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static ArtifactListTable m_artifactTab = new ArtifactListTable();

		private static ArtifactSuitTable m_artifactSuitTab = new ArtifactSuitTable();

		private static EffectTable m_effectTab = new EffectTable();

		private static EffectDesTable m_effectDesTab = new EffectDesTable();

		private static ArtifactSuitMgr m_suitMgr = null;

		private static List<uint> m_suitLevelList = new List<uint>();
	}
}
