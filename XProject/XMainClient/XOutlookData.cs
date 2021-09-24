using System;
using System.Collections.Generic;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOutlookData
	{

		public FashionPositionInfo[] OutlookList
		{
			get
			{
				return this.outlookList;
			}
		}

		public static void InitSharedFasionList()
		{
			XOutlookData.InitFasionList(ref XOutlookData.sharedFashionList);
		}

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

		public void SetProfType(uint type)
		{
			this.m_typeID = type;
		}

		public uint GetProfType()
		{
			return this.m_typeID;
		}

		public void SetDefaultFashion(short fashionTemplate)
		{
			XOutlookData.InitFasionList(ref this.outlookList);
			XEquipDocument.GetEquiplistByFashionTemplate(fashionTemplate, ref this.outlookList);
		}

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

		public void SetSpriteData(uint leaderid)
		{
			this.sprite.leaderid = leaderid;
		}

		public static FashionPositionInfo[] sharedFashionList = new FashionPositionInfo[XFastEnumIntEqualityComparer<FashionPosition>.ToInt(FashionPosition.FASHION_ALL_END)];

		public XBodyBag equipBag = null;

		public uint enhanceMasterLevel = 0U;

		public bool uiAvatar = false;

		public bool isMainDummy = false;

		private uint m_typeID = 0U;

		public uint hairColorID = 0U;

		public uint suitEffectID = 0U;

		public XOutlookState state = new XOutlookState();

		public XOutlookSprite sprite = default(XOutlookSprite);

		private FashionPositionInfo[] fashionList;

		private FashionPositionInfo[] outlookList;
	}
}
