using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DEC RID: 3564
	internal class XEmblemItem : XAttrItem
	{
		// Token: 0x0600C102 RID: 49410 RVA: 0x0028E182 File Offset: 0x0028C382
		public override void Init()
		{
			base.Init();
			this.smeltingInfo.Init();
			this.emblemInfo.Init();
		}

		// Token: 0x0600C103 RID: 49411 RVA: 0x0028E1A4 File Offset: 0x0028C3A4
		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XEmblemItem>.Recycle(this);
		}

		// Token: 0x170033E7 RID: 13287
		// (get) Token: 0x0600C104 RID: 49412 RVA: 0x0028E1B8 File Offset: 0x0028C3B8
		public bool bIsSkillEmblem
		{
			get
			{
				EmblemBasic.RowData emblemConf = XBagDocument.GetEmblemConf(this.itemID);
				bool flag = emblemConf == null;
				bool result;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("EmblemBasic not find this itemid = {0}", this.itemID), null, null, null, null, null);
					result = false;
				}
				else
				{
					result = (emblemConf.EmblemType > 1000);
				}
				return result;
			}
		}

		// Token: 0x170033E8 RID: 13288
		// (get) Token: 0x0600C105 RID: 49413 RVA: 0x0028E218 File Offset: 0x0028C418
		public override bool Treasure
		{
			get
			{
				return this.smeltingInfo.Attrs.Count > 2 || this.emblemInfo.thirdslot > 0U;
			}
		}

		// Token: 0x170033E9 RID: 13289
		// (get) Token: 0x0600C106 RID: 49414 RVA: 0x0028E250 File Offset: 0x0028C450
		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C107 RID: 49415 RVA: 0x0028E264 File Offset: 0x0028C464
		public override string ToPPTString(XAttributes attributes = null)
		{
			string result = string.Empty;
			bool bIsSkillEmblem = this.bIsSkillEmblem;
			if (bIsSkillEmblem)
			{
				SkillEmblem.RowData emblemSkillConf = XEmblemDocument.GetEmblemSkillConf((uint)this.itemID);
				bool flag = emblemSkillConf == null;
				if (flag)
				{
					result = "SKILL EMBLEM.";
				}
				else
				{
					result = emblemSkillConf.SkillPPT.ToString();
				}
			}
			else
			{
				bool flag2 = this.emblemInfo.thirdslot == 1U || this.emblemInfo.thirdslot == 10U;
				if (flag2)
				{
					int num;
					int endIndex;
					XEquipCreateDocument.GetEmblemAttrDataByID((uint)this.itemID, out num, out endIndex);
					bool flag3 = num >= 0;
					if (flag3)
					{
						bool flag4 = this.emblemInfo.thirdslot == 1U;
						uint num2;
						uint num3;
						if (flag4)
						{
							uint ppt = this.GetPPT(attributes);
							XEquipCreateDocument.GetRandomPPT(num, endIndex, out num2, out num3);
							num2 += ppt;
							num3 += ppt;
						}
						else
						{
							XEquipCreateDocument.GetPPT(num, endIndex, true, true, out num2, out num3);
						}
						result = string.Format("{0} - {1}", num2, num3);
					}
				}
				else
				{
					result = this.GetPPT(attributes).ToString();
				}
			}
			return result;
		}

		// Token: 0x04005126 RID: 20774
		public XEmblemInfo emblemInfo = default(XEmblemInfo);

		// Token: 0x04005127 RID: 20775
		public XSmeltingInfo smeltingInfo = default(XSmeltingInfo);
	}
}
