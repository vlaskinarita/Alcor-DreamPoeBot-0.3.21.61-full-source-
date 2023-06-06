using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using DreamPoeBot.Common;
using DreamPoeBot.Loki.Controllers;
using DreamPoeBot.Loki.Game.GameData;
using DreamPoeBot.Loki.Game.Objects;
using DreamPoeBot.Loki.Game.Std;
using DreamPoeBot.Structures.ns14;
using DreamPoeBot.Structures.ns19;

namespace DreamPoeBot.Loki.Game;

public class Inventory : RemoteMemoryObject
{
	public class HashNodeStruct242 : RemoteMemoryObject
	{
		private int _struct242Size = -1;

		private int Struct242Size
		{
			get
			{
				if (_struct242Size == -1)
				{
					_struct242Size = MarshalCache<Struct242>.Size;
				}
				return _struct242Size;
			}
		}

		public HashNodeStruct242 Previous => ReadObject<HashNodeStruct242>(base.Address);

		public HashNodeStruct242 Root => ReadObject<HashNodeStruct242>(base.Address + 8L);

		public HashNodeStruct242 Next => ReadObject<HashNodeStruct242>(base.Address + 16L);

		public bool IsNull => GameController.Instance.Memory.ReadByte(base.Address + 25L) != 0;

		public int Key => GameController.Instance.Memory.ReadInt(base.Address + 32L);

		internal long Value1 => GameController.Instance.Memory.ReadLong(base.Address + 40L);
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int col;

		public Inventory _003C_003E4__this;

		internal bool _003CGetItemPlacementGraph_003Eb__0(KeyValuePair<int, Item> x)
		{
			return x.Value.LocationTopLeft == new Vector2i(col, (!_003C_003E4__this._isEldrichTab) ? 1 : 2);
		}
	}

	private LokiPoe.InGameState.SentinelLockerUi.SentinelType _sentinelType;

	private List<int> _storableBaseItemTypeKeys;

	private bool _isEldrichTab;

	private bool _isMavenTab;

	private int _struct244InventorySize = -1;

	public int Id { get; internal set; }

	private int Struct244InventorySize
	{
		get
		{
			if (_struct244InventorySize == -1)
			{
				_struct244InventorySize = MarshalCache<Struct244Inventory>.Size;
			}
			return _struct244InventorySize;
		}
	}

	internal Struct244Inventory Struct244_0 => GameController.Instance.Memory.FastIntPtrToStruct<Struct244Inventory>(base.Address + 320L, Struct244InventorySize);

	public bool IsRequested => Struct244_0.isRequested == 1;

	public InventoryType PageType => Struct244_0.inventoryType_0;

	public InventorySlot PageSlot => Struct244_0.inventorySlot_0;

	public Dictionary<int, Item> ItemMap
	{
		get
		{
			if (!_isEldrichTab)
			{
				uint num = default(uint);
				Dictionary<int, Item> result = default(Dictionary<int, Item>);
				Dictionary<int, Item> source2 = default(Dictionary<int, Item>);
				Dictionary<int, long> source3 = default(Dictionary<int, long>);
				Dictionary<int, Item> source4 = default(Dictionary<int, Item>);
				while (!_isMavenTab)
				{
					while (true)
					{
						if (base.Address != 0L)
						{
							while (true)
							{
								if (PageType != InventoryType.EspeditionLocker)
								{
									while (true)
									{
										if (PageType == InventoryType.SentinelLocker)
										{
											while (true)
											{
												string metadata;
												string metadata2;
												while (true)
												{
													Dictionary<int, Item> source = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap).ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
													while (true)
													{
														IL_012f:
														metadata = "";
														while (true)
														{
															IL_0121:
															metadata2 = "";
															while (true)
															{
																IL_0117:
																LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
																while (true)
																{
																	IL_00fb:
																	switch (sentinelType)
																	{
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
																		goto IL_0260;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
																		goto IL_027a;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
																		goto IL_0294;
																	case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
																		goto IL_02ac;
																	}
																	int num2 = ((int)num * -1203065868) ^ -193939080;
																	while (true)
																	{
																		switch ((num = (uint)num2 ^ 0x2BF38B5Cu) % 28u)
																		{
																		case 14u:
																			break;
																		case 16u:
																			num2 = ((int)num * -1905942273) ^ 0x633DAF6E;
																			continue;
																		case 1u:
																			goto IL_00fb;
																		case 19u:
																			goto IL_0117;
																		case 25u:
																			goto IL_0121;
																		case 12u:
																			goto IL_012f;
																		case 27u:
																			goto end_IL_0010;
																		case 10u:
																			goto end_IL_0159;
																		case 17u:
																			goto end_IL_0165;
																		case 22u:
																			goto end_IL_0174;
																		case 21u:
																		case 26u:
																			goto end_IL_0180;
																		case 6u:
																			goto IL_019a;
																		case 8u:
																			goto IL_01f0;
																		case 13u:
																			goto IL_025a;
																		case 2u:
																			goto IL_0260;
																		case 11u:
																			goto IL_027a;
																		case 4u:
																			goto IL_0286;
																		case 7u:
																			goto IL_0294;
																		case 0u:
																		case 18u:
																			goto IL_02ac;
																		case 3u:
																			goto IL_0304;
																		case 9u:
																			goto IL_0316;
																		case 24u:
																			goto IL_035b;
																		default:
																			return result;
																		case 23u:
																			goto end_IL_018d;
																		case 5u:
																			goto IL_03d8;
																		case 20u:
																			goto IL_041e;
																		}
																		break;
																	}
																	break;
																	IL_0260:
																	metadata = "SentinelA";
																	metadata2 = "SentinelCraftedA";
																	goto IL_02ac;
																	IL_02ac:
																	return source.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && (x.Value.Metadata.Contains(metadata) || x.Value.Metadata.Contains(metadata2))).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
																	IL_0294:
																	metadata = "SentinelC";
																	metadata2 = "SentinelCraftedC";
																	goto IL_02ac;
																	IL_027a:
																	metadata = "SentinelB";
																	goto IL_0286;
																	IL_0286:
																	metadata2 = "SentinelCraftedB";
																	goto IL_02ac;
																}
																break;
															}
															break;
														}
														break;
													}
													continue;
													end_IL_0010:
													break;
												}
												continue;
												end_IL_0159:
												break;
											}
											continue;
										}
										goto IL_0304;
										IL_035b:
										return source2.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
										IL_0304:
										source3 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap);
										goto IL_0316;
										IL_0316:
										source2 = source3.ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
										goto IL_035b;
										continue;
										end_IL_0165:
										break;
									}
									continue;
								}
								goto IL_019a;
								IL_01f0:
								return source4.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && x.Value.Metadata == "Metadata/Items/Expedition/ExpeditionLogbook").ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
								IL_019a:
								source4 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap).ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
								goto IL_01f0;
								continue;
								end_IL_0174:
								break;
							}
							continue;
						}
						goto IL_025a;
						IL_025a:
						return new Dictionary<int, Item>();
						continue;
						end_IL_0180:
						break;
					}
					continue;
					end_IL_018d:
					break;
				}
			}
			Dictionary<int, long> source5 = Containers.StdMapIntLong(Struct244_0.nativeMap_ItemMap);
			goto IL_03d8;
			IL_03d8:
			Dictionary<int, Item> source6 = source5.ToDictionary((KeyValuePair<int, long> item) => item.Key, (KeyValuePair<int, long> item) => new Class247(item.Value, item.Key).Item_0);
			goto IL_041e;
			IL_041e:
			return source6.Where((KeyValuePair<int, Item> x) => x.Value != null && x.Value.IsValid && IsEldrichMavenBaseItemType(x.Value.BaseItemType.Index)).ToDictionary((KeyValuePair<int, Item> x) => x.Key, (KeyValuePair<int, Item> x) => x.Value);
		}
	}

	public List<Item> Items
	{
		get
		{
			if (base.Address == 0L)
			{
				return new List<Item>();
			}
			return ItemMap.Values.ToList();
		}
	}

	public int Rows
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.rows;
			}
			return 6;
		}
	}

	public int Cols
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Columns;
			}
			return 12;
		}
	}

	public int Columns
	{
		get
		{
			if (!_isEldrichTab && !_isMavenTab)
			{
				return Struct244_0.cols;
			}
			return 12;
		}
	}

	public int InventorySpacePercent
	{
		get
		{
			if (PageType == InventoryType.SentinelLocker)
			{
				return (int)(100.0 * (double)AvailableInventorySquares / 120.0);
			}
			return (int)(100.0 * (double)AvailableInventorySquares / (double)((float)Rows * (float)Columns));
		}
	}

	public int AvailableInventorySquares
	{
		get
		{
			int rows = Rows;
			uint num3 = default(uint);
			int num5 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			int num8 = default(int);
			while (true)
			{
				int columns = Columns;
				bool[,] itemPlacementGraph = GetItemPlacementGraph();
				while (true)
				{
					int num = 0;
					while (true)
					{
						if (PageType == InventoryType.SentinelLocker)
						{
							while (true)
							{
								int num2 = 0;
								LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
								while (true)
								{
									switch (sentinelType)
									{
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
										goto IL_013c;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
										goto IL_0141;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
										goto IL_0147;
									case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
										goto IL_014b;
									}
									int num4 = (int)(num3 * 1530792477) ^ -1949115415;
									while (true)
									{
										switch ((num3 = (uint)num4 ^ 0x3724055Bu) % 32u)
										{
										case 10u:
											num4 = (int)((num3 * 1027675841) ^ 0x3F71FE4D);
											continue;
										case 24u:
											break;
										case 20u:
											goto end_IL_00bd;
										case 2u:
											goto end_IL_00d9;
										case 0u:
											goto end_IL_00e6;
										case 19u:
										case 23u:
											goto end_IL_00f2;
										case 15u:
											goto IL_0106;
										case 16u:
										case 31u:
											goto IL_010b;
										case 6u:
											goto IL_0110;
										case 1u:
											goto IL_0118;
										case 17u:
											goto IL_011d;
										case 18u:
											goto IL_0129;
										case 29u:
											goto IL_012d;
										case 5u:
										case 30u:
											goto IL_0135;
										default:
											goto IL_013a;
										case 8u:
											goto IL_013c;
										case 14u:
											goto IL_0141;
										case 11u:
											goto IL_0147;
										case 21u:
										case 28u:
											goto IL_014b;
										case 7u:
											goto IL_0151;
										case 12u:
											goto IL_0156;
										case 27u:
											goto IL_0162;
										case 13u:
											goto IL_0166;
										case 4u:
											goto IL_016c;
										case 22u:
											goto IL_0171;
										case 3u:
										case 26u:
											goto IL_0177;
										case 25u:
											goto IL_0180;
										}
										break;
									}
									continue;
									IL_0162:
									num++;
									goto IL_0166;
									IL_0166:
									num5++;
									goto IL_016c;
									IL_0147:
									num2 = 24;
									goto IL_014b;
									IL_0141:
									num2 = 12;
									goto IL_014b;
									IL_013c:
									num2 = 0;
									goto IL_014b;
									IL_014b:
									num6 = num2;
									goto IL_0177;
									IL_0177:
									if (num6 < num2 + 12)
									{
										goto IL_0151;
									}
									goto IL_0180;
									IL_0180:
									return num;
									IL_0151:
									num5 = 0;
									goto IL_016c;
									IL_016c:
									if (num5 < rows)
									{
										goto IL_0156;
									}
									goto IL_0171;
									IL_0171:
									num6++;
									goto IL_0177;
									IL_0156:
									if (!itemPlacementGraph[num5, num6])
									{
										goto IL_0162;
									}
									goto IL_0166;
									continue;
									end_IL_00bd:
									break;
								}
								continue;
								end_IL_00d9:
								break;
							}
							continue;
						}
						goto IL_0106;
						IL_012d:
						num7++;
						goto IL_010b;
						IL_0106:
						num8 = 0;
						goto IL_0135;
						IL_0135:
						if (num8 < columns)
						{
							goto IL_0118;
						}
						goto IL_013a;
						IL_013a:
						return num;
						IL_0118:
						num7 = 0;
						goto IL_010b;
						IL_010b:
						if (num7 >= rows)
						{
							goto IL_0110;
						}
						goto IL_011d;
						IL_0110:
						num8++;
						goto IL_0135;
						IL_011d:
						if (!itemPlacementGraph[num7, num8])
						{
							goto IL_0129;
						}
						goto IL_012d;
						IL_0129:
						num++;
						goto IL_012d;
						continue;
						end_IL_00e6:
						break;
					}
					continue;
					end_IL_00f2:
					break;
				}
			}
		}
	}

	internal Inventory(long inventoryPageContents, int id)
		: base(inventoryPageContents)
	{
		Id = id;
	}

	internal Inventory(long inventoryPageContents)
		: base(inventoryPageContents)
	{
		Id = 0;
	}

	internal Inventory(long inventoryPageContents, LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType)
		: base(inventoryPageContents)
	{
		Id = 0;
		_sentinelType = sentinelType;
	}

	internal Inventory(long inventoryPageContents, bool isEldrichTab = false, bool isMavenTab = false, List<int> storableBaseItemTypeKeys = null)
		: base(inventoryPageContents)
	{
		Id = 0;
		_isEldrichTab = isEldrichTab;
		_isMavenTab = isMavenTab;
		_storableBaseItemTypeKeys = storableBaseItemTypeKeys;
	}

	private Dictionary<int, long> ReadHashMapStruct242(long pointer, uint size)
	{
		Dictionary<int, long> dictionary = new Dictionary<int, long>();
		if (size != 0)
		{
			Stack<HashNodeStruct242> stack = new Stack<HashNodeStruct242>();
			HashNodeStruct242 @object = GetObject<HashNodeStruct242>(pointer);
			HashNodeStruct242 root = @object.Root;
			stack.Push(root);
			while (stack.Count != 0)
			{
				HashNodeStruct242 hashNodeStruct = stack.Pop();
				if (hashNodeStruct.Address != 0L)
				{
					if (!hashNodeStruct.IsNull && !dictionary.ContainsKey(hashNodeStruct.Key))
					{
						dictionary.Add(hashNodeStruct.Key, hashNodeStruct.Value1);
					}
					HashNodeStruct242 previous = hashNodeStruct.Previous;
					if (!previous.IsNull)
					{
						stack.Push(previous);
					}
					HashNodeStruct242 next = hashNodeStruct.Next;
					if (!next.IsNull)
					{
						stack.Push(next);
					}
				}
			}
			stack.Clear();
			return dictionary;
		}
		return dictionary;
	}

	private bool IsEldrichMavenBaseItemType(int index)
	{
		return _storableBaseItemTypeKeys.Any((int x) => x == index - 1);
	}

	public Item FindItemByPos(Vector2i pos)
	{
		return GetItemAtLocation(pos);
	}

	public Item GetItemById(int id)
	{
		if (ItemMap.TryGetValue(id, out var value))
		{
			return value;
		}
		return null;
	}

	public bool NextAvailableInventoryPosition(int w, int h, out Vector2i pos)
	{
		pos = Vector2i.Zero;
		int rows = Rows;
		int columns = Columns;
		for (int i = 0; i < columns; i++)
		{
			for (int j = 0; j < rows; j++)
			{
				if (CanFitItemAt(i, j, w, h, allowOverlap: false, out var _))
				{
					pos = new Vector2i(i, j);
					return true;
				}
			}
		}
		return false;
	}

	public bool[,] GetItemPlacementGraph()
	{
		int rows = Rows;
		uint num2 = default(uint);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = default(_003C_003Ec__DisplayClass42_0);
		while (true)
		{
			int columns = Columns;
			bool[,] array = new bool[rows, columns];
			while (true)
			{
				IL_0145:
				if (!_isEldrichTab)
				{
					while (!_isMavenTab)
					{
						while (true)
						{
							List<long> list = Containers.StdLongVector<long>(Struct244_0.nativeVector_ItemPlacementGraph);
							if (PageType == InventoryType.SentinelLocker)
							{
								while (true)
								{
									int num = 0;
									while (true)
									{
										LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = _sentinelType;
										while (true)
										{
											switch (sentinelType)
											{
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
												goto IL_0163;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
												goto IL_0168;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
												goto IL_016e;
											case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
												goto IL_0172;
											}
											int num3 = ((int)num2 * -1023287797) ^ -1202476709;
											while (true)
											{
												switch ((num2 = (uint)num3 ^ 0xDC5E9A84u) % 43u)
												{
												case 8u:
													num3 = (int)((num2 * 1425103664) ^ 0x28F51BF3);
													continue;
												case 14u:
													break;
												case 34u:
													goto end_IL_00ec;
												case 33u:
													goto end_IL_0108;
												case 22u:
													goto end_IL_0112;
												case 21u:
													goto end_IL_0117;
												case 35u:
													goto IL_0145;
												case 20u:
												case 37u:
													goto end_IL_0145;
												case 25u:
													goto IL_0163;
												case 1u:
													goto IL_0168;
												case 42u:
													goto IL_016e;
												case 9u:
												case 18u:
												case 41u:
													goto IL_0172;
												case 4u:
													goto IL_0178;
												case 30u:
													goto IL_017d;
												case 10u:
													goto IL_019f;
												case 6u:
												case 29u:
													goto IL_01a5;
												case 24u:
													goto IL_01aa;
												case 26u:
													goto IL_01b0;
												case 15u:
													goto IL_01b9;
												case 32u:
													goto IL_01bb;
												case 7u:
													goto IL_01c0;
												case 11u:
													goto IL_01c5;
												case 28u:
													goto IL_01e7;
												case 12u:
												case 40u:
													goto IL_01ed;
												case 27u:
													goto IL_01f2;
												case 0u:
													goto IL_01f8;
												default:
													goto IL_01fd;
												case 23u:
													goto end_IL_0138;
												case 39u:
													goto IL_0204;
												case 38u:
													goto IL_0209;
												case 31u:
													goto IL_0210;
												case 19u:
													goto IL_0249;
												case 16u:
												case 36u:
													goto IL_024f;
												case 17u:
													goto IL_0254;
												case 2u:
												case 13u:
													goto IL_025a;
												case 3u:
													goto IL_025f;
												}
												break;
											}
											continue;
											IL_017d:
											array[num4, num5] = (ulong)list[num5 + num4 * columns] > 0uL;
											goto IL_019f;
											IL_019f:
											num4++;
											goto IL_01a5;
											IL_016e:
											num = 24;
											goto IL_0172;
											IL_0168:
											num = 12;
											goto IL_0172;
											IL_0163:
											num = 0;
											goto IL_0172;
											IL_0172:
											num5 = num;
											goto IL_01b0;
											IL_01b0:
											if (num5 < num + 12)
											{
												goto IL_0178;
											}
											goto IL_01b9;
											IL_01b9:
											return array;
											IL_0178:
											num4 = 0;
											goto IL_01a5;
											IL_01a5:
											if (num4 < rows)
											{
												goto IL_017d;
											}
											goto IL_01aa;
											IL_01aa:
											num5++;
											goto IL_01b0;
											continue;
											end_IL_00ec:
											break;
										}
										continue;
										end_IL_0108:
										break;
									}
									continue;
									end_IL_0112:
									break;
								}
								continue;
							}
							goto IL_01bb;
							IL_01e7:
							num6++;
							goto IL_01ed;
							IL_01bb:
							num7 = 0;
							goto IL_01f8;
							IL_01f8:
							if (num7 < columns)
							{
								goto IL_01c0;
							}
							goto IL_01fd;
							IL_01fd:
							return array;
							IL_01c0:
							num6 = 0;
							goto IL_01ed;
							IL_01ed:
							if (num6 < rows)
							{
								goto IL_01c5;
							}
							goto IL_01f2;
							IL_01f2:
							num7++;
							goto IL_01f8;
							IL_01c5:
							array[num6, num7] = (ulong)list[num7 + num6 * columns] > 0uL;
							goto IL_01e7;
							continue;
							end_IL_0117:
							break;
						}
						continue;
						end_IL_0138:
						break;
					}
				}
				num8 = 0;
				goto IL_025a;
				IL_0249:
				num9++;
				goto IL_024f;
				IL_0210:
				_003C_003Ec__DisplayClass42_._003C_003E4__this = this;
				_003C_003Ec__DisplayClass42_.col = num8 + 12 * num9;
				array[num9, num8] = ItemMap.Any(_003C_003Ec__DisplayClass42_._003CGetItemPlacementGraph_003Eb__0);
				goto IL_0249;
				IL_025a:
				if (num8 < columns)
				{
					goto IL_0204;
				}
				goto IL_025f;
				IL_025f:
				return array;
				IL_0204:
				num9 = 0;
				goto IL_024f;
				IL_024f:
				if (num9 < rows)
				{
					goto IL_0209;
				}
				goto IL_0254;
				IL_0254:
				num8++;
				goto IL_025a;
				IL_0209:
				_003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
				goto IL_0210;
				continue;
				end_IL_0145:
				break;
			}
		}
	}

	public bool CanFitItemAt(int col, int row, int width, int height, bool allowOverlap, out bool overlapped)
	{
		overlapped = false;
		if (col < 0)
		{
			return false;
		}
		if (row >= 0)
		{
			if (col + width > Columns)
			{
				return false;
			}
			if (row + height > Rows)
			{
				return false;
			}
			List<long> list = new List<long>();
			for (int i = col; i < col + width; i++)
			{
				for (int j = row; j < row + height; j++)
				{
					Item itemAtLocation = GetItemAtLocation(i, j);
					if (itemAtLocation != null)
					{
						if (!allowOverlap)
						{
							overlapped = true;
							return false;
						}
						if (!list.Contains(itemAtLocation.Address))
						{
							list.Add(itemAtLocation.Address);
						}
					}
				}
			}
			overlapped = list.Count > 1;
			return list.Count <= 1;
		}
		return false;
	}

	public Item GetItemAtLocation(Vector2i pos)
	{
		return GetItemAtLocation(pos.X, pos.Y);
	}

	public Item GetItemAtLocation(int col, int row)
	{
		if (PageType == InventoryType.SentinelLocker)
		{
			uint num = default(uint);
			while (true)
			{
				switch (_sentinelType)
				{
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
					goto IL_0086;
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
					goto IL_008e;
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
				case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
					goto end_IL_0067;
				}
				int num2 = (int)(num * 450914602) ^ -1339862452;
				while (true)
				{
					switch ((num = (uint)num2 ^ 0x231D65F5u) % 9u)
					{
					case 7u:
						num2 = ((int)num * -1038425584) ^ -229457775;
						continue;
					case 2u:
					case 3u:
						break;
					case 0u:
						goto IL_0086;
					case 4u:
						goto IL_008e;
					case 5u:
					case 8u:
						goto end_IL_0067;
					case 1u:
						goto IL_009f;
					default:
						goto IL_017a;
					}
					break;
				}
				continue;
				IL_008e:
				col += 24;
				break;
				IL_0086:
				col += 12;
				break;
				continue;
				end_IL_0067:
				break;
			}
		}
		if (!_isEldrichTab)
		{
			goto IL_009f;
		}
		goto IL_017a;
		IL_009f:
		if (!_isMavenTab)
		{
			foreach (Item item in Items)
			{
				Vector2i locationTopLeft = item.LocationTopLeft;
				Vector2i size = item.Size;
				if ((size.X > 1 || size.Y > 1) && size.X >= 1 && size.Y >= 1)
				{
					if (new Rect(locationTopLeft.X, locationTopLeft.Y, size.X - 1, size.Y - 1).Contains(col, row))
					{
						return item;
					}
				}
				else if (locationTopLeft.X == col && locationTopLeft.Y == row)
				{
					return item;
				}
			}
			return null;
		}
		goto IL_017a;
		IL_017a:
		foreach (Item item2 in Items)
		{
			Vector2i locationTopLeft2 = item2.LocationTopLeft;
			if (locationTopLeft2.X != col + 12 * row || locationTopLeft2.Y != ((!_isEldrichTab) ? 1 : 2))
			{
				continue;
			}
			return item2;
		}
		return null;
	}

	public bool CanFitItem(Item item)
	{
		int col;
		int row;
		return CanFitItem(item, out col, out row);
	}

	internal void SetId(int int_1)
	{
		Id = int_1;
	}

	public bool CanFitItem(Item item, out int col, out int row)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		return CanFitItem(item.Size, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize, out int col, out int row)
	{
		return CanFitItem(itemSize.X, itemSize.Y, out col, out row);
	}

	public bool CanFitItem(Vector2i itemSize)
	{
		int fcol;
		int frow;
		return CanFitItem(itemSize.X, itemSize.Y, out fcol, out frow);
	}

	public bool CanFitItem(int itemWidth, int itemHeight, out int fcol, out int frow)
	{
		fcol = -1;
		frow = -1;
		if (PageType != InventoryType.Cursor)
		{
			uint num2 = default(uint);
			int num4 = default(int);
			int num5 = default(int);
			Vector2i vector2i = default(Vector2i);
			Vector2i vector2i2 = default(Vector2i);
			bool flag = default(bool);
			int num6 = default(int);
			int num7 = default(int);
			LokiPoe.InGameState.SentinelLockerUi.SentinelType sentinelType = default(LokiPoe.InGameState.SentinelLockerUi.SentinelType);
			int num8 = default(int);
			int num9 = default(int);
			Vector2i vector2i3 = default(Vector2i);
			Vector2i vector2i4 = default(Vector2i);
			bool flag2 = default(bool);
			int num10 = default(int);
			int num11 = default(int);
			while (true)
			{
				bool[,] itemPlacementGraph = GetItemPlacementGraph();
				int columns = Columns;
				while (true)
				{
					int rows = Rows;
					while (true)
					{
						if (PageType == InventoryType.SentinelLocker)
						{
							while (true)
							{
								IL_025b:
								int num = 0;
								switch (_sentinelType)
								{
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
									break;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
									goto IL_0239;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
									goto IL_023c;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
									goto IL_0242;
								default:
									goto IL_0248;
								}
								goto IL_0233;
								IL_0248:
								int num3 = (int)(num2 * 905364816) ^ -1164180507;
								goto IL_0047;
								IL_0233:
								num = 12;
								goto IL_023c;
								IL_023c:
								num4 = num;
								goto IL_0221;
								IL_0221:
								if (num4 < num + 12 - (itemWidth - 1))
								{
									goto IL_0216;
								}
								goto IL_0389;
								IL_0216:
								num5 = 0;
								goto IL_020b;
								IL_020b:
								if (num5 < rows - (itemHeight - 1))
								{
									goto IL_01e6;
								}
								goto IL_021b;
								IL_01e6:
								vector2i = new Vector2i(num4, num5);
								vector2i2 = new Vector2i(num4 + itemWidth, num5 + itemHeight);
								flag = true;
								goto IL_01db;
								IL_01db:
								num6 = vector2i.X;
								goto IL_01ce;
								IL_01ce:
								if (num6 >= vector2i2.X)
								{
									goto IL_0193;
								}
								goto IL_01bd;
								IL_01bd:
								num7 = vector2i.Y;
								goto IL_01b0;
								IL_01b0:
								if (num7 < vector2i2.Y)
								{
									goto IL_019e;
								}
								goto IL_01c8;
								IL_019e:
								if (itemPlacementGraph[num7, num6])
								{
									goto IL_0199;
								}
								goto IL_01aa;
								IL_0199:
								flag = false;
								goto IL_0193;
								IL_0193:
								if (flag)
								{
									goto IL_0189;
								}
								goto IL_0205;
								IL_0189:
								sentinelType = _sentinelType;
								goto IL_016d;
								IL_016d:
								switch (sentinelType)
								{
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Stalker:
									goto IL_036c;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Pandemonium:
									goto IL_0372;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Apex:
									goto IL_037b;
								case LokiPoe.InGameState.SentinelLockerUi.SentinelType.Unknown:
									goto IL_0382;
								}
								num3 = ((int)num2 * -1242502330) ^ 0x6B30FDF0;
								goto IL_0047;
								IL_0389:
								return false;
								IL_0047:
								while (true)
								{
									switch ((num2 = (uint)num3 ^ 0x5816ABDDu) % 68u)
									{
									case 12u:
										num3 = (int)(num2 * 1040960454) ^ -867317926;
										continue;
									case 11u:
										num3 = (int)((num2 * 1907343711) ^ 0xD858AA6);
										continue;
									case 31u:
										break;
									case 30u:
										goto IL_0189;
									case 40u:
									case 50u:
										goto IL_0193;
									case 47u:
										goto IL_0199;
									case 41u:
										goto IL_019e;
									case 3u:
										goto IL_01aa;
									case 32u:
									case 39u:
										goto IL_01b0;
									case 23u:
										goto IL_01bd;
									case 55u:
										goto IL_01c8;
									case 35u:
									case 61u:
										goto IL_01ce;
									case 65u:
										goto IL_01db;
									case 60u:
										goto IL_01e6;
									case 7u:
										goto IL_0205;
									case 24u:
										goto IL_020b;
									case 16u:
										goto IL_0216;
									case 64u:
										goto IL_021b;
									case 46u:
										goto IL_0221;
									case 0u:
										goto IL_0233;
									case 59u:
										goto IL_0239;
									case 15u:
									case 34u:
										goto IL_023c;
									case 49u:
										goto IL_0242;
									case 6u:
										goto IL_025b;
									case 52u:
										goto end_IL_025b;
									case 17u:
										goto end_IL_027f;
									case 45u:
										goto end_IL_028b;
									case 8u:
									case 37u:
										goto end_IL_0294;
									case 42u:
										goto IL_02b5;
									case 53u:
										goto IL_02bd;
									case 27u:
										goto IL_02c0;
									case 22u:
										goto IL_02c7;
									case 66u:
										goto IL_02c9;
									case 9u:
										goto IL_02cf;
									case 19u:
										goto IL_02da;
									case 1u:
										goto IL_02e5;
									case 18u:
										goto IL_02f1;
									case 56u:
										goto IL_02f9;
									case 14u:
									case 36u:
										goto IL_02fc;
									case 29u:
										goto IL_0300;
									case 54u:
										goto IL_0308;
									case 20u:
										goto IL_0310;
									case 33u:
									case 51u:
										goto IL_0313;
									case 57u:
										goto IL_031c;
									case 43u:
										goto IL_0327;
									case 26u:
										goto IL_0336;
									case 21u:
										goto IL_0339;
									case 2u:
									case 25u:
									case 58u:
										goto IL_0344;
									case 13u:
									case 38u:
										goto IL_0354;
									case 28u:
										goto IL_035f;
									default:
										goto IL_036a;
									case 44u:
										goto IL_036c;
									case 63u:
										goto IL_0372;
									case 5u:
										goto IL_037b;
									case 10u:
									case 48u:
									case 62u:
										goto IL_0382;
									case 4u:
										goto IL_0389;
									}
									break;
								}
								goto IL_016d;
								IL_037b:
								fcol = num4 - 24;
								goto IL_0382;
								IL_0372:
								fcol = num4 - 12;
								goto IL_0382;
								IL_036c:
								fcol = num4;
								goto IL_0382;
								IL_0382:
								frow = num5;
								return true;
								IL_0242:
								num = 24;
								goto IL_023c;
								IL_0239:
								num = 0;
								goto IL_023c;
								IL_0205:
								num5++;
								goto IL_020b;
								IL_01c8:
								num6++;
								goto IL_01ce;
								IL_01aa:
								num7++;
								goto IL_01b0;
								IL_021b:
								num4++;
								goto IL_0221;
								continue;
								end_IL_025b:
								break;
							}
							continue;
						}
						goto IL_02b5;
						IL_036a:
						return false;
						IL_02b5:
						num8 = 0;
						goto IL_0354;
						IL_0354:
						if (num8 < columns - (itemWidth - 1))
						{
							goto IL_0310;
						}
						goto IL_036a;
						IL_0310:
						num9 = 0;
						goto IL_0313;
						IL_0313:
						if (num9 >= rows - (itemHeight - 1))
						{
							goto IL_0308;
						}
						goto IL_031c;
						IL_031c:
						vector2i3 = new Vector2i(num8, num9);
						goto IL_0327;
						IL_0327:
						vector2i4 = new Vector2i(num8 + itemWidth, num9 + itemHeight);
						goto IL_0336;
						IL_0336:
						flag2 = true;
						goto IL_0339;
						IL_0339:
						num10 = vector2i3.X;
						goto IL_02cf;
						IL_02cf:
						if (num10 < vector2i4.X)
						{
							goto IL_02da;
						}
						goto IL_02fc;
						IL_02da:
						num11 = vector2i3.Y;
						goto IL_0344;
						IL_0344:
						if (num11 >= vector2i4.Y)
						{
							goto IL_02c9;
						}
						goto IL_02e5;
						IL_02c9:
						num10++;
						goto IL_02cf;
						IL_02e5:
						if (!itemPlacementGraph[num11, num10])
						{
							goto IL_02f1;
						}
						goto IL_02f9;
						IL_02f1:
						num11++;
						goto IL_0344;
						IL_02f9:
						flag2 = false;
						goto IL_02fc;
						IL_02fc:
						if (!flag2)
						{
							goto IL_0300;
						}
						goto IL_035f;
						IL_0300:
						num9++;
						goto IL_0313;
						IL_035f:
						fcol = num8;
						frow = num9;
						return true;
						IL_0308:
						num8++;
						goto IL_0354;
						continue;
						end_IL_027f:
						break;
					}
					continue;
					end_IL_028b:
					break;
				}
				continue;
				end_IL_0294:
				break;
			}
		}
		bool flag3 = !Items.Any();
		goto IL_02bd;
		IL_02c0:
		fcol = 0;
		frow = 0;
		goto IL_02c7;
		IL_02bd:
		if (flag3)
		{
			goto IL_02c0;
		}
		goto IL_02c7;
		IL_02c7:
		return flag3;
	}

	public bool CanSlideItemUpOrLeft(Item item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (!item.HasInventoryLocation)
		{
			throw new Exception($"The item {item.FullName} does not have an inventory location.");
		}
		bool[,] itemPlacementGraph = GetItemPlacementGraph();
		bool flag = true;
		if (item.LocationTopLeft.Y <= 0)
		{
			flag = false;
		}
		else
		{
			for (int i = 0; i < item.Size.X; i++)
			{
				if (itemPlacementGraph[item.LocationTopLeft.Y - 1, item.LocationTopLeft.X + i])
				{
					flag = false;
					break;
				}
			}
		}
		bool flag2 = true;
		if (item.LocationTopLeft.X <= 0)
		{
			flag2 = false;
		}
		else
		{
			for (int j = 0; j < item.Size.Y; j++)
			{
				if (itemPlacementGraph[item.LocationTopLeft.Y + j, item.LocationTopLeft.X - 1])
				{
					flag2 = false;
					break;
				}
			}
		}
		return flag2 || flag;
	}

	public bool CanFitItemSizeAt(int itemWidth, int itemHeight, int col, int row)
	{
		Vector2i vector2i = new Vector2i(col, row);
		Vector2i vector2i2 = new Vector2i(col + itemWidth, row + itemHeight);
		if (vector2i2.X <= Columns && vector2i2.Y <= Rows)
		{
			bool[,] itemPlacementGraph = GetItemPlacementGraph();
			for (int i = vector2i.X; i < vector2i2.X; i++)
			{
				for (int j = vector2i.Y; j < vector2i2.Y; j++)
				{
					if (itemPlacementGraph[j, i])
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	public Item FindItemByFullName(string fullName)
	{
		return Items.FirstOrDefault((Item x) => x.FullName == fullName);
	}

	public Item FindItemByName(string name)
	{
		return Items.FirstOrDefault((Item x) => x.Name == name);
	}

	private int GetTotalItemQuantity(IEnumerable<Item> ienumerable_0)
	{
		int num = 0;
		foreach (Item item in ienumerable_0)
		{
			num += item.StackCount;
		}
		return num;
	}

	public int GetTotalItemQuantityByName(string name)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Name == name);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByFullName(string fullName)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.FullName == fullName);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadata(string metadata)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.Metadata == metadata);
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemQuantityByMetadataFlags(MetadataFlags flag)
	{
		IEnumerable<Item> ienumerable_ = Items.Where((Item x) => x.HasMetadataFlags(flag));
		return GetTotalItemQuantity(ienumerable_);
	}

	public int GetTotalItemStacksByFullName(string fullName)
	{
		return Items.Count((Item x) => x.FullName == fullName);
	}

	public bool NeedsToMerge()
	{
		List<Item> list = (from x in Items
			where x.Rarity == Rarity.Currency && x.Rarity != Rarity.Quest && x.MaxStackCount > 1 && x.StackCount != x.MaxStackCount
			orderby x.FullName
			select x).ToList();
		int num = 0;
		while (true)
		{
			if (num < list.Count - 1)
			{
				Item item = list[num];
				Item item2 = list[num + 1];
				if (item.FullName == item2.FullName)
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"[Inventory] {Id}");
		stringBuilder.AppendLine($"\tIsRequested: {IsRequested}");
		stringBuilder.AppendLine($"\tPageType: {PageType}");
		stringBuilder.AppendLine($"\tPageSlot: {PageSlot}");
		stringBuilder.AppendLine($"\tRows: {Rows}");
		stringBuilder.AppendLine($"\tCols: {Cols}");
		stringBuilder.AppendLine($"\t[Items]");
		foreach (Item item in Items)
		{
			stringBuilder.AppendLine($"\t\t{item.StackCount}x {item.FullName}");
		}
		return stringBuilder.ToString();
	}
}
