using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016F7 RID: 5879
	internal class CrossGVGHallHandle : GVGHallBase
	{
		// Token: 0x17003766 RID: 14182
		// (get) Token: 0x0600F287 RID: 62087 RVA: 0x0035CB3C File Offset: 0x0035AD3C
		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGHallFrame";
			}
		}

		// Token: 0x0600F288 RID: 62088 RVA: 0x0035CB54 File Offset: 0x0035AD54
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.SetupRewardList(XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("CrossGVG_Award", XGlobalConfig.ListSeparator));
			this.m_HelpText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CrossGVG_hall_message")));
		}

		// Token: 0x0600F289 RID: 62089 RVA: 0x0035CBB4 File Offset: 0x0035ADB4
		protected override int GetContentSize()
		{
			return this._doc.GVGRanks.Count;
		}

		// Token: 0x0600F28A RID: 62090 RVA: 0x0035CBD8 File Offset: 0x0035ADD8
		protected override void OnItemWrapUpdate(Transform t, int index)
		{
			IXUILabel ixuilabel = t.FindChild("Rank").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol = t.FindChild("GuildName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel2 = t.FindChild("Score").GetComponent("XUILabel") as IXUILabel;
			IXUILabelSymbol ixuilabelSymbol2 = t.Find("ServerName").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
			IXUILabel ixuilabel3 = t.Find("KillNum").GetComponent("XUILabel") as IXUILabel;
			bool flag = index == -1;
			if (flag)
			{
				ixuilabel.SetText(string.Empty);
				ixuilabelSymbol.InputText = XStringDefineProxy.GetString("GUILD_ARENA_UNLAYOUT");
				ixuilabel2.SetText(string.Empty);
				ixuilabel3.SetText(string.Empty);
				ixuilabelSymbol2.InputText = string.Empty;
			}
			else
			{
				XGVGGuildInfo xgvgguildInfo = this._doc.GVGRanks[index];
				ixuilabel.SetText((index + 1).ToString());
				ixuilabelSymbol.InputText = xgvgguildInfo.guildName;
				ixuilabel2.SetText(xgvgguildInfo.score.ToString());
				ixuilabel3.SetText(xgvgguildInfo.killNum.ToString());
				ixuilabelSymbol2.InputText = XStringDefineProxy.GetString("CROSS_GVG_GUILDNAME", new object[]
				{
					xgvgguildInfo.serverID,
					""
				});
				bool flag2 = xgvgguildInfo.uid == this.selfGuildID;
				if (flag2)
				{
					this.selfIndex = index;
				}
			}
		}

		// Token: 0x040067EF RID: 26607
		private XCrossGVGDocument _doc;
	}
}
