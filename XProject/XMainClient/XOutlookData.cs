using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B2C RID: 2860
	internal class XOutlookData
	{
		// Token: 0x1700300B RID: 12299
		// (get) Token: 0x0600A77B RID: 42875 RVA: 0x001DA078 File Offset: 0x001D8278
		public FashionPositionInfo[] OutlookList
		{
			get
			{
				return this.outlookList;
			}
		}

		// Token: 0x0600A77C RID: 42876 RVA: 0x001DA090 File Offset: 0x001D8290
		public static void InitSharedFasionList()
		{
			XOutlookData.InitFasionList(ref XOutlookData.sharedFashionList);
		}

		// Token: 0x0600A77D RID: 42877 RVA: 0x001DA0A0 File Offset: 0x001D82A0
		public static void InitFasionList(ref FashionPositionInfo[] fashionList)
		{
			bool flag = fashionList == null;
			if (flag)
			{
				fashionList = new FashionPositionInfo[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_ALL_END)];
			}
			int i = 0;
			int num = fashionList.Length;
			while (i < num)
			{
				FashionPositionInfo fashionPositionInfo;
				fashionPositionInfo.fasionID = 0;
				fashionPositionInfo.itemID = 0;
				fashionPositionInfo.fashionName = "";
				fashionPositionInfo.fashionDir = "";
				fashionPositionInfo.presentID = 0U;
				fashionPositionInfo.replace = false;
				fashionList[i] = fashionPositionInfo;
				i++;
			}
		}

		// Token: 0x0600A77E RID: 42878 RVA: 0x001DA124 File Offset: 0x001D8324
		private void SetPart(ref FashionPositionInfo[] partList, int fashionID)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(fashionID);
			bool flag = fashionConf != null;
			if (flag)
			{
				int equipPos = (int)fashionConf.EquipPos;
				partList[equipPos] = new FashionPositionInfo(fashionID);
			}
		}

		// Token: 0x0600A77F RID: 42879 RVA: 0x001DA158 File Offset: 0x001D8358
		public void SetData(OutLook outlook, uint type = 0U)
		{
			this.SetProfType(type);
			List<uint> fashion = null;
			uint hairID = 0U;
			uint spacial_effect_id = 0U;
			bool flag = outlook != null;
			if (flag)
			{
				bool flag2 = outlook.display_fashion != null;
				if (flag2)
				{
					hairID = outlook.display_fashion.hair_color_id;
					fashion = outlook.display_fashion.display_fashions;
					spacial_effect_id = outlook.display_fashion.special_effects_id;
				}
				bool flag3 = outlook.equips != null;
				if (flag3)
				{
					this.enhanceMasterLevel = outlook.equips.enhancemaster;
				}
			}
			this.SetFashionData(fashion, hairID, spacial_effect_id, false);
			this.CalculateOutLookFashion();
		}

		// Token: 0x0600A780 RID: 42880 RVA: 0x001DA1E7 File Offset: 0x001D83E7
		public void SetProfType(uint type)
		{
			this.m_typeID = type;
		}

		// Token: 0x0600A781 RID: 42881 RVA: 0x001DA1F4 File Offset: 0x001D83F4
		public uint GetProfType()
		{
			return this.m_typeID;
		}

		// Token: 0x0600A782 RID: 42882 RVA: 0x001DA20C File Offset: 0x001D840C
		public void SetDefaultFashion(short fashionTemplate)
		{
			XOutlookData.InitFasionList(ref this.outlookList);
			XEquipDocument.GetEquiplistByFashionTemplate(fashionTemplate, ref this.outlookList);
		}

		// Token: 0x0600A783 RID: 42883 RVA: 0x001DA228 File Offset: 0x001D8428
		public void SetFashion(int pos, int fashionID)
		{
			bool flag = this.fashionList != null;
			if (flag)
			{
				bool flag2 = pos >= 0 && pos < this.fashionList.Length;
				if (flag2)
				{
					this.fashionList[pos] = new FashionPositionInfo(fashionID);
				}
			}
		}

		// Token: 0x0600A784 RID: 42884 RVA: 0x001DA270 File Offset: 0x001D8470
		public bool SetFashionData(uint[] fashion, bool refresh = true)
		{
			bool flag = fashion == null || fashion.Length == 0;
			bool result;
			if (flag)
			{
				bool flag2 = this.fashionList != null;
				if (flag2)
				{
					XOutlookData.InitFasionList(ref this.fashionList);
				}
				result = true;
			}
			else
			{
				XOutlookData.InitFasionList(ref this.fashionList);
				for (int i = 0; i < fashion.Length; i++)
				{
					this.SetPart(ref this.fashionList, (int)fashion[i]);
				}
				if (refresh)
				{
					this.CalculateOutLookFashion();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A785 RID: 42885 RVA: 0x001DA2F4 File Offset: 0x001D84F4
		public bool SetFashionData(List<uint> fashion, uint hairID, uint spacial_effect_id, bool refresh = true)
		{
			this.hairColorID = hairID;
			this.suitEffectID = spacial_effect_id;
			bool flag = fashion == null || fashion.Count == 0;
			bool result;
			if (flag)
			{
				bool flag2 = this.fashionList != null;
				if (flag2)
				{
					XOutlookData.InitFasionList(ref this.fashionList);
				}
				result = true;
			}
			else
			{
				XOutlookData.InitFasionList(ref this.fashionList);
				for (int i = 0; i < fashion.Count; i++)
				{
					this.SetPart(ref this.fashionList, (int)fashion[i]);
				}
				if (refresh)
				{
					this.CalculateOutLookFashion();
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0600A786 RID: 42886 RVA: 0x001DA390 File Offset: 0x001D8590
		public void CalculateOutLookFashion()
		{
			bool flag = this.fashionList == null;
			if (flag)
			{
				XOutlookData.InitFasionList(ref this.outlookList);
				XEquipDocument.RefreshFashionList(ref this.outlookList, this.GetProfType());
			}
			else
			{
				XOutlookData.InitFasionList(ref this.outlookList);
				for (int i = 0; i < this.outlookList.Length; i++)
				{
					this.outlookList[i] = this.fashionList[i];
				}
				XEquipDocument.RefreshFashionList(ref this.outlookList, this.GetProfType());
			}
		}

		// Token: 0x0600A787 RID: 42887 RVA: 0x001DA41C File Offset: 0x001D861C
		public bool SetSpriteData(OutLook outlook)
		{
			bool flag = outlook == null;
			bool result;
			if (flag)
			{
				this.sprite.leaderid = 0U;
				result = false;
			}
			else
			{
				OutLookSprite outLookSprite = outlook.sprite;
				bool flag2 = outLookSprite == null;
				if (flag2)
				{
					this.sprite.leaderid = 0U;
					result = false;
				}
				else
				{
					bool flag3 = this.sprite.leaderid == outLookSprite.leaderid;
					if (flag3)
					{
						result = false;
					}
					else
					{
						this.sprite.leaderid = outLookSprite.leaderid;
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x0600A788 RID: 42888 RVA: 0x001DA496 File Offset: 0x001D8696
		public void SetSpriteData(uint leaderid)
		{
			this.sprite.leaderid = leaderid;
		}

		// Token: 0x04003DF3 RID: 15859
		public static FashionPositionInfo[] sharedFashionList = new FashionPositionInfo[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_ALL_END)];

		// Token: 0x04003DF4 RID: 15860
		public XBodyBag equipBag = null;

		// Token: 0x04003DF5 RID: 15861
		public uint enhanceMasterLevel = 0U;

		// Token: 0x04003DF6 RID: 15862
		public bool uiAvatar = false;

		// Token: 0x04003DF7 RID: 15863
		public bool isMainDummy = false;

		// Token: 0x04003DF8 RID: 15864
		private uint m_typeID = 0U;

		// Token: 0x04003DF9 RID: 15865
		public uint hairColorID = 0U;

		// Token: 0x04003DFA RID: 15866
		public uint suitEffectID = 0U;

		// Token: 0x04003DFB RID: 15867
		public XOutlookState state = new XOutlookState();

		// Token: 0x04003DFC RID: 15868
		public XOutlookSprite sprite = default(XOutlookSprite);

		// Token: 0x04003DFD RID: 15869
		private FashionPositionInfo[] fashionList;

		// Token: 0x04003DFE RID: 15870
		private FashionPositionInfo[] outlookList;
	}
}
