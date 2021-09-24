using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEmblemItem : XAttrItem
	{

		public override void Init()
		{
			base.Init();
			this.smeltingInfo.Init();
			this.emblemInfo.Init();
		}

		public override void Recycle()
		{
			base.Recycle();
			XDataPool<XEmblemItem>.Recycle(this);
		}

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

		public override bool Treasure
		{
			get
			{
				return this.smeltingInfo.Attrs.Count > 2 || this.emblemInfo.thirdslot > 0U;
			}
		}

		public override bool bHasPPT
		{
			get
			{
				return true;
			}
		}

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

		public XEmblemInfo emblemInfo = default(XEmblemInfo);

		public XSmeltingInfo smeltingInfo = default(XSmeltingInfo);
	}
}
