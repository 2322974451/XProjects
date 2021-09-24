using System;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class CrossGVGHallHandle : GVGHallBase
	{

		protected override string FileName
		{
			get
			{
				return "Guild/CrossGVG/CrossGVGHallFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCrossGVGDocument>(XCrossGVGDocument.uuID);
			this.SetupRewardList(XSingleton<XGlobalConfig>.singleton.GetAndSeparateValue("CrossGVG_Award", XGlobalConfig.ListSeparator));
			this.m_HelpText.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CrossGVG_hall_message")));
		}

		protected override int GetContentSize()
		{
			return this._doc.GVGRanks.Count;
		}

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

		private XCrossGVGDocument _doc;
	}
}
