using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008BE RID: 2238
	internal class ArtifactAtlasDocument : XDocComponent
	{
		// Token: 0x17002A66 RID: 10854
		// (get) Token: 0x0600873C RID: 34620 RVA: 0x00114A78 File Offset: 0x00112C78
		public override uint ID
		{
			get
			{
				return ArtifactAtlasDocument.uuID;
			}
		}

		// Token: 0x17002A67 RID: 10855
		// (get) Token: 0x0600873D RID: 34621 RVA: 0x00114A90 File Offset: 0x00112C90
		public static ArtifactAtlasDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactAtlasDocument.uuID) as ArtifactAtlasDocument;
			}
		}

		// Token: 0x0600873E RID: 34622 RVA: 0x00114ABB File Offset: 0x00112CBB
		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactAtlasDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x0600873F RID: 34623 RVA: 0x00114ACA File Offset: 0x00112CCA
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
		}

		// Token: 0x06008740 RID: 34624 RVA: 0x00114AD5 File Offset: 0x00112CD5
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
		}

		// Token: 0x06008741 RID: 34625 RVA: 0x00114ADF File Offset: 0x00112CDF
		public override void OnDetachFromHost()
		{
			base.OnDetachFromHost();
		}

		// Token: 0x06008742 RID: 34626 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008743 RID: 34627 RVA: 0x00114AE9 File Offset: 0x00112CE9
		public override void OnEnterSceneFinally()
		{
			base.OnEnterSceneFinally();
		}

		// Token: 0x06008744 RID: 34628 RVA: 0x00114AF4 File Offset: 0x00112CF4
		public List<ArtifactSuitLevel> GetLevelSuitList()
		{
			this.m_levelSuitList.Clear();
			uint defultSuitLevel = this.GetDefultSuitLevel(0U);
			uint showSuitLevel = this.GetShowSuitLevel(0U);
			for (int i = 0; i < ArtifactDocument.SuitMgr.Suits.Count; i++)
			{
				ArtifactSuit artifactSuit = ArtifactDocument.SuitMgr.Suits[i];
				bool flag = artifactSuit == null;
				if (!flag)
				{
					bool flag2 = artifactSuit.Level > showSuitLevel;
					if (!flag2)
					{
						ArtifactSuitLevel artifactSuitLevel = this.IsHad(artifactSuit.Level);
						bool flag3 = artifactSuitLevel == null;
						if (flag3)
						{
							artifactSuitLevel = new ArtifactSuitLevel();
							artifactSuitLevel.SuitLevel = artifactSuit.Level;
							artifactSuitLevel.IsDefultSelect = (artifactSuit.Level == defultSuitLevel);
							artifactSuitLevel.SuitIdList.Add(artifactSuit.SuitId);
							this.m_levelSuitList.Add(artifactSuitLevel);
						}
						else
						{
							artifactSuitLevel.SuitIdList.Add(artifactSuit.SuitId);
						}
					}
				}
			}
			return this.m_levelSuitList;
		}

		// Token: 0x06008745 RID: 34629 RVA: 0x00114BF8 File Offset: 0x00112DF8
		private ArtifactSuitLevel IsHad(uint suitLevel)
		{
			for (int i = 0; i < this.m_levelSuitList.Count; i++)
			{
				bool flag = this.m_levelSuitList[i].SuitLevel == suitLevel;
				if (flag)
				{
					return this.m_levelSuitList[i];
				}
			}
			return null;
		}

		// Token: 0x06008746 RID: 34630 RVA: 0x00114C50 File Offset: 0x00112E50
		private uint GetDefultSuitLevel(uint userLevel = 0U)
		{
			uint result = 1U;
			bool flag = userLevel == 0U;
			if (flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					userLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
			}
			int count = ArtifactDocument.SuitLevelList.Count;
			for (int i = 0; i < count; i++)
			{
				uint num = ArtifactDocument.SuitLevelList[i];
				bool flag3 = num > userLevel;
				if (flag3)
				{
					break;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x06008747 RID: 34631 RVA: 0x00114CD8 File Offset: 0x00112ED8
		private uint GetShowSuitLevel(uint userLevel = 0U)
		{
			uint result = 1U;
			bool flag = userLevel == 0U;
			if (flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null;
				if (flag2)
				{
					userLevel = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
				}
			}
			int count = ArtifactDocument.SuitLevelList.Count;
			bool flag3 = count > 0;
			if (flag3)
			{
				result = ArtifactDocument.SuitLevelList[0];
			}
			for (int i = 0; i < count; i++)
			{
				uint num = ArtifactDocument.SuitLevelList[i];
				bool flag4 = num > userLevel;
				if (flag4)
				{
					break;
				}
				result = num;
			}
			return result;
		}

		// Token: 0x04002AA7 RID: 10919
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactAtlasDocument");

		// Token: 0x04002AA8 RID: 10920
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002AA9 RID: 10921
		private List<ArtifactSuitLevel> m_levelSuitList = new List<ArtifactSuitLevel>();
	}
}
