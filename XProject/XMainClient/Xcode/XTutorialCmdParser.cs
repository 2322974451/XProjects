using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTutorialCmdParser
	{

		public bool Parse(string file, int initStep, ref Queue<XTutorialCmd> cmdQueue, int execStep)
		{
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText(file, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			string text = streamReader.ReadLine();
			int num = 1;
			int num2 = 0;
			XTutorialCmd xtutorialCmd = null;
			bool flag = execStep <= 0;
			for (;;)
			{
				text = streamReader.ReadLine();
				num++;
				bool flag2 = text.StartsWith("end tutorial");
				if (flag2)
				{
					break;
				}
				bool flag3 = text.Length == 0;
				if (!flag3)
				{
					bool flag4 = text.StartsWith("--");
					if (!flag4)
					{
						string[] array = text.Split(XGlobalConfig.TabSeparator, StringSplitOptions.RemoveEmptyEntries);
						bool flag5 = false;
						bool flag6 = text.StartsWith("step");
						if (flag6)
						{
							num2++;
							bool flag7 = num2 <= initStep;
							if (flag7)
							{
								continue;
							}
							this._parseTmpCmd = new XTutorialCmd();
							this._parseTmpCmd.mainTutorialBit = execStep;
							bool flag8 = flag;
							if (flag8)
							{
								this._parseTmpCmd.step = num2;
							}
							else
							{
								this._parseTmpCmd.step = -1;
							}
							bool flag9 = array.Length > 1;
							if (flag9)
							{
								this._parseTmpCmd.tag = array[1];
							}
							else
							{
								this._parseTmpCmd.tag = "NULL";
							}
							this._parseTmpCmd.conditions = new List<XTutorialCmdExecuteCondition>();
							this._parseTmpCmd.condParams = new List<string>();
							this._parseTmpCmd.endParam = new List<string>();
							this._parseTmpCmd.endcondition = XTutorialCmdFinishCondition.No_Condition;
							this._parseTmpCmd.state = XCmdState.Cmd_In_Queue;
							this._parseTmpCmd.bLastCmdInQueue = false;
							this._parseTmpCmd.isOutError = true;
							this._parseTmpCmd.TutorialID = execStep;
							this._parseTmpCmd.isCanDestroyOverlay = true;
							flag5 = true;
						}
						else
						{
							bool flag10 = text.StartsWith("scond");
							if (flag10)
							{
								bool flag11 = this._parseTmpCmd != null;
								if (flag11)
								{
									bool flag12 = array.Length > 1;
									if (flag12)
									{
										this._parseTmpCmd.conditions.Add(this.Str2Condition(array[1]));
									}
									bool flag13 = array.Length > 2;
									if (flag13)
									{
										this._parseTmpCmd.condParams.Add(array[2]);
									}
									else
									{
										this._parseTmpCmd.condParams.Add("null");
									}
								}
								flag5 = true;
							}
							else
							{
								bool flag14 = text.StartsWith("econd");
								if (flag14)
								{
									bool flag15 = this._parseTmpCmd != null;
									if (flag15)
									{
										bool flag16 = array.Length > 1;
										if (flag16)
										{
											this._parseTmpCmd.endcondition = this.Str2EndCondition(array[1]);
										}
										bool flag17 = array.Length > 2;
										if (flag17)
										{
											this._parseTmpCmd.endParam.Add(array[2]);
										}
									}
									flag5 = true;
								}
								else
								{
									bool flag18 = text.StartsWith("text");
									if (flag18)
									{
										bool flag19 = this._parseTmpCmd != null;
										if (flag19)
										{
											bool flag20 = array.Length > 1;
											if (flag20)
											{
												this._parseTmpCmd.text = array[1];
											}
											bool flag21 = array.Length > 3;
											if (flag21)
											{
												this._parseTmpCmd.textPos = new Vector3((float)int.Parse(array[2]), (float)int.Parse(array[3]));
											}
											else
											{
												bool flag22 = array.Length > 2;
												if (flag22)
												{
													this._parseTmpCmd.textPos = new Vector3((float)int.Parse(array[2]), 0f);
												}
											}
										}
										flag5 = true;
									}
									else
									{
										bool flag23 = text.StartsWith("internaldelay");
										if (flag23)
										{
											bool flag24 = this._parseTmpCmd != null;
											if (flag24)
											{
												bool flag25 = array.Length > 1;
												if (flag25)
												{
													this._parseTmpCmd.interalDelay = float.Parse(array[1]);
												}
											}
											flag5 = true;
										}
										else
										{
											bool flag26 = text.StartsWith("ailin");
											if (flag26)
											{
												bool flag27 = this._parseTmpCmd != null;
												if (flag27)
												{
													bool flag28 = array.Length > 1;
													if (flag28)
													{
														this._parseTmpCmd.ailinText = array[1];
													}
													bool flag29 = array.Length > 2;
													if (flag29)
													{
														this._parseTmpCmd.ailinPos = int.Parse(array[2]);
													}
													bool flag30 = array.Length > 3;
													if (flag30)
													{
														this._parseTmpCmd.ailinText2 = array[3];
													}
												}
												flag5 = true;
											}
											else
											{
												bool flag31 = text.StartsWith("buttomtext");
												if (flag31)
												{
													bool flag32 = this._parseTmpCmd != null;
													if (flag32)
													{
														bool flag33 = array.Length > 1;
														if (flag33)
														{
															this._parseTmpCmd.buttomtext = array[1];
														}
													}
													flag5 = true;
												}
												else
												{
													bool flag34 = text.StartsWith("pause");
													if (flag34)
													{
														bool flag35 = this._parseTmpCmd != null;
														if (flag35)
														{
															this._parseTmpCmd.pause = true;
														}
														flag5 = true;
													}
													else
													{
														bool flag36 = text.StartsWith("audio");
														if (flag36)
														{
															bool flag37 = this._parseTmpCmd != null;
															if (flag37)
															{
																bool flag38 = array.Length > 1;
																if (flag38)
																{
																	this._parseTmpCmd.audio = array[1];
																}
															}
															flag5 = true;
														}
														else
														{
															bool flag39 = text.StartsWith("skip");
															if (flag39)
															{
																bool flag40 = this._parseTmpCmd != null;
																if (flag40)
																{
																	bool flag41 = array.Length > 1;
																	if (flag41)
																	{
																		this._parseTmpCmd.skipCondition = array[1];
																	}
																	bool flag42 = array.Length > 2;
																	if (flag42)
																	{
																		this._parseTmpCmd.skipParam1 = array[2];
																	}
																	bool flag43 = array.Length > 3;
																	if (flag43)
																	{
																		this._parseTmpCmd.skipParam2 = array[3];
																	}
																	bool flag44 = array.Length > 4;
																	if (flag44)
																	{
																		this._parseTmpCmd.skipParam3 = array[4];
																	}
																}
																flag5 = true;
															}
															else
															{
																bool flag45 = text.StartsWith("scroll");
																if (flag45)
																{
																	bool flag46 = this._parseTmpCmd != null;
																	if (flag46)
																	{
																		bool flag47 = array.Length > 1;
																		if (flag47)
																		{
																			this._parseTmpCmd.scroll = array[1];
																		}
																		bool flag48 = array.Length > 2;
																		if (flag48)
																		{
																			this._parseTmpCmd.scrollPos = int.Parse(array[2]);
																		}
																	}
																	flag5 = true;
																}
																else
																{
																	bool flag49 = text.StartsWith("function");
																	if (flag49)
																	{
																		bool flag50 = this._parseTmpCmd != null;
																		if (flag50)
																		{
																			bool flag51 = array.Length > 1;
																			if (flag51)
																			{
																				this._parseTmpCmd.function = array[1];
																			}
																			bool flag52 = array.Length > 2;
																			if (flag52)
																			{
																				this._parseTmpCmd.functionparam1 = array[2];
																			}
																		}
																		flag5 = true;
																	}
																	else
																	{
																		bool flag53 = text.StartsWith("nodestroyoverlay");
																		if (flag53)
																		{
																			this._parseTmpCmd.isCanDestroyOverlay = false;
																			flag5 = true;
																		}
																		else
																		{
																			bool flag54 = this._parseTmpCmd != null;
																			if (flag54)
																			{
																				for (int i = 0; i < this._validateCmd.Length; i++)
																				{
																					bool flag55 = array[0] == this._validateCmd[i];
																					if (flag55)
																					{
																						this._parseTmpCmd.cmd = array[0];
																						bool flag56 = array.Length > 1;
																						if (flag56)
																						{
																							this._parseTmpCmd.param1 = array[1];
																						}
																						bool flag57 = array.Length > 2;
																						if (flag57)
																						{
																							this._parseTmpCmd.param2 = array[2];
																						}
																						bool flag58 = array.Length > 3;
																						if (flag58)
																						{
																							this._parseTmpCmd.param3 = array[3];
																						}
																						bool flag59 = array.Length > 4;
																						if (flag59)
																						{
																							this._parseTmpCmd.param4 = array[4];
																						}
																						bool flag60 = array.Length > 5;
																						if (flag60)
																						{
																							this._parseTmpCmd.param5 = array[5];
																						}
																						bool flag61 = array.Length > 6;
																						if (flag61)
																						{
																							this._parseTmpCmd.param6 = array[6];
																						}
																						cmdQueue.Enqueue(this._parseTmpCmd);
																						xtutorialCmd = this._parseTmpCmd;
																						flag5 = true;
																						break;
																					}
																				}
																			}
																			else
																			{
																				flag5 = true;
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						bool flag62 = !flag5;
						if (flag62)
						{
							goto Block_63;
						}
					}
				}
			}
			bool flag63 = xtutorialCmd != null;
			if (flag63)
			{
				xtutorialCmd.bLastCmdInQueue = true;
				xtutorialCmd.TutorialID = execStep;
				bool flag64 = !flag;
				if (flag64)
				{
					xtutorialCmd.step = execStep;
				}
			}
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			return true;
			Block_63:
			XSingleton<XDebug>.singleton.AddErrorLog(file, "Tutorial Format Error at line ", num.ToString(), " !", null, null);
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			return false;
		}

		public bool Parse(string file, ref List<XTutorialMainCmd> cmdList, ref XBetterDictionary<uint, XTutorialMainCmd> _SysTutorial)
		{
			XTutorialMainCmd xtutorialMainCmd = new XTutorialMainCmd();
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText(file, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			string text = streamReader.ReadLine();
			int num = 1;
			for (;;)
			{
				text = streamReader.ReadLine();
				num++;
				bool flag = text.StartsWith("end tutorial");
				if (flag)
				{
					break;
				}
				bool flag2 = text.Length == 0;
				if (!flag2)
				{
					bool flag3 = text.StartsWith("--");
					if (!flag3)
					{
						string[] array = text.Split(XGlobalConfig.TabSeparator, StringSplitOptions.RemoveEmptyEntries);
						bool flag4 = false;
						bool flag5 = text.StartsWith("tutorial");
						if (flag5)
						{
							int savebit = int.Parse(array[1]);
							xtutorialMainCmd = new XTutorialMainCmd();
							xtutorialMainCmd.savebit = savebit;
							bool flag6 = array.Length > 2;
							if (flag6)
							{
								xtutorialMainCmd.tag = array[2];
							}
							else
							{
								xtutorialMainCmd.tag = "NULL";
							}
							bool flag7 = array.Length > 3;
							if (flag7)
							{
								xtutorialMainCmd.isMust = (array[3] == "must");
							}
							else
							{
								xtutorialMainCmd.isMust = false;
							}
							xtutorialMainCmd.conditions = new List<XTutorialCmdExecuteCondition>();
							xtutorialMainCmd.condParams = new List<string>();
							flag4 = true;
						}
						else
						{
							bool flag8 = text.StartsWith("scond");
							if (flag8)
							{
								bool flag9 = xtutorialMainCmd != null;
								if (flag9)
								{
									bool flag10 = array.Length > 1;
									if (flag10)
									{
										XTutorialCmdExecuteCondition xtutorialCmdExecuteCondition = this.Str2Condition(array[1]);
										xtutorialMainCmd.conditions.Add(xtutorialCmdExecuteCondition);
										bool flag11 = array.Length > 2;
										if (flag11)
										{
											xtutorialMainCmd.condParams.Add(array[2]);
											bool flag12 = xtutorialCmdExecuteCondition == XTutorialCmdExecuteCondition.Sys_Notify;
											if (flag12)
											{
												bool flag13 = array.Length > 3 && int.Parse(array[3]) > 0;
												if (!flag13)
												{
													_SysTutorial.Add(uint.Parse(array[2]), xtutorialMainCmd);
												}
											}
										}
										else
										{
											xtutorialMainCmd.condParams.Add("");
										}
									}
								}
								flag4 = true;
							}
							else
							{
								bool flag14 = text.StartsWith("exec");
								if (flag14)
								{
									bool flag15 = xtutorialMainCmd != null;
									if (flag15)
									{
										xtutorialMainCmd.subTutorial = array[1];
										cmdList.Add(xtutorialMainCmd);
									}
									flag4 = true;
								}
							}
						}
						bool flag16 = !flag4;
						if (flag16)
						{
							goto Block_16;
						}
					}
				}
			}
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			return true;
			Block_16:
			XSingleton<XDebug>.singleton.AddLog(file, "Tutorial Format Error at line ", num.ToString(), " !", null, null, XDebugColor.XDebug_None);
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
			return false;
		}

		private XTutorialCmdExecuteCondition Str2Condition(string strCondition)
		{
			bool flag = strCondition == "playerlevel";
			XTutorialCmdExecuteCondition result;
			if (flag)
			{
				result = XTutorialCmdExecuteCondition.Player_Level;
			}
			else
			{
				bool flag2 = strCondition == "afterlevel";
				if (flag2)
				{
					result = XTutorialCmdExecuteCondition.After_Level;
				}
				else
				{
					bool flag3 = strCondition == "inlevel";
					if (flag3)
					{
						result = XTutorialCmdExecuteCondition.In_Level;
					}
					else
					{
						bool flag4 = strCondition == "musou";
						if (flag4)
						{
							result = XTutorialCmdExecuteCondition.Musou_Above;
						}
						else
						{
							bool flag5 = strCondition == "castskill";
							if (flag5)
							{
								result = XTutorialCmdExecuteCondition.Cast_Skill;
							}
							else
							{
								bool flag6 = strCondition == "exstring";
								if (flag6)
								{
									result = XTutorialCmdExecuteCondition.External_String;
								}
								else
								{
									bool flag7 = strCondition == "TalkingNpc";
									if (flag7)
									{
										result = XTutorialCmdExecuteCondition.Talk_Npc;
									}
									else
									{
										bool flag8 = strCondition == "accepttask";
										if (flag8)
										{
											result = XTutorialCmdExecuteCondition.Can_Accept_Task;
										}
										else
										{
											bool flag9 = strCondition == "dotaskbattle";
											if (flag9)
											{
												result = XTutorialCmdExecuteCondition.Task_Battle;
											}
											else
											{
												bool flag10 = strCondition == "taskscenefinished";
												if (flag10)
												{
													result = XTutorialCmdExecuteCondition.Task_Scene_Finish;
												}
												else
												{
													bool flag11 = strCondition == "taskover";
													if (flag11)
													{
														result = XTutorialCmdExecuteCondition.Task_Over;
													}
													else
													{
														bool flag12 = strCondition == "finishtask";
														if (flag12)
														{
															result = XTutorialCmdExecuteCondition.Can_Finish_Task;
														}
														else
														{
															bool flag13 = strCondition == "delay";
															if (flag13)
															{
																result = XTutorialCmdExecuteCondition.Time_Delay;
															}
															else
															{
																bool flag14 = strCondition == "SysNotify";
																if (flag14)
																{
																	result = XTutorialCmdExecuteCondition.Sys_Notify;
																}
																else
																{
																	bool flag15 = strCondition == "meetenemy";
																	if (flag15)
																	{
																		result = XTutorialCmdExecuteCondition.Meet_Enemy;
																	}
																	else
																	{
																		bool flag16 = strCondition == "hastarget";
																		if (flag16)
																		{
																			result = XTutorialCmdExecuteCondition.Has_Target;
																		}
																		else
																		{
																			bool flag17 = strCondition == "getfocus";
																			if (flag17)
																			{
																				result = XTutorialCmdExecuteCondition.Get_Focused;
																			}
																			else
																			{
																				bool flag18 = strCondition == "artskill";
																				if (flag18)
																				{
																					result = XTutorialCmdExecuteCondition.Art_Skill;
																				}
																				else
																				{
																					bool flag19 = strCondition == "superarmor0";
																					if (flag19)
																					{
																						result = XTutorialCmdExecuteCondition.No_SuperAmor;
																					}
																					else
																					{
																						bool flag20 = strCondition == "cutsceneover";
																						if (flag20)
																						{
																							result = XTutorialCmdExecuteCondition.Cutscene_Over;
																						}
																						else
																						{
																							bool flag21 = strCondition == "bossexist";
																							if (flag21)
																							{
																								result = XTutorialCmdExecuteCondition.Boss_Exist;
																							}
																							else
																							{
																								bool flag22 = strCondition == "enemyonground";
																								if (flag22)
																								{
																									result = XTutorialCmdExecuteCondition.Enemy_OnGround;
																								}
																								else
																								{
																									bool flag23 = strCondition == "nopromote";
																									if (flag23)
																									{
																										result = XTutorialCmdExecuteCondition.No_Promote;
																									}
																									else
																									{
																										bool flag24 = strCondition == "team2";
																										if (flag24)
																										{
																											result = XTutorialCmdExecuteCondition.Team2;
																										}
																										else
																										{
																											bool flag25 = strCondition == "MainUI";
																											if (flag25)
																											{
																												result = XTutorialCmdExecuteCondition.MainUI;
																											}
																											else
																											{
																												bool flag26 = strCondition == "item";
																												if (flag26)
																												{
																													result = XTutorialCmdExecuteCondition.Has_Item;
																												}
																												else
																												{
																													bool flag27 = strCondition == "hasbody";
																													if (flag27)
																													{
																														result = XTutorialCmdExecuteCondition.Has_Body;
																													}
																													else
																													{
																														bool flag28 = strCondition == "nostackui";
																														if (flag28)
																														{
																															result = XTutorialCmdExecuteCondition.No_Stackui;
																														}
																														else
																														{
																															bool flag29 = strCondition == "activityopen";
																															if (flag29)
																															{
																																result = XTutorialCmdExecuteCondition.Activity_Open;
																															}
																															else
																															{
																																bool flag30 = strCondition == "dragoncrusadeopen";
																																if (flag30)
																																{
																																	result = XTutorialCmdExecuteCondition.Dragon_Crusade_Open;
																																}
																																else
																																{
																																	bool flag31 = strCondition == "battleNPCtalkend";
																																	if (flag31)
																																	{
																																		result = XTutorialCmdExecuteCondition.Battle_NPC_Talk_End;
																																	}
																																	else
																																	{
																																		result = XTutorialCmdExecuteCondition.No_Condition;
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		private XTutorialCmdFinishCondition Str2EndCondition(string strCondition)
		{
			bool flag = strCondition == "click";
			XTutorialCmdFinishCondition result;
			if (flag)
			{
				result = XTutorialCmdFinishCondition.Click;
			}
			else
			{
				bool flag2 = strCondition == "time";
				if (flag2)
				{
					result = XTutorialCmdFinishCondition.Time;
				}
				else
				{
					bool flag3 = strCondition == "TalkingNpc";
					if (flag3)
					{
						result = XTutorialCmdFinishCondition.TalkingNpc;
					}
					else
					{
						bool flag4 = strCondition == "WorldMapShow";
						if (flag4)
						{
							result = XTutorialCmdFinishCondition.WorldMap;
						}
						else
						{
							bool flag5 = strCondition == "SkillLevelup";
							if (flag5)
							{
								result = XTutorialCmdFinishCondition.SkillLevelup;
							}
							else
							{
								bool flag6 = strCondition == "SkillBind";
								if (flag6)
								{
									result = XTutorialCmdFinishCondition.SkillBind;
								}
								else
								{
									bool flag7 = strCondition == "UseItem";
									if (flag7)
									{
										result = XTutorialCmdFinishCondition.UseItem;
									}
									else
									{
										bool flag8 = strCondition == "SysOpened";
										if (flag8)
										{
											result = XTutorialCmdFinishCondition.SysOpened;
										}
										else
										{
											bool flag9 = strCondition == "GetReward";
											if (flag9)
											{
												result = XTutorialCmdFinishCondition.GetReward;
											}
											else
											{
												bool flag10 = strCondition == "Move";
												if (flag10)
												{
													result = XTutorialCmdFinishCondition.Move;
												}
												else
												{
													bool flag11 = strCondition == "ComposeFashion";
													if (flag11)
													{
														result = XTutorialCmdFinishCondition.ComposeFashion;
													}
													else
													{
														bool flag12 = strCondition == "EnhanceItem";
														if (flag12)
														{
															result = XTutorialCmdFinishCondition.EnhanceItem;
														}
														else
														{
															bool flag13 = strCondition == "ReinforceItem";
															if (flag13)
															{
																result = XTutorialCmdFinishCondition.ReinforceItem;
															}
															else
															{
																bool flag14 = strCondition == "ChooseProf";
																if (flag14)
																{
																	result = XTutorialCmdFinishCondition.ChangeProf;
																}
																else
																{
																	bool flag15 = strCondition == "HasTeam";
																	if (flag15)
																	{
																		result = XTutorialCmdFinishCondition.HasTeam;
																	}
																	else
																	{
																		bool flag16 = strCondition == "Smelting";
																		if (flag16)
																		{
																			result = XTutorialCmdFinishCondition.Smelting;
																		}
																		else
																		{
																			bool flag17 = strCondition == "SelectView";
																			if (flag17)
																			{
																				result = XTutorialCmdFinishCondition.SelectView;
																			}
																			else
																			{
																				bool flag18 = strCondition == "SelectSkipTutorial";
																				if (flag18)
																				{
																					result = XTutorialCmdFinishCondition.SelectSkipTutorial;
																				}
																				else
																				{
																					result = XTutorialCmdFinishCondition.No_Condition;
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		private XTutorialCmd _parseTmpCmd;

		private string[] _validateCmd = new string[]
		{
			"forceclick",
			"newsys",
			"exec",
			"forceslide",
			"noforceclick",
			"noforceslide",
			"forcedoubleclick",
			"puretext",
			"genericclick",
			"cutscene",
			"directsys",
			"movetutorial",
			"forceskill",
			"overlay",
			"showprefab",
			"notewindow",
			"hideskills",
			"showskills",
			"showbutton",
			"clickentity",
			"empty"
		};
	}
}
