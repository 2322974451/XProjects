using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class ArtifactAtlasDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return ArtifactAtlasDocument.uuID;
			}
		}

		public static ArtifactAtlasDocument Doc
		{
			get
			{
				return XSingleton<XGame>.singleton.Doc.GetXComponent(ArtifactAtlasDocument.uuID) as ArtifactAtlasDocument;
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			ArtifactAtlasDocument.AsyncLoader.Execute(callback);
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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("ArtifactAtlasDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private List<ArtifactSuitLevel> m_levelSuitList = new List<ArtifactSuitLevel>();
	}
}
