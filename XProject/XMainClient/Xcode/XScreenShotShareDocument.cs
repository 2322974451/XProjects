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

	internal class XScreenShotShareDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XScreenShotShareDocument.uuID;
			}
		}

		public static CommentType ShareIndex { get; set; }

		public XScreenShotShareDocument()
		{
			for (int i = 0; i < XScreenShotShareDocument._EffectCfgReader.Table.Length; i++)
			{
				bool flag = !this.EffectAllListId.Contains(XScreenShotShareDocument._EffectCfgReader.Table[i].EffectID);
				if (flag)
				{
					this.EffectAllListId.Add(XScreenShotShareDocument._EffectCfgReader.Table[i].EffectID);
				}
			}
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/PhotographEffect", XScreenShotShareDocument._EffectCfgReader, false);
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/ShareTable", XScreenShotShareDocument._ShareTable, false);
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/ShareBgTexture", XScreenShotShareDocument._shareBgTextureTable, false);
			XScreenShotShareDocument.AsyncLoader.Execute(callback);
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public void OnGetPhotoGraphEffect(PhotographEffect res)
		{
			this.EffectListId.Clear();
			for (int i = 0; i < res.photograph_effect.Count; i++)
			{
				this.EffectListId.Add(res.photograph_effect[i]);
			}
			this.CharmVal = res.charm;
			bool flag = this.ScreenShotView != null && this.ScreenShotView.IsVisible();
			if (flag)
			{
				this.ScreenShotView.OnRefreshEffects();
			}
		}

		public List<PhotographEffectCfg.RowData> GetRowDataById(uint effectid)
		{
			this.EffectCfgList.Clear();
			for (int i = 0; i < XScreenShotShareDocument._EffectCfgReader.Table.Length; i++)
			{
				bool flag = XScreenShotShareDocument._EffectCfgReader.Table[i].EffectID == effectid;
				if (flag)
				{
					this.EffectCfgList.Add(XScreenShotShareDocument._EffectCfgReader.Table[i]);
				}
			}
			return this.EffectCfgList;
		}

		public XTuple<string, string> GetShareBgTexturePath()
		{
			for (int i = 0; i < XScreenShotShareDocument._shareBgTextureTable.Table.Length; i++)
			{
				ShareBgTexture.RowData rowData = XScreenShotShareDocument._shareBgTextureTable.Table[i];
				bool flag = rowData != null && rowData.ShareBgType == (int)this.CurShareBgType;
				if (flag)
				{
					uint num = (this.CurShareBgType == ShareBgType.DungeonType) ? XSingleton<XScene>.singleton.SceneID : this.SpriteID;
					int num2 = -1;
					uint[] subBgIDList = rowData.SubBgIDList;
					int j = 0;
					int num3 = subBgIDList.Length;
					while (j < num3)
					{
						bool flag2 = subBgIDList[j] == num;
						if (flag2)
						{
							num2 = j;
							break;
						}
						j++;
					}
					string t = "";
					bool flag3 = num2 >= 0 && num2 < rowData.TexturePathList.Length;
					string t2;
					if (flag3)
					{
						t2 = rowData.TexturePathList[num2];
						bool flag4 = this.CurShareBgType == ShareBgType.DungeonType;
						if (flag4)
						{
							bool flag5 = num2 < rowData.Text.Length;
							if (flag5)
							{
								t = rowData.Text[num2];
							}
							else
							{
								bool flag6 = rowData.Text.Length != 0;
								if (flag6)
								{
									t = rowData.Text[0];
								}
							}
						}
					}
					else
					{
						t2 = rowData.TexturePathList[0];
						bool flag7 = rowData.Text.Length != 0;
						if (flag7)
						{
							t = rowData.Text[0];
						}
					}
					return new XTuple<string, string>(t2, t);
				}
			}
			return new XTuple<string, string>("", "");
		}

		public static ShareTable.RowData GetShareInfoById(int index)
		{
			for (int i = 0; i < XScreenShotShareDocument._ShareTable.Table.Length; i++)
			{
				bool flag = XScreenShotShareDocument._ShareTable.Table[i].Condition == index;
				if (flag)
				{
					return XScreenShotShareDocument._ShareTable.Table[i];
				}
			}
			return null;
		}

		public static void DoShowShare()
		{
			XScreenShotShareDocument._choice_index = XFastEnumIntEqualityComparer<CommentType>.ToInt(XScreenShotShareDocument.ShareIndex);
			ShareTable.RowData shareInfoById = XScreenShotShareDocument.GetShareInfoById(XScreenShotShareDocument._choice_index);
			bool flag = shareInfoById != null;
			if (flag)
			{
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(shareInfoById.Desc, XStringDefineProxy.GetString("COMMON_DESE"), XStringDefineProxy.GetString("COMMON_DIDIAO"));
				DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(XScreenShotShareDocument.OnShareInfo), null);
			}
		}

		private static bool OpenAppStorePraise(IXUIButton btn)
		{
			DlgBase<ModalThreeDlg, ModalThreeDlgBehaviour>.singleton.SetVisible(false, true);
			ShareTable.RowData shareInfoById = XScreenShotShareDocument.GetShareInfoById(5);
			bool flag = shareInfoById != null;
			if (flag)
			{
				Application.OpenURL(shareInfoById.Link);
			}
			return true;
		}

		private static bool OnShareInfo(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XScreenShotMgr>.singleton.DoShareWithLink(XScreenShotShareDocument._choice_index, false, ShareTagType.Invite_Tag, null, new object[0]);
			return true;
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XScreenShotShareDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public ScreenShotShareView ScreenShotView;

		private static PhotographEffectCfg _EffectCfgReader = new PhotographEffectCfg();

		private static ShareTable _ShareTable = new ShareTable();

		private static ShareBgTexture _shareBgTextureTable = new ShareBgTexture();

		public List<uint> EffectListId = new List<uint>();

		public List<uint> EffectAllListId = new List<uint>();

		public List<PhotographEffectCfg.RowData> EffectCfgList = new List<PhotographEffectCfg.RowData>();

		public uint CharmVal = 0U;

		public ShareBgType CurShareBgType = ShareBgType.NoneType;

		public uint SpriteID = 0U;

		private static int _choice_index = 0;
	}
}
