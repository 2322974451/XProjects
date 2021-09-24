using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XLevelScriptMgr : XSingleton<XLevelScriptMgr>
	{

		public void RunScript(string funcName)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("add script ", funcName, null, null, null, null);
			bool flag = !this._LevelScripts.ContainsKey(funcName);
			if (!flag)
			{
				bool flag2 = this._CmdQueue != null && this._CmdQueue.Count > 0;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddGreenLog("script function append", null, null, null, null, null);
				}
				bool flag3 = this._CmdQueue.Count == 0;
				if (flag3)
				{
					this._currentCmd = null;
				}
				List<LevelCmdDesc> list = this._LevelScripts[funcName];
				for (int i = 0; i < list.Count; i++)
				{
					list[i].Reset();
					this._CmdQueue.Add(list[i]);
				}
				this.Update();
			}
		}

		public bool IsCurrentCmdFinished()
		{
			bool flag = this._currentCmd == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this._currentCmd.state == XCmdState.Cmd_Finished;
				result = flag2;
			}
			return result;
		}

		public void ClearWallInfo()
		{
			this._LevelInfos.Clear();
		}

		public void PreloadLevelScript(string file)
		{
			this.Reset();
			this.ClearWallInfo();
			Stream stream = XSingleton<XResourceLoaderMgr>.singleton.ReadText("Table/" + file, ".txt", true);
			StreamReader streamReader = new StreamReader(stream);
			string key = "";
			for (;;)
			{
				string text = streamReader.ReadLine();
				bool flag = text == null;
				if (flag)
				{
					break;
				}
				text = text.Trim();
				bool flag2 = text.StartsWith("func:");
				if (flag2)
				{
					string text2 = text.Substring(5);
					List<LevelCmdDesc> value = new List<LevelCmdDesc>();
					this._LevelScripts.Add(text2, value);
					key = text2;
				}
				bool flag3 = text.StartsWith("talkl");
				if (flag3)
				{
					string[] array = text.Split(XGlobalConfig.TabSeparator);
					LevelCmdDesc levelCmdDesc = new LevelCmdDesc();
					levelCmdDesc.cmd = LevelCmd.Level_Cmd_TalkL;
					levelCmdDesc.Param.Add(array[1]);
					levelCmdDesc.Param.Add(array[2]);
					bool flag4 = array.Length > 3;
					if (flag4)
					{
						levelCmdDesc.Param.Add(array[3]);
					}
					this._LevelScripts[key].Add(levelCmdDesc);
				}
				else
				{
					bool flag5 = text.StartsWith("talkr");
					if (flag5)
					{
						string[] array2 = text.Split(XGlobalConfig.TabSeparator);
						LevelCmdDesc levelCmdDesc2 = new LevelCmdDesc();
						levelCmdDesc2.cmd = LevelCmd.Level_Cmd_TalkR;
						levelCmdDesc2.Param.Add(array2[1]);
						levelCmdDesc2.Param.Add(array2[2]);
						bool flag6 = array2.Length > 3;
						if (flag6)
						{
							levelCmdDesc2.Param.Add(array2[3]);
						}
						this._LevelScripts[key].Add(levelCmdDesc2);
					}
					else
					{
						bool flag7 = text.StartsWith("stoptalk");
						if (flag7)
						{
							LevelCmdDesc levelCmdDesc3 = new LevelCmdDesc();
							levelCmdDesc3.cmd = LevelCmd.Level_Cmd_Notalk;
							this._LevelScripts[key].Add(levelCmdDesc3);
						}
						else
						{
							bool flag8 = text.StartsWith("addbuff");
							if (flag8)
							{
								string[] array3 = text.Split(XGlobalConfig.TabSeparator);
								bool flag9 = array3.Length >= 4;
								if (flag9)
								{
									LevelCmdDesc levelCmdDesc4 = new LevelCmdDesc();
									levelCmdDesc4.cmd = LevelCmd.Level_Cmd_Addbuff;
									levelCmdDesc4.Param.Add(array3[1]);
									levelCmdDesc4.Param.Add(array3[2]);
									levelCmdDesc4.Param.Add(array3[3]);
									this._LevelScripts[key].Add(levelCmdDesc4);
								}
							}
							else
							{
								bool flag10 = text.StartsWith("removebuff");
								if (flag10)
								{
									string[] array4 = text.Split(XGlobalConfig.TabSeparator);
									bool flag11 = array4.Length >= 3;
									if (flag11)
									{
										LevelCmdDesc levelCmdDesc5 = new LevelCmdDesc();
										levelCmdDesc5.cmd = LevelCmd.Level_Cmd_Removebuff;
										levelCmdDesc5.Param.Add(array4[1]);
										levelCmdDesc5.Param.Add(array4[2]);
										this._LevelScripts[key].Add(levelCmdDesc5);
									}
								}
								else
								{
									bool flag12 = text.StartsWith("hidebillboard");
									if (flag12)
									{
										string[] array5 = text.Split(XGlobalConfig.TabSeparator);
										bool flag13 = array5.Length >= 3;
										if (flag13)
										{
											LevelCmdDesc levelCmdDesc6 = new LevelCmdDesc();
											levelCmdDesc6.cmd = LevelCmd.Level_Cmd_HideBillboard;
											levelCmdDesc6.Param.Add(array5[1]);
											levelCmdDesc6.Param.Add(array5[2]);
											this._LevelScripts[key].Add(levelCmdDesc6);
										}
									}
									else
									{
										bool flag14 = text.StartsWith("changebody");
										if (flag14)
										{
											string[] array6 = text.Split(XGlobalConfig.TabSeparator);
											bool flag15 = array6.Length >= 2;
											if (flag15)
											{
												LevelCmdDesc levelCmdDesc7 = new LevelCmdDesc();
												levelCmdDesc7.cmd = LevelCmd.Level_Cmd_ChangeBody;
												levelCmdDesc7.Param.Add(array6[1]);
												this._LevelScripts[key].Add(levelCmdDesc7);
											}
										}
										else
										{
											bool flag16 = text.StartsWith("justfx");
											if (flag16)
											{
												string[] array7 = text.Split(XGlobalConfig.TabSeparator);
												bool flag17 = array7.Length >= 2;
												if (flag17)
												{
													LevelCmdDesc levelCmdDesc8 = new LevelCmdDesc();
													levelCmdDesc8.cmd = LevelCmd.Level_Cmd_JustFx;
													levelCmdDesc8.Param.Add(array7[1]);
													this._LevelScripts[key].Add(levelCmdDesc8);
												}
											}
											else
											{
												bool flag18 = text.StartsWith("playfx");
												if (flag18)
												{
													string[] array8 = text.Split(XGlobalConfig.TabSeparator);
													bool flag19 = array8.Length >= 3;
													if (flag19)
													{
														LevelCmdDesc levelCmdDesc9 = new LevelCmdDesc();
														levelCmdDesc9.cmd = LevelCmd.Level_Cmd_PlayFx;
														levelCmdDesc9.Param.Add(array8[1]);
														levelCmdDesc9.Param.Add(array8[2]);
														this._LevelScripts[key].Add(levelCmdDesc9);
													}
												}
												else
												{
													bool flag20 = text.StartsWith("settutorial");
													if (flag20)
													{
														string[] array9 = text.Split(XGlobalConfig.TabSeparator);
														bool flag21 = array9.Length >= 2;
														if (flag21)
														{
															LevelCmdDesc levelCmdDesc10 = new LevelCmdDesc();
															levelCmdDesc10.cmd = LevelCmd.Level_Cmd_Tutorial;
															levelCmdDesc10.Param.Add(array9[1]);
															this._LevelScripts[key].Add(levelCmdDesc10);
														}
													}
													else
													{
														bool flag22 = text.StartsWith("notice");
														if (flag22)
														{
															string[] array10 = text.Split(XGlobalConfig.TabSeparator);
															bool flag23 = array10.Length >= 2;
															if (flag23)
															{
																LevelCmdDesc levelCmdDesc11 = new LevelCmdDesc();
																levelCmdDesc11.cmd = LevelCmd.Level_Cmd_Notice;
																levelCmdDesc11.Param.Add(array10[1]);
																bool flag24 = array10.Length >= 3;
																if (flag24)
																{
																	levelCmdDesc11.Param.Add(array10[2]);
																}
																this._LevelScripts[key].Add(levelCmdDesc11);
															}
														}
														else
														{
															bool flag25 = text.StartsWith("stopnotice");
															if (flag25)
															{
																LevelCmdDesc levelCmdDesc12 = new LevelCmdDesc();
																levelCmdDesc12.cmd = LevelCmd.Level_Cmd_StopNotice;
																this._LevelScripts[key].Add(levelCmdDesc12);
															}
															else
															{
																bool flag26 = text.StartsWith("opendoor");
																if (flag26)
																{
																	string[] array11 = text.Split(XGlobalConfig.TabSeparator);
																	bool flag27 = array11.Length >= 2;
																	if (flag27)
																	{
																		LevelCmdDesc levelCmdDesc13 = new LevelCmdDesc();
																		levelCmdDesc13.cmd = LevelCmd.Level_Cmd_Opendoor;
																		levelCmdDesc13.Param.Add(array11[1]);
																		bool flag28 = array11.Length > 2;
																		if (flag28)
																		{
																			levelCmdDesc13.Param.Add(array11[2]);
																		}
																		this._LevelScripts[key].Add(levelCmdDesc13);
																	}
																}
																else
																{
																	bool flag29 = text.StartsWith("killspawn");
																	if (flag29)
																	{
																		string[] array12 = text.Split(XGlobalConfig.TabSeparator);
																		bool flag30 = array12.Length >= 2;
																		if (flag30)
																		{
																			LevelCmdDesc levelCmdDesc14 = new LevelCmdDesc();
																			levelCmdDesc14.cmd = LevelCmd.Level_Cmd_KillSpawn;
																			levelCmdDesc14.Param.Add(array12[1]);
																			this._LevelScripts[key].Add(levelCmdDesc14);
																		}
																	}
																	else
																	{
																		bool flag31 = text.StartsWith("killallspawn");
																		if (flag31)
																		{
																			LevelCmdDesc levelCmdDesc15 = new LevelCmdDesc();
																			levelCmdDesc15.cmd = LevelCmd.Level_Cmd_KillAllSpawn;
																			this._LevelScripts[key].Add(levelCmdDesc15);
																		}
																		else
																		{
																			bool flag32 = text.StartsWith("killally");
																			if (flag32)
																			{
																				LevelCmdDesc levelCmdDesc16 = new LevelCmdDesc();
																				levelCmdDesc16.cmd = LevelCmd.Level_Cmd_KillAlly;
																				this._LevelScripts[key].Add(levelCmdDesc16);
																			}
																			else
																			{
																				bool flag33 = text.StartsWith("killwave");
																				if (flag33)
																				{
																					string[] array13 = text.Split(XGlobalConfig.TabSeparator);
																					bool flag34 = array13.Length >= 2;
																					if (flag34)
																					{
																						LevelCmdDesc levelCmdDesc17 = new LevelCmdDesc();
																						levelCmdDesc17.cmd = LevelCmd.Level_Cmd_KillWave;
																						levelCmdDesc17.Param.Add(array13[1]);
																						this._LevelScripts[key].Add(levelCmdDesc17);
																					}
																				}
																				else
																				{
																					bool flag35 = text.StartsWith("showcutscene");
																					if (flag35)
																					{
																						string[] array14 = text.Split(XGlobalConfig.TabSeparator);
																						bool flag36 = array14.Length >= 2;
																						if (flag36)
																						{
																							LevelCmdDesc levelCmdDesc18 = new LevelCmdDesc();
																							levelCmdDesc18.cmd = LevelCmd.Level_Cmd_Cutscene;
																							levelCmdDesc18.Param.Add(array14[1]);
																							bool flag37 = array14.Length >= 6;
																							if (flag37)
																							{
																								levelCmdDesc18.Param.Add(array14[2]);
																								levelCmdDesc18.Param.Add(array14[3]);
																								levelCmdDesc18.Param.Add(array14[4]);
																								levelCmdDesc18.Param.Add(array14[5]);
																								bool flag38 = array14.Length >= 7;
																								if (flag38)
																								{
																									levelCmdDesc18.Param.Add(array14[6]);
																								}
																							}
																							else
																							{
																								bool flag39 = array14.Length == 3;
																								if (flag39)
																								{
																									levelCmdDesc18.Param.Add(array14[2]);
																								}
																							}
																							this._LevelScripts[key].Add(levelCmdDesc18);
																						}
																					}
																					else
																					{
																						bool flag40 = text.StartsWith("levelupfx");
																						if (flag40)
																						{
																							LevelCmdDesc levelCmdDesc19 = new LevelCmdDesc();
																							levelCmdDesc19.cmd = LevelCmd.Level_Cmd_LevelupFx;
																							this._LevelScripts[key].Add(levelCmdDesc19);
																						}
																						else
																						{
																							bool flag41 = text.StartsWith("continue_UI");
																							if (flag41)
																							{
																								LevelCmdDesc levelCmdDesc20 = new LevelCmdDesc();
																								levelCmdDesc20.cmd = LevelCmd.Level_Cmd_Continue;
																								this._LevelScripts[key].Add(levelCmdDesc20);
																							}
																							else
																							{
																								bool flag42 = text.StartsWith("showskillslot");
																								if (flag42)
																								{
																									string[] array15 = text.Split(XGlobalConfig.TabSeparator);
																									bool flag43 = array15.Length >= 2;
																									if (flag43)
																									{
																										LevelCmdDesc levelCmdDesc21 = new LevelCmdDesc();
																										levelCmdDesc21.cmd = LevelCmd.Level_Cmd_ShowSkill;
																										levelCmdDesc21.Param.Add(array15[1]);
																										this._LevelScripts[key].Add(levelCmdDesc21);
																									}
																								}
																								else
																								{
																									bool flag44 = text.StartsWith("bubble");
																									if (flag44)
																									{
																										string[] array16 = text.Split(XGlobalConfig.TabSeparator);
																										bool flag45 = array16.Length >= 4;
																										if (flag45)
																										{
																											LevelCmdDesc levelCmdDesc22 = new LevelCmdDesc();
																											levelCmdDesc22.cmd = LevelCmd.Level_Cmd_Bubble;
																											levelCmdDesc22.Param.Add(array16[1]);
																											levelCmdDesc22.Param.Add(array16[2]);
																											levelCmdDesc22.Param.Add(array16[3]);
																											this._LevelScripts[key].Add(levelCmdDesc22);
																										}
																									}
																									else
																									{
																										bool flag46 = text.StartsWith("showdirection");
																										if (flag46)
																										{
																											string[] array17 = text.Split(XGlobalConfig.TabSeparator);
																											bool flag47 = array17.Length >= 2;
																											if (flag47)
																											{
																												LevelCmdDesc levelCmdDesc23 = new LevelCmdDesc();
																												levelCmdDesc23.cmd = LevelCmd.Level_Cmd_Direction;
																												levelCmdDesc23.Param.Add(array17[1]);
																												this._LevelScripts[key].Add(levelCmdDesc23);
																											}
																										}
																										else
																										{
																											bool flag48 = text.StartsWith("outline");
																											if (flag48)
																											{
																												string[] array18 = text.Split(XGlobalConfig.TabSeparator);
																												bool flag49 = array18.Length >= 2;
																												if (flag49)
																												{
																													LevelCmdDesc levelCmdDesc24 = new LevelCmdDesc();
																													levelCmdDesc24.cmd = LevelCmd.Level_Cmd_Outline;
																													levelCmdDesc24.Param.Add(array18[1]);
																													this._LevelScripts[key].Add(levelCmdDesc24);
																												}
																											}
																											else
																											{
																												bool flag50 = text.StartsWith("clientrecord");
																												if (flag50)
																												{
																													string[] array19 = text.Split(XGlobalConfig.TabSeparator);
																													bool flag51 = array19.Length >= 2;
																													if (flag51)
																													{
																														LevelCmdDesc levelCmdDesc25 = new LevelCmdDesc();
																														levelCmdDesc25.cmd = LevelCmd.Level_Cmd_Record;
																														levelCmdDesc25.Param.Add(array19[1]);
																														this._LevelScripts[key].Add(levelCmdDesc25);
																													}
																												}
																												else
																												{
																													bool flag52 = text.StartsWith("callnewbiehelper");
																													if (flag52)
																													{
																														LevelCmdDesc levelCmdDesc26 = new LevelCmdDesc();
																														levelCmdDesc26.cmd = LevelCmd.Level_Cmd_NewbieHelper;
																														this._LevelScripts[key].Add(levelCmdDesc26);
																													}
																													else
																													{
																														bool flag53 = text.StartsWith("newbienotice");
																														if (flag53)
																														{
																															string[] array20 = text.Split(XGlobalConfig.TabSeparator);
																															bool flag54 = array20.Length >= 2;
																															if (flag54)
																															{
																																LevelCmdDesc levelCmdDesc27 = new LevelCmdDesc();
																																levelCmdDesc27.cmd = LevelCmd.Level_Cmd_NewbieNotice;
																																levelCmdDesc27.Param.Add(array20[1]);
																																this._LevelScripts[key].Add(levelCmdDesc27);
																															}
																														}
																														else
																														{
																															bool flag55 = text.StartsWith("summon");
																															if (flag55)
																															{
																																string[] array21 = text.Split(XGlobalConfig.TabSeparator);
																																bool flag56 = array21.Length >= 4;
																																if (flag56)
																																{
																																	LevelCmdDesc levelCmdDesc28 = new LevelCmdDesc();
																																	levelCmdDesc28.cmd = LevelCmd.Level_Cmd_Summon;
																																	levelCmdDesc28.Param.Add(array21[1]);
																																	levelCmdDesc28.Param.Add(array21[2]);
																																	levelCmdDesc28.Param.Add(array21[3]);
																																	this._LevelScripts[key].Add(levelCmdDesc28);
																																}
																															}
																															else
																															{
																																bool flag57 = text.StartsWith("npcpopspeek");
																																if (flag57)
																																{
																																	string[] array22 = text.Split(XGlobalConfig.TabSeparator);
																																	bool flag58 = array22.Length >= 5;
																																	if (flag58)
																																	{
																																		LevelCmdDesc levelCmdDesc29 = new LevelCmdDesc();
																																		levelCmdDesc29.cmd = LevelCmd.Level_Cmd_NpcPopSpeek;
																																		levelCmdDesc29.Param.Add(array22[1]);
																																		levelCmdDesc29.Param.Add(array22[2]);
																																		levelCmdDesc29.Param.Add(array22[3]);
																																		levelCmdDesc29.Param.Add(array22[4]);
																																		bool flag59 = array22.Length >= 6;
																																		if (flag59)
																																		{
																																			levelCmdDesc29.Param.Add(array22[5]);
																																		}
																																		this._LevelScripts[key].Add(levelCmdDesc29);
																																	}
																																}
																																else
																																{
																																	bool flag60 = text.StartsWith("aicommand");
																																	if (flag60)
																																	{
																																		string[] array23 = text.Split(XGlobalConfig.TabSeparator);
																																		bool flag61 = array23.Length >= 3;
																																		if (flag61)
																																		{
																																			LevelCmdDesc levelCmdDesc30 = new LevelCmdDesc();
																																			levelCmdDesc30.cmd = LevelCmd.Level_Cmd_SendAICmd;
																																			levelCmdDesc30.Param.Add(array23[1]);
																																			levelCmdDesc30.Param.Add(array23[2]);
																																			bool flag62 = array23.Length >= 4;
																																			if (flag62)
																																			{
																																				levelCmdDesc30.Param.Add(array23[3]);
																																			}
																																			else
																																			{
																																				levelCmdDesc30.Param.Add("0");
																																			}
																																			this._LevelScripts[key].Add(levelCmdDesc30);
																																		}
																																	}
																																	else
																																	{
																																		bool flag63 = text.StartsWith("info");
																																		if (flag63)
																																		{
																																			string[] array24 = text.Split(XGlobalConfig.TabSeparator);
																																			string[] array25 = array24[1].Split(XGlobalConfig.ListSeparator);
																																			XLevelInfo xlevelInfo = new XLevelInfo();
																																			xlevelInfo.infoName = array24[0].Substring(5);
																																			xlevelInfo.x = float.Parse(array25[0]);
																																			xlevelInfo.y = float.Parse(array25[1]);
																																			xlevelInfo.z = float.Parse(array25[2]);
																																			xlevelInfo.face = float.Parse(array25[3]);
																																			bool flag64 = array24.Length >= 3;
																																			if (flag64)
																																			{
																																				xlevelInfo.enable = (array24[2] == "on");
																																			}
																																			bool flag65 = array24.Length >= 4;
																																			if (flag65)
																																			{
																																				xlevelInfo.width = float.Parse(array24[3]);
																																			}
																																			bool flag66 = array24.Length >= 5;
																																			if (flag66)
																																			{
																																				xlevelInfo.height = float.Parse(array24[4]);
																																			}
																																			else
																																			{
																																				xlevelInfo.height = float.MaxValue;
																																			}
																																			bool flag67 = array24.Length >= 6;
																																			if (flag67)
																																			{
																																				xlevelInfo.thickness = float.Parse(array24[5]);
																																			}
																																			this._LevelInfos.Add(xlevelInfo);
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
			}
			XSingleton<XResourceLoaderMgr>.singleton.ClearStream(stream);
		}

		public List<XLevelInfo> GetLevelScriptInfos()
		{
			return this._LevelInfos;
		}

		public void Update()
		{
			bool flag = this._CmdQueue == null || this._CmdQueue.Count == 0;
			if (!flag)
			{
				bool flag2 = this._currentCmd == null || this._currentCmd.state == XCmdState.Cmd_Finished;
				if (flag2)
				{
					this._currentCmd = ((this._CmdQueue.Count > 0) ? this._CmdQueue[0] : null);
					bool flag3 = this._currentCmd == null;
					if (!flag3)
					{
						this._CmdQueue.RemoveAt(0);
						this.CommandCount += 1U;
						this.Execute(this._currentCmd);
					}
				}
			}
		}

		public void ExecuteNextCmd()
		{
			bool flag = this._currentCmd != null;
			if (flag)
			{
				this._currentCmd.state = XCmdState.Cmd_Finished;
			}
			bool flag2 = this._CmdQueue.Count == 0;
			if (flag2)
			{
				this._currentCmd = null;
			}
			else
			{
				this._currentCmd = ((this._CmdQueue.Count > 0) ? this._CmdQueue[0] : null);
				bool flag3 = this._currentCmd == null;
				if (!flag3)
				{
					this._CmdQueue.RemoveAt(0);
					this.Execute(this._currentCmd);
				}
			}
		}

		public void Reset()
		{
			this._externalString.Clear();
			this._onceString.Clear();
			this._CmdQueue.Clear();
			this._currentCmd = null;
			this._LevelScripts.Clear();
		}

		protected void Execute(LevelCmdDesc cmd)
		{
			switch (cmd.cmd)
			{
			case LevelCmd.Level_Cmd_TalkL:
			{
				bool flag = cmd.Param.Count > 2;
				if (flag)
				{
					DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.SetLeftAvatar(cmd.Param[0], cmd.Param[1], cmd.Param[2]);
				}
				else
				{
					DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.SetLeftAvatar(cmd.Param[0], cmd.Param[1], string.Empty);
				}
				this._currentCmd.state = XCmdState.Cmd_In_Process;
				break;
			}
			case LevelCmd.Level_Cmd_TalkR:
			{
				bool flag2 = cmd.Param.Count > 2;
				if (flag2)
				{
					DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.SetRightAvatar(cmd.Param[0], cmd.Param[1], cmd.Param[2]);
				}
				else
				{
					DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.SetRightAvatar(cmd.Param[0], cmd.Param[1], string.Empty);
				}
				this._currentCmd.state = XCmdState.Cmd_In_Process;
				break;
			}
			case LevelCmd.Level_Cmd_Notalk:
				XSingleton<XLevelSpawnMgr>.singleton.BossExtarScriptExecuting = false;
				DlgBase<BattleDramaDlg, BattleDramaDlgBehaviour>.singleton.SetVisible(false, true);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_Addbuff:
			{
				XSingleton<XShell>.singleton.Pause = false;
				int buffID = int.Parse(cmd.Param[1]);
				int buffLevel = int.Parse(cmd.Param[2]);
				int num = int.Parse(cmd.Param[0]);
				bool flag3 = num == 0;
				if (flag3)
				{
					XBuffAddEventArgs @event = XEventPool<XBuffAddEventArgs>.GetEvent();
					@event.xBuffDesc.BuffID = buffID;
					@event.xBuffDesc.BuffLevel = buffLevel;
					@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
					@event.xBuffDesc.CasterID = XSingleton<XEntityMgr>.singleton.Player.ID;
					XSingleton<XEventMgr>.singleton.FireEvent(@event);
				}
				else
				{
					List<XEntity> opponent = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
					for (int i = 0; i < opponent.Count; i++)
					{
						bool flag4 = (ulong)opponent[i].TypeID == (ulong)((long)num);
						if (flag4)
						{
							XBuffAddEventArgs event2 = XEventPool<XBuffAddEventArgs>.GetEvent();
							event2.xBuffDesc.BuffID = buffID;
							event2.xBuffDesc.BuffLevel = buffLevel;
							event2.Firer = opponent[i];
							event2.xBuffDesc.CasterID = opponent[i].ID;
							XSingleton<XEventMgr>.singleton.FireEvent(event2);
						}
					}
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Tutorial:
			{
				bool needTutorail = XSingleton<XTutorialMgr>.singleton.NeedTutorail;
				if (needTutorail)
				{
					XSingleton<XTutorialMgr>.singleton.SetExternalString(cmd.Param[0]);
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Notice:
			{
				float duration = 3f;
				bool flag5 = cmd.Param.Count > 1;
				if (flag5)
				{
					duration = float.Parse(cmd.Param[1]);
				}
				bool flag6 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag6)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowNotice(cmd.Param[0], duration, 1f);
				}
				bool flag7 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag7)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowNotice(cmd.Param[0], duration, 1f);
				}
				bool flag8 = this._currentCmd != null;
				if (flag8)
				{
					this._currentCmd.state = XCmdState.Cmd_Finished;
				}
				break;
			}
			case LevelCmd.Level_Cmd_StopNotice:
			{
				bool flag9 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag9)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.StopNotice();
				}
				bool flag10 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag10)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.StopNotice();
				}
				bool flag11 = this._currentCmd != null;
				if (flag11)
				{
					this._currentCmd.state = XCmdState.Cmd_Finished;
				}
				break;
			}
			case LevelCmd.Level_Cmd_Opendoor:
			{
				GameObject gameObject = GameObject.Find(XSingleton<XSceneMgr>.singleton.GetSceneDynamicPrefix(XSingleton<XScene>.singleton.SceneID));
				Transform transform = XSingleton<XCommon>.singleton.FindChildRecursively(gameObject.transform, cmd.Param[0]);
				bool flag12 = transform == null;
				if (flag12)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Wall no exists: ", cmd.Param[0], null, null, null, null);
				}
				bool flag13 = cmd.Param.Count > 1;
				if (flag13)
				{
					bool flag14 = cmd.Param[1] == "on";
					if (flag14)
					{
						transform.gameObject.SetActive(true);
						bool flag15 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
						if (flag15)
						{
							DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.MiniMapAddDoor(transform);
						}
						bool flag16 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
						if (flag16)
						{
							DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IndicateHandler.MiniMapAddDoor(transform);
						}
						this.SwitchWallState(cmd.Param[0], true);
					}
					else
					{
						bool flag17 = cmd.Param[1].Length == 0 || cmd.Param[1] == "off";
						if (flag17)
						{
							transform.gameObject.SetActive(false);
							this.SwitchWallState(cmd.Param[0], false);
						}
					}
				}
				else
				{
					transform.gameObject.SetActive(false);
					this.SwitchWallState(cmd.Param[0], false);
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Cutscene:
			{
				XSingleton<XDebug>.singleton.AddLog("play cutscene ", cmd.Param[0], null, null, null, null, XDebugColor.XDebug_None);
				bool flag18 = cmd.Param.Count == 6;
				if (flag18)
				{
					XSingleton<XCutScene>.singleton.GeneralMonsterID = uint.Parse(cmd.Param[5]);
				}
				else
				{
					bool flag19 = cmd.Param.Count == 2;
					if (flag19)
					{
						XSingleton<XCutScene>.singleton.GeneralMonsterID = uint.Parse(cmd.Param[1]);
					}
				}
				bool flag20 = this.CommandCount == 1U;
				if (flag20)
				{
					XSingleton<XCutScene>.singleton.Start(cmd.Param[0], false, true);
				}
				else
				{
					XSingleton<XCutScene>.singleton.Start(cmd.Param[0], true, true);
				}
				bool flag21 = cmd.Param.Count >= 5;
				if (flag21)
				{
					float num2 = float.Parse(cmd.Param[1]);
					float num3 = float.Parse(cmd.Param[2]);
					float num4 = float.Parse(cmd.Param[3]);
					XSingleton<XCutScene>.singleton.EndWithDir = float.Parse(cmd.Param[4]);
					XSingleton<XCutScene>.singleton.EndWithPos = new Vector3(num2, num3, num4);
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_LevelupFx:
			{
				XPlayer player = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XFxMgr>.singleton.CreateAndPlay(XSingleton<XGlobalConfig>.singleton.GetValue("LevelupFx"), player.EngineObject, Vector3.zero, Vector3.one, 1f, true, 5f, true);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_ShowSkill:
			{
				int index = int.Parse(cmd.Param[0]);
				bool flag22 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag22)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.ShowSkillSlot(index);
				}
				XSingleton<XTutorialHelper>.singleton.MeetEnemy = false;
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_KillSpawn:
				XSingleton<XDebug>.singleton.AddErrorLog("找小邹: kill spawn", null, null, null, null, null);
				XSingleton<XLevelSpawnMgr>.singleton.CurrentSpawner.KillSpawn(int.Parse(cmd.Param[0]));
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_KillAlly:
				XSingleton<XDebug>.singleton.AddErrorLog("找小邹: kill ally", null, null, null, null, null);
				XSingleton<XEntityMgr>.singleton.KillAlly(XSingleton<XEntityMgr>.singleton.Player);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_KillWave:
			{
				int num5 = int.Parse(cmd.Param[0]);
				List<XEntity> all = XSingleton<XEntityMgr>.singleton.GetAll();
				for (int j = 0; j < all.Count; j++)
				{
					bool flag23 = num5 == all[j].Wave;
					if (flag23)
					{
						all[j].Attributes.ForceDeath();
					}
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Direction:
			{
				GameObject gameObject2 = GameObject.Find(XSingleton<XSceneMgr>.singleton.GetSceneDynamicPrefix(XSingleton<XScene>.singleton.SceneID));
				Transform transform2 = XSingleton<XCommon>.singleton.FindChildRecursively(gameObject2.transform, cmd.Param[0]);
				bool flag24 = transform2 != null;
				if (flag24)
				{
					bool flag25 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
					if (flag25)
					{
						DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.ShowDirection(transform2);
					}
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Outline:
			{
				int num6 = int.Parse(cmd.Param[0]);
				List<XEntity> opponent2 = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
				for (int k = 0; k < opponent2.Count; k++)
				{
					bool flag26 = opponent2[k].Wave == num6;
					if (flag26)
					{
						XHighlightEventArgs event3 = XEventPool<XHighlightEventArgs>.GetEvent();
						event3.Enabled = true;
						event3.Firer = opponent2[k];
						XSingleton<XEventMgr>.singleton.FireEvent(event3);
					}
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Record:
				XSingleton<XOperationRecord>.singleton.DoScriptRecord(cmd.Param[0]);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_Continue:
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_NewbieHelper:
			{
				uint num7 = 0U;
				uint num8 = 0U;
				uint num9 = 0U;
				XPlayer player2 = XSingleton<XEntityMgr>.singleton.Player;
				XBoss boss = XSingleton<XEntityMgr>.singleton.Boss;
				bool flag27 = player2 == null || boss == null;
				if (!flag27)
				{
					bool flag28 = num7 > 0U;
					if (flag28)
					{
						XSingleton<XLevelSpawnMgr>.singleton.SpawnExternalMonster(num7, new Vector3(104.3f, 9.93f, 104.5f), 0);
					}
					bool flag29 = num8 > 0U;
					if (flag29)
					{
						XSingleton<XLevelSpawnMgr>.singleton.SpawnExternalMonster(num8, new Vector3(106f, 9.93f, 105f), 0);
					}
					bool flag30 = num9 > 0U;
					if (flag30)
					{
						XSingleton<XLevelSpawnMgr>.singleton.SpawnExternalMonster(num9, new Vector3(103.83f, 9.93f, 101.12f), 0);
					}
					bool flag31 = this._currentCmd != null;
					if (flag31)
					{
						this._currentCmd.state = XCmdState.Cmd_Finished;
					}
				}
				break;
			}
			case LevelCmd.Level_Cmd_NewbieNotice:
			{
				bool flag32 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsLoaded();
				if (flag32)
				{
					DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.ShowBigNotice(cmd.Param[0]);
				}
				bool flag33 = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
				if (flag33)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.ShowBigNotice(cmd.Param[0], true);
				}
				bool flag34 = this._currentCmd != null;
				if (flag34)
				{
					this._currentCmd.state = XCmdState.Cmd_In_Process;
				}
				break;
			}
			case LevelCmd.Level_Cmd_Removebuff:
			{
				XSingleton<XShell>.singleton.Pause = false;
				int xBuffID = int.Parse(cmd.Param[1]);
				int num10 = int.Parse(cmd.Param[0]);
				bool flag35 = num10 == 0;
				if (flag35)
				{
					XBuffRemoveEventArgs event4 = XEventPool<XBuffRemoveEventArgs>.GetEvent();
					event4.xBuffID = xBuffID;
					event4.Firer = XSingleton<XEntityMgr>.singleton.Player;
					XSingleton<XEventMgr>.singleton.FireEvent(event4);
				}
				else
				{
					List<XEntity> opponent3 = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
					for (int l = 0; l < opponent3.Count; l++)
					{
						bool flag36 = (ulong)opponent3[l].TypeID == (ulong)((long)num10);
						if (flag36)
						{
							XBuffRemoveEventArgs event5 = XEventPool<XBuffRemoveEventArgs>.GetEvent();
							event5.xBuffID = xBuffID;
							event5.Firer = opponent3[l];
							XSingleton<XEventMgr>.singleton.FireEvent(event5);
						}
					}
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Summon:
			{
				uint enemyID = uint.Parse(cmd.Param[0]);
				uint num11 = uint.Parse(cmd.Param[2]);
				Vector3 pos = Vector3.zero;
				int rot = 0;
				bool flag37 = cmd.Param[1] == "[player]";
				if (flag37)
				{
					pos = XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position;
				}
				else
				{
					int num12 = int.Parse(cmd.Param[1]);
					List<XEntity> opponent4 = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
					for (int m = 0; m < opponent4.Count; m++)
					{
						bool flag38 = (ulong)opponent4[m].TypeID == (ulong)((long)num12);
						if (flag38)
						{
							pos = opponent4[m].EngineObject.Position;
							rot = (int)opponent4[m].EngineObject.Rotation.eulerAngles.y;
						}
					}
				}
				int num13 = 0;
				while ((long)num13 < (long)((ulong)num11))
				{
					XSingleton<XLevelSpawnMgr>.singleton.SpawnExternalMonster(enemyID, pos, rot);
					num13++;
				}
				bool flag39 = this._currentCmd != null;
				if (flag39)
				{
					this._currentCmd.state = XCmdState.Cmd_Finished;
				}
				break;
			}
			case LevelCmd.Level_Cmd_KillAllSpawn:
				XSingleton<XLevelFinishMgr>.singleton.KillAllOpponent();
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_NpcPopSpeek:
			{
				int type = int.Parse(cmd.Param[0]);
				int npcid = int.Parse(cmd.Param[1]);
				string text = cmd.Param[2];
				float time = float.Parse(cmd.Param[3]);
				string fmod = "";
				bool flag40 = cmd.Param.Count >= 5;
				if (flag40)
				{
					fmod = cmd.Param[4];
				}
				DlgBase<NpcPopSpeekView, DlgBehaviourBase>.singleton.ShowNpcPopSpeek(type, npcid, text, time, fmod);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_SendAICmd:
			{
				int num14 = int.Parse(cmd.Param[0]);
				string eventArg = cmd.Param[1];
				int typeId = int.Parse(cmd.Param[2]);
				List<XEntity> list = new List<XEntity>();
				bool flag41 = num14 == -1;
				if (flag41)
				{
					bool flag42 = XSingleton<XLevelSpawnMgr>.singleton.AIGlobal != null && XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host != null;
					if (flag42)
					{
						list.Add(XSingleton<XLevelSpawnMgr>.singleton.AIGlobal.Host);
					}
				}
				else
				{
					List<XEntity> ally = XSingleton<XEntityMgr>.singleton.GetAlly(XSingleton<XEntityMgr>.singleton.Player);
					List<XEntity> opponent5 = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
					for (int n = 0; n < ally.Count; n++)
					{
						bool flag43 = ally[n].Attributes.TypeID == (uint)num14;
						if (flag43)
						{
							list.Add(ally[n]);
						}
					}
					for (int num15 = 0; num15 < opponent5.Count; num15++)
					{
						bool flag44 = opponent5[num15].Attributes.TypeID == (uint)num14;
						if (flag44)
						{
							list.Add(opponent5[num15]);
						}
					}
				}
				for (int num16 = 0; num16 < list.Count; num16++)
				{
					XAIEventArgs event6 = XEventPool<XAIEventArgs>.GetEvent();
					event6.DepracatedPass = false;
					event6.Firer = list[num16];
					event6.EventType = 1;
					event6.EventArg = eventArg;
					event6.TypeId = typeId;
					XSingleton<XEventMgr>.singleton.FireEvent(event6, 0.05f);
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_Bubble:
				XSingleton<XLevelSpawnMgr>.singleton.CurrentSpawner.ShowBubble(int.Parse(cmd.Param[0]), cmd.Param[1], float.Parse(cmd.Param[2]));
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_HideBillboard:
			{
				int num17 = int.Parse(cmd.Param[0]);
				float hidetime = float.Parse(cmd.Param[1]);
				List<XEntity> opponent6 = XSingleton<XEntityMgr>.singleton.GetOpponent(XSingleton<XEntityMgr>.singleton.Player);
				for (int num18 = 0; num18 < opponent6.Count; num18++)
				{
					bool flag45 = (ulong)opponent6[num18].TypeID == (ulong)((long)num17);
					if (flag45)
					{
						XBillboardHideEventArgs event7 = XEventPool<XBillboardHideEventArgs>.GetEvent();
						event7.hidetime = hidetime;
						event7.Firer = opponent6[num18];
						XSingleton<XEventMgr>.singleton.FireEvent(event7);
					}
				}
				break;
			}
			case LevelCmd.Level_Cmd_ChangeBody:
			{
				XPlayer player3 = XSingleton<XEntityMgr>.singleton.Player;
				bool flag46 = player3 != null;
				if (flag46)
				{
					player3.OnTransform(uint.Parse(cmd.Param[0]));
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			case LevelCmd.Level_Cmd_JustFx:
				this.DoScriptJustFx(cmd.Param);
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			case LevelCmd.Level_Cmd_PlayFx:
			{
				Transform transform3 = XSingleton<UIManager>.singleton.UIRoot.Find("Camera").transform;
				bool flag47 = transform3 != null;
				if (flag47)
				{
					XSingleton<XFxMgr>.singleton.CreateAndPlay(cmd.Param[0], transform3, Vector3.zero, Vector3.one, 1f, true, float.Parse(cmd.Param[1]), true);
				}
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
			default:
				this._currentCmd.state = XCmdState.Cmd_Finished;
				break;
			}
		}

		public void SetExternalString(string str, bool bOnce)
		{
			if (bOnce)
			{
				bool flag = this._onceString.Contains(str);
				if (!flag)
				{
					this._externalString.Add(str);
					this._onceString.Add(str);
				}
			}
			else
			{
				this._externalString.Add(str);
			}
		}

		public bool QueryExternalString(string str, bool autoRemove)
		{
			bool flag = false;
			foreach (string a in this._externalString)
			{
				bool flag2 = a == str;
				if (flag2)
				{
					flag = true;
					break;
				}
			}
			bool flag3 = flag && autoRemove;
			if (flag3)
			{
				this._externalString.Remove(str);
			}
			return flag;
		}

		public bool IsTalkScript(string funcName)
		{
			bool flag = !this._LevelScripts.ContainsKey(funcName);
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("invalid script func", null, null, null, null, null);
				result = false;
			}
			else
			{
				LevelCmdDesc levelCmdDesc = this._LevelScripts[funcName][0];
				bool flag2 = levelCmdDesc.cmd == LevelCmd.Level_Cmd_TalkL || levelCmdDesc.cmd == LevelCmd.Level_Cmd_TalkR;
				result = flag2;
			}
			return result;
		}

		protected void SwitchWallState(string name, bool enabled)
		{
			for (int i = 0; i < this._LevelInfos.Count; i++)
			{
				bool flag = this._LevelInfos[i].infoName == name;
				if (flag)
				{
					this._LevelInfos[i].enable = enabled;
				}
			}
		}

		public void SyncWallState(string name, bool isOn)
		{
			this.SetClientWallState(name, isOn);
			this.SwitchWallState(name, isOn);
		}

		public void SetClientWallState(string name, bool isOn)
		{
			GameObject gameObject = GameObject.Find(XSingleton<XSceneMgr>.singleton.GetSceneDynamicPrefix(XSingleton<XScene>.singleton.SceneID));
			bool flag = gameObject == null;
			if (!flag)
			{
				Transform transform = XSingleton<XCommon>.singleton.FindChildRecursively(gameObject.transform, name);
				bool flag2 = transform == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Wall no exists: ", name, null, null, null, null);
				}
				else
				{
					transform.gameObject.SetActive(isOn);
				}
			}
		}

		public void ResetAirWallState()
		{
			for (int i = 0; i < this._LevelInfos.Count; i++)
			{
				this.SetClientWallState(this._LevelInfos[i].infoName, this._LevelInfos[i].enable);
			}
		}

		public void DoScriptJustFx(List<string> param)
		{
			float time = float.Parse(param[0]);
			XBattleDocument specificDocument = XDocuments.GetSpecificDocument<XBattleDocument>(XBattleDocument.uuID);
			int num = 1 << LayerMask.NameToLayer("Resources");
			num |= 1 << LayerMask.NameToLayer("QualityHigh");
			num |= 1 << LayerMask.NameToLayer("QualityNormal");
			num |= 1 << LayerMask.NameToLayer("QualityCullDistance");
			specificDocument.SetCameraLayer(num, time);
		}

		public uint CommandCount = 0U;

		private List<LevelCmdDesc> _CmdQueue = new List<LevelCmdDesc>();

		private LevelCmdDesc _currentCmd;

		public List<string> _externalString = new List<string>();

		public List<string> _onceString = new List<string>();

		private Dictionary<string, List<LevelCmdDesc>> _LevelScripts = new Dictionary<string, List<LevelCmdDesc>>();

		private List<XLevelInfo> _LevelInfos = new List<XLevelInfo>();
	}
}
