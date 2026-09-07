using System.Collections.Generic;

namespace DebugMod
{
    internal enum Language { RU, EN, SCH }

    internal static class L
    {
        public static Language Current = Language.SCH;

        public static string T(string key, params object[] args)
        {
            string tpl = _t.TryGetValue(key, out var d) && d.TryGetValue(Current, out var s) ? s : key;
            return args.Length > 0 ? string.Format(tpl, args) : tpl;
        }

        private static Dictionary<Language, string> D(string ru, string en) =>
            new Dictionary<Language, string> { [Language.RU] = ru, [Language.EN] = en, [Language.SCH] = sch };

        private static readonly Dictionary<string, Dictionary<Language, string>> _t =
            new Dictionary<string, Dictionary<Language, string>>
        {
            // ── Окно ────────────────────────────────────────────────────────────
            { "win.title",     D("  DEBUG CHEAT MENU  |  {0} — закрыть",  "  DEBUG CHEAT MENU  |  {0} — close"),  "  调试作弊菜单  |  {0} — 关闭") },
            { "btn.refresh",   D("↺  Обновить списки",                    "↺  Refresh lists", "↺  刷新列表") },

            // ── Вкладки ─────────────────────────────────────────────────────────
            { "tab.npc",      D("NPC",     "NPC", "NPC") },
            { "tab.player",   D("ИГРОК",   "PLAYER", "玩家") },
            { "tab.event",    D("СОБЫТИЕ", "EVENT", "事件") },
            { "tab.item",     D("ПРЕДМЕТ", "ITEM", "物品") },
            { "tab.baldi",    D("БАЛДИ",   "BALDI", "巴迪") },
            { "tab.time",     D("ВРЕМЯ",   "TIME", "时间") },
            { "tab.rooms",    D("КОМНАТЫ", "ROOMS", "房间") },
            { "tab.log",      D("ЛОГ",     "LOG", "日志") },
            { "tab.camera",   D("КАМЕРА",  "CAMERA", "相机") },
            { "tab.stats",    D("СТАТ",    "STATS", "状态") },
            { "tab.settings", D("НАСТР",   "SETTINGS", "设置") },

            // ── NPC ─────────────────────────────────────────────────────────────
            { "npc.spawn_tab",    D("Спавн NPC",    "Spawn NPC", "生成 NPC") },
            { "npc.live_tab",     D("Активные NPC", "Active NPCs", "激活 NPC") },
            { "npc.pfx_count",    D("Префабов: {0}  (базовая игра + моды)", "Prefabs: {0}  (base + mods)", "预制体: {0}  (基础游戏 + 模组)") },
            { "npc.live_count",   D("Активных на уровне: {0}",              "Active on level: {0}", "在楼层激活: {0}") },
            { "npc.spawn",        D("Спавн",   "Spawn", "生成") },
            { "npc.tp_to",        D("ТП↓",     "TP↓", "传送↓") },
            { "npc.freeze",       D("Заморз",  "Freeze", "冻结") },
            { "npc.unfreeze",     D("Размрз",  "Unfrz", "解冻") },
            { "npc.delete",       D("Удал",    "Del", "删除") },
            { "npc.freeze_all",   D("Заморозить всех",               "Freeze all", "全部冻结") },
            { "npc.unfreeze_all", D("Разморозить всех",              "Unfreeze all", "全部解冻") },
            { "npc.delete_all",   D("Удалить всех  (кроме Балди!)",  "Delete all  (except Baldi!)", "全部删除  (巴迪除外!)") },

            // ── Player ──────────────────────────────────────────────────────────
            { "pl.godmode",    D("  Бог-мод (нет урона, Балди не ловит)",           "  God Mode (no damage, Baldi can't catch)", "  上帝模式 (无伤, 巴迪不能抓你)") },
            { "pl.stamina",    D("  Бесконечная выносливость",                      "  Infinite Stamina", "  无限体力") },
            { "pl.stealth",    D("  Стелс (NPC тебя не замечают; Балди — нет)",     "  Stealth (NPCs ignore you; Baldi — no)", "  隐身 (NPC 忽视你; 除了巴迪)") },
            { "pl.noclip",     D("  Ноклип  (WASD сквозь стены, Space↑ Ctrl↓)",    "  Noclip  (WASD through walls, Space↑ Ctrl↓)", "  穿墙  (WASD 穿墙, 空格↑ Ctrl↓)") },
            { "pl.fly",        D("  Полёт  (Space↑ Ctrl↓ или колёсико)",            "  Fly  (Space↑ Ctrl↓ or scroll)", "  飞行  (空格↑ Ctrl↓ 或者滚轮)") },
            { "pl.fly_h",      D("  Высота: {0:F1}",  "  Height: {0:F1}", "  高度: {0:F1}") },
            { "pl.speed",      D("Скорость  ×{0:F1}", "Speed  ×{0:F1}", "速度  ×{0:F1}") },
            { "pl.give_all",   D("Дать все предметы",             "Give all items", "获取所有物品") },
            { "pl.clear_inv",  D("Очистить инвентарь",            "Clear inventory", "清空物品栏") },
            { "pl.tp_random",  D("Телепорт в случайную комнату",  "Teleport to random room", "传送到随机房间") },
            { "pl.fill_stam",  D("Восстановить выносливость",     "Restore stamina", "恢复体力") },
            { "pl.collect_nb", D("Собрать все тетради",           "Collect all notebooks", "一键收集笔记本") },
            { "pl.solve_math", D("Решить все задачники",          "Solve all math machines", "一键解决数学机器") },
            { "pl.win",        D("★  Завершить уровень (победа)", "★  Complete level (win)", "★  完成楼层 (直接胜利)") },
            { "pl.bookmarks",  D("Закладки телепорта:",           "Teleport bookmarks:", "传送书签:") },
            { "pl.bm_save",    D("Сохр",     "Save", "保存") },
            { "pl.bm_tp",      D("ТП",       "TP", "传送") },
            { "pl.bm_empty",   D("— пусто —","— empty —", "— 空 —") },

            // ── Event ───────────────────────────────────────────────────────────
            { "ev.count",    D("Всего событий: {0}  (базовая игра + моды)", "Total events: {0}  (base + mods)", "所有事件: {0}  (基础游戏 + 模组)") },
            { "ev.start",    D("Старт",                  "Start", "开始") },
            { "ev.stop_all", D("Остановить все события", "Stop all events", "停止全部事件") },

            // ── Item ────────────────────────────────────────────────────────────
            { "it.count", D("Всего предметов: {0}  (базовая игра + моды)", "Total items: {0}  (base + mods)", "所有物品: {0}  (基础游戏 + 模组)") },
            { "it.give",  D("Дать",   "Give", "获取") },
            { "it.drop",  D("На пол", "Drop", "丢弃") },

            // ── Baldi ───────────────────────────────────────────────────────────
            { "baldi.not_found",   D("Балди не найден на уровне.",             "Baldi not found on level.", "没在楼层找到巴迪.") },
            { "baldi.anger",       D("Злость: {0:F2}",                         "Anger: {0:F2}", "怒气值: {0:F2}") },
            { "baldi.freeze",      D("  Заморозить Балди (отключить AI)",       "  Freeze Baldi (disable AI)", "  冻结巴迪 (禁用 AI)") },
            { "baldi.to_player",   D("Телепортировать Балди к игроку",         "Teleport Baldi to player", "传送巴迪到玩家") },
            { "baldi.player_to",   D("Телепортировать игрока к Балди",         "Teleport player to Baldi", "传送玩家到巴迪") },
            { "baldi.remove",      D("Убрать Балди с уровня",                  "Remove Baldi from level", "从楼层移除巴迪") },
            { "baldi.anger_0",     D("Злость = 0",   "Anger = 0", "怒气归零") },
            { "baldi.anger_max",   D("Злость = MAX", "Anger = MAX", "拉满怒气") },

            // ── Time ────────────────────────────────────────────────────────────
            { "time.scale",  D("Time.timeScale = {0:F2}x", "Time.timeScale = {0:F2}x", "时间速度 (Time.timeScale) = {0:F2}x") },
            { "time.pause",  D("Пауза  0x",     "Pause  0x", "暂停  0x") },
            { "time.slow",   D("Замедл. 0.25x", "Slow 0.25x", "慢速 0.25x") },
            { "time.normal", D("Норма  1x",      "Normal 1x", "常速 1x") },
            { "time.fast",   D("Ускор. 3x",      "Fast 3x", "快速 3x") },
            { "time.max",    D("Максимум  5x",   "Max  5x", "满速 5x") },

            // ── Rooms ───────────────────────────────────────────────────────────
            { "rooms.count",   D("Комнат на уровне: {0}", "Rooms on level: {0}", "楼层房间: {0}") },
            { "rooms.tp",      D("ТП",                    "TP", "传送") },
            { "rooms.refresh", D("Обновить список комнат","Refresh room list", "刷新房间列表") },

            // ── Log ─────────────────────────────────────────────────────────────
            { "log.title",  D("BepInEx лог — {0} строк:", "BepInEx log — {0} lines:", "BepInEx 日志 — {0} 行:") },
            { "log.bottom", D("↓ В конец", "↓ Bottom", "↓ 底部") },
            { "log.clear",  D("Очистить",  "Clear", "清除") },

            // ── Camera ──────────────────────────────────────────────────────────
            { "cam.hitboxes",   D("  Показать хитбоксы NPC",                           "  Show NPC hitboxes", "显示 NPC 碰撞箱") },
            { "cam.freecam",    D("  Свободная камера  (WASD + ПКМ поворот, Q↑ E↓)",  "  Free camera  (WASD + RMB rotate, Q↑ E↓)", "  灵魂出窍  (WASD + 右键旋转, Q↑ E↓)") },
            { "cam.speed",      D("  Скорость камеры: {0:F0}",                         "  Camera speed: {0:F0}", "  相机速度: {0:F0}") },
            { "cam.return",     D("Вернуть камеру к игроку", "Return camera to player", "灵魂回归") },
            { "cam.screenshot", D("Скриншот",  "Screenshot", "截图") },

            // ── Stats ───────────────────────────────────────────────────────────
            { "stat.fps",       D("FPS: {0:F1}",                                     "FPS: {0:F1}", "FPS: {0:F1}") },
            { "stat.pos",       D("Позиция: X={0:F1}  Y={1:F1}  Z={2:F1}",          "Position: X={0:F1}  Y={1:F1}  Z={2:F1}", "位置: X={0:F1}  Y={1:F1}  Z={2:F1}") },
            { "stat.room",      D("Комната: {0}",                                    "Room: {0}", "房间: {0}") },
            { "stat.stealth",   D("Стелс: {0}   Бессм: {1}",                        "Stealth: {0}   Invincible: {1}", "隐身: {0}   无敌: {1}") },
            { "stat.no_player", D("Игрок не найден (не в уровне)",                  "Player not found (not in level)", "未找到玩家 (不在楼层)") },
            { "stat.baldi",     D("Балди: злость={0:F2}  AI={1}",                   "Baldi: anger={0:F2}  AI={1}", "巴迪: 怒气值={0:F2}  AI={1}") },
            { "stat.baldi_st",  D("  Состояние: {0}",                               "  State: {0}", "  状态: {0}") },
            { "stat.notebooks", D("Тетради: собрано {0} / {1}  (осталось {2})",     "Notebooks: collected {0} / {1}  (left {2})", "笔记本: 已收集 {0} / {1}") },
            { "stat.npcs",      D("NPC на уровне: {0}",                             "NPCs on level: {0}", "楼层 NPC: {0}") },
            { "stat.frozen",    D("  Заморожено: {0}",                              "  Frozen: {0}", "  已冻结: {0}") },
            { "stat.events",    D("Активных событий: {0}",                          "Active events: {0}", "活动事件: {0}") },
            { "stat.ts",        D("timeScale: {0:F2}×",                             "timeScale: {0:F2}×", "时间速度: {0:F2}×") },
            { "stat.ram",       D("RAM (Mono): {0:F1} MB",                          "RAM (Mono): {0:F1} MB", "内存 (Mono): {0:F1} MB") },
            { "stat.ytp",       D("YTP: {0}",                                       "YTP: {0}", "YTP 答题机: {0}") },

            // ── Settings ────────────────────────────────────────────────────────
            { "set.keys",       D("── Клавиши ──────────────────────────", "── Key Bindings ────────────────────", "── 按键绑定 ────────────────────") },
            { "set.key_debug",  D("Debug Mode (вкл/выкл):", "Debug Mode (toggle):", "调试模式 (开关):") },
            { "set.key_menu",   D("Открыть меню:",           "Open menu:", "打开菜单:") },
            { "set.waiting",    D("  Нажми любую клавишу...  (Esc = отмена)", "  Press any key...  (Esc = cancel)", "  按下按键...  (Esc 取消)") },
            { "set.hud",        D("── HUD ──────────────────────────────", "── HUD ─────────────────────────────", "── HUD ─────────────────────────────") },
            { "set.show_label", D("  Показывать индикатор [DEBUG ON]",  "  Show [DEBUG ON] indicator", "  展示 [调试开启] 指示器") },
            { "set.show_fps",   D("  Показывать FPS счётчик",           "  Show FPS counter", "  显示 FPS 计数器") },
            { "set.show_msg",   D("  Показывать зелёные сообщения",     "  Show green messages", "  显示绿色消息") },
            { "set.params",     D("── Параметры ────────────────────────", "── Parameters ──────────────────────", "── 数值 ──────────────────────") },
            { "set.noclip_spd", D("Скорость ноклипа: {0:F0} ед/с",     "Noclip speed: {0:F0} u/s", "穿墙速度: {0:F0} u/s") },
            { "set.msg_dur",    D("Длительность сообщений: {0:F1} с",   "Message duration: {0:F1} s", "消息显示时间: {0:F1} s") },
            { "set.reset",      D("Сбросить всё к умолчанию",           "Reset all to default", "重置所有到默认值") },
            { "set.lang",       D("── Язык / Language ─────────────────", "── Language / Язык ─────────────────", "── 语言 ─────────────────") },

            // ── Поиск ───────────────────────────────────────────────────────────
            { "search", D("Поиск:", "Search:", "搜索:") },

            // ── Сообщения ───────────────────────────────────────────────────────
            { "msg.no_level",     D("Уровень не загружен",   "Level not loaded", "楼层未加载") },
            { "msg.no_player",    D("Игрок не найден",        "Player not found", "玩家未找到") },
            { "msg.spawned",      D("Заспавнен: {0}",         "Spawned: {0}", "已生成: {0}") },
            { "msg.err",          D("Ошибка: {0}",            "Error: {0}", "错误: {0}") },
            { "msg.deleted",      D("Удалён: {0}",            "Deleted: {0}", "已删除: {0}") },
            { "msg.frozen",       D("Заморожен: {0}",         "Frozen: {0}", "已冻结: {0}") },
            { "msg.unfrozen",     D("Разморожен: {0}",        "Unfrozen: {0}", "已解冻: {0}") },
            { "msg.tp_to",        D("ТП к: {0}",              "TP to: {0}", "传送至: {0}") },
            { "msg.given",        D("Выдан: {0}",             "Given: {0}", "已给予: {0}") },
            { "msg.given_all",    D("Выдано предметов: {0}",  "Items given: {0}", "已给予物品: {0}") },
            { "msg.inv_cleared",  D("Инвентарь очищен",       "Inventory cleared", "已清空物品栏") },
            { "msg.dropped",      D("На пол: {0}",            "Dropped: {0}", "已丢弃: {0}") },
            { "msg.no_pickup",    D("Шаблон Pickup не найден — выдан в инвентарь: {0}", "No Pickup template — added to inventory: {0}", "没有拾取模板 — 已加入物品栏: {0}") },
            { "msg.event",        D("Событие: {0}",           "Event: {0}", "事件: {0}") },
            { "msg.events_off",   D("Все события остановлены","All events stopped", "所有时间已停止") },
            { "msg.no_notebooks", D("Тетради не найдены",     "No notebooks found", "未找到笔记本") },
            { "msg.nb_collected", D("Тетрадей собрано: {0}",  "Notebooks collected: {0}", "已收集笔记本: {0}") },
            { "msg.math_solved",  D("Задачников решено: {0} из {1}", "Math machines solved: {0} of {1}", "已解决数学机器: {0} / {1}") },
            { "msg.no_machines",  D("Задачники не найдены",   "No math machines found", "未找到数学机器") },
            { "msg.win",          D("Собрано тетрадей: {0}, открыто выходов: {1}", "Notebooks: {0}, exits opened: {1}", "笔记本: {0}, 打开的出口: {1}") },
            { "msg.tp_done",      D("Телепортирован",         "Teleported", "已传送") },
            { "msg.no_tiles",     D("Нет тайлов",             "No tiles", "没有项目") },
            { "msg.b2p",          D("Балди → игрок",          "Baldi → player", "巴迪 → 玩家") },
            { "msg.p2b",          D("Игрок → Балди",          "Player → Baldi", "玩家 → 巴迪") },
            { "msg.freecam_on",   D("Свободная камера: WASD + ПКМ (поворот), Q/E вверх/вниз", "Free camera: WASD + RMB (rotate), Q/E up/down", "灵魂出窍: WASD + 右键 (旋转), Q/E 上下") },
            { "msg.freecam_off",  D("Камера возвращена к игроку", "Camera returned to player", "灵魂已回归") },
            { "msg.no_cam",       D("Камера не найдена",      "Camera not found", "相机未找到") },
            { "msg.screenshot",   D("Скриншот: {0}",          "Screenshot: {0}", "截图: {0}") },
            { "msg.no_cgm",       D("CoreGameManager не найден", "CoreGameManager not found", "未找到 CoreGameManager") },
            { "msg.no_endseq",    D("EndSequence не найден",  "EndSequence not found", "未找到 EndSequence") },
            { "msg.bm_saved",     D("Закладка {0} сохранена", "Bookmark {0} saved", "已保存书签 {0}") },
            { "msg.bm_tp",        D("→ Закладка {0}",         "→ Bookmark {0}", "→ 书签 {0}") },
            { "msg.set_reset",    D("Настройки сброшены",     "Settings reset", "已重置设置") },
            { "msg.key_set",      D("Клавиша установлена: {0}","Key set: {0}", "已设置按键: {0}") },
            { "msg.ytp",          D("+{0} YTP", "+{0} YTP", "+{0} YTP 答题机") },
            { "msg.room_tp",      D("→ {0}", "→ {0}", "→ {0}") },
            { "msg.refreshed",    D("Обновлено: {0} NPC · {1} предм. · {2} событий · {3} комнат",
                                    "Refreshed: {0} NPCs · {1} items · {2} events · {3} rooms",
                                    "已刷新: {0} 个 NPC · {1} 个物品 · {2} 个事件 · {3} 个房间") },
        };
    }
}
