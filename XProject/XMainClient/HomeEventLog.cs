using System;
using KKSG;
using XUtliPoolLib;

namespace XMainClient
{

	internal class HomeEventLog
	{

		public HomeEventLog(GardenEventLog log, uint severTime)
		{
			bool flag = log == null;
			if (!flag)
			{
				this.m_roleId = log.role_id;
				this.SetTime((ulong)severTime, (ulong)log.occur_time);
				this.SetTxt(log);
			}
		}

		public ulong RoleID
		{
			get
			{
				return this.m_roleId;
			}
		}

		public string Txt
		{
			get
			{
				return this.m_txt;
			}
		}

		public string Time
		{
			get
			{
				return this.m_time;
			}
		}

		private void SetTime(ulong endT, ulong startT)
		{
			ulong num = (endT > startT) ? (endT - startT) : 0UL;
			bool flag = num < 60UL;
			if (flag)
			{
				this.m_time = string.Format(XStringDefineProxy.GetString("Home_Second"), num);
			}
			else
			{
				num /= 60UL;
				bool flag2 = num < 60UL;
				if (flag2)
				{
					this.m_time = string.Format(XStringDefineProxy.GetString("Home_Min"), num);
				}
				else
				{
					num /= 60UL;
					bool flag3 = num < 24UL;
					if (flag3)
					{
						this.m_time = string.Format(XStringDefineProxy.GetString("Home_Hour"), num);
					}
					else
					{
						num /= 24UL;
						bool flag4 = num < 7UL;
						if (flag4)
						{
							this.m_time = string.Format(XStringDefineProxy.GetString("Home_Day"), num);
						}
						else
						{
							num /= 7UL;
							this.m_time = string.Format(XStringDefineProxy.GetString("Home_Day"), num);
						}
					}
				}
			}
		}

		private void SetTxt(GardenEventLog log)
		{
			switch (log.event_type)
			{
			case 1U:
			{
				PlantSeed.RowData seedRow = this.GetSeedRow(log.target);
				bool result = log.result;
				if (result)
				{
					bool flag = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag)
					{
						bool flag2 = seedRow != null;
						if (flag2)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendWater_Right"), new object[]
							{
								log.role_name,
								seedRow.PlantName,
								100,
								seedRow.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag3 = seedRow != null;
						if (flag3)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendWater_Right"), new object[]
							{
								XStringDefineProxy.GetString("Log_Me"),
								seedRow.PlantName,
								100,
								seedRow.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				else
				{
					bool flag4 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag4)
					{
						bool flag5 = seedRow != null;
						if (flag5)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendWater_Error"), log.role_name, seedRow.PlantName, seedRow.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag6 = seedRow != null;
						if (flag6)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendWater_Error"), XStringDefineProxy.GetString("Log_Me"), seedRow.PlantName, seedRow.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				break;
			}
			case 2U:
			{
				PlantSeed.RowData seedRow2 = this.GetSeedRow(log.target);
				bool result2 = log.result;
				if (result2)
				{
					bool flag7 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag7)
					{
						bool flag8 = seedRow2 != null;
						if (flag8)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendDisinsection_Right"), new object[]
							{
								log.role_name,
								seedRow2.PlantName,
								100,
								seedRow2.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag9 = seedRow2 != null;
						if (flag9)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendDisinsection_Right"), new object[]
							{
								XStringDefineProxy.GetString("Log_Me"),
								seedRow2.PlantName,
								100,
								seedRow2.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				else
				{
					bool flag10 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag10)
					{
						bool flag11 = seedRow2 != null;
						if (flag11)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendDisinsection_Error"), log.role_name, seedRow2.PlantName, seedRow2.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag12 = seedRow2 != null;
						if (flag12)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendDisinsection_Error"), XStringDefineProxy.GetString("Log_Me"), seedRow2.PlantName, seedRow2.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				break;
			}
			case 3U:
			{
				PlantSeed.RowData seedRow3 = this.GetSeedRow(log.target);
				bool result3 = log.result;
				if (result3)
				{
					bool flag13 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag13)
					{
						bool flag14 = seedRow3 != null;
						if (flag14)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendFertilize_Right"), new object[]
							{
								log.role_name,
								seedRow3.PlantName,
								100,
								seedRow3.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag15 = seedRow3 != null;
						if (flag15)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendFertilize_Right"), new object[]
							{
								XStringDefineProxy.GetString("Log_Me"),
								seedRow3.PlantName,
								100,
								seedRow3.IncreaseGrowUpRate
							});
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				else
				{
					bool flag16 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag16)
					{
						bool flag17 = seedRow3 != null;
						if (flag17)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendFertilize_Error"), log.role_name, seedRow3.PlantName, seedRow3.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
					else
					{
						bool flag18 = seedRow3 != null;
						if (flag18)
						{
							this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendFertilize_Error"), XStringDefineProxy.GetString("Log_Me"), seedRow3.PlantName, seedRow3.ReduceGrowUpRate);
						}
						else
						{
							this.m_txt = "1";
						}
					}
				}
				break;
			}
			case 4U:
			{
				PlantSeed.RowData seedRow4 = this.GetSeedRow(log.target);
				bool flag19 = seedRow4 != null;
				if (flag19)
				{
					this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendSteal"), log.role_name, seedRow4.StealAward[1], seedRow4.PlantName);
				}
				else
				{
					this.m_txt = "4";
				}
				break;
			}
			case 5U:
				this.m_txt = XStringDefineProxy.GetString("Log_SpriteTrouble");
				break;
			case 6U:
			{
				bool flag20 = log.role_id != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag20)
				{
					this.m_txt = string.Format(XStringDefineProxy.GetString("Log_SpriteExpel"), log.role_name);
				}
				else
				{
					this.m_txt = string.Format(XStringDefineProxy.GetString("Log_SpriteExpel"), XStringDefineProxy.GetString("Log_Me"));
				}
				break;
			}
			case 7U:
			{
				PlantSprite.RowData plantSprite = this.GetPlantSprite(log.target);
				bool flag21 = plantSprite != null;
				if (flag21)
				{
					this.m_txt = string.Format(XStringDefineProxy.GetString("Log_SpriteDamageCrop"), plantSprite.ReduceGrowth);
				}
				else
				{
					this.m_txt = "7";
				}
				break;
			}
			case 8U:
				this.m_txt = string.Format(XStringDefineProxy.GetString("Log_FriendVist"), log.role_name);
				break;
			default:
				this.m_txt = "";
				break;
			}
		}

		private PlantSeed.RowData GetSeedRow(uint seedId)
		{
			return HomePlantDocument.PlantSeedTable.GetBySeedID(seedId);
		}

		private PlantSprite.RowData GetPlantSprite(uint spriteId)
		{
			return HomePlantDocument.PlantSpriteTable.GetBySpriteID(spriteId);
		}

		private ulong m_roleId;

		private string m_txt;

		private string m_time;
	}
}
