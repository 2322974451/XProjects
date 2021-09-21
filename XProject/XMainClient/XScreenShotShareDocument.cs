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
	// Token: 0x0200096C RID: 2412
	internal class XScreenShotShareDocument : XDocComponent
	{
		// Token: 0x17002C61 RID: 11361
		// (get) Token: 0x06009150 RID: 37200 RVA: 0x0014CD68 File Offset: 0x0014AF68
		public override uint ID
		{
			get
			{
				return XScreenShotShareDocument.uuID;
			}
		}

		// Token: 0x17002C62 RID: 11362
		// (get) Token: 0x06009151 RID: 37201 RVA: 0x0014CD7F File Offset: 0x0014AF7F
		// (set) Token: 0x06009152 RID: 37202 RVA: 0x0014CD86 File Offset: 0x0014AF86
		public static CommentType ShareIndex { get; set; }

		// Token: 0x06009153 RID: 37203 RVA: 0x0014CD90 File Offset: 0x0014AF90
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

		// Token: 0x06009154 RID: 37204 RVA: 0x0014CE38 File Offset: 0x0014B038
		public static void Execute(OnLoadedCallback callback = null)
		{
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/PhotographEffect", XScreenShotShareDocument._EffectCfgReader, false);
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/ShareTable", XScreenShotShareDocument._ShareTable, false);
			XScreenShotShareDocument.AsyncLoader.AddTask("Table/ShareBgTexture", XScreenShotShareDocument._shareBgTextureTable, false);
			XScreenShotShareDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009155 RID: 37205 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06009156 RID: 37206 RVA: 0x0014CE94 File Offset: 0x0014B094
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

		// Token: 0x06009157 RID: 37207 RVA: 0x0014CF14 File Offset: 0x0014B114
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

		// Token: 0x06009158 RID: 37208 RVA: 0x0014CF88 File Offset: 0x0014B188
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

		// Token: 0x06009159 RID: 37209 RVA: 0x0014D10C File Offset: 0x0014B30C
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

		// Token: 0x0600915A RID: 37210 RVA: 0x0014D164 File Offset: 0x0014B364
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

		// Token: 0x0600915B RID: 37211 RVA: 0x0014D1F0 File Offset: 0x0014B3F0
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

		// Token: 0x0600915C RID: 37212 RVA: 0x0014D22C File Offset: 0x0014B42C
		private static bool OnShareInfo(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			XSingleton<XScreenShotMgr>.singleton.DoShareWithLink(XScreenShotShareDocument._choice_index, false, ShareTagType.Invite_Tag, null, new object[0]);
			return true;
		}

		// Token: 0x04003042 RID: 12354
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("XScreenShotShareDocument");

		// Token: 0x04003043 RID: 12355
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04003044 RID: 12356
		public ScreenShotShareView ScreenShotView;

		// Token: 0x04003045 RID: 12357
		private static PhotographEffectCfg _EffectCfgReader = new PhotographEffectCfg();

		// Token: 0x04003046 RID: 12358
		private static ShareTable _ShareTable = new ShareTable();

		// Token: 0x04003047 RID: 12359
		private static ShareBgTexture _shareBgTextureTable = new ShareBgTexture();

		// Token: 0x04003048 RID: 12360
		public List<uint> EffectListId = new List<uint>();

		// Token: 0x04003049 RID: 12361
		public List<uint> EffectAllListId = new List<uint>();

		// Token: 0x0400304A RID: 12362
		public List<PhotographEffectCfg.RowData> EffectCfgList = new List<PhotographEffectCfg.RowData>();

		// Token: 0x0400304B RID: 12363
		public uint CharmVal = 0U;

		// Token: 0x0400304C RID: 12364
		public ShareBgType CurShareBgType = ShareBgType.NoneType;

		// Token: 0x0400304D RID: 12365
		public uint SpriteID = 0U;

		// Token: 0x0400304E RID: 12366
		private static int _choice_index = 0;
	}
}
